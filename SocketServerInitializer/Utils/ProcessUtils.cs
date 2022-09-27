using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Utils
{
    public static class ProcessUtils
    {
        private static List<Process> GetProcesses()
        {
            return Process.GetProcesses().ToList();
        }

        public static List<Process> FindProcessByName(string name)
        {
            List<Process> list = new List<Process>();
            foreach (Process process in GetProcesses())
            {
                if (process.ProcessName.Contains(name))
                {
                    list.Add(process);
                }
            }
            return list;
        }

        public static void KillProcess(string processName)
        {
            var processList = FindProcessByName(processName);
            foreach (Process process in processList)
            {
                process.Kill();
                process.Dispose();
            }
        }
    }
}
