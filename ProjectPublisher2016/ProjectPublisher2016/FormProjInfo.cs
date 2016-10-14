using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	public class FormProjInfo : System.Windows.Forms.Form
    {
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.CheckBox chkHideProjInfo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		

		public FormProjInfo()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProjInfo));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkHideProjInfo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(8, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(450, 272);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 272;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(304, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(384, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkHideProjInfo
            // 
            this.chkHideProjInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHideProjInfo.Location = new System.Drawing.Point(8, 294);
            this.chkHideProjInfo.Name = "chkHideProjInfo";
            this.chkHideProjInfo.Size = new System.Drawing.Size(280, 24);
            this.chkHideProjInfo.TabIndex = 22;
            this.chkHideProjInfo.Text = "Do not show project information dialog again";
            this.chkHideProjInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Field";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Value";
            // 
            // FormProjInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 328);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHideProjInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProjInfo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Information";
            this.Load += new System.EventHandler(this.FormProjInfo_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormProjInfo_Load(object sender, EventArgs e)
		{
			label1.Parent = listView1;
			label2.Parent = listView1;
		}

		

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(listView1.Items.Count <= 0)
				return;

			label1.Top = 2;
			label1.Left = listView1.Items[0].Bounds.Left + 2;
			label1.Width = listView1.Columns[0].Width - 4;
			label2.Left = listView1.Items[0].Bounds.Left + listView1.Columns[0].Width + 4;
			label2.Top = 2;
			label2.Width = listView1.Columns[1].Width - 4;
			label1.Refresh();
			label2.Refresh();

			foreach(Object obj in listView1.Controls)
			{
				try
				{
					if(obj.GetType().ToString() == "System.Windows.Forms.Label")
					{
						Label lbl = (Label)obj;
						if(lbl.Name == "")
						{
							if(listView1.Items[int.Parse(lbl.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(lbl.Tag.ToString())].Bounds.Height)
								lbl.Visible = false;
							else
								lbl.Visible = true;
							lbl.Top = listView1.Items[int.Parse(lbl.Tag.ToString())].Bounds.Top + 2;
							lbl.Left = listView1.Items[int.Parse(lbl.Tag.ToString())].Bounds.Left + 1;
							lbl.Width = listView1.Columns[0].Width - 1;
						}
					}

					if(obj.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
					{
						DateTimePicker dt = (DateTimePicker)obj;
						if(listView1.Items[int.Parse(dt.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(dt.Tag.ToString())].Bounds.Height)
							dt.Visible = false;
						else
							dt.Visible = true;

						dt.Top = listView1.Items[int.Parse(dt.Tag.ToString())].Bounds.Top;
						dt.Left = listView1.Items[int.Parse(dt.Tag.ToString())].Bounds.Left + listView1.Columns[0].Width + 1;
						dt.Width = listView1.Columns[1].Width - 1;

					}

					if(obj.GetType().ToString() == "System.Windows.Forms.TextBox")
					{
						TextBox txt = (TextBox)obj;
						if(listView1.Items[int.Parse(txt.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(txt.Tag.ToString())].Bounds.Height)
							txt.Visible = false;
						else
							txt.Visible = true;

						txt.Top = listView1.Items[int.Parse(txt.Tag.ToString())].Bounds.Top + 1;
						txt.Left = listView1.Items[int.Parse(txt.Tag.ToString())].Bounds.Left + listView1.Columns[0].Width + 1;
						txt.Width = listView1.Columns[1].Width - 3;
						txt.Height =  listView1.Items[int.Parse(txt.Tag.ToString())].Bounds.Height;
					}

					if(obj.GetType().ToString() == "System.Windows.Forms.ComboBox")
					{
						ComboBox cbo = (ComboBox)obj;
						if(listView1.Items[int.Parse(cbo.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(cbo.Tag.ToString())].Bounds.Height)
							cbo.Visible = false;
						else
							cbo.Visible = true;
						cbo.Top = listView1.Items[int.Parse(cbo.Tag.ToString())].Bounds.Top - 1;
						cbo.Left = listView1.Items[int.Parse(cbo.Tag.ToString())].Bounds.Left + listView1.Columns[0].Width + 1;
						cbo.Width = listView1.Columns[1].Width - 1;
					}

					if(obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
					{
						CheckBox chk = (CheckBox)obj;
						if(listView1.Items[int.Parse(chk.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(chk.Tag.ToString())].Bounds.Height)
							chk.Visible = false;
						else
							chk.Visible = true;
						chk.Top = listView1.Items[int.Parse(chk.Tag.ToString())].Bounds.Top + 2;
						chk.Left = listView1.Items[int.Parse(chk.Tag.ToString())].Bounds.Left + listView1.Columns[0].Width + 4;
					}
                    if (obj.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
                    {
                        CheckedListBox lstCheckbox = (CheckedListBox)obj;
                        if (listView1.Items[int.Parse(lstCheckbox.Tag.ToString())].Bounds.Top < listView1.Items[int.Parse(lstCheckbox.Tag.ToString())].Bounds.Height)
                            lstCheckbox.Visible = false;
                        else
                            lstCheckbox.Visible = true;
                        lstCheckbox.Top = listView1.Items[int.Parse(lstCheckbox.Tag.ToString())].Bounds.Top + 4;
                        lstCheckbox.Left = listView1.Items[int.Parse(lstCheckbox.Tag.ToString())].Bounds.Left + listView1.Columns[0].Width + 4;
                        lstCheckbox.Width = listView1.Columns[1].Width - 4;
                    }
				}
				catch{}
			}
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

        public void button1Click(object sender, System.EventArgs e)
        {

            foreach (Object obj in listView1.Controls)
            {
                if (obj.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    try
                    {
                        TextBox txt = (TextBox)obj;
                        ListViewItem li = listView1.Items[int.Parse(txt.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;
                        if (txt.Text.Trim() == "")
                        {
                            if (getAttribute(nd, "Required").ToUpper() == "TRUE")
                            {
                                MessageBox.Show("You must enter a value for '" + getAttribute(nd, "DisplayName") + "'");
                                return;
                            }
                        }
                        else
                        {
                            switch (getAttribute(nd, "Type"))
                            {
                                case "Number":
                                case "Currency":
                                    try
                                    {
                                        float num = float.Parse(txt.Text);
                                        string max = getAttribute(nd, "Max");
                                        string min = getAttribute(nd, "Min");
                                        if (min != "")
                                        {
                                            if (num < float.Parse(min))
                                            {
                                                MessageBox.Show("The value for '" + getAttribute(nd, "DisplayName") + "' must be greater than " + min + ".");
                                                return;
                                            }
                                        }
                                        if (max != "")
                                        {
                                            if (num > float.Parse(max))
                                            {
                                                MessageBox.Show("The value for '" + getAttribute(nd, "DisplayName") + "' must be less than " + max + ".");
                                                return;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("The value for '" + getAttribute(nd, "DisplayName") + "' is not a valid number.");
                                        return;
                                    }
                                    break;
                            };
                        }
                    }
                    catch { }
                }
                if (obj.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    try
                    {
                        ComboBox cbo = (ComboBox)obj;
                        ListViewItem li = listView1.Items[int.Parse(cbo.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;
                        if (getAttribute(nd, "Required").ToUpper() == "TRUE")
                        {
                            if (cbo.SelectedIndex == -1)
                            {
                                MessageBox.Show("You must select a value for '" + getAttribute(nd, "DisplayName") + "'");
                                return;
                            }
                        }
                    }
                    catch { }
                }
                if (obj.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
                {
                    try
                    {
                        CheckedListBox lstCheckbox = (CheckedListBox)obj;
                        ListViewItem li = listView1.Items[int.Parse(lstCheckbox.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;
                        if (getAttribute(nd, "Required").ToUpper() == "TRUE")
                        {
                            if (lstCheckbox.CheckedItems.Count == 0)
                            {
                                MessageBox.Show("You must select a value for '" + getAttribute(nd, "DisplayName") + "'");
                                return;
                            }
                        }
                    }
                    catch { }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }


        private void button1_Click(object sender, System.EventArgs e)
		{
            button1Click(sender, e);
        }

		private static string getAttribute(XmlNode nd, string attr)
		{
			try
			{
				return nd.Attributes[attr].Value;
			}
			catch{}
			return "";
		}
	}
}
