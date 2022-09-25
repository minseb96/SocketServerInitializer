using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class CreateSessionEnvVariableCommand : ICmdCommand
    {
        public string Verb { get => "SET"; set { } }
        public string PathName { get; set; }
        public string Destination { get; set; }
        public int Order { get; set; }
    }
}
