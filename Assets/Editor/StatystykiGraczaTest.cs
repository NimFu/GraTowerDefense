using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

    public class StatystykiGraczaTest
    {
        [Test]
        public void Testy()
        {
            var KasaNaStart = 800;
            var ZyciaNaPoczatek = 3;
            int Kasa;
            int Zycia;
            int LiczbaRund;
            Kasa = KasaNaStart;
            Zycia = ZyciaNaPoczatek;
            LiczbaRund = 0;
            Assert.AreEqual(Kasa, KasaNaStart);
            Assert.AreEqual(Zycia, ZyciaNaPoczatek);
            Is.Equals(LiczbaRund, 0);
        }
    }


