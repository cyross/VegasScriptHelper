namespace VegasScriptExpandFirstVideoEvent
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.audioTrack = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.audioTrackLabel = new System.Windows.Forms.Label();
            this.videoTrack = new System.Windows.Forms.ComboBox();
            this.videoTrackLabel = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.audioTrack);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.audioTrackLabel);
            this.panel1.Controls.Add(this.videoTrack);
            this.panel1.Controls.Add(this.videoTrackLabel);
            this.panel1.Controls.Add(this.millisecondLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 100);
            this.panel1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(344, 67);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(24, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // audioTrack
            // 
            this.audioTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioTrack.FormattingEnabled = true;
            this.audioTrack.Location = new System.Drawing.Point(128, 37);
            this.audioTrack.Margin = new System.Windows.Forms.Padding(4);
            this.audioTrack.Name = "audioTrack";
            this.audioTrack.Size = new System.Drawing.Size(240, 25);
            this.audioTrack.TabIndex = 8;
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Location = new System.Drawing.Point(315, 67);
            this.OKButton.Margin = new System.Windows.Forms.Padding(8);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(24, 24);
            this.OKButton.TabIndex = 1;
            this.OKButton.UseVisualStyleBackColor = false;
            // 
            // audioTrackLabel
            // 
            this.audioTrackLabel.AutoSize = true;
            this.audioTrackLabel.Location = new System.Drawing.Point(7, 40);
            this.audioTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.audioTrackLabel.Name = "audioTrackLabel";
            this.audioTrackLabel.Size = new System.Drawing.Size(116, 17);
            this.audioTrackLabel.TabIndex = 7;
            this.audioTrackLabel.Text = "オーディオトラック";
            // 
            // videoTrack
            // 
            this.videoTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoTrack.FormattingEnabled = true;
            this.videoTrack.Location = new System.Drawing.Point(128, 4);
            this.videoTrack.Margin = new System.Windows.Forms.Padding(4);
            this.videoTrack.Name = "videoTrack";
            this.videoTrack.Size = new System.Drawing.Size(240, 25);
            this.videoTrack.TabIndex = 6;
            // 
            // videoTrackLabel
            // 
            this.videoTrackLabel.AutoSize = true;
            this.videoTrackLabel.Location = new System.Drawing.Point(7, 6);
            this.videoTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.videoTrackLabel.Name = "videoTrackLabel";
            this.videoTrackLabel.Size = new System.Drawing.Size(92, 17);
            this.videoTrackLabel.TabIndex = 5;
            this.videoTrackLabel.Text = "ビデオトラック";
            // 
            // millisecondLabel
            // 
            this.millisecondLabel.AutoSize = true;
            this.millisecondLabel.Location = new System.Drawing.Point(200, 71);
            this.millisecondLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.millisecondLabel.Name = "millisecondLabel";
            this.millisecondLabel.Size = new System.Drawing.Size(44, 17);
            this.millisecondLabel.TabIndex = 4;
            this.millisecondLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.marginBox.Location = new System.Drawing.Point(128, 70);
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
            this.marginLabel.Location = new System.Drawing.Point(4, 71);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(56, 17);
            this.marginLabel.TabIndex = 2;
            this.marginLabel.Text = "マージン";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 106);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "イベントの長さを音声トラックに合わせる";
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
        private System.Windows.Forms.ComboBox videoTrack;
        private System.Windows.Forms.Label videoTrackLabel;
        private System.Windows.Forms.Label audioTrackLabel;
        private System.Windows.Forms.ComboBox audioTrack;
    }
}