using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    
    public class JsonFileReader : BaseFileReader
    {
        public override string SupportedFormat => "JSON";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening JSON stream...");

            string rawJson = File.ReadAllText(filePath);
            int propertyCount = 0;

            
            using (JsonDocument doc = JsonDocument.Parse(rawJson))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var _ in doc.RootElement.EnumerateObject())
                    {
                        propertyCount++;
                    }
                }
                else if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    propertyCount = doc.RootElement.GetArrayLength();
                }
            }

            Console.WriteLine($" -> Parsed {propertyCount} root properties.");

            string displayContent = rawJson.Length > 100
                ? rawJson.Substring(0, 100) + "..."
                : rawJson;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(displayContent);
            Console.WriteLine("----------------------------\n");
        }
    }
}