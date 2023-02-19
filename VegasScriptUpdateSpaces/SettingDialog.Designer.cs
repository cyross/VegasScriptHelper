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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.spaceBox = new System.Windows.Forms.TextBox();
            this.msecLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.msecLabel);
            this.mainPanel.Controls.Add(this.spaceBox);
            this.mainPanel.Controls.Add(this.spaceLabel);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(282, 40);
            this.mainPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(138, 58);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.Location = new System.Drawing.Point(219, 58);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(75, 23);
            this.canselButton.TabIndex = 2;
            this.canselButton.Text = "CANSEL";
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // spaceLabel
            // 
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(12, 12);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(37, 15);
            this.spaceLabel.TabIndex = 0;
            this.spaceLabel.Text = "間隔";
            // 
            // spaceBox
            // 
            this.spaceBox.Location = new System.Drawing.Point(55, 9);
            this.spaceBox.Name = "spaceBox";
            this.spaceBox.Size = new System.Drawing.Size(146, 22);
            this.spaceBox.TabIndex = 3;
            this.spaceBox.Text = "0";
            this.spaceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // msecLabel
            // 
            this.msecLabel.AutoSize = true;
            this.msecLabel.Location = new System.Drawing.Point(207, 12);
            this.msecLabel.Name = "msecLabel";
            this.msecLabel.Size = new System.Drawing.Size(40, 15);
            this.msecLabel.TabIndex = 3;
            this.msecLabel.Text = "ミリ秒";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 93);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mainPanel);
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