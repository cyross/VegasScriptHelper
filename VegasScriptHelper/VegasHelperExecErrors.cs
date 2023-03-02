using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    /// <summary>
    /// VegasHelperや各スクリプトを実行中に起きた例外の情報を保持する
    /// </summary>
    public struct VegasHelperExecError
    {
        public string message;
    }

    /// <summary>
    /// VegasHelperや各スクリプトを実行中に起きた例外を管理する
    /// </summary>
    public class VegasHelperExecErrors
    {
        public List<VegasHelperExecError> Erros
        {
            get;
        }
    }
}
