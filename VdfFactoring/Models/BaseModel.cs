
namespace VdfFactoring.Models
{
    public abstract class BaseModel
    {
        protected virtual string GetIdByDefault(string text)
        {
            text = text.ToLower();
            text = text.Replace("*", "-");
            text = text.Replace("ı", "i");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ç", "c");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");

            string retValue = string.Empty;
            string idLongText = text.Trim();
            string[] idArray = idLongText.Split(' ');
            int length = idArray.Length;
            for (int i = 0; i < length; i++)
            {
                retValue += idArray[i];
                if (i < length - 1)
                    retValue += "-";
            }
            return retValue;
        }
    }
}