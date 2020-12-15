using System;
using System.Collections.Generic;
using System.Text;

namespace HarToFiles.Interface
{
    /// <summary>
    /// 取得するファイルの条件を指定するインターフェース。
    /// </summary>
    interface ISearchCondition
    {
        /// <summary>
        /// 取得するファイルの拡張子の条件。
        /// </summary>
        public List<string> extension { get; set; }
    }
}
