using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    class SessionEnvironmentVariableController : CmdController
    {
        public SessionEnvironmentVariableController()
        {
            this.SupportTypes = new List<Type> { typeof(CreateSessionEnvVariableCommand) };
        }

        public override string GetFullCommand(CommandBase commandParam)
        {
            CreateSessionEnvVariableCommand command = (CreateSessionEnvVariableCommand)commandParam;
            if (command.PathName.Equals("PATH"))
            {
                return $"SET {command.PathName}=%PATH%;{command.Destination};";
            }
            else
            {
                return $"SET {command.PathName}={command.Destination}";
            }
        }
    }
}
