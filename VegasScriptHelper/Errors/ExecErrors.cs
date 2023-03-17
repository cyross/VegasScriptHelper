using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper.Errors
{

    /// <summary>
    /// VegasHelperや各スクリプトを実行中に起きた例外の情報を保持する
    /// </summary>
    public struct VHExecError
    {
        public string message;
    }

    /// <summary>
    /// VegasHelperや各スクリプトを実行中に起きた例外を管理する
    /// </summary>
    public class VHExecErrors
    {
        public List<VHExecError> Errors
        {
            get;
        }

        public VHExecErrors()
        {
            Errors = new List<VHExecError>();
        }
    }
}
