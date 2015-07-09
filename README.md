# PingoConsole
Building out a starter kit for console apps

Requirements: Visual Studio 2013

This is a Console Framework that is modeled after how nuget.exe work.  It produces a standalone exe, with all its dlls embedded as resources.  No need for after the fact packing to turn a c# console app with a bunch of supporting dlls into a single standalone exe.  

Step by Step instructions, a VSIX to do all this will soon follow.

1. Create a new console project

2. Install the following nuget

  Pingo.EmbeddedAssemblies

  Agree to the file replacement prompts

3. Install the following nugets 

  Pingo.CommandLineHelp
  
  Pingo.Console
  
  Pingo.JsonConverters.Commands
  
  Pingo.TestCommands

4. Edit Program.cs

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MainCore(string[] args)
        {
            Pingo.CommandLine.EntryPoint.Program.MefRunnerEntryPoint(new EntryAssemblyEmbeddedMefAssemblies(), args);
        }
        
5. Congratulations you have fully working, single exe, console app that does few nice commands.  Play with it to see what it gives you.

6. Now lets build your own command line plugin.
  Tools->Extensions and Updates...
  Search for Pingo.Commandline.PluginTemplate
  install and restart visual studio 2013

7. Add->Project   
  Select Pingo.Commandline.PluginTemplate
  A wizard prompt asks for what your command name should be.  I use Json2Xml, Xml2Json, etc.

8. Build and add as a solution reference to your previously created console app.
9. Done.  
10. Modify your command project to suit.
11. uninstall Pingo.JsonConverters.Commands and Pingo.TestCommands.












