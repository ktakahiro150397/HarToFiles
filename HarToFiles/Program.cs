using System;
using System.IO;
using HarToFiles.Model;
using HarToFiles.cls;

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
                            var mediaGetter = new GetMediaFileFromHar(harDeserialized, destFolderPath);
                            mediaGetter.SaveVideo();

                        }
                        break;
                    case "ps1":
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
