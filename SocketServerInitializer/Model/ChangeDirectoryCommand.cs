using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public class ChangeDirectoryCommand : CmdCommand
    {
        public ChangeDirectoryCommand()
        {
            this.Verb = "cd";
        }
    }
}
