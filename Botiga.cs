using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoanAlex.BotigaCistella
{
    /// <summary>
    /// Classe que representa una botiga amb productes.
    /// </summary>
    internal class Botiga
    {
        // Atributs per emmagatzemar els productes i preus
        private string[] productesBotiga;
        private double[] preus;
        private int nElemBotiga;
        private const int MAX_PRODUCTES = 100;

        /// <summary>
        /// Constructor de la classe Botiga.
        /// Inicialitza les variables necessàries.
        /// </summary>
        public Botiga()
        {
            productesBotiga = new string[MAX_PRODUCTES];
            preus = new double[MAX_PRODUCTES];
            nElemBotiga = 0;
        }

        /// <summary>
        /// Mètode per afegir un producte a la botiga.
        /// </summary>
        /// <param name="producte">El nom del producte a afegir.</param>
        /// <param name="preu">El preu del producte a afegir.</param>
        public void AfegirProducte(string producte, double preu)
        {
            // Comprova si la botiga està plena
            if (nElemBotiga < MAX_PRODUCTES)
            {
                productesBotiga[nElemBotiga] = producte;
                preus[nElemBotiga] = preu;
                nElemBotiga++;
                Console.WriteLine("Producte afegit a la botiga.");
            }
            else
            {
                // Si la botiga està plena, demana si es vol ampliar
                Console.WriteLine("La botiga està completa. Vols ampliar-la?");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "si")
                {
                    Console.WriteLine("Quants productes vols afegir?");
                    int numProductes = int.Parse(Console.ReadLine());
                    AmpliarTenda(numProductes);
                }
            }
        }

        /// <summary>
        /// Mètode per afegir múltiples productes a la botiga.
        /// </summary>
        /// <param name="productes">Array de noms de productes a afegir.</param>
        /// <param name="preus">Array de preus corresponents als productes.</param>
        public void AfegirProducte(string[] productes, double[] preus)
        {
            // Comprova si els arrays tenen la mateixa longitud
            if (productes.Length == preus.Length)
            {
                // Afegir cada producte individualment
                for (int i = 0; i < productes.Length; i++)
                {
                    AfegirProducte(productes[i], preus[i]);
                }
            }
            else
            {
                Console.WriteLine("Error: les taules de productes i preus han de tenir la mateixa longitud.");
            }
        }


        /// <summary>
        /// Mètode per ampliar la botiga.
        /// </summary>
        /// <param name="num">Nombre de productes a afegir per ampliar la botiga.</param>
        public void AmpliarTenda(int num)
        {
            // S'utilitza el mètode Resize per a crear nous peoductes en la botiga
            Array.Resize(ref productesBotiga, productesBotiga.Length + num);
            Array.Resize(ref preus, preus.Length + num);
            Console.WriteLine("Botiga ampliada en " + num + " productes.");
        }

        /// <summary>
        /// Mètode per modificar el preu d'un producte.
        /// </summary>
        /// <param name="producte">El nom del producte a modificar el preu.</param>
        /// <param name="preu">El nou preu del producte.</param>
        public void ModificarPreu(string producte, double preu)
        {
            int index = Array.IndexOf(productesBotiga, producte);
            if (index != -1) // busca el producte i modifica el preu si es troba
            {
                preus[index] = preu;
                Console.WriteLine("Preu del producte '" + producte + "' modificat amb èxit.");
            }
            else 
            {
                Console.WriteLine("El producte '" + producte + "' no s'ha trobat.");
            }
        }

        /// <summary>
        /// Mètode per modificar el nom d'un producte.
        /// </summary>
        /// <param name="producteAntic">El nom del producte a modificar.</param>
        /// <param name="producteNou">El nou nom del producte.</param>
        public void ModificarProducte(string producteAntic, string producteNou)
        {
            int index = Array.IndexOf(productesBotiga, producteAntic);
            if (index != -1) //Busca el nom del producte, si el troba el canvia
            {
                productesBotiga[index] = producteNou;
                Console.WriteLine("Nom del producte modificat amb èxit.");
            }
            else
            {
                Console.WriteLine("El producte '" + producteAntic + "' no s'ha trobat.");
            }
        }

        /// <summary>
        /// Mètode per ordenar els productes alfabèticament.
        /// </summary>
        public void OrdenarProducte()
        {
            for (int i = 0; i < nElemBotiga - 1; i++) //Doble bucle on el gran recòrrer els elements, i el petit els compara
            {
                for (int j = 0; j < nElemBotiga - 1 - i; j++)
                {
                    if (String.Compare(productesBotiga[j], productesBotiga[j + 1], StringComparison.Ordinal) > 0) //Compara els dos elements, i els ordena per ordre alfabètic
                    {
                        string tempProducte = productesBotiga[j];
                        productesBotiga[j] = productesBotiga[j + 1];
                        productesBotiga[j + 1] = tempProducte;

                        double tempPreu = preus[j];
                        preus[j] = preus[j + 1];
                        preus[j + 1] = tempPreu;
                    }
                }
            }
            Console.WriteLine("Productes ordenats alfabèticament.");
        }

        /// <summary>
        /// Mètode per ordenar els productes per preu.
        /// </summary>
        public void OrdenarPreus()
        {
            for (int i = 0; i < nElemBotiga - 1; i++) // 
            {
                for (int j = 0; j < nElemBotiga - 1 - i; j++)
                {
                    if (preus[j] > preus[j + 1])
                    {
                        string tempProducte = productesBotiga[j];
                        productesBotiga[j] = productesBotiga[j + 1];
                        productesBotiga[j + 1] = tempProducte;

                        double tempPreu = preus[j];
                        preus[j] = preus[j + 1];
                        preus[j + 1] = tempPreu;
                    }
                }
            }
            Console.WriteLine("Productes ordenats per preu de forma creixent.");
        }

        /// <summary>
        /// Mètode per mostrar els productes de la botiga.
        /// </summary>
        public void Mostrar()
        {
            Console.WriteLine("Productes a la botiga:");
            for (int i = 0; i < nElemBotiga; i++)
            {
                Console.WriteLine(productesBotiga[i] + " - " + preus[i]);
            }
        }

        /// <summary>
        /// Sobrecàrrega del mètode ToString per mostrar els productes.
        /// </summary>
        /// <returns>Una cadena que representa els productes de la botiga.</returns>
        public override string ToString()
        {
            string result = "Productes a la botiga:\n";
            for (int i = 0; i < nElemBotiga; i++)
            {
                result += productesBotiga[i] + " - " + preus[i] + "\n";
            }
            result += "Nombre de productes: " + nElemBotiga + "\n";
            result += "Espai disponible: " + (MAX_PRODUCTES - nElemBotiga) + " productes";
            return result;
        }
    }
}