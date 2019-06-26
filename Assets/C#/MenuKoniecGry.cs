using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa zawierająca elementy oraz metody potrzebne do prawidłowego działania Menu wyłaniającego się gdy liczba żyć gracza spadnie do 0.
/// </summary>
public class MenuKoniecGry : MonoBehaviour
{
    /// <summary>
    /// Zmienna służąca do zmiany tekstu w odpowiednium polu tekstowym w menu.
    /// </summary>
    public Text LiczbaRundText;

    /// <summary>
    /// Metoda która po tym jak życia gracza spadną do 0 wyswietla na ekranie napis ilu przeciwników udało mu sie pokonać.
    /// </summary>
    private void OnEnable()
    {
        LiczbaRundText.text = StatystkiGracza.LiczbaRund.ToString();
    }

    /// <summary>
    /// Metoda pozwalająca na zaczęcie gry od nowa przez gracza.
    /// </summary>
    public void Powtórka() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            
        }
    }
}
