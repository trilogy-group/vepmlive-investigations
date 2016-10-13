using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Office.Interop.MSProject;
using System.Xml;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormResourceMap.
	/// </summary>
	public class FormResourceMapV2 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader resName;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox chkHideResMap;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ColumnHeader user;

		private Project pj;

        public int resMapVersion = 1;

		public FormResourceMapV2(Project project)
		{

			pj = project;
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
			Connect.NAR(pj);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResourceMapV2));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.resName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.chkHideResMap = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "SharePoint Resources";
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.resName,
            this.user});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 68);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(296, 224);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // resName
            // 
            this.resName.Text = "Name";
            this.resName.Width = 116;
            // 
            // user
            // 
            this.user.Text = "E-Mail";
            this.user.Width = 175;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(405, 68);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(288, 224);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "E-Mail";
            this.columnHeader2.Width = 170;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Microsoft Project Resources";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(309, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "Map >>";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(557, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(629, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Location = new System.Drawing.Point(309, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 24);
            this.button4.TabIndex = 12;
            this.button4.Text = "Add >>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.Location = new System.Drawing.Point(309, 268);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 24);
            this.button5.TabIndex = 17;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(5, 300);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(224, 16);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add Resources";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(680, 40);
            this.label3.TabIndex = 19;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(5, 28);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 16);
            this.linkLabel2.TabIndex = 20;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "More Help";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // chkHideResMap
            // 
            this.chkHideResMap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHideResMap.Location = new System.Drawing.Point(341, 300);
            this.chkHideResMap.Name = "chkHideResMap";
            this.chkHideResMap.Size = new System.Drawing.Size(200, 24);
            this.chkHideResMap.TabIndex = 21;
            this.chkHideResMap.Text = "Do not show resource map again";
            this.chkHideResMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHideResMap.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.Location = new System.Drawing.Point(309, 100);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 24);
            this.button6.TabIndex = 22;
            this.button6.Text = "<< Unmap";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormResourceMapV2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 333);
            this.ControlBox = false;
            this.Controls.Add(this.button6);
            this.Controls.Add(this.chkHideResMap);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResourceMapV2";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Map (Using Resource Pool)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormResourceMap_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormResourceMap_Load(object sender, System.EventArgs e)
		{
			loadIt();
			string hideRes = Connect.getProperty("EPMLiveHideRes",pj);
			if(hideRes.ToUpper() == "TRUE")
			{
				chkHideResMap.Checked = true;
			}
		}

		private int getIndex(ListView lv, string res)
		{
			int i;
			for(i = 0;i<lv.Items.Count;i++)
			{
				if(lv.Items[i].Text.CompareTo(res) > 0)
					return i;
			}
			return i;
		}

		private void loadIt()
		{
			listView1.Items.Clear();
			listView2.Items.Clear();
			
			for(int i = 0;i<CheckResources.resCount;i++)
			{
				ListViewItem li = new ListViewItem(new string[]{CheckResources.resList[i].name,CheckResources.resList[i].email});
				li.Tag = CheckResources.resList[i].resId;
				//listView1.Items.Add(li);
				listView1.Items.Add(li);

				if(CheckResources.resList[i].matchedResID != 0 || CheckResources.resList[i].newRes)
				{
					li.ImageIndex = 0;
				}

			}
			
			Hashtable hshResFields = new Hashtable();
			foreach(Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
			{
				try
				{
					string fieldName = val.ToString();
					if(fieldName.Length > 16 && fieldName.Substring(0,16) == "pjResourceNumber")
					{
						hshResFields.Add(fieldName.Substring(10),(int)val);
					}
				}
				catch{}	
			}

			string field = Connect.getProperty("EPMLiveResField",pj);
			if(field == "")
				field = "Number15";
			
			int fieldId = 0;

			if(hshResFields.Contains(field))
			{
				fieldId = (int)hshResFields[field];
			}

			foreach(Resource res in pj.Resources)
			{
				if(res!=null)
				{
					//if(res.Type == Microsoft.Office.Interop.MSProject.PjResourceTypes.pjResourceTypeWork)
					{
						ListViewItem li = new ListViewItem(new string[]{res.Name,res.EMailAddress});
						li.Tag = res.UniqueID;
						//listView2.Items.Add(li);
						listView2.Items.Insert(getIndex(listView2,res.Name),li);
						for(int i = 0;i<CheckResources.resCount;i++)
						{
							if(fieldId != 0)
							{
								if(CheckResources.resList[i].matchedResID == res.UniqueID)
								{
									if(CheckResources.resList[i].changed)
									{
										li.SubItems[0].Text  = CheckResources.resList[i].name;
										li.ImageIndex = 0;
									}
									else
										li.ImageIndex = 0;

								}
							}
						}
					}
				}
			}

			for(int i = 0;i<CheckResources.resCount;i++)
			{
				if(CheckResources.resList[i].newRes == true)
				{
					ListViewItem li = new ListViewItem(new string[]{CheckResources.resList[i].name,CheckResources.resList[i].email});
					li.ImageIndex = 0;
					//listView2.Items.Add(li);
					listView2.Items.Insert(getIndex(listView2,CheckResources.resList[i].name),li);
				}
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Connect.setProperty("EPMLiveHideRes",pj,chkHideResMap.Checked.ToString());
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(listView1.SelectedItems.Count < 1)
			{
				MessageBox.Show("Please select a SharePoint resource");
				return;
			}
			if(listView2.SelectedItems.Count < 1)
			{
				MessageBox.Show("Please select a Microsoft Project resource");
				return;
			}
			if(listView1.SelectedItems[0].ImageIndex == 0)
			{
				MessageBox.Show("That SharePoint resource is already mapped.");
				return;
			}
			if(listView2.SelectedItems[0].ImageIndex == 0)
			{
				MessageBox.Show("That Microsoft Project resource is already mapped.");
				return;
			}

//			string email = listView1.SelectedItems[0].SubItems[1].Text;

//			for(int i =0;i<CheckResources.resCount;i++)
//			{
//				if(CheckResources.resList[i].resId == int.Parse(listView1.SelectedItems[0].Tag.ToString()))
//				{
//					CheckResources.resList[i].sharepointChange = false;
//				}
//			}

//			if(email.Trim() == "")
//			{
//				FormEmail frmEmail = new FormEmail();
//				frmEmail.label1.Text = "An E-mail address must be specified to map resources. Please enter an E-mail address for " + listView1.SelectedItems[0].SubItems[0].Text;
//				frmEmail.ShowDialog();
//				if(frmEmail.DialogResult == DialogResult.OK)
//				{
//					for(int i =0;i<CheckResources.resCount;i++)
//					{
//						if(CheckResources.resList[i].resId == int.Parse(listView1.SelectedItems[0].Tag.ToString()))
//						{
//							CheckResources.resList[i].sharepointChange = true;
//							email = frmEmail.txtEmail.Text;
//						}
//					}
//				}
//				frmEmail.Dispose();
//			}

			listView1.SelectedItems[0].ImageIndex = 0;
			listView2.SelectedItems[0].ImageIndex = 0;
			listView2.SelectedItems[0].SubItems[0].Text = listView1.SelectedItems[0].SubItems[0].Text;
			listView2.SelectedItems[0].SubItems[1] = listView1.SelectedItems[0].SubItems[1];

			for(int i =0;i<CheckResources.resCount;i++)
			{
				if(CheckResources.resList[i].resId == int.Parse(listView1.SelectedItems[0].Tag.ToString()))
				{
					CheckResources.resList[i].matchedResID = int.Parse(listView2.SelectedItems[0].Tag.ToString());
					CheckResources.resList[i].changed = true;
					break;
				}
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(listView1.SelectedItems.Count > 0)
			{
				for(int i =0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].resId == int.Parse(listView1.SelectedItems[0].Tag.ToString()))
					{
						ListViewItem li = new ListViewItem(new string[]{listView1.SelectedItems[0].SubItems[0].Text,""});
						li.ImageIndex = 0;
						li.Tag = "a" + listView1.SelectedItems[0].Index;
						listView2.Items.Add(li);
						listView1.SelectedItems[0].ImageIndex = 0;
						
						CheckResources.resList[i].newRes = true;
						break;
					}
				}
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button5_Click_1(object sender, System.EventArgs e)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Refreshing Resources...";
			frmStatus.Show();
			frmStatus.Refresh();
            int ResMap = 0;
            Connection.resUrl = "";

            if(Connect.HasWorkEngineAPI())
            {
                Connection.resUrl = Connection.url;
                ResMap = 2;
            }
            else
            {
                Connection.resUrl = Connect.getConfigSetting("EPMLiveResourceURL", pj);
                if(Connection.resUrl != "")
                    ResMap = 1;
            }

            if(ResMap == 2)
            {
                CheckResources.checkV3(false, pj);
            }
            else
            {
                CheckResources.checkV2(false, pj);
            }
			loadIt();
			frmStatus.Dispose();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            if(resMapVersion == 1)
                System.Diagnostics.Process.Start("IExplore", " " + Connection.resUrl + "/Lists/Resources");
            else
            {
                EPMLiveWorkEngine.WorkEngineAPI api = Connection.GetWorkEngineService(Connection.url);

                string projInfo = api.Execute("GetPublisherItemInfo", "<Settings><![CDATA[" + pj.Name + "]]></Settings>");

                XmlDocument docProjInfo = new XmlDocument();
                docProjInfo.LoadXml(projInfo);
                XmlNode ndRes = docProjInfo.FirstChild.FirstChild;

                if(ndRes != null && ndRes.Attributes["ListId"] != null && ndRes.Attributes["ItemId"] != null)
                {
                    System.Diagnostics.Process.Start("IExplore", " " + Connection.resUrl + "/_layouts/epmlive/buildteam.aspx?ListId=" + ndRes.Attributes["ListId"].Value + "&ID=" + ndRes.Attributes["ItemId"].Value);
                }
                else
                {
                    System.Diagnostics.Process.Start("IExplore", " " + Connection.resUrl + "/_layouts/epmlive/buildteam.aspx");
                }
            }
		}
		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmResMapHelp frmHelp = new frmResMapHelp();
			frmHelp.ShowDialog();
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			if(listView2.SelectedItems.Count > 0)
			{
				if(listView2.SelectedItems[0].Tag.ToString()[0] == 'a')
				{
					int index = int.Parse(listView2.SelectedItems[0].Tag.ToString().Substring(1));
					listView1.SelectedItems[index].ImageIndex = -1;
					listView2.Items.Remove(listView2.SelectedItems[0]);
					listView1.Refresh();
				}
				else
				{
					listView2.SelectedItems[0].ImageIndex = -1;

					if(listView2.SelectedItems[0].Tag == null)
					{
						listView2.Items.Remove(listView2.SelectedItems[0]);
					}
					else
					{
						foreach(Resource r in pj.Resources)
						{
							if(r.UniqueID == int.Parse(listView2.SelectedItems[0].Tag.ToString()))
							{
								listView2.SelectedItems[0].SubItems[0].Text = r.Name;
								break;
							}
						}

						for(int i =0;i<CheckResources.resCount;i++)
						{

							if(CheckResources.resList[i].matchedResID == int.Parse(listView2.SelectedItems[0].Tag.ToString()))
							{
						
								CheckResources.resList[i].matchedResID = 0;
								CheckResources.resList[i].changed = true;
								//CheckResources.resList[i].email = email;
								for(int j = 0; j<listView1.Items.Count;j++)
								{
									if(CheckResources.resList[i].resId == int.Parse(listView1.Items[j].Tag.ToString()))
									{
										listView1.Items[j].ImageIndex = -1;
									}
								}
								listView1.Refresh();
								listView2.Refresh();
								break;
						
							}
						}
					}
				}
			}
		}
	}
}
