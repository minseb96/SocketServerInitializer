using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonKnownType(typeof(CommonCommand), "CommonCommand")]
    class CommonCommand : CmdCommand
    {
        public string PostVerb { get; set; } // install, run ... 
        public string CommandOption { get; set; } // --all, -g, --dev ...
    }
}
