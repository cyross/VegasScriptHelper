namespace VegasScriptEditEventTimeByTextBoxExt
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.timeFormatGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.timeFormatGroup);
            this.mainPanel.Controls.Add(this.timeLengthBox);
            this.mainPanel.Controls.Add(this.startTimeBox);
            this.mainPanel.Controls.Add(this.LengthLabel);
            this.mainPanel.Controls.Add(this.startTimeLabel);
            this.mainPanel.Location = new System.Drawing.Point(2, 4);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(276, 137);
            this.mainPanel.TabIndex = 0;
            // 
            // timeFormatGroup
            // 
            this.timeFormatGroup.BackColor = System.Drawing.Color.Transparent;
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
            this.hmsfFormatLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.hmsmsFormatLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.timeLengthBox.Location = new System.Drawing.Point(123, 76);
            this.timeLengthBox.Name = "timeLengthBox";
            this.timeLengthBox.Size = new System.Drawing.Size(96, 25);
            this.timeLengthBox.TabIndex = 16;
            this.timeLengthBox.Text = "23:59:59.999";
            this.timeLengthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeLengthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyEntered);
            // 
            // startTimeBox
            // 
            this.startTimeBox.Location = new System.Drawing.Point(123, 50);
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.Size = new System.Drawing.Size(96, 25);
            this.startTimeBox.TabIndex = 15;
            this.startTimeBox.Text = "23:59:59.999";
            this.startTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTimeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyEntered);
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.LengthLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LengthLabel.ForeColor = System.Drawing.Color.White;
            this.LengthLabel.Location = new System.Drawing.Point(27, 80);
            this.LengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(92, 17);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "イベントの長さ";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.startTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startTimeLabel.ForeColor = System.Drawing.Color.White;
            this.startTimeLabel.Location = new System.Drawing.Point(6, 54);
            this.startTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(116, 17);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "イベントの開始時間";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "(テキストボックス内でEnterキーを押して更新)";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.mainPanel);
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox timeLengthBox;
        private System.Windows.Forms.TextBox startTimeBox;
        private System.Windows.Forms.RadioButton hmsmsFormat;
        private System.Windows.Forms.GroupBox timeFormatGroup;
        private System.Windows.Forms.RadioButton hmsfFormat;
        private System.Windows.Forms.Label hmsfFormatLabel;
        private System.Windows.Forms.Label hmsmsFormatLabel;
        private System.Windows.Forms.Label label1;
    }
}