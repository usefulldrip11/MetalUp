using System.Drawing;
namespace OOPDraw
{
 public abstract class Shape
 {
        public Pen Pen { get; private set; }

        public int X1 { get; private set; }

        public int X2 { get; private set; }

        public int Y1 { get; private set; }

        public int Y2 { get; private set; }
        public abstract void Draw(Graphics g);
 public abstract void GrowTo(int x2, int y2);
 }
}