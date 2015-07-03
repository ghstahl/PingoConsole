using System;
using System.IO;
using System.Xml;
using Json2Xml.Core.CommandLine;
using Newtonsoft.Json;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Json2Xml.Core.Executables
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
                doc.Load(Parser.Source);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                File.WriteAllText(Parser.Output, jsonText);
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