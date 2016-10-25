using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public class DefaultEditor : TabControl, IEditor
    {
        private List<ICanvas> canvases;
        private ICanvas selectedCanvas;
        private IToolbox toolbox;

        public IToolbox Toolbox
        {
            get
            {
                return this.toolbox;
            }

            set
            {
                this.toolbox = value;
            }
        }

        public DefaultEditor()
        {
            Dock = DockStyle.Fill;
            canvases = new List<ICanvas>();

            this.Selected += DefaultEditor_Selected;
        }

        private void DefaultEditor_Selected(object sender, TabControlEventArgs e)
        {
            this.selectedCanvas = (ICanvas)e.TabPage.Controls[0];
            this.toolbox.ActiveTool = this.selectedCanvas.GetActiveTool();
        }

        public void AddCanvas(ICanvas canvas)
        {
            canvases.Add(canvas);
            TabPage tabPage = new TabPage(canvas.Name);
            tabPage.Controls.Add((Control)canvas);
            this.Controls.Add(tabPage);
            this.SelectedTab = tabPage;
            this.selectedCanvas = canvas;
        }

        public ICanvas GetSelectedCanvas()
        {
            return this.selectedCanvas;
        }

        public void RemoveCanvas(ICanvas canvas)
        {
            throw new NotImplementedException();
        }

        public void RemoveSelectedCanvas()
        {
            //TabPage selectedTab = this.SelectedTab;
            
        }

        public void SelectCanvas(ICanvas canvas)
        {
            this.selectedCanvas = canvas;
        }
    }
}
