
class Program
{
    public static void Main(string[] args)
    {
        List<Samochod> flota = new List<Samochod>();

        Console.WriteLine("Dodawanie samochodu nr1:");
        flota.Add(StworzSamochod());

        Console.WriteLine("Dodawanie samochodu nr2:");
        flota.Add(StworzSamochod());

        Menu(flota);
    }
    public static Samochod StworzSamochod()
    {
        Console.WriteLine("Podaj marke");
        string marka = Console.ReadLine();
        Console.WriteLine("Podaj model");
        string model = Console.ReadLine();
        int przebieg;
        Console.Write("Podaj przebieg: ");
        while (!int.TryParse(Console.ReadLine(), out przebieg) || przebieg <= 0)
        {
            Console.WriteLine("Błąd! Podaj liczbę");
        }
        return new Samochod(marka, model, przebieg);
    }    
    public static int Wybor()
    {
        int nr = 0;
        while (nr != 1 && nr != 2)
        {
            Console.WriteLine("Wybierz samochód (1 albo 2)");
            if (!int.TryParse(Console.ReadLine(), out nr))
            {
                Console.WriteLine("To nie jest liczba!");
            }
            
        }return nr;
    }
    public static void WypiszDane(Samochod auto, int nr)
    {
        Console.WriteLine($"\nDane samochodu nr {nr}:");
        Console.WriteLine($"\nMarka samochodu to {auto.marka}");
        Console.WriteLine($"Model samochodu to {auto.model}");
        Console.WriteLine($"Przebieg samochodu to {auto.przebieg}");
        Console.WriteLine($"Alerty: {auto.alert}");
    }
    public static void Menu(List<Samochod> flota)
    {            
        int wybor = -1;
        while (wybor != 0)
        {
            Console.WriteLine("\n=====MENU=====");
            Console.WriteLine("1 – Jedź");
            Console.WriteLine("2 – Wyswietl dane samochodu");
            Console.WriteLine("0 – Wyjście");

            Console.WriteLine("Wprowadz odpowiednią liczbe");



            while (!int.TryParse(Console.ReadLine(), out wybor) || (wybor < 0 || wybor > 2))
            {
                Console.WriteLine("Nieprawidlowy wybor. Podaj 0, 1 lub 2.");
                wybor = -1;

            }
            if (wybor == 0) break;

            int nr = Wybor();
            Samochod wybrane = flota[nr - 1];

            int km = 0;
            if (wybor == 1)
            {
                Console.WriteLine("Ile kilometrów");
                while (!int.TryParse(Console.ReadLine(), out km) || km <= 0)
                {
                    Console.WriteLine("Niepoprawna liczba. Podaj jeszcze raz.");
                    continue;
                }
                
                wybrane.Jedz(km);
            }

            else if (wybor == 2)
            {
                WypiszDane(wybrane, nr);
            }

        }
    }
public class Samochod
{
        private string marka1;
        private string model1;
        private int przebieg1;
        private string alert1 = "";

        public string marka => marka1;
        public string model => model1;
        public int przebieg => przebieg1;
        public string alert => alert1;
        public Samochod(string marka, string model, int przebieg)
        {
            marka1 = marka;
            model1 = model;
            przebieg1 = przebieg;
            alert1 = alert;
        }
        public void Jedz(int dystans)
        {
            int stareDane = przebieg1 / 10000;
            przebieg1 += dystans;
            int noweDane = przebieg / 10000;
            if (noweDane > stareDane)
            {
                DodajAlert("WYMAGANY PRZEGLĄD! ");
            }
        }

            private void DodajAlert(string komunikat)
    {
        {
            alert1 += komunikat;
        }
    }
}
    }