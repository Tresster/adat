namespace FileManagement
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal sealed partial class Adat
    {
        public static string PlaceHolder
        {
            get
            {
                string placeholder = string.Empty;
                foreach (var enumName in Enum.GetNames(typeof(Adat.Type)).Skip(1))
                {
                    placeholder += enumName + ';';
                }

                return placeholder;
            }
        }
        public Type Típus
        {
            get
            {
                if (Regex.IsMatch(_adat, Patterns.Név)) return Type.Név;
                else if (Regex.IsMatch(_adat, Patterns.Dátum)) return Type.Dátum;
                else if (Regex.IsMatch(_adat, Patterns.Személyi_Azonosíto)) return Type.Személyi_Azonosíto;
                else return Type.Hibás;
            }
        }
        public string _adat { get; } = string.Empty;
        public Adat(string adat) => _adat = adat;
    }
}