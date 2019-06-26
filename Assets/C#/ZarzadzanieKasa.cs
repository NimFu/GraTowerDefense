using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Klasa posiadająca pola orz metody służące do aktaluzacji portfela wirtualnej waluty dla gracza.
/// </summary>
public class ZarzadzanieKasa : MonoBehaviour
{
    /// <summary>
    /// Zmienna służąca do zmieniania wartości portfela w grze.
    /// </summary>
    public Text kasaNapis;
    /// <summary>
    /// Metoda służąca do aktualizacji ilości posiadanej wlauty w portfelu dla gracza.
    /// </summary>
    void Update()
    {
        kasaNapis.text = StatystkiGracza.Kasa.ToString() + "€" ;
    }
}
