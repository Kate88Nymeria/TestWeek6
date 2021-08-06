using System;
namespace Banca.Entities
{
    public class TransfertMovement : Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{'-',-20}{BancaDestinazione,-20}{'-',15}{'-',12}";
        }
    }
}
