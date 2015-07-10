# PingoConsole
Building out a starter kit for console apps

Requirements: Visual Studio 2013

This is a Console Framework that is modeled after how nuget.exe work.  It produces a standalone exe, with all its dlls embedded as resources.  No need for after the fact packing to turn a c# console app with a bunch of supporting dlls into a single standalone exe.  
####Step by Step instructions, a VSIX to do all this will soon follow.  
1. Create a new console project 
  - [ ] Name it "ConsoleMe"
  - [ ] Enable Nuget Restore for your Solution

2. Make your Console App a Single Exe
  - [ ] install nuget: Pingo.EmbeddedAssemblies 
  - [ ] Agree to the file replacement prompts

3. Bring in the Pingo Console Kit and a few stock commands  
  - [ ] install nuget: Pingo.CommandLineHelp 
  - [ ] install nuget: Pingo.Console 
  - [ ] install nuget: Pingo.JsonConverters.Commands  
  - [ ] install nuget: Pingo.TestCommands  

4. Edit Program.cs 
  ```c#
  using System;
  using System.Runtime.CompilerServices;
  using Pingo.CommandLine.Composite;
  
  namespace ConsoleMe
  {
      class Program
      {
          private static void Main(string[] args)
          {
              AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ConsoleMe.PingoEmbeddedAssemblies.AssemblyResolver.OnResolveAssembly);
              MainCore(args);
          }
  
          [MethodImpl(MethodImplOptions.NoInlining)]
          private static void MainCore(string[] args)
          {
              Pingo.CommandLine.EntryPoint.Program.MefRunnerEntryPoint(new EntryAssemblyEmbeddedMefAssemblies(), args);
          }
      }
  }
  ```  

5. Build and Run  

    What we have here is a console application that was built using barely any code.  It also means that I don't have to worry about the help and formatting of help when I introduce a new command.  I just worry about building out the command itself and supply the necessary strings to the help engine.  

6. Now lets build your own command line plugin.
  - [ ] install the Pingo.Commandline.PluginTemplate Extension
    - [ ] direct: https://visualstudiogallery.msdn.microsoft.com/7b579419-fdbd-4b47-880c-261409120bb9
    - [ ] Visual Studio 2013: Tools -> Extensions and Updates... -> Online
  - [ ] restart visual studio 2013  

7. Solution -> Add -> Project
  - [ ] Select Pingo.Commandline.PluginTemplate
    - [ ] Name it "My.Sweet.Command"
  - [ ] A wizard prompt asks for what your command name should be.
    - [ ] Enter "Sweet"
  - [ ] Press "Done"  
  - [ ] Build "My.Sweet.Command"
  - [ ] Add the  "My.Sweet.Command" project as a reference to "ConsoleMe"
  - [ ] Build "ConsoleMe"

9. Done and Run!  
You should see your "Sweet" command in the list of now usable commands.  

10. Modify your command project to suit.

11. uninstall Pingo.JsonConverters.Commands and Pingo.TestCommands from ConsoleMe  
Unless you really want to keep them in there for their profound awesomeness.












