using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public class NotCmdCommand : Command
    {
        public string Destination { get; set; }
    }
}
