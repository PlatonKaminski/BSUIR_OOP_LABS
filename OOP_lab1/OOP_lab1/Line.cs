using System.Drawing.Drawing2D;

namespace OOP_lab1;

public class Line : Figure
{
    private int x2;
    private int y2;

    public Line(int x, int y, int x2, int y2) : base(x, y)
    {
        this.x2 = x2;
        this.y2 = y2;
    }

    public override void Draw(Graphics g)
    {
        g.DrawLine(new Pen(Color.Black), this.x, this.y, this.x2, this.y2);
    }
}