using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using InfragisticsDev.Common.Helpers;
using InfragisticsDev.Win.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfragisticsDev.Win
{
    public partial class ApplicationEvents : Form
    {
        public ApplicationEvents()
        {
            InitializeComponent();
        }

        private void ApplicationEvents_Load(object sender, EventArgs e)
        {
            
        }

        private void treeViewExamples_DoubleClick(object sender, EventArgs e)
        {
            UltraTree tree = (UltraTree)sender;
            UIElement element = tree.UIElement.LastElementEntered;
            if (element == null)
                return;

            UltraTreeNode node = element.GetContext(typeof(UltraTreeNode)) as UltraTreeNode;
            if (node == null)
                return;
            Form form = null;
            switch (node.Key)
            {
                case "GridHybridColumnsLayout":
                    form = new InfragisticsDev.Win.GridControl.GroupsLayout.Form3();
                    break;
                default:
                    break;
            }
            form.ShowDialog();
        }
    }
}
