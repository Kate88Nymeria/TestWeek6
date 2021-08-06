using System;
namespace Banca.Entities
{
    public class CashMovement : Movimento
    {
        public string Esecutore { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{Esecutore,-20}{'-',-20}{'-',15}{'-',12}";
        }
    }
}
