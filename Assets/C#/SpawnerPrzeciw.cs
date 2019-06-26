using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Klasa służaca do obsługi tworzenia przeciwników dla użytkownika oraz zarządzająca czasomierzem odliczającym czas do następej fali przeciwników.
/// </summary>

public class SpawnerPrzeciw : MonoBehaviour
{
    /// <summary>
    /// Tablica przechowywujaca wrogów, służy do tego aby można było wywołac rózne rodzaje przeciwników.
    /// </summary>
    public SchowekNaWrogow[] wrog;

    /// <summary>
    /// Zmienna pobiera położenie punktuStartu czyli punktu z którego wychodzą przeciwnicy.
    /// </summary>
    public Transform punktStartu;

    /// <summary>
    /// Zmienna zawiera informacje o tym ile czasu jest do następnej fali.
    /// </summary>
    public float czasMiedzyFalami = 5f;

    /// <summary>
    /// Zmienna słuzy do zmiany timera na ekranie, który opkazuje czas do następnej fali.
    /// </summary>
    public float odliczanie = 2f;
        
    /// <summary>
    /// Zmienna słuzy do manipulowania tekstem timera.
    /// </summary>
    public Text odliczanieDoFali;

    /// <summary>
    /// Zmienna zawiera informacje o tym ilu przeciwników jest na planszy.
    /// </summary>
    public static int LiczbaPrzeciwnikow = 0;

    /// <summary>
    /// Zmienna zawiera informacje o tym która obecnie fala przeciwników jest tworzona.
    /// </summary>
    private int numerFali = 0;

    /// <summary>
    /// Metoda inicjuje zmienną Liczba przeciwników na 0, ponieważ na początku gry nie mam żadnego.
    /// </summary>
    private void Start()
    {
        LiczbaPrzeciwnikow = 0;
    }

    /// <summary>
    /// Metoda nie pozwala na stworzenie kolejnych przeciwników podczas gry jakiś przeciwnik pozostał na mapnie z poprzedniej fali
    /// Dodatkowo zajmuje sie ustawianiem czasu odliczania do następnej fali i tworzeniem przeciwników.
    /// </summary>
    void Update()
    {

        if (LiczbaPrzeciwnikow > 0)
            return;

        if(odliczanie <= 0f)
        {
            StartCoroutine(StworzPrzeciwnika());
            odliczanie = czasMiedzyFalami;
            return;
        }

        odliczanie -= Time.deltaTime;

        odliczanieDoFali.text = Mathf.Round(odliczanie).ToString();
    }

    /// <summary>
    /// Metoda stworzona do wspólpracy z wbudowaną metodą Unity StartCorutine czyli powtarza czynnosci jakie są zapisane w tej metodzie.
    /// A jest to zwiekszenie licznika fali, pobranie odpowiedniego wroga, oraz stworzenie dobrej ilosci wrogów na planszy czyli takiej
    /// która jest okreslona przez ilość rund. Czyli jeśli aktualnie mamy runde 2 to przeciwników bd 2 itd.
    /// </summary>
    

    IEnumerator StworzPrzeciwnika()
    {
        numerFali++;
        StatystkiGracza.LiczbaRund++;

        SchowekNaWrogow w = wrog[WylosujWroga()];       
        for (int i = 0; i < numerFali; i++)
        {
            StworzWroga(w.wrogPrefab);
            yield return new WaitForSeconds(0.5f);
        }

    }

    /// <summary>
    /// Metoda przyjmmująca za parametr obiekt jakim jest wróg z gry i stwarzająca go w odpowiednim miejscu.
    /// </summary>
    /// <param name="wrogg"> Parametr przyjmowany przez metodę to obiekt z gry będący obiektem "Przeciwnika".</param>
    void StworzWroga(GameObject wrogg) {
        Instantiate(wrogg, punktStartu.position, punktStartu.rotation);
        LiczbaPrzeciwnikow++;
    }

    /// <summary>
    /// Metoda zwracająca randomową liczbę od 0 do 2. Liczba słuzy do odpowiedniego zainicjowania obiektu jakim jest wróg do metody która ich tworzy.
    /// </summary>
    /// <returns>Metoda zwraca numer od 0 do 2 czyli numer przypisany do poszczególnego rodzaju wroga</returns>
    public int WylosujWroga()
    {
        int random = Random.Range(0, 3);
        return random;
    }

}
