using UnityEngine.TestTools;
using NUnit.Framework;

public class LosowanieWrogowTest
{
   [Test]
   public void LosowanieWrogow()
    {
        var liczba0= 0;
        var liczba1 =1;
        var liczba2 = 2;
        var ob1 = new SpawnerPrzeciw();
        Assert.AreEqual(ob1.WylosujWroga(), (liczba0 | liczba1 | liczba2));
    }
}
