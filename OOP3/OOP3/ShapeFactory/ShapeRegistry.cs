using System;
using System.Collections.Generic;
using OOP3.Shapes;

namespace OOP3.ShapeFactory
{
    public static class ShapeRegistry
    {
        private static readonly Dictionary<string, Func<IShape>> _registry =
            new Dictionary<string, Func<IShape>>();
        
        static ShapeRegistry()
        {
            Register("Circle",    () => new Circle());
            Register("Rectangle", () => new Rectanglem());
            Register("Triangle",  () => new Triangle());
            Register("Ellipse",   () => new Ellipse());
            Register("Square",    () => new Square());
        }
        
        public static void Register(string typeName, Func<IShape> factory)
        {
            _registry[typeName] = factory;
        }
        
        public static IShape Create(string typeName)
        {
            if (_registry.TryGetValue(typeName, out Func<IShape>? factory))
                return factory();

            throw new InvalidOperationException(
                $"Unknown shape type: '{typeName}'. Register it in ShapeRegistry.");
        }
        
        public static IEnumerable<string> GetAllTypeNames() => _registry.Keys;
    }
}