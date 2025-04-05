using Bank;
namespace BankTest
{
    [TestClass]
    public sealed class KontoPlusTest
    {
        [TestMethod]
        public void TestWplata()
        {
            var konto = new Konto("John John", 100);
            konto.Wplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void TestWyplata()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(50);
            Assert.AreEqual(50, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi byc dodatnia")]
        public void TestWplataNegativeAmount()
        {
            var konto = new Konto("John John", 100);
            konto.Wplata(-50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi byc dodatnia")]
        public void TestWyplataNegativeAmount()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(-50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWplataOnBlockedAccount()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.Wplata(50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWyplataOnBlockedAccount()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.Wyplata(50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Niewystarczajace srodki na koncie")]
        public void TestWyplataInsufficientFunds()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(150);
        }

        [TestMethod]
        public void TestBlokujKonto()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void TestOdblokujKonto()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.OdblokujKonto();
            Assert.IsFalse(konto.Zablokowane);
        }

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