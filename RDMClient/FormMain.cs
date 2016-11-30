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

        private RdmDalWSR _rdmDal = new RdmDalWSR();
        public FormMain()
        {
            InitializeComponent();
            _rdmDal.StringConnect = ADR_SERVICE_DEBUG;
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
            btDeConnect.Enabled = (!String.IsNullOrWhiteSpace(txtPassword.Text));
        }
        #endregion


        #region "Evenement click"

        private async void btConnect_Click(object sender, EventArgs e)
        {
            panelConnexion.Enabled = false;
            RdmDalWSRResult ret = await _rdmDal.LoginAsync(CancellationToken.None);

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

        private async void btDeConnect_Click(object sender, EventArgs e)
        {
            panelConnexion.Enabled = false;
            RdmDalWSRResult ret = await _rdmDal.LogoutAsync(CancellationToken.None);

            if (ret.IsSuccess)
            {
                lblErreur.Text = "Vous n'êtes pas connecté";
            }
            else
            {
                lblErreur.Text = "Vous n'êtes pas connecté" + ret.ErrorMessage;
            }
            panelConnexion.Enabled = true;
            listBoxPseudoConnected.Items.Clear();
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
    }
}
