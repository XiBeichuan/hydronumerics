﻿namespace HydroNumerics.HydroCat.Editor
{
    partial class HydroCatEditor
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
            this.parametersPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.runButton = new System.Windows.Forms.Button();
            this.timeSeriesPlot = new HydroNumerics.Time.Tools.TimeSeriesPlot();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeseriesPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parametersPropertyGrid
            // 
            this.parametersPropertyGrid.Location = new System.Drawing.Point(12, 27);
            this.parametersPropertyGrid.Name = "parametersPropertyGrid";
            this.parametersPropertyGrid.Size = new System.Drawing.Size(334, 541);
            this.parametersPropertyGrid.TabIndex = 0;
            this.parametersPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.parametersPropertyGrid_PropertyValueChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(27, 573);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // timeSeriesPlot
            // 
            this.timeSeriesPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeSeriesPlot.AutoSize = true;
            this.timeSeriesPlot.Location = new System.Drawing.Point(410, 27);
            this.timeSeriesPlot.Name = "timeSeriesPlot";
            this.timeSeriesPlot.Size = new System.Drawing.Size(289, 582);
            this.timeSeriesPlot.TabIndex = 2;
            this.timeSeriesPlot.TimeSeriesDataSet = null;
            this.timeSeriesPlot.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeseriesPropertiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // timeseriesPropertiesToolStripMenuItem
            // 
            this.timeseriesPropertiesToolStripMenuItem.Name = "timeseriesPropertiesToolStripMenuItem";
            this.timeseriesPropertiesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.timeseriesPropertiesToolStripMenuItem.Text = "Timeseries properties...";
            this.timeseriesPropertiesToolStripMenuItem.Click += new System.EventHandler(this.timeseriesPropertiesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotItemsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // plotItemsToolStripMenuItem
            // 
            this.plotItemsToolStripMenuItem.Name = "plotItemsToolStripMenuItem";
            this.plotItemsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.plotItemsToolStripMenuItem.Text = "Hide or show curves";
            this.plotItemsToolStripMenuItem.Click += new System.EventHandler(this.plotItemsToolStripMenuItem_Click);
            // 
            // HydroCatEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(699, 651);
            this.Controls.Add(this.timeSeriesPlot);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.parametersPropertyGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HydroCatEditor";
            this.Text = "HydroCatEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid parametersPropertyGrid;
        private System.Windows.Forms.Button runButton;
        private HydroNumerics.Time.Tools.TimeSeriesPlot timeSeriesPlot;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeseriesPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotItemsToolStripMenuItem;
    }
}