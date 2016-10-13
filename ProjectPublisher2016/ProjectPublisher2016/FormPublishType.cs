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
	public class FormPublishType : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton rdoAssignment;
		private System.Windows.Forms.RadioButton rdoTask;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private Microsoft.Office.Interop.MSProject.Application app;
		private System.Windows.Forms.CheckBox chkSummary;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormPublishType(Microsoft.Office.Interop.MSProject.Application app)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPublishType));
            this.rdoAssignment = new System.Windows.Forms.RadioButton();
            this.rdoTask = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rdoAssignment
            // 
            this.rdoAssignment.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoAssignment.Location = new System.Drawing.Point(4, 6);
            this.rdoAssignment.Name = "rdoAssignment";
            this.rdoAssignment.Size = new System.Drawing.Size(152, 24);
            this.rdoAssignment.TabIndex = 0;
            this.rdoAssignment.Text = "Assignment Based";
            // 
            // rdoTask
            // 
            this.rdoTask.Checked = true;
            this.rdoTask.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rdoTask.Location = new System.Drawing.Point(4, 86);
            this.rdoTask.Name = "rdoTask";
            this.rdoTask.Size = new System.Drawing.Size(152, 24);
            this.rdoTask.TabIndex = 1;
            this.rdoTask.TabStop = true;
            this.rdoTask.Text = "Task Based";
            this.rdoTask.CheckedChanged += new System.EventHandler(this.rdoTask_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(212, 182);
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
            this.button2.Location = new System.Drawing.Point(140, 182);
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
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "By choosing Task Based publishing, you are creating one SharePoint task for every" +
                " Microsoft Project task and assigning one or more resources to that task.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 56);
            this.label2.TabIndex = 15;
            this.label2.Text = "By choosing Assignment Based publishing, you are creating one SharePoint task for" +
                " each resource that is assigned to a task in Microsoft Project.  ";
            // 
            // chkSummary
            // 
            this.chkSummary.Checked = true;
            this.chkSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.chkSummary.Location = new System.Drawing.Point(4, 166);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(184, 16);
            this.chkSummary.TabIndex = 19;
            this.chkSummary.Text = "Publish summary tasks";
            // 
            // FormPublishType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(286, 213);
            this.ControlBox = false;
            this.Controls.Add(this.chkSummary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rdoTask);
            this.Controls.Add(this.rdoAssignment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPublishType";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publishing Type";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormPublishType_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			Connect.setProperty("EPMLiveType",app.ActiveProject,rdoAssignment.Checked.ToString());
			Connect.setProperty("EPMLivePubSummary",app.ActiveProject,chkSummary.Checked.ToString());
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{

		}

		private void rdoTask_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void FormPublishType_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
