using System;
using System.IO;

namespace ConsoleApp1
{
    
    public class CsvFileReader : BaseFileReader
    {
        public override string SupportedFormat => "CSV";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening CSV stream...");

            string[] lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int colCount = 0;

            if (rowCount > 0)
            {
                
                string[] columns = lines[0].Split(',');
                colCount = columns.Length;
            }

            Console.WriteLine($" -> Detected {rowCount} rows and {colCount} columns.");

            
            string rawCsv = string.Join(Environment.NewLine, lines);
            string displayContent = rawCsv.Length > 100
                ? rawCsv.Substring(0, 100) + "..."
                : rawCsv;

            Console.WriteLine("\n--- First 100 Characters ---");
            Console.WriteLine(displayContent);
            Console.WriteLine("----------------------------\n");
        }
    }
}
