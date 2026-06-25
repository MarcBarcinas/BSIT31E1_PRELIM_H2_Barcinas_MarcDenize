using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
 
    public class XmlFileReader : BaseFileReader
    {
        public override string SupportedFormat => "XML";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening XML stream...");

            
            XDocument doc = XDocument.Load(filePath);

            
            string rootName = doc.Root?.Name.LocalName ?? "None";
            int descendantCount = doc.Descendants().Count();

            Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

            
            string rawXml = doc.ToString();
            string displayContent = rawXml.Length > 100
                ? rawXml.Substring(0, 100) + "..."
                : rawXml;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(displayContent);
            Console.WriteLine("----------------------------\n");
        }
    }
}