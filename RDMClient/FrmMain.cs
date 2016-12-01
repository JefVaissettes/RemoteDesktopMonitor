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
            btConnecter.Enabled = (!String.IsNullOrWhiteSpace(txtPseudo.Text));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            btDeconnecter.Enabled = (!String.IsNullOrWhiteSpace(txtPassword.Text));
        }
        #endregion

        #region "Evenement click"
        private async void btConnecter_Click(object sender, EventArgs e)
        {
            pnlConnexion.Enabled = false;
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

            pnlConnexion.Enabled = true;
        }

        private async void btDeconnecter_Click(object sender, EventArgs e)
        {
            pnlConnexion.Enabled = false;
            RdmDalWSRResult ret = await _rdmDal.LogoutAsync(CancellationToken.None);

            if (ret.IsSuccess)
            {
                lblErreur.Text = "Vous n'êtes pas connecté";
            }
            else
            {
                lblErreur.Text = "Vous n'êtes pas connecté" + ret.ErrorMessage;
            }
            pnlConnexion.Enabled = true;
            lstbPseudos.Items.Clear();
            txtWebService.Enabled = true;
            txtPseudo.Enabled = true;
            txtPassword.Text = String.Empty;
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
