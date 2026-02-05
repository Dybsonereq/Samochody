class Program
{
    public static void Main(string[] args)
    {
        Samochod auto1 = new Samochod();
        Samochod auto2 = new Samochod();
        auto1.PobierzDane();
        auto2.PobierzDane();

        auto1.WypiszDane(1);
        auto2.WypiszDane(2);

        Samochod[] flota = new Samochod[2];
        flota[0] = auto1;
        flota[1] = auto2;

        Menu(flota);
    }
    public static void Menu(Samochod[] flota)
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

            int nr = 0;
            while (nr != 1 && nr != 2)
            {
                Console.WriteLine("Wybierz samochód (1 albo 2)");
                if (!int.TryParse(Console.ReadLine(), out nr))
                {
                    Console.WriteLine("To nie jest liczba!");
                }
            }

            Samochod wybrane = flota[nr - 1];

            int km = 0;
            if (wybor == 1)
            {
                Console.WriteLine("Ile kilometrów");
                while (!int.TryParse(Console.ReadLine(), out km))
                {
                    Console.WriteLine("Niepoprawna liczba. Podaj jeszcze raz.");
                    continue;
                }
                wybrane.Jedz(km);
            }

            if (wybor == 2)
            {
                wybrane.WypiszDane(nr);
            }

        }
    }
public class Samochod
{
    public Samochod()
    {
        
    }
    public string marka;
    public string model;
    public int przebieg;


    public void PobierzDane()
    {
        Console.WriteLine("Podaj marke samochodu.");
        marka = Console.ReadLine();
        Console.WriteLine("Podaj model samochodu.");
        model = Console.ReadLine();
        Console.WriteLine("Podaj przebieg samochodu.");
        while (!int.TryParse(Console.ReadLine(), out przebieg))
            {
            Console.WriteLine("Niepoprawny przebieg. Podaj jeszcze raz.");
            continue;
            }
        ;
    }
    public void WypiszDane(int liczba)
    {
        Console.WriteLine($"\nDane samochodu nr {liczba}:");
        Console.WriteLine($"\nMarka samochodu to {marka}");
        Console.WriteLine($"Model samochodu to {model}");
        Console.WriteLine($"Przebieg samochodu to {przebieg}");
    }

    public void Jedz(int dystans)
    {
        przebieg += dystans;
        Console.WriteLine($"Samochod {marka} {model} przejechał {dystans} km");
    }

    }
}