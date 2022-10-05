using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class ProcessController
    {
        private Process process;
        public StringBuilder OutputLogBuffer { get; set; }
        public StringBuilder ErrorLogBuffer { get; set; }

        public ProcessController()
        {
            Init();
        }

        private void Init()
        {
            OutputLogBuffer = new StringBuilder();
            ErrorLogBuffer = new StringBuilder();

            process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = @"C:\",
                FileName = "cmd.exe",
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                //RedirectStandardInput = true,
                RedirectStandardInput = false,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
            };
            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data != string.Empty)
            {
                Console.WriteLine($"[Warn] {e.Data}");
                ErrorLogBuffer.Append(e.Data);
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data != string.Empty)
            {
                Console.WriteLine($"[Output] {e.Data}");
                OutputLogBuffer.Append(e.Data);
            }
        }

        private void Start(string commands)
        {
            process.StartInfo.Arguments = $"/c {commands}";
            if (process.Start())
            {
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
            }
            else
            {
                throw new Exception("Fail to start process.");
            }
        }

        public void SendCommands(string commands, int maxTimeWait=0)
        {
            Start(commands);
            Thread.Sleep(2000);

            //process.StandardInput.WriteLine(commands);
            if (maxTimeWait > 0)
            {
                process.WaitForExit(maxTimeWait);
                return;
            }
            process.WaitForExit();

            process.Dispose();
            process = null;
        }
    }
}
