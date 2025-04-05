using Bank;
using KontoPlus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public sealed class KontoPlusTest
    {
        [TestMethod]
        public void TestKontoPlusWplata()
        {
            var konto = new KontoPlus.KontoPlus("John John", 100, 50);
            konto.Wplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void TestKontoPlusWyplata()
        {
            var konto = new KontoPlus.KontoPlus("John John", 100, 50);
            konto.Wyplata(120);
            Assert.AreEqual(-20, konto.Bilans);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void TestKontoPlusOdblokowaniePoWplacie()
        {
            var konto = new KontoPlus.KontoPlus("John John", 100, 50);
            konto.Wyplata(120);
            Assert.IsTrue(konto.Zablokowane);
            konto.Wplata(30);
            Assert.IsFalse(konto.Zablokowane);
            Assert.AreEqual(10, konto.Bilans);
        }
    }
}