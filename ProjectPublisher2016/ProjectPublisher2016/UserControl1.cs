using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class UserControl1 : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.CheckBox checkBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public bool isAccept;
		public ListViewItem lItem;
		public UserControl1 otherItem;
		public UserControl1(bool accept)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			isAccept=accept;
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(0, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(16, 16);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// UserControl1
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.checkBox1);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(16, 16);
			this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void checkBox1_Click(object sender, System.EventArgs e)
		{
			if(Connect.isProjServer)
			{
				
				if(otherItem != null)
					otherItem.checkBox1.Checked = false;
				if(checkBox1.Checked && isAccept)
					((FormApproveEntTasks.UUpdateTaskItem)lItem.Tag).approvalstatus = 2;
				if(checkBox1.Checked && !isAccept)
					((FormApproveEntTasks.UUpdateTaskItem)lItem.Tag).approvalstatus = 1;
				if(!checkBox1.Checked)
					((FormApproveEntTasks.UUpdateTaskItem)lItem.Tag).approvalstatus = 0;
			}
			else
			{
				if(otherItem != null)
					otherItem.checkBox1.Checked = false;
				if(checkBox1.Checked && isAccept)
					Connect.taskList[int.Parse(lItem.Tag.ToString())].moderationStatus = 2;
				if(checkBox1.Checked && !isAccept)
					Connect.taskList[int.Parse(lItem.Tag.ToString())].moderationStatus = 1;
				if(!checkBox1.Checked)
					Connect.taskList[int.Parse(lItem.Tag.ToString())].moderationStatus = 0;

			}
		}

	}
}
