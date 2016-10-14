using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.MSProject;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormOptions.
	/// </summary>
	public class FormEntOptions : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtURL;

		public Microsoft.Office.Interop.MSProject.Application app;

		private System.Windows.Forms.RadioButton rdoAssignment;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoTaskAssn;
		private System.Windows.Forms.CheckBox chkHideProjInfo;
		private System.Windows.Forms.CheckBox chkUpdates;
		private System.Windows.Forms.RadioButton rdoTaskNoAssn;

//		private Connect.TaskField []taskFields;

		public FormEntOptions()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntOptions));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.rdoTaskAssn = new System.Windows.Forms.RadioButton();
            this.rdoAssignment = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTaskNoAssn = new System.Windows.Forms.RadioButton();
            this.chkHideProjInfo = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(160, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(240, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Please enter the URL to the SharePoint workspace that you want to associate with " +
                "this project:";
            // 
            // txtURL
            // 
            this.txtURL.Enabled = false;
            this.txtURL.Location = new System.Drawing.Point(8, 40);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(304, 20);
            this.txtURL.TabIndex = 14;
            // 
            // rdoTaskAssn
            // 
            this.rdoTaskAssn.BackColor = System.Drawing.Color.White;
            this.rdoTaskAssn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTaskAssn.Location = new System.Drawing.Point(8, 40);
            this.rdoTaskAssn.Name = "rdoTaskAssn";
            this.rdoTaskAssn.Size = new System.Drawing.Size(216, 24);
            this.rdoTaskAssn.TabIndex = 3;
            this.rdoTaskAssn.Text = "Task Based w/ Assignments";
            this.rdoTaskAssn.UseVisualStyleBackColor = false;
            // 
            // rdoAssignment
            // 
            this.rdoAssignment.BackColor = System.Drawing.Color.White;
            this.rdoAssignment.Checked = true;
            this.rdoAssignment.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoAssignment.Location = new System.Drawing.Point(8, 16);
            this.rdoAssignment.Name = "rdoAssignment";
            this.rdoAssignment.Size = new System.Drawing.Size(152, 24);
            this.rdoAssignment.TabIndex = 2;
            this.rdoAssignment.TabStop = true;
            this.rdoAssignment.Text = "Assignment Based";
            this.rdoAssignment.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rdoTaskNoAssn);
            this.groupBox1.Controls.Add(this.rdoTaskAssn);
            this.groupBox1.Controls.Add(this.rdoAssignment);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Publish Type";
            // 
            // rdoTaskNoAssn
            // 
            this.rdoTaskNoAssn.BackColor = System.Drawing.Color.White;
            this.rdoTaskNoAssn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTaskNoAssn.Location = new System.Drawing.Point(8, 64);
            this.rdoTaskNoAssn.Name = "rdoTaskNoAssn";
            this.rdoTaskNoAssn.Size = new System.Drawing.Size(216, 24);
            this.rdoTaskNoAssn.TabIndex = 4;
            this.rdoTaskNoAssn.Text = "Task Based w/o Assignments";
            this.rdoTaskNoAssn.UseVisualStyleBackColor = false;
            // 
            // chkHideProjInfo
            // 
            this.chkHideProjInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkHideProjInfo.Location = new System.Drawing.Point(8, 176);
            this.chkHideProjInfo.Name = "chkHideProjInfo";
            this.chkHideProjInfo.Size = new System.Drawing.Size(200, 16);
            this.chkHideProjInfo.TabIndex = 18;
            this.chkHideProjInfo.Text = "Hide project information on publish";
            // 
            // chkUpdates
            // 
            this.chkUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkUpdates.Location = new System.Drawing.Point(8, 200);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(200, 16);
            this.chkUpdates.TabIndex = 19;
            this.chkUpdates.Text = "Check for updates on open";
            // 
            // FormEntOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 257);
            this.ControlBox = false;
            this.Controls.Add(this.chkUpdates);
            this.Controls.Add(this.chkHideProjInfo);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormEntOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEntOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(txtURL.Text.Length > 5 || txtURL.Text == "")
			{
				if(txtURL.Text.IndexOf("http://") == 0 || txtURL.Text.IndexOf("https://") == 0 || txtURL.Text == "")
				{

					Connect.setProperty("EPMLiveURL",app.ActiveProject,txtURL.Text);

					this.DialogResult = DialogResult.OK;
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

			if(rdoAssignment.Checked)
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"1");
			else if(rdoTaskNoAssn.Checked)
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"3");
			else
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"2");

			Connect.setProperty("EPMLiveHideProjInfo",app.ActiveProject,chkHideProjInfo.Checked.ToString());
			Connect.setProperty("EPMLiveSU",app.ActiveProject,chkUpdates.Checked.ToString());
		}

		private void FormEntOptions_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtURL.Text = Connect.getProperty("EPMLiveURL",app.ActiveProject);

				if(Connect.getProperty("EPMLiveEntPubType",app.ActiveProject) == "2")
					rdoTaskAssn.Checked = true;
				else if(Connect.getProperty("EPMLiveEntPubType",app.ActiveProject) == "3")
					rdoTaskNoAssn.Checked = true;
				else
					rdoAssignment.Checked = true;

				if(Connect.getProperty("EPMLiveHideProjInfo",app.ActiveProject) == "True")
					chkHideProjInfo.Checked = true;

				if(Connect.getProperty("EPMLiveSU",app.ActiveProject) == "True")
					chkUpdates.Checked = true;

				string strlocks = Connect.getProperty("EPMLivePubLock",app.ActiveProject);
				string []locks = strlocks.Split(',');
				try
				{
					if(locks[0] == "1")
					{
						rdoAssignment.Enabled = false;
						rdoTaskAssn.Enabled = false;
						rdoTaskNoAssn.Enabled = false;
					}
				}
				catch{}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Options Error: " + ex.Message);
			}
		}

	}
}