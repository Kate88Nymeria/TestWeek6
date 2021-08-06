using System;
using System.Collections.Generic;
using Banca.Utilities;

namespace Banca.Entities
{
    public class Conto
    {
        public int Numero { get; set; }
        public string Banca { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }

        public List<Movimento> Movimenti = new List<Movimento>();

        public override string ToString()
        {
            string stampaConto = $"{Numero,-15}{Banca,-20}{Saldo,-8}{DataUltimaOperazione,25}";
            return stampaConto;
        }
    }
}
