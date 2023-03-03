namespace VegasScriptCreateJimakuBackground
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
            this.createOneEventCheckLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.marginUnitLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.createOneEventCheck = new System.Windows.Forms.CheckBox();
            this.targetMediaBox = new System.Windows.Forms.ComboBox();
            this.targetMediaLabel = new System.Windows.Forms.Label();
            this.noticLabel = new System.Windows.Forms.Label();
            this.videoTrackBox = new System.Windows.Forms.ComboBox();
            this.audioTrackBox = new System.Windows.Forms.ComboBox();
            this.videoTrackLabel = new System.Windows.Forms.Label();
            this.audioTrackLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.createOneEventCheckLabel);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.canselButton);
            this.panel1.Controls.Add(this.marginUnitLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.Controls.Add(this.createOneEventCheck);
            this.panel1.Controls.Add(this.targetMediaBox);
            this.panel1.Controls.Add(this.targetMediaLabel);
            this.panel1.Controls.Add(this.noticLabel);
            this.panel1.Controls.Add(this.videoTrackBox);
            this.panel1.Controls.Add(this.audioTrackBox);
            this.panel1.Controls.Add(this.videoTrackLabel);
            this.panel1.Controls.Add(this.audioTrackLabel);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 174);
            this.panel1.TabIndex = 0;
            // 
            // createOneEventCheckLabel
            // 
            this.createOneEventCheckLabel.AutoSize = true;
            this.createOneEventCheckLabel.Location = new System.Drawing.Point(22, 149);
            this.createOneEventCheckLabel.Name = "createOneEventCheckLabel";
            this.createOneEventCheckLabel.Size = new System.Drawing.Size(248, 17);
            this.createOneEventCheckLabel.TabIndex = 11;
            this.createOneEventCheckLabel.Text = "字幕・声優名の背景は全セリフを跨いで生成";
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(400, 146);
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
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.FlatAppearance.BorderSize = 0;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(440, 146);
            this.canselButton.Margin = new System.Windows.Forms.Padding(8);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(25, 24);
            this.canselButton.TabIndex = 2;
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // marginUnitLabel
            // 
            this.marginUnitLabel.AutoSize = true;
            this.marginUnitLabel.Location = new System.Drawing.Point(218, 122);
            this.marginUnitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marginUnitLabel.Name = "marginUnitLabel";
            this.marginUnitLabel.Size = new System.Drawing.Size(44, 17);
            this.marginUnitLabel.TabIndex = 10;
            this.marginUnitLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.marginBox.Location = new System.Drawing.Point(146, 122);
            this.marginBox.Margin = new System.Windows.Forms.Padding(4);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(64, 18);
            this.marginBox.TabIndex = 9;
            this.marginBox.Text = "1000000";
            this.marginBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(88, 122);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(56, 17);
            this.marginLabel.TabIndex = 8;
            this.marginLabel.Text = "マージン";
            // 
            // createOneEventCheck
            // 
            this.createOneEventCheck.AutoSize = true;
            this.createOneEventCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createOneEventCheck.ForeColor = System.Drawing.Color.Crimson;
            this.createOneEventCheck.Location = new System.Drawing.Point(9, 153);
            this.createOneEventCheck.Margin = new System.Windows.Forms.Padding(4);
            this.createOneEventCheck.Name = "createOneEventCheck";
            this.createOneEventCheck.Size = new System.Drawing.Size(12, 11);
            this.createOneEventCheck.TabIndex = 7;
            this.createOneEventCheck.UseVisualStyleBackColor = true;
            // 
            // targetMediaBox
            // 
            this.targetMediaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetMediaBox.DropDownWidth = 640;
            this.targetMediaBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetMediaBox.FormattingEnabled = true;
            this.targetMediaBox.Location = new System.Drawing.Point(146, 89);
            this.targetMediaBox.Margin = new System.Windows.Forms.Padding(4);
            this.targetMediaBox.Name = "targetMediaBox";
            this.targetMediaBox.Size = new System.Drawing.Size(320, 25);
            this.targetMediaBox.TabIndex = 6;
            // 
            // targetMediaLabel
            // 
            this.targetMediaLabel.AutoSize = true;
            this.targetMediaLabel.Location = new System.Drawing.Point(64, 92);
            this.targetMediaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetMediaLabel.Name = "targetMediaLabel";
            this.targetMediaLabel.Size = new System.Drawing.Size(80, 17);
            this.targetMediaLabel.TabIndex = 5;
            this.targetMediaLabel.Text = "対象メディア";
            // 
            // noticLabel
            // 
            this.noticLabel.AutoSize = true;
            this.noticLabel.Location = new System.Drawing.Point(143, 68);
            this.noticLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noticLabel.Name = "noticLabel";
            this.noticLabel.Size = new System.Drawing.Size(222, 17);
            this.noticLabel.TabIndex = 4;
            this.noticLabel.Text = "(新規作成するときはトラック名を明記)";
            // 
            // videoTrackBox
            // 
            this.videoTrackBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoTrackBox.FormattingEnabled = true;
            this.videoTrackBox.Location = new System.Drawing.Point(146, 39);
            this.videoTrackBox.Margin = new System.Windows.Forms.Padding(4);
            this.videoTrackBox.Name = "videoTrackBox";
            this.videoTrackBox.Size = new System.Drawing.Size(240, 25);
            this.videoTrackBox.TabIndex = 3;
            this.videoTrackBox.Text = "TEST";
            // 
            // audioTrackBox
            // 
            this.audioTrackBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioTrackBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioTrackBox.FormattingEnabled = true;
            this.audioTrackBox.Location = new System.Drawing.Point(146, 7);
            this.audioTrackBox.Margin = new System.Windows.Forms.Padding(4);
            this.audioTrackBox.Name = "audioTrackBox";
            this.audioTrackBox.Size = new System.Drawing.Size(240, 25);
            this.audioTrackBox.TabIndex = 2;
            // 
            // videoTrackLabel
            // 
            this.videoTrackLabel.AutoSize = true;
            this.videoTrackLabel.Location = new System.Drawing.Point(28, 42);
            this.videoTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.videoTrackLabel.Name = "videoTrackLabel";
            this.videoTrackLabel.Size = new System.Drawing.Size(116, 17);
            this.videoTrackLabel.TabIndex = 1;
            this.videoTrackLabel.Text = "対象ビデオトラック";
            // 
            // audioTrackLabel
            // 
            this.audioTrackLabel.AutoSize = true;
            this.audioTrackLabel.Location = new System.Drawing.Point(4, 10);
            this.audioTrackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.audioTrackLabel.Name = "audioTrackLabel";
            this.audioTrackLabel.Size = new System.Drawing.Size(140, 17);
            this.audioTrackLabel.TabIndex = 0;
            this.audioTrackLabel.Text = "対象オーディオトラック";
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 181);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("M PLUS 1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字幕背景を作成";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label noticLabel;
        private System.Windows.Forms.ComboBox videoTrackBox;
        private System.Windows.Forms.ComboBox audioTrackBox;
        private System.Windows.Forms.Label videoTrackLabel;
        private System.Windows.Forms.Label audioTrackLabel;
        private System.Windows.Forms.Label targetMediaLabel;
        private System.Windows.Forms.ComboBox targetMediaBox;
        private System.Windows.Forms.CheckBox createOneEventCheck;
        private System.Windows.Forms.Label marginUnitLabel;
        private System.Windows.Forms.TextBox marginBox;
        private System.Windows.Forms.Label marginLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button canselButton;
        private System.Windows.Forms.Label createOneEventCheckLabel;
    }
}