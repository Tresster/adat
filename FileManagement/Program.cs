namespace FileManagement
{
    using System;

    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("(beolvasása, kiírása)");
            MENU:
            Console.Write("Adatok ");
            string menu = Console.ReadLine();
            string path = string.Empty;

            if (menu == "1" || menu.ToLower().Contains("beolvas")) Adatok.Beolvas(path);
            else if (menu == "2" || menu.ToLower().Contains("kiír")) Adatok.Kiír(path);
            else { Console.WriteLine("Helytelen menüpont." + Environment.NewLine); goto MENU; }

            Console.ReadLine(); //debug
        }
    }
}