using System;
using System.Collections.Generic;
using System;

using System;

/// <summary>
/// Programa principal que permet gestionar la botiga,com a treballador o client.
/// </summary>
class Program
{
    /// <summary>
    /// Inici del progama.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Ets un treballador o un client? (T/C)");
        string resposta = Console.ReadLine().ToUpper();

        if (resposta == "T")
        {
            // Accions específiques per a treballadors
            Botiga botiga = new Botiga();
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Introdueix el nom del producte que vols afegir:");
                string nomProducte = Console.ReadLine();

                Console.WriteLine("Introdueix el preu del producte:");
                double preuProducte = Convert.ToDouble(Console.ReadLine());

                // Afegeix el producte a la botiga
                botiga.AfegirProducte(nomProducte, preuProducte);

                Console.WriteLine("Vols afegir més productes a la botiga? (S/N)");
                string respostaProducte = Console.ReadLine().ToUpper();
                if (respostaProducte != "S")
                {
                    continuar = false;
                }
            }
        }
        else if (resposta == "C")
        {
            // Accions específiques per a clients
            Cistella cistella = new Cistella();
            Console.WriteLine("Quants diners vols afegir a la cistella?");
            decimal diners = Convert.ToDecimal(Console.ReadLine());
            cistella.AfegirDiners(diners);

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Introdueix el nom del producte:");
                string nomProducte = Console.ReadLine();

                Console.WriteLine("Introdueix el preu del producte:");
                double preuProducte = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Introdueix la quantitat desitjada:");
                int quantitatProducte = Convert.ToInt32(Console.ReadLine());

                // Creem el producte i el comprem
                Producte producte = new Producte(nomProducte, preuProducte);
                cistella.ComprarProducte(producte, quantitatProducte);

                Console.WriteLine("Vols afegir més productes a la cistella? (S/N)");
                string respostaProducte = Console.ReadLine().ToUpper();
                if (respostaProducte != "S")
                {
                    continuar = false;
                }
            }

            // Mostrem els detalls de la compra
            cistella.Mostra();
        }
        else
        {
            Console.WriteLine("Resposta no reconeguda.");
        }
    }
}


