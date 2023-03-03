namespace VegasScriptSetJimakuColor
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

            pfc.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.canselButton = new System.Windows.Forms.Button();
            this.targetVideoTrackName = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.targetVideoTrackLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.outlineWidthBox = new System.Windows.Forms.TextBox();
            this.outlineColorBox = new System.Windows.Forms.PictureBox();
            this.jimakuColorBox = new System.Windows.Forms.PictureBox();
            this.outlineWidthLabel = new System.Windows.Forms.Label();
            this.outlineColorLabel = new System.Windows.Forms.Label();
            this.jimakuColorLabel = new System.Windows.Forms.Label();
            this.jimakuColorDialog = new System.Windows.Forms.ColorDialog();
            this.outlineColorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlineColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jimakuColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.canselButton);
            this.panel1.Controls.Add(this.targetVideoTrackName);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.targetVideoTrackLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.outlineWidthBox);
            this.panel1.Controls.Add(this.outlineColorBox);
            this.panel1.Controls.Add(this.jimakuColorBox);
            this.panel1.Controls.Add(this.outlineWidthLabel);
            this.panel1.Controls.Add(this.outlineColorLabel);
            this.panel1.Controls.Add(this.jimakuColorLabel);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 110);
            this.panel1.TabIndex = 0;
            // 
            // canselButton
            // 
            this.canselButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canselButton.BackgroundImage")));
            this.canselButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(315, 80);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(24, 24);
            this.canselButton.TabIndex = 3;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // targetVideoTrackName
            // 
            this.targetVideoTrackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetVideoTrackName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetVideoTrackName.FormattingEnabled = true;
            this.targetVideoTrackName.Location = new System.Drawing.Point(99, 11);
            this.targetVideoTrackName.Margin = new System.Windows.Forms.Padding(4);
            this.targetVideoTrackName.Name = "targetVideoTrackName";
            this.targetVideoTrackName.Size = new System.Drawing.Size(240, 25);
            this.targetVideoTrackName.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(284, 80);
            this.okButton.Margin = new System.Windows.Forms.Padding(8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(24, 24);
            this.okButton.TabIndex = 2;
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // targetVideoTrackLabel
            // 
            this.targetVideoTrackLabel.AutoSize = true;
            this.targetVideoTrackLabel.Location = new System.Drawing.Point(11, 14);
            this.targetVideoTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetVideoTrackLabel.Name = "targetVideoTrackLabel";
            this.targetVideoTrackLabel.Size = new System.Drawing.Size(80, 17);
            this.targetVideoTrackLabel.TabIndex = 8;
            this.targetVideoTrackLabel.Text = "字幕トラック";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "px";
            // 
            // outlineWidthBox
            // 
            this.outlineWidthBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outlineWidthBox.Location = new System.Drawing.Point(99, 84);
            this.outlineWidthBox.Margin = new System.Windows.Forms.Padding(4);
            this.outlineWidthBox.Name = "outlineWidthBox";
            this.outlineWidthBox.Size = new System.Drawing.Size(40, 18);
            this.outlineWidthBox.TabIndex = 1;
            this.outlineWidthBox.Text = "1000";
            this.outlineWidthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outlineColorBox
            // 
            this.outlineColorBox.BackColor = System.Drawing.Color.ForestGreen;
            this.outlineColorBox.Location = new System.Drawing.Point(99, 44);
            this.outlineColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.outlineColorBox.Name = "outlineColorBox";
            this.outlineColorBox.Size = new System.Drawing.Size(32, 32);
            this.outlineColorBox.TabIndex = 4;
            this.outlineColorBox.TabStop = false;
            this.outlineColorBox.Click += new System.EventHandler(this.outlineColorBox_Click);
            // 
            // jimakuColorBox
            // 
            this.jimakuColorBox.BackColor = System.Drawing.Color.ForestGreen;
            this.jimakuColorBox.Location = new System.Drawing.Point(253, 44);
            this.jimakuColorBox.Margin = new System.Windows.Forms.Padding(4);
            this.jimakuColorBox.Name = "jimakuColorBox";
            this.jimakuColorBox.Size = new System.Drawing.Size(32, 32);
            this.jimakuColorBox.TabIndex = 3;
            this.jimakuColorBox.TabStop = false;
            this.jimakuColorBox.Click += new System.EventHandler(this.jimakuColorBox_Click);
            // 
            // outlineWidthLabel
            // 
            this.outlineWidthLabel.AutoSize = true;
            this.outlineWidthLabel.Location = new System.Drawing.Point(1, 84);
            this.outlineWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outlineWidthLabel.Name = "outlineWidthLabel";
            this.outlineWidthLabel.Size = new System.Drawing.Size(92, 17);
            this.outlineWidthLabel.TabIndex = 0;
            this.outlineWidthLabel.Text = "アウトライン幅";
            // 
            // outlineColorLabel
            // 
            this.outlineColorLabel.AutoSize = true;
            this.outlineColorLabel.Location = new System.Drawing.Point(153, 52);
            this.outlineColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outlineColorLabel.Name = "outlineColorLabel";
            this.outlineColorLabel.Size = new System.Drawing.Size(92, 17);
            this.outlineColorLabel.TabIndex = 0;
            this.outlineColorLabel.Text = "アウトライン色";
            // 
            // jimakuColorLabel
            // 
            this.jimakuColorLabel.AutoSize = true;
            this.jimakuColorLabel.Location = new System.Drawing.Point(49, 52);
            this.jimakuColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jimakuColorLabel.Name = "jimakuColorLabel";
            this.jimakuColorLabel.Size = new System.Drawing.Size(44, 17);
            this.jimakuColorLabel.TabIndex = 0;
            this.jimakuColorLabel.Text = "字幕色";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(354, 114);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字幕属性設定";
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SettingForm_Validating);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlineColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jimakuColorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label outlineWidthLabel;
        private System.Windows.Forms.Label outlineColorLabel;
        private System.Windows.Forms.Label jimakuColorLabel;
        private System.Windows.Forms.ColorDialog jimakuColorDialog;
        private System.Windows.Forms.ColorDialog outlineColorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outlineWidthBox;
        private System.Windows.Forms.PictureBox outlineColorBox;
        private System.Windows.Forms.PictureBox jimakuColorBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.ComboBox targetVideoTrackName;
        private System.Windows.Forms.Label targetVideoTrackLabel;
    }
}