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
	public class FormCustomFields : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button4;

		private Hashtable hAddFields = new Hashtable();
		private Hashtable hDeleteFields = new Hashtable();
		private Hashtable hUpdateFields = new Hashtable();

		private Hashtable hAddFieldsP = new Hashtable();
		private Hashtable hDeleteFieldsP = new Hashtable();
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
		private Hashtable hUpdateFieldsP = new Hashtable();
        private Microsoft.Office.Interop.MSProject.Project pj;

		public FormCustomFields(Microsoft.Office.Interop.MSProject.Project _pj)
		{
            pj = _pj;
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
            this.button3.Location = new System.Drawing.Point(339, 361);
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
            this.button4.Location = new System.Drawing.Point(419, 361);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(79, 18);
            this.tabControl1.Location = new System.Drawing.Point(6, 9);
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
            // FormCustomFields
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 391);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCustomFields";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Field Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCustomFields_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormCustomFields_Load(object sender, System.EventArgs e)
		{
			loadTaskCenter();
			loadProjectCenter();
		}

		private void loadProjectCenter()
		{
			listBox3.Items.Clear();
			listBox4.Items.Clear();

			Hashtable hFields = new Hashtable();

			if(Connect.hProjectCenterFields != null)
			{
				foreach(DictionaryEntry entry in Connect.hProjectCenterFields)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					listBox4.Items.Add(tField);
					hFields.Add(tField.fieldName.ToUpper(),"");
					hUpdateFieldsP.Add(tField.fieldName.ToUpper().Trim(),tField);
				}
			}
			foreach(DictionaryEntry entry in Connect.hPprojectFields)
			{
				Connect.TaskField tField = (Connect.TaskField)entry.Value;
				if(!hFields.Contains(tField.fieldName.ToUpper()) && !tField.builtin )
				{
					listBox3.Items.Add(tField);
				}
			}
		}

		/*private bool invalidField(string name)
		{
			return false;
			switch(name)
			{
				case "BASELINEDURATION":
				case "BASELINESTART":
				case "BASELINEFINISH":
				case "BASELINECOST":
				case "BASELINEWORK":
				case "REMAININGWORK":
				case "REMAININGCOST":
				case "REMAININGDURATION":
				case "FIXEDCOST":
				case "PHYSICALPERCENTCOMPLETE":
				case "WORKVARIANCE":
				case "COSTVARIANCE":
					return true;
			}
			return false;
		}*/

		private void loadTaskCenter()
		{
			listBox1.Items.Clear();
			listBox2.Items.Clear();

			Hashtable hFields = new Hashtable();

			if(Connect.hTaskCenterFields != null)
			{
				foreach(DictionaryEntry entry in Connect.hTaskCenterFields)
				{   
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
                    if(tField.wssFieldName != "IsPublished")
                    {
                        listBox2.Items.Add(tField);
                        hFields.Add(tField.fieldName.ToUpper(), "");
                        hUpdateFields.Add(tField.fieldName.ToUpper().Trim(), tField);
                    }
				}
			}
			foreach(DictionaryEntry entry in Connect.hPprojectFields)
			{
				Connect.TaskField tField = (Connect.TaskField)entry.Value;
				if(!hFields.Contains(tField.fieldName.ToUpper()) && !tField.builtin)
				{
//					switch(tField.fieldName.ToUpper())
//					{
//						case "ACTUALWORK":
//							break;
//						default:
							listBox1.Items.Add(tField);
					//		break;
					//}
				}
			}
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}
		//Add Field
		private void button1_Click(object sender, System.EventArgs e)
		{
			Connect.TaskField fld = (Connect.TaskField)listBox1.SelectedItem;
			
			try
			{
				if(!hUpdateFields.Contains(fld.fieldName.ToUpper()))
				{
					hAddFields.Add(fld.fieldName.ToUpper(),fld);
				}
				listBox2.Items.Add(fld);
				listBox1.Items.Remove(listBox1.SelectedItem);
			}
			catch{}
			try
			{
				hDeleteFields.Remove(fld.fieldName.ToUpper());
			}
			catch{}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            if(MessageBox.Show("Are you sure you want to remove this field from your " + Connect.getProperty("EPMLiveTCList", pj) + " list? This will remove all data for that column.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Connect.TaskField tField = (Connect.TaskField)listBox2.SelectedItem;
				try
				{
					hAddFields.Remove(tField.fieldName.ToUpper());
				}
				catch{}
				try
				{
					tField.displayName = "";
					hDeleteFields.Add(tField.fieldName.ToUpper(),listBox2.SelectedItem);
				}
				catch{}
				listBox1.Items.Add(tField);
				listBox2.Items.Remove(listBox2.SelectedItem);
				checkBox1.Enabled = false;
				checkBox1.Checked = false;
			}
		}

		private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(listBox2.SelectedItem != null)
			{
				checkBox1.Enabled = true;
				if(isEditableSwitch())
				{
					checkBox1.Enabled = true;
				}
				else
				{
					checkBox1.Enabled = false;
					checkBox1.Checked = false;
				}

				Connect.TaskField fld = (Connect.TaskField)listBox2.SelectedItem;
				if(fld.editable)
					checkBox1.Checked = true;
				else
					checkBox1.Checked = false;

				if(!fld.builtin)
					button2.Enabled = true;
				else
					button2.Enabled = false;
			}
			else
			{
				checkBox1.Enabled = false;
				checkBox1.Checked = false;
				button2.Enabled = false;
			}
		}

		private bool isEditableSwitch()
		{
			Connect.TaskField tField = (Connect.TaskField)listBox2.SelectedItem;
			if(tField.fieldName.Length > 4)
			{
				if(tField.fieldName.Substring(0,4).ToUpper() == "COST" && tField.fieldName.ToUpper() != "COSTVARIANCE")
					return true;

				if(tField.fieldName.Substring(0,4).ToUpper() == "DATE")
					return true;

				if(tField.fieldName.Substring(0,4).ToUpper() == "FLAG")
					return true;

				if(tField.fieldName.Substring(0,4).ToUpper() == "TEXT")
					return true;
			}
			if(tField.fieldName.Length > 5)
			{
				if(tField.fieldName.Substring(0,5).ToUpper() == "START" && tField.fieldName.ToUpper() != "STARTSLACK" && tField.fieldName.ToUpper() != "STARTVARIANCE")
					return true;
			}
			if(tField.fieldName.Length > 6)
			{
				if(tField.fieldName.Substring(0,6).ToUpper() == "NUMBER")
					return true;

				if(tField.fieldName.Substring(0,6).ToUpper() == "FINISH" && tField.fieldName.ToUpper() != "FINISHSLACK" && tField.fieldName.ToUpper() != "FINISHVARIANCE")
					return true;
			}
			if(tField.fieldName.Length > 8)
			{
				if(tField.fieldName.Substring(0,8).ToUpper() == "DURATION" && tField.fieldName.ToUpper() != "DURATIONVARIANCE")
					return true;
			}

			if(tField.fieldName.ToUpper() == "PHYSICAL_X0020__X0025__X0020_COM" || tField.fieldName.ToUpper() == "PERCENTCOMPLETE" || tField.fieldName.ToUpper() == "PHYSICALPERCENTCOMPLETE" || tField.fieldName.ToUpper() == "ACTUAL_X0020_WORK" || tField.fieldName.ToUpper() == "REMAININGWORK" || tField.fieldName.ToUpper() == "CRITICAL" || tField.fieldName.ToUpper() == "MILESTONE" || tField.fieldName.ToUpper() == "PRIORITY" || tField.fieldName.ToUpper() == "ACTUAL_X0020_START"  || tField.fieldName.ToUpper() == "ACTUAL_X0020_FINISH" || tField.fieldName.ToUpper() == "DUEDATE" || tField.fieldName.ToUpper() == "ASSIGNEDTO" || tField.fieldName.ToUpper() == "STATUS" || tField.fieldName.ToUpper() == "TITLE")
				return true;

			switch(tField.fieldName.ToUpper())
			{
				case "START":
				case "FINISH":
				case "ACTUALSTART":
				case "ACTUALFINISH":
				case "COST":
				case "ACTUALCOST":
				case "WORK":
				case "ACTUALWORK":
				case "REMAININGCOST":
				case "REMAININGWORK":
				case "NOTES":
					return true;
			};

			return false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			bool pct = false;
			bool work = false;

			foreach(Object li in listBox2.Items)
			{
				Connect.TaskField tf = (Connect.TaskField)li;
				if(tf.fieldName == "PercentComplete")
					pct = tf.editable;
				if((tf.fieldName == "Actual_x0020_Work" || tf.fieldName == "RemainingWork") && !work && tf.type != 9)
					work = tf.editable;
			}
			if(pct && work)
			{
				this.DialogResult = DialogResult.None;
				MessageBox.Show("You cannot make both % Complete and Actual Work or Remaining Work editable at the same time.");
				return;
			}
			this.DialogResult = DialogResult.OK ;

			FormStatus frmStatus = new FormStatus();
            frmStatus.label1.Text = "Saving " + Connect.getProperty("EPMLiveTCList", pj) + " List...";
			frmStatus.progressBar1.Maximum = 2;
			frmStatus.Show();
			frmStatus.Refresh();

            SPSLists.Lists spList = Connection.GetListService(Connection.url);
			
			XmlNode ndList = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));
			XmlNode ndVersion = ndList.Attributes["Version"];
			string listName = ndList.Attributes["ID"].Value;

			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
			XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

			int methodId = 1;
			string uFields = "";
			string aFields = "";
			string dFields = "";

			Hashtable hTemp = new Hashtable();
		///===================TASK FIELDS====================================
			foreach(DictionaryEntry entry in hAddFields)
			{
				if(hUpdateFields.Contains(entry.Key.ToString().ToUpper().Trim()))
				{
					hTemp.Add(entry.Key.ToString().ToUpper(),"");
				}
			}

			foreach(DictionaryEntry entry in hTemp)
			{
				hAddFields.Remove(entry.Key);
			}

			if(hUpdateFields.Count > 0)
			{
				foreach(DictionaryEntry entry in hUpdateFields)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					if(tField.displayName == "")
						tField.displayName = tField.fieldName;

					if(tField.type == 6)
					{
						uFields = uFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "' DisplayName='" + tField.displayName + "' Type='UserMulti' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "' List='UserInfo' Mult='TRUE'></Field></Method>";
					}
					else if(tField.type == 7)
					{
						uFields = uFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "' DisplayName='" + tField.displayName + "' Type='Choice' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "'>" + tField.innerXml + "</Field></Method>";
					}
					else
					{
						if(tField.fieldName.ToUpper() == "TITLE" || tField.fieldName.ToUpper() == "STARTDATE" || tField.fieldName.ToUpper() == "DUEDATE")
						{
							uFields = uFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "' DisplayName='" + tField.displayName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='TRUE' Required='" + tField.required + "' Format='" + tField.format + "'></Field></Method>";
						}
						else if(tField.fieldName.ToUpper() == "PERCENTCOMPLETE" || tField.fieldName.ToUpper() == "PHYSICAL_X0020__X0025__X0020_COM")
						{
							uFields = uFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "' DisplayName='" + tField.displayName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "' Percentage='TRUE'></Field></Method>";
						}
						else
						{
							uFields = uFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "' DisplayName='" + tField.displayName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "'";
							if(tField.required != "")
							{
								uFields = uFields + " Required='" + tField.required + "'";
							}
							if(tField.format != "")
							{
								uFields = uFields + " Format='" + tField.format + "'";
							}
							uFields = uFields + "></Field></Method>";
						}
					}
					methodId++;
				}
				ndUpdateFields.InnerXml = uFields;
				
			}
			else
				ndUpdateFields = null;

			if(hAddFields.Count > 0)
			{
				foreach(DictionaryEntry entry in hAddFields)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					if(tField.fieldName.ToUpper() == "PHYSICALPERCENTCOMPLETE")
					{
						aFields = aFields + "<Method ID='" + methodId.ToString() + "'><Field Name='PhysicalPercentComplete' DisplayName='PhysicalPercentComplete' Type='Number' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "' Percentage='TRUE'></Field></Method>";
					}
					else if(tField.fieldName.ToUpper() == "PERCENTCOMPLETE")
					{
						aFields = aFields + "<Method ID='" + methodId.ToString() + "'><Field Name='PercentComplete' DisplayName='PercentComplete' Type='Number' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "' Percentage='TRUE'></Field></Method>";
					}
					else
					{
						aFields = aFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.fieldName + "' DisplayName='" + tField.fieldName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "'></Field></Method>";
					}
					methodId++;
				}
				ndNewFields.InnerXml = aFields;
			}
			else
				ndNewFields = null;

			if(hDeleteFields.Count > 0)
			{
				foreach(DictionaryEntry entry in hDeleteFields)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					if(tField.wssFieldName == null || tField.wssFieldName == "")
						dFields = dFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.fieldName + "'></Field></Method>";
					else
						dFields = dFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "'></Field></Method>";
					methodId++;
				}
				ndDeleteFields.InnerXml = dFields;
			}
			else
				ndDeleteFields = null;

			try
			{
				XmlNode ndReturn = spList.UpdateList(listName, ndProperties, ndNewFields, ndUpdateFields, ndDeleteFields, ndVersion.Value);
			}
			catch (Exception ex)
			{
                MessageBox.Show("Error Saving " + Connect.getProperty("EPMLiveTCList", pj) + " Fields\r\nMessage:\n" + ex.Message);
			}

		///===================PROJECT CENTER FIELDS====================================

			ndList = spList.GetList(Connect.getProperty("EPMLivePCList", pj));
			ndVersion = ndList.Attributes["Version"];
			listName = ndList.Attributes["ID"].Value;

			frmStatus.progressBar1.Value = 1;

			hTemp = new Hashtable();
			ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
			ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

			methodId = 1;
			uFields = "";
			aFields = "";
			dFields = "";

			foreach(DictionaryEntry entry in hAddFieldsP)
			{
				if(hUpdateFieldsP.Contains(entry.Key.ToString().ToUpper().Trim()))
				{
					hTemp.Add(entry.Key.ToString().ToUpper(),"");
				}
			}

			foreach(DictionaryEntry entry in hTemp)
			{
				hAddFieldsP.Remove(entry.Key);
			}

			if(hAddFieldsP.Count > 0)
			{
				foreach(DictionaryEntry entry in hAddFieldsP)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					if(tField.fieldName.ToUpper() == "PHYSICALPERCENTCOMPLETE")
					{
						aFields = aFields + "<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.fieldName + "' DisplayName='" + tField.displayName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "' Percentage='TRUE'></Field></Method>";
					}
					else
					{
						aFields = aFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.fieldName + "' DisplayName='" + tField.fieldName + "' Type='" + getTypeString(tField.type) + "' ShowInEditForm='" + tField.editable.ToString().ToUpper() + "' ShowInNewForm='" + tField.editable.ToString().ToUpper() + "'></Field></Method>";
					}
					methodId++;
				}
				ndNewFields.InnerXml = aFields;
			}
			else
				ndNewFields = null;

			if(hDeleteFieldsP.Count > 0)
			{
				foreach(DictionaryEntry entry in hDeleteFieldsP)
				{
					Connect.TaskField tField = (Connect.TaskField)entry.Value;
					if(tField.wssFieldName == null || tField.wssFieldName == "")
						dFields = dFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.fieldName + "'></Field></Method>";
					else
						dFields = dFields +	"<Method ID='" + methodId.ToString() + "'><Field Name='" + tField.wssFieldName + "'></Field></Method>";
					methodId++;
				}
				ndDeleteFields.InnerXml = dFields;
			}
			else
				ndDeleteFields = null;

			try
			{
				XmlNode ndReturn = spList.UpdateList(listName, ndProperties, ndNewFields, null, ndDeleteFields, ndVersion.Value);
			}
			catch (Exception ex)
			{
                MessageBox.Show("Error Saving " + Connect.getProperty("EPMLivePCList", pj) + " Fields\r\nMessage:\n" + ex.Message);
			}



			frmStatus.Dispose();

			this.hAddFields = null;
			this.hAddFieldsP = null;
			this.hDeleteFields = null;
			this.hDeleteFieldsP = null;
			this.hUpdateFields = null;
			this.hUpdateFieldsP = null;
		}

		private string getTypeString(int type)
		{
			switch(type)
			{
				case 1:
					return "Text";
				case 2:
					return "Number";
				case 3:
					return "Currency";
				case 4:
					return "DateTime";
				case 5:
					return "Boolean";
			}
			return "Text";
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(listBox2.SelectedItem != null)
			{
				Connect.TaskField tField = (Connect.TaskField)listBox2.SelectedItem;
				tField.editable = checkBox1.Checked;
				listBox2.SelectedItem = tField;
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Connect.TaskField fld = (Connect.TaskField)listBox3.SelectedItem;
			try
			{
				hAddFieldsP.Add(fld.fieldName.ToUpper(),fld);
				listBox4.Items.Add(fld);
				listBox3.Items.Remove(listBox3.SelectedItem);
			}
			catch{}
			try
			{
				hDeleteFieldsP.Remove(fld.fieldName.ToUpper());
			}
			catch{}
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			if(listBox4.SelectedIndex >= 0)
			{
                if(MessageBox.Show("Are you sure you want to remove this field from your " + Connect.getProperty("EPMLivePCList", pj) + " list? This will remove all data for that column.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Connect.TaskField tField = (Connect.TaskField)listBox4.SelectedItem;
					try
					{
						hAddFieldsP.Remove(tField.fieldName.ToUpper());
					}
					catch{}
					try
					{
						tField.displayName = "";
						hDeleteFieldsP.Add(tField.fieldName.ToUpper(),listBox4.SelectedItem);
					}
					catch{}
					listBox3.Items.Add(tField);
					listBox4.Items.Remove(listBox4.SelectedItem);
				}
			}
		}

		private void listBox4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
