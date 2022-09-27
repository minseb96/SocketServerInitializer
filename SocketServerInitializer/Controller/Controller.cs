using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public abstract class Controller
    {
        public bool IsSupport(Command command)
        {
            return this.SupportTypes.Contains(command.GetType()) ? true : false;
            //return commands[0].GetType() ? true : false;
        }
        public abstract bool Execute(Command command);
        public List<Type> SupportTypes { get; set; }
    }
}
