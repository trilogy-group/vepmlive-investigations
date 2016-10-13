using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormTaskInformation.
	/// </summary>
	public class FormTaskInformation : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTaskName;

		private Connect.Tasks task;
		private Microsoft.Office.Interop.MSProject.Project pj;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblFinish;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox txtApprovalNotes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		public System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblModified;
        private WebBrowser webBrowser1;

		Hashtable myHash = new Hashtable();

		public FormTaskInformation(Connect.Tasks taskItem, Microsoft.Office.Interop.MSProject.Project iPj)
		{
			this.task = taskItem;
			this.pj = iPj;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskInformation));
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApprovalNotes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblModified = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTaskName.Location = new System.Drawing.Point(80, 8);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(560, 16);
            this.lblTaskName.TabIndex = 7;
            this.lblTaskName.Text = "label8";
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(48, 32);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(200, 16);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "label8";
            // 
            // lblFinish
            // 
            this.lblFinish.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFinish.Location = new System.Drawing.Point(56, 48);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(200, 16);
            this.lblFinish.TabIndex = 9;
            this.lblFinish.Text = "label8";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(328, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Approval Notes:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtApprovalNotes
            // 
            this.txtApprovalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtApprovalNotes.Location = new System.Drawing.Point(328, 272);
            this.txtApprovalNotes.Multiline = true;
            this.txtApprovalNotes.Name = "txtApprovalNotes";
            this.txtApprovalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApprovalNotes.Size = new System.Drawing.Size(312, 56);
            this.txtApprovalNotes.TabIndex = 15;
            this.txtApprovalNotes.Text = "textBox1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(488, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(568, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Task Name:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Start:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Finish:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(328, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Resources:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(328, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Bread Crumbs:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(328, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Notes:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(328, 40);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(312, 48);
            this.textBox2.TabIndex = 30;
            this.textBox2.Text = "textBox2";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(328, 112);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(312, 48);
            this.textBox3.TabIndex = 31;
            this.textBox3.Text = "textBox3";
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(8, 112);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(312, 216);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current Value";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New Value";
            this.columnHeader3.Width = 100;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(264, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Fields (Changes shown in yellow):";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(8, 336);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 24);
            this.button3.TabIndex = 36;
            this.button3.Text = "Send E-Mail";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Modified By:";
            // 
            // lblModified
            // 
            this.lblModified.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblModified.Location = new System.Drawing.Point(88, 72);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(232, 16);
            this.lblModified.TabIndex = 37;
            this.lblModified.Text = "label8";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(331, 188);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(307, 65);
            this.webBrowser1.TabIndex = 39;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // FormTaskInformation
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 367);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblModified);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtApprovalNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblTaskName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTaskInformation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTaskInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FormTaskInformation_Load(object sender, System.EventArgs e)
		{
			System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo( );

			provider.NumberDecimalSeparator = ".";
			provider.NumberGroupSeparator = ",";
			provider.NumberGroupSizes = new int[ ] { 3 };
//			this.lblActualFinish.Text = task.actualFinish;
//			this.lblActualStart.Text =  task.actualStart;
			this.lblFinish.Text = task.finish;
			lblModified.Text = task.modifiedBy;

			object empty = System.Reflection.Missing.Value;
			string body = "<body leftmargin=\"0\" rightmargin=\"0\" topmargin=\"0\" bottommargin=\"0\" target=\"_blank\" style=\"font-family:MS Sans Serif;font-size:10px\">";
			webBrowser1.Navigate("about:blank");

			body += task.notes.Replace("\r\n","<br>").Replace("<a href=","<a target=\"_blank\" href=") + "</body>";
			
            webBrowser1.DocumentText = body;

//			if(task.pctComplete != "")
//				this.lblPctComplete.Text = task.pctComplete + "%";
//			else
//				this.lblPctComplete.Text = "0%";

			this.lblStart.Text = task.start;
			this.lblTaskName.Text =  task.taskname;


			string res = "";
			//string[] ress = task.resource.Replace(";#","\n").Split('\n');

			string []resources = task.resource.Replace(";#","\n").Split('\n');

			for(int i = 0;i<CheckResources.resCount;i++)
			{
				for(int j = 0;j<resources.Length;j=j+2)
				{
					if(resources[j] != "")
					{
						if(Connection.resUrl != "")
						{
							try
							{
								if(CheckResources.resList[i].ResourceID == int.Parse(resources[j]))
								{
									res += "," + CheckResources.resList[i].name;
									if(CheckResources.resList[i].email != "")
										myHash.Add(CheckResources.resList[i].email," ");
								}
							}
							catch{}
						}
						else if(CheckResources.resList[i].resId == int.Parse(resources[j]))
						{
							res += "," + CheckResources.resList[i].name;
							if(CheckResources.resList[i].email != "")
								myHash.Add(CheckResources.resList[i].email," ");
						}
					}
				}
			}
			if(res.Length > 1)
				res = res.Substring(1);

//
//			if(ress.Length > 1)
//				for(int i=1;i<ress.Length;i=i+2)
//					res = res + "; " + ress[i];
//
//			if(res.Length > 2)
//				res = res.Substring(2);

//			for(int i=0;i<ress.Length;i=i+2)
//			{
//				for(int j = 0;j<CheckResources.resCount;j++)
//				{
//					if(ress[i].Trim() != "")
//					{
//						if(CheckResources.resList[j].resId == Convert.ToInt32(ress[i]))
//						{
//							if(CheckResources.resList[j].email != "")
//								myHash.Add(CheckResources.resList[j].email," ");
//						}
//					}
//				}
//			}

			this.textBox3.Text = res;
			this.textBox2.Text = task.breadCrumbs;

			//===============Get Task============
			Microsoft.Office.Interop.MSProject.Task pjTask = null;
			Microsoft.Office.Interop.MSProject.Assignment pjAssn = null;

			string taskuid = task.taskuid;
			string assnuid = "";

			if(task.taskuid.IndexOf(".") > 0)
			{
				int dot = taskuid.IndexOf(".");
				assnuid = taskuid.Substring(dot + 1);
				taskuid = taskuid.Substring(0,dot);
			}

			foreach(Microsoft.Office.Interop.MSProject.Task tsk in pj.Tasks)
			{
				if(tsk != null)
				{
					if(tsk.UniqueID.ToString() == taskuid)
					{
						pjTask = tsk;
						if(assnuid != "")
						{
							foreach(Microsoft.Office.Interop.MSProject.Assignment assn in tsk.Assignments)
							{
								if(assn.UniqueID.ToString() == assnuid)
								{
									pjAssn = assn;
									break;
								}
							}
						}
						break;

					}
				}
			}
			//===================================

			foreach(DictionaryEntry entry in task.customFields)
			{

				int iField = 0;
				try
				{
					iField = Convert.ToInt32(entry.Key.ToString());
				}
				catch{}
				string sFieldVal =  entry.Value.ToString();

				string fieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString();
				fieldName = fieldName.Replace("pjTask","");

                Connect.TaskField tf = (Connect.TaskField)Connect.hTaskCenterFields[fieldName.ToUpper()];
                try
                {
                    if (tf.type == 1) 
                    {
                        sFieldVal = Convert.ToString(sFieldVal);
                    } 
                    else
                    {
                        sFieldVal = Convert.ToString(Convert.ToDouble(sFieldVal));
                    }
                }
                catch { }

				string val = "";
				try
				{
					if(pjAssn != null)
					{
						val = Publish.getFieldForAssignment(pjTask,pjAssn,iField);
					}
					else if(pjTask != null)
					{
						val = pjTask.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
					}
				}
				catch{}
				if(iField == 188743729)
				{
					fieldName = "Assigned To";
					sFieldVal = res;
				}
				if(Connect.hTaskCenterFields.Contains(fieldName.ToUpper()))
				{
					
					tf = (Connect.TaskField)Connect.hTaskCenterFields[fieldName.ToUpper()];
					fieldName = tf.displayName;
					if(tf.type == 2)
					{
						if(tf.outerXml.IndexOf("Percentage=\"TRUE\"") > 0)
						{
							try
							{
								sFieldVal = (float.Parse(sFieldVal) * 100).ToString() + "%";
								val = (float.Parse(val)).ToString() + "%";
							}
							catch{}
						}
						else
						{
							try
							{
								val = val.Split(' ')[0];
							}
							catch{}
						}
					}
					else if(tf.type == 5)
					{
						if(sFieldVal == "0" || sFieldVal.ToLower() == "false")
							sFieldVal = "No";
						else if (sFieldVal == "1" || sFieldVal.ToLower() == "true")
							sFieldVal = "Yes";
						if(val == "0" || val.ToLower() == "false")
							val = "No";
						else if (val == "1" || val.ToLower() == "true")
							val = "Yes";
						
					}
					else if(tf.type == 3)
					{
						try
						{
							sFieldVal = float.Parse(sFieldVal).ToString("c");
						}
						catch{}
						try
						{
							val = float.Parse(val).ToString("c");
						}
						catch{}
					}
					else if(tf.type == 4)
					{
						try
						{
							val = pj.Application.DateFormat(val,Microsoft.Office.Interop.MSProject.PjDateFormat.pjDateDefault).ToString();
						}
						catch{}
						try
						{
							sFieldVal = pj.Application.DateFormat(sFieldVal,Microsoft.Office.Interop.MSProject.PjDateFormat.pjDateDefault).ToString();
						}
						catch{}
						if(sFieldVal == "")
							sFieldVal = "NA";
					}
				}

				if(iField != 188743695)
				{
					if(!(iField == 188743729 && task.type == 0))
					{
						ListViewItem li = listView1.Items.Add(fieldName);
						li.SubItems.Add(val);
						li.SubItems.Add(sFieldVal);
						if(val != sFieldVal)
						{
							li.BackColor = System.Drawing.Color.Yellow;
						}
					}
				}
			}

			this.Refresh();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void lblResources_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label8_Click(object sender, System.EventArgs e)
		{
		
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Generating E-Mail...";
			frmStatus.Show();
			frmStatus.Refresh();
			try
			{

				string subject = Connection.getProjectName(pj) + ": " + task.taskname;
				string body = "\r\n\r\nSite Address: " + Connect.getProperty("EPMLiveURL",pj).Replace(" ","%20");

				MapiMailMessage message = new MapiMailMessage(subject, body);
		

				foreach(DictionaryEntry entry in myHash)
					message.Recipients.Add(entry.Key.ToString());

				frmStatus.Dispose();
				message.ShowDialog();
			}
			catch(Exception ex)
			{
				frmStatus.Dispose();
				MessageBox.Show("Error Generating Email:\r\n" + ex.Message);
			}
			
		}
	}
}
