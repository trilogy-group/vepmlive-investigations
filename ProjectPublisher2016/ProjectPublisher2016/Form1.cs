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
	public class FormSiteConnect : System.Windows.Forms.Form
	{
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
		public bool connected;

		public FormSiteConnect()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSiteConnect));
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please enter the URL to the SharePoint workspace that you want to associate with " +
                "this project.";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(3, 19);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(456, 20);
            this.txtURL.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(291, 51);
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
            this.button1.Location = new System.Drawing.Point(379, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(3, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(272, 16);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Publish TimePhased Data";
            // 
            // FormSiteConnect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 85);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSiteConnect";
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
			
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			if(txtURL.Text.Length > 5)
			{
				if(txtURL.Text.IndexOf("http://") == 0 || txtURL.Text.IndexOf("https://") == 0)
				{
					if(Connect.isProjServer)
					{
						if(txtURL.Text.ToLower().IndexOf(app.Profiles.ActiveProfile.Server.ToLower()) >= 0)
							this.DialogResult = DialogResult.OK;	
						else
							MessageBox.Show("The web you have selected is not part of the Project Server site collection.\r\n\r\nYou must choose something below the following address:\r\n" + app.Profiles.ActiveProfile.Server);
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
	}
}
