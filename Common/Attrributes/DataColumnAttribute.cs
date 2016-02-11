using Common.Helpers;
using System;


namespace Common.Attributes
{
    /// <summary>
    /// custom attribute for DataGridModel's DataGridColumn
    /// </summary>
    public class DataGridColumnAttribute : Attribute
    {
        private bool _visible;
        private bool _searchable;
        private string _searchLabel;
        private string _displayName;
        private ColumnDataFormat _dataFormat;
        private ColumnDataType _dataType;
      //  private DataGridSearch _dataGridSearch;

        public DataGridColumnAttribute(string displayName)
        {
            this._visible = true;
            this._displayName = displayName;
            this._dataFormat = ColumnDataFormat.Default;
            this._dataType = ColumnDataType.Text;
        }

        public DataGridColumnAttribute()
        {
            this._visible = true;
            this._dataFormat = ColumnDataFormat.Default;
            this._dataType = ColumnDataType.Text;
        }

        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        //public virtual bool Searchable
        //{
        //    get { return _searchable; }
        //    set { _searchable = value; }
        //}

        //public virtual string SearchLabel
        //{
        //    get { return _searchLabel; }
        //    set { _searchLabel = value; }
        //}

        public virtual string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public virtual ColumnDataFormat DataFormat
        {
            get { return _dataFormat; }
            set { _dataFormat = value; }
        }

        public virtual ColumnDataType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }
    }
}