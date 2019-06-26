using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa służąca do obsługi podstatowych statystyk gracza.
/// </summary>
public class StatystkiGracza : MonoBehaviour
{
    /// <summary>
    /// Zmienna zawiera informacje o tym ile waluty posiada gracz.
    /// </summary>
    public static int Kasa;

    /// <summary>
    /// Zmienna zawiera informację o tym ile waluty na początku gry będzie miał gracz.
    /// </summary>
    public int KasaNaStart = 800;

    /// <summary>
    /// Zmienna zawiera informacje o tym ile żyć posiada gracz.
    /// </summary>
    public static int Zycia;
    /// <summary>
    /// Zmienna zawiera informacje o tym ile żyć na początku gry posiada grracz.
    /// </summary>
    public int ZyciaNaPoczatek= 3;

    /// <summary>
    /// Zmienna służy od określenia ile rund / fal przeciwników przetrwał gracz.
    /// </summary>
    public static int LiczbaRund;

    /// <summary>
    /// Metoda inicjuje podstawowe wartości zmiennaych na te które ustawione są jako poczatkowe.
    /// </summary>
    private void Start()
    {
        Kasa = KasaNaStart;
        Zycia = ZyciaNaPoczatek;

        LiczbaRund = 0;
    }

}
