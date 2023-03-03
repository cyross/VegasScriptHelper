namespace VegasScriptRemoveJimakuPrefix
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
            this.removeJimakuBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.removeJimakuLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.canselButton);
            this.panel1.Controls.Add(this.removeJimakuBox);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.removeJimakuLabel);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 38);
            this.panel1.TabIndex = 0;
            // 
            // canselButton
            // 
            this.canselButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canselButton.BackgroundImage")));
            this.canselButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(383, 8);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(24, 24);
            this.canselButton.TabIndex = 2;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // removeJimakuBox
            // 
            this.removeJimakuBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeJimakuBox.FormattingEnabled = true;
            this.removeJimakuBox.Location = new System.Drawing.Point(70, 7);
            this.removeJimakuBox.Margin = new System.Windows.Forms.Padding(4);
            this.removeJimakuBox.Name = "removeJimakuBox";
            this.removeJimakuBox.Size = new System.Drawing.Size(240, 25);
            this.removeJimakuBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(355, 8);
            this.okButton.Margin = new System.Windows.Forms.Padding(8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(24, 24);
            this.okButton.TabIndex = 1;
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // removeJimakuLabel
            // 
            this.removeJimakuLabel.AutoSize = true;
            this.removeJimakuLabel.Location = new System.Drawing.Point(6, 11);
            this.removeJimakuLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.removeJimakuLabel.Name = "removeJimakuLabel";
            this.removeJimakuLabel.Size = new System.Drawing.Size(56, 17);
            this.removeJimakuLabel.TabIndex = 0;
            this.removeJimakuLabel.Text = "トラック";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(422, 45);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "接頭辞削除";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.ComboBox removeJimakuBox;
        private System.Windows.Forms.Label removeJimakuLabel;
    }
}