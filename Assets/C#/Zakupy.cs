using UnityEngine;
/// <summary>
/// Kalsa służąca do pobierania i przekazywania dalej wybranej przez użytkownika wiezy do budiwy.
/// </summary>
public class Zakupy : MonoBehaviour
{
    BudowanieWiez budowanie;
    public SchowekWiezyDoSklepu zwyklaWieza;
    public SchowekWiezyDoSklepu WiezaRakietowa;

    /// <summary>
    /// Pobiera oraz przekazuje wartości wieży do zbudowania wybranej przez użytkownika.
    /// </summary>
    private void Start()
    {
        budowanie = BudowanieWiez.zarzadca;
    }

    /// <summary>
    /// Metoda ustawia jako wieże do budowy zwykła wieże.
    /// </summary>
    public void WyborWiezy()
    {
        budowanie.WybierzWiezeDoBudowy(zwyklaWieza);
    }
    /// <summary>
    /// Metoda ustawia jako wieże do budowy wieże rakietową.
    /// </summary>
    public void WyborRakietowej()
    {
        budowanie.WybierzWiezeDoBudowy(WiezaRakietowa);
    }
}
