using System.Xml;

namespace OOP3.Shapes
{
    public interface IShape
    {
        string TypeName { get; }

        string Describe();
        
        double GetArea();
        
        void WriteXml(XmlWriter writer);
        
        void ReadXml(XmlReader reader);
        
        void Edit();
    }
}