namespace InfragisticsDev.Win
{
    partial class ApplicationEvents
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
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode1 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode2 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode3 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode4 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode5 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            Infragistics.Win.UltraWinTree.UltraTreeNode ultraTreeNode6 = new Infragistics.Win.UltraWinTree.UltraTreeNode();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.treeViewExamples = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewExamples)).BeginInit();
            this.ultraPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(800, 41);
            this.ultraPanel1.TabIndex = 0;
            // 
            // ultraPanel2
            // 
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 413);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(800, 37);
            this.ultraPanel2.TabIndex = 1;
            // 
            // treeViewExamples
            // 
            this.treeViewExamples.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewExamples.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treeViewExamples.Location = new System.Drawing.Point(0, 41);
            this.treeViewExamples.Name = "treeViewExamples";
            this.treeViewExamples.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            ultraTreeNode4.Key = "GridHybridColumnsLayout";
            ultraTreeNode4.Tag = "Demonstrate that how to arrange grid group and non Group columns";
            ultraTreeNode4.Text = "Group and Non-Group Column Position";
            ultraTreeNode3.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode4});
            ultraTreeNode3.Text = "Group Layout";
            ultraTreeNode2.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode3});
            ultraTreeNode2.Text = "Layout";
            ultraTreeNode1.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode2});
            ultraTreeNode1.Text = "Grid";
            ultraTreeNode5.Text = "Tree";
            ultraTreeNode6.Text = "Misc";
            this.treeViewExamples.Nodes.AddRange(new Infragistics.Win.UltraWinTree.UltraTreeNode[] {
            ultraTreeNode1,
            ultraTreeNode5,
            ultraTreeNode6});
            this.treeViewExamples.Size = new System.Drawing.Size(261, 372);
            this.treeViewExamples.TabIndex = 2;
            this.treeViewExamples.DoubleClick += new System.EventHandler(this.treeViewExamples_DoubleClick);
            // 
            // ultraPanel3
            // 
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(261, 41);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(539, 372);
            this.ultraPanel3.TabIndex = 3;
            // 
            // ApplicationEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this.treeViewExamples);
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.Name = "ApplicationEvents";
            this.Text = "Controls examples viewer";
            this.Load += new System.EventHandler(this.ApplicationEvents_Load);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewExamples)).EndInit();
            this.ultraPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.UltraWinTree.UltraTree treeViewExamples;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
    }
}

