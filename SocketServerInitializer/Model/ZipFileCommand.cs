using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public enum ZipCommand
    {
        Zip,
        Extract
    }
    public class ZipFileCommand : NotCmdCommand
    {
        public ZipCommand ZipCommandType { get; set; }
        public string ExceptionProcessName { get; set; }
        public bool RecreateAfterDelete { get; set; }
    }
}
