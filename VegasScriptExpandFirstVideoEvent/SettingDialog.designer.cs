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
            this.millisecondLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.videoTrackLabel = new System.Windows.Forms.Label();
            this.videoTrack = new System.Windows.Forms.ComboBox();
            this.audioTrackLabel = new System.Windows.Forms.Label();
            this.audioTrack = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.audioTrack);
            this.panel1.Controls.Add(this.audioTrackLabel);
            this.panel1.Controls.Add(this.videoTrack);
            this.panel1.Controls.Add(this.videoTrackLabel);
            this.panel1.Controls.Add(this.millisecondLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 96);
            this.panel1.TabIndex = 0;
            // 
            // millisecondLabel
            // 
            this.millisecondLabel.AutoSize = true;
            this.millisecondLabel.Location = new System.Drawing.Point(222, 68);
            this.millisecondLabel.Name = "millisecondLabel";
            this.millisecondLabel.Size = new System.Drawing.Size(31, 12);
            this.millisecondLabel.TabIndex = 4;
            this.millisecondLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.Location = new System.Drawing.Point(140, 65);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(76, 19);
            this.marginBox.TabIndex = 3;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(6, 68);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(128, 12);
            this.marginLabel.TabIndex = 2;
            this.marginLabel.Text = "ビデオイベント側のマージン";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(332, 104);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(413, 104);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cansel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // videoTrackLabel
            // 
            this.videoTrackLabel.AutoSize = true;
            this.videoTrackLabel.Location = new System.Drawing.Point(10, 13);
            this.videoTrackLabel.Name = "videoTrackLabel";
            this.videoTrackLabel.Size = new System.Drawing.Size(63, 12);
            this.videoTrackLabel.TabIndex = 5;
            this.videoTrackLabel.Text = "ビデオトラック";
            // 
            // videoTrack
            // 
            this.videoTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoTrack.FormattingEnabled = true;
            this.videoTrack.Location = new System.Drawing.Point(110, 10);
            this.videoTrack.Name = "videoTrack";
            this.videoTrack.Size = new System.Drawing.Size(348, 20);
            this.videoTrack.TabIndex = 6;
            // 
            // audioTrackLabel
            // 
            this.audioTrackLabel.AutoSize = true;
            this.audioTrackLabel.Location = new System.Drawing.Point(10, 42);
            this.audioTrackLabel.Name = "audioTrackLabel";
            this.audioTrackLabel.Size = new System.Drawing.Size(81, 12);
            this.audioTrackLabel.TabIndex = 7;
            this.audioTrackLabel.Text = "オーディオトラック";
            // 
            // audioTrack
            // 
            this.audioTrack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioTrack.FormattingEnabled = true;
            this.audioTrack.Location = new System.Drawing.Point(110, 39);
            this.audioTrack.Name = "audioTrack";
            this.audioTrack.Size = new System.Drawing.Size(348, 20);
            this.audioTrack.TabIndex = 8;
            // 
            // VegasScriptSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 134);
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
        private System.Windows.Forms.ComboBox videoTrack;
        private System.Windows.Forms.Label videoTrackLabel;
        private System.Windows.Forms.Label audioTrackLabel;
        private System.Windows.Forms.ComboBox audioTrack;
    }
}