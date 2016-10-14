using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for ApprovalLabel.
	/// </summary>
	public class ApprovalLabel : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.LinkLabel linkLabel1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListViewItem lItem;
		private Microsoft.Office.Interop.MSProject.Project pj;

		public ApprovalLabel(Microsoft.Office.Interop.MSProject.Project iPj)
		{

			this.pj = iPj;
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 16);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ApprovalLabel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.linkLabel1);
            this.Name = "ApprovalLabel";
            this.Size = new System.Drawing.Size(150, 16);
            this.Load += new System.EventHandler(this.ApprovalLabel_Load);
            this.Resize += new System.EventHandler(this.ApprovalLabel_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		private void ApprovalLabel_Resize(object sender, System.EventArgs e)
		{
			linkLabel1.Width = this.Width;
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if(Connect.isProjServer)
			{
				FormApproveEntTasks.UUpdateTaskItem uItem = (FormApproveEntTasks.UUpdateTaskItem)lItem.Tag;

				FormEntTaskInformation frmTaskInfo = new FormEntTaskInformation(uItem, pj);
				frmTaskInfo.txtApprovalNotes.Text = uItem.approvalnotes;
				frmTaskInfo.ShowDialog(this.Parent.Parent);
				if(frmTaskInfo.DialogResult == DialogResult.OK)
					uItem.approvalnotes = frmTaskInfo.txtApprovalNotes.Text;
				frmTaskInfo.Dispose();
			}
			else
			{
				FormTaskInformation frmTaskInformation = new FormTaskInformation(Connect.taskList[int.Parse(lItem.Tag.ToString())], pj);
				frmTaskInformation.txtApprovalNotes.Text = Connect.taskList[int.Parse(lItem.Tag.ToString())].moderationNotes;
				frmTaskInformation.ShowDialog(this.Parent.Parent);
				if(frmTaskInformation.DialogResult == DialogResult.OK)
					Connect.taskList[int.Parse(lItem.Tag.ToString())].moderationNotes = frmTaskInformation.txtApprovalNotes.Text;
				frmTaskInformation.Dispose();
			}
		}

        private void ApprovalLabel_Load(object sender, EventArgs e)
        {

        }

	}
}
