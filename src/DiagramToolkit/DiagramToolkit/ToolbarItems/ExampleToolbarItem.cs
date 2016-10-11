using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    public class ExampleToolbarItem : ToolStripButton, IToolbarItem
    {
        public ExampleToolbarItem()
        {
            this.Name = "Example";
            this.ToolTipText = "Example toolbaritem";
            this.Image = IconSet.folder;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }
        
    }
}
