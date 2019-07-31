namespace PointLayoutGenerator
{
    partial class Generator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.layoutOptionsBox = new System.Windows.Forms.ComboBox();
            this.numPointsCircle = new System.Windows.Forms.NumericUpDown();
            this.numPointsRectangle = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.coordBox = new System.Windows.Forms.RichTextBox();
            this.stratLabel = new System.Windows.Forms.Label();
            this.numPointsLabel = new System.Windows.Forms.Label();
            this.dieHeightInput = new System.Windows.Forms.NumericUpDown();
            this.dieWidthInput = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.dieVisualizer = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsRectangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieHeightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieVisualizer)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutOptionsBox
            // 
            this.layoutOptionsBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.layoutOptionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutOptionsBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.layoutOptionsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutOptionsBox.FormattingEnabled = true;
            this.layoutOptionsBox.Location = new System.Drawing.Point(168, 6);
            this.layoutOptionsBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutOptionsBox.Name = "layoutOptionsBox";
            this.layoutOptionsBox.Size = new System.Drawing.Size(160, 28);
            this.layoutOptionsBox.TabIndex = 0;
            this.layoutOptionsBox.SelectedIndexChanged += new System.EventHandler(this.LayoutOptionsBox_SelectedIndexChanged);
            // 
            // numPointsCircle
            // 
            this.numPointsCircle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numPointsCircle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPointsCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPointsCircle.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPointsCircle.Location = new System.Drawing.Point(168, 42);
            this.numPointsCircle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPointsCircle.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.numPointsCircle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPointsCircle.Name = "numPointsCircle";
            this.numPointsCircle.Size = new System.Drawing.Size(160, 26);
            this.numPointsCircle.TabIndex = 1;
            this.numPointsCircle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPointsCircle.ValueChanged += new System.EventHandler(this.NumPointsCircle_ValueChanged);
            // 
            // numPointsRectangle
            // 
            this.numPointsRectangle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numPointsRectangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPointsRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPointsRectangle.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPointsRectangle.Location = new System.Drawing.Point(168, 42);
            this.numPointsRectangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPointsRectangle.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.numPointsRectangle.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPointsRectangle.Name = "numPointsRectangle";
            this.numPointsRectangle.Size = new System.Drawing.Size(160, 26);
            this.numPointsRectangle.TabIndex = 2;
            this.numPointsRectangle.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPointsRectangle.ValueChanged += new System.EventHandler(this.NumPointsRectangle_ValueChanged);
            // 
            // generateButton
            // 
            this.generateButton.AutoSize = true;
            this.generateButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(61, 93);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(221, 30);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate Inspection Points";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // coordBox
            // 
            this.coordBox.Location = new System.Drawing.Point(12, 146);
            this.coordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.coordBox.Name = "coordBox";
            this.coordBox.Size = new System.Drawing.Size(591, 563);
            this.coordBox.TabIndex = 4;
            this.coordBox.Text = "";
            // 
            // stratLabel
            // 
            this.stratLabel.AutoSize = true;
            this.stratLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stratLabel.Location = new System.Drawing.Point(12, 9);
            this.stratLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stratLabel.Name = "stratLabel";
            this.stratLabel.Size = new System.Drawing.Size(126, 20);
            this.stratLabel.TabIndex = 5;
            this.stratLabel.Text = "Layout Strategy";
            // 
            // numPointsLabel
            // 
            this.numPointsLabel.AutoSize = true;
            this.numPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPointsLabel.Location = new System.Drawing.Point(7, 45);
            this.numPointsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numPointsLabel.Name = "numPointsLabel";
            this.numPointsLabel.Size = new System.Drawing.Size(139, 20);
            this.numPointsLabel.TabIndex = 6;
            this.numPointsLabel.Text = "Number of Points";
            // 
            // dieHeightInput
            // 
            this.dieHeightInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieHeightInput.Location = new System.Drawing.Point(558, 45);
            this.dieHeightInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dieHeightInput.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.dieHeightInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dieHeightInput.Name = "dieHeightInput";
            this.dieHeightInput.Size = new System.Drawing.Size(66, 26);
            this.dieHeightInput.TabIndex = 7;
            this.dieHeightInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.dieHeightInput.ValueChanged += new System.EventHandler(this.DieHeightInput_ValueChanged);
            // 
            // dieWidthInput
            // 
            this.dieWidthInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieWidthInput.Location = new System.Drawing.Point(558, 12);
            this.dieWidthInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dieWidthInput.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.dieWidthInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dieWidthInput.Name = "dieWidthInput";
            this.dieWidthInput.Size = new System.Drawing.Size(66, 26);
            this.dieWidthInput.TabIndex = 8;
            this.dieWidthInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.dieWidthInput.ValueChanged += new System.EventHandler(this.DieWidthInput_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthLabel.Location = new System.Drawing.Point(455, 14);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(83, 20);
            this.widthLabel.TabIndex = 9;
            this.widthLabel.Text = "Die Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightLabel.Location = new System.Drawing.Point(455, 48);
            this.heightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(89, 20);
            this.heightLabel.TabIndex = 10;
            this.heightLabel.Text = "Die Height";
            // 
            // dieVisualizer
            // 
            this.dieVisualizer.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.dieVisualizer.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Center Points";
            this.dieVisualizer.Legends.Add(legend2);
            this.dieVisualizer.Location = new System.Drawing.Point(630, 12);
            this.dieVisualizer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dieVisualizer.Name = "dieVisualizer";
            series3.BorderColor = System.Drawing.Color.Transparent;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.DarkBlue;
            series3.Legend = "Center Points";
            series3.Name = "centers";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.Gold;
            series4.Legend = "Center Points";
            series4.Name = "inspected";
            this.dieVisualizer.Series.Add(series3);
            this.dieVisualizer.Series.Add(series4);
            this.dieVisualizer.Size = new System.Drawing.Size(700, 700);
            this.dieVisualizer.TabIndex = 11;
            this.dieVisualizer.Text = "Die Grid";
            title2.Alignment = System.Drawing.ContentAlignment.TopRight;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Wafer Visualization";
            this.dieVisualizer.Titles.Add(title2);
            // 
            // plotButton
            // 
            this.plotButton.AutoSize = true;
            this.plotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotButton.Location = new System.Drawing.Point(348, 93);
            this.plotButton.Name = "plotButton";
            this.plotButton.Size = new System.Drawing.Size(221, 30);
            this.plotButton.TabIndex = 12;
            this.plotButton.Text = "Plot Wafer";
            this.plotButton.UseVisualStyleBackColor = true;
            this.plotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1342, 721);
            this.Controls.Add(this.plotButton);
            this.Controls.Add(this.dieVisualizer);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.dieWidthInput);
            this.Controls.Add(this.dieHeightInput);
            this.Controls.Add(this.numPointsLabel);
            this.Controls.Add(this.stratLabel);
            this.Controls.Add(this.coordBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.numPointsRectangle);
            this.Controls.Add(this.numPointsCircle);
            this.Controls.Add(this.layoutOptionsBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Generator";
            this.Text = "Inspection Point Layout Generator";
            this.Load += new System.EventHandler(this.Generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPointsCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsRectangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieHeightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dieVisualizer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox layoutOptionsBox;
        private System.Windows.Forms.NumericUpDown numPointsCircle;
        private System.Windows.Forms.NumericUpDown numPointsRectangle;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.RichTextBox coordBox;
        private System.Windows.Forms.Label stratLabel;
        private System.Windows.Forms.Label numPointsLabel;
        private System.Windows.Forms.NumericUpDown dieHeightInput;
        private System.Windows.Forms.NumericUpDown dieWidthInput;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart dieVisualizer;
        private System.Windows.Forms.Button plotButton;
    }
}

