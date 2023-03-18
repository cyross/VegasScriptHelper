using System.Windows.Forms;
using ScriptPortal.Vegas;
using VegasScriptHelper;
using VegasScriptHelper.Errors;

namespace VegasScriptDebug.DebugProcess.DMediaBin
{
    internal class Check : IDebugProcess
    {
        private readonly VegasHelper helper;

        public Check(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            string binName = "テスト用";
            if (MessageBox.Show(
                "メディアビンは空ですか？",
                "メディアビンが空かどうかの確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            MessageBox.Show("[正常系]メディアビンを作成します。");
            try
            {
                helper.MediaBin.Create(binName);
            }
            catch (VHAlreadyExistedMediaBinException)
            {
                MessageBox.Show("メディアビンが存在しています。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("作成が完了しました。", "OK");
            MessageBox.Show("[異常系]存在しているメディアビンを作成しようとします。");
            try
            {
                helper.MediaBin.Create(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VHAlreadyExistedMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("[正常系]メディアビンを取得します。");
            try
            {
                MediaBin bin = helper.MediaBin.Get(binName);
            }
            catch (VHNotFoundMediaBinException)
            {
                MessageBox.Show("メディアビンが存在していません。", "例外発生", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("取得が完了しました。", "OK");
            MessageBox.Show("[正常系]メディアビンを削除します。");
            try
            {
                helper.MediaBin.Delete(binName);
            }
            catch (VHNotFoundMediaBinException)
            {
                MessageBox.Show("メディアビンが存在していません。", "例外発生", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("削除が完了しました。", "OK");
            MessageBox.Show("[異常系]存在していないメディアビンを取得しようとします。");
            try
            {
                MediaBin bin = helper.MediaBin.Get(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VHNotFoundMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("[異常系]存在していないメディアビンを削除しようとします。");
            try
            {
                helper.MediaBin.Delete(binName);
                MessageBox.Show("例外が発生しませんでした。", "NG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (VHNotFoundMediaBinException)
            {
                MessageBox.Show("例外が発生しました。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("デバッグが無事完了しました。");
        }
    }
}
