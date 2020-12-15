using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Interface;
using System.Runtime;
using System.Linq;

namespace HarToFiles.cls
{
    class GetMediaFileFromPS : Interface.IGetMediaFile
    {
        private string psStr;
        private string destUri;

        /// <summary>
        /// ChromeからエクスポートしたPowerShellスクリプトを使用して、このインスタンスを初期化します。
        /// </summary>
        /// <param name="psStr">エクスポートしたPowerShellスクリプト。</param>
        public GetMediaFileFromPS(string psStr,string uri)
        {
            this.psStr = psStr;
            this.destUri = uri;
        }

        /// <summary>
        /// 指定された条件に一致するファイルを対象のディレクトリに保存します。
        /// </summary>
        /// <param name="searchCondition">検索条件オブジェクト。</param>
        void IGetMediaFile.SaveFile(ISearchCondition searchCondition)
        {

            //;区切りで細切れにする

            //それぞれのスクリプトを解析
            //URLからファイル名を取得
            //MimeTypeをスクリプトから取得

            //クラスオブジェクトにする
            var dataObjList = getPSScriptDataFromInput(this.psStr);

            //searchConditionでデータを取得する
            var filterdList = dataObjList.Where(elem => elem.extension == searchCondition.extension)
                                            .Where(elem => elem.MIMEType == searchCondition.MimeType)
                                            .ToList();

            //データをダウンロードする
            //ダウンロードしたデータを保存する


            throw new NotImplementedException();
        }

        /// <summary>
        /// 入力された文字列から、このスクリプトのデータを返します。
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private List<PSScriptData> getPSScriptDataFromInput(string inputStr)
        {
            var commmaSeparatedStr = inputStr.Split(";").ToList();
            var retList = new List<PSScriptData>();

            foreach(var str in commmaSeparatedStr)
            {
                //それぞれの文字列から、URLとMIMETypeを抜き出す
                var url = "";
                var mimetype = "";
                var extension = "";

                retList.Add(new PSScriptData(url, mimetype,extension));

            }
            return retList;
        }

        /// <summary>
        /// スクリプトから取得したデータを格納するPOCOオブジェクト。
        /// </summary>
        private class PSScriptData
        {
            public string Url { get; set; }
            public string MIMEType { get; set; }
            public string extension { get; set; }
            public byte[] Data { get; set; }

            /// <summary>
            /// スクリプトデータを表すデータを初期化します。
            /// </summary>
            /// <param name="url"></param>
            /// <param name="mimeType"></param>
            public PSScriptData(string url,string mimeType,string extension)
            {
                this.Url = url;
                this.MIMEType = mimeType;
                this.extension = extension;
            }

        }
    }
}
