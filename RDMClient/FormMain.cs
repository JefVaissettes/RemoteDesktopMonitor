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
using RDMDALWSR;


namespace RDMClient
{//TODO

    public partial class FormMain : Form
    {
        
        internal const string ADR_SERVICE_DEBUG = "http://localhost:60078/";

        private RdmDalWSR _rdmDal = new RdmDalWSR();

        public FormMain()
        {
            InitializeComponent();

            // On fixe l'adresse de base du service Web
            //_rdmDal.StringConnect = txtboxWebService.Text;

            // On fixe l'adresse de base du service Web en mode Debug (exécution du service en local)
            _rdmDal.StringConnect = ADR_SERVICE_DEBUG;

        }


        
        private async void btConnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            btDeconnect.Enabled = false;

            RdmDalWSRResult ret = await _rdmDal.LoginAsync(CancellationToken.None);

            if (ret.IsSuccess)
            {
                txtboxWebService.Enabled = false;
                txtboxPseudo.Enabled = false;
                txtboxPassword.Text = (string) ret.Data;
                lbError.Text = "Vous êtes connecté";
            }
            else
            {
                lbError.Text = ret.ErrorMessage;
            }

            btConnect.Enabled = true;
            btDeconnect.Enabled = true;

        }

        private async void btDeconnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            btDeconnect.Enabled = false;

            RdmDalWSRResult ret = await _rdmDal.LogoutAsync(CancellationToken.None);

       
            if (ret.IsSuccess)
            {
                
                lbError.Text = "Vous n'êtes pas connecté";
            }
            else
            {
                lbError.Text = "Vous n'êtes pas connecté" + ret.ErrorMessage;
            }

            btConnect.Enabled = true;
            btDeconnect.Enabled = true;
           
            lstbPseudos.Items.Clear();
            txtboxWebService.Enabled = true;
            txtboxPseudo.Enabled = true;
            txtboxPassword.Text = String.Empty;
            
        }

        private void txtboxWebService_TextChanged(object sender, EventArgs e)
        {
            _rdmDal.StringConnect = txtboxWebService.Text;
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e)
        {
            btDeconnect.Enabled = (!String.IsNullOrWhiteSpace(txtboxPassword.Text));
             
        }

        private void txtboxPseudo_TextChanged(object sender, EventArgs e)
        {
            _rdmDal.PseudoConnect = txtboxPseudo.Text;
            btConnect.Enabled = (!String.IsNullOrWhiteSpace(txtboxPseudo.Text));

        }


       

    }
}
