using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public abstract class CmdController : ControllerBase
    {
        public abstract string GetFullCommand(CommandBase command);
    }
}
