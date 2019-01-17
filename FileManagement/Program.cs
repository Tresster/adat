namespace FileManagement
{
    using System;

    internal static class Program
    {
        public static void Main()
        {
            Console.Write("Fájlnév: ");
            string path = Console.ReadLine();

        MENU:
            Console.WriteLine(Environment.NewLine + "(beolvasása, tárolása)");
            Console.Write("Adatok ");
            string menu = Console.ReadLine();

            if (menu.ToLower().Contains("beolvas")) Tartalom.Fájlból_Olvas(path);
            else if (menu.ToLower().Contains("tárolás")) Tartalom.Fájlba_Ír(path);
            else if (menu.ToLower() == "exit") Environment.Exit(0);
            else Console.WriteLine("Helytelen menüpont." + Environment.NewLine);

            goto MENU;
        }
    }
}