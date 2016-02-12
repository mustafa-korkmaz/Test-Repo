using System.Collections.Generic;

namespace VdfFactoring.ViewModels
{
    /// <summary>
    /// request query string class for dataTables.js
    /// </summary>
    public class DataGridRequestQueryString
    {
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public int orderedColumnIndex { get; set; }
        public string orderedColumnName { get; set; }
        public string orderBy { get; set; }  //asc - desc?
    }

    /// <summary>
    /// response class for dataTables.js 
    /// </summary>
    public class DataGridResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        //public List<CustomerModel> data { get; set; }
        public List<SimplePersonViewModel> data { get; set; }
    }

    /// <summary>
    /// order types for dataTables.js
    /// </summary>
    public enum DataGridOrderType
    {
        Asc,
        Desc
    }
}