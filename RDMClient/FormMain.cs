﻿using ConsumeWebServiceRest;
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

   

        public FormMain()
        {
            InitializeComponent();
        }
       

        private async void btConnect_Click(object sender, EventArgs e)
        {
            string login = "http;//localhost:600078/ServiceRDM.svc/Login";
            WSR_Params wsr_params = new WSR_Params();
            wsr_params.Add("pseudo", txtPseudo.Text);
            WSR_Result wsr_result = new WSR_Result();
            wsr_result = await ConsumeWSR.Call(login, wsr_params, TypeSerializer.Json, CancellationToken.None);
        }

        private async void btDeConnect_Click(object sender, EventArgs e)
        {

        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWebService_TextChanged(object sender, EventArgs e)
        {

        }

        private async void txtPseudo_TextChanged(object sender, EventArgs e)
        {
            //string login = "http;//localhost:600078/ServiceRDM.svc/Login";
            //WSR_Params wsr_params = new WSR_Params();
            //wsr_params.Add("pseudo", txtPseudo.Text);
            //WSR_Result wsr_result = new WSR_Result();
            //wsr_result = await ConsumeWSR.Call(login, wsr_params, TypeSerializer.Json, CancellationToken.None);

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
