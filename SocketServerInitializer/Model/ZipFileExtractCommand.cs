using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    class ZipFileExtractCommand : INotCmdCommand
    {
        public int Order { get; set; }
        public string Destination { get; set; }

    }
}
