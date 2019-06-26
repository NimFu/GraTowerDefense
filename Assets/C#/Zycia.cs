using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa zawierająca pola oraz metody służące do aktualizacji ilości żyć użytkownika wraz z postępami w grze.
/// </summary>
public class Zycia : MonoBehaviour
{
    /// <summary>
    /// Zmienna służąca do wyświetlenia ilości żyć na ekranie.
    /// </summary>
    public Text ZyciaText;

    /// <summary>
    /// Metoda aktualizująca ilosć żyć użytkownika.
    /// </summary>
    void Update()
    {
        ZyciaText.text = "Pozostałe Życia: " + StatystkiGracza.Zycia;
    }
}
