using DiagramToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramPlugin.CurveTool
{
    public class CurveTool : ToolStripButton, ITool, IPlugin
    {
        private string name;

        public System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public IPluginHost Host
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CurveTool()
        {
            this.Name = "Curve tool";
            this.ToolTipText = "Curve tool";
            this.Image = IconSet.vector;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, System.Windows.Forms.Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
