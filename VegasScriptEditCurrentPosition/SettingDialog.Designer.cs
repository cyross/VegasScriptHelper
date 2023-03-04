namespace VegasScriptEditCurrentPosition
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDialog));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timeFormatGroup = new System.Windows.Forms.GroupBox();
            this.hmsfFormatLabel = new System.Windows.Forms.Label();
            this.hmsfFormat = new System.Windows.Forms.RadioButton();
            this.hmsmsFormatLabel = new System.Windows.Forms.Label();
            this.hmsmsFormat = new System.Windows.Forms.RadioButton();
            this.currentBox = new System.Windows.Forms.TextBox();
            this.currentLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.getCurrentButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.timeFormatGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.getCurrentButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.timeFormatGroup);
            this.mainPanel.Controls.Add(this.currentBox);
            this.mainPanel.Controls.Add(this.currentLabel);
            this.mainPanel.Location = new System.Drawing.Point(2, 4);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(276, 112);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Enter += new System.EventHandler(this.OnClickUpdateButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "(テキストボックス内でEnterキーを押して更新)";
            // 
            // timeFormatGroup
            // 
            this.timeFormatGroup.BackColor = System.Drawing.Color.Transparent;
            this.timeFormatGroup.Controls.Add(this.hmsfFormatLabel);
            this.timeFormatGroup.Controls.Add(this.hmsfFormat);
            this.timeFormatGroup.Controls.Add(this.hmsmsFormatLabel);
            this.timeFormatGroup.Controls.Add(this.hmsmsFormat);
            this.timeFormatGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeFormatGroup.ForeColor = System.Drawing.Color.LemonChiffon;
            this.timeFormatGroup.Location = new System.Drawing.Point(3, 3);
            this.timeFormatGroup.Name = "timeFormatGroup";
            this.timeFormatGroup.Size = new System.Drawing.Size(267, 44);
            this.timeFormatGroup.TabIndex = 17;
            this.timeFormatGroup.TabStop = false;
            this.timeFormatGroup.Text = "書式";
            // 
            // hmsfFormatLabel
            // 
            this.hmsfFormatLabel.AutoSize = true;
            this.hmsfFormatLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsfFormatLabel.ForeColor = System.Drawing.Color.White;
            this.hmsfFormatLabel.Location = new System.Drawing.Point(140, 16);
            this.hmsfFormatLabel.Name = "hmsfFormatLabel";
            this.hmsfFormatLabel.Size = new System.Drawing.Size(119, 17);
            this.hmsfFormatLabel.TabIndex = 19;
            this.hmsfFormatLabel.Text = "HH:MM:SS.FRAME";
            // 
            // hmsfFormat
            // 
            this.hmsfFormat.AutoSize = true;
            this.hmsfFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsfFormat.ForeColor = System.Drawing.Color.Black;
            this.hmsfFormat.Location = new System.Drawing.Point(125, 19);
            this.hmsfFormat.Name = "hmsfFormat";
            this.hmsfFormat.Size = new System.Drawing.Size(13, 12);
            this.hmsfFormat.TabIndex = 19;
            this.hmsfFormat.UseVisualStyleBackColor = true;
            this.hmsfFormat.CheckedChanged += new System.EventHandler(this.OnChangeFormatRadiobutton);
            // 
            // hmsmsFormatLabel
            // 
            this.hmsmsFormatLabel.AutoSize = true;
            this.hmsmsFormatLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsmsFormatLabel.ForeColor = System.Drawing.Color.White;
            this.hmsmsFormatLabel.Location = new System.Drawing.Point(21, 16);
            this.hmsmsFormatLabel.Name = "hmsmsFormatLabel";
            this.hmsmsFormatLabel.Size = new System.Drawing.Size(95, 17);
            this.hmsmsFormatLabel.TabIndex = 18;
            this.hmsmsFormatLabel.Text = "HH:MM:SS.MS";
            // 
            // hmsmsFormat
            // 
            this.hmsmsFormat.AutoSize = true;
            this.hmsmsFormat.Checked = true;
            this.hmsmsFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hmsmsFormat.ForeColor = System.Drawing.Color.Black;
            this.hmsmsFormat.Location = new System.Drawing.Point(6, 19);
            this.hmsmsFormat.Name = "hmsmsFormat";
            this.hmsmsFormat.Size = new System.Drawing.Size(13, 12);
            this.hmsmsFormat.TabIndex = 18;
            this.hmsmsFormat.TabStop = true;
            this.hmsmsFormat.UseVisualStyleBackColor = true;
            this.hmsmsFormat.CheckedChanged += new System.EventHandler(this.OnChangeFormatRadiobutton);
            // 
            // currentBox
            // 
            this.currentBox.Location = new System.Drawing.Point(69, 57);
            this.currentBox.Name = "currentBox";
            this.currentBox.Size = new System.Drawing.Size(96, 25);
            this.currentBox.TabIndex = 15;
            this.currentBox.Text = "23:59:59.999";
            this.currentBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyEntered);
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentLabel.ForeColor = System.Drawing.Color.White;
            this.currentLabel.Location = new System.Drawing.Point(6, 60);
            this.currentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(56, 17);
            this.currentLabel.TabIndex = 0;
            this.currentLabel.Text = "現在位置";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // getCurrentButton
            // 
            this.getCurrentButton.BackColor = System.Drawing.Color.Transparent;
            this.getCurrentButton.FlatAppearance.BorderSize = 0;
            this.getCurrentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getCurrentButton.ForeColor = System.Drawing.Color.White;
            this.getCurrentButton.Location = new System.Drawing.Point(196, 58);
            this.getCurrentButton.Name = "getCurrentButton";
            this.getCurrentButton.Size = new System.Drawing.Size(47, 23);
            this.getCurrentButton.TabIndex = 19;
            this.getCurrentButton.Text = "取得";
            this.getCurrentButton.UseVisualStyleBackColor = false;
            this.getCurrentButton.Click += new System.EventHandler(this.OnClickUpdateButton);
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "現在位置の設定";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.timeFormatGroup.ResumeLayout(false);
            this.timeFormatGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox currentBox;
        private System.Windows.Forms.RadioButton hmsmsFormat;
        private System.Windows.Forms.GroupBox timeFormatGroup;
        private System.Windows.Forms.RadioButton hmsfFormat;
        private System.Windows.Forms.Label hmsfFormatLabel;
        private System.Windows.Forms.Label hmsmsFormatLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getCurrentButton;
    }
}