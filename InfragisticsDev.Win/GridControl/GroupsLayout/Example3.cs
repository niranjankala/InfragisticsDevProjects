using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfragisticsDev.Win.GridControl.GroupsLayout
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ugvExProps.InitializeLayout += UgvExProps_InitializeLayout;
            //DataRow dataRow = this.groupLayoutDataSet.ZoneExProps.Rows.Add();
            this.groupLayoutDataSet.ZoneExProps.AddZoneExPropsRow("Space-1", "Bldg-Story-1", "123.3", "123.4", "", "", "", "", "", "Zone HVAC Group-1", "...", "", "", "", "", "Thermal Zone 1-1", "...", "...", "...", "...", "...", "...", "...", "...", "...", "...")
            ;
        }

        private void UgvExProps_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.UseFixedHeaders = true;
            //e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            //e.Layout.Override.AllowColSizing = AllowColSizing.Free;
            //e.Layout.Override.DefaultColWidth = 150;

            //e.Layout.Appearance.BackColor = Color.White;

            //e.Layout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            foreach (UltraGridBand band in e.Layout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    if (char.IsDigit(column.Key.ToArray().Last()))
                    {
                        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                        column.Width = 30;
                        column.RowLayoutColumnInfo.PreferredCellSize = new Size(30,column.RowLayoutColumnInfo.PreferredCellSize.Height);
                        //column.RowLayoutColumnInfo.PreferredLabelSize = new Size(column.RowLayoutColumnInfo.PreferredLabelSize.Height, 30);
                    }
                }

            }
            //e.Layout.PerformAutoResizeColumns(true, PerformAutoSizeType.VisibleRows);
        }
    }
}
