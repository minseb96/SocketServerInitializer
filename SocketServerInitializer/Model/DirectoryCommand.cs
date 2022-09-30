using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    public enum CRUDType
    {
        [EnumMember(Value = "Create")]
        Create,
        [EnumMember(Value = "Delete")]
        Delete
    }
    [JsonKnownType(typeof(DirectoryCommand), "DirectoryCommand")]
    public class DirectoryCommand : NotCmdCommand
    {
        public CRUDType CommandType { get; set; }
        public string ExceptionProcessName { get; set; }
        public bool UseRelativeDestination { get; set; }
    }
}
