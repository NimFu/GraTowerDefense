using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klasa obsługująca takie elementy jak obrót góry wieży, naacelowanie wiezy na przeciwnika oraz tworzenie naboi.
/// </summary>
public class WiezaRuch : MonoBehaviour
{
    
    /// <summary>
    /// Zmienna zwiera informacje o położeniu wroga.
    /// </summary>
    [Header("Pola Unity")]
    public Transform cel;
    /// <summary>
    /// Zmienna potrzebna do zainicjowania metody obiektem worga.
    /// </summary>
    [Header("Pola Unity")]
    public string cel1 = "Przeciwnicy";
    /// <summary>
    /// Zmienna pobiera położenie górnej częsci wieży która się obraca.
    /// </summary>
    public Transform GoraObrot;

    /// <summary>
    /// Zmienna wyznacza z jaką prędkoscią obraca się wieza.
    /// </summary>
    public float szybkoscObrotu = 8f;


    public GameObject Nabojprefab;
    /// <summary>
    /// Zmienna pobiera położenie punktu w grze z którego będą wystrzeliwane pociski.
    /// </summary>
    public Transform punktWystrzalu;

    /// <summary>
    /// Zmiena określa wieklość sfery która ogranicza możliwości wykrywania wrogów wieży.
    /// </summary>
    [Header("Atrybuty Wiezy")]

    public float zakresStrzalu = 12f;

    /// <summary>
    /// Zmienna informuje z jaką szybkością będą lecieć pociski.
    /// </summary>
    public float SzybkoscStrzalu = 1f;

    /// <summary>
    /// Zmienna informuje ile trzeba odczekać pomiędzy strzałami.
    /// </summary>
    public float OdstepStrzalow = 0f;
    /// <summary>
    /// Metoda sprawdza czy jest dostępny cel dla wieży.
    /// </summary>
    void Start()
    {
        InvokeRepeating("Celuj", 0f, 0.5f); //petla metody Celuj
    }

    /// <summary>
    /// Metoda ustawia dystans , położenie oraz sam cel dla naboi.
    /// </summary>
    void Celuj() {
        GameObject[] cele = GameObject.FindGameObjectsWithTag(cel1);

        float najkrotszyDystansDoCelu = Mathf.Infinity;
        GameObject najblizszyCel = null;

        // nacelowanie na przeciwnika
        foreach (GameObject enemy in cele)
        {
            float dystansDoCelu = Vector3.Distance(transform.position, enemy.transform.position);
            if (dystansDoCelu < najkrotszyDystansDoCelu) {
                najkrotszyDystansDoCelu = dystansDoCelu;
                najblizszyCel = enemy;
            }
        }

        //ustawianie celu do ostrzalu
        if (najblizszyCel != null && najkrotszyDystansDoCelu <= zakresStrzalu)
        {
            cel = najblizszyCel.transform;
        }
        else
        {
            cel = null;
        }
    }

   /// <summary>
   /// Metoda zarząda obrotem górnej wieży wieżyczki oraz wywołuje metode strzelaj która tworzy naboie.
   /// </summary>
    void Update()
    {
        //obrot gory wiezy
        if (cel == null)
            return;

        Vector3 dir = cel.position - transform.position;
        Quaternion obrotWiezy = Quaternion.LookRotation(dir);
        Vector3 obrot = Quaternion.Lerp(GoraObrot.rotation, obrotWiezy, Time.deltaTime * szybkoscObrotu).eulerAngles;
        GoraObrot.rotation = Quaternion.Euler(0f,obrot.y,0f);

        //odstęp do kolejnego strzalu
        if (OdstepStrzalow <= 0f)
        {
            Strzelaj();
            OdstepStrzalow = 1f / SzybkoscStrzalu;
        }

        OdstepStrzalow -= Time.deltaTime;


    }

    /// <summary>
    /// Metoda tworzy pociski w grze oraz wywołuje metode SzukajCelu dla naboi.
    /// </summary>
    void Strzelaj()
    {
   
        GameObject Nabojprefab1 = (GameObject)Instantiate(Nabojprefab, punktWystrzalu.position, punktWystrzalu.rotation);
        NabojRuch Naboj = Nabojprefab1.GetComponent<NabojRuch>();

        if (Naboj != null)
            Naboj.SzukajCelu(cel);
    }

    /// <summary>
    /// Metoda powoduje rysowanie sfery ktora pokazuje zasieg naszej wiezy po klikniecu.
    /// </summary>
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, zakresStrzalu);
    }
}
