using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Utils
{
    public static class PathUtils
    {
        public static string GetCurrentProjectPath(string addPath = "")
        {
            return Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), addPath);
        }

        public static string CombineTwoPath(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
    }
}
