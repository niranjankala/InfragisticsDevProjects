namespace OpenStudioMeasuresViewer
{
    partial class MeasuresViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.measuresTreeView = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTreePrintDocument1 = new Infragistics.Win.UltraWinTree.UltraTreePrintDocument(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measuresTreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Measures";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 450);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 32);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.measuresTreeView);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 450);
            this.panel3.TabIndex = 4;
            // 
            // measuresTreeView
            // 
            this.measuresTreeView.ColumnSettings.AllowCellEdit = Infragistics.Win.UltraWinTree.AllowCellEdit.ReadOnly;
            this.measuresTreeView.ColumnSettings.AllowColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.measuresTreeView.ColumnSettings.AllowSorting = Infragistics.Win.DefaultableBoolean.False;
            this.measuresTreeView.ColumnSettings.AutoFitColumns = Infragistics.Win.UltraWinTree.AutoFitColumns.ResizeAllColumns;
            this.measuresTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuresTreeView.Location = new System.Drawing.Point(264, 0);
            this.measuresTreeView.Name = "measuresTreeView";
            this.measuresTreeView.Size = new System.Drawing.Size(460, 450);
            this.measuresTreeView.TabIndex = 5;
            this.measuresTreeView.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.OutlookExpress;
            this.measuresTreeView.InitializeDataNode += new Infragistics.Win.UltraWinTree.InitializeDataNodeEventHandler(this.measuresTreeView_InitializeDataNode);
            this.measuresTreeView.BeforeDataNodesCollectionPopulated += new Infragistics.Win.UltraWinTree.BeforeDataNodesCollectionPopulatedEventHandler(this.measuresTreeView_BeforeDataNodesCollectionPopulated);
            this.measuresTreeView.AfterDataNodesCollectionPopulated += new Infragistics.Win.UltraWinTree.AfterDataNodesCollectionPopulatedEventHandler(this.measuresTreeView_AfterDataNodesCollectionPopulated);
            this.measuresTreeView.ColumnSetGenerated += new Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventHandler(this.measuresTreeView_ColumnSetGenerated);
            // 
            // MeasuresViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 482);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "MeasuresViewForm";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.measuresTreeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.UltraWinTree.UltraTree measuresTreeView;
        private Infragistics.Win.UltraWinTree.UltraTreePrintDocument ultraTreePrintDocument1;
    }
}

