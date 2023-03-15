using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptHyphenation
{
    public class EntryPoint : IEntryPoint
    {
        // 設定ダイアログが不要なときは削除
        private static SettingDialog settingDialog = null;

        public void FromVegas(Vegas vegas)
        {
            // ヘルパクラスのオブジェクト生成は必須
            VegasHelper helper = VegasHelper.Instance(vegas);

            using (var block = new UndoBlock("Hyphenation"))
            {
                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.HyphenationLength = helper.Settings[SettingName.WdHyphe.Length];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                int length = settingDialog.HyphenationLength;

                VideoTrack selected = helper.SelectedVideoTrack(false);

                if(selected == null || selected.Events.Count == 0) { return; }

                foreach(var trackEvent in selected.Events)
                {
                    Takes takes = trackEvent.Takes;

                    if(takes.Count == 0) { continue; }

                    var take = takes[0];

                    Media media = take.Media;

                    if (media == null) { continue; }

                    OFXStringParameter strparam = helper.GetOFXStringParameter(media, false);

                    if(strparam == null) { continue; }

                    helper.SetTextToRtfBox(strparam);

                    helper.RtfLines = helper.Hyphenation(helper.RtfLines, length);

                    helper.SetTextFromRtfBox(strparam);
                }

                helper.Settings[SettingName.WdHyphe.Length] = length;
            }
            helper.Settings.Save();
        }
    }
}
