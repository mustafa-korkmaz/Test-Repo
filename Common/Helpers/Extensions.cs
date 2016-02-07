using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.Helpers
{
    public static class Extensions
    {
        public static string JoinToString(this List<string> items, string delimeter)
        {
            return String.Join(delimeter, items.ToArray());
        }

        public static string ToCamelCase(this string value)
        {
            //
            // Uppercase only the first letter in the string when  this extension is called on.
            //
            value = value.ToLower();
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }

        public static void SetTableCaptions(this DataTable dt, List<string> captionList)
        {
            for (int i = 0; i < captionList.Count; i++)
            {
                dt.Columns[i].Caption = captionList[i];
            }
        }

        public static void SetTableCaptions(this DataTable dt, int columnIndex, string caption)
        {
            dt.Columns[columnIndex].Caption = caption;
        }

        public static string ToFSISDateFormat(this DateTime d)
        {
            return d.ToString("dd.MM.yyyy");
        }

        public static DateTime ToFSISDateFormat(this string s)
        {
            return s == null ? DateTime.Today : DateTime.ParseExact(s, "dd.MM.yyyy", null);
        }

        public static string ToFSISDateCriteriaFormat(this DateTime d)
        {
            return d.ToString("yyyyMMdd");
        }
        public static string ToFSISMoneyFormat(this decimal val)
        {
            return string.Format("{0:#,0.00}", val); // "1.234.256,58"
        }
        public static string ToDocumentName(this string name)
        {
            name = name.ToLower();
            name = name.Replace("ı", "i");
            name = name.Replace("ö", "o");
            name = name.Replace("ü", "u");
            name = name.Replace("ç", "c");
            name = name.Replace("ş", "s");
            name = name.Replace("ğ", "g");

            string retValue = string.Empty;
            string id_long_name = name.Trim();
            string[] id_array = id_long_name.Split(' ');
            int length = id_array.Length;
            for (int i = 0; i < length; i++)
            {
                retValue += id_array[i];
                if (i < length - 1)
                    retValue += "_";
            }
            return retValue;
        }


        public static string SetDataFormat(this string value, ColumnDataFormat format)
        {
            string retValue = string.Empty;
            if (format != ColumnDataFormat.Default)
            {
                switch (format)
                {
                    case ColumnDataFormat.Date:
                        if (string.IsNullOrEmpty(value))
                            return "";
                        retValue = DateTime.Parse(value).ToFSISDateFormat();
                        break;
                    case ColumnDataFormat.Money:
                        value = string.IsNullOrEmpty(value) ? "0" : value;
                        retValue = Decimal.Parse(value).ToFSISMoneyFormat();
                        break;
                    default:
                        break;
                }
            }
            else
                retValue = value;

            return retValue;
        }
    }
}
