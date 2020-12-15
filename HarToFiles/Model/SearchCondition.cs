using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Interface;

namespace HarToFiles.Model
{
    class SearchCondition : ISearchCondition
    {
        private string _extension;
        private string _mimeType;

        string ISearchCondition.extension { get => _extension; set => _extension = value; }
        string ISearchCondition.MimeType { get => _mimeType; set => _mimeType = value; }

        public SearchCondition(string extension,string mimeType)
        {
            this._extension = extension;
            this._mimeType = mimeType;
        }
    }
}
