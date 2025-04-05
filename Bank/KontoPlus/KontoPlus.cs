using Bank;

namespace KontoPlus
{
    public class KontoPlus : Konto
    {
        private decimal jednorazowyLimitDebetowy;
        private bool debetWykorzystany = false;

        public KontoPlus(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0)
            : base(klient, bilansNaStart)
        {
            jednorazowyLimitDebetowy = limitDebetowy;
        }

        public decimal JednorazowyLimitDebetowy
        {
            get => jednorazowyLimitDebetowy;
            set => jednorazowyLimitDebetowy = value;
        }

        public new decimal Bilans => base.Bilans + (debetWykorzystany ? 0 : jednorazowyLimitDebetowy);

        public new void Wyplata(decimal kwota)
        {
            if (Zablokowane)
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

            bilans -= kwota;

            if (bilans < 0)
            {
                debetWykorzystany = true;
                BlokujKonto();
            }
        }

        public new void Wplata(decimal kwota)
        {
            base.Wplata(kwota);

            if (Bilans > 0 && Zablokowane)
            {
                OdblokujKonto();
                debetWykorzystany = false;
            }
        }
    }
}