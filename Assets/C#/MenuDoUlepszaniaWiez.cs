using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa zawierająca metody potrzebne do ulepszenia wież.
/// </summary>
public class MenuDoUlepszaniaWiez : MonoBehaviour
{
    /// <summary>
    /// Obiekt klasy która pozwala budować wieże na wybranym polu. Pozwala wywołać metody z tej klasy.
    /// </summary>
    private Buduj WybranyElement;

    /// <summary>
    /// Obiekt z gry określający fizyczne menu do ulepszenia wież.
    /// </summary>
    public GameObject menu;

    /// <summary>
    /// Przycisk z gry określający fizyczny przycisk do ulepszania wieży.
    /// </summary>
    public Button PrzuciskUlepszenia;

    /// <summary>
    /// Tekst z gry, orkeślający tekst wyswietlany na przycisku służączym do ulepszenia wieży.
    /// </summary>
    public Text UlepszText;

    /// <summary>
    /// Tekst z gry, orkeślający tekst wyswietlany na przycisku służączym do sprzedawania wieży.
    /// </summary>
    public Text SprzedajText;

    /// <summary>
    /// Metoda przyjmująca jako parametr obiekt z klasy Buduj, ustawiająca pozycje naszej wieży zgodnie z parametrami pobranymi z klasy Buduj,
    /// sprawdzająca czy ulepszyliśmy wieże oraz wywołująca odpowiednie akcje takie jak wyświetlanie tekstu na przycisku czy podświetlanie dla przycisku UlepszWieże 
    /// oraz otwiera menu Sprzedaj/Ulepsz jeśli wieża jest ulepszona.
    /// </summary>
    /// <param name="_WybranyElement"> Parametr pobieranym przez metode jest obiek klasy Buduj</param>
    public void WbierzElementDoRozbudowy(Buduj _WybranyElement) {
        WybranyElement = _WybranyElement;

        transform.position = WybranyElement.PozycjaBudowyWiezy();
        if (!WybranyElement.CzyUlepszona)
        {
            UlepszText.text = "Ulepsz " + WybranyElement.wiezaprefabik.kosztulepszenia + "€";
            PrzuciskUlepszenia.interactable = true;
        }else
        {
            UlepszText.text = "Ulepszono";
            PrzuciskUlepszenia.interactable = false;
        }

        SprzedajText.text = "Sprzedaj " + WybranyElement.wiezaprefabik.KasaZaSprzedaz();
        menu.SetActive(true);
    }

    /// <summary>
    /// Metoda zamykająca menu do ulepszeń.
    /// </summary>
    public void ZamknijMenuDoUlepszen() {
        menu.SetActive(false);
    }

    /// <summary>
    /// Metoda służaca do wywoływania metody do  sprzedawania wieży oraz wywoływania metody z klasy BudujWieże.
    /// </summary>
    public void Sprzedaj()
    {
        WybranyElement.SprzedajWieze();
        BudowanieWiez.zarzadca.ZamknijMenu();
    }


    /// <summary>
    /// Metoda która slużąca do wywoływanie=a metody do ulepszenia wiezy oraz metody z klasy BudujWieze.
    /// </summary>
    public void Ulepszanie()
    {
        WybranyElement.UlepszanieWiezy();
        BudowanieWiez.zarzadca.ZamknijMenu();
    }
}
