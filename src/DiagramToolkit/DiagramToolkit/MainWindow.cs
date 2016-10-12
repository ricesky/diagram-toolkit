using DiagramToolkit.Commands;
using DiagramToolkit.MenuItems;
using DiagramToolkit.ToolbarItems;
using DiagramToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;
        private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Canvas
            Debug.WriteLine("Loading canvas...");
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);

            #endregion

            #region Commands

            BlackCanvasBgCommand blackCanvasBgCmd = new BlackCanvasBgCommand(this.canvas);
            WhiteCanvasBgCommand whiteCanvasBgCmd = new WhiteCanvasBgCommand(this.canvas);

            #endregion

            #region Menubar
            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuItem exampleMenuItem1 = new DefaultMenuItem("File");
            this.menubar.AddMenuItem(exampleMenuItem1);

            DefaultMenuItem exampleMenuItem11 = new DefaultMenuItem("New");
            exampleMenuItem1.AddMenuItem(exampleMenuItem11);

            DefaultMenuItem exampleMenuItem2 = new DefaultMenuItem("Edit");
            this.menubar.AddMenuItem(exampleMenuItem2);

            DefaultMenuItem exampleMenuItem21 = new DefaultMenuItem("Change to Black");
            exampleMenuItem21.SetCommand(blackCanvasBgCmd);
            exampleMenuItem2.AddMenuItem(exampleMenuItem21);
            DefaultMenuItem exampleMenuItem22 = new DefaultMenuItem("Change to White");
            exampleMenuItem22.SetCommand(whiteCanvasBgCmd);
            exampleMenuItem2.AddMenuItem(exampleMenuItem22);

            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new ExampleTool());
            this.toolbox.AddTool(new ExampleTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion

            #region Toolbar
            // Initializing toolbar
            Debug.WriteLine("Loading toolbar...");
            this.toolbar = new DefaultToolbar();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            ExampleToolbarItem toolItem1 = new ExampleToolbarItem();
            toolItem1.SetCommand(whiteCanvasBgCmd);
            ExampleToolbarItem toolItem2 = new ExampleToolbarItem();
            toolItem2.SetCommand(blackCanvasBgCmd);

            this.toolbar.AddToolbarItem(toolItem1);
            this.toolbar.AddSeparator();
            this.toolbar.AddToolbarItem(toolItem2);

            #endregion

        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
