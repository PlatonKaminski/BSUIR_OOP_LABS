using System.Drawing;

namespace OOP_lab1;

public abstract class Figure
{
    protected int x;  
    protected int y;
    
    public Figure(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public abstract void Draw(Graphics g);

}