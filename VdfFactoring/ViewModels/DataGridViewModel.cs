using System.Collections;
using System.Collections.Generic;
using Common.Attributes;
using System;
using System.Web;

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
        public int orderedColumnIndex
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Request.QueryString["order[0][column]"]);
            }
        }
        public string orderedColumnName
        {
            get
            {
                var columnNameIdentifier = string.Format("columns[{0}][data]", orderedColumnIndex);
                return HttpContext.Current.Request.QueryString[columnNameIdentifier];
            }
        }
        public string orderBy
        {
            get
            {
                return HttpContext.Current.Request.QueryString["order[0][dir]"];
            }  //asc - desc?
        }
    }
    /// <summary>
    /// response class for dataTables.js 
    /// </summary>
    public class DataGridResponseViewModel
    {
        public DataGridResponseViewModel(DataGridRequestQueryString queryString)
        {
            _draw = queryString.draw;
        }

        private int _draw;
        public int draw
        {
            get
            {
                return _draw;
            }
        }

        public IEnumerable data { get; set; } //generated data for our dataGrid

        public int recordsTotal { get; set; }

        public int recordsFiltered
        {
            get
            {
                return recordsTotal;
            }
        }
    }

    /// <summary>
    /// order types for dataTables.js
    /// </summary>
    public enum DataGridOrderType
    {
        Asc,
        Desc
    }

    public interface IDataTablesJs
    {
        string DT_RowId { get; } // dataTables.js row id property. We will use it for dataGrid <tr> element id attribute
    }
}