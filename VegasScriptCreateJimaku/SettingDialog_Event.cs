using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasScriptCreateJimaku
{
    public partial class SettingDialog : Form
    {
        private void ColorBoxClicked(PictureBox box, ColorDialog dialog)
        {
            dialog.Color = box.BackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                box.BackColor = dialog.Color;
            }
        }

        private void AudioFileFolderButton_Clicked(object sender, EventArgs e)
        {
            audioFileFolderBrowser.SelectedPath = audioFileFolderBox.Text;
            if (audioFileFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                audioFileFolderBox.Text = audioFileFolderBrowser.SelectedPath;
            }
        }

        private void JimakuFileDialogOpenButton_Clicked(object sender, EventArgs e)
        {
            string filePath = jimakuFilePathBox.Text;

            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("指定のファイルパスは存在していません: {0}", filePath));
            }

            jimakuFileBrowser.InitialDirectory = Path.GetDirectoryName(filePath);
            jimakuFileBrowser.FileName = Path.GetFileName(filePath);
            if (jimakuFileBrowser.ShowDialog() == DialogResult.OK)
            {
                jimakuFilePathBox.Text = jimakuFileBrowser.FileName;
            }
        }
        private void UseAudioMediaBin_Checked(object sender, EventArgs e)
        {
            audioMediaBinPanel.Enabled = useAudioMediaBin.Checked;
        }

        private void UseJimakuMediaBin_Checked(object sender, EventArgs e)
        {
            jimakuMediaBinPanel.Enabled = useJimakuMediaBin.Checked;
        }

        private void UseActorMediaBin_Checked(object sender, EventArgs e)
        {
            actorMediaBinPanel.Enabled = useActorMediaBin.Checked;
        }

        private void CreateJimakuBG_Checked(object sender, EventArgs e)
        {
            jimakuBGPanel.Enabled = createJimakuBackground.Checked;
        }

        private void CreateActorBG_Checked(object sender, EventArgs e)
        {
            actorBGPanel.Enabled = createActorBackground.Checked;
        }

        private void UseJimakuBGMediaBin_Checked(object sender, EventArgs e)
        {
            jimakuBGMediaBinPanel.Enabled = useJimakuMediaBin.Checked;
        }

        private void UseActorBGMediaBin_Checked(object sender, EventArgs e)
        {
            actorBGMediaBinPanel.Enabled = useActorMediaBin.Checked;
        }

        private void JimakuColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(jimakuColorBox, jimakuColorDialog);
        }

        private void JimakuOutlineColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(jimakuOutlineColorBox, jimakuOutlineColorDialog);
        }

        private void ActorColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(actorColorBox, actorColorDialog);
        }

        private void ActorOutlineColorBox_Clicked(object sender, EventArgs e)
        {
            ColorBoxClicked(actorOutlineColorBox, actorOutlineColorDialog);
        }

        private void Tachie_CheckedChanged(object sender, EventArgs e)
        {
            tachiePanel.Enabled = tachieCheck.Checked;
        }
    }
}
