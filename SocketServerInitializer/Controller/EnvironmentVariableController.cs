using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    class EnvironmentVariableController : Controller
    {
        public EnvironmentVariableController()
        {
            this.SupportTypes = new List<Type> { typeof(CreateEnvVariableCommand), typeof(CreateSessionEnvVariableCommand) };
        }

        public override bool Execute(Command commandParam)
        {
            switch (commandParam)
            {
                case CreateEnvVariableCommand _ :
                    CreateMachineEnvVariable((CreateEnvVariableCommand)commandParam);
                    break;
                case CreateSessionEnvVariableCommand _:
                    CreateSessionEnvVariable();
                    break;
            }
            return true;
        }

        public bool ExecuteCmdCommand(Command commandParam)
        {

        }

        private bool CreateMachineEnvVariable(CreateEnvVariableCommand command)
        {
            try
            {
                if (command.PathName.Equals("PATH"))
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
        private bool CreateSessionEnvVariable(CreateSessionEnvVariableCommand command)
        {
            try
            {
                if (command.PathName.Equals("PATH"))
                {
                    this.process.StandardInput.WriteLine($"SET PATH=%PATH%;{path};");
                }
                else
                {
                    this.process.StandardInput.WriteLine($"SET {varName}={path}");
                }
                CommandWaitForExit(CommandKind.Immediately);
            }
            catch
            {

            }
        }

    }
}
