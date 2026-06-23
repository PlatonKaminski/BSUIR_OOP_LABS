namespace OOP_lab1;

public class Arc : Figure
{
    private int width;
    private int height;
    private int startAngle;
    private int endAngle;

    public Arc(int x, int y, int width, int height, int startAngle, int endAngle) : base(x, y)
    {
        this.width = width;
        this.height = height;
        this.startAngle = startAngle;
        this.endAngle = endAngle;
    }

    public override void Draw(Graphics g)
    {
        g.DrawArc(new Pen(Color.Black), x, y, width, height, startAngle, endAngle);
    }
}