using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonConverter(typeof(JsonKnownTypesConverter<CommandBase>))]
    public class CommandBase
    {
        public int Order { get; set; }
        public bool IsSkip { get; set; }
    }
}
