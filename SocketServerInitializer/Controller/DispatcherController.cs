using SocketServerInitializer.Model;
using SocketServerInitializer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerInitializer.Controller
{
    class DispatcherController
    {
        public bool EndOfCommand { get => endOfCommand; }
        public int CommandListCount { get => CommandList.Count; }

        private bool endOfCommand = false;
        private List<Command> CommandList = new List<Command>();
        private List<Controller> ControllerStore  = new List<Controller>();

        private DirectoryController pathController;
        private EnvironmentVariableController environmentVariableController;
        private ZipFileExtractController zipFileExtractController;

        public DispatcherController(List<Command> commandList)
        {
            CommandList = OrderByCommandOrder(commandList);
            Init();

            MapController();
        }
        private List<Command> OrderByCommandOrder(List<Command> commands)
        {
            return commands.OrderBy(command => command.Order).ToList();
        }
        private void Init()
        {
            pathController = new DirectoryController();
            environmentVariableController = new EnvironmentVariableController();
            zipFileExtractController = new ZipFileExtractController();
        }
        private void MapController()
        {
            this.ControllerStore.Add(pathController);
            this.ControllerStore.Add(environmentVariableController);
            this.ControllerStore.Add(zipFileExtractController);
        }
        private Controller GetSupportedController(Command command)
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
        private bool Execute(Command command)
        {
            Controller controller = GetSupportedController(command);
            if (controller == null)
            {
                throw new Exception("Not found controller.");
            }
            if(command is CmdCommand)
            {
                return controller.ExecuteCmdCommand(command);
            }
            return controller.Execute(command);
        }

        public bool ExecuteNext()
        {
            if (CommandList.Count == 1)
            {
                endOfCommand = true;
            }

            bool result = Execute(CommandList[0]);
            CommandList.RemoveAt(0);
            return result;
        }
    }
}
