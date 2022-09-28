using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonKnownType(typeof(CmdCommand), "CmdCommand")]
    public class CmdCommand : Command
    {
        public string Verb { get; set; }
        public string Destination { get; set; }
    }
}
