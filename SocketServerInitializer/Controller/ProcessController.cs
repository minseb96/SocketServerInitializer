using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    public class ProcessController
    {
        private Process process;
        private string codePageCommand = "chcp 65001";
        public StringBuilder OutputLogBuffer { get; set; }
        public StringBuilder ErrorLogBuffer { get; set; }

        public ProcessController(List<KeyValuePair<string, string>> processInfo)
        {
            Init(processInfo);
        }

        private void Init(List<KeyValuePair<string, string>> processInfo = null)
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
            if(processInfo != null)
            {
                CreateEnvVarDictionary(processInfo);
            }
            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;
        }

        private void CreateEnvVarDictionary(List<KeyValuePair<string, string>> infos)
        {
            string pathValue = string.Empty;
            infos.Where(x => x.Key.ToLower().Equals("path")).ToList().ForEach(info => pathValue += info.Value + ";");
            process.StartInfo.EnvironmentVariables["PATH"] = pathValue + process.StartInfo.EnvironmentVariables["PATH"];
            infos.Where(x => !x.Key.ToLower().Equals("path")).ToList().ForEach(info => process.StartInfo.EnvironmentVariables[info.Key] = info.Value);
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"[Warn] {e.Data}");
                ErrorLogBuffer.Append(e.Data);
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine($"[Output] {e.Data}");
                OutputLogBuffer.Append(e.Data);
            }
        }

        private void Start(string commands)
        {
            process.StartInfo.Arguments = $"/c {codePageCommand} & {commands}";
            if (process.Start())
            {
                process.BeginOutputReadLine();
                Thread.Sleep(50);
                process.BeginErrorReadLine();
            }
            else
            {
                throw new Exception("### Fail to start process ###");
            }
        }

        public void SendCommands(string commands, int maxTimeWait=0)
        {
            Start(commands);
            //Thread.Sleep(2000);

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
