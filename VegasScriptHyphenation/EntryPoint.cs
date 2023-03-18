using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;
using VegasScriptHelper.ExtProc.Jimaku;
using VegasScriptHelper.Interfaces;
using VegasScriptHelper.Settings;

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
            Hyphenazer hyphenazer = new Hyphenazer(helper);

            using (var block = new UndoBlock("Hyphenation"))
            {
                if (settingDialog == null) { settingDialog = new SettingDialog(); }

                settingDialog.HyphenationLength = helper.Config[Names.WdHyphe.Length];

                if (settingDialog.ShowDialog() == DialogResult.Cancel) { return; }

                int length = settingDialog.HyphenationLength;

                VideoTrack selected = helper.Project.SelectedVideoTrack(false);

                if(selected == null || selected.Events.Count == 0) { return; }

                foreach(var trackEvent in selected.Events)
                {
                    Takes takes = trackEvent.Takes;

                    if(takes.Count == 0) { continue; }

                    var take = takes[0];

                    Media media = take.Media;

                    if (media == null) { continue; }

                    OFXStringParameter strparam = helper.OFXParam.GetStringParam(media, false);

                    if(strparam == null) { continue; }

                    helper.TextParam.SetTextToRtfBox(strparam);

                    helper.Rtf.Text = hyphenazer.Get(helper.Rtf.Text, length);

                    helper.TextParam.SetTextFromRtfBox(strparam);
                }

                helper.Config[Names.WdHyphe.Length] = length;
            }
            helper.Config.Save();
        }
    }
}
