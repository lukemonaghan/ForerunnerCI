using System;
using DiscordSharp;
using System.Threading;
using DiscordSharp.Objects;

namespace DiscordSharpTestApplication
{
    public class Program
    {
        public static DiscordClient client = new DiscordClient();

        public static void Main(string[] args)
        {
			// args[0] = username
			// args[1] = password
			// args[2] = serverID
			// args[3] = channelID
			// args[4-n] = message

	        if (args.Length < 4)
	        {
				Console.WriteLine("Args Mismatch, should be \n EMAIL PASSWORD SERVER_ID CHANNEL_ID MESSAGE STRING GOES AT THE END");
				Thread.Sleep(1000);
				return;
	        }

	        foreach (var v in args)
	        {
				Console.WriteLine(v);
	        }

			// Bot instantiate
			Console.WriteLine("DiscordSharp Command Bot");

            client.ClientPrivateInformation = new DiscordUserInformation();

            // Bot setup
            Login(args[0],args[1]);

			// Craft our message.
			var msg = "";
			for (var i = 4; i < args.Length; i++)
			{
				msg += args[i] + " ";
			}

			GetChannelFromServer(GetServerFromID(args[2]), args[3]).SendMessage(msg);

            // Destroy the client
            client.Dispose();

			Thread.Sleep(1000);
        }

	    // Creation of a credentials text file (RAW PASSWORD VISIBLE)
        private static void Login(string email, string pass)
        {
            client.ClientPrivateInformation.email = email;
            client.ClientPrivateInformation.password = pass;

			// logged in
			if (client.SendLoginRequest() == null)
				return;

			Console.WriteLine("Logged in!");
			client.Connect();
			Console.WriteLine($"Connected to {client.CurrentGatewayURL}");
			client.UpdateCurrentGame("By Luke Monaghan");

			// we make her wait a little bit, else it doesnt hook up the backend
			Thread.Sleep(1000);
		}

        public static DiscordServer GetServerFromID(string id)
        {
            return client.GetServersList().Find(x => x.id == id);
        }

	    public static DiscordChannel GetChannelFromServer(DiscordServer server,string id)
	    {
		    return server.channels.Find(x => x.ID == id);
	    }
	}
}
