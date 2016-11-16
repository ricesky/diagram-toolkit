using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class LineSegment : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public LineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;

        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);

            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public override void Add(DrawingObject obj)
        {
            //this.drawingObjects.Add(obj);
        }

        public override void Remove(DrawingObject obj)
        {
            //this.drawingObjects.Remove(obj);
        }
    }
}
