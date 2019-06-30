using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class SchowekWiezyDoSklepuTest
{
    [Test]
    public void Testuj()
    {
        var wynik = 0;
        var ob1 = new SchowekWiezyDoSklepu();
        ob1.KasaZaSprzedaz();
        Assert.AreEqual(ob1.KasaZaSprzedaz(), wynik);
        //Spodzeiwany wynik zero, ponieważ nie podaliśmy którą wieże chcemy sprzedać.
        
    }
       
}
