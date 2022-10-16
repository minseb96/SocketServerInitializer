using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SocketServerInitializerTests
{
    [TestFixture()]
    public class UniversalTest
    {

        //[Test()]
        //public void NullTest()
        //{
        //    //string testData = string.Empty;
        //    string testData = null;
        //    testData = testData ?? "isnull";
        //    Console.WriteLine(testData);
        //}

        [Test()]
        public void GetProcessEnvironmentPathVarValue()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            var path = process.StartInfo.EnvironmentVariables["PATH"];
            Console.WriteLine(path);
        }

        [Test()]
        public void GetPath()
        {
            string addPath = "test.bat";
            string totalPath = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), addPath);
            Console.WriteLine(totalPath);
        }
    }
}
