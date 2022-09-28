using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonKnownType(typeof(ChangeDirectoryCommand), "ChangeDirectoryCommand")]
    public class ChangeDirectoryCommand : CmdCommand
    {
        public ChangeDirectoryCommand()
        {
            this.Verb = "cd";
        }
    }
}
