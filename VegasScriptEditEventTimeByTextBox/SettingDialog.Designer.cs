namespace VegasScriptEditEventTimeByTextBox
{
    partial class SettingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDialog));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.timeFormatGroup = new System.Windows.Forms.GroupBox();
            this.hmsfFormatLabel = new System.Windows.Forms.Label();
            this.hmsfFormat = new System.Windows.Forms.RadioButton();
            this.hmsmsFormatLabel = new System.Windows.Forms.Label();
            this.hmsmsFormat = new System.Windows.Forms.RadioButton();
            this.timeLengthBox = new System.Windows.Forms.TextBox();
            this.startTimeBox = new System.Windows.Forms.TextBox();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.canselButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            this.timeFormatGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.timeFormatGroup);
            this.mainPanel.Controls.Add(this.timeLengthBox);
            this.mainPanel.Controls.Add(this.startTimeBox);
            this.mainPanel.Controls.Add(this.LengthLabel);
            this.mainPanel.Controls.Add(this.startTimeLabel);
            this.mainPanel.Location = new System.Drawing.Point(2, 4);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(276, 104);
            this.mainPanel.TabIndex = 0;
            // 
            // timeFormatGroup
            // 
            this.timeFormatGroup.Controls.Add(this.hmsfFormatLabel);
            this.timeFormatGroup.Controls.Add(this.hmsfFormat);
            this.timeFormatGroup.Controls.Add(this.hmsmsFormatLabel);
            this.timeFormatGroup.Controls.Add(this.hmsmsFormat);
            this.timeFormatGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeFormatGroup.ForeColor = System.Drawing.Color.LemonChiffon;
            this.timeFormatGroup.Location = new System.Drawing.Point(3, 3);
            this.timeFormatGroup.Name = "timeFormatGroup";
            this.timeFormatGroup.Size = new System.Drawing.Size(267, 44);
            this.timeFormatGroup.TabIndex = 17;
            this.timeFormatGroup.TabStop = false;
            this.timeFormatGroup.Text = "書式";
            // 
            // hmsfFormatLabel
            // 
            this.hmsfFormatLabel.AutoSize = true;
            this.hmsfFormatLabel.ForeColor = System.Drawing.Color.White;
            this.hmsfFormatLabel.Location = new System.Drawing.Point(140, 16);
            this.hmsfFormatLabel.Name = "hmsfFormatLabel";
            this.hmsfFormatLabel.Size = new System.Drawing.Size(119, 17);
            this.hmsfFormatLabel.TabIndex = 19;
            this.hmsfFormatLabel.Text = "HH:MM:SS.FRAME";
            // 
            // hmsfFormat
            // 
            this.hmsfFormat.AutoSize = true;
            this.hmsfFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsfFormat.ForeColor = System.Drawing.Color.Black;
            this.hmsfFormat.Location = new System.Drawing.Point(125, 19);
            this.hmsfFormat.Name = "hmsfFormat";
            this.hmsfFormat.Size = new System.Drawing.Size(13, 12);
            this.hmsfFormat.TabIndex = 19;
            this.hmsfFormat.UseVisualStyleBackColor = true;
            this.hmsfFormat.CheckedChanged += new System.EventHandler(this.OnChangeFormatRadiobutton);
            // 
            // hmsmsFormatLabel
            // 
            this.hmsmsFormatLabel.AutoSize = true;
            this.hmsmsFormatLabel.ForeColor = System.Drawing.Color.White;
            this.hmsmsFormatLabel.Location = new System.Drawing.Point(21, 16);
            this.hmsmsFormatLabel.Name = "hmsmsFormatLabel";
            this.hmsmsFormatLabel.Size = new System.Drawing.Size(95, 17);
            this.hmsmsFormatLabel.TabIndex = 18;
            this.hmsmsFormatLabel.Text = "HH:MM:SS.MS";
            // 
            // hmsmsFormat
            // 
            this.hmsmsFormat.AutoSize = true;
            this.hmsmsFormat.Checked = true;
            this.hmsmsFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsmsFormat.ForeColor = System.Drawing.Color.Black;
            this.hmsmsFormat.Location = new System.Drawing.Point(6, 19);
            this.hmsmsFormat.Name = "hmsmsFormat";
            this.hmsmsFormat.Size = new System.Drawing.Size(13, 12);
            this.hmsmsFormat.TabIndex = 18;
            this.hmsmsFormat.TabStop = true;
            this.hmsmsFormat.UseVisualStyleBackColor = true;
            this.hmsmsFormat.CheckedChanged += new System.EventHandler(this.OnChangeFormatRadiobutton);
            // 
            // timeLengthBox
            // 
            this.timeLengthBox.Location = new System.Drawing.Point(119, 76);
            this.timeLengthBox.Name = "timeLengthBox";
            this.timeLengthBox.Size = new System.Drawing.Size(96, 25);
            this.timeLengthBox.TabIndex = 16;
            this.timeLengthBox.Text = "23:59:59.999";
            this.timeLengthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeLengthBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTimeFormatOnly);
            // 
            // startTimeBox
            // 
            this.startTimeBox.Location = new System.Drawing.Point(119, 50);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(96, 25);
            this.startTimeBox.TabIndex = 15;
            this.startTimeBox.Text = "23:59:59.999";
            this.startTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTimeBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTimeFormatOnly);
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(4, 79);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(92, 17);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "イベントの長さ";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(4, 50);
            this.startTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(116, 17);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "イベントの開始時間";
            // 
            // canselButton
            // 
            this.canselButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canselButton.BackgroundImage")));
            this.canselButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(311, 83);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(24, 24);
            this.canselButton.TabIndex = 10;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Location = new System.Drawing.Point(282, 83);
            this.OKButton.Margin = new System.Windows.Forms.Padding(8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(24, 24);
            this.OKButton.TabIndex = 9;
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(340, 110);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "イベントの長さ・時間設定";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.timeFormatGroup.ResumeLayout(false);
            this.timeFormatGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox timeLengthBox;
        private System.Windows.Forms.TextBox startTimeBox;
        private System.Windows.Forms.RadioButton hmsmsFormat;
        private System.Windows.Forms.GroupBox timeFormatGroup;
        private System.Windows.Forms.RadioButton hmsfFormat;
        private System.Windows.Forms.Label hmsfFormatLabel;
        private System.Windows.Forms.Label hmsmsFormatLabel;
    }
}