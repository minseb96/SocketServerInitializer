using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class ControllerBase
    {
        public bool IsSupport(CommandBase command)
        {
            return this.SupportTypes.Contains(command.GetType()) ? true : false;
        }
        public List<Type> SupportTypes { get; set; }
    }
}
