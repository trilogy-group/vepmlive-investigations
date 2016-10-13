using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormBuildTeam.
	/// </summary>
	public class FormBuildTeam : System.Windows.Forms.Form
    {
		public System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader resName;
		private System.Windows.Forms.ColumnHeader email;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;

		public Hashtable myUsers;
		private System.Windows.Forms.ComboBox comboBox2;
		public Hashtable myGroups;
		public Hashtable myUserLogins;
		public string url;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label2;
		public Microsoft.Office.Interop.MSProject.Project pj;

		public FormBuildTeam()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildTeam));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.resName,
            this.email,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 78);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(696, 208);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Group";
            this.columnHeader1.Width = 100;
            // 
            // resName
            // 
            this.resName.Text = "Name";
            this.resName.Width = 179;
            // 
            // email
            // 
            this.email.Text = "E-Mail";
            this.email.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 107;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(552, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 72);
            this.label1.TabIndex = 9;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Items.AddRange(new object[] {
            "Do Not Process"});
            this.comboBox1.Location = new System.Drawing.Point(8, 294);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.Black;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.ItemHeight = 13;
            this.comboBox2.Items.AddRange(new object[] {
            "Do Not Process",
            "Request Account"});
            this.comboBox2.Location = new System.Drawing.Point(120, 294);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(104, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Visible = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(632, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Location = new System.Drawing.Point(8, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // FormBuildTeam
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 325);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBuildTeam";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Build Team";
            this.Load += new System.EventHandler(this.FormBuildTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(listView1.SelectedItems.Count > 0)
			{
				if(listView1.SelectedItems[0].SubItems[4].Text == "1")
				{
					comboBox1.Top = listView1.SelectedItems[0].Bounds.Top - 3;
					comboBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
					comboBox1.Left = 0;
					comboBox1.Visible = true;
					comboBox2.Visible = false;
				}
				else
				{
					comboBox2.Top = listView1.SelectedItems[0].Bounds.Top - 3;
					comboBox2.Text = listView1.SelectedItems[0].SubItems[0].Text;
					comboBox2.Left = 0;
					comboBox2.Visible = true;
					comboBox1.Visible = false;
				}
			}
			else
			{
				comboBox1.Visible = false;
				comboBox2.Visible = false;
			}
		}

		private void FormBuildTeam_Load(object sender, System.EventArgs e)
		{
			label1.Text = "The following users are currently in your Microsoft Project Resource Sheet but do not have access to your SharePoint site.  To add them to your SharePoint site, choose the security group using the Group dropdown list then click the OK button. \n\nNote:  If users in your Microsoft Project Resource Sheet do not have EPM Live accounts, you will need to request account creation by choosing that option in the Group dropdown list.";
			comboBox2.Parent = listView1;
			comboBox1.Parent = listView1;

			comboBox1.Items.Clear();
			comboBox1.Items.Add("Do Not Process");

			int width = 104;
			foreach(DictionaryEntry entry in myGroups)
			{
				label2.Text = entry.Key.ToString();
				if(label2.Width > width)
					width = label2.Width;
			}
			comboBox1.Width = width;
			comboBox2.Width = width;
			listView1.Columns[0].Width = width;
			foreach(DictionaryEntry entry in myGroups)
			{
				comboBox1.Items.Add(entry.Key.ToString());
			}

			foreach(DictionaryEntry entry in myUsers)
			{
				ListViewItem li = new ListViewItem(new string[]{"Do Not Process",entry.Value.ToString(),entry.Key.ToString(),myUserLogins[entry.Key.ToString()].ToString(),"1"});
				listView1.Items.Add(li);
			}
			bool siteAdmin = isSiteAdmin();
			foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
			{
				string email = res.EMailAddress.Trim();
				if(email != "")
				{
					if(!myUsers.Contains(email))
					{
						bool found = false;
						for(int i = 0;i<CheckResources.resCount;i++)
						{
							if(CheckResources.resList[i].email.ToLower() == email.ToLower() && CheckResources.resList[i].matchedResID > 0)
							{
								found = true;
							}
						}
						if(!found)
						{
							if(siteAdmin)
							{
								ListViewItem li = new ListViewItem(new string[]{"Do Not Process",res.Name,res.EMailAddress,"","1"});
								listView1.Items.Add(li);
							}
							else
							{
								ListViewItem li = new ListViewItem(new string[]{"Do Not Process",res.Name,res.EMailAddress,"","0"});
								listView1.Items.Add(li);
							}
							
						}
					}
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listView1.SelectedItems[0].SubItems[0].Text = comboBox1.Text;
			comboBox1.Visible = false;
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listView1.SelectedItems[0].SubItems[0].Text = comboBox2.Text;
			comboBox2.Visible = false;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
		}

		private bool isSiteAdmin()
		{
			SPSUserGroup.UserGroup spUserGroup = new SPSUserGroup.UserGroup();
			spUserGroup.Url = this.url + "/_vti_bin/UserGroup.asmx";

			if(Connection.username == "")
			{
				Connection.username = "";
				spUserGroup.Credentials = System.Net.CredentialCache.DefaultCredentials;
			}
			else
			{
				System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username,Connection.password,Connection.domain);
				spUserGroup.Credentials = nw;
			}

			
			XmlNode nd = spUserGroup.GetAllUserCollectionFromWeb();
			XmlNode xmlUsers = nd["Users"];

			for(int j=0;j<xmlUsers.ChildNodes.Count;j++)
			{
				if(xmlUsers.ChildNodes[j].Attributes["IsSiteAdmin"].Value.Trim() == "True")
				{
					if(xmlUsers.ChildNodes[j].Attributes["LoginName"].Value.ToLower() == Connection.fullUsername.ToLower())
						return true;
				}
			}
			return false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			CheckResources.check(false, pj);
			BuildTeam.build(pj, url);
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(e.Link.LinkData.ToString());
		}
	}
}
