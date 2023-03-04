namespace VegasScriptApplySerifuColor
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

            myFontCollection.Dispose();

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
            this.removePrefixFlagLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.jimakuTrackNameLabel = new System.Windows.Forms.Label();
            this.jimakuTrackName = new System.Windows.Forms.ComboBox();
            this.OutlineWidthTextBox = new System.Windows.Forms.TextBox();
            this.removePrefixFlag = new System.Windows.Forms.CheckBox();
            this.OutlineWidthLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.removePrefixFlagLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.canselButton);
            this.panel1.Controls.Add(this.jimakuTrackNameLabel);
            this.panel1.Controls.Add(this.jimakuTrackName);
            this.panel1.Controls.Add(this.OutlineWidthTextBox);
            this.panel1.Controls.Add(this.removePrefixFlag);
            this.panel1.Controls.Add(this.OutlineWidthLabel);
            this.panel1.Location = new System.Drawing.Point(8, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 95);
            this.panel1.TabIndex = 0;
            // 
            // removePrefixFlagLabel
            // 
            this.removePrefixFlagLabel.AutoSize = true;
            this.removePrefixFlagLabel.Location = new System.Drawing.Point(206, 42);
            this.removePrefixFlagLabel.Name = "removePrefixFlagLabel";
            this.removePrefixFlagLabel.Size = new System.Drawing.Size(140, 17);
            this.removePrefixFlagLabel.TabIndex = 6;
            this.removePrefixFlagLabel.Text = "字幕の接頭辞を削除する";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "px";
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Location = new System.Drawing.Point(300, 67);
            this.OKButton.Margin = new System.Windows.Forms.Padding(8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(24, 24);
            this.OKButton.TabIndex = 1;
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canselButton.BackgroundImage")));
            this.canselButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(330, 67);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(24, 24);
            this.canselButton.TabIndex = 2;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // jimakuTrackNameLabel
            // 
            this.jimakuTrackNameLabel.AutoSize = true;
            this.jimakuTrackNameLabel.Location = new System.Drawing.Point(28, 12);
            this.jimakuTrackNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jimakuTrackNameLabel.Name = "jimakuTrackNameLabel";
            this.jimakuTrackNameLabel.Size = new System.Drawing.Size(80, 17);
            this.jimakuTrackNameLabel.TabIndex = 4;
            this.jimakuTrackNameLabel.Text = "字幕トラック";
            // 
            // jimakuTrackName
            // 
            this.jimakuTrackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jimakuTrackName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jimakuTrackName.FormattingEnabled = true;
            this.jimakuTrackName.Location = new System.Drawing.Point(114, 9);
            this.jimakuTrackName.Margin = new System.Windows.Forms.Padding(4);
            this.jimakuTrackName.Name = "jimakuTrackName";
            this.jimakuTrackName.Size = new System.Drawing.Size(240, 25);
            this.jimakuTrackName.TabIndex = 3;
            // 
            // OutlineWidthTextBox
            // 
            this.OutlineWidthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutlineWidthTextBox.Location = new System.Drawing.Point(116, 42);
            this.OutlineWidthTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutlineWidthTextBox.Name = "OutlineWidthTextBox";
            this.OutlineWidthTextBox.Size = new System.Drawing.Size(40, 18);
            this.OutlineWidthTextBox.TabIndex = 2;
            this.OutlineWidthTextBox.Text = "1000";
            // 
            // removePrefixFlag
            // 
            this.removePrefixFlag.AutoSize = true;
            this.removePrefixFlag.BackColor = System.Drawing.Color.Transparent;
            this.removePrefixFlag.Checked = true;
            this.removePrefixFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removePrefixFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removePrefixFlag.ForeColor = System.Drawing.Color.Crimson;
            this.removePrefixFlag.Location = new System.Drawing.Point(192, 45);
            this.removePrefixFlag.Margin = new System.Windows.Forms.Padding(4);
            this.removePrefixFlag.Name = "removePrefixFlag";
            this.removePrefixFlag.Size = new System.Drawing.Size(12, 11);
            this.removePrefixFlag.TabIndex = 1;
            this.removePrefixFlag.UseVisualStyleBackColor = false;
            // 
            // OutlineWidthLabel
            // 
            this.OutlineWidthLabel.AutoSize = true;
            this.OutlineWidthLabel.Location = new System.Drawing.Point(4, 42);
            this.OutlineWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OutlineWidthLabel.Name = "OutlineWidthLabel";
            this.OutlineWidthLabel.Size = new System.Drawing.Size(104, 17);
            this.OutlineWidthLabel.TabIndex = 0;
            this.OutlineWidthLabel.Text = "アウトラインの幅";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(375, 103);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "セリフの属性を設定";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.TextBox OutlineWidthTextBox;
        private System.Windows.Forms.CheckBox removePrefixFlag;
        private System.Windows.Forms.Label OutlineWidthLabel;
        private System.Windows.Forms.ComboBox jimakuTrackName;
        private System.Windows.Forms.Label jimakuTrackNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label removePrefixFlagLabel;
    }
}