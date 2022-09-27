using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class NpmCommand : CmdCommand
    {
        public string CommandWord { get; set; } // install, run ...
        public string CommandOption { get; set; } // --all, -g, --dev ...
        public NpmCommand()
        {
            this.Verb = "npm";
        }
    }
}
