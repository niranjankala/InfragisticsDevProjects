using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
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

        private T DownloadAndDeserializeJsonData<T>(string url) where T : new()
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

        private void measuresTreeView_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void measuresTreeView_BeforeDataNodesCollectionPopulated(object sender, Infragistics.Win.UltraWinTree.BeforeDataNodesCollectionPopulatedEventArgs e)
        {

        }

        private void measuresTreeView_InitializeDataNode(object sender, Infragistics.Win.UltraWinTree.InitializeDataNodeEventArgs e)
        {
            //if (e.Node.Nodes.Count == 0)
            //    e.Node.Visible = false;   
            SimulationMeasure measure = e.Node.ListObject as SimulationMeasure;
            if (e.Node.IsRootLevelNode)
            {
                e.Node.Override.NodeAppearance.BackColor = Color.Gray;
                e.Node.Override.NodeAppearance.ForeColor = Color.White;
                e.Node.Override.NodeAppearance.BorderColor = Color.Black;
                e.Node.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                e.Node.Override.BorderStyleNode = Infragistics.Win.UIElementBorderStyle.Solid;
                if (measure?.Measures != null)
                {
                    int count = measure.Measures.Select(m => m.Measures == null ? new List<SimulationMeasure>() : m.Measures).Count();

                    if (!e.Reinitialize)
                        e.Node.Text = string.Format("{0} ({1})", e.Node.Text, count);

                }
            }
            else
            {
                switch (e.Node.Level)
                {
                    case 1:
                        {
                            e.Node.Override.NodeAppearance.BackColor = Color.LightGray;
                            e.Node.Override.NodeAppearance.ForeColor = Color.Black;
                            e.Node.Override.NodeAppearance.BorderColor = Color.Gray;
                            e.Node.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            e.Node.Override.BorderStyleNode = Infragistics.Win.UIElementBorderStyle.Solid;
                        }
                        break;

                    case 2:
                        {
                            if (measure != null)
                            {
                                Color color = e.Node.Override.NodeAppearance.BackColor;
                                if (measure.Type == SimulationMeasureType.ModelMeasure)
                                    color = Color.FromArgb(200, 214, 230);

                                if (measure.Type == SimulationMeasureType.EnergyPlusMeasure)
                                    color = Color.FromArgb(202, 218, 169);

                                if (measure.Type == SimulationMeasureType.ReportingMeasure)
                                    color = Color.FromArgb(206, 149, 139);

                                e.Node.Override.NodeAppearance.BackColor = color;
                                // e.Node.Override.NodeAppearance.ForeColor = Color.White;
                                e.Node.Override.NodeAppearance.BorderColor = Color.Black;
                                e.Node.Override.BorderStyleNode = Infragistics.Win.UIElementBorderStyle.Solid;
                                e.Node.LeftImagesAlignment = Infragistics.Win.VAlign.Default;
                                if (measure.Type == SimulationMeasureType.ReportingMeasure)
                                {
                                    e.Node.LeftImages.Add(Properties.Resources.rm32x32);
                                }

                                if (measure.Type == SimulationMeasureType.EnergyPlusMeasure)
                                {
                                    e.Node.LeftImages.Add(Properties.Resources.em32x32);
                                }
                                if (measure.Type == SimulationMeasureType.ModelMeasure)
                                {
                                    e.Node.LeftImages.Add(Properties.Resources.mm32x32);
                                }

                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void measuresTreeView_AfterDataNodesCollectionPopulated(object sender, Infragistics.Win.UltraWinTree.AfterDataNodesCollectionPopulatedEventArgs e)
        {


        }

        private void measuresTreeView_ColumnSetGenerated(object sender, Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventArgs e)
        {
            e.ColumnSet.NodeTextColumn = e.ColumnSet.Columns["Name"];
            foreach (var column in e.ColumnSet.Columns)
            {
                if (column.Key != "Name" && !column.DataType.IsGenericType)
                    column.Visible = false;
                column.LayoutInfo.PreferredCellSize = new Size(0, measuresTreeView.Override.ItemHeight);

            }
            //e.ColumnSet.Columns["Type"].Visible = true;
            //e.ColumnSet.Columns["Type"].LayoutInfo.OriginX = 0;
            //for (int i = 0; i < e.ColumnSet.Columns["Type"].Index; i++)
            //{
            //    if (e.ColumnSet.Columns[i].Visible)
            //        e.ColumnSet.Columns[i].LayoutInfo.OriginX = i + 2;
            //}


            //e.ColumnSet.AllowCellSizing = LayoutSizing.Both;


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
                //UltraDataRow simRunRow = measureRow.GetChildRows("SIMRUN").Add();
                //simRunRow["Configuration"] = "SimRun-1";

                //this.ugSimulationgropus.DataSource = this.udsSimulationGroupList;


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
            e.Layout.Override.AllowColSizing = AllowColSizing.Free;
            e.Layout.Override.DefaultRowHeight = 23;
            e.Layout.Bands[1].RowLayoutStyle = RowLayoutStyle.ColumnLayout;
            e.Layout.Bands[1].Columns["Delete Row"].Hidden = false;
            e.Layout.Bands[1].Columns["Change Measure Order"].Hidden = false;

            e.Layout.Bands[1].Override.RowAppearance.BackColor = Color.LightBlue;


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
                if (measuresTreeView.SelectedNodes?.Count > 0)
                {
                    List<SimulationMeasure> selectedMeasures = new List<SimulationMeasure>();
                    foreach (UltraTreeNode measureNode in measuresTreeView.SelectedNodes)
                    {
                        SimulationMeasure measure = measureNode.ListObject as SimulationMeasure;
                        if (measureNode.Level == 2)
                        {
                            UltraDataRow dr = parentGridRow.ListObject as UltraDataRow;
                            UltraDataRowsCollection rowsList = dr.GetChildRows("ZONE");
                            bool isMeasureExists = false;
                            foreach (UltraDataRow row in rowsList)
                            {
                                if (measure.Name == Convert.ToString(row["Configuration"]))
                                {
                                    isMeasureExists = true;
                                    break;
                                }
                            }
                            if (!isMeasureExists)
                            {
                                UltraDataRow measureRow = rowsList.Add(new object[] { measure.Name });
                            }
                            else
                            {
                                MessageBox.Show("Measure already exists");
                            }

                        }
                    }
                }
            }

        }

        private void measuresTreeView_AfterSelect(object sender, SelectEventArgs e)
        {

        }

        private void ugSimulationgropus_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Change Measure Order" && e.Cell.Row.Index > 0)
            {
                ugSimulationgropus.SuspendLayout();
                ugSimulationgropus.Rows.Move(e.Cell.Row.ParentRow, e.Cell.Row.Index - 1);

                ugSimulationgropus.ResumeLayout();
            }

        }

        private void measuresTreeView_SelectionDragStart(object sender, EventArgs e)
        {
            List<SimulationMeasure> selectedMeasures = GetSelectedMeasures();
            DoDragDrop(selectedMeasures, DragDropEffects.Link);

        }

        void ugSimulationgropus_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data != null)
            {
                // Try to get the grid row 
                UltraGridRow newParentRow = GetGridRowFromCoordinates(ugSimulationgropus.PointToClient(new Point(e.X, e.Y)), ugSimulationgropus);
                // If a row was found display the band and row index
                if (newParentRow != null)
                {
                    if (newParentRow.Band.Index != 0)
                    {
                        if (this.ParentForm != null)
                        {
                           
                                MessageBox.Show("Please drop on a simulation configuration");
                            
                        }
                    }
                    if (isDragInternal)
                    {
                    }
                    else
                    {
                        //                     
                        List<SimulationMeasure> selectedMeasures = (List<SimulationMeasure>)e.Data.GetData(typeof(List<SimulationMeasure>));
                        if (selectedMeasures != null)
                        {
                            if (selectedMeasures.Count > 0)
                            {                                
                                AddMeasuresToConfiguration(selectedMeasures);
                            }
                        }
                        //this.ugSimulationgropus.Rows.CollapseAll(true);
                        //this.ugSimulationgropus.Rows[index].Expanded = true;
                        //LoadSimulationTable(this, modelPlayer);
                        //PopulateAndConfigureTemplateControls();
                    }
                }
            }
        }

        void ugSimulationgropus_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!isDragInternal)
            {
                if (e.Data == null)
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.None;
                }
                else
                {                   
                    List<SimulationMeasure> selectedMeasures = (List<SimulationMeasure>)e.Data.GetData(typeof(List<SimulationMeasure>));
                    if (selectedMeasures != null)
                    {
                        if (selectedMeasures.Count > 0)
                        {
                            foreach (SimulationMeasure measure in selectedMeasures)
                            {
                                if (measure.Type != SimulationMeasureType.None)
                                {
                                    e.Effect = DragDropEffects.Link;
                                }
                                else
                                {
                                    e.Effect = System.Windows.Forms.DragDropEffects.None;
                                }
                            }
                        }
                        else
                        {
                            e.Effect = System.Windows.Forms.DragDropEffects.None;
                        }
                    }

                }
            }
            else
            {
                e.Effect = System.Windows.Forms.DragDropEffects.None;
                //e.Effect = DragDropEffects.Move;
            }

        }
        private bool isDragInternal = false;
        void ugSimulationgropus_SelectionDrag(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isDragInternal = true;
            if (ugSimulationgropus.ActiveRow.ListObject.GetType() != typeof(UltraDataRow)) return;
            ugSimulationgropus.DoDragDrop(ugSimulationgropus.Selected.Rows, DragDropEffects.Move);
            isDragInternal = false;
        }

        void ugSimulationgropus_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (isDragInternal)
            {
                e.Effect = DragDropEffects.Move;
                UltraGrid grid = sender as UltraGrid;
                Point pointInGridCoords = grid.PointToClient(new Point(e.X, e.Y));
                if (pointInGridCoords.Y < 20)
                    // Scroll up.
                    this.ugSimulationgropus.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp);
                else if (pointInGridCoords.Y > grid.Height - 20)
                    // Scroll down.
                    this.ugSimulationgropus.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown);
            }
        }

        public void AddMeasuresToConfiguration(List<SimulationMeasure> selectedMeasures)
        {
            //if (this.measuresTreeView.SelectedNodes
            UltraGridRow parentGridRow = null;
            UltraGridRow childGridRow = null;


            if (this.ugSimulationgropus.ActiveRow != null)
            {
                parentGridRow = (UltraGridRow)ugSimulationgropus.ActiveRow;
            }

            if (parentGridRow != null && parentGridRow.Band.Key == Constants.BAND_ZONE)
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
                                   parentGridRow.Band.Key != Constants.BAND_ZONE)
            {
                if (selectedMeasures?.Count > 0)
                {
                    foreach (SimulationMeasure measure in selectedMeasures)
                    {

                        UltraDataRow dr = parentGridRow.ListObject as UltraDataRow;
                        UltraDataRowsCollection rowsList = dr.GetChildRows(Constants.BAND_ZONE);
                        bool isMeasureExists = false;
                        foreach (UltraDataRow row in rowsList)
                        {
                            if (measure.Name == Convert.ToString(row[Constants.COLUMN_CONFIGURATION]))
                            {
                                isMeasureExists = true;
                                break;
                            }
                        }
                        if (!isMeasureExists)
                        {
                            if (rowsList.Count == 1 && Convert.ToString(rowsList[0][Constants.COLUMN_CONFIGURATION]) == Constants.TextNoMeasuresSelected)
                            {
                                rowsList.Clear();
                            }


                            UltraDataRow measureRow = rowsList.Add(new object[] { measure.Name });
                        }
                        else
                        {
                            MessageBox.Show("Measure already exists");
                        }

                    }

                }
            }
        }


        public UltraGridRow GetGridRowFromCoordinates(Point point, UltraGrid grid)
        {
            // Declare and retrieve a reference to the UIElement
            UIElement aUIElement = grid.DisplayLayout.UIElement.ElementFromPoint(point);

            // Declare and retrieve a reference to the Row
            var aRow = (UltraGridRow)aUIElement.GetContext(typeof(UltraGridRow));

            // Return the row - may be Nothing
            return aRow;
        }

        private List<SimulationMeasure> GetSelectedMeasures()
        {
            List<SimulationMeasure> selectedMeasures = new List<SimulationMeasure>();
            if (measuresTreeView.SelectedNodes?.Count > 0)
            {
                foreach (UltraTreeNode measureNode in measuresTreeView.SelectedNodes)
                {
                    SimulationMeasure measure = measureNode.ListObject as SimulationMeasure;
                    if (measureNode.Level == 2 && measure.Type != SimulationMeasureType.None)
                    {
                        selectedMeasures.Add(measure);
                    }
                }
            }
            return selectedMeasures;
        }
    }
}
