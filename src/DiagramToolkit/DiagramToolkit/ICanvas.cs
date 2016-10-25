using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface ICanvas
    {
        String Name { get; set; }
        ITool GetActiveTool();
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);

        void AddDrawingObject(DrawingObject drawingObject);
        void RemoveDrawingObject(DrawingObject drawingObject);

        DrawingObject SelectObjectAt(int x, int y);
        void DeselectAllObjects();
    }
}
