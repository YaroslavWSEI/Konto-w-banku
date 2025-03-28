﻿namespace Bank
{
    public class Konto
    {
        private string klient;
        private decimal bilans; 
        private bool zablokowane = false;
        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            this.bilans = bilansNaStart;
        }
        public string Nazwa => klient;
        public decimal Bilans => bilans;
        public bool Zablokowane => zablokowane;
        public void Wplata(decimal kwota)
        {
            if (zablokowane)
            {
                throw new Exception("Konto zablokowane");
            }
            if (kwota <= 0)
            {
                throw new Exception("Kwota musi być dodatnia");
            }
            bilans += kwota;
        }
        public void Wyplata(decimal kwota)
        {
            if (zablokowane)
            {
                throw new Exception("Konto zablokowane");
            }
            if (kwota <= 0)
            {
                throw new Exception("Kwota musi być dodatnia");
            }
            if (bilans < kwota)
            {
                throw new Exception("Brak środków na koncie");
            }
            bilans -= kwota;
        }
        public void BlokujKonto()
        {
            zablokowane = true;
        }
        public void OdblokujKonto()
        {
            zablokowane = false;
        }


    }
}