using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Model;
using System.Linq;
using System.IO;
using HarToFiles.Interface;

namespace HarToFiles.cls
{
    class GetMediaFileFromHar:IGetMediaFile
    {
        private Har targetHar;
        private string dest;

        /// <summary>
        /// メディアファイルを取得する対象データと保存先を使用して初期化します。
        /// </summary>
        /// <param name="har">メディアファイルを取得する<see cref="Har"/>。</param>
        /// <param name="uri">メディアファイルの保存先。</param>
        public GetMediaFileFromHar(Har har, string uri)
        {
            targetHar = har;
            dest = uri;
        }

        /// <summary>
        /// <see cref="Har"/>クラスデータから、動画データを取得して保存します。
        /// </summary>
        /// <returns>成功した場合true。失敗した場合false。</returns>
        void IGetMediaFile.SaveVideo(ISearchCondition searchCondition)
        {
            //mimeTypeが"video"から始まっているデータを取得する
            var videoData = targetHar.log.entries.Where(entry => entry.response.content.mimeType.StartsWith("video")).ToList();

            //取得したデータのtextをそれぞれbase64でデコードする
            //デコードしたファイルを、保存先に保存する
            //ファイル名はrequestのurlのファイル名とする
            foreach (var data in videoData)
            {
                if (!(data.response.content.text == null))
                {
                    var fileName = Path.GetFileName(data.request.url);
                    fileName = System.Text.RegularExpressions.Regex.Replace(fileName, "\\?.*", "");
                    var destFullPath = Path.Combine(dest, fileName);

                    using (var fs = File.Create(destFullPath))
                    {
                        //textをbase64デコードして書き込む
                        fs.Write(Convert.FromBase64String(data.response.content.text));
                    }
                }
            }
        }
    }
}
