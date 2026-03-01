# Changelog

Wszystkie istotne zmiany w projekcie.

## [1.1.0] - 2026-03-01
### Dodano
- Zarządzanie paliwem w `Program.cs` / klasa `Samochod`:
  - pola: `_bakPaliwa`, `_spalanie`, `_paliwo` oraz odpowiadające im tylko do odczytu właściwości.
  - konstruktor `Samochod(string marka, string model, int przebieg, int bakPaliwa, double spalanie, double paliwo)`.
  - metoda `Zatankuj(double)` — tankowanie z walidacją pojemności baku.
  - aktualizacja `StworzSamochod()` — wczytanie pojemności baku i średniego spalania, inicjalizacja paliwa (pełny bak).
  - wyświetlanie stanu paliwa i pojemności w `WypiszDane(...)`.
- Nowe helpery wejścia/wyjścia:
  - `WczytajInt(string prompt, int min = int.MinValue, int max = int.MaxValue)` — bezpieczne wczytywanie `int`.
  - `WczytajDouble(string prompt, double min = double.MinValue, double max = double.MaxValue)` — bezpieczne wczytywanie `double`.
  - `WyświetlKomunikat(string prompt)` — scentralizowane wypisywanie komunikatów.
- Menu: nowa opcja `4 – Zatankuj` umożliwiająca tankowanie wybranego samochodu.

### Zmodyfikowano
- `Jedz(int)`:
  - sprawdza zasięg na bazie obecnego paliwa i średniego spalania,
  - zmniejsza `_paliwo` po przejechaniu dystansu,
  - zachowano mechanizm dodawania alertu serwisowego przy przekroczeniu progu 10 000 km oraz wyświetlanie komunikatów.
- `StworzSamochod()` i komunikaty wejściowe: poprawiono prompt dla modelu (zamiast powtórzonego "Podaj marke" -> "Podaj model").
- `WypiszDane(...)` rozszerzone o informacje paliwowe.


2026-02-22 - v1.0.1 - Changelog dla Program.cs:1-144

• Poprawiono konstruktor

• Poprawiono walidacje tekstu

• Poprawiono błędy związane z danymi wejściowymi

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

