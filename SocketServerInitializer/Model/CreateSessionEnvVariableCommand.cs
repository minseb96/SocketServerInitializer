using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class CreateSessionEnvVariableCommand : CmdCommand
    {
        public string PathName { get; set; }
        public CreateSessionEnvVariableCommand()
        {
            this.Verb = "SET";
        }
    }
}
