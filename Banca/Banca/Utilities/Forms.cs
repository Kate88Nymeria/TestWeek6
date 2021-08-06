using System;
using Banca.Entities;

namespace Banca.Utilities
{
    public class Forms
    {
        public static void CreaConto()
        {
            Conto nuovoConto = new();

            Console.WriteLine("====== CREA NUOVO CONTO ======");
            Console.WriteLine();

            //do
            //{
                Console.WriteLine("Inserisci numero conto");
                nuovoConto.Numero = Helpers.CheckInt();

                Console.WriteLine();
                Console.WriteLine("Inserisci nome banca");
                nuovoConto.Banca = Console.ReadLine();

                //if (Helpers.CercaNumeroConto(nuovoConto.Numero) && Helpers.CercaBanca(nuovoConto.Banca))
                //{
                //    Console.WriteLine("Errore: numero di conto già presente in questa banca.");
                //}
            //} while (Helpers.CercaNumeroConto(nuovoConto.Numero) && Helpers.CercaBanca(nuovoConto.Banca));
            
                
            Console.WriteLine("Inserisci saldo");
            nuovoConto.Saldo = Helpers.CheckDecimal();
            nuovoConto.DataUltimaOperazione = DateTime.Now;

            DataService.Conti.Add(nuovoConto);
            Console.WriteLine("Conto Aggiunto Correttamente");
        }

        public static void StampaConto()
        {
            Conto contoDaStampare = null;

            do
            {
                Helpers.StampaConti();

                contoDaStampare = Helpers.ScegliConto();
                if ( contoDaStampare == null)
                {
                    Console.WriteLine("Impossibile eseguire la stampa.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("{0,-15}{1,-20}{2,-8}{3,25}", "Numero Conto", "Banca", "Saldo", "Data Ultima Operazione");
                    Console.WriteLine(new string('-', 125));
                    Console.WriteLine(contoDaStampare);
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 125));
                    Console.WriteLine("{0,-25}{1,-18}{2,-12}{3, -20}{4, -20}{5,15}{6, 12}", "Data Movimento", "Tipo Operazione", "Importo", "Esecutore",
                        "Banca Destinataria", "Numero Carta", "Tipo Carta");
                    Console.WriteLine(new string('-', 125));

                    if(contoDaStampare.Movimenti.Count == 0)
                    {
                        Console.WriteLine("Nessun Movimento da Mostrare");
                    }
                    else
                    {
                        foreach (Movimento m in contoDaStampare.Movimenti)
                        {
                            Console.WriteLine(m);
                        }
                    }

                    Console.WriteLine();
                    contoDaStampare.DataUltimaOperazione = DateTime.Now;
                    return;
                }

            } while (Helpers.ScegliConto() == null);
        }

