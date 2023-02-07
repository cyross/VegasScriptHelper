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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.mediaBinName = new System.Windows.Forms.TextBox();
            this.mediaBinNameLabel = new System.Windows.Forms.Label();
            this.useMediaBin = new System.Windows.Forms.CheckBox();
            this.StartPoint = new System.Windows.Forms.GroupBox();
            this.fromCurrent = new System.Windows.Forms.RadioButton();
            this.fromStart = new System.Windows.Forms.RadioButton();
            this.trackNameLabel = new System.Windows.Forms.Label();
            this.trackName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.StartPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // IsRecursiveCheck
            // 
            this.IsRecursiveCheck.AutoSize = true;
            this.IsRecursiveCheck.Location = new System.Drawing.Point(98, 34);
            this.IsRecursiveCheck.Name = "IsRecursiveCheck";
            this.IsRecursiveCheck.Size = new System.Drawing.Size(93, 16);
            this.IsRecursiveCheck.TabIndex = 0;
            this.IsRecursiveCheck.Text = "再帰的に取得";
            this.IsRecursiveCheck.UseVisualStyleBackColor = true;
            // 
            // AudioFileFolderLavel
            // 
            this.AudioFileFolderLavel.AutoSize = true;
            this.AudioFileFolderLavel.Location = new System.Drawing.Point(16, 12);
            this.AudioFileFolderLavel.Name = "AudioFileFolderLavel";
            this.AudioFileFolderLavel.Size = new System.Drawing.Size(64, 12);
            this.AudioFileFolderLavel.TabIndex = 1;
            this.AudioFileFolderLavel.Text = "取得フォルダ";
            // 
            // AudioFileFolderText
            // 
            this.AudioFileFolderText.Location = new System.Drawing.Point(98, 9);
            this.AudioFileFolderText.Name = "AudioFileFolderText";
            this.AudioFileFolderText.Size = new System.Drawing.Size(605, 19);
            this.AudioFileFolderText.TabIndex = 2;
            // 
            // AudioFileFolderDialogOpenButton
            // 
            this.AudioFileFolderDialogOpenButton.Location = new System.Drawing.Point(709, 7);
            this.AudioFileFolderDialogOpenButton.Name = "AudioFileFolderDialogOpenButton";
            this.AudioFileFolderDialogOpenButton.Size = new System.Drawing.Size(75, 23);
            this.AudioFileFolderDialogOpenButton.TabIndex = 3;
            this.AudioFileFolderDialogOpenButton.Text = "参照...";
            this.AudioFileFolderDialogOpenButton.UseVisualStyleBackColor = true;
            this.AudioFileFolderDialogOpenButton.Click += new System.EventHandler(this.AudioFileFolderDialogOpenButton_Click);
            // 
            // IntervalInputText
            // 
            this.IntervalInputText.Location = new System.Drawing.Point(98, 149);
            this.IntervalInputText.Name = "IntervalInputText";
            this.IntervalInputText.Size = new System.Drawing.Size(74, 19);
            this.IntervalInputText.TabIndex = 5;
            // 
            // IntervalInputLavel
            // 
            this.IntervalInputLavel.AutoSize = true;
            this.IntervalInputLavel.Location = new System.Drawing.Point(16, 152);
            this.IntervalInputLavel.Name = "IntervalInputLavel";
            this.IntervalInputLavel.Size = new System.Drawing.Size(53, 12);
            this.IntervalInputLavel.TabIndex = 4;
            this.IntervalInputLavel.Text = "貼付間隔";
            // 
            // IntervalInputUnitLabel
            // 
            this.IntervalInputUnitLabel.AutoSize = true;
            this.IntervalInputUnitLabel.Location = new System.Drawing.Point(178, 152);
            this.IntervalInputUnitLabel.Name = "IntervalInputUnitLabel";
            this.IntervalInputUnitLabel.Size = new System.Drawing.Size(31, 12);
            this.IntervalInputUnitLabel.TabIndex = 6;
            this.IntervalInputUnitLabel.Text = "ミリ秒";
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(648, 226);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 7;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // CANSELbutton
            // 
            this.CANSELbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANSELbutton.Location = new System.Drawing.Point(729, 226);
            this.CANSELbutton.Name = "CANSELbutton";
            this.CANSELbutton.Size = new System.Drawing.Size(75, 23);
            this.CANSELbutton.TabIndex = 8;
            this.CANSELbutton.Text = "Cansel";
            this.CANSELbutton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackName);
            this.panel1.Controls.Add(this.trackNameLabel);
            this.panel1.Controls.Add(this.mediaBinName);
            this.panel1.Controls.Add(this.mediaBinNameLabel);
            this.panel1.Controls.Add(this.useMediaBin);
            this.panel1.Controls.Add(this.StartPoint);
            this.panel1.Controls.Add(this.AudioFileFolderLavel);
            this.panel1.Controls.Add(this.IsRecursiveCheck);
            this.panel1.Controls.Add(this.AudioFileFolderText);
            this.panel1.Controls.Add(this.IntervalInputUnitLabel);
            this.panel1.Controls.Add(this.AudioFileFolderDialogOpenButton);
            this.panel1.Controls.Add(this.IntervalInputText);
            this.panel1.Controls.Add(this.IntervalInputLavel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 208);
            this.panel1.TabIndex = 9;
            // 
            // mediaBinName
            // 
            this.mediaBinName.Location = new System.Drawing.Point(250, 176);
            this.mediaBinName.Name = "mediaBinName";
            this.mediaBinName.Size = new System.Drawing.Size(233, 19);
            this.mediaBinName.TabIndex = 10;
            // 
            // mediaBinNameLabel
            // 
            this.mediaBinNameLabel.AutoSize = true;
            this.mediaBinNameLabel.Location = new System.Drawing.Point(176, 179);
            this.mediaBinNameLabel.Name = "mediaBinNameLabel";
            this.mediaBinNameLabel.Size = new System.Drawing.Size(68, 12);
            this.mediaBinNameLabel.TabIndex = 9;
            this.mediaBinNameLabel.Text = "メディアビン名";
            // 
            // useMediaBin
            // 
            this.useMediaBin.AutoSize = true;
            this.useMediaBin.Checked = true;
            this.useMediaBin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useMediaBin.Location = new System.Drawing.Point(18, 178);
            this.useMediaBin.Name = "useMediaBin";
            this.useMediaBin.Size = new System.Drawing.Size(138, 16);
            this.useMediaBin.TabIndex = 8;
            this.useMediaBin.Text = "メディアビンを作成・使用";
            this.useMediaBin.UseVisualStyleBackColor = true;
            // 
            // StartPoint
            // 
            this.StartPoint.Controls.Add(this.fromCurrent);
            this.StartPoint.Controls.Add(this.fromStart);
            this.StartPoint.Location = new System.Drawing.Point(18, 94);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Size = new System.Drawing.Size(226, 49);
            this.StartPoint.TabIndex = 7;
            this.StartPoint.TabStop = false;
            this.StartPoint.Text = "開始位置";
            // 
            // fromCurrent
            // 
            this.fromCurrent.AutoSize = true;
            this.fromCurrent.Location = new System.Drawing.Point(103, 18);
            this.fromCurrent.Name = "fromCurrent";
            this.fromCurrent.Size = new System.Drawing.Size(99, 16);
            this.fromCurrent.TabIndex = 1;
            this.fromCurrent.TabStop = true;
            this.fromCurrent.Text = "現在の位置から";
            this.fromCurrent.UseVisualStyleBackColor = true;
            // 
            // fromStart
            // 
            this.fromStart.AutoSize = true;
            this.fromStart.Location = new System.Drawing.Point(6, 18);
            this.fromStart.Name = "fromStart";
            this.fromStart.Size = new System.Drawing.Size(65, 16);
            this.fromStart.TabIndex = 0;
            this.fromStart.TabStop = true;
            this.fromStart.Text = "最初から";
            this.fromStart.UseVisualStyleBackColor = true;
            // 
            // trackNameLabel
            // 
            this.trackNameLabel.AutoSize = true;
            this.trackNameLabel.Location = new System.Drawing.Point(16, 59);
            this.trackNameLabel.Name = "trackNameLabel";
            this.trackNameLabel.Size = new System.Drawing.Size(84, 12);
            this.trackNameLabel.TabIndex = 11;
            this.trackNameLabel.Text = "挿入対象トラック";
            // 
            // trackName
            // 
            this.trackName.FormattingEnabled = true;
            this.trackName.Location = new System.Drawing.Point(106, 56);
            this.trackName.Name = "trackName";
            this.trackName.Size = new System.Drawing.Size(597, 20);
            this.trackName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(105, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "新規追加はトラック名を記入";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 258);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CANSELbutton);
            this.Controls.Add(this.OKbutton);
            this.Name = "Setting";
            this.Text = "スクリプト設定";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.StartPoint.ResumeLayout(false);
            this.StartPoint.PerformLayout();
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
        private System.Windows.Forms.Label label1;
    }
}