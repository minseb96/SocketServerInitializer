using SocketServerInitializer.Model;
using SocketServerInitializer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SocketServerInitializer.Controller
{
    class DispatcherController
    {
        public bool EndOfCommand { get => endOfCommand; }
        public int CommandListCount { get => CommandList.Count; }
        public string StrCmdCommands { get => CmdCommands.ToString(); }

        private bool endOfCommand = false;
        private List<CommandBase> CommandList = new List<CommandBase>();
        private List<ControllerBase> ControllerStore  = new List<ControllerBase>();
        private StringBuilder CmdCommands = new StringBuilder();

        private DirectoryController directoryController;
        private MachineEnvironmentVariableController environmentVariableController;
        private ZipFileController zipFileExtractController;
        private CommonCommandController universalCmdController;
        private SessionEnvironmentVariableController sessionEnvironmentVariableController;

        public DispatcherController(List<CommandBase> commandList)
        {
            CommandList = OrderByCommandOrder(commandList);
            Init();

            MapController();
        }
        private List<CommandBase> OrderByCommandOrder(List<CommandBase> commands)
        {
            return commands.OrderBy(command => command.Order).ToList();
        }
        private void Init()
        {
            directoryController = new DirectoryController();
            environmentVariableController = new MachineEnvironmentVariableController();
            sessionEnvironmentVariableController = new SessionEnvironmentVariableController();
            zipFileExtractController = new ZipFileController();
            universalCmdController = new CommonCommandController();
        }
        private void MapController()
        {
            this.ControllerStore.Add(directoryController);
            this.ControllerStore.Add(environmentVariableController);
            this.ControllerStore.Add(sessionEnvironmentVariableController);
            this.ControllerStore.Add(zipFileExtractController);
            this.ControllerStore.Add(universalCmdController);
        }
        private ControllerBase GetSupportedController(CommandBase command)
        {
            foreach (var controller in this.ControllerStore)
            {
                if (controller.IsSupport(command))
                {
                    return controller;
                }
            }
            return null;
        }
        private bool Execute(CommandBase command)
        {
            if (command.IsSkip)
            {
                return true;
            }
            ControllerBase controller = GetSupportedController(command);
            if (controller == null)
            {
                throw new Exception("Controller not found.");
            }
            if (command is CmdCommand)
            {
                ConcatCommand(((CmdController)controller).GetFullCommand(command));
                return true;
            }
            else
            {
                return ((GeneralController)controller).Execute(command);
            }
        }

        private void ConcatCommand(string strCommand)
        {
            if(this.CommandList.Count == 1)
            {
                this.CmdCommands.Append($"{strCommand}");
            }
            else
            {
                this.CmdCommands.Append($"{strCommand} & ");
            }
        }

        public bool ExecuteNext()
        {
            bool result = Execute(CommandList[0]);
            CommandList.RemoveAt(0);

            if (CommandList.Count <= 0)
            {
                endOfCommand = true;
            }
            return result;
        }
    }
}
