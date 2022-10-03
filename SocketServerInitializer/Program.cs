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
            string path = string.Empty;
            if(Properties.Settings.Default.ProcessorArchitecture == 64)
            {
                path = PathUtils.GetCurrentProjectPath(@"testObj64.json");
            }
            else
            {
                path = PathUtils.GetCurrentProjectPath(@"testObj32.json");
            }
            using(StreamReader reader = new StreamReader(path))
            {
                string jsonObj = reader.ReadToEnd();
                var commandList = JsonConvert.DeserializeObject<List<CommandBase>>(jsonObj, new JsonKnownTypesConverter<CommandBase>());

                dispatcherController = new DispatcherController(commandList);
            }
            while (dispatcherController.CommandListCount > 0)
            {
                bool result = dispatcherController.ExecuteNext();
                if (!result)
                {
                    throw new Exception("General commands execute failed");
                }
                if (dispatcherController.EndOfCommand)
                {
                    try
                    {
                        ProcessController processController = new ProcessController();
                        processController.SendCommands(dispatcherController.StrCmdCommands, (int)(TimeSpan.FromMinutes((double)Properties.Settings.Default.MaxTimeWait).TotalMilliseconds));
                    }
                    catch
                    {
                        throw new Exception("Cmd commands execute failed.");
                    }
                    break;
                }
            }

            Console.WriteLine("[End] Installation finished !!! ");
            Console.ReadKey();
        }

    }
}
