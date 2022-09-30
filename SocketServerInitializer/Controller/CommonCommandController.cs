using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class CommonCommandController : CmdController
    {
        public CommonCommandController()
        {
            this.SupportTypes = new List<Type> { typeof(CommonCommand) };
        }

        public override string GetFullCommand(CommandBase commandParam)
        {
            var command = (CommonCommand)commandParam;
            var blank = " ";
            return $"{command.Verb} {command.PostVerb}" +
                $"{(String.IsNullOrEmpty(command.Destination) ? String.Empty : blank + command.Destination)}" +
                $"{(String.IsNullOrEmpty(command.CommandOption) ? String.Empty : blank + command.CommandOption) }";
        }
    }
}
