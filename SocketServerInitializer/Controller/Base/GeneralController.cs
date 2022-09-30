using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public abstract class GeneralController : ControllerBase
    {
        public abstract bool Execute(CommandBase command);
    }
}
