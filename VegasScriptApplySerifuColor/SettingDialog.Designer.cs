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
            this.OutlineWidthTextBox = new System.Windows.Forms.TextBox();
            this.RemovePrefixFlag = new System.Windows.Forms.CheckBox();
            this.OutlineWidthLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.jimakuTrackName = new System.Windows.Forms.ComboBox();
            this.jimakuTrackNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.jimakuTrackNameLabel);
            this.panel1.Controls.Add(this.jimakuTrackName);
            this.panel1.Controls.Add(this.OutlineWidthTextBox);
            this.panel1.Controls.Add(this.RemovePrefixFlag);
            this.panel1.Controls.Add(this.OutlineWidthLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 87);
            this.panel1.TabIndex = 0;
            // 
            // OutlineWidthTextBox
            // 
            this.OutlineWidthTextBox.Location = new System.Drawing.Point(88, 38);
            this.OutlineWidthTextBox.Name = "OutlineWidthTextBox";
            this.OutlineWidthTextBox.Size = new System.Drawing.Size(119, 19);
            this.OutlineWidthTextBox.TabIndex = 2;
            // 
            // RemovePrefixFlag
            // 
            this.RemovePrefixFlag.AutoSize = true;
            this.RemovePrefixFlag.Checked = true;
            this.RemovePrefixFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemovePrefixFlag.Location = new System.Drawing.Point(3, 63);
            this.RemovePrefixFlag.Name = "RemovePrefixFlag";
            this.RemovePrefixFlag.Size = new System.Drawing.Size(146, 16);
            this.RemovePrefixFlag.TabIndex = 1;
            this.RemovePrefixFlag.Text = "字幕の接頭辞を削除する";
            this.RemovePrefixFlag.UseVisualStyleBackColor = true;
            // 
            // OutlineWidthLabel
            // 
            this.OutlineWidthLabel.AutoSize = true;
            this.OutlineWidthLabel.Location = new System.Drawing.Point(3, 41);
            this.OutlineWidthLabel.Name = "OutlineWidthLabel";
            this.OutlineWidthLabel.Size = new System.Drawing.Size(79, 12);
            this.OutlineWidthLabel.TabIndex = 0;
            this.OutlineWidthLabel.Text = "アウトラインの幅";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(162, 105);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.Location = new System.Drawing.Point(243, 105);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(75, 23);
            this.canselButton.TabIndex = 2;
            this.canselButton.Text = "CANSEL";
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // jimakuTrackName
            // 
            this.jimakuTrackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jimakuTrackName.FormattingEnabled = true;
            this.jimakuTrackName.Location = new System.Drawing.Point(88, 12);
            this.jimakuTrackName.Name = "jimakuTrackName";
            this.jimakuTrackName.Size = new System.Drawing.Size(205, 20);
            this.jimakuTrackName.TabIndex = 3;
            // 
            // jimakuTrackNameLabel
            // 
            this.jimakuTrackNameLabel.AutoSize = true;
            this.jimakuTrackNameLabel.Location = new System.Drawing.Point(22, 15);
            this.jimakuTrackNameLabel.Name = "jimakuTrackNameLabel";
            this.jimakuTrackNameLabel.Size = new System.Drawing.Size(60, 12);
            this.jimakuTrackNameLabel.TabIndex = 4;
            this.jimakuTrackNameLabel.Text = "字幕トラック";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 133);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.panel1);
            this.Name = "SettingForm";
            this.Text = "各種設定";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.TextBox OutlineWidthTextBox;
        private System.Windows.Forms.CheckBox RemovePrefixFlag;
        private System.Windows.Forms.Label OutlineWidthLabel;
        private System.Windows.Forms.ComboBox jimakuTrackName;
        private System.Windows.Forms.Label jimakuTrackNameLabel;
    }
}