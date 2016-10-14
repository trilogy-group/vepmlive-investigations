using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormHelp.
	/// </summary>
	public class FormHelp : System.Windows.Forms.Form
	{
        private WebBrowser webBrowser1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormHelp()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1045, 469);
            this.webBrowser1.TabIndex = 0;
            // 
            // FormHelp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 469);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHelp";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.FormHelp_Load);
            this.Resize += new System.EventHandler(this.FormHelp_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormHelp_Load(object sender, System.EventArgs e)
		{
			object missing = System.Reflection.Missing.Value;
            webBrowser1.Navigate("http://upland.screenstepslive.com/s/EPMLive2013/m/UserGuide/c/58107");
			//axWebBrowser1.Height = this.Height - 40;
		}

		private void FormHelp_Resize(object sender, System.EventArgs e)
		{
			//axWebBrowser1.Height = this.Height - 40;
		}
	}
}
