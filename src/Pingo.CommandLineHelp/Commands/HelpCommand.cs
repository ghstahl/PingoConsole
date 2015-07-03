using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using Pingo.CommandLine.ArrayUtils;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.Contracts.Command;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Contracts.Help;
using Pingo.CommandLine.Execute;
using Pingo.CommandLineHelp.Pages;

namespace Pingo.CommandLineHelp.Commands
{

    [Export(typeof (ICommandLineHelp))]
    [Export(typeof (ICommand))]
    [ExportMetadata("Command", "Help")]
    public class HelpCommand : ICommandLineHelp, ICommand
    {

        private SortedList<string, ICommandHelp> _commandHelpList;

        private SortedList<string, ICommandHelp> CommandHelpList
        {
            get { return _commandHelpList ?? (_commandHelpList = new SortedList<string, ICommandHelp>()); }
        }

        public void Add(ICommandHelp commandHelp)
        {
            CommandHelpList.Add(commandHelp.Name, commandHelp);
        }

        public IExecuteResult ExecuteCommand(string[] args)
        {
            var twoColumnWidths = new[] {1, 16, 999};
            var twoColumnFlexIds = new[] {2};
            var twoColumnTruncatedIds = new[] {1};

            twoColumnWidths = twoColumnWidths.ToFlexWidthColumns(twoColumnFlexIds, Console.BufferWidth-1, 16);

            var executeResult = new ExecuteResult {Name = Resources.HelpResources.Name_Help};
            const string reservedTokens = "-/";
            if (args.IsNullOrEmpty())
            {
                goto HelpDashboard;
                // do Main Dashboard Help
            }

            // check for command
            string command = args[0];
            if (string.IsNullOrWhiteSpace(command))
            {
                goto HelpDashboard;
            }
            string token = command[0].ToString(CultureInfo.InvariantCulture);
            if (reservedTokens.Contains(token))
            {
                ConsoleHelper.DoConsoleErrorColor(
                    () => Console.WriteLine(Resources.Common.Format_UnknownCommand, command));
                goto HelpDashboard;
            }

            ICommandHelp targetCommandHelp;

            try
            {
                var commandHelpRecord =
                    _commandHelpList.First(
                        i => System.String.Compare(command, i.Key, System.StringComparison.OrdinalIgnoreCase) == 0);
                targetCommandHelp = commandHelpRecord.Value;
                goto HelpForCommand;

            }
            catch (Exception e)
            {
                ConsoleHelper.DoConsoleErrorColor(
                    () => Console.WriteLine(Resources.Common.Format_UnknownCommand, command));
                goto HelpDashboard;
            }

            HelpDashboard:
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            var pageMyHelpDashboard = new MyHelpDashboard(_commandHelpList, twoColumnWidths, twoColumnTruncatedIds);
            pageMyHelpDashboard.WritePage();
            return executeResult;

            HelpForCommand:
            var pageMyCommandHelp = new MyCommandHelpPage(targetCommandHelp, twoColumnWidths, twoColumnTruncatedIds);
            pageMyCommandHelp.WritePage();
            return executeResult;
        }
    }
}
