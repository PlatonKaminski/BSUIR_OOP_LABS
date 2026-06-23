using OOP_lab2;

namespace ExternalPlugin_Triangle
{
    /// <summary>
    /// Triangle figure - external plugin class.
    /// Extends the base hierarchy without modifying the main program.
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>Base length of the triangle.</summary>
        public int Base { get; set; }

        /// <summary>Height of the triangle.</summary>
        public int Height { get; set; }

        public Triangle(int x, int y, int triangleBase, int height)
            : base(x, y)
        {
            Base   = triangleBase;
            Height = height;
        }
    }
}