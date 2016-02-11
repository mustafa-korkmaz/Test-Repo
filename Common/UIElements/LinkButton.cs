
using Common.Helpers;

namespace Common.UIElements
{
    /// <summary>
    ///an anchor tag acts like a link in HTML 
    /// </summary>
    public class LinkButton
    {
        private string _displayText;
        public string DisplayText
        {
            get
            {
                return this._displayText;
            }
            set
            {
                this._displayText = value;
            }
        }
        public string Id { get; set; } // html element id attribute
        private string _value;
        public string Value
        {
            get
            {
                if (this.UseDisplayTextAsValue)
                {
                    return this._displayText;
                }
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        public string Tooltip { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public bool UseDisplayTextAsValue { private get; set; } // if true DisplayText and Value properties are the same
        public DataLoadType DataLoadType { get; set; } // loads a new page or opens modal box when linkButton object clicked

        public LinkButton(string displayText)
        {
            this.DisplayText = displayText;
            this.UseDisplayTextAsValue = false; //do not show linktext property as value (use cell value as linkText)
            this.Tooltip = displayText;
            this.Id = "";
        }
        public LinkButton()
        {
            this.UseDisplayTextAsValue = false; //do not show linktext property as value (use cell value as linkText)
            this.Id = "";
            this.Tooltip = "";
        }
    }
}
