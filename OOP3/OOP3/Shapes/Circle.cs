using System;
using System.Xml;

namespace OOP3.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; } = 1.0;

        public override string TypeName => "Circle";

        public override double GetArea() => Math.PI * Radius * Radius;

        public override string Describe() =>
            base.Describe() + $", Radius={Radius}";

        protected override void WriteShapeXml(XmlWriter writer)
        {
            writer.WriteElementString("Radius", Radius.ToString());
        }

        protected override void ReadShapeXml(XmlReader reader)
        {
            reader.ReadToDescendant("Radius");
            Radius = double.Parse(reader.ReadElementContentAsString());
        }

        protected override void EditShape()
        {
            Console.Write($"  Radius [{Radius}]: ");
            string input = Console.ReadLine()!;
            if (double.TryParse(input, out double r)) Radius = r;
        }
    }
}