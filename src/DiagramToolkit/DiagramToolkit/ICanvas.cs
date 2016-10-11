using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool);
        void Repaint();
    }
}
