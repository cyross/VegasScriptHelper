using System;
using System.Runtime;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VegasScriptHelper;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace VegasScriptCreateJimaku
{
    public enum PrefixBehaviorType
    {
        Remain = 0,
        Delete = 1,
        NewEvent = 2
    }

    public partial class SettingDialog : Form
    {
        private PrivateFontCollection myFontCollection = new PrivateFontCollection();

        public SettingDialog()
        {
            InitializeComponent();

            myFontCollection.AddFontFile(VegasHelperUtility.GetExecFilepath(VegasHelper.FONT_FILENAME));

            Font f_main = new Font(myFontCollection.Families[0], 9);
            Font = f_main;

            Font f_bold = new Font(myFontCollection.Families[0], 9, FontStyle.Bold);
            audioTrackNameNoticeLabel.Font = f_bold;

            Font f_input = new Font(myFontCollection.Families[0], 8);
            audioFileFolderBox.Font = f_input;
            jimakuFilePathBox.Font = f_input;
            jimakuBackgroundMediaBox.Font = f_input;
            actorBackgroundMediaBox.Font = f_input;

            SetColorToolTip(jimakuColorBox);
            SetColorToolTip(jimakuOutlineColorBox);
            SetColorToolTip(actorColorBox);
            SetColorToolTip(actorOutlineColorBox);
        }

        public PrefixBehaviorType PrefixBehavior
        {
            get {
                if (remainActorName.Checked)
                {
                    return PrefixBehaviorType.Remain;
                }
                if (deleteActorName.Checked)
                {
                    return PrefixBehaviorType.Delete;
                }
                return PrefixBehaviorType.NewEvent;
            }
            set {
                UpdatePrefixBehavor(
                    value == PrefixBehaviorType.Remain,
                    value == PrefixBehaviorType.Delete,
                    value == PrefixBehaviorType.NewEvent);
            }
        }

        private void UpdatePrefixBehavor(bool remain, bool delete, bool newEvent)
        {
            remainActorName.Checked = remain;
            deleteActorName.Checked = delete;
            createNewEvent.Checked = newEvent;
        }

        private void SetComboBox(ComboBox combobox, KeyListInfo klStruct)
        {
            SetComboBox(combobox, klStruct.Keys, klStruct.FirstKey);
        }

        private void SetComboBox(ComboBox combobox, List<string> list, string text = null)
        {
            combobox.Items.Clear();
            combobox.Items.AddRange(list.ToArray());

            if(text != null) { combobox.Text = text; }
        }

        private void SetBoxValue<T>(TextBox box, T value)
        {
            box.Text = value.ToString();
        }

        private T GetBoxValue<T>(TextBox box)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(box.Text);
        }

        private void SetColorToolTip(Control control)
        {
            colorTooltip.SetToolTip(control, "ボックスをクリックすると色の設定ができます");
        }

        private void CreateBGEnabledChange(
            bool enabled,
            ComboBox trackBox, ComboBox mediaBox, TextBox marginBox, CheckBox useCheck, ComboBox bgMediaBinBox)
        {
            trackBox.Enabled = enabled;
            mediaBox.Enabled = enabled;
            marginBox.Enabled = enabled;
            useCheck.Enabled = enabled;
            bgMediaBinBox.Enabled = enabled;
        }
    }
}
