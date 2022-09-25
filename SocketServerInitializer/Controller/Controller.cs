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
        public IEnumerable<ICommand> OrderByCommandOrder(ICommand[] commands)
        {
            IEnumerable<ICommand> orderedCommand = commands.OrderBy(command => command.Order);
            return orderedCommand;
        }
        public bool IsSupport<T>(ICommand[] commands)
        {
            return commands[0].GetType() == typeof(T) ? true : false;
        }
        public abstract bool Execute();
    }
}
