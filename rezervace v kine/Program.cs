namespace rezervace_v_kine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int cena_za_1 = 179;
            int objednane_misto = 0;
            int osX;
            int osY;
            int hlaska;
            int volba;
            string[,] catalogMist = new string[10,10];
            for (int i = 0; i < catalogMist.GetLength(0); i++)
            {
                for (int j = 0; j < catalogMist.GetLength(1); j++)
                {
                    catalogMist[i, j] = "[ ]";
                }
            }
            void vypis_mist()
            {
                Console.WriteLine("   -----------PLATNO-------------");
                Console.Write("   ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($" {i+1} ");    
                }
                Console.WriteLine();
                for (int i = 0; i < catalogMist.GetLength(0); i++)
                {
                    if (i==9)
                        Console.Write("10 ");
                    else
                        Console.Write($" {i + 1} ");
                    for (int j = 0; j < catalogMist.GetLength(1); j++)
                    {
                        if (catalogMist[i, j] == "[X]")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(catalogMist[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            Console.Write(catalogMist[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            void select_misto()
            {
                hlaska = 0;
                do
                {
                    if (hlaska == 0)
                    {
                        Console.Write("zadejte os X sedadla (1-10): ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Špatny vstup.\nZadejte os X ještě jednou: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    hlaska++;
                } while (!(int.TryParse(Console.ReadLine(), out osX) && osX > 0 && osX <= 10));
                osX--;
                hlaska = 0;
                do
                {
                    if (hlaska == 0)
                    {
                        Console.Write("zadejte os Y sedadla (1-10): ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Špatny vstup.\nZadejte os Y ještě jednou: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    hlaska++;
                } while (!(int.TryParse(Console.ReadLine(), out osY) && osY > 0 && osY <= 10));
                osY--;

            }
            void final_menu()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Pocet zarezervovanych mist: {objednane_misto}");
                Console.WriteLine($"Cena listku je: {cena_za_1 * objednane_misto} Kč");
                Console.ForegroundColor = ConsoleColor.White;
                hlaska = 0;
                do
                {
                    if (hlaska == 0)
                        Console.Write("Možnosti: (ukončeni rezervace = |1|, zarezervovat další misto = |2|, zrušít rezervaci = |3|)\nVáše volbá: ");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Špatny vstup. \nMožnosti: (ukončeni rezervace = |1|, zarezervovat další misto = |2|, zrušít rezervaci = |3|) \nZadejte ještě jednou: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    hlaska++;
                } while (!(int.TryParse(Console.ReadLine(), out volba) && volba > 0 && volba <= 3));
                switch (volba)
                {
                    case (1):
                        Environment.Exit(0);
                        break;
                    case (2):
                        Console.Clear();
                        break;
                    case (3):
                        Console.Clear();
                        vypis_mist();
                        Console.WriteLine("=====ZRUŠENI REZERVACE=====");
                        zruseni_rezervace();
                        final_menu();
                        break;
                }
            }
            void zruseni_rezervace()
            {
                select_misto();
                Console.Clear();
                if (catalogMist[osY, osX] == "[X]")
                {
                    catalogMist[osY, osX] = "[ ]";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Rezervace mista [{osX+1}, {osY+1}] byla zrušena.");
                    Console.ForegroundColor = ConsoleColor.White;
                    objednane_misto--;
                }
                else if (catalogMist[osY, osX] == "[ ]")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Misto [{osX+1}, {osY+1}] nebylo rezervovane, zrušeni rezervaci nebylo třeba.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                vypis_mist();
            }





            while (true)
            {
                vypis_mist();
                select_misto();
                Console.Clear();
                if (catalogMist[osY, osX] == "[X]")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Misto už je zarezervovane!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    catalogMist[osY, osX] = "[X]";
                    objednane_misto++;
                }
                vypis_mist();
                final_menu();
            }





        }
    }
}
