using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Shapes
{
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public PointF Position { get; set; }

        private Brush brush;
        private Font font;

        public Text()
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public override void Add(DrawingObject obj)
        {
            //do nothing
        }

        public override void Remove(DrawingObject obj)
        {
            //do nothing
        }

        public override bool Intersect(int xTest, int yTest)
        {
            return false;
        }

        public override void RenderOnEditingView()
        {
            Graphics.DrawString(Value, font, brush, Position);
        }

        public override void RenderOnPreview()
        {
            Graphics.DrawString(Value, font, brush, Position);
        }

        public override void RenderOnStaticView()
        {
            Graphics.DrawString(Value, font, brush, Position);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            //throw new NotImplementedException();
        }
    }
}
