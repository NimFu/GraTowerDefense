using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Klasa zawiera zmienne, obiekty potrzebne do prawidłowego funkcjownwania  menu Pauzy w grze.
/// </summary>
public class MenuStartPauseitp : MonoBehaviour
{
    /// <summary>
    /// Zmienna boolowska służaca do określenia czy graczowi skończyła się liczba żyć i przegrał.
    /// </summary>
    public static bool gameOver;

    public GameObject KoniecGeyMenu;

    public GameObject PauseMenu;
   
    /// <summary>
    /// Metoda Start, która wywołuje się wraz z startem programu oraz ustawia zmienna gameOver na false czyli gracz nie przegrał.
    /// </summary>
    private void Start()
    {
        gameOver = false;
    }
    /// <summary>
    /// Metoda Update wywołująca metody Pauzuj lub GameOver po naciśnięciu przez urzytkownika odpowiednich przyciskóna klawiaturze.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pauzuj();
        }
       
            if (gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
       if(StatystkiGracza.Zycia <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Metoda która służy do zatrzymania gry.
    /// </summary>
    void Pauzuj()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        if(PauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }
   
    /// <summary>
    /// Metoda służy do wywołania Menu Porażki gdy gracz przegra czyli liczba jego żyć spadnie do 0 lub naciście odpowiendi przycisk.
    /// </summary>
    void GameOver()
    {
        gameOver = true;
        KoniecGeyMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    /// <summary>
    /// Metoda obsługująca przycisk Kontynuuj z menu Pauzy któr pozwal użytkownikowi na ponowne wznowienie gry po uprzednim jego zatrzymaniu.
    /// </summary>
    public void KontynuujButton()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Metoda obsługująca przycisk Menu z menu Pauzy który pozwala na powrót użytkownikowi do menu głównego gry.
    /// </summary>
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
