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
        private bool _orderable;
        //private bool searchable;
        //private string searchLabel;
        private string _displayName;
        private bool _useInSummary;
        private ColumnDataFormat _dataFormat;
        private ColumnDataType _dataType;
        //  private DataGridSearch dataGridSearch;

        public DataGridColumnAttribute(string displayName)
        {
            _visible = true;
            _orderable = false;
            _displayName = displayName;
            _dataFormat = ColumnDataFormat.Default;
            _dataType = ColumnDataType.Text;
            _useInSummary = false;
        }

        public DataGridColumnAttribute()
        {
            _visible = true;
            _dataFormat = ColumnDataFormat.Default;
            _dataType = ColumnDataType.Text;
        }

        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public virtual bool Orderable
        {
            get { return _orderable; }
            set { _orderable = value; }
        }

        public virtual bool UseInSummary
        {
            get { return _useInSummary; }
            set { _useInSummary = value; }
        }

        //public virtual bool Searchable
        //{
        //    get { return searchable; }
        //    set { searchable = value; }
        //}

        //public virtual string SearchLabel
        //{
        //    get { return searchLabel; }
        //    set { searchLabel = value; }
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