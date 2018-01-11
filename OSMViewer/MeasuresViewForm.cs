using Newtonsoft.Json;
using Simergy.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenStudioMeasuresViewer
{
    public partial class MeasuresViewForm : Form
    {
        public MeasuresViewForm()
        {
            InitializeComponent();
            ApplicationManager.Instance.CopyConfigFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateMeasuresFolderStructure();
        }

        public void CreateMeasuresFolderStructure()
        {
            string measureFolder = ApplicationManager.Instance.GetMeasuresFolder();
            string aa = "http://bcl.nrel.gov/api/taxonomy/measure";
            taxonomy result = DownloadAndDeserializeJsonData<taxonomy>(aa);
            if (result != null)
            {
                IEnumerable<string> measureFiles = Directory.EnumerateFiles(measureFolder, "measure.xml", SearchOption.AllDirectories);
                List<measure> measures = new List<measure>();
                foreach (string measureFilePath in measureFiles)
                {
                    measure m = null;
                    try
                    {
                        m = XMLHelper.Deserialize<measure>(File.ReadAllText(measureFilePath));
                    }
                    catch (Exception ex)
                    {                        
                    }
                    if (m != null)
                    {
                        SimulationMeasureType measureType = SimulationMeasureType.None;
                        foreach (var item in m.attributes)
                        {
                            if (item?.name == "Measure Type" && Enum.TryParse<SimulationMeasureType>(item.value, out measureType))
                            {
                                m.MeasureType = measureType;
                                break;
                            }
                        }
                        measures.Add(m); 
                    }
                }



                foreach (Term term in result.term)
                {
                    foreach (Term childTerm in term.term)
                    {
                        string measureTag = string.Format("{0}.{1}", term.name, childTerm.name);

                        List<measure> termMeasures = measures.Where(m => m.tags.tag == measureTag).ToList();
                        childTerm.Measures = termMeasures;

                    }
                }

                ultraTree1.DataSource = result.term;
            }
        }

        private static T DownloadAndDeserializeJsonData<T>(string url) where T : new()
        {
            using (var webClient = new WebClient())
            {
                var jsonData = string.Empty;
                try
                {
                    jsonData = webClient.DownloadString(url);
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(jsonData)
                           ? JsonConvert.DeserializeObject<T>(jsonData)
                           : new T();
            }
        }

        private void ultraTree1_Layout(object sender, LayoutEventArgs e)
        {

        }
    }
}
