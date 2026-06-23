using System;
using System.Xml;

namespace OOP3.Shapes
{
    public class Ellipse : Shape
    {
        public double SemiA { get; set; } = 3.0;
        public double SemiB { get; set; } = 2.0;

        public override string TypeName => "Ellipse";

        public override double GetArea() => Math.PI * SemiA * SemiB;

        public override string Describe() =>
            base.Describe() + $", SemiA={SemiA}, SemiB={SemiB}";

        protected override void WriteShapeXml(XmlWriter writer)
        {
            writer.WriteElementString("SemiA", SemiA.ToString());
            writer.WriteElementString("SemiB", SemiB.ToString());
        }

        protected override void ReadShapeXml(XmlReader reader)
        {
            reader.ReadToDescendant("SemiA");
            SemiA = double.Parse(reader.ReadElementContentAsString());
            SemiB = double.Parse(reader.ReadElementContentAsString());
        }

        protected override void EditShape()
        {
            Console.Write($"  SemiA [{SemiA}]: ");
            string input = Console.ReadLine()!;
            if (double.TryParse(input, out double a)) SemiA = a;

            Console.Write($"  SemiB [{SemiB}]: ");
            input = Console.ReadLine()!;
            if (double.TryParse(input, out double b)) SemiB = b;
        }
    }
}