using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textAr, string textEN)
        {
            CultureInfo _CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (_CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEN;
        }
    }
}

