using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Interface;

namespace HarToFiles.Model
{
    class PSRequestScript
    {
        private string psStr;
        private ISearchCondition searchCondition;

        /// <summary>
        /// PowerShellリクエストスクリプトの文字列を使用して初期化します。
        /// </summary>
        /// <param name="psStr"></param>
        public PSRequestScript(string psStr,ISearchCondition searchCondition)
        {
            this.psStr = psStr;
            this.searchCondition = searchCondition;
        }

        /// <summary>
        /// 入力された条件から、ファイルを保存します。
        /// </summary>
        public void SaveFiles()
        {

        }


    }
}
