
using System;
using System.Xml;

namespace OOP3.Shapes
{
    public class Rectanglem: Shape
    {
        public double Width  { get; set; } = 1.0;
        public double Height { get; set; } = 1.0;

        public override string TypeName => "Rectangle";

        public override double GetArea() => Width * Height;

        public override string Describe() =>
            base.Describe() + $", Width={Width}, Height={Height}";

        protected override void WriteShapeXml(XmlWriter writer)
        {
            writer.WriteElementString("Width",  Width.ToString());
            writer.WriteElementString("Height", Height.ToString());
        }

        protected override void ReadShapeXml(XmlReader reader)
        {
            reader.ReadToDescendant("Width");
            Width  = double.Parse(reader.ReadElementContentAsString());
            Height = double.Parse(reader.ReadElementContentAsString());
        }

        protected override void EditShape()
        {
            Console.Write($"  Width [{Width}]: ");
            string input = Console.ReadLine()!;
            if (double.TryParse(input, out double w)) Width = w;

            Console.Write($"  Height [{Height}]: ");
            input = Console.ReadLine()!;
            if (double.TryParse(input, out double h)) Height = h;
        }
    }
}