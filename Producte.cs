using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoanAlex.BotigaCistella
{
    using System;

    /// <summary>
    /// Classe que representa un producte d'una botiga amb el seu nom, preu, IVA i quantitat en estoc.
    /// </summary>
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

}
