using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormProxy.
	/// </summary>
	public class FormProxy : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox chkAuth;
		private System.Windows.Forms.CheckBox chkProxy;
		private System.Windows.Forms.CheckBox chkWindows;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label LabelUsername;
		private System.Windows.Forms.TextBox txtUsername;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormProxy()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.chkWindows = new System.Windows.Forms.CheckBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.chkProxy = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Proxy Server:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkAuth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 224);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.LabelUsername);
            this.groupBox2.Controls.Add(this.chkWindows);
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 128);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(8, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(232, 20);
            this.txtPassword.TabIndex = 15;
            this.txtPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(8, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(232, 20);
            this.txtUsername.TabIndex = 13;
            // 
            // LabelUsername
            // 
            this.LabelUsername.Location = new System.Drawing.Point(8, 40);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(100, 16);
            this.LabelUsername.TabIndex = 12;
            this.LabelUsername.Text = "Username:";
            // 
            // chkWindows
            // 
            this.chkWindows.Location = new System.Drawing.Point(8, 16);
            this.chkWindows.Name = "chkWindows";
            this.chkWindows.Size = new System.Drawing.Size(224, 24);
            this.chkWindows.TabIndex = 11;
            this.chkWindows.Text = "Use Windows Authentication";
            this.chkWindows.CheckedChanged += new System.EventHandler(this.chkWindows_CheckedChanged);
            // 
            // chkAuth
            // 
            this.chkAuth.Location = new System.Drawing.Point(8, 64);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(224, 24);
            this.chkAuth.TabIndex = 10;
            this.chkAuth.Text = "Proxy Server Requires Authentication";
            this.chkAuth.CheckedChanged += new System.EventHandler(this.chkAuth_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(200, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(200, 40);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 20);
            this.txtPort.TabIndex = 8;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(8, 40);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(184, 20);
            this.txtServer.TabIndex = 7;
            // 
            // chkProxy
            // 
            this.chkProxy.Location = new System.Drawing.Point(8, 6);
            this.chkProxy.Name = "chkProxy";
            this.chkProxy.Size = new System.Drawing.Size(216, 24);
            this.chkProxy.TabIndex = 8;
            this.chkProxy.Text = "Use Proxy Server";
            this.chkProxy.CheckedChanged += new System.EventHandler(this.chkProxy_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(117, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(197, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // FormProxy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 292);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkProxy);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormProxy";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Proxy Settings";
            this.Load += new System.EventHandler(this.FormProxy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void chkWindows_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkWindows.Checked)
			{
				txtUsername.Enabled = false;
				txtPassword.Enabled = false;
			}
			else
			{
				txtUsername.Enabled = true;
				txtPassword.Enabled = true;
			}
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkAuth_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAuth.Checked)
				groupBox2.Enabled = true;
			else
				groupBox2.Enabled = false;
		}

		private void chkProxy_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkProxy.Checked)
				groupBox1.Enabled = true;
			else
				groupBox1.Enabled = false;
		}

		private void FormProxy_Load(object sender, System.EventArgs e)
		{
			chkProxy.Checked = Convert.ToBoolean(RegistryClass.GetSetting("Tr","UseProxy","False"));
			txtServer.Text = RegistryClass.GetSetting("Tr","ProxyServer","");
			txtPort.Text = RegistryClass.GetSetting("Tr","ProxyPort","");
			chkAuth.Checked = Convert.ToBoolean(RegistryClass.GetSetting("Tr","ProxyAuth","False"));
			chkWindows.Checked = Convert.ToBoolean(RegistryClass.GetSetting("Tr","ProxyUseWindows","False"));
			txtUsername.Text = RegistryClass.GetSetting("Tr","ProxyUsername","");
			txtPassword.Text = RegistryClass.GetSetting("Tr","ProxyPassword","");

			chkProxy_CheckedChanged(this, null);
			chkAuth_CheckedChanged(this, null);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			RegistryClass.SaveSetting("Tr","UseProxy",chkProxy.Checked.ToString());
			RegistryClass.SaveSetting("Tr","ProxyServer",txtServer.Text);
			RegistryClass.SaveSetting("Tr","ProxyPort",txtPort.Text);
			RegistryClass.SaveSetting("Tr","ProxyAuth",chkAuth.Checked.ToString());
			RegistryClass.SaveSetting("Tr","ProxyUseWindows",chkWindows.Checked.ToString());
			RegistryClass.SaveSetting("Tr","ProxyUsername",txtUsername.Text);
			RegistryClass.SaveSetting("Tr","ProxyPassword",txtPassword.Text);
		}
	}
}
