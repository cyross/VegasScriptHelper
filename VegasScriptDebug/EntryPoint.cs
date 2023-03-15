using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;
using System.Collections.Generic;
using VegasScriptDebug.DebugProcess;
using VegasScriptDebug.DebugProcess.DMediaBin;

namespace VegasScriptDebug
{
    public class EntryPoint: IEntryPoint
    {
        private readonly Dictionary<string, IDebugProcess> NameToObj = new Dictionary<string, IDebugProcess>();
        private readonly List<string> Names = new List<string>();

        public void FromVegas(Vegas vegas)
        {

                VegasHelper helper = VegasHelper.Instance(vegas);
                SettingDialog dialog = new SettingDialog();

                SetDataSource(helper);

                dialog.DataSource = Names;

                if(dialog.ShowDialog() == DialogResult.Cancel) { return; }

                NameToObj[dialog.DebugProcess].Exec();
        }

        private void SetDataSource(VegasHelper helper)
        {
            AppendDataSource("メディア生成", new GenerateMedia(helper));
            AppendDataSource("YAMLファイル読み込み", new YAMLAccess(helper));
            AppendDataSource("フォルダ内の音声ファイルを流し込み", new InsertWaveFileInNewAudioTrack(helper));
            AppendDataSource("声優名に合わせた文字色を設定", new ApplyTextColorByActor(helper));
            AppendDataSource(
                "ビデオイベントの幅をオーディオイベントにあわせる",
                new AssignAudioTrackDurationToVideoTrack(helper));
            AppendDataSource(
                "選択したビデオトラックのイベント幅を選択したオーディオトラックのイベントに合わせる",
                new AssignSAudioTrackDurToSVideoTrack(helper));
            AppendDataSource("字幕の接頭辞を削除", new DeleteJimakuPrefix(helper));
            AppendDataSource("指定トラックの長さを表示", new ShowTrackLength(helper));
            AppendDataSource("最初のイベントを拡大", new ExpandFirstVideoEvent(helper));
            AppendDataSource("メディアビンの動作チェック", new Check(helper));
            AppendDataSource("メディアビンの作成", new Create(helper));
        }

        private void AppendDataSource(string name, IDebugProcess debugObj)
        {
            Names.Add(name);
            NameToObj[name] = debugObj;
        }
    }
}
