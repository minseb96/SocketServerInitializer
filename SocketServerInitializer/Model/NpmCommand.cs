using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class NpmCommand : ICmdCommand
    {
        public string Verb { get => "npm"; set { } }
        public string CommandWord { get; set; } // install, run ...
        public string CommandOption { get; set; } // --all, -g, --dev ...
        public string Destination { get; set; } // module name
        public int Order { get; set; }
    }
}
