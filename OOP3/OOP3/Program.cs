using System;
using System.Collections.Generic;
using OOP3.ShapeFactory;
using OOP3.Serialization;
using OOP3.Shapes;

namespace OOP3
{
    class Program
    {
        private static List<IShape> _shapes = new List<IShape>();
        
        private static readonly XmlShapeSerializer _serializer =
            new XmlShapeSerializer("shapes.xml");

        static void Main(string[] args)
        {
            Console.WriteLine("=== Shapes XML Serializer ===\n");

            bool running = true;
            while (running)
            {
                PrintMenu();
                string choice = Console.ReadLine()!.Trim();

                switch (choice)
                {
                    case "1": ListShapes();   break;
                    case "2": AddShape();     break;
                    case "3": EditShape();    break;
                    case "4": DeleteShape();  break;
                    case "5": SaveShapes();   break;
                    case "6": LoadShapes();   break;
                    case "0": running = false; break;
                    default:
                        Console.WriteLine("Unknown option, try again.\n");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
        

        static void PrintMenu()
        {
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. List all shapes");
            Console.WriteLine("2. Add shape");
            Console.WriteLine("3. Edit shape");
            Console.WriteLine("4. Delete shape");
            Console.WriteLine("5. Save to XML (shapes.xml)");
            Console.WriteLine("6. Load from XML (shapes.xml)");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
        }
        
        static void ListShapes()
        {
            Console.WriteLine();
            if (_shapes.Count == 0)
            {
                Console.WriteLine("  (list is empty)");
            }
            else
            {
                for (int i = 0; i < _shapes.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {_shapes[i].Describe()}");
                }
            }
            Console.WriteLine();
        }
        
        static void AddShape()
        {
            Console.WriteLine("\nAvailable types:");
            int idx = 1;

            var names = new List<string>(ShapeRegistry.GetAllTypeNames());
            foreach (string name in names)
            {
                Console.WriteLine($"  {idx++}. {name}");
            }

            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) ||
                choice < 1 || choice > names.Count)
            {
                Console.WriteLine("Invalid choice.\n");
                return;
            }
            
            IShape shape = ShapeRegistry.Create(names[choice - 1]);

            Console.WriteLine("Enter properties (press Enter to keep default):");
            shape.Edit();

            _shapes.Add(shape);
            Console.WriteLine($"Added: {shape.Describe()}\n");
        }
        static void EditShape()
        {
            if (_shapes.Count == 0) { Console.WriteLine("List is empty.\n"); return; }

            ListShapes();
            Console.Write("Enter shape number to edit: ");

            if (!int.TryParse(Console.ReadLine(), out int num) ||
                num < 1 || num > _shapes.Count)
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            IShape shape = _shapes[num - 1];
            Console.WriteLine($"Editing: {shape.Describe()}");
            Console.WriteLine("(Press Enter to keep current value)");
            
            shape.Edit();

            Console.WriteLine($"Updated: {shape.Describe()}\n");
        }
        
        static void DeleteShape()
        {
            if (_shapes.Count == 0) { Console.WriteLine("List is empty.\n"); return; }

            ListShapes();
            Console.Write("Enter shape number to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int num) ||
                num < 1 || num > _shapes.Count)
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            IShape removed = _shapes[num - 1];
            _shapes.RemoveAt(num - 1);
            Console.WriteLine($"Deleted: {removed.Describe()}\n");
        }
        static void SaveShapes()
        {
            _serializer.Save(_shapes);
            Console.WriteLine($"Saved {_shapes.Count} shape(s) to shapes.xml\n");
        }
        
        static void LoadShapes()
        {
            _shapes = _serializer.Load();
            Console.WriteLine($"Loaded {_shapes.Count} shape(s) from shapes.xml\n");
        }
    }
}