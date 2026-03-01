
using System;
class Program
{
    public static void Main(string[] args)
    {
        List<Samochod> flota = new List<Samochod>();

        Menu(flota);
    }
    public static Samochod StworzSamochod()
    {
        Console.WriteLine("Dodawanie samochodu...");
        string marka = "";
        string model = "";
        while (string.IsNullOrWhiteSpace(marka)){
            Console.WriteLine("Podaj marke");
            marka = Console.ReadLine();

        }
        while (string.IsNullOrWhiteSpace(model))
        {
            Console.WriteLine("Podaj model");
            model = Console.ReadLine();
        }

        int przebieg = WczytajInt("Podaj przebieg", 0);

        int bakPaliwa = WczytajInt("Podaj pojemność baku paliwa (l)", 0);

        double spalanie = WczytajDouble("Podaj średnie spalanie na 100km (l)", 0);
        double paliwo = bakPaliwa;

        return new Samochod(marka, model, przebieg, bakPaliwa, spalanie, paliwo);
    }    
    public static int Wybor(List<Samochod> flota)
    {
        if (flota.Count == 0) return -1;
        return WczytajInt("Wybierz numer samochodu", 1, flota.Count);

    }
    public static void WypiszDane(Samochod auto, int nr)
    {
        Console.WriteLine($"\nDane samochodu nr {nr}:");
        Console.WriteLine($"\nMarka samochodu to {auto.marka}");
        Console.WriteLine($"Model samochodu to {auto.model}");
        Console.WriteLine($"Przebieg samochodu to {auto.przebieg}");
        Console.WriteLine($"Pojemność baku paliwa to {auto.bakPaliwa}l");
        Console.WriteLine($"Obecny stan paliwa to {auto.paliwo}");
        Console.WriteLine($"Alerty: {auto.alert}");
    }
    public static int WczytajInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        int wynik;
        while (true)
        {
            Console.Write($"{prompt}: ");
            if (int.TryParse(Console.ReadLine(), out wynik) && wynik >= min && wynik <= max)
            {
                return wynik;
            }
            Console.WriteLine($"Błąd! Podaj poprawną liczbę.");
        }
    }
    public static double WczytajDouble(string prompt, double min = double.MinValue, double max = double.MaxValue)
    {
        double wynik;
        while (true)
        {
            Console.Write($"{prompt}: ");
            if (double.TryParse(Console.ReadLine(), out wynik) && wynik >= min && wynik <= max)
            {
                return wynik;
            }
            Console.WriteLine($"Błąd! Podaj poprawną liczbę.");
        }
    }
    public static void WyświetlKomunikat(string prompt)
    {
        Console.WriteLine($"Komunikat: {prompt}");
    }
    public static void Menu(List<Samochod> flota)
    {
        int wybor = -1;
        while (wybor != 0)
        {
            Console.WriteLine("\n=====MENU=====");
            Console.WriteLine("1 – Dodaj samochód");
            Console.WriteLine("2 – Wyswietl dane samochodu");
            Console.WriteLine("3 - Jedź");
            Console.WriteLine("4 - Zatankuj");
            Console.WriteLine("0 – Wyjście");


            wybor = WczytajInt("Wybierz opcję", 0, 4);


            if (wybor == 0) break;

            if (wybor == 1)
            {
                flota.Add(StworzSamochod());
            }
            if (wybor == 3)
                if (flota.Count == 0)
                {
                    Console.WriteLine("Flota jest pusta. Najpierw dodaj samochod");
                }
                else
                {
                    int nr = Wybor(flota);
                    Samochod wybrane = flota[nr - 1];
                    int km = 0;
                    km = WczytajInt("Ile kilometrów?", 0);

                    wybrane.Jedz(km);
                }

            else if (wybor == 2)
            {
                if (flota.Count == 0)
                {
                    Console.WriteLine("Flota jest pusta. Najpierw dodaj samochod");
                }
                else
                {
                    int nr = Wybor(flota);
                    Samochod wybrane = flota[nr - 1];
                    WypiszDane(wybrane, nr);
                }
            }
            else if (wybor == 4)
            {
                if (flota.Count == 0)
                {
                    Console.WriteLine("Flota jest pusta. Najpierw dodaj samochod");
                }
                else
                {
                    int nr = Wybor(flota);
                    Samochod wybrane = flota[nr - 1];
                    double ilosc = WczytajDouble("Ile chcesz zatankować?", 0);
                    wybrane.Zatankuj(ilosc);
                }
            }
        }
    }
public class Samochod
{
        private string _marka;
        private string _model;
        private int _przebieg;
        private string _alert = "";
        private int _bakPaliwa;
        private double _spalanie;
        private double _paliwo;

        public string marka => _marka;
        public string model => _model;
        public int przebieg => _przebieg;
        public string alert => _alert;
        public int bakPaliwa => _bakPaliwa;
        public double spalanie => _spalanie;
        public double paliwo => _paliwo;

        public Samochod(string marka, string model, int przebieg, int bakPaliwa, double spalanie, double paliwo)
        {
            _marka = marka;
            _model = model;
            _przebieg = przebieg;
            _bakPaliwa = bakPaliwa;
            _spalanie = spalanie;
            _paliwo = paliwo;

        }
        public void Jedz(int dystans)
        {
            double zasieg = (_paliwo / _spalanie * 100);
            if (dystans <= zasieg)
            {
                int stareDane = _przebieg / 10000;
                _przebieg += dystans;
                WyświetlKomunikat($"Przejechałeś właśnie {dystans}km");
                _paliwo -= (dystans * spalanie) / 100;
                int noweDane = _przebieg / 10000;
                if (noweDane > stareDane)
                {
                    DodajAlert("WYMAGANY PRZEGLĄD! ");
                    WyświetlKomunikat("WYMAGANY PRZEGLĄD!");
                }
            }
            else WyświetlKomunikat("Nie masz tyle paliwa aby przejechać taką trase");
        }
        public void Zatankuj(double ilosc)
        {
            if (ilosc <= 0)
            {
                WyświetlKomunikat("Ilosc paliwa musi być dodatnia");
            }
            else if (_paliwo + ilosc > _bakPaliwa)
            {
                WyświetlKomunikat("Nie zmieścisz tyle paliwa");
            }
            else
            {
                _paliwo += ilosc;
                WyświetlKomunikat($"Zatankowano {ilosc}l. Obecny stan {_paliwo}l");
            }
    }

        private void DodajAlert(string komunikat)
    {
        {
            _alert += komunikat;
        }
        }
    }
    }
