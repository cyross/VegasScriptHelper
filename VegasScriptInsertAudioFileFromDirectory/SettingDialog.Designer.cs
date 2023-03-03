namespace VegasScriptInsertAudioFileFromDirectory
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
            this.IsRecursiveCheck = new System.Windows.Forms.CheckBox();
            this.AudioFileFolderLavel = new System.Windows.Forms.Label();
            this.AudioFileFolderText = new System.Windows.Forms.TextBox();
            this.AudioFileFolderDialogOpenButton = new System.Windows.Forms.Button();
            this.IntervalInputText = new System.Windows.Forms.TextBox();
            this.IntervalInputLavel = new System.Windows.Forms.Label();
            this.IntervalInputUnitLabel = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.CANSELbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mediaBinNameLabel = new System.Windows.Forms.Label();
            this.mediaBinName = new System.Windows.Forms.TextBox();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.trackName = new System.Windows.Forms.ComboBox();
            this.trackNameLabel = new System.Windows.Forms.Label();
            this.useMediaBin = new System.Windows.Forms.CheckBox();
            this.StartPoint = new System.Windows.Forms.GroupBox();
            this.fromCurrent = new System.Windows.Forms.RadioButton();
            this.fromStart = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.StartPoint.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IsRecursiveCheck
            // 
            this.IsRecursiveCheck.AutoSize = true;
            this.IsRecursiveCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsRecursiveCheck.ForeColor = System.Drawing.Color.Crimson;
            this.IsRecursiveCheck.Location = new System.Drawing.Point(140, 39);
            this.IsRecursiveCheck.Margin = new System.Windows.Forms.Padding(4);
            this.IsRecursiveCheck.Name = "IsRecursiveCheck";
            this.IsRecursiveCheck.Size = new System.Drawing.Size(12, 11);
            this.IsRecursiveCheck.TabIndex = 0;
            this.IsRecursiveCheck.UseVisualStyleBackColor = true;
            // 
            // AudioFileFolderLavel
            // 
            this.AudioFileFolderLavel.AutoSize = true;
            this.AudioFileFolderLavel.Location = new System.Drawing.Point(4, 10);
            this.AudioFileFolderLavel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AudioFileFolderLavel.Name = "AudioFileFolderLavel";
            this.AudioFileFolderLavel.Size = new System.Drawing.Size(128, 17);
            this.AudioFileFolderLavel.TabIndex = 1;
            this.AudioFileFolderLavel.Text = "音声ファイルフォルダ";
            // 
            // AudioFileFolderText
            // 
            this.AudioFileFolderText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AudioFileFolderText.Location = new System.Drawing.Point(140, 10);
            this.AudioFileFolderText.Margin = new System.Windows.Forms.Padding(4);
            this.AudioFileFolderText.Name = "AudioFileFolderText";
            this.AudioFileFolderText.Size = new System.Drawing.Size(520, 18);
            this.AudioFileFolderText.TabIndex = 2;
            // 
            // AudioFileFolderDialogOpenButton
            // 
            this.AudioFileFolderDialogOpenButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AudioFileFolderDialogOpenButton.BackgroundImage")));
            this.AudioFileFolderDialogOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AudioFileFolderDialogOpenButton.FlatAppearance.BorderSize = 0;
            this.AudioFileFolderDialogOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioFileFolderDialogOpenButton.Location = new System.Drawing.Point(672, 6);
            this.AudioFileFolderDialogOpenButton.Margin = new System.Windows.Forms.Padding(8);
            this.AudioFileFolderDialogOpenButton.Name = "AudioFileFolderDialogOpenButton";
            this.AudioFileFolderDialogOpenButton.Size = new System.Drawing.Size(24, 24);
            this.AudioFileFolderDialogOpenButton.TabIndex = 3;
            this.AudioFileFolderDialogOpenButton.UseVisualStyleBackColor = true;
            this.AudioFileFolderDialogOpenButton.Click += new System.EventHandler(this.AudioFileFolderDialogOpenButton_Click);
            // 
            // IntervalInputText
            // 
            this.IntervalInputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IntervalInputText.Location = new System.Drawing.Point(481, 68);
            this.IntervalInputText.Margin = new System.Windows.Forms.Padding(4);
            this.IntervalInputText.Name = "IntervalInputText";
            this.IntervalInputText.Size = new System.Drawing.Size(64, 18);
            this.IntervalInputText.TabIndex = 5;
            this.IntervalInputText.Text = "1000000";
            // 
            // IntervalInputLavel
            // 
            this.IntervalInputLavel.AutoSize = true;
            this.IntervalInputLavel.Location = new System.Drawing.Point(417, 68);
            this.IntervalInputLavel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IntervalInputLavel.Name = "IntervalInputLavel";
            this.IntervalInputLavel.Size = new System.Drawing.Size(56, 17);
            this.IntervalInputLavel.TabIndex = 4;
            this.IntervalInputLavel.Text = "貼付間隔";
            // 
            // IntervalInputUnitLabel
            // 
            this.IntervalInputUnitLabel.AutoSize = true;
            this.IntervalInputUnitLabel.Location = new System.Drawing.Point(553, 68);
            this.IntervalInputUnitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IntervalInputUnitLabel.Name = "IntervalInputUnitLabel";
            this.IntervalInputUnitLabel.Size = new System.Drawing.Size(44, 17);
            this.IntervalInputUnitLabel.TabIndex = 6;
            this.IntervalInputUnitLabel.Text = "ミリ秒";
            // 
            // OKbutton
            // 
            this.OKbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKbutton.BackgroundImage")));
            this.OKbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.FlatAppearance.BorderSize = 0;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbutton.Location = new System.Drawing.Point(642, 150);
            this.OKbutton.Margin = new System.Windows.Forms.Padding(8);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(24, 24);
            this.OKbutton.TabIndex = 7;
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // CANSELbutton
            // 
            this.CANSELbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CANSELbutton.BackgroundImage")));
            this.CANSELbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CANSELbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANSELbutton.FlatAppearance.BorderSize = 0;
            this.CANSELbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CANSELbutton.Location = new System.Drawing.Point(672, 150);
            this.CANSELbutton.Margin = new System.Windows.Forms.Padding(8);
            this.CANSELbutton.Name = "CANSELbutton";
            this.CANSELbutton.Size = new System.Drawing.Size(24, 24);
            this.CANSELbutton.TabIndex = 8;
            this.CANSELbutton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CANSELbutton);
            this.panel1.Controls.Add(this.noticeLabel);
            this.panel1.Controls.Add(this.OKbutton);
            this.panel1.Controls.Add(this.trackName);
            this.panel1.Controls.Add(this.trackNameLabel);
            this.panel1.Controls.Add(this.StartPoint);
            this.panel1.Controls.Add(this.AudioFileFolderLavel);
            this.panel1.Controls.Add(this.IsRecursiveCheck);
            this.panel1.Controls.Add(this.AudioFileFolderText);
            this.panel1.Controls.Add(this.IntervalInputUnitLabel);
            this.panel1.Controls.Add(this.AudioFileFolderDialogOpenButton);
            this.panel1.Controls.Add(this.IntervalInputText);
            this.panel1.Controls.Add(this.IntervalInputLavel);
            this.panel1.Location = new System.Drawing.Point(9, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 178);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mediaBinNameLabel);
            this.panel2.Controls.Add(this.mediaBinName);
            this.panel2.Location = new System.Drawing.Point(96, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 27);
            this.panel2.TabIndex = 14;
            // 
            // mediaBinNameLabel
            // 
            this.mediaBinNameLabel.AutoSize = true;
            this.mediaBinNameLabel.ForeColor = System.Drawing.Color.White;
            this.mediaBinNameLabel.Location = new System.Drawing.Point(4, 4);
            this.mediaBinNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mediaBinNameLabel.Name = "mediaBinNameLabel";
            this.mediaBinNameLabel.Size = new System.Drawing.Size(92, 17);
            this.mediaBinNameLabel.TabIndex = 9;
            this.mediaBinNameLabel.Text = "メディアビン名";
            // 
            // mediaBinName
            // 
            this.mediaBinName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mediaBinName.Location = new System.Drawing.Point(104, 4);
            this.mediaBinName.Margin = new System.Windows.Forms.Padding(4);
            this.mediaBinName.Name = "mediaBinName";
            this.mediaBinName.Size = new System.Drawing.Size(180, 18);
            this.mediaBinName.TabIndex = 10;
            // 
            // noticeLabel
            // 
            this.noticeLabel.AutoSize = true;
            this.noticeLabel.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.noticeLabel.Location = new System.Drawing.Point(138, 94);
            this.noticeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(164, 17);
            this.noticeLabel.TabIndex = 13;
            this.noticeLabel.Text = "新規追加はトラック名を記入";
            // 
            // trackName
            // 
            this.trackName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trackName.FormattingEnabled = true;
            this.trackName.Location = new System.Drawing.Point(140, 65);
            this.trackName.Margin = new System.Windows.Forms.Padding(4);
            this.trackName.Name = "trackName";
            this.trackName.Size = new System.Drawing.Size(240, 25);
            this.trackName.TabIndex = 12;
            // 
            // trackNameLabel
            // 
            this.trackNameLabel.AutoSize = true;
            this.trackNameLabel.Location = new System.Drawing.Point(25, 68);
            this.trackNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.trackNameLabel.Name = "trackNameLabel";
            this.trackNameLabel.Size = new System.Drawing.Size(104, 17);
            this.trackNameLabel.TabIndex = 11;
            this.trackNameLabel.Text = "挿入対象トラック";
            // 
            // useMediaBin
            // 
            this.useMediaBin.AutoSize = true;
            this.useMediaBin.Checked = true;
            this.useMediaBin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useMediaBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.useMediaBin.ForeColor = System.Drawing.Color.Crimson;
            this.useMediaBin.Location = new System.Drawing.Point(7, 33);
            this.useMediaBin.Margin = new System.Windows.Forms.Padding(4);
            this.useMediaBin.Name = "useMediaBin";
            this.useMediaBin.Size = new System.Drawing.Size(12, 11);
            this.useMediaBin.TabIndex = 8;
            this.useMediaBin.UseVisualStyleBackColor = true;
            // 
            // StartPoint
            // 
            this.StartPoint.Controls.Add(this.fromCurrent);
            this.StartPoint.Controls.Add(this.fromStart);
            this.StartPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartPoint.ForeColor = System.Drawing.Color.LemonChiffon;
            this.StartPoint.Location = new System.Drawing.Point(7, 115);
            this.StartPoint.Margin = new System.Windows.Forms.Padding(4);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Padding = new System.Windows.Forms.Padding(4);
            this.StartPoint.Size = new System.Drawing.Size(208, 59);
            this.StartPoint.TabIndex = 7;
            this.StartPoint.TabStop = false;
            this.StartPoint.Text = "開始位置";
            // 
            // fromCurrent
            // 
            this.fromCurrent.AutoSize = true;
            this.fromCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromCurrent.ForeColor = System.Drawing.Color.White;
            this.fromCurrent.Location = new System.Drawing.Point(88, 26);
            this.fromCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.fromCurrent.Name = "fromCurrent";
            this.fromCurrent.Size = new System.Drawing.Size(109, 21);
            this.fromCurrent.TabIndex = 1;
            this.fromCurrent.TabStop = true;
            this.fromCurrent.Text = "現在の位置から";
            this.fromCurrent.UseVisualStyleBackColor = true;
            // 
            // fromStart
            // 
            this.fromStart.AutoSize = true;
            this.fromStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromStart.ForeColor = System.Drawing.Color.White;
            this.fromStart.Location = new System.Drawing.Point(7, 26);
            this.fromStart.Margin = new System.Windows.Forms.Padding(4);
            this.fromStart.Name = "fromStart";
            this.fromStart.Size = new System.Drawing.Size(73, 21);
            this.fromStart.TabIndex = 0;
            this.fromStart.TabStop = true;
            this.fromStart.Text = "最初から";
            this.fromStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "再帰的に取得";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "作成・使用";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useMediaBin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Location = new System.Drawing.Point(231, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 59);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "メディアビン";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(715, 185);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "音声ファイル流し込み";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.StartPoint.ResumeLayout(false);
            this.StartPoint.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox IsRecursiveCheck;
        private System.Windows.Forms.Label AudioFileFolderLavel;
        private System.Windows.Forms.TextBox AudioFileFolderText;
        private System.Windows.Forms.Button AudioFileFolderDialogOpenButton;
        private System.Windows.Forms.TextBox IntervalInputText;
        private System.Windows.Forms.Label IntervalInputLavel;
        private System.Windows.Forms.Label IntervalInputUnitLabel;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button CANSELbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox StartPoint;
        private System.Windows.Forms.RadioButton fromStart;
        private System.Windows.Forms.RadioButton fromCurrent;
        private System.Windows.Forms.CheckBox useMediaBin;
        private System.Windows.Forms.Label mediaBinNameLabel;
        private System.Windows.Forms.TextBox mediaBinName;
        private System.Windows.Forms.Label trackNameLabel;
        private System.Windows.Forms.ComboBox trackName;
        private System.Windows.Forms.Label noticeLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}