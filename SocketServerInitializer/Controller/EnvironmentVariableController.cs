using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    class EnvironmentVariableController : Controller
    {
        public EnvironmentVariableController()
        {
            this.SupportTypes = new List<Type> { typeof(CreateEnvVariableCommand), typeof(CreateSessionEnvVariableCommand) };
        }

        private Type FindCommandType(Type type)
        {
            return this.SupportTypes.Find(x=> x.Equals(type));
        }

        public override bool Execute(Command commandParam)
        {
            var type = FindCommandType(commandParam.GetType());
            var command = (type.GetType())commandParam;
        }
    }
}
