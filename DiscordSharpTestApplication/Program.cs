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
			if (args.Length < 8)
			{
				Console.WriteLine("Args Mismatch, should be \n [EMAIL] [PASSWORD] [SERVER_ID] [CHANNEL_ID] [URL] [COMMIT] [BRANCH] [SLUG] [MESSAGE STRING GOES AT THE END]");
				// halt for a sec. Just so user can read stuff.
				Thread.Sleep(1000);
				return;
			}

			// debug info
	        for (var index = 0; index < args.Length; index++)
	        {
		        Console.WriteLine($"args[{index}] = {args[index]}");
	        }

	        // Bot instantiate
			Console.WriteLine("DiscordSharp Command Bot");

			var username	= args[0];
	        var password	= args[1];
	        var serverID	= args[2];
	        var channelID	= args[3];
	        var URL			= args[4];
	        var commit		= args[5];
	        var branch		= args[6];
	        var slug		= args[7];

			//offset to make the generic message
			var msgOffset	= 8;
			var msg = "";
			for (; msgOffset < args.Length; msgOffset++)
			{
				msg += args[msgOffset] + " ";
			}

			// Bot setup
			Login(username, password);

			// Craft our message.
			var comment = $"**TravisCI**\n" +
			              $"{msg}\n" +
			              $"```\n" +
			              $"Commit: {commit}\n" +
			              $"Repo: {slug}\n" +
			              $"Branch: {branch}\n" +
			              $"```" +
			              $"URL: {URL}\n\n";

			// get channel and server
	        var server = GetServerFromID(serverID);
            var channel = GetChannelFromServer(server, channelID);
			channel.SendMessage(comment);

            // Destroy the client
            client.Dispose();
        }

	    // Creation of a credentials text file (RAW PASSWORD VISIBLE)
        private static void Login(string email, string pass)
		{
	        client.ClientPrivateInformation = new DiscordUserInformation
	        {
		        email = email,
		        password = pass
	        };

	        // logged in
	        if (client.SendLoginRequest() == null)
	        {
		        return;
	        }

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
