using System;
using Newtonsoft.Json;

namespace DiscordSharp.Objects
{
    [Obsolete]
    public class DiscordLoginInformation
    {
        public string[] email { get; set; }
        public string[] password { get; set; }

        public string AsJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public DiscordLoginInformation()
        {
            email = new string[1];
            password = new string[1];
        }
    }
}
