using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Commons
{
    public class LocalizableEntity: GeneralLocalizableEntity
    {
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string GetLocalized()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return NameAR;
            return NameEN;
        }
    }
}
