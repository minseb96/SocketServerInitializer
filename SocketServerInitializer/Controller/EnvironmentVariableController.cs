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

        public override bool Execute(Command commandParam)
        {
            return true;
            //var type = commandParam.GetType();
            //CastObject<commandParam.GetType()>(commandParam);
        }
    }
}
