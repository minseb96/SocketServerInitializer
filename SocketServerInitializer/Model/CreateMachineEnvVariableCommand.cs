using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonKnownType(typeof(CreateMachineEnvVariableCommand), "CreateMachineEnvVariableCommand")]
    class CreateMachineEnvVariableCommand : NotCmdCommand
    {
        public string PathName { get; set; }
    }
}
