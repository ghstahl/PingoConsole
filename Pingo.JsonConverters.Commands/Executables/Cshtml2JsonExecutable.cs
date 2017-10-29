using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Pingo.CommandLine.Contracts.Execute;
using Pingo.CommandLine.Execute;

namespace Pingo.JsonConverters.Commands.Executables
{
    public class FileSystemEventSink : IFileSystemEventSink
    {
        public List<RazorLocation> RazorLocations = new List<RazorLocation>();
        private string _root;
        public void OnNewDirectory(string fullPath)
        {
            if (string.IsNullOrEmpty(_root))
            {
                _root = fullPath;
            }
        }

        public void OnNewFile(string fullPath)
        {
            var fi = new FileInfo(fullPath);
            if (fi.Extension == ".cshtml")
            {
                var sub = fullPath.Substring(_root.Length);
                var location = sub.Replace('\\', '/');
                var content = File.ReadAllText(fullPath);
                RazorLocations.Add(new RazorLocation() { Location = location, Content = content });
            }
        }
    }
    public class RazorLocation
    {
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
    public class RazorLocationViews
    {
        [JsonProperty("views")]
        public RazorLocation[] Views { get; set; }
    }

    class Cshtml2JsonExecutable : IExecutable
    {
        static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
        public static RazorLocationViews FromJson(string json) => JsonConvert.DeserializeObject<RazorLocationViews>(json, Settings);
        public static string ToJson(RazorLocationViews o) => JsonConvert.SerializeObject((object)o, (JsonSerializerSettings)Settings);

        public string Source { get; set; }
        public string Output { get; set; }

        public IExecuteResult Execute()
        {
            var executeResult = new ExecuteResult { Name = "cshtml2json" };
            try
            {
                var fileSystemEnumerator = new FileSystemEnumerator(Source);
                var mySink = new FileSystemEventSink();
                fileSystemEnumerator.RegisterEventSink(mySink);

                fileSystemEnumerator.Start();

                var final = new RazorLocationViews()
                {
                    Views = mySink.RazorLocations.ToArray()
                };


                var json = ToJson(final);
                File.WriteAllText(Output, json);
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