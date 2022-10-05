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
    public class ZipFileController : GeneralController
    {
        private FastZip zipper = null;
        public ZipFileController()
        {
            zipper = new FastZip();
            this.SupportTypes = new List<Type> { typeof(ZipFileCommand) };
        }

        private bool ExtractZipFile(string zipFilePath, string extractPath, bool useRelativeZipFilePath, bool useRelativeExtractionPath)
        {
            if (useRelativeZipFilePath)
            {
                zipFilePath = PathUtils.GetCurrentProjectPath("Resources\\" + zipFilePath);
            }
            if (useRelativeExtractionPath)
            {
                extractPath = PathUtils.GetCurrentProjectPath(extractPath);
            }
            try
            {
                zipper.ExtractZip(zipFilePath, extractPath, null);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public override bool Execute(CommandBase commandParam)
        {
            var command = (ZipFileCommand)commandParam;

            switch (command.ZipCommandType)
            {
                case ZipCommand.Extract:
                    return ExtractZipFile(command.Destination, command.ExtractionPath, command.UseRelativeDestination, command.UseRelativeExtractionPath);
                default:
                    return false;
            }
        }
    }
}
