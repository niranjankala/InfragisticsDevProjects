﻿namespace InfragisticsDev.Win
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenTemplatesView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(800, 414);
            this.textBox1.TabIndex = 0;
            // 
            // btnOpenTemplatesView
            // 
            this.btnOpenTemplatesView.Location = new System.Drawing.Point(12, 420);
            this.btnOpenTemplatesView.Name = "btnOpenTemplatesView";
            this.btnOpenTemplatesView.Size = new System.Drawing.Size(129, 23);
            this.btnOpenTemplatesView.TabIndex = 1;
            this.btnOpenTemplatesView.Text = "Open Tempates View";
            this.btnOpenTemplatesView.UseVisualStyleBackColor = true;
            this.btnOpenTemplatesView.Click += new System.EventHandler(this.btnOpenTemplatesView_Click);
            // 
            // ApplicationEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenTemplatesView);
            this.Controls.Add(this.textBox1);
            this.Name = "ApplicationEvents";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ApplicationEvents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenTemplatesView;
    }
}

