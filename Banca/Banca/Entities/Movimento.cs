using System;
using Banca.Utilities;

namespace Banca.Entities
{
    public abstract class Movimento
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public bool IsPrelievo { get; set; }


        public void EseguiOperazione(Conto conto)
        {
            if (IsPrelievo)
            {
                if(conto.Saldo < Importo)
                {
                    throw new RedCountException("Errore: non è possibile prelevare un importo maggiore del saldo disponibile")
                    {
                        Saldo = conto.Saldo,
                        ImportoOperazione = Importo
                    };
                }
                else
                {
                    conto.Saldo -= Importo;
                }
            }
            else
                conto.Saldo += Importo;
        }

        public override string ToString()
        {
            string stampaMovimento = $"{DataMovimento, -25}{Helpers.StampaOperazione(IsPrelievo),-18}{Importo,-12}";
            return stampaMovimento;
        }
    }
}
