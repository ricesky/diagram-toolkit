using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class Rectangle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public Rectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangle(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }

        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }

        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public override void Add(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override void Remove(DrawingObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
