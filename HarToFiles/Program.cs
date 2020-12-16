using System;
using System.IO;
using HarToFiles.Model;
using HarToFiles.cls;
using HarToFiles.Interface;
using System.Collections.Generic;
using System.Collections;

namespace HarToFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //引数
            //.exe <targetFile.har> <destFolder>
            //harファイルから、対象フォルダにビデオファイルを保存する

            if (args.Length != 3)
            {
                Console.WriteLine("引数の数が正しくありません。");
                Console.WriteLine("対象ファイル・対象フォルダを指定してください。");
                Console.WriteLine(@"HarToFiles.exe ""har"" <targetFile.har> <destFolder>");
                Console.WriteLine(@"HarToFiles.exe ""ps1"" <targetFile.ps1> <destFolder>");
            }
            else
            {
                string mode = args[0];
                string targetFilePath = args[1];
                string destFolderPath = args[2];

                //検索条件を設定する
                var conditionList = new List<string> { ".ts" };
                ISearchCondition searchCondition = new SearchCondition(conditionList);


                switch (mode)
                {
                    case "har":
                        //対象のharファイルを文字列として読み取る
                        using (var sr = new StreamReader(targetFilePath))
                        {
                            var fileStr = sr.ReadToEnd();

                            //読み取ったファイルをデシリアライズする
                            var harDeserializer = new HarDeserializer(fileStr);
                            var harDeserialized = harDeserializer.Deserialize();

                            //読み取ったデータを保存する
                            IGetMediaFile mediaGetter = new GetMediaFileFromHar(harDeserialized, destFolderPath);
                            mediaGetter.SaveVideo(searchCondition);

                        }
                        break;
                    case "ps1":
                        using (var sr = new StreamReader(targetFilePath))
                        {
                            var fileStr = sr.ReadToEnd();

                           
                            //読み取った文字列を解析する
                            IGetMediaFile psGetter = new GetMediaFileFromPS(fileStr, destFolderPath);
                            //ファイルを取得する
                            psGetter.SaveFile(searchCondition);


                        }
                            break;
                    default:
                        Console.WriteLine("引数が正しくありません。");
                        Console.WriteLine("第一引数には適切なモードを指定してください。");
                        break;
                }


            }
        }
    }
}
