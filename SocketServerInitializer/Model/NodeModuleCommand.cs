using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class NodeModuleCommand : ICmdCommand
    {
        public string Verb { get; set; } // Module 이름
        public string CommandOption { get; set; }
        public string Destination { get; set; }
        public string PostVerb { get; set; }
        public int Order { get; set; }
    }
}
