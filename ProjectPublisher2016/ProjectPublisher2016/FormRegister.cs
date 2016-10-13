using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormRegister.
	/// </summary>
	public class FormRegister : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtCompany;
		public System.Windows.Forms.TextBox txtSerial;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Button button2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		public System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormRegister()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your copy of Project Publisher has not been activated. To activate your product p" +
                "lease enter your company information and serial number into the boxes below.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Company:";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(4, 62);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(440, 20);
            this.txtCompany.TabIndex = 7;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(4, 102);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(440, 20);
            this.txtSerial.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Serial Number:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(252, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Activate Now";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(4, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(392, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "You have 0 days left on your 30 days trial.";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.button2.Location = new System.Drawing.Point(148, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "Skip Activation";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(4, 166);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 16);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Buy Now";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(348, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 24);
            this.button3.TabIndex = 14;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // FormRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 192);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRegister";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FormRegister_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtCompany.Text = RegistryClass.GetSetting("Tr","Company","");
				txtSerial.Text = RegistryClass.GetSetting("Tr","Key","");
			}
			catch{}
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore","http://www.projectpublisher.com/buy.aspx");
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Activating...";
			frmStatus.Show();
			frmStatus.Refresh();

			int error = 0;
			try
			{
				WSactivation.Service activation = new WSactivation.Service();
				if(RegistryClass.GetSetting("Tr","UseProxy","") == "True")
				{
					System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr","ProxyServer","") + ":" + RegistryClass.GetSetting("Tr","ProxyPort",""), true);
					if(RegistryClass.GetSetting("Tr","ProxyAuth","") == "True")
						if(RegistryClass.GetSetting("Tr","ProxyUseWindows","") == "True")
							pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
						else
							pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr","ProxyUsername",""),RegistryClass.GetSetting("Tr","ProxyPassword",""));
					activation.Proxy = pr;
				}
				string code = activation.Activate(txtCompany.Text,txtSerial.Text,out error);

				if(error == 0)
				{
					RegistryClass.SaveSetting("Tr","Company",txtCompany.Text);
					RegistryClass.SaveSetting("Tr","Key",txtSerial.Text.Replace("-","").ToUpper());
					RegistryClass.SaveSetting("Tr","Code",RA.computerCode(code));

					MessageBox.Show("Your product has been activated successfully!");
					this.DialogResult = DialogResult.OK;
				}
				else if(error == 1)
				{
					System.Windows.Forms.MessageBox.Show("There are no activations remaining for this serial number.","Activation");
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("That is an invalid Serial Number.","Invalid Key");
				}

			}
			catch(Exception)
			{
				MessageBox.Show("Product cannot be activated at this time.");
			}
			frmStatus.Dispose();
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
