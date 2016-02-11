using Common.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;

namespace Common.UIElements
{
    public class DataGridCell
    {
        /// <summary>
        /// DataGridColumn object which DataGridItem belongs
        /// </summary>
        public DataGridColumn Column { get; set; }
        /// <summary>
        /// DataGridRow object which DataGridItem belongs
        /// </summary>
        public DataGridRow Row { get; set; }

        /// <summary>
        /// DataGridCell item value
        /// </summary>
        public object Value { get; set; }
        public DataGridCell()
        {

        }

        public override string ToString()
        {
            return Value.ToString().SetDataFormat(this.Column.DataFormat);
        }
    }
}