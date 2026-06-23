
using System;
using System.Xml;

namespace OOP3.Shapes
{
    public abstract class Shape : IShape
    {
        public string Name { get; set; } = "Shape";

        public string Color { get; set; } = "Black";
        
        public abstract string TypeName { get; }
        public abstract double GetArea();
        
        public virtual string Describe()
        {
            return $"[{TypeName}] Name={Name}, Color={Color}, Area={GetArea():F2}";
        }
        
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("color", Color);
            WriteShapeXml(writer);
        }
        
        public void ReadXml(XmlReader reader)
        {
            Name  = reader.GetAttribute("name")  ?? "Shape";
            Color = reader.GetAttribute("color") ?? "Black";
            
            ReadShapeXml(reader);
        }
        
        public void Edit()
        {
            Console.Write($"  Name [{Name}]: ");
            string input = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(input)) Name = input;

            Console.Write($"  Color [{Color}]: ");
            input = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(input)) Color = input;
            EditShape();
        }
        
        protected abstract void WriteShapeXml(XmlWriter writer);
        
        protected abstract void ReadShapeXml(XmlReader reader);
        
        protected abstract void EditShape();
    }
}