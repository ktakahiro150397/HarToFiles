using System;
using System.Collections.Generic;
using System.Text;
using HarToFiles.Interface;

namespace HarToFiles.Model
{
    class SearchCondition : ISearchCondition
    {
        private List<string> _extension;

        List<string> ISearchCondition.extension { get => _extension; set => _extension = value; }

        public SearchCondition(List<string> extension)
        {
            this._extension = extension;
        }
    }
}
