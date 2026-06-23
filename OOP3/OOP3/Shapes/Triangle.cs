using System;
using System.Xml;

namespace OOP3.Shapes
{
    public class Triangle : Shape
    {
        public double Base   { get; set; } = 1.0;
        public double Height { get; set; } = 1.0;

        public override string TypeName => "Triangle";

        public override double GetArea() => 0.5 * Base * Height;

        public override string Describe() =>
            base.Describe() + $", Base={Base}, Height={Height}";

        protected override void WriteShapeXml(XmlWriter writer)
        {
            writer.WriteElementString("Base",   Base.ToString());
            writer.WriteElementString("Height", Height.ToString());
        }

        protected override void ReadShapeXml(XmlReader reader)
        {
            reader.ReadToDescendant("Base");
            Base   = double.Parse(reader.ReadElementContentAsString());
            Height = double.Parse(reader.ReadElementContentAsString());
        }

        protected override void EditShape()
        {
            Console.Write($"  Base [{Base}]: ");
            string input = Console.ReadLine()!;
            if (double.TryParse(input, out double b)) Base = b;

            Console.Write($"  Height [{Height}]: ");
            input = Console.ReadLine()!;
            if (double.TryParse(input, out double h)) Height = h;
        }
    }
}