        public static void CreaMovimento()
        {
            Conto contoDaUsare = null;

            do
            {
                Helpers.StampaConti();

                contoDaUsare = Helpers.ScegliConto();
                if (contoDaUsare == null)
                {
                    Console.WriteLine("Impossibile aggiungere movimento.");
                }
                else
                {
                    Movimento nuovoMovimento = null;
                    int sceltaTipo = 0;
                    int sceltaOperazione = 0;

                    Console.Clear();
                    Console.WriteLine("====== NUOVO MOVIMENTO ======");
                    Console.WriteLine("{0,-15}{1,-20}{2,-8}{3,25}", "Numero Conto", "Banca", "Saldo", "Data Ultima Operazione");
                    Console.WriteLine(new string('-', 100));
                    Console.WriteLine(contoDaUsare);

                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Scegli il movimento da eseguire");
                        Console.WriteLine("1 - Cash Movement");
                        Console.WriteLine("2 - Transfert Movement");
                        Console.WriteLine("3 - Credit Card Movement");

                        sceltaTipo = Helpers.CheckInt();
                        switch (sceltaTipo)
                        {
                            case 1:
                                nuovoMovimento = new CashMovement();
                                break;
                            case 2:
                                nuovoMovimento = new TransfertMovement();
                                break;
                            case 3:
                                nuovoMovimento = new CreditCardMovement();
                                break;
                            default:
                                Console.WriteLine("Errore: scelta non ammessa. Riprova:");
                                break;
                        }
                    } while (sceltaTipo != 1 && sceltaTipo != 2 && sceltaTipo != 3);

                    Console.WriteLine();
                    Console.WriteLine("1 - Prelievo");
                    Console.WriteLine("2 - Versamento");
                    do
                    {
                        sceltaOperazione = Helpers.CheckInt();

                        switch (sceltaOperazione)
                        {
                            case 1:
                                nuovoMovimento.IsPrelievo = true;
                                break;
                            case 2:
                                nuovoMovimento.IsPrelievo = false;
                                break;
                            default:
                                Console.WriteLine("Errore: scelta non ammessa. Riprova:");
                                break;
                        }
                    } while (sceltaOperazione != 1 && sceltaOperazione != 2);

                    Console.WriteLine();
                    Console.WriteLine("Inserisci importo:");
                    nuovoMovimento.Importo = Helpers.CheckDecimal();

                    try
                    {
                        nuovoMovimento.EseguiOperazione(contoDaUsare);
                    }
                    catch(RedCountException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }

                    Console.WriteLine();
                    if(nuovoMovimento is CashMovement)
                    {
                        Console.WriteLine("Inserisci nome esecutore:");
                        ((CashMovement)nuovoMovimento).Esecutore = Console.ReadLine();
                    }
                    else if(nuovoMovimento is TransfertMovement)
                    {
                        ((TransfertMovement)nuovoMovimento).BancaOrigine = contoDaUsare.Banca;
                        Console.WriteLine("Inserisci la banca di destinazione");
                        ((TransfertMovement)nuovoMovimento).BancaDestinazione = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Inserisci il numero della carta");
                        ((CreditCardMovement)nuovoMovimento).NumeroCarta = Helpers.CheckInt();
                        Console.WriteLine();
                        int sceltaCarta = 0;
                        do
                        {
                            Console.WriteLine("Scegli il tipo di carta");
                            Console.WriteLine($"{(int)CreditCardMovement.TipologiaCarta.AMEX} - {CreditCardMovement.TipologiaCarta.AMEX}");
                            Console.WriteLine($"{(int)CreditCardMovement.TipologiaCarta.VISA} - {CreditCardMovement.TipologiaCarta.VISA}");
                            Console.WriteLine($"{(int)CreditCardMovement.TipologiaCarta.MASTERCARD} - {CreditCardMovement.TipologiaCarta.MASTERCARD}");
                            Console.WriteLine($"{(int)CreditCardMovement.TipologiaCarta.OTHER} - {CreditCardMovement.TipologiaCarta.OTHER}");

                            sceltaCarta = Helpers.CheckInt();

                            switch (sceltaCarta)
                            {
                                case 0:
                                    ((CreditCardMovement)nuovoMovimento).Tipo = CreditCardMovement.TipologiaCarta.AMEX;
                                    break;
                                case 1:
                                    ((CreditCardMovement)nuovoMovimento).Tipo = CreditCardMovement.TipologiaCarta.VISA;
                                    break;
                                case 2:
                                    ((CreditCardMovement)nuovoMovimento).Tipo = CreditCardMovement.TipologiaCarta.MASTERCARD;
                                    break;
                                case 3:
                                    ((CreditCardMovement)nuovoMovimento).Tipo = CreditCardMovement.TipologiaCarta.OTHER;
                                    break;
                                default:
                                    Console.WriteLine("Errore: Scelta non ammessa. Riprova:");
                                    Console.WriteLine();
                                    break;
                            }
                        } while (sceltaCarta < 0 || sceltaCarta > 3);
                    }

                    nuovoMovimento.DataMovimento = DateTime.Now;
                    Console.WriteLine();

                    contoDaUsare.DataUltimaOperazione = nuovoMovimento.DataMovimento;
                    contoDaUsare.Movimenti.Add(nuovoMovimento);

                    Console.WriteLine("Movimento eseguito correttamente");
                    return;
                }

            } while (Helpers.ScegliConto() == null);
        }
    }
}
