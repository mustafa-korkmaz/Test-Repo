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

        public Type _sourceModelType;

        public Type SourceModelType
        {
            set
            {
                this._sourceModelType = value;
                SetDataGridProperties();
            }

        }

        /// <summary>
        /// table body columns fieldName and orderable property json format for dataTables.js integration
        /// </summary>
        public string BodyColumns
        {
            get
            {
                var bodyColumnsQuery = DataGrid.Columns.Where(c => c.IsVisible).Select(p => new { data = p.FieldName, orderable = p.IsOrderable });
                return JsonConvert.SerializeObject(bodyColumnsQuery.ToList());
            }
        }

        /// <summary>
        /// summaryColumns json format for dataTables.js integration
        /// </summary>
        public string SummaryColumns
        {
            get
            {
                var summaryColumnsQuery = DataGrid.Columns.Where(c => c.UseInSummaryColumns).Select(p => p.ColumnIndex);
                return JsonConvert.SerializeObject(summaryColumnsQuery.ToList());
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

        private void SetDataGridProperties()
        {
            var pi = _sourceModelType.GetProperties().FirstOrDefault(p => p.PropertyType.Name == "DataGridModel");
            var customAttributes = pi.GetCustomAttributes(true);
            var dataGridAttribute = (customAttributes.Any() ? customAttributes[0] : null) as DataGridAttribute;
            if (dataGridAttribute != null)
            {
                DataGrid.Name = dataGridAttribute.Name;
                DataGrid.ShowFooter = dataGridAttribute.ShowFooter;
                //  DataGrid.ShowSearchSection = dataGridAttribute.ShowSearchSection;
                DataGrid.IsRowsCheckable = dataGridAttribute.RowsCheckable;
                DataGrid.IsRowsDeletable = dataGridAttribute.RowsDeletable;
                DataGrid.DeleteText = dataGridAttribute.DeleteText;
                DataGrid.IsRowsEditable = dataGridAttribute.RowsEditable;
                DataGrid.EditText = dataGridAttribute.EditText;
                DataGrid.EdittingRowDataLoadType = dataGridAttribute.EdittingRowDataLoadType;
                DataGrid.PagingType = dataGridAttribute.PagingType;
            }
        }

    }
}
