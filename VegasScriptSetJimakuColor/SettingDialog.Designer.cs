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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.jimakuColorLabel = new System.Windows.Forms.Label();
            this.outlineColorLabel = new System.Windows.Forms.Label();
            this.outlineWidthLabel = new System.Windows.Forms.Label();
            this.jimakuColorDialog = new System.Windows.Forms.ColorDialog();
            this.outlineColorDialog = new System.Windows.Forms.ColorDialog();
            this.jimakuColorBox = new System.Windows.Forms.PictureBox();
            this.outlineColorBox = new System.Windows.Forms.PictureBox();
            this.outlineWidthBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jimakuColorNoteLabel = new System.Windows.Forms.Label();
            this.outlineColorNoteLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.targetVideoTrackLabel = new System.Windows.Forms.Label();
            this.targetVideoTrackName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jimakuColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlineColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.targetVideoTrackName);
            this.panel1.Controls.Add(this.targetVideoTrackLabel);
            this.panel1.Controls.Add(this.outlineColorNoteLabel);
            this.panel1.Controls.Add(this.jimakuColorNoteLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.outlineWidthBox);
            this.panel1.Controls.Add(this.outlineColorBox);
            this.panel1.Controls.Add(this.jimakuColorBox);
            this.panel1.Controls.Add(this.outlineWidthLabel);
            this.panel1.Controls.Add(this.outlineColorLabel);
            this.panel1.Controls.Add(this.jimakuColorLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 226);
            this.panel1.TabIndex = 0;
            // 
            // jimakuColorLabel
            // 
            this.jimakuColorLabel.AutoSize = true;
            this.jimakuColorLabel.Location = new System.Drawing.Point(14, 80);
            this.jimakuColorLabel.Name = "jimakuColorLabel";
            this.jimakuColorLabel.Size = new System.Drawing.Size(41, 12);
            this.jimakuColorLabel.TabIndex = 0;
            this.jimakuColorLabel.Text = "字幕色";
            // 
            // outlineColorLabel
            // 
            this.outlineColorLabel.AutoSize = true;
            this.outlineColorLabel.Location = new System.Drawing.Point(14, 136);
            this.outlineColorLabel.Name = "outlineColorLabel";
            this.outlineColorLabel.Size = new System.Drawing.Size(69, 12);
            this.outlineColorLabel.TabIndex = 0;
            this.outlineColorLabel.Text = "アウトライン色";
            // 
            // outlineWidthLabel
            // 
            this.outlineWidthLabel.AutoSize = true;
            this.outlineWidthLabel.Location = new System.Drawing.Point(14, 192);
            this.outlineWidthLabel.Name = "outlineWidthLabel";
            this.outlineWidthLabel.Size = new System.Drawing.Size(69, 12);
            this.outlineWidthLabel.TabIndex = 0;
            this.outlineWidthLabel.Text = "アウトライン幅";
            // 
            // jimakuColorBox
            // 
            this.jimakuColorBox.BackColor = System.Drawing.Color.Transparent;
            this.jimakuColorBox.Location = new System.Drawing.Point(104, 72);
            this.jimakuColorBox.Name = "jimakuColorBox";
            this.jimakuColorBox.Size = new System.Drawing.Size(100, 29);
            this.jimakuColorBox.TabIndex = 3;
            this.jimakuColorBox.TabStop = false;
            this.jimakuColorBox.Click += new System.EventHandler(this.jimakuColorBox_Click);
            // 
            // outlineColorBox
            // 
            this.outlineColorBox.BackColor = System.Drawing.Color.Transparent;
            this.outlineColorBox.Location = new System.Drawing.Point(104, 128);
            this.outlineColorBox.Name = "outlineColorBox";
            this.outlineColorBox.Size = new System.Drawing.Size(100, 29);
            this.outlineColorBox.TabIndex = 4;
            this.outlineColorBox.TabStop = false;
            this.outlineColorBox.Click += new System.EventHandler(this.outlineColorBox_Click);
            // 
            // outlineWidthBox
            // 
            this.outlineWidthBox.Location = new System.Drawing.Point(104, 189);
            this.outlineWidthBox.Name = "outlineWidthBox";
            this.outlineWidthBox.Size = new System.Drawing.Size(100, 19);
            this.outlineWidthBox.TabIndex = 1;
            this.outlineWidthBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "px";
            // 
            // jimakuColorNoteLabel
            // 
            this.jimakuColorNoteLabel.AutoSize = true;
            this.jimakuColorNoteLabel.Location = new System.Drawing.Point(210, 80);
            this.jimakuColorNoteLabel.Name = "jimakuColorNoteLabel";
            this.jimakuColorNoteLabel.Size = new System.Drawing.Size(211, 12);
            this.jimakuColorNoteLabel.TabIndex = 7;
            this.jimakuColorNoteLabel.Text = "←ボックスをクリックすると色の設定ができます";
            // 
            // outlineColorNoteLabel
            // 
            this.outlineColorNoteLabel.AutoSize = true;
            this.outlineColorNoteLabel.Location = new System.Drawing.Point(210, 136);
            this.outlineColorNoteLabel.Name = "outlineColorNoteLabel";
            this.outlineColorNoteLabel.Size = new System.Drawing.Size(211, 12);
            this.outlineColorNoteLabel.TabIndex = 0;
            this.outlineColorNoteLabel.Text = "←ボックスをクリックすると色の設定ができます";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(291, 244);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.Location = new System.Drawing.Point(372, 244);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(75, 23);
            this.canselButton.TabIndex = 3;
            this.canselButton.Text = "CANSEL";
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // targetVideoTrackLabel
            // 
            this.targetVideoTrackLabel.AutoSize = true;
            this.targetVideoTrackLabel.Location = new System.Drawing.Point(14, 26);
            this.targetVideoTrackLabel.Name = "targetVideoTrackLabel";
            this.targetVideoTrackLabel.Size = new System.Drawing.Size(84, 12);
            this.targetVideoTrackLabel.TabIndex = 8;
            this.targetVideoTrackLabel.Text = "対象字幕トラック";
            // 
            // targetVideoTrackName
            // 
            this.targetVideoTrackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetVideoTrackName.FormattingEnabled = true;
            this.targetVideoTrackName.Location = new System.Drawing.Point(104, 22);
            this.targetVideoTrackName.Name = "targetVideoTrackName";
            this.targetVideoTrackName.Size = new System.Drawing.Size(308, 20);
            this.targetVideoTrackName.TabIndex = 9;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 274);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.panel1);
            this.Name = "SettingForm";
            this.Text = "設定";
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SettingForm_Validating);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jimakuColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlineColorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label outlineWidthLabel;
        private System.Windows.Forms.Label outlineColorLabel;
        private System.Windows.Forms.Label jimakuColorLabel;
        private System.Windows.Forms.ColorDialog jimakuColorDialog;
        private System.Windows.Forms.ColorDialog outlineColorDialog;
        private System.Windows.Forms.Label outlineColorNoteLabel;
        private System.Windows.Forms.Label jimakuColorNoteLabel;
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