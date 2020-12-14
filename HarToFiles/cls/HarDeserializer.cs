using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HarToFiles.cls
{
    /// <summary>
    /// Harファイルのデシリアライズ機能を提供します。
    /// </summary>
    class HarDeserializer
    {

        private string input;

        /// <summary>
        /// デシリアライザを初期化します。
        /// </summary>
        /// <param name="input">デシリアライズするターゲット文字列。</param>
        public HarDeserializer(string input)
        {
            this.input = input;
        }

        /// <summary>
        /// 初期化された文字列を<see cref="HarToFiles.Model.Har"></see>形式でデシリアライズします。
        /// </summary>
        /// <returns></returns>
        public Har Deserialize()
        {
            return JsonSerializer.Deserialize<Har>(input);
        }
    }
}
