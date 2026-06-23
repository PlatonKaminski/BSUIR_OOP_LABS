using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using OOP3.ShapeFactory;
using OOP3.Shapes;

namespace OOP3.Serialization
{

    public class XmlShapeSerializer
    {
        private readonly string _filePath;

        public XmlShapeSerializer(string filePath)
        {
            _filePath = filePath;
        }
        
        public void Save(List<IShape> shapes)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  "
            };

            using XmlWriter writer = XmlWriter.Create(_filePath, settings);
            
            writer.WriteStartElement("Shapes");

            foreach (IShape shape in shapes)
            {
                writer.WriteStartElement(shape.TypeName);
                
                shape.WriteXml(writer);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
        public List<IShape> Load()
        {
            var shapes = new List<IShape>();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"File not found: {_filePath}");
                return shapes;
            }

            var settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments   = true
            };

            using XmlReader reader = XmlReader.Create(_filePath, settings);

            reader.ReadToFollowing("Shapes");
            
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element) continue;
                if (reader.Name == "Shapes") continue;

                string typeName = reader.Name;


                IShape shape = ShapeRegistry.Create(typeName);
                
                shape.ReadXml(reader);

                shapes.Add(shape);
            }

            return shapes;
        }
    }
}