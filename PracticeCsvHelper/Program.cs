using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace PracticeCsvHelper
{
    class Program
    {
        static List<List<string>> resTable = new List<List<string>>();

        static void Main(string[] args)
        {
            var appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("application dir: " + appDir);
            string testFile = appDir + @"/../../../../SalesActionPlan.csv";
            Console.WriteLine(File.Exists(testFile) ? "File exists." : "File does not exist.");
            using (var reader = new StreamReader(testFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //var records = new List<Foo>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    List<string> row = new List<string>();
                    var record = new Foo
                    {
                        eval = csv.GetField("EVALUATIONTYPE"),
                        score = csv.GetField("SCORE"),
                        mitigate = csv.GetField("MITIGATIONACTION")
                    };
                    row.Add(record.eval);
                    row.Add(record.score);
                    row.Add(record.mitigate);
                    resTable.Add(row);
                    //resTable.Add(record.Id, record.Name);
                    //records.Add(record);
                }
                //Console.WriteLine("record item: " + records[0].Id);
                //Console.WriteLine("record item: " + records[1].Id);
                //Console.WriteLine("record item: " + records[0].Name);
                //Console.WriteLine("record item: " + records[1].Name);
            }
            //foreach (var pair in _fields)
            //{
            //    Console.WriteLine(pair.Key + ": " + pair.Value);
            //}
            foreach (var row in resTable)
            {
                foreach (var col in row)
                {
                    Console.WriteLine(col);
                }
            }
            Console.WriteLine("Hello World!");
        }
    }

    public class Foo
    {
        public string eval { get; set; }
        public string score { get; set; }
        public string mitigate { get; set; }
    }
}
