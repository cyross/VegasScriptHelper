using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using VegasScriptHelper;

namespace VegasScriptDebug
{
    public partial class EntryPoint
    {
        private void DebugCreateMediaBin(VegasHelper helper)
        {
            Debug.WriteLine("メディアビンを作成します。");
            MediaBin mediaBin = helper.CreateMediaBin("ほげ");
            Debug.WriteLine("メディアビンにメディアを挿入します。");
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string executingPath = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath);
            mediaBin.Add(helper.CreateMedia(executingPath + "\\..\\..\\for_debug-0.wav"));
            Debug.WriteLine("完了しました。");
        }

        private void DebugMediaBin(VegasHelper helper)
        {
            string binName = "テスト用";
            if (MessageBox.Show(
                "メディアビンは空ですか？",
                "メディアビンが空かどうかの確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            MessageBox.Show("[正常系]メディアビンを作成します。");
            try
            {
                helper.CreateMediaBin(binName);
            }
            catch (VegasHelperAlreadyExistedMediaBinException)
            {
                MessageBox.Show("メディアビンが存在しています。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("作成が完了しました。", "OK");
            MessageBox.Show("[異常系]存在しているメディアビンを作成しようとします。");
            try
            {
                helper.CreateMediaBin(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VegasHelperAlreadyExistedMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("[正常系]メディアビンを取得します。");
            try
            {
                MediaBin bin = helper.GetMediaBin(binName);
            }
            catch (VegasHelperNotFoundMediaBinException)
            {
                MessageBox.Show("メディアビンが存在していません。", "例外発生", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("取得が完了しました。", "OK");
            MessageBox.Show("[正常系]メディアビンを削除します。");
            try
            {
                helper.DeleteMediaBin(binName);
            }
            catch (VegasHelperNotFoundMediaBinException)
            {
                MessageBox.Show("メディアビンが存在していません。", "例外発生", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("削除が完了しました。", "OK");
            MessageBox.Show("[異常系]存在していないメディアビンを取得しようとします。");
            try
            {
                MediaBin bin = helper.GetMediaBin(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VegasHelperNotFoundMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("[異常系]存在していないメディアビンを削除しようとします。");
            try
            {
                helper.DeleteMediaBin(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VegasHelperNotFoundMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("デバッグが無事完了しました。");
        }
    }
}
