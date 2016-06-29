using System;
using BotSDK;

namespace Bot1
{
    public class Vasiliy : IBot
    {
        public string Name { get; private set; }
        public string Answer(string message)
        {
            Name = "Vasiliy";
            if (message.Equals("Hi", StringComparison.InvariantCultureIgnoreCase))
                return "Vasya said: Hello ";
            if (message.Equals("How are you?", StringComparison.InvariantCultureIgnoreCase))
                return "Vasya said: Good! And you? ";
            if (message.Equals("Fine, thx", StringComparison.InvariantCultureIgnoreCase))
                return "Vasya said: Haw can i help? ";
            else { return "you're so funny"; }
        }

        
    }
}
