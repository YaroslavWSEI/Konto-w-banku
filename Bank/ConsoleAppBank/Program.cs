using System;
using Bank;

namespace ConsoleAppBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Symulacja działania konta podstawowego
            Console.WriteLine("Symulacja działania konta podstawowego:");
            Konto konto = new Konto("Jan Kowalski", 100);
            Console.WriteLine($"Nazwa: {konto.Nazwa}, Bilans: {konto.Bilans}");
            konto.Wplata(50);
            Console.WriteLine($"Po wpłacie 50: Bilans: {konto.Bilans}");
            konto.Wyplata(30);
            Console.WriteLine($"Po wypłacie 30: Bilans: {konto.Bilans}");
            konto.BlokujKonto();
            Console.WriteLine($"Konto zablokowane: {konto.Zablokowane}");
            try
            {
                konto.Wplata(20);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            konto.OdblokujKonto();
            Console.WriteLine($"Konto odblokowane: {konto.Zablokowane}");

            // Symulacja działania konta z limitem debetowym (KontoPlus)
            Console.WriteLine("\nSymulacja działania konta z limitem debetowym (KontoPlus):");
            KontoPlus.KontoPlus kontoPlus = new KontoPlus.KontoPlus("Anna Nowak", 100, 50);
            Console.WriteLine($"Nazwa: {kontoPlus.Nazwa}, Bilans: {kontoPlus.Bilans}");

            kontoPlus.Wplata(50);
            Console.WriteLine($"Po wpłacie 50: Bilans: {kontoPlus.Bilans}");

            kontoPlus.Wyplata(120);
            Console.WriteLine($"Po wypłacie 120: Bilans: {kontoPlus.Bilans}, Zablokowane: {kontoPlus.Zablokowane}");

            try
            {
                kontoPlus.Wyplata(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            kontoPlus.Wplata(30);
            Console.WriteLine($"Po wpłacie 30: Bilans: {kontoPlus.Bilans}, Zablokowane: {kontoPlus.Zablokowane}");

            // Symulacja działania konta z limitem debetowym (KontoLimit)
            Console.WriteLine("\nSymulacja działania konta z limitem debetowym (KontoLimit):");
            Bank.KontoLimit kontoLimit = new Bank.KontoLimit("Piotr Kowalski", 100, 50);
            Console.WriteLine($"Nazwa: {kontoLimit.Nazwa}, Bilans: {kontoLimit.Bilans}");

            kontoLimit.Wplata(50);
            Console.WriteLine($"Po wpłacie 50: Bilans: {kontoLimit.Bilans}");

            kontoLimit.Wyplata(120);
            Console.WriteLine($"Po wypłacie 120: Bilans: {kontoLimit.Bilans}, Zablokowane: {kontoLimit.Zablokowane}");

            try
            {
                kontoLimit.Wyplata(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            kontoLimit.Wplata(30);
            Console.WriteLine($"Po wpłacie 30: Bilans: {kontoLimit.Bilans}, Zablokowane: {kontoLimit.Zablokowane}");
        }
    }
}