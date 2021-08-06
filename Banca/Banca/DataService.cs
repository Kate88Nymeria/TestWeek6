using System;
using System.Collections.Generic;
using Banca.Entities;

namespace Banca
{
    public class DataService
    {
        public static List<Conto> Conti = new()
        {
            new Conto { Numero = 5465464, Banca = "Intesa San Paolo", Saldo = 3500M, DataUltimaOperazione = DateTime.Parse("2021/05/04"),
                Movimenti = new()
                {
                    new CreditCardMovement
                    {
                    DataMovimento = DateTime.Parse("2021/01/30"),
                    Importo = 250M,
                    IsPrelievo = false,
                    NumeroCarta = 5478537,
                    Tipo = CreditCardMovement.TipologiaCarta.MASTERCARD
                    },
                    new CreditCardMovement
                    {
                      DataMovimento = DateTime.Parse("2021/03/01"),
                      Importo = 150M,
                      IsPrelievo = true,
                      NumeroCarta = 5478537,
                      Tipo = CreditCardMovement.TipologiaCarta.MASTERCARD
                    },
                    new CashMovement
                    {
                      DataMovimento = DateTime.Parse("2021/05/10"),
                      Importo = 250M,
                      IsPrelievo = false,
                      Esecutore = "Paolo Bianchi"
                    },
                    new CashMovement
                    {
                      DataMovimento = DateTime.Parse("2021/06/30"),
                      Importo = 80M,
                      IsPrelievo = true,
                      Esecutore = "Mario Rossi"
                    },
                    new TransfertMovement
                    {
                      DataMovimento = DateTime.Parse("2021/01/30"),
                      Importo = 250M,
                      IsPrelievo = false,
                      BancaOrigine = "Intesa San Paolo",
                      BancaDestinazione = "Unicredit Banca"
                    }
                }
            },
            new Conto { Numero = 3836594, Banca = "Unicredit Banca", Saldo = 1300M, DataUltimaOperazione = DateTime.Parse("2021/04/14"),
                Movimenti = new()
                {
                    new CreditCardMovement
                    {
                        DataMovimento = DateTime.Parse("2021/01/30"),
                        Importo = 250M,
                        IsPrelievo = false,
                        NumeroCarta = 5478537,
                        Tipo = CreditCardMovement.TipologiaCarta.MASTERCARD
                    },
                    new CreditCardMovement
                    {
                        DataMovimento = DateTime.Parse("2021/03/01"),
                        Importo = 150M,
                        IsPrelievo = true,
                        NumeroCarta = 5478537,
                        Tipo = CreditCardMovement.TipologiaCarta.MASTERCARD
                    },
                    new CashMovement
                    {
                        DataMovimento = DateTime.Parse("2021/05/10"),
                        Importo = 250M,
                        IsPrelievo = false,
                        Esecutore = "Paolo Bianchi"
                    },
                    new CashMovement
                    {
                        DataMovimento = DateTime.Parse("2021/06/30"),
                        Importo = 80M,
                        IsPrelievo = true,
                        Esecutore = "Mario Rossi"
                    },
                    new TransfertMovement
                    {
                        DataMovimento = DateTime.Parse("2021/01/30"),
                        Importo = 250M,
                        IsPrelievo = false,
                        BancaOrigine = "Intesa San Paolo",
                        BancaDestinazione = "Unicredit Banca"
                    }
                }
            },
            new Conto { Numero = 1646478, Banca = "BNL", Saldo = 5900M, DataUltimaOperazione = DateTime.Parse("2021/07/02") },
        };
    }
}
