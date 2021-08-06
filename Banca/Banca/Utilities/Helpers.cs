using System;
using Banca.Entities;

namespace Banca.Utilities
{
    public class Helpers
    {
        public static int CheckInt()
        {
            bool isInt = false;
            int numero = 0;

            do
            {
                isInt = int.TryParse(Console.ReadLine(), out numero);

                if (!isInt)
                {
                    Console.WriteLine("Errore: non hai inserito un numero intero. Riprova:");
                }
            } while (!isInt);

            return numero;
        }

        public static decimal CheckDecimal()
        {
            bool isDecimal = false;
            decimal numero = 0;

            do
            {
                isDecimal = decimal.TryParse(Console.ReadLine(), out numero);

                if (!isDecimal)
                {
                    Console.WriteLine("Errore: non hai inserito un numero. Riprova:");
                }
                else if(numero < 0)
                {
                    Console.WriteLine("Errore: non puoi inserire un importo negativo. Riprova:");
                }
            } while (!isDecimal || numero < 0);

            return numero;
        }

        public static void ContinuaEsecuzione()
        {
            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
        }

        public static Conto ScegliConto()
        {
            Conto contoCercato = null;
            int numeroContoCercato = 0;
            int contatore = 0;

            Console.WriteLine("Inserisci il numero del conto:");
            numeroContoCercato = CheckInt();

            foreach(Conto c in DataService.Conti)
            {
                if(c.Numero == numeroContoCercato)
                {
                    contoCercato = c;
                    return contoCercato;
                }
                contatore++;
            }

            if(contatore == DataService.Conti.Count)
            {
                Console.WriteLine("Errore: numero del conto inesistente");
            }

            return contoCercato;
        }

        public static string StampaData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }

        public static void StampaConti()
        {
            if(DataService.Conti.Count != 0)
            {
                Console.WriteLine("{0,-15}{1,-20}{2,-8}{3,25}", "Numero Conto", "Banca", "Saldo", "Data Ultima Operazione");
                Console.WriteLine(new string('-', 100));
                foreach (Conto c in DataService.Conti)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Non ci sono conti presenti");
            }
        }

        public static string StampaOperazione(bool isPrelievo)
        {
            string operazione = "";
            if (isPrelievo)
            {
                operazione = "Prelievo";
            }
            else
            {
                operazione = "Versamento";
            }
            return operazione;
        }

        public static bool CercaNumeroConto(int numeroConto)
        {
            foreach(Conto c in DataService.Conti)
            {
                if(c.Numero == numeroConto)
                    return true;
            }

            return false;
        }

        public static bool CercaBanca(string nomeBanca)
        {
            foreach (Conto c in DataService.Conti)
            {
                if (c.Banca == nomeBanca)
                    return true;
            }
            return false;
        }
    }
}
