using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Klasa odpowiadająca za działanie przycisków w Menu Głównym Gry.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Metoda powoduje załadowanie się planszy z grą, co pozwala na rozpoczęcie gry przez użytkownika.
    /// </summary>
  public void Graj()
    {
        SceneManager.LoadScene("GlownaPlansza");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;

        }

    }

    /// <summary>
    /// Metoa powoduje zamknięcie aplikacji.
    /// </summary>
    public void Wyjdz()
    {
        Application.Quit();
    }
 }
