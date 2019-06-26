using UnityEngine;


/// <summary>
/// Klasa zawierająca metody potrzebne do poruszania się noboi w grze oraz ich ogólnego zastosowania jak niszczenie przeciwników.
/// </summary>
public class NabojRuch : MonoBehaviour
{
    /// <summary>
    /// Zmienna przechowywująca wartości z położenia oraz wielkości wroga.
    /// </summary>
    private Transform cel;

    /// <summary>
    /// Zmienna przechowywująca prędkość poruszania się naboi.
    /// </summary>
    public float szybkoscKuli = 70f;

    /// <summary>
    /// Zmienna reprezentująca obiekt z gry jakim jest efekt wizualny wybuchu pocisku.
    /// </summary>
    public GameObject efektyWybuchu;

    /// <summary>
    /// Zmienna zawierająca wartość obrażeń jaką pocisk zada przeciwnikowi.
    /// </summary>
    public int WartoscObrazen = 20;

    /// <summary>
    /// Zmienna zwierająca zasięg eksplozi pocisku czyli wymiar sfery.
    /// </summary>
    public float zasiegEksplozji = 0f;

    /// <summary>
    /// Metoda pobierająca jako parametr pozycje przeciwnika co pozwala na ustawienie napoi.
    /// </summary>
    /// <param name="_cel"></param>
    public void SzukajCelu(Transform _cel) {
        cel = _cel;
    }
   

    /// <summary>
    /// Metoda Updata która działa w trakcie grania i służy do niszczenia pocisku w razie gdyby nabój wystrzelono a nie posiadał on celu ponieważ na przykład został on wcześniej zniszczony oraz wyznacza kierunek poruszania sie naboi
    /// </summary>
    void Update()
    {
        //niszczy pocisk gdy ten dosiegnie celu
        if (cel == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = cel.position - transform.position;
        float dystansNaKlatke = szybkoscKuli * Time.deltaTime;

        if (dir.magnitude <= dystansNaKlatke)
        {
            ZderzenieZcelem();
            return;
        }

        transform.Translate(dir.normalized * dystansNaKlatke, Space.World);

        transform.LookAt(cel);
    }


    /// <summary>
    /// Metoda która wywołuje efekt zadawania obrażeń przez naboie oraz wywołuje dwie metody w zależności od parametrów danych naboi oraz po wykonaniu jednej z dwóch metod niszczy pocisk.
    /// </summary>
    void ZderzenieZcelem() {

        GameObject efekty = (GameObject)Instantiate(efektyWybuchu, transform.position, transform.rotation);
        Destroy(efekty, 1f);

        if (zasiegEksplozji > 0f)
        {
            Wybuch();
        }
        else {
            ZadawanieUszkodzen(cel);
        }
        Destroy(gameObject);
    }


    /// <summary>
    /// Metoda która pobiera pozycję przeciwników, przy założeniu że nasz pocisk dotarł do celu i zderzył sie w wrogiem wywołuje metode która zada obrażenia worgowi.
    /// </summary>
    /// <param name="wrog"></param>
    void ZadawanieUszkodzen(Transform wrog)
    {
        PrzeciwnikRuch wrog1 = wrog.GetComponent<PrzeciwnikRuch>();

        if (wrog1 != null)
        {
            wrog1.ZadawanieObrazen(WartoscObrazen);
           
        }
    }

    /// <summary>
    /// Metoda służy do stworzenia niewidzialnej sfery której zasięg jest ograniczony przez parametry pocisku, niewidzialna sfera ma za zadanie wykrycie ilu przeciwników znajduje się w jej polu i wywołanie metody która zada im odpowiednia liczbę obrażeń.
    /// </summary>

    void Wybuch() {
        Collider[] coliders = Physics.OverlapSphere(transform.position, zasiegEksplozji);
        foreach (Collider collider in coliders)
        {
            if (collider.tag == "Przeciwnicy")
            {
                ZadawanieUszkodzen(collider.transform);
            }
        }
    }
}
