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
	public class FormEntTaskInformation : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTaskName;

		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblFinish;
		private System.Windows.Forms.Label lblPctComplete;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox txtApprovalNotes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
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
		public System.Windows.Forms.TextBox txtHierarchy;

		private FormApproveEntTasks.UUpdateTaskItem taskItem;
        private WebBrowser webBrowser1;
		private Microsoft.Office.Interop.MSProject.Project pj;

		public FormEntTaskInformation(FormApproveEntTasks.UUpdateTaskItem ti, Microsoft.Office.Interop.MSProject.Project iPj)
		{
			taskItem = ti;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntTaskInformation));
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblPctComplete = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApprovalNotes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHierarchy = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTaskName.Location = new System.Drawing.Point(80, 8);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(344, 16);
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
            // lblPctComplete
            // 
            this.lblPctComplete.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPctComplete.Location = new System.Drawing.Point(88, 72);
            this.lblPctComplete.Name = "lblPctComplete";
            this.lblPctComplete.Size = new System.Drawing.Size(120, 16);
            this.lblPctComplete.TabIndex = 12;
            this.lblPctComplete.Text = "label8";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Approval Notes:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtApprovalNotes
            // 
            this.txtApprovalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtApprovalNotes.Location = new System.Drawing.Point(8, 408);
            this.txtApprovalNotes.Multiline = true;
            this.txtApprovalNotes.Name = "txtApprovalNotes";
            this.txtApprovalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApprovalNotes.Size = new System.Drawing.Size(408, 48);
            this.txtApprovalNotes.TabIndex = 15;
            this.txtApprovalNotes.Text = "textBox1";
            this.txtApprovalNotes.TextChanged += new System.EventHandler(this.txtApprovalNotes_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(264, 464);
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
            this.button2.Location = new System.Drawing.Point(344, 464);
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
            // label6
            // 
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "% Complete:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Notes:";
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
            this.listView1.Size = new System.Drawing.Size(408, 120);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Old Value";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New Value";
            this.columnHeader3.Width = 130;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Updated Values:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(8, 464);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 24);
            this.button3.TabIndex = 36;
            this.button3.Text = "Send E-Mail";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Task Hierarchy:";
            // 
            // txtHierarchy
            // 
            this.txtHierarchy.BackColor = System.Drawing.Color.White;
            this.txtHierarchy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHierarchy.Location = new System.Drawing.Point(8, 256);
            this.txtHierarchy.Multiline = true;
            this.txtHierarchy.Name = "txtHierarchy";
            this.txtHierarchy.ReadOnly = true;
            this.txtHierarchy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHierarchy.Size = new System.Drawing.Size(408, 40);
            this.txtHierarchy.TabIndex = 39;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(8, 323);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(406, 66);
            this.webBrowser1.TabIndex = 40;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // FormEntTaskInformation
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 495);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtHierarchy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtApprovalNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPctComplete);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblTaskName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEntTaskInformation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEntTaskInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FormEntTaskInformation_Load(object sender, System.EventArgs e)
		{
			System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo( );

			provider.NumberDecimalSeparator = ".";
			provider.NumberGroupSeparator = ",";
			provider.NumberGroupSizes = new int[ ] { 3 };

			this.lblFinish.Text = taskItem.finishDate;
			
			object empty = System.Reflection.Missing.Value;
			string body = "<body leftmargin=\"0\" rightmargin=\"0\" topmargin=\"0\" bottommargin=\"0\" target=\"_blank\" style=\"font-family:MS Sans Serif;font-size:10px\">";
			webBrowser1.Navigate("about:blank");
            //HtmlDocument doc = webBrowser1.DocumentText = body;
			
			//this.textBox1.Text = task.notes;

            
			body += taskItem.notes.Replace("\r\n","<br>").Replace("<a href=","<a target=\"_blank\" href=") + "</body>";
			
            webBrowser1.DocumentText = body;

			if(taskItem.percentComplete != "")
				this.lblPctComplete.Text = taskItem.percentComplete + "%";
			else
				this.lblPctComplete.Text = "0%";

			this.lblStart.Text = taskItem.startDate;
			this.lblTaskName.Text =  taskItem.taskname;
			try
			{
				this.txtHierarchy.Text = taskItem.taskHierarchy;
			}
			catch{}

			foreach(EPMLivePublisher.UpdateFieldItem fi in taskItem.updatefields)
			{
				if(fi.value != null)
				{
					ListViewItem li = listView1.Items.Add(fi.displayName);
					string val = "";
					if(taskItem.task != null)
					{
                        if (fi.fieldId == 188743715)
                        {
                            val = taskItem.task.Start.ToString();
                        }
                        else if (fi.fieldId == 188743716)
                        {
                            val = taskItem.task.Finish.ToString();
                        }
                        else if (fi.fieldId != 0)
                        {
                            val = taskItem.task.GetField((Microsoft.Office.Interop.MSProject.PjField)fi.fieldId);
                        }
                        else
                            val = fi.fieldId.ToString() + ":" + fi.internalFieldName;
					}

					string fieldName = ((Microsoft.Office.Interop.MSProject.PjField)fi.fieldId).ToString();
					string sFieldVal = fi.value;
					if(fieldName.IndexOf("pjTask")==0)
					{
						fieldName = fieldName.Replace("pjTask","");
						if(Connect.hTaskCenterFields.Contains(fieldName.ToUpper()))
						{
							Connect.TaskField tf = (Connect.TaskField)Connect.hTaskCenterFields[fieldName.ToUpper()];

							if(tf.type == 2)
							{
								if(tf.outerXml.IndexOf("Percentage=\"TRUE\"") > 0)
								{
									try
									{
										sFieldVal = (float.Parse(sFieldVal)).ToString() + "%";
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
					}
					
					li.SubItems.Add(val);
					li.SubItems.Add(sFieldVal);

					if(val != sFieldVal)
					{
						li.BackColor = System.Drawing.Color.Yellow;
					}
				}
			}

			/*string res = "";
			string[] ress = task.resource.Replace(";#","\n").Split('\n');

			if(ress.Length > 1)
				for(int i=1;i<ress.Length;i=i+2)
					res = res + "; " + ress[i];

			if(res.Length > 2)
				res = res.Substring(2);

			for(int i=0;i<ress.Length;i=i+2)
			{
				for(int j = 0;j<CheckResources.resCount;j++)
				{
					if(ress[i].Trim() != "")
					{
						if(CheckResources.resList[j].resId == Convert.ToInt32(ress[i]))
						{
							if(CheckResources.resList[j].email != "")
								myHash.Add(CheckResources.resList[j].email," ");
						}
					}
				}
			}*/

			/*foreach(DictionaryEntry entry in task.customFields)
			{
				int iField = 0;
				try
				{
					iField = Convert.ToInt32(entry.Key.ToString());
				}
				catch{}
				string sFieldVal =  entry.Value.ToString();
				try
				{
					sFieldVal = Convert.ToString(Convert.ToDouble(sFieldVal));
				}
				catch{}

				string fieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString();
				listView1.Items.Add(fieldName.Replace("pjTask","")).SubItems.Add(sFieldVal);
			}*/
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
			
			/*FormStatus frmStatus = new FormStatus();
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
			}*/
			
		}

        private void txtApprovalNotes_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
