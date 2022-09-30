using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public enum ZipCommand
    {
        [EnumMember(Value = "Zip")]
        Zip,
        [EnumMember(Value = "Extract")]
        Extract
    }

    [JsonKnownType(typeof(ZipFileCommand), "ZipFileCommand")]
    public class ZipFileCommand : NotCmdCommand
    {
        public ZipCommand ZipCommandType { get; set; }
        public string ExtractionPath { get; set; }
        public bool UseRelativeDestination { get; set; }
        public bool UseRelativeExtractionPath { get; set; }
    }
}
