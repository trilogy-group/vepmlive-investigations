using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace ProjectPublisher2016
{
	

	/// <summary>
	/// Summary description for FormCustomFields.
	/// </summary>
	public class FormEntCustomFields : System.Windows.Forms.Form
	{
		public class CCustomField : EPMLivePublisher.CustomField
		{
			public override string ToString()
			{
				if(base.locked)
					return base.displayName + "*";
				else
					return base.displayName;
			}

		}

		private Hashtable hshDelTaskFields = new Hashtable();
        private Hashtable hshDelProjectFields = new Hashtable();
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button4;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ListBox listBox4;
		private Microsoft.Office.Interop.MSProject.Project pj;

		public FormEntCustomFields(Microsoft.Office.Interop.MSProject.Project project)
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
		}




		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(341, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(421, 358);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(79, 18);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 344);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.listBox4);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listBox3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(480, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project Center";
            // 
            // listBox4
            // 
            this.listBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.listBox4.Location = new System.Drawing.Point(264, 24);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(208, 277);
            this.listBox4.Sorted = true;
            this.listBox4.TabIndex = 14;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(224, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(32, 32);
            this.button6.TabIndex = 13;
            this.button6.Text = "<";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(224, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 32);
            this.button5.TabIndex = 12;
            this.button5.Text = ">";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "SharePoint Fields";
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.listBox3.Location = new System.Drawing.Point(8, 24);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(208, 277);
            this.listBox3.Sorted = true;
            this.listBox3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Additional Project Fields";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(480, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Task Center";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Additional Project Fields";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.listBox1.Location = new System.Drawing.Point(8, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 277);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(224, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(224, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 12;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "SharePoint Fields";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.listBox2.Location = new System.Drawing.Point(264, 24);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(208, 264);
            this.listBox2.Sorted = true;
            this.listBox2.TabIndex = 10;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(264, 296);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(200, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Make Editable Field in SharePoint";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormEntCustomFields
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(506, 391);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEntCustomFields";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Field Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEntCustomFields_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormEntCustomFields_Load(object sender, System.EventArgs e)
		{
			FormStatus frmStatus = new FormStatus();
			try
			{

                EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(Connection.url);
				
				frmStatus.label1.Text = "Downloading Fields...";
				frmStatus.Show();
				frmStatus.Refresh();

				EPMLivePublisher.CustomField[] cfs = new EPMLivePublisher.CustomField[0];
				try
				{
					cfs = pub.getTaskCustomFields2(pj.Application.Profiles.ActiveProfile.Server);
				}
				catch
				{
					cfs = pub.getTaskCustomFields();
				}

				foreach(EPMLivePublisher.CustomField cf in cfs)
				{
					CCustomField c = new CCustomField();
					c.displayName = cf.displayName;
					c.editable = cf.editable;
					c.fieldCategory = cf.fieldCategory;
					c.fieldType = cf.fieldType;
					c.locked = cf.locked;
					c.visible = cf.visible;
					c.wssFieldName = cf.wssFieldName;

					if(cf.visible)
						listBox2.Items.Add(c);
					else
						listBox1.Items.Add(c);

				}

				EPMLivePublisher.CustomField[] pcfs = new EPMLivePublisher.CustomField[0];
				try
				{
					pcfs = pub.getProjectCustomFields2(pj.Application.Profiles.ActiveProfile.Server);
				}
				catch
				{
					pcfs = pub.getProjectCustomFields();
				}

				foreach(EPMLivePublisher.CustomField cf in pcfs)
				{
					CCustomField c = new CCustomField();
					c.displayName = cf.displayName;
					c.editable = cf.editable;
					c.fieldCategory = cf.fieldCategory;
					c.fieldType = cf.fieldType;
					c.locked = cf.locked;
					c.visible = cf.visible;
					c.wssFieldName = cf.wssFieldName;

					if(cf.visible)
						listBox4.Items.Add(c);
					else
						listBox3.Items.Add(c);

				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error loading custom fields: " + ex.Message);
			}
			frmStatus.Dispose();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			if(listBox3.SelectedIndex >= 0)
			{
				listBox4.Items.Add(listBox3.SelectedItem);
				if(hshDelProjectFields.Contains(((CCustomField)listBox3.SelectedItem).wssFieldName))
				{
					hshDelProjectFields.Remove(((CCustomField)listBox3.SelectedItem).wssFieldName);
				}
				listBox3.Items.Remove(listBox3.SelectedItem);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(listBox1.SelectedIndex >= 0)
			{
				listBox2.Items.Add(listBox1.SelectedItem);
				if(hshDelTaskFields.Contains(((CCustomField)listBox1.SelectedItem).wssFieldName))
				{
					hshDelTaskFields.Remove(((CCustomField)listBox1.SelectedItem).wssFieldName);
				}
				listBox1.Items.Remove(listBox1.SelectedItem);
			}
		}

		private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(listBox2.SelectedIndex >= 0)
			{
				if(((CCustomField)listBox2.SelectedItem).locked)
				{
					checkBox1.Checked = ((CCustomField)listBox2.SelectedItem).editable;
					checkBox1.Enabled = false;
					button2.Enabled = false;
				}
				else
				{
					checkBox1.Enabled = true;
					button2.Enabled = true;
					checkBox1.Checked = ((CCustomField)listBox2.SelectedItem).editable;
				}
			}
			else
			{
				checkBox1.Enabled = false;
				button2.Enabled = false;
			}
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			((CCustomField)listBox2.SelectedItem).editable = checkBox1.Checked;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(listBox2.SelectedIndex >= 0)
			{
				listBox1.Items.Add(listBox2.SelectedItem);
				hshDelTaskFields.Add(((CCustomField)listBox2.SelectedItem).wssFieldName,"");
				listBox2.Items.Remove(listBox2.SelectedItem);
				
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			FormStatus frmStatus = new FormStatus();
            frmStatus.label1.Text = "Saving " + Connect.getProperty("EPMLiveTCList", pj) + " Fields...";
			frmStatus.Show();
			frmStatus.Refresh();

			try
			{
                EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(Connection.url);

				int counter = 0;

				foreach(CCustomField cf in listBox2.Items)
				{
					if(!cf.locked)
						counter++;
				}

				EPMLivePublisher.CustomField []cfs = new EPMLivePublisher.CustomField[counter];

				counter=0;
				foreach(CCustomField cf in listBox2.Items)
				{
					if(!cf.locked)
					{
						EPMLivePublisher.CustomField c = new EPMLivePublisher.CustomField();
						c.displayName = cf.displayName;
						c.editable = cf.editable;
						c.fieldCategory = cf.fieldCategory;
						c.fieldType = cf.fieldType;
						c.locked = cf.locked;
						c.visible = cf.visible;
						c.wssFieldName = cf.wssFieldName;

						cfs[counter++] = c;
					}
				}

				string []dFields = new string[hshDelTaskFields.Count];
				counter = 0;
				foreach(DictionaryEntry entry in hshDelTaskFields)
				{
					dFields[counter++] = entry.Key.ToString();
				}

				pub.saveTaskFields(cfs,dFields);

			//====================Project Center Fields=======================
				counter = 0;
				foreach(CCustomField cf in listBox4.Items)
				{
					if(!cf.locked)
						counter++;
				}

				cfs = new EPMLivePublisher.CustomField[counter];

				counter=0;
				foreach(CCustomField cf in listBox4.Items)
				{
					if(!cf.locked)
					{
						EPMLivePublisher.CustomField c = new EPMLivePublisher.CustomField();
						c.displayName = cf.displayName;
						c.editable = cf.editable;
						c.fieldCategory = cf.fieldCategory;
						c.fieldType = cf.fieldType;
						c.locked = cf.locked;
						c.visible = cf.visible;
						c.wssFieldName = cf.wssFieldName;

						cfs[counter++] = c;
					}
				}

				dFields = new string[hshDelProjectFields.Count];
				counter = 0;
				foreach(DictionaryEntry entry in hshDelProjectFields)
				{
					dFields[counter++] = entry.Key.ToString();
				}

				pub.saveProjectFields(cfs,dFields);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error saving fields: " + ex.Message);
			}


			frmStatus.Dispose();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			if(listBox4.SelectedIndex >= 0)
			{
				listBox3.Items.Add(listBox4.SelectedItem);
				hshDelProjectFields.Add(((CCustomField)listBox4.SelectedItem).wssFieldName,"");
				listBox4.Items.Remove(listBox4.SelectedItem);
				
			}
		}

		private void listBox4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(listBox4.SelectedIndex >= 0)
			{
				if(((CCustomField)listBox4.SelectedItem).locked)
				{
					button6.Enabled = false;
				}
				else
				{
					button6.Enabled = true;
				}
			}
			else
			{
				button6.Enabled = false;
			}
		}

		
	}
}
