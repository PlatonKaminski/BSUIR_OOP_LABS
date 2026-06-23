using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using OOP_lab2.Plugins;

namespace ExternalProcessing_XmlToJson
{

    public class XmlToJsonPlugin : IProcessingPlugin
    {
        public string Name => "XML → JSON";
        
        public string ProcessBeforeSave(string xmlPath)
        {
            XDocument xml = XDocument.Load(xmlPath);

            var figures =
                new List<Dictionary<string, string>>();

            foreach (var element in xml.Root!.Elements("Figure"))
            {
                var dict = new Dictionary<string, string>();

                dict["type"] =
                    element.Attribute("type")?.Value ?? "";

                foreach (var child in element.Elements())
                    dict[child.Name.LocalName] = child.Value;

                figures.Add(dict);
            }
            
            string json = JsonSerializer.Serialize(figures,
                new JsonSerializerOptions { WriteIndented = true });
            
            string jsonPath =
                Path.ChangeExtension(xmlPath, ".json");

            File.WriteAllText(jsonPath, json, Encoding.UTF8);

            return jsonPath;
        }
        
        public string ProcessAfterLoad(string jsonPath)
        {
            string json = File.ReadAllText(jsonPath, Encoding.UTF8);

            var figures = JsonSerializer
                .Deserialize<List<Dictionary<string, string>>>(json)!;

            var root = new XElement("Figures");

            foreach (var dict in figures)
            {
                string type = dict.ContainsKey("type")
                    ? dict["type"] : "";

                var element = new XElement("Figure",
                    new XAttribute("type", type));

                foreach (var kvp in dict)
                {
                    if (kvp.Key == "type") continue;
                    element.Add(new XElement(kvp.Key, kvp.Value));
                }

                root.Add(element);
            }

            string xmlPath =
                Path.ChangeExtension(jsonPath, ".xml");

            new XDocument(root).Save(xmlPath);

            return xmlPath;
        }
    }
}