using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public class ChangeDirecotryCommand : ICmdCommand
    {
        public int Order { get; set; }
        public string Verb { get => "cd"; set { } }
        public string Destination { get; set; }
    }
}
