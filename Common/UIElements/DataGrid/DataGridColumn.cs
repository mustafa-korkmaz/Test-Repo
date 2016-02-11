using Common.Helpers;
using System.Collections;
using System.Collections.Generic;

namespace Common.UIElements
{
    public class DataGridColumn
    {
        private string fieldName;// non editable property name of a class

        public bool IsVisible { get; set; }
        public DataGridSearch DataGridSearch { get; set; }
        public bool UseInSummaryColumns { get; set; } // for getting column summary totals
        public bool ShowInDataExport { get; set; } //may be we want to export data for a hidden column
        public string DisplayName { get; set; } // column display name
        public int ColumnIndex { get; internal set; }
        public int DisplayIndex { get; set; }
        public ColumnDataFormat DataFormat { get; set; }
        public ColumnDataType DataType { get; set; }
        /// <summary>
        /// DataGrid object which DataGridColumn belongs to.
        /// </summary>
        public DataGrid DataGrid { get; internal set; }
        public string FieldName { get { return this.fieldName; } }


        private DataGridColumn(string fieldName, ColumnDataFormat dataFormat, ColumnDataType dataType)
        {
            this.fieldName = fieldName;
            this.DisplayName = fieldName; // fieldName== displayName by default
            this.DataFormat = dataFormat;
            this.DataType = dataType;
            this.UseInSummaryColumns = false;
            this.IsVisible = true;
            this.ShowInDataExport = true;
        }

        private DataGridColumn(int columnIndex, string fieldName, string displayName, ColumnDataFormat dataFormat, ColumnDataType dataType)
        {
            this.ColumnIndex = columnIndex;
            this.DisplayName = displayName;
            this.fieldName = fieldName;
            this.DataFormat = dataFormat;
            this.DataType = dataType;
            this.UseInSummaryColumns = false;
            this.IsVisible = true;
            this.ShowInDataExport = true;
        }

        public static DataGridColumn Create(string fieldName, ColumnDataFormat dataFormat = ColumnDataFormat.Default, ColumnDataType dataType = ColumnDataType.Text)
        {
            return new DataGridColumn(fieldName, dataFormat, dataType);
        }
        public static DataGridColumn Create(int columnIndex, string fieldName, string displayName, ColumnDataFormat dataFormat = ColumnDataFormat.Default, ColumnDataType dataType = ColumnDataType.Text)
        {
            return new DataGridColumn(columnIndex, fieldName, displayName, dataFormat, dataType);
        }
    }

    public class DataGridColumnCollection : IEnumerable<DataGridColumn>
    {
        private DataGrid _dataGrid;
        private List<DataGridColumn> _columns;
        public DataGridColumn this[int index]
        {
            get { return this._columns[index]; }
        }
        public DataGridColumn this[string fieldName]
        {
            get { return this._columns.Find(c => c.FieldName == fieldName); }
        }
        public DataGridColumnCollection(DataGrid dataGrid)
        {
            this._dataGrid = dataGrid;
            this._columns = new List<DataGridColumn>();
        }

        public void Add(DataGridColumn column)
        {
            this._columns.Add(column);
            column.DataGrid = this._dataGrid;
        }
        public bool Remove(DataGridColumn column)
        {
            return this._columns.Remove(column);
        }
        public void RemoveAt(int columnIndex)
        {
            this._columns.RemoveAt(columnIndex);
        }
        IEnumerator<DataGridColumn> IEnumerable<DataGridColumn>.GetEnumerator()
        {
            return this._columns.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._columns.GetEnumerator();
        }
    }
}