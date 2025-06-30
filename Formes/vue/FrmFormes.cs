using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Formes
{
    public partial class FrmFormes : Form
    {
        /// <summary>
        /// Texte du label associé aux formes avec un côté (carré, cube)
        /// </summary>
        private const string COTE = "côté";

        /// <summary>
        /// Texte du label associé aux formes avec un rayon (cercle, sphère)
        /// </summary>
        private const string RAYON = "rayon";

        /// <summary>
        /// Culture utilisée pour le formatage des nombres (français)
        /// </summary>
        private const string CULTURE = "fr-FR";

        /// <summary>
        /// Initialise la fenêtre et les composants
        /// </summary>
        public FrmFormes()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide les champs de résultat (aire, périmètre, volume)
        /// </summary>
        private void ViderChamps()
        {
            TxtAire.Text = "";
            TxtPerimetre.Text = "";
            TxtVolume.Text = "";
        }
        /// <summary>
        /// Tente de récupérer la valeur saisie par l'utilisateur en tant que double.
        /// Retourne null si la saisie est invalide.
        /// </summary>
        private double? RecupValeur()
        {
            return double.TryParse(TxtValeur.Text, out double val) ? (double?)val : null;
        }
        /// <summary>
        /// Met à jour les résultats pour une forme 2D (carre, cercle)
        /// </summary>
        /// <param name="forme2D">La forme 2D à afficher</param>
        private void Forme2D(IForme2D forme2D)
        {
            LblValeur.Text = forme2D is Carre ? COTE : RAYON;
            MajTxtPerimetre(forme2D);
            MajTxtAire(forme2D);
            TxtVolume.Text = "";
        }
        /// <summary>
        /// Met à jour les résultats pour une forme 3D (cube, sphère)
        /// </summary>
        /// <param name="forme3D">La forme 3D à afficher</param>
        private void Forme3D(IForme3D forme3D)
        {
            LblValeur.Text = forme3D is Cube ? COTE : RAYON;
            MajTxtAire(forme3D);
            MajTxtVolume(forme3D);
            TxtPerimetre.Text = "";
        }
        /// <summary>
        /// Formate un nombre en chaîne localisée (fr-FR), arrondie à deux décimales si nécessaire
        /// </summary>
        /// <param name="valeur">La valeur à formater</param>
        /// <returns>La chaîne formatée</returns>
        private string FormatText(double valeur)
        {
            var culture = CultureInfo.GetCultureInfo(CULTURE);
            return valeur % 1 == 0
                ? valeur.ToString(culture)
                : valeur.ToString("F2", culture);
        }
        /// <summary>
        /// Met à jour le champ périmètre
        /// </summary>
        /// <param name="forme2D">La forme dont on veut le périmètre</param>
        private void MajTxtPerimetre(IForme2D forme2D)
        {
            TxtPerimetre.Text = FormatText(forme2D.Perimetre());
        }
        /// <summary>
        /// Met à jour le champ volume
        /// </summary>
        /// <param name="forme3D">La forme dont on veut le volume</param>
        private void MajTxtVolume(IForme3D forme3D)
        {
            TxtVolume.Text = FormatText(forme3D.Volume());
        }
        /// <summary>
        /// Met à jour le champ aire
        /// </summary>
        /// <param name="forme">La forme dont on veut l'aire</param>
        private void MajTxtAire(IForme forme)
        {
            TxtAire.Text = FormatText(forme.Aire());
        }
        /// <summary>
        /// Met à jour les champs selon la forme sélectionnée et la valeur saisie
        /// </summary>
        private void ActualiserForme()
        {
            double? valeur = RecupValeur();

            if (!valeur.HasValue)
            {
                ViderChamps();
                return;
            }
            if (RdbCarre.Checked) 
                Forme2D(new Carre(valeur.Value));
            else if (RdbCercle.Checked) 
                Forme2D(new Cercle(valeur.Value));
            else if (RdbCube.Checked) 
                Forme3D(new Cube(valeur.Value));
            else if (RdbSphere.Checked) 
                Forme3D(new Sphere(valeur.Value));
        }
        /// <summary>
        /// Déclenché à chaque modification de la valeur saisie.
        /// Met à jour l'affichage des résultats.
        /// </summary
        private void TxtValeur_TextChanged(object sender, EventArgs e)
        {
            ActualiserForme();
        }
        private void RdbCarre_CheckedChanged(object sender, EventArgs e)
        {
            ActualiserForme();
        }
        private void RdbCube_CheckedChanged(object sender, EventArgs e)
        {
            ActualiserForme();
        }
        private void RdbCercle_CheckedChanged(object sender, EventArgs e)
        {
            ActualiserForme();
        }
        private void RdbSphere_CheckedChanged(object sender, EventArgs e)
        {
            ActualiserForme();
        }
    }
}
