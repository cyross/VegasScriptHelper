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
            this.targetVideoTrackLabel = new System.Windows.Forms.Label();
            this.millisecondLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.targetVideoTrack = new System.Windows.Forms.ComboBox();
            this.targetAudioTrack = new System.Windows.Forms.ComboBox();
            this.targetAudioTrackLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.targetAudioTrack);
            this.panel1.Controls.Add(this.targetAudioTrackLabel);
            this.panel1.Controls.Add(this.targetVideoTrack);
            this.panel1.Controls.Add(this.targetVideoTrackLabel);
            this.panel1.Controls.Add(this.millisecondLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 84);
            this.panel1.TabIndex = 0;
            // 
            // targetVideoTrackLabel
            // 
            this.targetVideoTrackLabel.AutoSize = true;
            this.targetVideoTrackLabel.Location = new System.Drawing.Point(10, 7);
            this.targetVideoTrackLabel.Name = "targetVideoTrackLabel";
            this.targetVideoTrackLabel.Size = new System.Drawing.Size(60, 12);
            this.targetVideoTrackLabel.TabIndex = 5;
            this.targetVideoTrackLabel.Text = "字幕トラック";
            // 
            // millisecondLabel
            // 
            this.millisecondLabel.AutoSize = true;
            this.millisecondLabel.Location = new System.Drawing.Point(205, 60);
            this.millisecondLabel.Name = "millisecondLabel";
            this.millisecondLabel.Size = new System.Drawing.Size(31, 12);
            this.millisecondLabel.TabIndex = 4;
            this.millisecondLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.Location = new System.Drawing.Point(123, 57);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(76, 19);
            this.marginBox.TabIndex = 3;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(10, 60);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(89, 12);
            this.marginLabel.TabIndex = 2;
            this.marginLabel.Text = "字幕側のマージン";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(426, 92);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(507, 92);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cansel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // targetVideoTrack
            // 
            this.targetVideoTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetVideoTrack.FormattingEnabled = true;
            this.targetVideoTrack.Location = new System.Drawing.Point(123, 3);
            this.targetVideoTrack.Name = "targetVideoTrack";
            this.targetVideoTrack.Size = new System.Drawing.Size(454, 20);
            this.targetVideoTrack.TabIndex = 6;
            // 
            // targetAudioTrack
            // 
            this.targetAudioTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetAudioTrack.FormattingEnabled = true;
            this.targetAudioTrack.Location = new System.Drawing.Point(123, 31);
            this.targetAudioTrack.Name = "targetAudioTrack";
            this.targetAudioTrack.Size = new System.Drawing.Size(454, 20);
            this.targetAudioTrack.TabIndex = 8;
            // 
            // targetAudioTrackLabel
            // 
            this.targetAudioTrackLabel.AutoSize = true;
            this.targetAudioTrackLabel.Location = new System.Drawing.Point(10, 35);
            this.targetAudioTrackLabel.Name = "targetAudioTrackLabel";
            this.targetAudioTrackLabel.Size = new System.Drawing.Size(64, 12);
            this.targetAudioTrackLabel.TabIndex = 7;
            this.targetAudioTrackLabel.Text = "ボイストラック";
            // 
            // VegasScriptSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 124);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.panel1);
            this.Name = "VegasScriptSettingDialog";
            this.Text = "字幕位置・長さ合わせの設定";
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