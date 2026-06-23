using System;
using System.Drawing;
using OOP_lab2.Plugins;
using OOP_lab2;
using System.Xml.Linq;

namespace ExternalPlugin_Triangle
{
    /// <summary>
    /// Plugin that registers Triangle figure in the main application.
    /// 
    /// To install this plugin:
    /// 1. Build this project -> produces ExternalPlugin_Triangle.dll
    /// 2. Sign it with PluginSigner tool
    /// 3. Copy .dll and .dll.sig to "plugins" folder next to main .exe
    /// 4. Restart or click "Обновить плагины" in the main app
    /// 
    /// No changes to main program code are needed!
    /// </summary>
    public class TrianglePlugin : IPlugin
    {
        public string Name => "Треугольник";

        public Type FigureType => typeof(Triangle);

        public string[] ParameterNames =>
            new[] { "X", "Y", "Основание", "Высота" };

        /// <summary>
        /// Create a Triangle from 4 integer parameters.
        /// </summary>
        public Figure Create(int[] p) =>
            new Triangle(p[0], p[1], p[2], p[3]);

        /// <summary>
        /// Draw the triangle as three lines forming a triangle shape.
        /// </summary>
        public void Draw(Graphics g, Figure figure)
        {
            var t = (Triangle)figure;

            // Calculate the three vertices of the triangle:
            // Bottom-left, Bottom-right, Top-center
            var points = new Point[]
            {
                new Point(t.X,              t.Y + t.Height), // bottom left
                new Point(t.X + t.Base,     t.Y + t.Height), // bottom right
                new Point(t.X + t.Base / 2, t.Y)             // top center
            };

            // Draw filled polygon outline
            using var pen = new Pen(Color.DarkGreen, 2);
            g.DrawPolygon(pen, points);
        }
        public XElement Serialize(Figure figure)
        {
            var c = (Triangle)figure;

            return new XElement("Figure",
                new XAttribute("type", "Ellipse"),
                new XElement("X", c.X),
                new XElement("Y", c.Y),
                new XElement("Base", c.Base),
                new XElement("Height", c.Height)
            );
        }

        /// <summary>
        /// Deserialize Circle from XML element.
        /// </summary>
        public Figure Deserialize(XElement element)
        {
            int x      = int.Parse(element.Element("X").Value);
            int y      = int.Parse(element.Element("Y").Value);
            int bas = int.Parse(element.Element("Base").Value);
            int height = int.Parse(element.Element("Height").Value);

            return new Triangle(x, y, bas, height);
        }
        
        
    }
}