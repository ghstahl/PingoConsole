using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Pingo.JsonConverters.Commands.Executables
{
    class Xml2JsonExecutable : IExecutable
    {
        public string Source { get; set; }
        public string Output { get; set; }

        public IExecuteResult Execute()
        {
            var executeResult = new ExecuteResult {Name = "Xml2Json"};

            try
            {
                var doc = new XmlDocument();
                doc.Load(Source);
                string jsonText = JsonConvert.SerializeXmlNode(doc);

                Pingo.CommandLine.IO.FileSystem.EnsurePathsExist(Output);

                File.WriteAllText(Output, jsonText);
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError { ErrorText = e.Message };
                executeResult.ErrorsStore.Add(executeError);
            }
            LastResult = executeResult;
            return LastResult;
        }

        public IExecuteResult LastResult { get; private set; }
    }
}