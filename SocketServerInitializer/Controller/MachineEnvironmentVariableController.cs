using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    class MachineEnvironmentVariableController : GeneralController
    {
        public MachineEnvironmentVariableController()
        {
            this.SupportTypes = new List<Type> { typeof(CreateMachineEnvVariableCommand) };
        }

        public override bool Execute(CommandBase commandParam)
        {
            CreateMachineEnvVariable((CreateMachineEnvVariableCommand)commandParam);
            return true;
        }

        private bool CreateMachineEnvVariable(CreateMachineEnvVariableCommand command)
        {
            try
            {
                if (command.PathName.ToLower().Equals("path"))
                {
                    CreateMachineEnvVariableToPath(command.Destination);
                }
                else
                {
                    System.Environment.SetEnvironmentVariable(command.PathName, command.Destination, EnvironmentVariableTarget.Machine);
                }
                return true;
            }
            catch
            {
                throw new Exception($"Fail to create machine environment variable '{command.PathName}'");
            }
        }
        private void CreateMachineEnvVariableToPath(string destinationPath)
        {
            string sysEnvPath = System.Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            string[] oldPath = sysEnvPath.Split(';');
            StringBuilder newPath = new StringBuilder();

            if (Array.IndexOf(oldPath, destinationPath) < 0)
            {
                newPath.Append(destinationPath + ";");

                foreach (string ePath in oldPath)
                {
                    newPath.Append(ePath + ";");
                }
                System.Environment.SetEnvironmentVariable("Path", newPath.ToString(), EnvironmentVariableTarget.Machine);
            }
        }

    }
}
