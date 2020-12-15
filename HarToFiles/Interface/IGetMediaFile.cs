using System;
using System.Collections.Generic;
using System.Text;

namespace HarToFiles.Interface
{
    /// <summary>
    /// 各種リクエストからファイルを取得するクラスが実装するインターフェース。
    /// </summary>
    interface IGetMediaFile
    {
        public abstract void SaveFile(ISearchCondition searchCondition);
    }
}
