using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDMDALWSR;
using System.Threading;

namespace RDMClient
{
    public partial class FrmMain : Form
    {
        internal const string ADR_SERVICE_DEBUG = "http://localhost:60078/";

        private RdmDalWSR _rdmDal = new RdmDalWSR();

        public FrmMain()
        {
            InitializeComponent();

            // On fixe l'adresse de base du service Web
            //_rdmDal.StringConnect = txtbWebService.Text;

            // On fixe l'adresse de base du service Web en mode Debug (exécution du service en local)
            _rdmDal.StringConnect = ADR_SERVICE_DEBUG;
            txtWebService.Text = ADR_SERVICE_DEBUG;
        }

        #region "Texte Changed"

        private void txtWebService_TextChanged(object sender, EventArgs e)
        {
            _rdmDal.StringConnect = txtWebService.Text;
        }

        private void txtPseudo_TextChanged(object sender, EventArgs e)
        {
            _rdmDal.PseudoConnect = txtPseudo.Text;
            btConnect.Enabled = (!String.IsNullOrWhiteSpace(txtPseudo.Text));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            btDeconnect.Enabled = (!String.IsNullOrWhiteSpace(txtPassword.Text));
        }
        #endregion

        #region "Evenements Panel Connexion"

        private async void btConnecter_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = true;
            btDeconnect.Enabled = false;
            _rdmDal.PseudoConnect = txtPseudo.Text;
            RdmDalWSRResult ret1 = await _rdmDal.LoginAsync(CancellationToken.None);

            if (ret1.IsSuccess)
            {
                txtWebService.Enabled = false;
                txtPseudo.Enabled = true;
                txtPassword.Text = (string)ret1.Data;
                lblErreur.Text = "Vous êtes connecté";
            }
            else
            {
                lblErreur.Text = ret1.ErrorMessage;
            }

            RdmDalWSRResult ret2 = await _rdmDal.GetPseudosAsync(CancellationToken.None);

            if (ret2.IsSuccess && _rdmDal.IsLogged)
            {
                AfficheListePseudos(ret2);
            }
            else
            {
                lblErreur.Text = ret2.ErrorMessage;
            }
            btConnect.Enabled = false;
            btDeconnect.Enabled = true;
        }

        private async void btDeconnecter_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            btDeconnect.Enabled = false;

            RdmDalWSRResult ret1 = await _rdmDal.LogoutAsync(CancellationToken.None);


            if (ret1.IsSuccess)
            {

                lblErreur.Text = "Vous n'êtes pas connecté";
            }
            else
            {
                lblErreur.Text = "Vous n'êtes pas connecté" + ret1.ErrorMessage;
            }

            btConnect.Enabled = false;
            btDeconnect.Enabled = true;

            // On ré-initialise les champs de la fenêtre
            lstbPseudos.Items.Clear();
            txtWebService.Enabled = true;
            txtPseudo.Enabled = true;
            txtPassword.Text = String.Empty;
            txtPseudo.Text = String.Empty;
            btConnect.Enabled = true;
            btDeconnect.Enabled = false;
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Fonction permettant d'afficer les pseudos dans la liste
        /// </summary>
        /// <param name="result"></param>
        private void AfficheListePseudos(RdmDalWSRResult result)
        {
            List<String> lstResult = (List<string>)result.Data;

            //Suppression des pseudos déconnectés
            for (int i = lstbPseudos.Items.Count - 1; i >= 0; i--)
            {
                if (!lstResult.Contains(lstbPseudos.Items[i]))
                {
                    lstbPseudos.Items.RemoveAt(i);
                }
            }
            //Ajout des news pseudos
            foreach (string pseudo in lstResult)
            {
                if (!lstbPseudos.Items.Contains(pseudo))
                {
                    lstbPseudos.Items.Add(pseudo);
                }
            }
        }
        #endregion
    }
}
