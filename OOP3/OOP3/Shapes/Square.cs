using System;
using System.Xml;

namespace OOP3.Shapes
{
    public class Square : Shape
    {
        public double Side { get; set; } = 1.0;

        public override string TypeName => "Square";

        public override double GetArea() => Side * Side;

        public override string Describe() =>
            base.Describe() + $", Side={Side}";

        protected override void WriteShapeXml(XmlWriter writer)
        {
            writer.WriteElementString("Side", Side.ToString());
        }

        protected override void ReadShapeXml(XmlReader reader)
        {
            reader.ReadToDescendant("Side");
            Side = double.Parse(reader.ReadElementContentAsString());
        }

        protected override void EditShape()
        {
            Console.Write($"  Side [{Side}]: ");
            string input = Console.ReadLine()!;
            if (double.TryParse(input, out double s)) Side = s;
        }
    }
}