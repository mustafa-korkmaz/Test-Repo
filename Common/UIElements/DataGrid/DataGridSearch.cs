using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helpers;
using System.Text;

namespace Common.UIElements
{
    public class DataGridSearch
    {
        public string Label { get; set; }
        public DataSearchType SearchType { get; set; }
        public object DataSource { get; set; }
    }
}
