using static System.Net.Mime.MediaTypeNames;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal jednorazowyLimitDebetowy;
        private bool debetWykorzystany = false;

        public KontoLimit(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0)
        {
            konto = new Konto(klient, bilansNaStart);
            jednorazowyLimitDebetowy = limitDebetowy;
        }

        public string Nazwa => konto.Nazwa;
        public decimal Bilans => konto.Bilans + (debetWykorzystany ? 0 : jednorazowyLimitDebetowy);
        public bool Zablokowane => konto.Zablokowane;

        public decimal JednorazowyLimitDebetowy
        {
            get => jednorazowyLimitDebetowy;
            set => jednorazowyLimitDebetowy = value;
        }

        public void Wplata(decimal kwota)
        {
            konto.Wplata(kwota);

            if (konto.Bilans > 0 && konto.Zablokowane)
            {
                konto.OdblokujKonto();
                debetWykorzystany = false;
            }
        }

        public void Wyplata(decimal kwota)
        {
            if (konto.Zablokowane)
            {
                throw new Exception("Konto zablokowane");
            }
            if (kwota <= 0)
            {
                throw new Exception("Kwota musi być dodatnia");
            }
            if (kwota > Bilans)
            {
                throw new Exception("Kwota przekracza dostępne środki i limit debetowy");
            }

            konto.Wyplata(kwota);

            if (konto.Bilans < 0)
            {
                debetWykorzystany = true;
                konto.BlokujKonto();
            }
        }
    }
}