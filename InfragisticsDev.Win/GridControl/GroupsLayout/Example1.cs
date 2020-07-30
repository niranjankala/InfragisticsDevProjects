using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace InfragisticsDev.Win.GridControl.GroupsLayout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable uds = new DataTable();
            

            uds.Columns.Add("A", typeof(string));
            uds.Columns.Add("B", typeof(string));
            uds.Columns.Add("C", typeof(string));
            uds.Columns.Add("D", typeof(string));
            uds.Columns.Add("E", typeof(string));
            uds.Columns.Add("F", typeof(string));
            uds.Columns.Add("G", typeof(string));
            uds.Columns.Add("H", typeof(string));
            uds.Columns.Add("I", typeof(string));
            uds.Columns.Add("J", typeof(string));
            uds.Columns.Add("K", typeof(string));
            DataRow row;
            row = uds.Rows.Add(new object[] { "Test A","Test B","Test C","Test D","Test E","Test F","Test G","Test H","Test I","Test J","Test K"});
            row = uds.Rows.Add(new object[] { "Test A1", "Test B1", "Test C1", "Test D1", "Test E1", "Test F1", "Test G1", "Test H1", "Test I1", "Test J1", "Test K1" });
            row = uds.Rows.Add(new object[] { "Test A2", "Test B2", "Test C2", "Test D2", "Test E2", "Test F2", "Test G2", "Test H2", "Test I2", "Test J2", "Test K2" });
            this.ultraGrid1.DataSource = uds;
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //Create the groups
            UltraGridGroup accountGroup = e.Layout.Bands[0].Groups.Add("Account", "Account");
            UltraGridGroup contraGroup = e.Layout.Bands[0].Groups.Add("ContraAccount", "Contra account");
            UltraGridGroup contraBill = e.Layout.Bands[0].Groups.Add("ContraBill", "Billing account");
            UltraGridGroup contraNom = e.Layout.Bands[0].Groups.Add("ContraNom", "Nominal account");


            // Set the parent Group
            contraBill.RowLayoutGroupInfo.ParentGroup = contraGroup;
            contraNom.RowLayoutGroupInfo.ParentGroup = contraGroup;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                //Set the Group for each columns
                switch (col.Key)
                {
                    case "A":
                    case "B":
                    case "C":
                        ultraGrid1.DisplayLayout.Bands[0].Columns[col.Key].RowLayoutColumnInfo.ParentGroup = accountGroup;
                        break;

                    case "D":
                    case "E":
                    case "F":
                        ultraGrid1.DisplayLayout.Bands[0].Columns[col.Key].RowLayoutColumnInfo.ParentGroup = contraBill;
                        break;


                    case "G":
                    case "H":
                    case "I":
                    case "J":
                    case "K":
                        ultraGrid1.DisplayLayout.Bands[0].Columns[col.Key].RowLayoutColumnInfo.ParentGroup = contraNom;
                        break;
                }
            }
            // This property is important, because determinate that we are using groups
            ultraGrid1.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;

        }
    }
}
