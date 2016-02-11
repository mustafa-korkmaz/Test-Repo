using System.Collections.Generic;

namespace VdfFactoring.ViewModels
{

    public class DataGridRequestQueryString
    {
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public int orderedColumnIndex { get; set; }
        public string orderedColumnName { get; set; }
        public string orderBy { get; set; }  //asc - desc?
    }

    public class DataGridResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        //public List<CustomerModel> data { get; set; }
        public List<SimplePersonViewModel> data { get; set; }
    }

    public enum DataGridOrderType
    {
        Asc,
        Desc
    }
}