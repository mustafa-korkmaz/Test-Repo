using Common.Helpers;
using System;


namespace Common.Attributes
{
    /// <summary>
    /// custom attribute for DataGridModel's DataGridColumn
    /// </summary>
    public class DataGridColumnAttribute : Attribute
    {
        private bool visible;
        private bool sortable;
        //private bool searchable;
        //private string searchLabel;
        private string displayName;
        private ColumnDataFormat dataFormat;
        private ColumnDataType dataType;
      //  private DataGridSearch dataGridSearch;

        public DataGridColumnAttribute(string displayName)
        {
            this.visible = true;
            this.sortable = false;
            this.displayName = displayName;
            this.dataFormat = ColumnDataFormat.Default;
            this.dataType = ColumnDataType.Text;
        }

        public DataGridColumnAttribute()
        {
            this.visible = true;
            this.dataFormat = ColumnDataFormat.Default;
            this.dataType = ColumnDataType.Text;
        }

        public virtual bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public virtual bool Sortable
        {
            get { return sortable; }
            set { sortable = value; }
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
            get { return displayName; }
            set { displayName = value; }
        }

        public virtual ColumnDataFormat DataFormat
        {
            get { return dataFormat; }
            set { dataFormat = value; }
        }

        public virtual ColumnDataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
    }
}