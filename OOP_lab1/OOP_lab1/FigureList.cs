using System;
using System.Collections.Generic;
using System.Drawing;

namespace OOP_lab1;

public class FigureList
{
    private List<Figure> figures;
    
    public FigureList()
    {
        figures = new List<Figure>();
    }
    
    public List<Figure> GetShapes()
    {
        return figures;
    }
        
    public void Add(Figure shape) => figures.Add(shape);
        

}