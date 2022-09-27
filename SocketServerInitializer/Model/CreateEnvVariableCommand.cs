using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class CreateEnvVariableCommand : NotCmdCommand
    {
        public string PathName { get; set; }
    }
}
