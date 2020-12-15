using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Interface;
using System.Runtime;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace HarToFiles.cls
{
    class GetMediaFileFromPS : IGetMediaFile
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
            var dataObjList = GetSplitedObject(this.psStr);

            //searchConditionでデータを取得する
            var filterdList = dataObjList.Where(elem => searchCondition.extension.Contains(elem.extension))
                                            .ToList();

            Console.WriteLine("ダウンロード対象は{0}件です。", filterdList.Count);
            //データをダウンロードする
            //ダウンロードしたデータを保存する
            foreach(var item in filterdList)
            {
                Console.WriteLine("DL:{0}", item.FileName);
                DataDownloader.DownloadFile(item.Url, destUri, item.FileName);
            }
        }

        /// <summary>
        /// PowerShellスクリプトから、クラスオブジェクトを生成して返します。
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private List<PSScriptData> GetSplitedObject(string inputStr)
        {
            //改行コードを変換する
            var targetStr = inputStr.Replace(Environment.NewLine, "<NL>");

            var separetedStr = Regex.Matches(targetStr, "Invoke-WebRequest.*?;").ToList();
            //var separetedStr = Regex.Split(, "Invoke-WebRequest.*?};").ToList();

            var retList = new List<PSScriptData>();

            foreach(var item in separetedStr)
            {
                string url = "";
                string FileName = "";
                string Extension = "";

                //URLの取得
                var urlMatch = Regex.Match(item.Value, @"-Uri ""(.*?)""");
                if(urlMatch.Groups.Count > 1)
                {
                    //URLがマッチしているため取得
                    url = urlMatch.Groups[1].Value;
                }

                //ファイル名の取得
                //URLからパラメータを取り除く
                FileName = Path.GetFileName(url);
                FileName = Regex.Replace(FileName, "\\?.*", "");

                //ファイル拡張子の取得
                Extension = Path.GetExtension(FileName);

                retList.Add(new PSScriptData(url, FileName, Extension));
            }

            return retList;
        }

        /// <summary>
        /// スクリプトから取得したデータを格納するPOCOオブジェクト。
        /// </summary>
        private class PSScriptData
        {
            public string Url { get; set; }
            public string FileName { get; set; }
            public string extension { get; set; }
            public byte[] Data { get; set; }

            /// <summary>
            /// スクリプトデータを表すデータを初期化します。
            /// </summary>
            /// <param name="url"></param>
            /// <param name="mimeType"></param>
            public PSScriptData(string url,string fileName,string extension)
            {
                this.Url = url;
                this.FileName = fileName;
                this.extension = extension;
            }

        }
    }
}
