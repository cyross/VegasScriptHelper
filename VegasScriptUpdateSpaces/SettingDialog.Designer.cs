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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.msecLabel = new System.Windows.Forms.Label();
            this.spaceBox = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.okButton);
            this.mainPanel.Controls.Add(this.canselButton);
            this.mainPanel.Controls.Add(this.msecLabel);
            this.mainPanel.Controls.Add(this.spaceBox);
            this.mainPanel.Location = new System.Drawing.Point(6, 2);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(191, 32);
            this.mainPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(132, 3);
            this.okButton.Margin = new System.Windows.Forms.Padding(8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(24, 24);
            this.okButton.TabIndex = 1;
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canselButton.BackgroundImage")));
            this.canselButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canselButton.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(160, 3);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(24, 24);
            this.canselButton.TabIndex = 2;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // msecLabel
            // 
            this.msecLabel.AutoSize = true;
            this.msecLabel.ForeColor = System.Drawing.Color.White;
            this.msecLabel.Location = new System.Drawing.Point(75, 7);
            this.msecLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.msecLabel.Name = "msecLabel";
            this.msecLabel.Size = new System.Drawing.Size(44, 17);
            this.msecLabel.TabIndex = 3;
            this.msecLabel.Text = "ミリ秒";
            // 
            // spaceBox
            // 
            this.spaceBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spaceBox.Location = new System.Drawing.Point(7, 7);
            this.spaceBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spaceBox.Name = "spaceBox";
            this.spaceBox.Size = new System.Drawing.Size(64, 18);
            this.spaceBox.TabIndex = 3;
            this.spaceBox.Text = "1000000";
            this.spaceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(201, 38);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
    }
}