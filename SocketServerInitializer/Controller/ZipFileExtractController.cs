using SocketServerInitializer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Threading;
using SocketServerInitializer.Utils;

namespace SocketServerInitializer.Controller
{
    public class ZipFileExtractController : Controller
    {
        private FastZip zipper = null;
        public ZipFileExtractController()
        {
            zipper = new FastZip();
            this.SupportTypes = new List<Type> { typeof(ZipFileCommand) };
        }

        private bool DeleteAndExtract(string path, string exceptionProcessName="", bool reCreate = true)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch
            {
                Thread.Sleep(500);

                if (exceptionProcessName != string.Empty)
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
                    return false;
                }
            }
            if (reCreate)
            {
                Directory.CreateDirectory(path);
            }
            return true;
        }
        public override bool Execute(Command commandParam)
        {
            var command = (ZipFileCommand)commandParam;

            switch (command.ZipCommandType)
            {
                case ZipCommand.Extract:
                    return DeleteAndExtract(command.Destination, command.ExceptionProcessName ?? "", command.RecreateAfterDelete);
                default:
                    return false;
            }
        }
    }
}
