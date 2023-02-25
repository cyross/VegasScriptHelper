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
            this.marginUnitLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.createOneEventCheck = new System.Windows.Forms.CheckBox();
            this.targetMediaBox = new System.Windows.Forms.ComboBox();
            this.targetMediaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.videoTrackBox = new System.Windows.Forms.ComboBox();
            this.audioTrackBox = new System.Windows.Forms.ComboBox();
            this.videoTrackLabel = new System.Windows.Forms.Label();
            this.audioTrackLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.canselButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.marginUnitLabel);
            this.panel1.Controls.Add(this.marginBox);
            this.panel1.Controls.Add(this.marginLabel);
            this.panel1.Controls.Add(this.createOneEventCheck);
            this.panel1.Controls.Add(this.targetMediaBox);
            this.panel1.Controls.Add(this.targetMediaLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.videoTrackBox);
            this.panel1.Controls.Add(this.audioTrackBox);
            this.panel1.Controls.Add(this.videoTrackLabel);
            this.panel1.Controls.Add(this.audioTrackLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 169);
            this.panel1.TabIndex = 0;
            // 
            // marginUnitLabel
            // 
            this.marginUnitLabel.AutoSize = true;
            this.marginUnitLabel.Location = new System.Drawing.Point(231, 118);
            this.marginUnitLabel.Name = "marginUnitLabel";
            this.marginUnitLabel.Size = new System.Drawing.Size(31, 12);
            this.marginUnitLabel.TabIndex = 10;
            this.marginUnitLabel.Text = "ミリ秒";
            // 
            // marginBox
            // 
            this.marginBox.Location = new System.Drawing.Point(125, 115);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(100, 19);
            this.marginBox.TabIndex = 9;
            this.marginBox.Text = "0";
            this.marginBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(14, 118);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(43, 12);
            this.marginLabel.TabIndex = 8;
            this.marginLabel.Text = "マージン";
            // 
            // createOneEventCheck
            // 
            this.createOneEventCheck.AutoSize = true;
            this.createOneEventCheck.Location = new System.Drawing.Point(16, 140);
            this.createOneEventCheck.Name = "createOneEventCheck";
            this.createOneEventCheck.Size = new System.Drawing.Size(303, 16);
            this.createOneEventCheck.TabIndex = 7;
            this.createOneEventCheck.Text = "オーディオトラック内の全イベントを跨いだビデオイベントを作る";
            this.createOneEventCheck.UseVisualStyleBackColor = true;
            // 
            // targetMediaBox
            // 
            this.targetMediaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetMediaBox.FormattingEnabled = true;
            this.targetMediaBox.Location = new System.Drawing.Point(125, 89);
            this.targetMediaBox.Name = "targetMediaBox";
            this.targetMediaBox.Size = new System.Drawing.Size(299, 20);
            this.targetMediaBox.TabIndex = 6;
            // 
            // targetMediaLabel
            // 
            this.targetMediaLabel.AutoSize = true;
            this.targetMediaLabel.Location = new System.Drawing.Point(14, 92);
            this.targetMediaLabel.Name = "targetMediaLabel";
            this.targetMediaLabel.Size = new System.Drawing.Size(63, 12);
            this.targetMediaLabel.TabIndex = 5;
            this.targetMediaLabel.Text = "対象メディア";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "(新規作成するときはトラック名を明記)";
            // 
            // videoTrackBox
            // 
            this.videoTrackBox.FormattingEnabled = true;
            this.videoTrackBox.Location = new System.Drawing.Point(125, 36);
            this.videoTrackBox.Name = "videoTrackBox";
            this.videoTrackBox.Size = new System.Drawing.Size(299, 20);
            this.videoTrackBox.TabIndex = 3;
            // 
            // audioTrackBox
            // 
            this.audioTrackBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioTrackBox.FormattingEnabled = true;
            this.audioTrackBox.Location = new System.Drawing.Point(125, 7);
            this.audioTrackBox.Name = "audioTrackBox";
            this.audioTrackBox.Size = new System.Drawing.Size(299, 20);
            this.audioTrackBox.TabIndex = 2;
            // 
            // videoTrackLabel
            // 
            this.videoTrackLabel.AutoSize = true;
            this.videoTrackLabel.Location = new System.Drawing.Point(14, 39);
            this.videoTrackLabel.Name = "videoTrackLabel";
            this.videoTrackLabel.Size = new System.Drawing.Size(87, 12);
            this.videoTrackLabel.TabIndex = 1;
            this.videoTrackLabel.Text = "対象ビデオトラック";
            // 
            // audioTrackLabel
            // 
            this.audioTrackLabel.AutoSize = true;
            this.audioTrackLabel.Location = new System.Drawing.Point(14, 10);
            this.audioTrackLabel.Name = "audioTrackLabel";
            this.audioTrackLabel.Size = new System.Drawing.Size(105, 12);
            this.audioTrackLabel.TabIndex = 0;
            this.audioTrackLabel.Text = "対象オーディオトラック";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(292, 187);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // canselButton
            // 
            this.canselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.canselButton.Location = new System.Drawing.Point(373, 187);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(75, 23);
            this.canselButton.TabIndex = 2;
            this.canselButton.Text = "CANSEL";
            this.canselButton.UseVisualStyleBackColor = true;
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 215);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingDialog";
            this.Text = "設定";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
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
    }
}