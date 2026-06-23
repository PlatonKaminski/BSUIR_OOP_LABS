namespace OOP_lab1;

public class Circle : Ellipse 
{

    public Circle(int x, int y, int diameter) : base(x, y, diameter, diameter)
    {
    }
    
    public override void Draw(Graphics g)
    {
        g.DrawEllipse(new Pen(Color.Black), x, y, width, height);
    }
}