using NUnit.Framework;
using UnityEngine;

public class BudowanieWiezTest
{
    [Test]
    public void PobieranieWiezyDobudowyTest()
    {
        var wiezaZwykla = GameObject.FindGameObjectWithTag("WiezaStandardowa");
        var ob1 = new BudowanieWiez();
        Assert.AreEqual(ob1.PrzekazWiezeDoBudowy(), wiezaZwykla);
     
    }
}
