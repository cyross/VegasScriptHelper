namespace VegasScriptAssignVideoEventFromAudioEvent
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.targetAudioTrack = new System.Windows.Forms.ComboBox();
            this.targetAudioTrackLabel = new System.Windows.Forms.Label();
            this.targetVideoTrack = new System.Windows.Forms.ComboBox();
            this.targetVideoTrackLabel = new System.Windows.Forms.Label();
            this.millisecondLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.targetAudioTrack);
            this.panel1.Controls.Add(this.targetAudioTrackLabel);
            this.panel1.Controls.Add(this.targetVideoTrack);
            this.panel1.Controls.Add(this.targetVideoTrackLabel);
            this.panel1.Controls.Add(this.millisecondLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 93);
            this.panel1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(340, 61);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(24, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Location = new System.Drawing.Point(311, 61);
            this.OKButton.Margin = new System.Windows.Forms.Padding(8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(24, 24);
            this.OKButton.TabIndex = 1;
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // targetAudioTrack
            // 
            this.targetAudioTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetAudioTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetAudioTrack.FormattingEnabled = true;
            this.targetAudioTrack.Location = new System.Drawing.Point(124, 4);
            this.targetAudioTrack.Margin = new System.Windows.Forms.Padding(4);
            this.targetAudioTrack.Name = "targetAudioTrack";
            this.targetAudioTrack.Size = new System.Drawing.Size(240, 25);
            this.targetAudioTrack.TabIndex = 8;
            // 
            // targetAudioTrackLabel
            // 
            this.targetAudioTrackLabel.AutoSize = true;
            this.targetAudioTrackLabel.Location = new System.Drawing.Point(36, 7);
            this.targetAudioTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetAudioTrackLabel.Name = "targetAudioTrackLabel";
            this.targetAudioTrackLabel.Size = new System.Drawing.Size(80, 17);
            this.targetAudioTrackLabel.TabIndex = 7;
            this.targetAudioTrackLabel.Text = "音声トラック";
            // 
            // targetVideoTrack
            // 
            this.targetVideoTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetVideoTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetVideoTrack.FormattingEnabled = true;
            this.targetVideoTrack.Location = new System.Drawing.Point(124, 32);
            this.targetVideoTrack.Margin = new System.Windows.Forms.Padding(4);
            this.targetVideoTrack.Name = "targetVideoTrack";
            this.targetVideoTrack.Size = new System.Drawing.Size(240, 25);
            this.targetVideoTrack.TabIndex = 6;
            // 
            // targetVideoTrackLabel
            // 
            this.targetVideoTrackLabel.AutoSize = true;
            this.targetVideoTrackLabel.Location = new System.Drawing.Point(36, 35);
            this.targetVideoTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetVideoTrackLabel.Name = "targetVideoTrackLabel";
            this.targetVideoTrackLabel.Size = new System.Drawing.Size(80, 17);
            this.targetVideoTrackLabel.TabIndex = 5;
            this.targetVideoTrackLabel.Text = "字幕トラック";
            // 
            // millisecondLabel
            // 
            this.millisecondLabel.AutoSize = true;
            this.millisecondLabel.Location = new System.Drawing.Point(196, 61);
            this.millisecondLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.millisecondLabel.Name = "millisecondLabel";
            this.millisecondLabel.Size = new System.Drawing.Size(44, 17);
            this.millisecondLabel.TabIndex = 4;
            this.millisecondLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.marginBox.Location = new System.Drawing.Point(124, 61);
            this.marginBox.Margin = new System.Windows.Forms.Padding(4);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(64, 18);
            this.marginBox.TabIndex = 3;
            this.marginBox.Text = "1000000";
            this.marginBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(12, 61);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(104, 17);
            this.marginLabel.TabIndex = 2;
            this.marginLabel.Text = "字幕側のマージン";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 98);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字幕位置・長さ合わせ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label millisecondLabel;
        private System.Windows.Forms.TextBox marginBox;
        private System.Windows.Forms.Label marginLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label targetVideoTrackLabel;
        private System.Windows.Forms.ComboBox targetVideoTrack;
        private System.Windows.Forms.ComboBox targetAudioTrack;
        private System.Windows.Forms.Label targetAudioTrackLabel;
    }
}