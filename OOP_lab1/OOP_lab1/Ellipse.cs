namespace OOP_lab1;

public class Ellipse : Figure
{
    protected int width;
    protected int height;

    public Ellipse(int x, int y, int width, int height) : base(x, y)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw(Graphics g)
    {
        g.DrawEllipse(new Pen(Color.Black), this.x, this.y, this.width, this.height);
    }
}
