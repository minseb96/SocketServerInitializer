using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class DirectoryController : Controller
    {
        public DirectoryController()
        {
            this.SupportTypes = new List<Type> { typeof(DirectoryCommand) };
        }
        private bool CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public override bool Execute(Command commandParam)
        {
            var command = (DirectoryCommand)commandParam;

            switch(command.commandType)
            {
                case CRUDType.Create:
                    return CreateDirectory(command.Destination);
                case CRUDType.Delete:
                    return DeleteDirectory(command.Destination);
                default:
                    return false;
            }
        }
    }
}
