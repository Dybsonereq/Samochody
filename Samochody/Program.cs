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
        while (marka == ""){
            Console.WriteLine("Podaj marke");
            marka = Console.ReadLine();

        }
        while (model == "")
        {
            Console.WriteLine("Podaj marke");
            model = Console.ReadLine();
        }

        int przebieg = WczytajLiczbe("Podaj przebieg", 0);

        return new Samochod(marka, model, przebieg);
    }    
    public static int Wybor(List<Samochod> flota)
    {
        if (flota.Count == 0) return -1;
        return WczytajLiczbe("Wybierz numer samochodu", 1, flota.Count);

    }
    public static void WypiszDane(Samochod auto, int nr)
    {
        Console.WriteLine($"\nDane samochodu nr {nr}:");
        Console.WriteLine($"\nMarka samochodu to {auto.marka}");
        Console.WriteLine($"Model samochodu to {auto.model}");
        Console.WriteLine($"Przebieg samochodu to {auto.przebieg}");
        Console.WriteLine($"Alerty: {auto.alert}");
    }
    public static int WczytajLiczbe(string prompt, int min = int.MinValue, int max = int.MaxValue)
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
    public static void Menu(List<Samochod> flota)
    {            
        int wybor = -1;
        while (wybor != 0)
        {
            Console.WriteLine("\n=====MENU=====");
            Console.WriteLine("1 – Dodaj samochód");
            Console.WriteLine("2 – Wyswietl dane samochodu");
            Console.WriteLine("3 - Jedź");
            Console.WriteLine("0 – Wyjście");


            wybor = WczytajLiczbe("Wybierz opcję", 0, 3);

           
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
                    km = WczytajLiczbe("Ile kilometrów?", 0);

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
        }
    }
public class Samochod
{
        private string _marka;
        private string _model;
        private int _przebieg;
        private string _alert = "";

        public string marka => _marka;
        public string model => _model;
        public int przebieg => _przebieg;
        public string alert => _alert;
        public Samochod(string marka, string model, int przebieg)
        {
            _marka = marka;
            _model = model;
            _przebieg = przebieg;
            _alert = alert;
        }
        public void Jedz(int dystans)
        {
            int stareDane = _przebieg / 10000;
            _przebieg += dystans;
            int noweDane = przebieg / 10000;
            if (noweDane > stareDane)
            {
                DodajAlert("WYMAGANY PRZEGLĄD! ");
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