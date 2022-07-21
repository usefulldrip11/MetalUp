using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPDraw
{
    public partial class OOPDraw : Form
    {
        public OOPDraw()
        {
            InitializeComponent();
            DoubleBuffered = true; //stops image flickering
            LineWidth.SelectedItem = "Medium";
            Colour.SelectedItem = "Green";
            Shape.SelectedItem = "Line";

            //shapes.Add(new Rectangle(currentPen, 100, 100, 300, 200));

        }

        Pen currentPen = new Pen(Color.Black);
        bool dragging = false;
        Point startofdrag = Point.Empty;
        Point lastmouseposition = Point.Empty;
        List<Shape> shapes = new List<Shape>();

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
      
            Graphics gr = e.Graphics;
            foreach (Shape shape in shapes)
            {
                shape.Draw(gr);
                
            }

            Console.WriteLine("nerd");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void OOPDraw_Load(object sender, EventArgs e)
        {

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startofdrag = lastmouseposition = e.Location;
            switch (Shape.Text)
            {
                case "Line":
                    shapes.Add(new Line(currentPen, e.X, e.Y));
                        break;
                case "Rectangle":
                    shapes.Add(new Rectangle(currentPen, e.X, e.Y));
                    break;

                    
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Shape shape = shapes.Last();
                shape.GrowTo(e.X, e.Y);
                lastmouseposition = e.Location;
                Refresh();

            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float width = currentPen.Width;
            switch (LineWidth.Text)
            {
                case "Thin":
                    Width = (int)2.0F;
                    break;
                case "Medium":
                    Width = (int)4.0F;
                    break;
                case "Thick":
                    Width = (int)8.0F;
                    break;

            }
            currentPen = new Pen(currentPen.Color, width);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Colour_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = currentPen.Color;
            switch (Colour.Text)
            {
                case "Red":
                    color = Color.Red;
                    break;
                case "Blue":
                    color = Color.Blue;
                    break;
                case "Green":
                    color = Color.Green;
                    break;
            }
            currentPen = new Pen(color, currentPen.Width);
        }

        private void LineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            float width = currentPen.Width;
            switch (LineWidth.Text)
            {
                case "Thin":
                    width = 2.0F;
                    break;
                case "Medium":
                    width = 4.0F;
                    break;
                case "Thick":
                    width = 8.0F;
                    break;

            }
            currentPen = new Pen(currentPen.Color, width);
        }
    }
}
