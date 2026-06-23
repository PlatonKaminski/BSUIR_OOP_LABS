using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab1
{
    class Program
    {
        private static FigureList figures;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var form = new Form();
            form.Size = new Size(450, 500);
            form.Text = "Лабораторная работа 1";
            form.StartPosition = FormStartPosition.CenterScreen;
            
            figures = new FigureList();
            
            figures.Add(new Line(30, 100, 100, 200));
            figures.Add(new Rectangle(110, 100, 150, 100));
            figures.Add(new Ellipse(300, 100, 120, 80));
            figures.Add(new Circle(30, 300, 100 ));
            figures.Add(new Arc(150, 300, 80, 200, 180,120));
            figures.Add(new Square(300, 300, 100));

            form.Paint += Form_Paint;

            Application.Run(form);
        }
        
        private static void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
                foreach (var figure in figures.GetShapes())
                {
                    figure.Draw(g);
                }
        }
    }
}