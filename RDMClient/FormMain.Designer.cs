namespace RDMClient
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDeconnect = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.txtboxPseudo = new System.Windows.Forms.TextBox();
            this.txtboxWebService = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbPseudo = new System.Windows.Forms.Label();
            this.lbWebService = new System.Windows.Forms.Label();
            this.lstbPseudos = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstbPseudos, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 217);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbError);
            this.groupBox1.Controls.Add(this.btDeconnect);
            this.groupBox1.Controls.Add(this.btConnect);
            this.groupBox1.Controls.Add(this.txtboxPassword);
            this.groupBox1.Controls.Add(this.txtboxPseudo);
            this.groupBox1.Controls.Add(this.txtboxWebService);
            this.groupBox1.Controls.Add(this.lbPassword);
            this.groupBox1.Controls.Add(this.lbPseudo);
            this.groupBox1.Controls.Add(this.lbWebService);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btDeconnect
            // 
            this.btDeconnect.Location = new System.Drawing.Point(181, 149);
            this.btDeconnect.Name = "btDeconnect";
            this.btDeconnect.Size = new System.Drawing.Size(83, 23);
            this.btDeconnect.TabIndex = 7;
            this.btDeconnect.Text = "Déconnecter";
            this.btDeconnect.UseVisualStyleBackColor = true;
            this.btDeconnect.Click += new System.EventHandler(this.btDeconnect_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(32, 149);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 6;
            this.btConnect.Text = "Connecter";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(105, 109);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(184, 20);
            this.txtboxPassword.TabIndex = 5;
            this.txtboxPassword.TextChanged += new System.EventHandler(this.txtboxPassword_TextChanged);
            // 
            // txtboxPseudo
            // 
            this.txtboxPseudo.Location = new System.Drawing.Point(105, 69);
            this.txtboxPseudo.Name = "txtboxPseudo";
            this.txtboxPseudo.Size = new System.Drawing.Size(184, 20);
            this.txtboxPseudo.TabIndex = 4;
            this.txtboxPseudo.TextChanged += new System.EventHandler(this.txtboxPseudo_TextChanged);
            // 
            // txtboxWebService
            // 
            this.txtboxWebService.Location = new System.Drawing.Point(105, 29);
            this.txtboxWebService.Name = "txtboxWebService";
            this.txtboxWebService.Size = new System.Drawing.Size(184, 20);
            this.txtboxWebService.TabIndex = 3;
            this.txtboxWebService.Text = "http://user10.2isa.org";
            this.txtboxWebService.TextChanged += new System.EventHandler(this.txtboxWebService_TextChanged);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(10, 112);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 2;
            this.lbPassword.Text = "Password";
            // 
            // lbPseudo
            // 
            this.lbPseudo.AutoSize = true;
            this.lbPseudo.Location = new System.Drawing.Point(10, 69);
            this.lbPseudo.Name = "lbPseudo";
            this.lbPseudo.Size = new System.Drawing.Size(43, 13);
            this.lbPseudo.TabIndex = 1;
            this.lbPseudo.Text = "Pseudo";
            // 
            // lbWebService
            // 
            this.lbWebService.AutoSize = true;
            this.lbWebService.Location = new System.Drawing.Point(10, 29);
            this.lbWebService.Name = "lbWebService";
            this.lbWebService.Size = new System.Drawing.Size(69, 13);
            this.lbWebService.TabIndex = 0;
            this.lbWebService.Text = "Web Service";
            // 
            // lstbPseudos
            // 
            this.lstbPseudos.FormattingEnabled = true;
            this.lstbPseudos.Location = new System.Drawing.Point(316, 3);
            this.lstbPseudos.Name = "lstbPseudos";
            this.lstbPseudos.Size = new System.Drawing.Size(307, 199);
            this.lstbPseudos.TabIndex = 1;
          
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 78);
            this.panel2.TabIndex = 2;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Location = new System.Drawing.Point(111, 186);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.TextBox txtboxPseudo;
        private System.Windows.Forms.TextBox txtboxWebService;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbPseudo;
        private System.Windows.Forms.Label lbWebService;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDeconnect;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ListBox lstbPseudos;
        private System.Windows.Forms.Label lbError;
    }
}

