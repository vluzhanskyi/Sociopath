using System;
using BotSDK;

namespace Bot2
{
    public class Aristarch : IBot
    {
        public string Name { get; private set; }
        public string Answer(string message)
        {
            Name = "Aristarch";
            if (message.Equals("Ar", StringComparison.InvariantCultureIgnoreCase))
                return "You can easily call me 'Ra' :-) ";
            if (message.Equals("Ra", StringComparison.InvariantCultureIgnoreCase))
                return "Your Highness, Ra ";
            if (message.Equals("Highness", StringComparison.InvariantCultureIgnoreCase))
                return "How you can???";
            else { return "You can easily call me 'Ra' :-) "; }
        }
    }
}
