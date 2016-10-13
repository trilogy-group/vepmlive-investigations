using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for frmResMapHelp.
	/// </summary>
	public class frmResMapHelp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmResMapHelp()
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
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(480, 152);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(424, 160);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 11;
			this.button2.Text = "OK";
			// 
			// frmResMapHelp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(4, 10);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(496, 189);
			this.ControlBox = false;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.Name = "frmResMapHelp";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Resource Mapping Help";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmResMapHelp_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmResMapHelp_Load(object sender, System.EventArgs e)
		{
			label1.Text = "Steps for mapping your resources:\n\n";
			label1.Text += "1. All resources that are in your Microsoft Office Project schedule should be members of your linked SharePoint site as well.  If you need to add resources as members of your SharePoint site, click the Add SharePoint Members link below to do so.\n\n";
			label1.Text += "2.	Once you have all of the resources that you need in the mapping lists and are ready to map, highlight the resource in both lists and click the Map button.  Once mapped, a green checkbox will appear next to their name.\n\n";
			label1.Text += "3.	When you are finished, click the OK button.";
		}
	}
}
