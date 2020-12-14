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
         
            if(args.Length !=  2)
            {
                Console.WriteLine("引数の数が正しくありません。");
                Console.WriteLine("対象ファイル・対象フォルダを指定してください。");
                Console.WriteLine("HarToFiles.exe <targetFile.har> <destFolder>");
            }
            else
            {
                string targetFilePath = args[0];
                string destFolderPath = args[1];

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
            }
        }
    }
}
