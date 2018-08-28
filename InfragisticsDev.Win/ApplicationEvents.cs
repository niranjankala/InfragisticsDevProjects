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
            try
            {
                string xmlPath = @"D:\Repositories\GitHub\InfragisticsDevProjects\InfragisticsDev.Win\LoadIS\ZoneLoadProps.xml";
                //XMLHelper.ToXML(xmlPath, CreateXMLStructure());
                if (File.Exists(xmlPath))
                {
                    textBox1.Text = File.ReadAllText(xmlPath);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private TemplateProperty CreateXMLStructure()
        {
            TemplateProperty template = new TemplateProperty()
            {
                SimModelClass = "SimTemplateOccupancyDriven",
                Type = "Default",
                SubType = "Default"
            };

            TemplateProperty zoneLoadsProp = new TemplateProperty()
            {
                PropertyName = "Loads",
                Category = "Loads",
                SimModelClass = "SimInternalLoad",
                Type = "Any",
                SubType = "Any",
                InstanceSpeciferPropName = "Loads",
                Properties = new List<ComponentProperty>()
                {
                    new TemplateProperty()
                    {
                    }
                }
            };

            return template;

        }

        private void btnOpenTemplatesView_Click(object sender, EventArgs e)
        {
            using (LoadIS.TemplatesForm templatesForm = new LoadIS.TemplatesForm())
            {
                templatesForm.ShowDialog(this);

            }
           
        }
    }
}
