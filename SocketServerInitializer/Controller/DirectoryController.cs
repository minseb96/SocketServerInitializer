using SocketServerInitializer.Model;
using SocketServerInitializer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class DirectoryController : GeneralController
    {
        public DirectoryController()
        {
            this.SupportTypes = new List<Type> { typeof(DirectoryCommand) };
        }
        private bool CreateDirectory(string path, bool useRelativePath)
        {
            if (useRelativePath)
            {
                path = PathUtils.GetCurrentProjectPath(path);
            }
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
        private bool DeleteDirectory(string path, string exceptionProcessName, bool useRelativePath)
        {
            if (useRelativePath)
            {
                path = PathUtils.GetCurrentProjectPath(path);
            }
            try
            {
                Directory.Delete(path, true);
            }
            catch(Exception e)
            {
                if (!string.IsNullOrEmpty(exceptionProcessName))
                {
                    ProcessUtils.KillProcess(exceptionProcessName);

                    Thread.Sleep(500);
                }
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                {
                    return true;
                }
            }
            return true;
        }
        public override bool Execute(CommandBase commandParam)
        {
            var command = (DirectoryCommand)commandParam;

            switch(command.CommandType)
            {
                case CRUDType.Create:
                    return CreateDirectory(command.Destination, command.UseRelativeDestination);
                case CRUDType.Delete:
                    return DeleteDirectory(command.Destination, command.ExceptionProcessName, command.UseRelativeDestination);
                default:
                    return false;
            }
        }
    }
}
