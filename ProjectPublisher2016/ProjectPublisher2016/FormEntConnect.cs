using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormEntConnect : System.Windows.Forms.Form
	{
		public class SiteTemplate
		{
			public string title;
			public string name;
			public override string ToString()
			{
				return title;
			}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		///
		public Microsoft.Office.Interop.MSProject.Application app;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Button btnConnect;
		private System.ComponentModel.Container components = null;
		public string username;
		public string password;
		public string url;
		public string domain;
        private System.Windows.Forms.Button button1;
		public System.Windows.Forms.CheckBox checkBox2;
		public System.Windows.Forms.ComboBox cboTemplate;
		public System.Windows.Forms.Button btnSkip;
		public System.Windows.Forms.Label lblTemplate;
		public bool connected;
		public bool allowCrossSite;

		public FormEntConnect()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntConnect));
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please enter the URL to the SharePoint workspace that you want to associate with " +
                "this project.";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(8, 24);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(528, 20);
            this.txtURL.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(372, 68);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 24);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "OK";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(456, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(8, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(272, 16);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Create site if one doesn\'t exist";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // lblTemplate
            // 
            this.lblTemplate.Enabled = false;
            this.lblTemplate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTemplate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTemplate.Location = new System.Drawing.Point(8, 72);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(80, 16);
            this.lblTemplate.TabIndex = 11;
            this.lblTemplate.Text = "Site Template:";
            // 
            // cboTemplate
            // 
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.Enabled = false;
            this.cboTemplate.Location = new System.Drawing.Point(80, 68);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(204, 21);
            this.cboTemplate.TabIndex = 12;
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSkip.Location = new System.Drawing.Point(288, 68);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(80, 24);
            this.btnSkip.TabIndex = 13;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // FormEntConnect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 99);
            this.ControlBox = false;
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.cboTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEntConnect";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To SharePoint";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSiteConnect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FormSiteConnect_Load(object sender, System.EventArgs e)
		{
			string defUrl = getDefaulPubUrl();
			if(defUrl.IndexOf("http://") >= 0 || defUrl.IndexOf("https://") >= 0)
			{
				txtURL.Text = defUrl+ "/" + app.ActiveProject.Name;
			}
			else
			{
				string serverUrl = app.Profiles.ActiveProfile.Server;
				int slash = serverUrl.IndexOf("/",10);
				if(slash > 0)
				{
					serverUrl = serverUrl.Substring(0,slash);
				}
				txtURL.Text = serverUrl + "/" + defUrl + "/" + app.ActiveProject.Name;
			}
		}

		private string getDefaulPubUrl()
		{
			string url = "";

			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Retrieving Project Information...";
			frmStatus.Show();
			frmStatus.Refresh();

			try
			{
                EPMLivePublisher.EPMLivePublisher chk = Connection.GetPublisherService(Connection.url);
			
				url = chk.getDefaultPublishURL();
			}
			catch{}

			frmStatus.Dispose();
			return url;
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			if(checkBox2.Checked && cboTemplate.SelectedItem == null && cboTemplate.Visible == true)
			{
				MessageBox.Show("Please select a template.");
				return;
			}
			if(txtURL.Text.Length > 5)
			{
				if(txtURL.Text.IndexOf("http://") == 0 || txtURL.Text.IndexOf("https://") == 0)
				{
					if(Connect.isProjServer)
					{
						if(txtURL.Text.ToLower().IndexOf(app.Profiles.ActiveProfile.Server.ToLower()) >= 0)
							this.DialogResult = DialogResult.OK;	
						else if(!allowCrossSite)
							MessageBox.Show("The web you have selected is not part of the Project Server site collection.\r\n\r\nYou must choose something below the following address:\r\n" + app.Profiles.ActiveProfile.Server);
						else
							this.DialogResult = DialogResult.OK;
					}
					else
					{
						this.DialogResult = DialogResult.OK;
						Connect.setProperty("EPMLivePubSummary",app.ActiveProject,"True");
					}
				}
				else
				{
					MessageBox.Show("URL must start with http:// or https://");
				}
			}
			else
			{
				MessageBox.Show("Please enter a valid URL.");
			}
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBox2.Checked)
			{
				cboTemplate.Enabled = true;
				lblTemplate.Enabled = true;
			}
			else
			{
				cboTemplate.Enabled = false;
				lblTemplate.Enabled = false;
			}

		}

		private void btnSkip_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Ignore;
		}
	}
}
