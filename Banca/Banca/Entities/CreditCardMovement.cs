using System;
namespace Banca.Entities
{
    public class CreditCardMovement : Movimento
    {
        public int NumeroCarta { get; set; }
        public TipologiaCarta Tipo { get; set; }


        public enum TipologiaCarta
        {
            AMEX,
            VISA,
            MASTERCARD,
            OTHER
        }

        public override string ToString()
        {
            return base.ToString() + $"{'-', -20}{'-', -20}{NumeroCarta,15}{Tipo, 12}";
        }
    }
}
