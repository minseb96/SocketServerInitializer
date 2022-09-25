using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    interface INotCmdCommand : ICommand
    {
        string Destination { get; set; }
    }
}
