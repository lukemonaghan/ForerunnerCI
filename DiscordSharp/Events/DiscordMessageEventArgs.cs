﻿using System;
using Newtonsoft.Json.Linq;
using DiscordSharp.Objects;
namespace DiscordSharp.Events
{
    public class DiscordMessageEventArgs : EventArgs
    {
        public string message_text { get; internal set; }

        public DiscordMember author { get; internal set; }
        public DiscordChannel Channel { get; internal set; }
        public DiscordMessage message { get; internal set; }
        public DiscordMessageType MessageType { get; internal set; }
    }

    public class DiscordMessageEditedEventArgs : EventArgs
    {
        public DiscordMessage MessageEdited { get; internal set; }

        public DiscordMember author { get; internal set; }
        public DiscordChannel Channel { get; internal set; }
        public string message { get; internal set; }
        public DiscordMessageType MessageType { get; internal set; }
        public DateTime EditedTimestamp { get; internal set; }

        public DiscordMessageEditedEventArgs(JObject message)
        {
        }
        public DiscordMessageEditedEventArgs() { }
    }
}
