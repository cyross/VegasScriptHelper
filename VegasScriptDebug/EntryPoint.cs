using System;
using ScriptPortal.Vegas;
using System.Windows.Forms;
using VegasScriptHelper;
using System.IO;
using System.Reflection;

namespace VegasScriptDebug
{
    public partial class EntryPoint: IEntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            try
            {
                VegasHelper helper = VegasHelper.Instance(vegas);
            }
            catch (FileNotFoundException ex)
            {
                string execDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
                MessageBox.Show(
                    string.Format(
                        "{0}\r\n以下の場所にファイルを置いてください。\r\n{1}",
                        ex.Message,
                        execDir
                    ));
            }
        }
    }
}
