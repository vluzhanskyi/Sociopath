using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using BotSDK;

namespace Sociopath
{
       class Logic
    {
        List<Type> GetTypesbyinterface(List<Type> allTypes)
        {
            List<Type> chosenTypes = new List<Type>();
            
            foreach(Type t in allTypes)
            {
                foreach(Type i in t.GetInterfaces())
                {
                    if (i.Name == "IBot")
                        chosenTypes.Add(t);
                }                
            }
            return chosenTypes;
        }

        List<Type> GetTypeOfAgent()
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            List<Type> allTypes = new List<Type>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (string dll in Directory.GetFiles(path + "/Bots/", "*.dll"))
                    allAssemblies.Add(Assembly.LoadFile(dll));
            
            if (allAssemblies.Capacity > 0)
            {
                foreach (Assembly asm in allAssemblies)
                {
                        Type[] tempTypes = asm.GetTypes();

                    for (int i = 0; i < tempTypes.Length; i++)
                        allTypes.Add(tempTypes[i]);
                }

                allTypes = GetTypesbyinterface(allTypes);
            }

            return allTypes;
        }

        List<IBot> RunAgents(List<Type> types)
        {
            List<object> instances = new List<object>();
            foreach (Type T in types)
                instances.Add(Activator.CreateInstance(T)) ;
            List<IBot> resultedBots = new List<IBot>();
            foreach (var bot in instances)
            {
                resultedBots.Add((IBot)bot);
            }
            return resultedBots;
        }

      public List<string> RunInteraction(string message)
        {
            object[] answer = new object[2];
            List<string> result = new List<string>();
            object[] parameters = new object[1];
            parameters[0] = message;
            List<Type> types = GetTypeOfAgent();
            List<IBot> instances = RunAgents(types);

          foreach (var bot in instances)
          {
              answer[1] = bot.Answer(message);
              answer[0] = bot.Name;
              if (answer[1] != null)
                  result.Add(string.Join(": ", answer));
          }
          
            return result;
        }

    }
}
