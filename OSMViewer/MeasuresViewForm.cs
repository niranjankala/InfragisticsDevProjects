﻿using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
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
            //CreateMeasuresFolderStructure();
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
                        //SimulationMeasureType measureType = SimulationMeasureType.None;
                        //foreach (var item in m.attributes)
                        //{
                        //    if (item?.name == "Measure Type" && Enum.TryParse<SimulationMeasureType>(item.value, out measureType))
                        //    {
                        //        m.MeasureType = measureType;
                        //        break;
                        //    }
                        //}
                        measures.Add(m);
                    }
                }


                List<SimulationMeasure> simulationMeasures = new List<SimulationMeasure>();
                foreach (Term term in result.term)
                {
                    SimulationMeasure measureCategory = new SimulationMeasure();
                    measureCategory.Name = term.name;
                    measureCategory.Description = term.description;
                    simulationMeasures.Add(measureCategory);

                    if (term.term?.Count > 0)
                    {
                        measureCategory.Measures = new List<SimulationMeasure>();
                        foreach (Term childTerm in term.term)
                        {
                            SimulationMeasure childCategory = new SimulationMeasure();
                            childCategory.Name = childTerm.name;
                            childCategory.Description = childTerm.description;
                            measureCategory.Measures.Add(childCategory);
                            string measureTag = string.Format("{0}.{1}", term.name, childTerm.name);
                            List<measure> termMeasures = measures.Where(m => m.tags.tag == measureTag).ToList();
                            if (termMeasures?.Count > 0)
                            {
                                childCategory.Measures = new List<SimulationMeasure>();
                                foreach (measure simMeausre in termMeasures)
                                {
                                    SimulationMeasure termMeasure = new SimulationMeasure();
                                    termMeasure.Name = simMeausre.name;
                                    termMeasure.Description = simMeausre.description;
                                    SimulationMeasureType measureType = SimulationMeasureType.None;
                                    foreach (var item in simMeausre.attributes)
                                    {
                                        if (item?.name == "Measure Type" && Enum.TryParse<SimulationMeasureType>(item.value, out measureType))
                                        {
                                            termMeasure.Type = measureType;
                                            break;
                                        }
                                    }
                                    childCategory.Measures.Add(termMeasure);
                                }
                            }
                        }
                    }
                }

                measuresTreeView.DataSource = simulationMeasures;
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

        private void measuresTreeView_BeforeDataNodesCollectionPopulated(object sender, Infragistics.Win.UltraWinTree.BeforeDataNodesCollectionPopulatedEventArgs e)
        {

        }

        private void measuresTreeView_InitializeDataNode(object sender, Infragistics.Win.UltraWinTree.InitializeDataNodeEventArgs e)
        {
            //if (e.Node.Nodes.Count == 0)
            //    e.Node.Visible = false;
        }

        private void measuresTreeView_AfterDataNodesCollectionPopulated(object sender, Infragistics.Win.UltraWinTree.AfterDataNodesCollectionPopulatedEventArgs e)
        {

        }

        private void measuresTreeView_ColumnSetGenerated(object sender, Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventArgs e)
        {
            foreach (var item in e.ColumnSet.Columns)
            {
                if (item.Key != "Name" && !item.DataType.IsGenericType)
                    item.Visible = false;
            }

        }

        private void MeasuresViewForm_Load(object sender, EventArgs e)
        {
            CreateMeasuresFolderStructure();
        }

        private void ucmdNewConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                UltraDataRow configRow;
                configRow = this.udsSimulationGroupList.Rows.Add();
                configRow["Configuration"] = "Config-1";
                UltraDataRow measureRow = configRow.GetChildRows("ZONE").Add();
                measureRow["Configuration"] = "Measure-1";
                UltraDataRow simRunRow = measureRow.GetChildRows("SIMRUN").Add();
                simRunRow["Configuration"] = "SimRun-1";

                this.ugSimulationgropus.DataSource = this.udsSimulationGroupList;               
               
            }
            catch (Exception ex)
            {
                if (this.ParentForm != null)
                {
                   
                        MessageBox.Show(ex.Message);
                    
                }
            }
        }

        private void ugSimulationgropus_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {           
            e.Layout.Bands[1].Columns["Delete Row"].Width = 20;
            e.Layout.Bands[1].Columns["Change Measure Order"].Width = 20;
            
        }

        private void btnAddMeasure_Click(object sender, EventArgs e)
        {
            //if (this.measuresTreeView.SelectedNodes
            UltraGridRow parentGridRow = null;
            UltraGridRow childGridRow = null;


            

            if (this.ugSimulationgropus.ActiveRow != null)
            {
                parentGridRow = (UltraGridRow)ugSimulationgropus.ActiveRow;
            }

            if (parentGridRow != null && parentGridRow.Band.Key == "ZONE")
            {
                childGridRow = parentGridRow;
                parentGridRow = parentGridRow.ParentRow;
            }

            if (parentGridRow == null && this.ugSimulationgropus.Rows.Count == 1)
            {
                this.ugSimulationgropus.ActiveRow = ugSimulationgropus.Rows[0];
                parentGridRow = (UltraGridRow)ugSimulationgropus.Rows[0];
            }

            if (parentGridRow != null && (parentGridRow.Band.Index == 0 || parentGridRow.Band.Index == 1) &&
                                   parentGridRow.Band.Key != "ZONE")
            {

            }
               
        }
    }
}
