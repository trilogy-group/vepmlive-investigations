using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormPublishType.
	/// </summary>
	public class FormEntPublishType : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton rdoAssignment;
		private System.Windows.Forms.RadioButton rdoTask;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private Microsoft.Office.Interop.MSProject.Application app;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rdoTaskNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEntPublishType(Microsoft.Office.Interop.MSProject.Application app)
		{
			this.app = app;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntPublishType));
            this.rdoAssignment = new System.Windows.Forms.RadioButton();
            this.rdoTask = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoTaskNo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoAssignment
            // 
            this.rdoAssignment.Checked = true;
            this.rdoAssignment.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoAssignment.Location = new System.Drawing.Point(8, 4);
            this.rdoAssignment.Name = "rdoAssignment";
            this.rdoAssignment.Size = new System.Drawing.Size(152, 24);
            this.rdoAssignment.TabIndex = 0;
            this.rdoAssignment.TabStop = true;
            this.rdoAssignment.Text = "Assignment Based";
            // 
            // rdoTask
            // 
            this.rdoTask.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTask.Location = new System.Drawing.Point(8, 64);
            this.rdoTask.Name = "rdoTask";
            this.rdoTask.Size = new System.Drawing.Size(248, 24);
            this.rdoTask.TabIndex = 1;
            this.rdoTask.Text = "Task Based w/ Assignments";
            this.rdoTask.CheckedChanged += new System.EventHandler(this.rdoTask_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(256, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 13;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(184, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 49);
            this.label1.TabIndex = 14;
            this.label1.Text = "By choosing Task Based publishing, you are creating one SharePoint task for every" +
                " Microsoft Project task and assigning one or more resources to that task.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 40);
            this.label2.TabIndex = 15;
            this.label2.Text = "By choosing Assignment Based publishing, you are creating one SharePoint task for" +
                " each resource that is assigned to a task in Microsoft Project.  ";
            // 
            // rdoTaskNo
            // 
            this.rdoTaskNo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTaskNo.Location = new System.Drawing.Point(8, 134);
            this.rdoTaskNo.Name = "rdoTaskNo";
            this.rdoTaskNo.Size = new System.Drawing.Size(248, 24);
            this.rdoTaskNo.TabIndex = 17;
            this.rdoTaskNo.Text = "Task Based w/o Assignments";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 72);
            this.label3.TabIndex = 18;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // FormEntPublishType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 263);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoTaskNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rdoTask);
            this.Controls.Add(this.rdoAssignment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEntPublishType";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publishing Type";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEntPublishType_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(this.rdoAssignment.Checked)
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"1");
			else if(this.rdoTask.Checked)
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"2");
			else if(this.rdoTaskNo.Checked)
				Connect.setProperty("EPMLiveEntPubType",app.ActiveProject,"3");
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{

		}

		private void rdoTask_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void FormEntPublishType_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
