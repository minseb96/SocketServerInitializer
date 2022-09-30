using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SocketServerInitializerTests
{
    [TestFixture()]
    public class UniversalTest
    {

        [Test()]
        public void NullTest()
        {
            //string testData = string.Empty;
            string testData = null;
            testData = testData ?? "isnull";
            Console.WriteLine(testData);
        }
    }
}
