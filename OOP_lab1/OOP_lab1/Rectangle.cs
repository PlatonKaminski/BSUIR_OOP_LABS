using System.Drawing;

namespace OOP_lab1;

public class Rectangle : Figure
{
    protected int width;
    protected int height;

    public Rectangle(int x, int y, int width, int height) :base(x, y)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw(Graphics g)
    {
        g.DrawRectangle(new Pen(Color.Black), x, y, width, height);
    }
}