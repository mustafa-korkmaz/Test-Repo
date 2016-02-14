using System;
using System.Collections;
using System.Collections.Generic;
using Common.Attributes;
using System.Linq;
using Newtonsoft.Json;
using Common.UIElements;
using System.Reflection;
using System.Linq.Expressions;

namespace VdfFactoring.Models
{
    /// <summary>
    ///  _DataGrid.cshtml için modelimiz. ihtiyaç duyulan grid özelliklerini buraya ekleyip shared mantığı ile grid componentimizi geliştirebiliriz. 
    /// </summary>
    public class DataGridModel : BaseModel
    {
        #region Properties

        //     public DataExportModel DataExportModel { get; set; }

        public DataGrid DataGrid { get; set; }

        /// <summary>
        /// table body columns fieldName and orderable property json format for dataTables.js integration
        /// </summary>
        public string BodyColumns
        {
            get
            {
                var bodyColumnsQuery = DataGrid.Columns.Where(c => c.Visible).Select(p => new { data = p.FieldName, orderable = p.Orderable });
                return JsonConvert.SerializeObject(bodyColumnsQuery.ToList());
            }
        }

        private string _summaryColumns;

        /// <summary>
        /// summaryColumns json format for dataTables.js integration
        /// </summary>
        public string SummaryColumns
        {
            get { return _summaryColumns; }
        }

        public bool HasSummaryColumns
        {
            get
            {
                var summaryColumnsQuery = DataGrid.Columns.Where(c => c.UseInSummary).Select(p => p.ColumnIndex);
                _summaryColumns = JsonConvert.SerializeObject(summaryColumnsQuery.ToList());
                return summaryColumnsQuery.Any();
            }
        }

        /// <summary>
        /// table action columns f  json format for dataTables.js integration  eg: {"deletable":"false","editable":"true", defaultContent:""}
        /// </summary>
        public string RowActions
        {
            get
            {
                var rowActions = new { deletable = DataGrid.IsRowsDeletable, editable = DataGrid.IsRowsEditable, defaultContent = "" };
                return JsonConvert.SerializeObject(rowActions);
            }
        }

        #endregion Properties

        #region Constructor

        public DataGridModel(IEnumerable source, string gridTableName)
        {
            this.DataGrid = new DataGrid(source, gridTableName);
            this.DataGrid.Id = GetIdByDefault(gridTableName); //DOM Element id
        }

        #endregion Constructor
    }
}
