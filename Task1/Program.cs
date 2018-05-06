using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Task1
{
    internal class Program
    {
        private const string ClientInfoInputFilePath = "clientinfo_input.xml";
        private const string ClientInfoOutputFileName = "clientinfo_output";        
        
        public static void Main(string[] args)
        {
            var fileExists = File.Exists(ClientInfoInputFilePath);
            if (!fileExists)
            {
                Console.WriteLine($"File {ClientInfoInputFilePath} does not exist!");
                return;
            }
            
            var xmlClientInfoMalformedSerializer = new XmlSerializer(typeof(ClientInfoMalformed));
            var clientInfo = new ClientInfo();
            try
            {
                using (var reader = new StreamReader(ClientInfoInputFilePath))
                {
                    var clientInfoMalformed = (ClientInfoMalformed)xmlClientInfoMalformedSerializer.Deserialize(reader);
                    clientInfo.MatchPropertiesFrom(clientInfoMalformed);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine($"The file {ClientInfoInputFilePath} could not be read: ");
                Console.WriteLine(e.Message);
            }

            try
            {
                SaveToXml(clientInfo, $"{ClientInfoOutputFileName}.xml");
                SaveToJson(clientInfo, $"{ClientInfoOutputFileName}.json");
                SaveToXml(clientInfo.WorkAddress, "workaddress_output.xml");
                SaveToJson(clientInfo.HomeAddress, "homeaddress_output.json");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not write to file");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Finished");
        }

        public static void SaveToXml(object target, string filePath)
        {
            var xmlSerializer = new XmlSerializer(target.GetType());
            using (var writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, target);
            }
        }

        public static void SaveToJson(object target, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                var jsonObject = JsonConvert.SerializeObject(target);
                writer.WriteLine(jsonObject);
            }
        }
    }
}