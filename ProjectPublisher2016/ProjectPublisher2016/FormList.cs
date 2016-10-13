using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	public class FormList : System.Windows.Forms.Form
    {
		public System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.LinkLabel linkLabel1;
		public System.Windows.Forms.LinkLabel linkLabel2;
		public System.Windows.Forms.LinkLabel linkLabel3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.LinkLabel linkLabel4;

		private string url;

		public FormList(string u)
		{
			url = u;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormList));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(256, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Your project has been successfully published.  The following Lists were created b" +
                "y the Project Publisher:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(24, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 16);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Project Center";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(24, 56);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(72, 16);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Task Center";
            this.linkLabel2.Visible = false;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.Location = new System.Drawing.Point(24, 72);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(96, 16);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Resource Center";
            this.linkLabel3.Visible = false;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Click the link below to learn how to add the new Lists that were created to your " +
                "SharePoint Quick launch menu.";
            // 
            // linkLabel4
            // 
            this.linkLabel4.Location = new System.Drawing.Point(8, 128);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(312, 16);
            this.linkLabel4.TabIndex = 11;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "How to add Lists to your SharePoint Quick Launch bar";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // FormList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 186);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Notification";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void FormAbout_Load(object sender, System.EventArgs e)
		{
			
		}

		private void linkLabel4_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore"," http://www.epmlive.com/pubhelp/Creating_Quick_Launch_Links.htm#Creating Quick Launch Links");
			
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore"," " + url + "/lists/project%20center");
		}

		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore"," " + url + "/lists/task%20center");
		}

		private void linkLabel3_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("IExplore"," " + url + "/lists/resource%20center");
		}

	}
}
