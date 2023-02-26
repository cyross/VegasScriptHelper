namespace VegasScriptHelper
{
    partial class TipsViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipsViewForm));
            this.rtfPanel = new System.Windows.Forms.Panel();
            this.markDownBrowser = new System.Windows.Forms.WebBrowser();
            this.rtfPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfPanel
            // 
            this.rtfPanel.Controls.Add(this.markDownBrowser);
            this.rtfPanel.Location = new System.Drawing.Point(1, 2);
            this.rtfPanel.Name = "rtfPanel";
            this.rtfPanel.Size = new System.Drawing.Size(1044, 788);
            this.rtfPanel.TabIndex = 1;
            // 
            // markDownBrowser
            // 
            this.markDownBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markDownBrowser.Location = new System.Drawing.Point(0, 0);
            this.markDownBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.markDownBrowser.Name = "markDownBrowser";
            this.markDownBrowser.Size = new System.Drawing.Size(1044, 788);
            this.markDownBrowser.TabIndex = 0;
            // 
            // TipsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 791);
            this.Controls.Add(this.rtfPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TipsViewForm";
            this.Text = "Tips";
            this.rtfPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel rtfPanel;
        private System.Windows.Forms.WebBrowser markDownBrowser;
    }
}