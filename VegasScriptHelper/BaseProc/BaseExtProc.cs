using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper.BaseProc
{
    public class BaseExtProc: Interfaces.IExtProc
    {
        protected VegasHelper myHelper;

        public BaseExtProc(VegasHelper helper)
        {
            myHelper = helper;
        }

        /// <summary>
        /// 戻り値なしメソッドの雛形
        /// </summary>
        public virtual void Exec()
        {
            // Empty
        }

        /// <summary>
        /// 戻り値ありメソッドの雛形
        /// </summary>
        public virtual T Get<T>() where T: class, new()
        {
            return new T();
        }
    }
}
