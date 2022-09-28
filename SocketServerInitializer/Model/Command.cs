using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Model
{
    [JsonConverter(typeof(JsonKnownTypesConverter<Command>))]
    public class Command
    {
        public int Order { get; set; }
    }
}
