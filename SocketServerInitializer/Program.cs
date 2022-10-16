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
using System.Threading;

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
                path = PathUtils.GetCurrentProjectPath(@"commandSet_x64.json");
            }
            else
            {
                path = PathUtils.GetCurrentProjectPath(@"commandSet_x86.json");
            }
            using(StreamReader reader = new StreamReader(path))
            {
                string jsonObj = reader.ReadToEnd();
                try
                {
                    var commandList = JsonConvert.DeserializeObject<List<CommandBase>>(jsonObj, new JsonKnownTypesConverter<CommandBase>());
                    dispatcherController = new DispatcherController(commandList);
                }
                catch
                {
                    throw new Exception("### JSON commandSet read failed ###");
                }
            }
            Console.WriteLine("### Start of running general commands ###");
            while (dispatcherController.CommandListCount > 0)
            {
                bool result = dispatcherController.ExecuteNext();
                if (!result)
                {
                    throw new Exception("### General commands execute failed ###");
                }
                if (dispatcherController.EndOfCommand)
                {
                    Console.WriteLine("### General commands execute done ###");
                    try
                    {
                        ProcessController processController = new ProcessController(dispatcherController.ProcessInfo);
                        Console.WriteLine("### Start of running CLI based commands ###");
                        Thread.Sleep(3000);
                        processController.SendCommands(dispatcherController.StrCmdCommands, (int)(TimeSpan.FromMinutes((double)Properties.Settings.Default.MaxTimeWait).TotalMilliseconds));
                    }
                    catch
                    {
                        throw new Exception("### Cmd commands execute failed ###");
                    }
                    break;
                }
            }
            Console.WriteLine("### Done of executing CLI based commands ###");

            Console.WriteLine();
            Console.WriteLine("##################################################");
            Console.WriteLine("[End] Installation finished !!!");
            Console.WriteLine("[End] Press any key to exit ... ");
            Console.WriteLine("##################################################");
            Console.ReadKey();
        }

    }
}
