namespace FileManagement
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    internal static class Tartalom
    {
        public static LinkedList<string> Fájlból_Olvas(string Path)
        {
            LinkedList<string> adatok = new LinkedList<string>();

            #region Adatok Beolvasása Fájlból
            try
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string sor;
                    while ((sor = reader.ReadLine()) != null)
                    {
                        adatok.AddLast(sor);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nem létezik a fájl.");
            }
            #endregion

            return adatok;
        }

        public static void Fájlba_Ír(string Path)
        {
            LinkedList<Adat> adatok = new LinkedList<Adat>();
            string reader = string.Empty;

            #region Adatok Beolvasása Console-ról
            Console.WriteLine(Environment.NewLine + "(név, születési dátum, személyi szám)");
            do
            {
                Console.Write("Adjon meg egy adatot: ");
                reader = Console.ReadLine();
                adatok.AddLast(new Adat(reader));

                if (adatok.Last.Value.Típus == Adat.Type.Hibás)
                {
                    if (!(adatok.Last.Value._adat == "*")) Console.WriteLine("Helytelen adat.");
                    adatok.RemoveLast(); //Hibás adat törlése
                }
            } while (reader != "*");
            #endregion

            #region Adatok Előkészítése
            Dictionary<Adat.Type, List<string>> kiirasok = new Dictionary<Adat.Type, List<string>>();

            foreach (Adat adat in adatok)
            {
                if (kiirasok.ContainsKey(adat.Típus)) kiirasok[adat.Típus].Add(adat._adat);
                else kiirasok.Add(adat.Típus, new List<string>() { adat._adat }); //Lista létrehozása "_adat" alapértékkel
            }
            #endregion

            #region Adatok Összeszedése
            List<string> kiirnivalo = new List<string>();

            foreach (var kiiras in kiirasok)
            {
                int index = 0;

                foreach (string adat in kiiras.Value) //minden egyes adat a listában
                {
                    if (kiiras.Value.Count > kiirnivalo.Count) kiirnivalo.Add(Adat.PlaceHolder); //helykitöltő hozzáadása a listához
                    kiirnivalo[index] = kiirnivalo[index].Replace(kiiras.Key.ToString(), adat); //aktuális adattal kicseréljük a helykitöltőt (it doesn't seem to work without converting the Enum type to string)

                    index++;
                }
            }

            #endregion

            #region Kiírás
            File.AppendAllLines(Path, kiirnivalo);
            #endregion
        }
    }
}
