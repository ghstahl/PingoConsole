using System;
using System.IO;
using Newtonsoft.Json;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Json2Xml.Core.Executables
{
    class Json2XmlExecutable : IExecutable
    {
        public string Source { get; set; }
        public string Output { get; set; }

        public IExecuteResult Execute()
        {
            var executeResult = new ExecuteResult {Name = "Json2Xml"};
            try
            {
                var json = File.ReadAllText(Source);
                var doc = JsonConvert.DeserializeXmlNode(json);
                doc.Save(Output);
            }
            catch (Exception e)
            {
                var executeError = new ExecuteError {ErrorText = e.Message};
                executeResult.ErrorsStore.Add(executeError);
            }
            LastResult = executeResult;
            return LastResult;
        }

        public IExecuteResult LastResult { get; private set; }
    }
}
