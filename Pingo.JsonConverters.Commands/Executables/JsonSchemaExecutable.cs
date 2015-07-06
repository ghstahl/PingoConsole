using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Pingo.JsonConverters.Commands.Executables
{
    class JsonSchemaExecutable : IExecutable
    {
        public string Source { get; set; }
        public string SourceSchema { get; set; }

        public IExecuteResult Execute()
        {
            var executeResult = new ExecuteResult { Name = "JsonSchema" };
            try
            {
                var jsonSchema = File.ReadAllText(SourceSchema);
                var jsonSource = File.ReadAllText(Source);
                // load schema
                JSchema schema = JSchema.Parse(jsonSchema);
                JToken json = JToken.Parse(jsonSource);

                // validate json
                IList<ValidationError> errors;
                bool valid = json.IsValid(schema, out errors);


                if (!valid)
                {
                    foreach (var error in errors)
                    {
                        var executeError = new ExecuteError { ErrorText = error.Message };
                        executeResult.ErrorsStore.Add(executeError);
                    }                    
                }
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
