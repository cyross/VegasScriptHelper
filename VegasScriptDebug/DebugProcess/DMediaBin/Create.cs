using System;
using System.Diagnostics;
using ScriptPortal.Vegas;
using VegasScriptHelper;

namespace VegasScriptDebug.DebugProcess.DMediaBin
{
    internal class Create : IDebugProcess
    {
        private readonly VegasHelper helper;

        public Create(VegasHelper helper)
        {
            this.helper = helper;
        }

        public void Exec()
        {
            Debug.WriteLine("メディアビンを作成します。");
            MediaBin mediaBin = helper.CreateMediaBin("ほげ");
            Debug.WriteLine("メディアビンにメディアを挿入します。");
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string executingPath = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath);
            mediaBin.Add(helper.CreateMedia(executingPath + "\\..\\..\\for_debug-0.wav"));
            Debug.WriteLine("完了しました。");
        }
    }
}
