using System;
using Banca.Utilities;

namespace Banca
{
    public class Menu
    {
        public static void Start()
        {
            bool continua = true;

            do
            {
                Console.WriteLine("Quale operazione vuoi eseguire?");
                Console.WriteLine("1 - Crea Nuovo Conto");
                Console.WriteLine("2 - Nuovo Movimento");
                Console.WriteLine("3 - Stampa Estratto Conto");
                Console.WriteLine("0 - Esci dal Programma");

                int scelta = Helpers.CheckInt();
                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        Forms.CreaConto();
                        Helpers.ContinuaEsecuzione();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Forms.CreaMovimento();
                        Helpers.ContinuaEsecuzione();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Forms.StampaConto();
                        Helpers.ContinuaEsecuzione();
                        Console.Clear();
                        break;
                    case 0:
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Errore: scelta non valida.");
                        Helpers.ContinuaEsecuzione();
                        Console.Clear();
                        break;
                }
            } while (continua);
        }
    }
}
