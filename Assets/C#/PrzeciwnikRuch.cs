using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa okreslająca jak przeciwnicy będą się poruszać oraz wartości ich atrybutów.
/// </summary>
public class PrzeciwnikRuch : MonoBehaviour
 {

    /// <summary>
    /// Zmienna zawierająca prędkość jaką przeciwnicy będą się poruszać.
    /// </summary>
    public float speed = 10f;

    /// <summary>
    /// Zmienna zawirająca fizyczne położenie przeciwniak w grze.
    /// </summary>
    private Transform przeciwnik;
    /// <summary>
    /// Zmienna określająca przy którym punkcie kontrolnym jest aktualnie przeciwnik.
    /// </summary>
    private int punktykontrolneNumer = 0;

    /// <summary>
    /// Zmienna zawierająca wartość paska życia przeciwników.
    /// </summary>
    public float zycie = 200;

    /// <summary>
    /// Zmienna potrzebna do przekonwertowania wartości życia przeciwnika na odzwierciedlenie graficzne w grze.
    /// </summary>
    public float zyciepasek;


    /// <summary>
    /// Zmienna zawierająca wartość wirtualnej waluty jaką gracz otrzyma za pokonanie przeciwnika.
    /// </summary>
    public int KasaZaSmiercPrzeciwnika = 30;

    /// <summary>
    /// Zmienna odzwierciedlajaca pasek zycia przeciwników grze.
    /// </summary>
    public Image ZyciePasek;
    /// <summary>
    /// Metoda ustawiająca pierwszy punkt kontrolny dla przeciwników na zerowy oraz przypisująca wartość życia przeciwników do paska życia
    /// </summary>
    void Start()
    {
        przeciwnik = PunktyKon.punkt[0];
        zyciepasek = zycie;
    }

    /// <summary>
    /// Metoda przyjmująca za parametr ilość obrażen jaką poszczególny naboj zada przeciwnikowi i zmieniająca zgodnie z tym wygląd paska życia.
    /// </summary>
    /// <param name="wartoscObr"> Parametrem przyjmowanym przez metodę jest zmienna przechowywująca wartość obrażeń jaką wybrany pocisk zadaje celowi.</param>
    public void ZadawanieObrazen(int wartoscObr)
    {
        zycie -= wartoscObr;

        ZyciePasek.fillAmount = zycie / zyciepasek; 
        if(zycie <= 0)
        {
            Smierc();
        }
    }

    /// <summary>
    /// Metoda dodająca graczowi walutę za pokonanie przeciwnika oraz niszcząca przeciwników w grze gdy ten otrzyma wystarczającą liczbę obrażeń.
    /// </summary>
    void Smierc()
    {
        StatystkiGracza.Kasa += KasaZaSmiercPrzeciwnika;

        SpawnerPrzeciw.LiczbaPrzeciwnikow--;
        Destroy(gameObject);
    }


    /// <summary>
    /// Metoda wyznaczająca wywołująca metodę PobierzNastepnyPunkt która podaje położenie następnego punktu do którego powinien
    /// udać sie przeciwnik gdy dotrze do obecnego punktu kontrolnego.
    /// </summary>
    void Update()
    {
        Vector3 dir = przeciwnik.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, przeciwnik.position) <= 0.4f)
        {
            PobierzNastepnyPunkt();
        }
    }

    /// <summary>
    /// Metoda pobierająca położenie następnego punktu kontrolnego dla przeciwników oraz wywołujaca metodę Meta która określa zachowanie przeciwnika 
    /// po tym jak dotrze do punktu w grze zwanego META.
    /// </summary>
    void PobierzNastepnyPunkt() {
        if(punktykontrolneNumer >= PunktyKon.punkt.Length -1)
        {
            Meta();
            return;
        }

        punktykontrolneNumer++;
        przeciwnik = PunktyKon.punkt[punktykontrolneNumer];
    }

    /// <summary>
    /// Metoda powodująca zniszczenie obiektu przeciwnik w grze gry ten dotrze do punktu META oraz odejmujaca jedno życie za każdego przeciwnika która tam dotarł.
    /// </summary>
    void Meta() {
        Destroy(gameObject);
        SpawnerPrzeciw.LiczbaPrzeciwnikow--;
        StatystkiGracza.Zycia--;
    }
}
