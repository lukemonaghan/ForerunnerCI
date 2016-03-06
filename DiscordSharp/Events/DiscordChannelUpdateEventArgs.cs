using System;
using DiscordSharp.Objects;
using Newtonsoft.Json.Linq;

namespace DiscordSharp.Events
{
    public class DiscordChannelUpdateEventArgs : EventArgs
    {
        public JObject RawJson { get; internal set; }
        public DiscordChannel OldChannel { get; internal set; }
        public DiscordChannel NewChannel { get; internal set; }
    }
}
