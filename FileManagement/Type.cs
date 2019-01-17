namespace FileManagement
{
    internal sealed partial class Adat
    {
        public enum Type : byte
        {
            Hibás = 0, //alapértelmezett érték
            Név = 1,
            Dátum = 2,
            Személyi_Azonosíto = 3
        }
    }
}