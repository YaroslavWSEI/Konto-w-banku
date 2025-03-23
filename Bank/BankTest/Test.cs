using Bank;
namespace BankTest
{
    [TestClass]
    public sealed class Test
    {
        [TestMethod]

        //test wpłaty
        public void TestWplata()
        {
            var konto = new Konto("John John", 100);
            konto.Wplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }
        [TestMethod]
        //test wyplaty
        public void TestWyplata()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(50);
            Assert.AreEqual(50, konto.Bilans);
        }
        //test wpłaty z ujemną kwotą
        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi być dodatnia")]
        public void TestWplataNegativeAmount()
        {
            var konto = new Konto("John John", 100);
            konto.Wplata(-50);
        }
        //test wyplaty z ujemną kwotą
        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi być dodatnia")]
        public void TestWyplataNegativeAmount()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(-50);
        }
        //test wpłaty na zablowanym koncie
        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWplataOnBlockedAccount()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.Wplata(50);
        }
        //test wyplaty na zablowanym koncie
        [TestMethod]
        [ExpectedException(typeof(Exception), "Konto zablokowane")]
        public void TestWyplataOnBlockedAccount()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.Wyplata(50);
        }
        //test wyplaty z brakiem srodkow
        [TestMethod]
        [ExpectedException(typeof(Exception), "Niewystarczające środki na koncie")]
        public void TestWyplataInsufficientFunds()
        {
            var konto = new Konto("John John", 100);
            konto.Wyplata(150);
        }
        //test blokowania konta
        [TestMethod]
        public void TestBlokujKonto()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            Assert.IsTrue(konto.Zablokowane);
        }
        //test odblokowania konta
        [TestMethod]
        public void TestOdblokujKonto()
        {
            var konto = new Konto("John John", 100);
            konto.BlokujKonto();
            konto.OdblokujKonto();
            Assert.IsFalse(konto.Zablokowane);
        }
    }
}