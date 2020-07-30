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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

		private void Form2_Load(object sender, System.EventArgs e)
		{
			DataTable dt = new DataTable("Table1");
			dt.Columns.Add("Col1", typeof(string));
			dt.Columns.Add("Col2", typeof(string));
			dt.Columns.Add("Col3", typeof(string));
			dt.Columns.Add("Col4", typeof(string));
			dt.Columns.Add("Col5", typeof(string));

			Random random = new Random();
			for (int i = 0; i < 100; i++)
			{
				string[] rowData = new string[5];
				for (int j = 0; j < 5; j++)
					rowData[j] = random.Next(1000).ToString();

				dt.Rows.Add(rowData);
			}

			this.ultraGrid1.DataSource = dt;

			// Get the columns of Table1 band in the UltraGrid.
			ColumnsCollection gridColumns = this.ultraGrid1.DisplayLayout.Bands["Table1"].Columns;

			// Turn on the row layout functionality for Table1 band.
			this.ultraGrid1.DisplayLayout.Bands["Table1"].UseRowLayout = true;

			// Allow the user to only resize width of the columns/labels.
			this.ultraGrid1.DisplayLayout.Bands["Table1"].Override.AllowRowLayoutCellSizing = RowLayoutSizing.Horizontal;
			this.ultraGrid1.DisplayLayout.Bands["Table1"].Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Horizontal;

			// Setup Col1 column.
			gridColumns["Col1"].RowLayoutColumnInfo.OriginX = 0;
			gridColumns["Col1"].RowLayoutColumnInfo.OriginY = 0;
			gridColumns["Col1"].RowLayoutColumnInfo.SpanX = 1;
			gridColumns["Col1"].RowLayoutColumnInfo.SpanY = 1;
			// Set the preferred cell size to 200,0 so that it's at least 200 pixel wide.
			// Height of 0 means that the UltraGrid will calculate one based on the font.
			gridColumns["Col1"].RowLayoutColumnInfo.PreferredCellSize = new Size(200, 0);
			// Set the MinimumCellSize to 50,0 to prevent the user from resizing the column
			// and making it smaller than 50 in width.
			gridColumns["Col1"].RowLayoutColumnInfo.MinimumCellSize = new Size(50, 0);

			// Setup Col2 column.
			gridColumns["Col2"].RowLayoutColumnInfo.OriginX = 1;
			gridColumns["Col2"].RowLayoutColumnInfo.OriginY = 0;
			gridColumns["Col2"].RowLayoutColumnInfo.SpanX = 1;
			gridColumns["Col2"].RowLayoutColumnInfo.SpanY = 1;

			// Setup Col3 column.
			gridColumns["Col3"].RowLayoutColumnInfo.OriginX = 0;
			gridColumns["Col3"].RowLayoutColumnInfo.OriginY = 1;
			gridColumns["Col3"].RowLayoutColumnInfo.SpanX = 1;
			gridColumns["Col3"].RowLayoutColumnInfo.SpanY = 1;

			// Setup Col4 column.
			gridColumns["Col4"].RowLayoutColumnInfo.OriginX = 1;
			gridColumns["Col4"].RowLayoutColumnInfo.OriginY = 1;
			gridColumns["Col4"].RowLayoutColumnInfo.SpanX = 1;
			gridColumns["Col4"].RowLayoutColumnInfo.SpanY = 1;
			// Set the preferred cell size to 150,0 so that it's at least 150 pixel wide.
			// Height of 0 means that the UltraGrid will calculate one based on the font.
			gridColumns["Col4"].RowLayoutColumnInfo.PreferredCellSize = new Size(150, 0);
			// Set the MinimumCellSize to 50,0 to prevent the user from resizing the column
			// and making it smaller than 50 in width.
			gridColumns["Col4"].RowLayoutColumnInfo.MinimumCellSize = new Size(60, 0);

			// Setup Col5 column.
			gridColumns["Col5"].RowLayoutColumnInfo.OriginX = 0;
			gridColumns["Col5"].RowLayoutColumnInfo.OriginY = 2;
			// Set the SpanX to Remainder so that it occupies the rest of the horizontal space.
			gridColumns["Col5"].RowLayoutColumnInfo.SpanX = RowLayoutColumnInfo.Remainder;
			gridColumns["Col5"].RowLayoutColumnInfo.SpanY = 1;
			// Set the preferred cell size height to 40.
			gridColumns["Col5"].RowLayoutColumnInfo.PreferredCellSize = new Size(0, 40);
			gridColumns["Col5"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
		}
	}
}
