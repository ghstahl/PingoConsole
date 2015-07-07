using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using Pingo.CommandLine.ArrayUtils;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;
using Pingo.CommandLineHelp.Pages;

namespace Pingo.CommandLineHelp.Commands
{

    [Export(typeof(Pingo.CommandLine.Contracts.Help.ICommandLineHelp))]
    [Export(typeof(Pingo.CommandLine.Contracts.Command.ICommand))]
    [ExportMetadata("Command", "Help")]
    public class HelpCommand : Pingo.CommandLine.Contracts.Command.ICommand, Pingo.CommandLine.Contracts.Help.ICommandLineHelp
    {

        private SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp> _commandHelpList;

        private SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp> CommandHelpList
        {
            get { return _commandHelpList ?? (_commandHelpList = new SortedList<string, Pingo.CommandLine.Contracts.Help.ICommandHelp>()); }
        }

        public void Add(Pingo.CommandLine.Contracts.Help.ICommandHelp commandHelp)
        {
            CommandHelpList.Add(commandHelp.Name, commandHelp);
        }

        public IExecuteResult ExecuteCommand(string[] args)
        {

            var twoColumnWidths = new[] {1, 0, 999};
            var twoColumnFlexIds = new[] {2};
            var twoColumnTruncatedIds = new[] {1};

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

            Pingo.CommandLine.Contracts.Help.ICommandHelp targetCommandHelp;

            try
            {
                var commandHelpRecord =
                    CommandHelpList.First(
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
            var helpDashboardColumn2Width = CommandHelpList.LongestNameWidth() + 4;
            twoColumnWidths[1] = helpDashboardColumn2Width;
            twoColumnWidths = twoColumnWidths.ToFlexWidthColumns(twoColumnFlexIds, Console.BufferWidth - 1,
                helpDashboardColumn2Width);
            var pageMyHelpDashboard = new MyHelpDashboard(CommandHelpList, twoColumnWidths, twoColumnTruncatedIds);
            pageMyHelpDashboard.WritePage();
            return executeResult;

            HelpForCommand:
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            var helpForCommandColumn2Width = targetCommandHelp.LongestNameWidth() + 4;
            twoColumnWidths[1] = helpForCommandColumn2Width;
            twoColumnWidths = twoColumnWidths.ToFlexWidthColumns(twoColumnFlexIds, Console.BufferWidth - 1,
                helpForCommandColumn2Width);
            var pageMyCommandHelp = new MyCommandHelpPage(targetCommandHelp, twoColumnWidths, twoColumnTruncatedIds);
            pageMyCommandHelp.WritePage();
            return executeResult;
        }
    }
}
