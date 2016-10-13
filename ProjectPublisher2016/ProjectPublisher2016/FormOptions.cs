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
	public class FormOptions : System.Windows.Forms.Form
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

		private int oldindex = 0;
		private System.Windows.Forms.RadioButton rdoTask;
		private System.Windows.Forms.RadioButton rdoAssignment;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkSynch;
		private System.Windows.Forms.CheckBox chkSummary;
		private System.Windows.Forms.CheckBox chkHideProjInfo;
		private System.Windows.Forms.CheckBox chkHideRes;
		private System.Windows.Forms.CheckBox chkUpdates;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboResourceField;
		private System.Windows.Forms.CheckBox chkTimePhased;
		private bool formLoading = true;

//		private Connect.TaskField []taskFields;

		public FormOptions()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.rdoTask = new System.Windows.Forms.RadioButton();
            this.rdoAssignment = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTimePhased = new System.Windows.Forms.CheckBox();
            this.chkSynch = new System.Windows.Forms.CheckBox();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.chkHideProjInfo = new System.Windows.Forms.CheckBox();
            this.chkHideRes = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboResourceField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(250, 232);
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
            this.button2.Location = new System.Drawing.Point(328, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Please enter the URL to the SharePoint workspace that you want to associate with " +
                "this project:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(8, 40);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(392, 20);
            this.txtURL.TabIndex = 14;
            // 
            // rdoTask
            // 
            this.rdoTask.BackColor = System.Drawing.Color.White;
            this.rdoTask.Checked = true;
            this.rdoTask.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTask.Location = new System.Drawing.Point(8, 40);
            this.rdoTask.Name = "rdoTask";
            this.rdoTask.Size = new System.Drawing.Size(152, 24);
            this.rdoTask.TabIndex = 3;
            this.rdoTask.TabStop = true;
            this.rdoTask.Text = "Task Based";
            this.rdoTask.UseVisualStyleBackColor = false;
            // 
            // rdoAssignment
            // 
            this.rdoAssignment.BackColor = System.Drawing.Color.White;
            this.rdoAssignment.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoAssignment.Location = new System.Drawing.Point(8, 16);
            this.rdoAssignment.Name = "rdoAssignment";
            this.rdoAssignment.Size = new System.Drawing.Size(152, 24);
            this.rdoAssignment.TabIndex = 2;
            this.rdoAssignment.Text = "Assignment Based";
            this.rdoAssignment.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rdoTask);
            this.groupBox1.Controls.Add(this.rdoAssignment);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Publish Type";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.chkTimePhased);
            this.groupBox2.Controls.Add(this.chkSynch);
            this.groupBox2.Controls.Add(this.chkSummary);
            this.groupBox2.Controls.Add(this.chkHideProjInfo);
            this.groupBox2.Controls.Add(this.chkHideRes);
            this.groupBox2.Controls.Add(this.chkUpdates);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(184, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 145);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Publish Options";
            // 
            // chkTimePhased
            // 
            this.chkTimePhased.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkTimePhased.Location = new System.Drawing.Point(79, 62);
            this.chkTimePhased.Name = "chkTimePhased";
            this.chkTimePhased.Size = new System.Drawing.Size(184, 16);
            this.chkTimePhased.TabIndex = 29;
            this.chkTimePhased.Text = "Publish time phased data";
            this.chkTimePhased.Visible = false;
            // 
            // chkSynch
            // 
            this.chkSynch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkSynch.Location = new System.Drawing.Point(8, 121);
            this.chkSynch.Name = "chkSynch";
            this.chkSynch.Size = new System.Drawing.Size(184, 16);
            this.chkSynch.TabIndex = 28;
            this.chkSynch.Text = "Synchronize fields on open";
            // 
            // chkSummary
            // 
            this.chkSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkSummary.Location = new System.Drawing.Point(8, 72);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(184, 16);
            this.chkSummary.TabIndex = 26;
            this.chkSummary.Text = "Publish summary tasks";
            // 
            // chkHideProjInfo
            // 
            this.chkHideProjInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkHideProjInfo.Location = new System.Drawing.Point(8, 24);
            this.chkHideProjInfo.Name = "chkHideProjInfo";
            this.chkHideProjInfo.Size = new System.Drawing.Size(200, 16);
            this.chkHideProjInfo.TabIndex = 25;
            this.chkHideProjInfo.Text = "Hide project information on publish";
            // 
            // chkHideRes
            // 
            this.chkHideRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkHideRes.Location = new System.Drawing.Point(8, 40);
            this.chkHideRes.Name = "chkHideRes";
            this.chkHideRes.Size = new System.Drawing.Size(176, 16);
            this.chkHideRes.TabIndex = 24;
            this.chkHideRes.Text = "Hide resource map on publish";
            // 
            // chkUpdates
            // 
            this.chkUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkUpdates.Location = new System.Drawing.Point(8, 99);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(184, 16);
            this.chkUpdates.TabIndex = 23;
            this.chkUpdates.Text = "Check for task updates on open";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.cboResourceField);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 112);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Field Settings";
            // 
            // cboResourceField
            // 
            this.cboResourceField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResourceField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResourceField.Items.AddRange(new object[] {
            "Number1",
            "Number2",
            "Number3",
            "Number4",
            "Number5",
            "Number6",
            "Number7",
            "Number8",
            "Number9",
            "Number10",
            "Number11",
            "Number12",
            "Number13",
            "Number14",
            "Number15",
            "Number16",
            "Number17",
            "Number18",
            "Number19",
            "Number20"});
            this.cboResourceField.Location = new System.Drawing.Point(8, 80);
            this.cboResourceField.Name = "cboResourceField";
            this.cboResourceField.Size = new System.Drawing.Size(152, 21);
            this.cboResourceField.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Resource Link Field";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.Items.AddRange(new object[] {
            "Text1",
            "Text2",
            "Text3",
            "Text4",
            "Text5",
            "Text6",
            "Text7",
            "Text8",
            "Text9",
            "Text10",
            "Text11",
            "Text12",
            "Text13",
            "Text14",
            "Text15",
            "Text16",
            "Text17",
            "Text18",
            "Text19",
            "Text20",
            "Text21",
            "Text22",
            "Text23",
            "Text24",
            "Text25",
            "Text26",
            "Text27",
            "Text28",
            "Text29",
            "Text30"});
            this.comboBox1.Location = new System.Drawing.Point(8, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Publish Status Field";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 264);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			if(txtURL.Text.Length > 5 || txtURL.Text == "")
			{
				if(txtURL.Text.IndexOf("http://") >= 0 || txtURL.Text.IndexOf("https://") >= 0 || txtURL.Text == "")
				{
					Connect.setProperty("EPMLiveType",app.ActiveProject,rdoAssignment.Checked.ToString());
					Connect.setProperty("EPMLiveURL",app.ActiveProject,txtURL.Text);
					Connect.setProperty("EPMLiveSU",app.ActiveProject,chkUpdates.Checked.ToString());
					Connect.setProperty("EPMLiveSynchFields",app.ActiveProject,chkSynch.Checked.ToString());
					Connect.setProperty("EPMLiveLMF",app.ActiveProject,comboBox1.Text);
					Connect.setProperty("EPMLiveResField",app.ActiveProject,cboResourceField.Text);
					Connect.setProperty("EPMLiveHideRes",app.ActiveProject,chkHideRes.Checked.ToString());
					Connect.setProperty("EPMLivePubSummary",app.ActiveProject,chkSummary.Checked.ToString());
					Connect.setProperty("EPMLiveHideProjInfo",app.ActiveProject,chkHideProjInfo.Checked.ToString());
					Connect.setProperty("EPMLiveTimePhased",app.ActiveProject,chkTimePhased.Checked.ToString());
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
		}

		/*private void addField(Microsoft.Office.Interop.MSProject.PjField field)
		{
			string fieldName = field.ToString();

			if(validField(fieldName))
			{
				Connect.TaskField fld = new Addin.Connect.TaskField();
				fld.fieldId = (int)field;
				fld.fieldName = fieldName;
				listBox1.Items.Add(fld);
				try
				{
					listBox2.Items.Add(app.ActiveProject.Tasks[1].GetField(field).ToString());
				}
				catch{}
			}
		}*/

		private void FormOptions_Load(object sender, System.EventArgs e)
		{
			/*foreach(Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
			{
				addField(val);
			}*/

			
			try
			{
				txtURL.Text = Connect.getProperty("EPMLiveURL",app.ActiveProject);

				if(Connect.getProperty("EPMLiveType",app.ActiveProject) == "True")
					rdoAssignment.Checked = true;
				else
					rdoTask.Checked = true;

				if(Connect.getProperty("EPMLiveSU",app.ActiveProject) == "True")
					chkUpdates.Checked = true;
				if(Connect.getProperty("EPMLiveHideRes",app.ActiveProject) == "True")
					chkHideRes.Checked = true;
				if(Connect.getProperty("EPMLiveHideProjInfo",app.ActiveProject) == "True")
					chkHideProjInfo.Checked = true;

				if(Connect.getProperty("EPMLivePubSummary",app.ActiveProject) == "True" || Connect.getProperty("EPMLivePubSummary",app.ActiveProject) == "")
					chkSummary.Checked = true;

				if(Connect.getProperty("EPMLiveSynchFields",app.ActiveProject) == "True")
					chkSynch.Checked = true;
				if(Connect.getProperty("EPMLiveTimePhased",app.ActiveProject) == "True")
					chkTimePhased.Checked = true;

				comboBox1.Text = Connect.getProperty("EPMLiveLMF",app.ActiveProject);
				if(comboBox1.Text == "")
					comboBox1.Text = "Text25";

				oldindex = comboBox1.SelectedIndex;

				cboResourceField.Text = Connect.getProperty("EPMLiveResField",app.ActiveProject);
				if(cboResourceField.Text == "")
					cboResourceField.Text = "Number15";

				string strlocks = Connect.getProperty("EPMLivePubLock",app.ActiveProject);
				string []locks = strlocks.Split(',');
				try
				{
					if(locks[0] == "1")
					{
						rdoAssignment.Enabled = false;
						rdoTask.Enabled = false;
					}
				}
				catch{}
				try
				{
					if(locks[1] == "1")
						chkSummary.Enabled = false;
				}
				catch{}
				try
				{
					if(locks[2] == "1")
						chkTimePhased.Enabled = false;
				}
				catch{}
				try
				{
					if(locks[3] == "1")
						comboBox1.Enabled = false;
				}
				catch{}
				try
				{
					if(locks[4] == "1")
						cboResourceField.Enabled = false;
				}
				catch{}
				try
				{
					if(locks[5] == "1")
						chkSynch.Enabled = false;
				}
				catch{}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Options Error: " + ex.Message);
			}
			formLoading = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!formLoading)
			{
				DialogResult res = MessageBox.Show("Are you sure you want to update this field?  It is strongly recommended that you process all Updates first.  Once all Updates have been processed, change this field and then republish your Project Schedule (Choosing not to Process Updates).","Confirm",MessageBoxButtons.YesNo);
				if(res == DialogResult.No)
				{
					formLoading = true;
					comboBox1.SelectedIndex = oldindex;
					formLoading = false;
				}
				else
					oldindex = comboBox1.SelectedIndex;
			}
		}

		private void chkUpdates_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}