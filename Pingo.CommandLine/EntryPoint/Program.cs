﻿using System;
using System.Globalization;
using System.Linq;
using Fclp;
using Pingo.CommandLine.ArrayUtils;
using Pingo.CommandLine.Composite;
using Pingo.CommandLine.ConsoleUtility;
using Pingo.CommandLine.Resources.EntryPoint.Resources;

namespace Pingo.CommandLine.EntryPoint
{

    public enum ExitResult
    {
        Fatal = -1,
        Success = 0,
        BadCommandArgument = 1,
        EmptyArguments = 2
    }

    public class ParseException : Exception
    {
        public ExitResult Result { get; set; }
        public string Text { get; set; }
    }

    public class InitialParseResult
    {
        public string Command { get; set; }
        public bool HelpRequested { get; set; }
    }

    public static class Program
    {
        private static InitialParseResult InitialParse(string[] args, string[] helpOptions)
        {
            string reservedTokens = "-/";

            if (args.IsNullOrEmpty())
            {
                return new InitialParseResult() {Command = null, HelpRequested = true};
            }
            var command = args[0];
            string token = command[0].ToString(CultureInfo.InvariantCulture);
            if (reservedTokens.Contains(token))
            {
                throw new ParseException() { Result = ExitResult.BadCommandArgument };
            }
            var result = new InitialParseResult() {Command = command};

            bool helpSwitch = false;
            var p = new FluentCommandLineParser();
            ///////////////////////////////////////////////////////////////////////////////////////////
            // Help Switch
            ///////////////////////////////////////////////////////////////////////////////////////////
            p.Setup<bool>(CaseType.CaseInsensitive, helpOptions)
                .Callback(value => helpSwitch = value)
                .SetDefault(false);
            p.Parse(args);
            result.HelpRequested = helpSwitch;

            return result;
        }

        /*
         * 
         <command> <arg>(s) [-|/|--]<option>(s)
         Test A1 A2 A3 -s sdata -t tData -many m1 m2 m3
         * 
         * 
         */


        public static void MefRunnerEntryPoint(IAssemblyAccumulator assemblyAccumulator, string[] args)
        {
            var finalResult = (int)ExitResult.Fatal;
            
            try
            {
                var commandManager = new CommandManager(assemblyAccumulator);
                commandManager.BuildContainer();

                var helpOptions = new[] {Common.ShortHelpOption, Common.LongHelpOption};

                var result = InitialParse(args, helpOptions);
                // result now has the command
                if (result.HelpRequested)
                {
                    // we only want a command help arg list here.
                    var newArgs = new string[]
                    {
                        Common.LongHelpOption, result.Command
                    };
                    result.Command = Common.LongHelpOption;
                    args = newArgs;
                }

                try
                {
                    ArrayItemDeleter.RemoveArrayItem(ref args, 0); // don't need Command arg anymore, so strip it out.

                    var cCommand =
                        commandManager.Commands.First(
                            command => System.String.Compare(command.Metadata.Command, result.Command,
                                System.StringComparison.OrdinalIgnoreCase) == 0);
                    if (cCommand == null)
                    {
                        throw new ParseException() { Result = ExitResult.BadCommandArgument, Text = result.Command };
                    }

                    var commandResult = cCommand.Value.ExecuteCommand(args);
                    if (commandResult.HasErrors)
                    {
                        foreach (var error in commandResult.Errors)
                        {
                            ConsoleHelper.DoConsoleErrorColor(
                                () => System.Console.WriteLine(error.ErrorText));
                        }
                    }
                    finalResult = commandResult.ResultCode;
                }
                catch (Exception e)
                {
                    throw new ParseException() { Result = ExitResult.BadCommandArgument, Text = result.Command };
                }

            }
            catch (ParseException pe)
            {
                switch (pe.Result)
                {
                    case ExitResult.BadCommandArgument:
                        ConsoleHelper.DoConsoleErrorColor(
                            () => System.Console.WriteLine(Resources.EntryPoint.Resources.Common.Format_UnknownCommand, pe.Text));
                        break;
                    default:
                        throw;
                }
                // do help
            }
            catch (Exception e)
            {
                ConsoleHelper.DoConsoleErrorColor(
                    () => System.Console.WriteLine(Resources.EntryPoint.Resources.Common.Format_UnknownException, e.Message));
            }
            finally
            {
                Environment.ExitCode = finalResult;
            }
        }
    }
}
