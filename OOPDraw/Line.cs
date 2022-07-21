﻿using System;
using System.Drawing;


namespace OOPDraw
{
    public class Line : Shape
    {

        public Line(Pen p, int x1, int y1, int x2, int y2)
        {
            Pen = p;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

        }

        public Line(Pen p , int x1, int y1) : this(p, x1,y1,x1,y1)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, X1, Y1, X2, Y2);
        }

        public override void GrowTo(int x2, int y2)
        {
            X2 = x2;
            Y2 = y2;
        }
    }
}
