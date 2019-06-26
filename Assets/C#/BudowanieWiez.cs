using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za pobieranie i przekazywanie odpowiednich rodzai wież do budowy na wybranym polu, nie pozwala również zbudować dwóch wież na jednym polu.
/// </summary>
public class BudowanieWiez : MonoBehaviour
{
   
    public static BudowanieWiez zarzadca;

    
    public MenuDoUlepszaniaWiez menuUlepszania;
    /// <summary>
    /// Metoda sprawdza czy nie chcemy wybudwać dwóch wież na jednym polu i zapobiega temu.
    /// </summary
    private void Awake()
    {
        if (zarzadca != null)
        {
            Debug.LogError("Chcesz zbudować dwie różne żeczy na raz!");
            return;
        }
        zarzadca = this;
    }

    
    private SchowekWiezyDoSklepu WiezaDoBudowy;

   
    private Buduj WybranyObiekt;
    /// <summary>
    /// Zmienna boolowska która służy do zwrócenia true lub false w zależności czy wybraliśmy więżę która chcemu zbudować czy nie.
    /// </summary>
    public bool MoznaBudowac { get { return WiezaDoBudowy != null; } }

    /// <summary>
    /// Zmienna boolowska która służy do zwrócenia true lub false w zależności czy urzytkownik posiada środki na wybudowanie kolejnej wieży.
    /// </summary>
    public bool SprawdzCzyMamyKase { get { return StatystkiGracza.Kasa >= WiezaDoBudowy.koszt; } }


    /// <summary>
    /// Metoda która pobiera jako parametr zmienną z klasy Buduj która określa wybrane przez nas pole do budowy w grze i jeśli zgadza się ono z poprzednio wybranym przez nas polem
    /// oraz na wybranym przez nas polu istnieje zbudowana wież otwiera menu ulepszenia danej wieży. Drugim zastosowaniem jest zamknięcie menu do ulepszeń jeśli wybierzemy to samo 
    /// pole jeszcze raz oraz zapobiega budowaniu przez nas wież gdy nie zostały one przez urzytkownika wybrane.
    /// </summary>
    /// <param name="wybranepole"></param>
    public void WybranyElementPlanszy(Buduj wybranepole) {
        if (WybranyObiekt == wybranepole)
        {
            ZamknijMenu();
            return;
        }
        WybranyObiekt = wybranepole;
        WiezaDoBudowy = null;

        menuUlepszania.WbierzElementDoRozbudowy(wybranepole);
    }

    /// <summary>
    /// Metoda odznacza wybrane przez nas pole do budowy wież na planszy oraz wywołuje metodę z klasy MenuUlepszeń która zamyka Menu ulepszenia danej wieży. 
    /// </summary>
    public void ZamknijMenu()
    {
        WybranyObiekt = null;
        menuUlepszania.ZamknijMenuDoUlepszen();
    }

   /// <summary>
   /// Metoda pobiera parametr z klasy SchowekWiezyDoSklepu jakim jest aktualnie wybrana przez nas wieża , zapisuje w zmiennej WiezaDobudowy oraz wywołuje metodę ZamknijMenu.
   /// </summary>
   /// <param name="wieze"></param>
    public void WybierzWiezeDoBudowy(SchowekWiezyDoSklepu wieze) {
        WiezaDoBudowy = wieze;
        ZamknijMenu();

    }

    /// <summary>
    /// Metoda która ma za zadanie zwrócić/przekazać aktualnie wybraną przez nas wieże do budowy dla innych klas, metod.
    /// </summary>
    /// <returns>Wartością zwracaną jest obiekt gry jakim jest wybrana przez urzytkownika wieża, która chce zbudować.</returns>
    public SchowekWiezyDoSklepu PrzekazWiezeDoBudowy()
    {
        return WiezaDoBudowy;
    }
}
