using SocketServerInitializer.Model;
using SocketServerInitializer.Utils;
using SocketServerInitializer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonKnownTypes;
using Newtonsoft.Json;
using System.IO;

namespace SocketServerInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            DispatcherController dispatcherController;
            string path = @"C:\Users\Minseob Song\Desktop\testObj.json";
            using(StreamReader reader = new StreamReader(path))
            {
                string jsonObj = reader.ReadToEnd();
                var commandList = JsonConvert.DeserializeObject<List<Command>>(jsonObj, new JsonKnownTypesConverter<Command>());
                dispatcherController = new DispatcherController(commandList);
            }
            for(int i=0; i<dispatcherController.CommandListCount; i++)
            {
                if(dispatcherController.EndOfCommand || !dispatcherController.ExecuteNext())
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
