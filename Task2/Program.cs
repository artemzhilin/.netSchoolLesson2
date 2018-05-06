using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var filesList = Directory.GetFiles("operations");
            var xmlOperationSerializer = new XmlSerializer(typeof(BankOperation));
            var operations = new List<BankOperation>();
            foreach (var filePath in filesList)
            {
                try
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        switch (Path.GetExtension(filePath))
                        {
                            case ".xml":
                                operations.Add((BankOperation)xmlOperationSerializer.Deserialize(reader));
                                break;
                            case ".json":
                                operations.Add(JsonConvert.DeserializeObject<BankOperation>(reader.ReadToEnd()));
                                break;
                            default:
                                Console.WriteLine($"Unexpected file extension: {filePath}");
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not read file {filePath}. Maybe it's broken");
                }
            }
            Console.WriteLine();
            Console.WriteLine(operations.Max());
        }
    }
}