using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class NodeModuleCommand : CmdCommand
    {
        public string CommandOption { get; set; }
        public string PostVerb { get; set; }
    }
}
