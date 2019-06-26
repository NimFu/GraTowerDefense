using UnityEngine;
/// <summary>
/// Klasa wczytująca położenie punkty=ów kontrolnych dla przeciwników przy uruchomieniu.
/// </summary>
public class PunktyKon : MonoBehaviour
{

    /// <summary>
    /// Tablica służąca do przechowywania położnia wszystkich punktów kontrolnych.
    /// </summary>
    public static Transform[] punkt;

   /// <summary>
   /// Metoda wczytuje wartości położenia wszyzstkich punktów kontorlnych przy uruchomieniu aplikacji.
   /// </summary>
    void Awake() {
        punkt = new Transform[transform.childCount];
        for(int i = 0; i < punkt.Length; i++)
        {
            punkt[i] = transform.GetChild(i);
        }
    }
}
