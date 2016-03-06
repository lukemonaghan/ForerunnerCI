using System;
using Newtonsoft.Json.Linq;
using DiscordSharp.Objects;
namespace DiscordSharp.Events
{
    public class DiscordUserUpdateEventArgs : EventArgs
    {
        public DiscordMember OriginalMember { get; internal set; }
        public DiscordMember NewMember { get; internal set; }
        public JObject RawJson { get; internal set; }
    }
}
