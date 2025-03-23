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
            var konto = new Konto("Yaroslav Furmanov", 100);
            konto.Wplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }
        [TestMethod]
        //test wyplaty
        public void TestWyplata()
        {
            var konto = new Konto("Yaroslav Furmanov", 100);
            konto.Wyplata(50);
            Assert.AreEqual(50, konto.Bilans);
        }
        //test wpłaty z ujemną kwotą
        [TestMethod]
        [ExpectedException(typeof(Exception), "Kwota musi być dodatnia")]
        public void TestWplataNegativeAmount()
        {
            var konto = new Konto("Yaroslav Furmanov", 100);
            konto.Wplata(-50);
        }
       
    }
}