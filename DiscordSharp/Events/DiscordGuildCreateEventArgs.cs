using System;
using Newtonsoft.Json.Linq;
using DiscordSharp.Objects;
namespace DiscordSharp.Events
{
    public class DiscordGuildCreateEventArgs : EventArgs
    {
        public DiscordServer server { get; internal set; }
        public JObject RawJson { get; internal set; }
    }
}
