2026-02-11 — v1.0.0 — Changelog dla Program.cs:1-144

Krótki opis

•	Zmiany poprawiają skalowalność, walidację wejścia, enkapsulację i logikę biznesową programu zarządzającego flotą samochodów.

Główne zmiany (zwięźle)

•	Samochod[2] → List<Samochod> — dynamiczne dodawanie dowolnej liczby pojazdów (flota).

•	Dodano uniwersalną metodę WczytajLiczbe(string prompt, int min = int.MinValue, int max = int.MaxValue) obsługującą int.TryParse i ograniczenia zakresu.

•	Prywatne pola z _camelCase (_marka, _model, _przebieg, _alert).

•	Właściwości tylko do odczytu — expression-bodied (public string marka => _marka;).

•	Sprawdzenie stanu floty (flota.Count == 0) przed operacjami które indeksują listę — zapobiega IndexOutOfRange.

Pliki zmodyfikowane / rekomendowane

Wpływ na działanie / zachowanie

•	Program obsługuje teraz dowolną liczbę samochodów.

•	Wszelkie niepoprawne liczby są centralnie walidowane przez WczytajLiczbe(string, int, int).

•	Operacje na flocie zabezpieczone przed pustą listą.

