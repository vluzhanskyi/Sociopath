using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Sociopath
{
       class logic
    {
        List<Type> GetTypesbyinterface(List<Type> AllTypes)
        {
            List<Type> ChosenTypes = new List<Type>();
            
            foreach(Type t in AllTypes)
            {
                foreach(Type i in t.GetInterfaces())
                {
                    if (i.Name == "IBot")
                        ChosenTypes.Add(t);
                }                
            }
            return ChosenTypes;
        }

        List<Type> GetTypeOfAgent()
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            List<Type> AllTypes = new List<Type>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                if (!dll.Contains("SDK"))
                    allAssemblies.Add(Assembly.LoadFile(dll));
            
            if (allAssemblies.Capacity > 0)
            {
                foreach (Assembly asm in allAssemblies)
                {
                        Type[] tempTypes = asm.GetTypes();

                    for (int i = 0; i < tempTypes.Length; i++)
                        AllTypes.Add(tempTypes[i]);
                }

                AllTypes = GetTypesbyinterface(AllTypes);
            }

            return AllTypes;
        }

        List<object> RunAgents(List<Type> Types)
        {
            List<object> Instances = new List<object>();
            foreach (Type T in Types)
                Instances.Add(Activator.CreateInstance(T)) ;
            return Instances;
        }

      public List<string> RunInteraction(string message)
        {
            object[] answer = new object[2];
            List<string> result = new List<string>();
            MethodInfo Method = null;
            PropertyInfo Name = null;
            object[] parameters = new object[1];
            parameters[0] = message;
            List<Type> types = GetTypeOfAgent();
            List<object> instances = RunAgents(types);
           
            foreach (Type t in types)
            {
                foreach (object obj in instances)
                {
                    try
                    {
                        Method = t.GetMethod("Answer");
                        Name = t.GetProperty("Name");
                        answer[1] = Method.Invoke(obj, parameters);
                        answer[0] = Name.GetValue(obj);
                        if (answer[1] != null)
                            result.Add(string.Join(": ", answer));
                    }
                    catch (TargetException)
                    {

                    }
                }
               
            }

            return result;
        }

    }
}
