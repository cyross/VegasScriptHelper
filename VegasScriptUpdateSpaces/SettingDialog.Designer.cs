namespace VegasScriptUpdateSpaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDialog));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.msecLabel = new System.Windows.Forms.Label();
            this.spaceBox = new System.Windows.Forms.TextBox();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.msecLabel);
            this.mainPanel.Controls.Add(this.spaceBox);
            this.mainPanel.Controls.Add(this.spaceLabel);
            this.mainPanel.Location = new System.Drawing.Point(9, 10);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(212, 32);
            this.mainPanel.TabIndex = 0;
            // 
            // msecLabel
            // 
            this.msecLabel.AutoSize = true;
            this.msecLabel.Location = new System.Drawing.Point(155, 10);
            this.msecLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msecLabel.Name = "msecLabel";
            this.msecLabel.Size = new System.Drawing.Size(31, 12);
            this.msecLabel.TabIndex = 3;
            this.msecLabel.Text = "ミリ秒";
            // 
            // spaceBox
            // 
            this.spaceBox.Location = new System.Drawing.Point(41, 7);
            this.spaceBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.spaceBox.Name = "spaceBox";
            this.spaceBox.Size = new System.Drawing.Size(110, 19);
            this.spaceBox.TabIndex = 3;
            this.spaceBox.Text = "0";
            this.spaceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spaceLabel
            // 
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(9, 10);
            this.spaceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(29, 12);
            this.spaceLabel.TabIndex = 0;
            this.spaceLabel.Text = "間隔";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(104, 46);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 18);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.Location = new System.Drawing.Point(164, 46);
            this.canselButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(56, 18);
            this.canselButton.TabIndex = 2;
            this.canselButton.Text = "CANSEL";
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 74);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingDialog";
            this.Text = "SettingDialog";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.Label msecLabel;
        private System.Windows.Forms.TextBox spaceBox;
        private System.Windows.Forms.Label spaceLabel;
    }
}