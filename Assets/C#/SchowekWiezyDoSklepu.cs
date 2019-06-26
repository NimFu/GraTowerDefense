using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klasa służąca do przechowywania informacji o wieżach.
/// </summary>
[System.Serializable]
public class SchowekWiezyDoSklepu
{
    public GameObject wiezaprefab;
    public int koszt;

    public GameObject UlepszonaWieza;
    public int kosztulepszenia;

    /// <summary>
    /// Metoda która zarząda wartością sprzedazy wiezy.
    /// </summary>
    /// <returns>Zwraca graczowi połowę wartośi wieży</returns>
    public int KasaZaSprzedaz()
    {
        return koszt / 2;
    }
}
