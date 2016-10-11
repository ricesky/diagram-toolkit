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

            DefaultMenuItem exampleMenuItem21 = new DefaultMenuItem("Cut");
            exampleMenuItem2.AddMenuItem(exampleMenuItem21);
            DefaultMenuItem exampleMenuItem22 = new DefaultMenuItem("Copy");
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

            this.toolbar.AddToolbarItem(new ExampleToolbarItem());
            this.toolbar.AddSeparator();
            this.toolbar.AddToolbarItem(new ExampleToolbarItem());

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