public class Producte
    {
        // Atributs
        private string nom;
        private double preuSenseIVA;
        private double iva;
        private int quantitat;

        // Constructors

        /// <summary>
        /// Constructor buit que inicialitza el producte amb l'IVA per defecte al 21% i la quantitat a 0.
        /// </summary>
        public Producte()
        {
            nom = "";
            preuSenseIVA = 0;
            iva = 0.21; // IVA per defecte al 21%
            quantitat = 0;
        }

        /// <summary>
        /// Constructor que permet inicialitzar el nom i el preu sense IVA del producte, amb l'IVA per defecte al 21%.
        /// </summary>
        /// <param name="nom">El nom del producte.</param>
        /// <param name="preuSenseIVA">El preu del producte sense IVA.</param>
        public Producte(string nom, double preuSenseIVA)
        {
            this.nom = nom;
            this.preuSenseIVA = preuSenseIVA;
            this.iva = 0.21; // IVA per defecte al 21%
            this.quantitat = 0;
        }

        /// <summary>
        /// Constructor que permet inicialitzar tots els atributs del producte.
        /// </summary>
        /// <param name="nom">El nom del producte.</param>
        /// <param name="preuSenseIVA">El preu del producte sense IVA.</param>
        /// <param name="iva">El valor de l'IVA.</param>
        /// <param name="quantitat">La quantitat de productes en estoc.</param>
        public Producte(string nom, double preuSenseIVA, double iva, int quantitat)
        {
            this.nom = nom;
            this.preuSenseIVA = preuSenseIVA;
            this.iva = iva;
            this.quantitat = quantitat;
        }

        // Propietats

        /// <summary>
        /// Obté o assigna el nom del producte.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Obté o assigna el preu del producte sense IVA.
        /// </summary>
        public double PreuSenseIVA
        {
            get { return preuSenseIVA; }
            set { preuSenseIVA = value; }
        }

        /// <summary>
        /// Obté o assigna l'IVA del producte.
        /// </summary>
        public double IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        /// <summary>
        /// Obté o assigna la quantitat de productes en estoc.
        /// </summary>
        public int Quantitat
        {
            get { return quantitat; }
            set { quantitat = value; }
        }

        // Mètodes Públics

        /// <summary>
        /// Calcula i retorna el preu total del producte, tenint en compte l'IVA.
        /// </summary>
        /// <returns>El preu total del producte amb IVA inclòs.</returns>
        public double Preu()
        {
            return preuSenseIVA * (1 + iva);
        }

        /// <summary>
        /// Retorna una cadena que representa el producte amb el seu nom, preu i quantitat.
        /// </summary>
        /// <returns>Una cadena que representa el producte.</returns>
        public override string ToString()
        {
            return $"Nom: {nom}, Preu: {Preu()}, Quantitat: {quantitat}";
        }
    }
    /// <summary>
    /// Classe que representa una botiga amb productes.
    /// </summary>
    public class Botiga
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
        public void TreureProducte(string nomProducte)
        {
            // Busca el índice del producto en el array
            int index = Array.IndexOf(productesBotiga, nomProducte);

            // Si el producto se encuentra en el array
            if (index != -1)
            {
                // Desplaza los elementos subsiguientes una posición hacia atrás para eliminar el producto
                for (int i = index; i < nElemBotiga - 1; i++)
                {
                    productesBotiga[i] = productesBotiga[i + 1];
                    preus[i] = preus[i + 1];
                }

                // Decrementa el contador de elementos de la botiga
                nElemBotiga--;

                // Opcional: Puede limpiar el último elemento, ahora duplicado al final del array, aunque no es estrictamente necesario
                productesBotiga[nElemBotiga] = null;
                preus[nElemBotiga] = 0;

                Console.WriteLine($"Producte tret: {nomProducte}");
            }
            else
            {
                Console.WriteLine("Producte no trobat.");
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
public class Cistella
{
    // Referència a la botiga, pot ser null si la cistella no està vinculada directament amb una botiga específica.
    private Botiga botiga;

    // Data i hora de la creació de la cistella.
    private DateTime data;

    // Llista de productes continguts a la cistella.
    private List<Producte> productes;

    // Llista de quantitats per cada producte a la cistella, en la mateixa ordre que la llista de productes.
    private List<int> quantitats;

    // Nombre d'elements diferents (productes) a la cistella.
    private int nElements;

    // Quantitat total de diners disponibles per fer compres a la cistella.
    private decimal diners;

    // Constructor per defecte que inicialitza una cistella buida sense productes i amb 0 diners.
    public Cistella()
    {
        this.botiga = null;
        this.data = DateTime.Now;
        this.productes = new List<Producte>();
        this.quantitats = new List<int>();
        this.nElements = 0;
        this.diners = 0m;
    }

    // Constructor que permet crear una cistella amb una llista específica de productes, quantitats i una quantitat inicial de diners.
    // Llança una excepció si les llistes de productes i quantitats no tenen la mateixa mida.
    public Cistella(Botiga botiga, List<Producte> productes, List<int> quantitats, decimal diners)
    {
        if (productes.Count != quantitats.Count)
        {
            Console.WriteLine("Els productes i les quantitats han de tenir la mateixa longitud.");
        }

        this.botiga = botiga;
        this.data = DateTime.Now;
        this.productes = new List<Producte>(productes);
        this.quantitats = new List<int>(quantitats);
        this.nElements = productes.Count;
        this.diners = diners;
    }

    // Afegeix diners a la cistella, incrementant la quantitat total disponible per a futures compres.
    public void AfegirDiners(decimal quantitat)
    {
        this.diners += quantitat;
    }

    // Intenta comprar un producte i afegir-lo a la cistella. Si no hi ha prou diners, mostra un missatge i no realitza la compra.
    public void ComprarProducte(Producte producte, int quantitat)
    {
        decimal cost = (decimal)producte.Preu() * quantitat;
        if (cost > this.diners)
        {
            Console.WriteLine("No tens prou diners.");
            return;
        }

        this.productes.Add(producte);
        this.quantitats.Add(quantitat);
        this.nElements++;
        this.diners -= cost;
    }

    // Ordena els productes de la cistella alfabèticament pel seu nom utilitzant l'algoritme de la bombolla.
    public void OrdenarCistella()
    {
        bool intercanvi;
        do
        {
            intercanvi = false;
            for (int i = 0; i < nElements - 1; i++)
            {
                if (String.Compare(productes[i].Nom, productes[i + 1].Nom) > 0)
                {
                    var tempProd = productes[i];
                    var tempQuant = quantitats[i];

                    productes[i] = productes[i + 1];
                    quantitats[i] = quantitats[i + 1];

                    productes[i + 1] = tempProd;
                    quantitats[i + 1] = tempQuant;

                    intercanvi = true;
                }
            }
        } while (intercanvi);
    }

    // Mostra els detalls de cada producte a la cistella, incloent el preu unitari, la quantitat, el cost total per producte i el cost total de la cistella amb IVA.
    public void Mostra()
    {
        Console.WriteLine($"Data de compra: {this.data}");
        Console.WriteLine("Detall de la compra:");
        decimal total = 0;
        for (int i = 0; i < nElements; i++)
        {
            decimal cost = (decimal)(productes[i].Preu() * quantitats[i]);
            Console.WriteLine($"{productes[i].Nom} - Quantitat: {quantitats[i]}, Preu per unitat: {productes[i].Preu}, Cost: {cost}");
            total += cost;
        }
        decimal totalIVA = total * 1.21m; // IVA del 21%
        Console.WriteLine($"Total sense IVA: {total}");
        Console.WriteLine($"Total amb IVA: {totalIVA}");
    }

    // Calcula el cost total de la compra, incloent l'IVA, sense mostrar els detalls de cada producte.
    public decimal CostTotal()
    {
        decimal total = 0;
        for (int i = 0; i < nElements; i++)
        {
            total += (decimal)(productes[i].Preu() * quantitats[i]);
        }
        return total * 1.21m; // IVA del 21%
    }

    // Retorna el nombre d'elements diferents  que conté la cistella.
    public int GetNElements()
    {
        return this.nElements;
    }

    // Retorna la quantitat de diners restants a la cistella després de fer les compres.
    public decimal GetDiners()
    {
        return this.diners;
    }

    // Retorna la data i hora de la creació o ús de la cistella.
    public DateTime GetData()
    {
        return this.data;
    }
}

