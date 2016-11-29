using RDMDALWSR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDMClient
{
    public partial class FormMain : Form
    {
        internal const string ADR_SERVICE_DEBUG = "http://localhost:60078/";

        private RdmDalWSR _rdmDAL = new RdmDalWSR();

        public FormMain()
        {
            InitializeComponent();

            //_rdmDAL.StringConnect = txtWebService.Text;

            _rdmDAL.StringConnect = ADR_SERVICE_DEBUG;
        }

        #region Ouverture et fermeture de la fenêtre

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (_rdmDAL.IsLogged)
                {
                    e.Cancel = true;

                    await _rdmDAL.LogoutAsync(CancellationToken.None);

                    this.Close();
                }
            }
        }

        #endregion

        #region Evenements TextChanged

        private void txtWebService_TextChanged(object sender, EventArgs e)
        {
            _rdmDAL.StringConnect = txtWebService.Text;
        }

        private void txtPseudo_TextChanged(object sender, EventArgs e)
        {
            _rdmDAL.PseudoConnect = txtPseudo.Text;
            btConnect.Enabled = (!String.IsNullOrWhiteSpace(txtPseudo.Text));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btDeConnect.Enabled = (!String.IsNullOrWhiteSpace(txtPassword.Text));
        }

        #endregion

        #region Bloc PanelConnexion Connecter Déconnecter Annuler

        /// <summary>
        /// Bouton se Connecter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btConnect_Click(object sender, EventArgs e)
        {
            panelConnexion.Enabled = false;

            RdmDalWSRResult ret = await _rdmDAL.LoginAsync(CancellationToken.None);

            if (ret.IsSuccess)
            {
                txtWebService.Enabled = false;
                txtPseudo.Enabled = false;
                txtPassword.Text = (string)ret.Data;
                lblErreur.Text = "Vous êtes connecté"; 
            }
            else
            {
                lblErreur.Text = ret.ErrorMessage;
            }

            panelConnexion.Enabled = true;
        }

        /// <summary>
        /// Bouton se déconnecter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btDeConnect_Click(object sender, EventArgs e)
        {
            panelConnexion.Enabled = false;

            RdmDalWSRResult ret = await _rdmDAL.LogoutAsync(CancellationToken.None);

            if (ret.IsSuccess)
            {
                lblErreur.Text = "Vous n'êtes pas connecté";
            }
            else
            {
                lblErreur.Text = ret.ErrorMessage;
            }

            panelConnexion.Enabled = true;

            listBoxPseudoConnected.Items.Clear();

            //Réinitialisation des 3 textbox
            txtWebService.Enabled = true;
            txtPseudo.Enabled = true;
            txtPassword.Text = String.Empty;
        }

        /// <summary>
        /// Bouton annuler pour sortir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void listBoxPseudoConnected_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listBoxPseudoConnected_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
