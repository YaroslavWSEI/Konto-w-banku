using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public sealed class KontoLimitTest
    {
        [TestMethod]
        public void TestWplata()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void TestWyplata()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(50);
            Assert.AreEqual(50, konto.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi być dodatnia")]
        public void TestWplataNegativeAmount()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wplata(-50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi być dodatnia")]
        public void TestWyplataNegativeAmount()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(-50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWplataOnBlockedAccount()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(150); // Uzywamy debet i blokujemy konto
            konto.Wplata(50); // Proba wplaty na zablokowane konto
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWyplataOnBlockedAccount()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(150); // Uzywamy debet i blokujemy konto
            konto.Wyplata(50); // Proba wyplaty z zablokowanego konta
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota przekracza dostępne środki i limit debetowy")]
        public void TestWyplataInsufficientFunds()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(200); // Przekraczamy dostepne srodki i limit debetowy
        }

        [TestMethod]
        public void TestKontoLimitOdblokowaniePoWplacie()
        {
            var konto = new KontoLimit("John John", 100, 50);
            konto.Wyplata(150); // Uzywamy debet i blokujemy konto
            Assert.IsTrue(konto.Zablokowane);
            konto.Wplata(60); // Wplata srodkow, aby odblokowac konto
            Assert.IsFalse(konto.Zablokowane);
            Assert.AreEqual(10, konto.Bilans);
        }
    }
}