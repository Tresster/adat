namespace FileManagement
{
    internal sealed partial class Adat
    {
        private struct Patterns
        {
            public static string Név { get; } = @"^[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+(\s[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+)+$"; //Nagybetűvel kezdődik, bármennyi név, de legalább 2
            public static string Dátum { get; } = "^[1-2][0-9]{3}.[0-1][0-9].[0-3][1-9]$"; //YYYY.MM.DD
            public static string Személyi_Azonosíto { get; } = @"^[1-4]\s[1-2][1-9]{5}\s[1-9]{4}$"; //space-szel választódik el, első rész: 1szám, 2 rész: 5szám, 3 rész: 4szám
        }
    }
}