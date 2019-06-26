using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Klasa służy do obsługi czynności tkaich jak budowa,ulepszanie oraz sprzedaż wież.
/// </summary>
public class Buduj : MonoBehaviour
{

    /// <summary>
    /// Kolor służący do cieniowania wybranego pola na planszy.
    /// </summary>
    public Color Cieniuj;

    /// <summary>
    /// Obiekt gry służący do przechowywania obiektu jakim jest wybrna przez nas wieża.
    /// </summary>
    public  GameObject wieza;
    public SchowekWiezyDoSklepu wiezaprefabik;

    /// <summary>
    /// Zmienna potrzebna do sprawdzenia czy wybudowana wieża jest ulepszona
    /// </summary>
    public bool CzyUlepszona = false;

    /// <summary>
    /// Obiekt z gry przechowywujący efekt wizualny ulepszenia wieży.
    /// </summary>
    public GameObject efektUlepszania;

    /// <summary>
    /// Zmienna pozwalająca pobrać kolor naszsej planszy.
    /// </summary>
    private Renderer rend;

    /// <summary>
    /// Zmienna przechowywująca kolor początkowy planszy.
    /// </summary>
    private Color Poczatkowy;

    /// <summary>
    /// Wektor 3D pozwalający na przesówanie wiezy na planszy.
    /// </summary>
    public Vector3 PozycjaWiezy;
    BudowanieWiez budowanieWie;
    /// <summary>
    /// Zmienna przechowywująca kolor, który jest wyśiwtlany na wybranym polu gdy nie mamy wystarczająco waluty by cos zrobić.
    /// </summary>
    public Color BrakKasyKolor;
   
    /// <summary>
    /// Metoda Start pobierająca kolor z planszy i przechowywująca go w zmiennej Poczaatkowy oraz wywołująca metody z klasy BudowanieWież.
    /// </summary>
    private void Start()
    {
        rend = GetComponent<Renderer>();
        Poczatkowy = rend.material.color;
        budowanieWie = BudowanieWiez.zarzadca;
    }

    /// <summary>
    /// Metoda która służy do zwracania wektora na którym zbudujemy wieże.
    /// </summary>
    /// <returns>Zwraca wektor pola i dodane do niego ustawione prze developera wartości które powduja że wieża wybudowana jest dokładnie na środku planszy a nie pod nią czy nad nią</returns>
    public Vector3 PozycjaBudowyWiezy()
    {
        return transform.position + PozycjaWiezy;
    }

    /// <summary>
    /// Metoda sprawdza czy na wybranym prze nas polu do budowania wieży nie ma już wybudowanej wieży i poozwala wybudować gdy takowej nie ma.
    /// Działa ona tylko wtedy gdy użytkownik kliknie myszą na wybrane pole.
    /// </summary>
    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        if(wieza != null)
        {
            budowanieWie.WybranyElementPlanszy(this);
            return;
        }

        if (!budowanieWie.MoznaBudowac)
            return;

        ZbudujWieze(budowanieWie.PrzekazWiezeDoBudowy());
    }

    /// <summary>
    /// Metoda pobierająca jako parametr wybraną przez na wieże do budowy po czym tworzy taką wieże na wybranym przez na polu
    /// i odejmuje wirtualna walutę którą ta wieża jest warta.
    /// </summary>
    /// <param name="prefab"></param>
    void ZbudujWieze(SchowekWiezyDoSklepu prefab)
    {
        if (StatystkiGracza.Kasa < prefab.koszt)
        {
            Debug.Log("brak kasy");
            return;
        }

        StatystkiGracza.Kasa -= prefab.koszt;
        GameObject wiezyczki = (GameObject)Instantiate(prefab.wiezaprefab, PozycjaBudowyWiezy(), Quaternion.identity);
        wieza = wiezyczki;

       wiezaprefabik = prefab;
        Debug.Log("Wieza zbudowana");
        
    }


    /// <summary>
    /// Metora wywoływana gdy użytkownik naciście przycisj Sprzedaj dodaje ona walute do portfela gracza, która warta jest sprzedana wieża
    /// oraz niszczy obiekt w grze.
    /// </summary>
    public void SprzedajWieze()
    {
        StatystkiGracza.Kasa += wiezaprefabik.KasaZaSprzedaz();
        Destroy(wieza);
        wiezaprefabik = null;
        CzyUlepszona = false;
    }

    /// <summary>
    /// Metoda która wywoływana jest gdy gracz naciśnie przycisk Ulepsz na wieży podminia ona niszczy ona wybudowaną przez użytkownika
    /// wieże po czym na jej miejsce buduje ulepszoną jej wersje oraz odejmuje walute z portfela gracza która jest potrzebna do tej czynności.
    /// Dodatkowo wywołuje efekt wizualny ulepszania wieży.
    /// </summary>
    public void UlepszanieWiezy()
    {
        if (StatystkiGracza.Kasa < wiezaprefabik.kosztulepszenia)
        {
            Debug.Log("Brak kasy do upgradu");
            return;
        }

        StatystkiGracza.Kasa -= wiezaprefabik.kosztulepszenia;
        Destroy(wieza);
        GameObject wiezyczki = (GameObject)Instantiate(wiezaprefabik.UlepszonaWieza, PozycjaBudowyWiezy(), Quaternion.identity);
        wieza = wiezyczki;

        GameObject efekt = (GameObject)Instantiate(efektUlepszania, PozycjaBudowyWiezy(), Quaternion.identity);
        Destroy(efekt, 0.7f);
        CzyUlepszona = true;
        Debug.Log("Wieza ulepszona");
    }
    /// <summary>
    /// Metoda która po najechaniu myszą na jakiekolwiek pole do budowy zmienia jego kolor na inny.
    /// </summary>
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!budowanieWie.MoznaBudowac)
            return;

        if (budowanieWie.SprawdzCzyMamyKase)
        {
            rend.material.color = Cieniuj;
        }
        else
        {
            rend.material.color = BrakKasyKolor;
        }
    }


    /// <summary>
    /// Metoda która po tym jak opuściliśmy wymmiary pola do budowy zwraca mu początkowy kolor.
    /// </summary>
    private void OnMouseExit()
    {
        rend.material.color = Poczatkowy;
    }
}

