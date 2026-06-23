namespace OOP_lab1;

public class Square : Rectangle

{
    public Square(int x, int y, int side) :base(x, y, side, side)
    {
    }

    public override void Draw(Graphics g)
    {
        g.DrawRectangle(new Pen(Color.Black), this.x, this.y, this.width, this.height);
    }
}
