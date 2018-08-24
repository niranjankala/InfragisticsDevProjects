using InfragisticsDev.Common.Helpers;
using InfragisticsDev.Win.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            try
            {
                XMLHelper.ToXML(@"D:\Repositories\GitHub\InfragisticsDevProjects\InfragisticsDev.Win\LoadIS\ZoneLoadProps.xml", new TemplateProperty()
                { }
                    );
            }
            catch (Exception ex)
            {                
            }
        }
    }
}
