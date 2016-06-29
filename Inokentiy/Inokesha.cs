using System;
using BotSDK;

namespace Inokentiy
{
    public class Inokesha : IBot
    {
        public string Name { get; private set; }
        public string Answer(string message)
        {
            Name = "Inokentiy";
            if (message.Equals("Kesha", StringComparison.InvariantCultureIgnoreCase))
                return "Kesha said: text1 ";
            if (message.Equals("text1", StringComparison.InvariantCultureIgnoreCase))
                return "Kesha said: fuck off ";
            if (message.Equals("crazy", StringComparison.InvariantCultureIgnoreCase))
                return "Kesha said: Kill your self!!";
            else { return null; }
        }
    }
}
