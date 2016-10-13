using System;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Collections;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for ProjInfo.
	/// </summary>
	public class ProjInfo
	{
		public class ResourceItem
		{
			public int index;
			public string name;

			public override string ToString()
			{
				return name;
			}
		}
		public static SPSLists.Lists spsList;
		private static FormProjInfo frmProjInfo;
		public ProjInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static ArrayList getTaskFields(Microsoft.Office.Interop.MSProject.Project pj)
		{
            EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(pj.Application.Profiles.ActiveProfile.Server);
			
			ArrayList arr = new ArrayList();
			foreach(string s in pub.getAllTaskEnterpriseFieldList())
			{
				arr.Add(s);
			}

			return arr;
		}

		public static ArrayList getProjectFields(Microsoft.Office.Interop.MSProject.Project pj)
		{
            EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(pj.Application.Profiles.ActiveProfile.Server);
			
			ArrayList arr = new ArrayList();
			foreach(string s in pub.getAllProjectEnterpriseFieldList())
			{
				arr.Add(s);
			}

			return arr;
		}

		public static bool projInfo(System.Xml.XmlNode node, Microsoft.Office.Interop.MSProject.Project pj, bool hideForm, bool showMessage, out string []propList)
		{

			Connect.projectCenterFields = new Hashtable();

			bool propsSet;

			frmProjInfo = new FormProjInfo();

            spsList = Connection.GetListService(Connection.url);
			
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Retrieving Resource List...";
			frmStatus.Show();
			frmStatus.Refresh();

			CheckResources.resListStruct []resList = CheckResources.getResourceList(pj, frmStatus);

			frmStatus.label1.Text = "Retrieving Project Information...";
			frmStatus.Refresh();

			Font f = new Font("Arial",8);

			Hashtable hProps = new Hashtable();

			string viewFields = "";
	
			ArrayList arrTaskFields = new ArrayList();
			if(Connect.isProjServer)
			{
				try
				{
					arrTaskFields = getTaskFields(pj);
				}
				catch{}
			}

			

			foreach(XmlNode nd in node["Fields"].ChildNodes)
			{
				string hidden = getAttribute(nd,"Hidden");
				string ro = getAttribute(nd,"ReadOnly");
				string name = getAttribute(nd,"Name");
				string displayname = getAttribute(nd,"DisplayName");
				string type = getAttribute(nd,"Type");
				string required = getAttribute(nd,"Required");
				string editable = getAttribute(nd,"ShowInEditForm").ToLower();

				if(required.ToUpper() == "TRUE")
					displayname = displayname + "*";

				int iTemp = 0;
				bool bTemp = false;

				if(arrTaskFields.Contains(name))
					hidden = "TRUE";

				if(hidden != "TRUE" && ro != "TRUE" && validField(name) && validType(type) && !Connect.validWssField(type,name,out iTemp,out bTemp,true) && (editable == "true" || editable == ""))
				{

					ListViewItem li = new ListViewItem(new string[]{"",""});
					li.Tag = nd;
					frmProjInfo.listView1.Items.Add(li);

					Label lbl = new Label();
					lbl.Top = li.Bounds.Top - 1;
					lbl.Tag = li.Index;
					frmProjInfo.listView1.Controls.Add(lbl);
					lbl.Visible = true;
					lbl.Left = -1;
					lbl.Width = frmProjInfo.listView1.Columns[0].Width + 1;
			
					lbl.Text = displayname;
			
					lbl.Height = 13;
					lbl.Font = f;

					hProps.Add(name,"");

					viewFields = viewFields + "<FieldRef Name='" + name + "'/>";

					switch(type.ToUpper())
					{
						case "NUMBER":
						case "CURRENCY":
						case "URL":
						case "TEXT":
                        case "NOTE":
							addTextField(nd, li, name, type.ToUpper());
							break;
						case "CHOICE":
							addChoiceField(nd, li,name);
							break;
                        case "MULTICHOICE":
                            addMultiSelectField(nd, li, name);
                            break;
						case "BOOLEAN":
							addCheckField(li, name);
							break;
						case "DATETIME":
							addDateField(li, name);
							break;
						case "USER":
							addUserField(nd, li, name, resList);
							break;
						case "LOOKUP":
							addLookupField(nd, li,name);
							break;
					};

				}
		
			}

			XmlNode ndProjectInfo = getProjectCenter(viewFields, pj);
			//MessageBox.Show(ndProjectInfo.OuterXml);
			setProjectCenterInfo(ndProjectInfo, pj);

			propList = new string[hProps.Count];
			int counter = 0;
			foreach(DictionaryEntry entry in hProps)
			{
				propList[counter++] = entry.Key.ToString();
			}

			frmStatus.Dispose();
	
			propList = new string[1];
			propsSet = false;
	
			if(hProps.Count <= 0 || hideForm)
			{

				if(Connect.isProjServer)
					saveResults(pj);

				frmProjInfo.Dispose();

				if(showMessage && hProps.Count <= 0)
                    MessageBox.Show("There are currently no custom " + Connect.getProperty("EPMLivePCList", pj) + " fields configured.");

				propsSet = true;
			}
			else
			{
				if(hProps.Count >= 12)
					frmProjInfo.listView1.Columns[1].Width = 280;
				else
					frmProjInfo.listView1.Columns[1].Width = 300;

				DialogResult res = frmProjInfo.ShowDialog();
				if(res==DialogResult.OK)
				{
					saveResults(pj);
					propsSet = true;
					if(showMessage)
						saveProjectCenter(pj);
				}
				frmProjInfo.Dispose();
			}

			return propsSet;
		}

		private static void setProjectCenterInfo(XmlNode ndProjectInfo, Microsoft.Office.Interop.MSProject.Project pj)
		{

			System.Globalization.NumberFormatInfo eProvider = new System.Globalization.NumberFormatInfo( );

			eProvider.NumberDecimalSeparator = ".";
			eProvider.NumberGroupSeparator = ",";
			eProvider.NumberGroupSizes = new int[] {3};

			System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo( );

			provider.NumberDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			provider.NumberGroupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
			provider.NumberGroupSizes = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes;

			ArrayList arrProjFields = new ArrayList();
			if(Connect.isProjServer)
			{
				try
				{
					arrProjFields = ProjInfo.getProjectFields(pj);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error Loading Project Fields: " + ex.Message + ex.StackTrace);
				}
			}

			foreach(Object obj in frmProjInfo.listView1.Controls)
			{
				if(obj.GetType().ToString() == "System.Windows.Forms.TextBox")
				{
					try
					{
						TextBox txt = (TextBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(txt.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						string val = "";
						try
						{
							val = ndProjectInfo.Attributes["ows_" + getAttribute(nd,"Name")].Value;
						}
						catch{}
						if(arrProjFields.Contains(getAttribute(nd,"Name")))
						{
							string entFieldId = getAttribute(nd,"Name").Substring(3);
							val = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId));
						}
						switch(getAttribute(nd,"Type").ToUpper())
						{
							case "NUMBER":
								double num = Convert.ToDouble(val,eProvider);

								if(getAttribute(nd,"Percentage").ToUpper() == "TRUE")
								{
									num = num * 100;
									val = String.Format(provider,"{0:F2}",num);
								}
								else
								{
									string decimals = getAttribute(nd,"Decimals");

									if(decimals != "")
										val = String.Format(provider,"{0:F" + decimals + "}",num);
									else
										val = String.Format(provider,"{0:F}",num);
								}
								break;
							case "CURRENCY":
								//MessageBox.Show("Currency");
								val = val.Replace("$","").Trim();
								val = String.Format(provider,"{0:#.00}",Convert.ToDouble(val,eProvider));
								break;
						};

						txt.Text = val;
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.ComboBox")
				{
					try
					{
						ComboBox cbo = (ComboBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(cbo.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;

						string val = "";
						try
						{
							val = ndProjectInfo.Attributes["ows_" + getAttribute(nd,"Name")].Value;
						}
						catch{}
						if(arrProjFields.Contains(getAttribute(nd,"Name")))
						{
							string entFieldId = getAttribute(nd,"Name").Substring(3);
							val = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId));
						}
						switch (getAttribute(nd,"Type"))
						{
							case "Choice":
								cbo.Text = val.Replace("&amp;","&");
								break;
							case "User":
							case "Lookup":
								try
								{
									ResourceItem ri = (ResourceItem)cbo.SelectedItem;
									//string val = ndProjectInfo.Attributes["ows_" + getAttribute(nd,"Name")].Value;
									int ind = val.IndexOf(";#");
									if(ind > 0)
									{
										val = val.Substring(ind + 2);
										cbo.Text = val;
									}
								}
								catch{}
								break;
						};
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
				{
					try
					{
						DateTimePicker dt = (DateTimePicker)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(dt.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						//DateTime date = DateTime.Parse(dt.Text);
						string val = "";
						try
						{
							val = ndProjectInfo.Attributes["ows_" + getAttribute(nd,"Name")].Value;
						}
						catch{}
						if(arrProjFields.Contains(getAttribute(nd,"Name")))
						{
							string entFieldId = getAttribute(nd,"Name").Substring(3);
							val = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId));
						}
                        if(val == "")
                            dt.Checked = false;
                        else
                        {
                            dt.Checked = true;
                            dt.Text = val;
                        }
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
				{
					try
					{
						CheckBox chk = (CheckBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(chk.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						string val = "";
						try
						{
							val = ndProjectInfo.Attributes["ows_" + getAttribute(nd,"Name")].Value;
						}
						catch{}
						if(arrProjFields.Contains(getAttribute(nd,"Name")))
						{
							string entFieldId = getAttribute(nd,"Name").Substring(3);
							val = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId));
							if(val == "Yes")
								val = "1";
						}
						
						if(val == "1")
							chk.Checked = true;
						else
							chk.Checked = false;
					}
					catch{}
				}
                if (obj.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
                {
                    try
                    {
                        CheckedListBox lstCheckBox = (CheckedListBox)obj;
                        ListViewItem li = frmProjInfo.listView1.Items[int.Parse(lstCheckBox.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;
                        string val = "";
                        try
                        {
                            val = ndProjectInfo.Attributes["ows_" + getAttribute(nd, "Name")].Value;
                        }
                        catch { }

                        if (!string.IsNullOrEmpty(val))
                        {
                            string[] valArr = val.Split(new char[] { ';', '#' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var selText in valArr)
                            {
                                int index = lstCheckBox.Items.IndexOf(selText);
                                if (index != -1)
                                    lstCheckBox.SetItemChecked(index, true);
                            }
                        }
                        else
                        {
                            if (nd["Default"] != null)
                            {
                                foreach (XmlNode node in nd["Default"].ChildNodes)
                                {
                                    var index = lstCheckBox.Items.IndexOf(node.InnerText);
                                    if (index != -1)
                                        lstCheckBox.SetItemChecked(index, true);
                                }
                            }
                        }
                    }
                    catch { }
                }
			}
		}

		private static XmlNode getProjectCenter(string viewFields, Microsoft.Office.Interop.MSProject.Project pj)
		{
			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
			XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
			XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

			ndQueryOptions.InnerXml = "";
			ndViewFields.InnerXml = viewFields;
			ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Value></Eq></Where>";
			XmlNode ndListItems = null;
			try
			{
				ndListItems = spsList.GetListItems(Connect.getProperty("EPMLivePCList", pj), string.Empty, ndQuery, ndViewFields, "150", ndQueryOptions, string.Empty);
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
                MessageBox.Show("Error Reading " + Connect.getProperty("EPMLivePCList", pj) + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
				return null;
			}

			string id = "";
			foreach(XmlNode nd in ndListItems.ChildNodes[1])
			{
				if(nd.OuterXml != "")
				{
					string title = "";
					try
					{
						title = nd.Attributes["ows_Title"].Value;
					}
					catch(System.Exception){}
					if(title == Connection.getProjectName(pj))
					{
						id = nd.Attributes["ows_ID"].Value;
						Connect.projectCenterFields.Add("ID",id);
					}
				}
			}
			return ndListItems.ChildNodes[1].ChildNodes[1];
		}

		private static void saveProjectCenter(Microsoft.Office.Interop.MSProject.Project pj)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Saving Project Information...";
			frmStatus.Show();
			frmStatus.Refresh();
			try
			{
				ArrayList arrProjFields = new ArrayList();
				if(Connect.isProjServer)
				{
					try
					{
						arrProjFields = ProjInfo.getProjectFields(pj);
					}
					catch(Exception ex)
					{
						MessageBox.Show("Error Loading Project Fields: " + ex.Message + ex.StackTrace);
					}
				}
				string id = "";
	
				try
				{
					id = Connect.projectCenterFields["ID"].ToString();
				}
				catch{}
				string fields = "<Method ID='1' Cmd='Update'><Field Name='ID'>" + id + "</Field>";
				if(id != "")
				{
					foreach(DictionaryEntry entry in Connect.projectCenterFields)
					{
						if(entry.Key.ToString() != "ID")
						{
							if(arrProjFields.Contains(entry.Key.ToString()))
							{
                                if(entry.Value != null)
                                {
                                    string entFieldId = entry.Key.ToString().Substring(3);
                                    try
                                    {
                                        pj.ProjectSummaryTask.SetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId), entry.Value.ToString());
                                    }
                                    catch
                                    {
                                        string val = entry.Value.ToString();
                                        if(val == "True")
                                            val = "Yes";
                                        else
                                            val = "No";
                                        try
                                        {
                                            pj.ProjectSummaryTask.SetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId), val);
                                        }
                                        catch { }
                                    }
                                }
							}
                            if(entry.Value != null)
							    fields = fields + "<Field Name='" + entry.Key.ToString() + "'><![CDATA[" + entry.Value.ToString() + "]]></Field>";
                            else
                                fields = fields + "<Field Name='" + entry.Key.ToString() + "'></Field>";
						}
					}
				}
				fields = fields + "</Method>";

				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				elBatch.InnerXml = fields;

				XmlNode ndReturn = spsList.UpdateListItems(Connect.getProperty("EPMLivePCList", pj), elBatch);

				if(ndReturn.OuterXml.IndexOf("<ErrorCode>0x81020014</ErrorCode>") > 0)
				{
                    MessageBox.Show("Your " + Connect.getProperty("EPMLivePCList", pj) + " list does not appear to contain the correct column structure. You will need to recreate that list with the current version of Project Publisher.");
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error saving project information: " + ex.Message);
			}
			frmStatus.Dispose();
		}

		private static void addCheckField(ListViewItem li,string name)
		{
			Font f = new Font("Arial",10,GraphicsUnit.Pixel);
			CheckBox chk = new CheckBox();
			chk.Top = li.Bounds.Top + 4;
			chk.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(chk);
			chk.Visible = true;
			chk.Left = frmProjInfo.listView1.Columns[0].Width + 4;
			chk.Width = frmProjInfo.listView1.Columns[1].Width - 10;
			chk.Height = 15;
			/*if(Connect.getProperty("EPMLiveCF-" + name, pj) == "True")
				chk.Checked = true;
			else
				chk.Checked = false;
				*/
			//txt.Text = Connect.getProperty("EPMLiveCF-" + name, pj);
		}

        private static void addMultiSelectField(XmlNode nd, ListViewItem li, string name)
        {
            Font f = new Font("Arial", 10, GraphicsUnit.Pixel);
            CheckedListBox lstCheckBox = new CheckedListBox();
            lstCheckBox.Top = li.Bounds.Top + 4;
            lstCheckBox.Tag = li.Index;
            frmProjInfo.listView1.Controls.Add(lstCheckBox);
            lstCheckBox.Visible = true;
            lstCheckBox.Left = frmProjInfo.listView1.Columns[0].Width + 4;
            lstCheckBox.Width = frmProjInfo.listView1.Columns[1].Width - 4;
            lstCheckBox.Height = 25;
            lstCheckBox.Font = f;

            foreach (XmlNode node in nd["CHOICES"].ChildNodes)
            {
                lstCheckBox.Items.Add(node.InnerText);
            }

        }

		private static void addTextField(XmlNode nd, ListViewItem li,string name, string type)
		{
			Font f = new Font("Arial",12,GraphicsUnit.Pixel);
			TextBox txt = new TextBox();
			txt.Top = li.Bounds.Top - 1;
			txt.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(txt);
			txt.Visible = true;
			txt.Left = frmProjInfo.listView1.Columns[0].Width;
			txt.Width = frmProjInfo.listView1.Columns[1].Width + 1;
			txt.BorderStyle = BorderStyle.None;
			txt.Font = f;

			/*string val = Connect.getProperty("EPMLiveCF-" + name, pj);

			if(getAttribute(nd,"Percentage") == "TRUE")
			{
				try
				{
					val = (float.Parse(val)*100).ToString();
				}
				catch{}
			}
			txt.Text = val;*/
		}

		private static void addDateField(ListViewItem li,string name)
		{
			Font f = new Font("Arial",10,GraphicsUnit.Pixel);
			DateTimePicker dt = new DateTimePicker();
			dt.Top = li.Bounds.Top - 1;
			dt.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(dt);
			dt.Visible = true;
            dt.ShowCheckBox = true;
			dt.Left = frmProjInfo.listView1.Columns[0].Width;
			dt.Width = frmProjInfo.listView1.Columns[1].Width + 1;
			dt.Format = DateTimePickerFormat.Short;
			//dt.BorderStyle = BorderStyle.None;
			dt.Font = f;
			dt.CalendarFont = f;
			/*try
			{
				dt.Text = Connect.getProperty("EPMLiveCF-" + name, pj);
			}
			catch{}*/
		}

		private static void addLookupField(XmlNode nd, ListViewItem li,string name)
		{
			Font f = new Font("Arial",9,GraphicsUnit.Pixel);
			ComboBox cbo = new ComboBox();
			cbo.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo.Top = li.Bounds.Top - 1;
			cbo.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(cbo);
			cbo.Visible = true;
			cbo.Left = frmProjInfo.listView1.Columns[0].Width;
			cbo.Width = frmProjInfo.listView1.Columns[1].Width + 1;
			cbo.Font = f;
			//cbo.DrawMode = DrawMode.OwnerDrawVariable;
			cbo.ItemHeight = 12;
			cbo.Sorted = true;

			if(getAttribute(nd,"Required") == "FALSE")
				cbo.Items.Add("");

			buildList(cbo, getAttribute(nd,"List"), getAttribute(nd,"ShowField"));

			/*string val = Connect.getProperty("EPMLiveCF-" + name, pj);
			int ind = val.IndexOf(";#");
			if(ind > 0)
			{
				val = val.Substring(ind + 2);
				cbo.Text = val;
			}*/
		}

		private static void buildList(ComboBox cbo, string list, string field)
		{
			try
			{
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
				XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
				XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");
				ndQueryOptions.InnerXml = "";
				ndQuery.InnerXml = "";
				ndViewFields.InnerXml = "<FieldRef Name=\"" + field + "\"/>";

				XmlNode nd = spsList.GetListItems(list,string.Empty,ndQuery,ndViewFields,"0",ndQueryOptions,string.Empty);
				foreach(XmlNode item in nd["rs:data"].ChildNodes)
				{
					if(item.OuterXml.Trim().Replace("&nbsp;"," ") != "")
					{
						try
						{
							ResourceItem ri = new ResourceItem();
							ri.name = item.Attributes["ows_" + field].Value;
							ri.index =  int.Parse(item.Attributes["ows_ID"].Value);
							cbo.Items.Add(ri);
						}
						catch{}
					}
				}
			}
			catch{}

		}

		private static void addChoiceField(XmlNode nd, ListViewItem li,string name)
		{
			Font f = new Font("Arial",9,GraphicsUnit.Pixel);
			ComboBox cbo = new ComboBox();
			cbo.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo.Top = li.Bounds.Top - 1;
			cbo.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(cbo);
			cbo.Visible = true;
			cbo.Left = frmProjInfo.listView1.Columns[0].Width;
			cbo.Width = frmProjInfo.listView1.Columns[1].Width + 1;
			cbo.Font = f;
			//cbo.DrawMode = DrawMode.OwnerDrawVariable;
			cbo.ItemHeight = 12;
			cbo.Sorted = true;
	
			if(getAttribute(nd,"Required") == "FALSE")
				cbo.Items.Add("");

			foreach(XmlNode node in nd["CHOICES"].ChildNodes)
			{
				cbo.Items.Add(node.InnerText);
			}

			//cbo.Text = Connect.getProperty("EPMLiveCF-" + name, pj);
	
		}

		private static void addUserField(XmlNode nd, ListViewItem li,string name, CheckResources.resListStruct[] resList)
		{
			Font f = new Font("Arial",9,GraphicsUnit.Pixel);
			ComboBox cbo = new ComboBox();
			cbo.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo.Top = li.Bounds.Top - 1;
			cbo.Tag = li.Index;
			frmProjInfo.listView1.Controls.Add(cbo);
			cbo.Visible = true;
			cbo.Left = frmProjInfo.listView1.Columns[0].Width;
			cbo.Width = frmProjInfo.listView1.Columns[1].Width + 1;
			cbo.Font = f;
			cbo.Sorted = true;
			cbo.ItemHeight = 12;
	
			if(getAttribute(nd,"Required") == "FALSE")
				cbo.Items.Add("");

			foreach(CheckResources.resListStruct res in resList)
			{
				ResourceItem ri = new ResourceItem();
				ri.name = res.name;
				ri.index = res.resId;
				cbo.Items.Add(ri);
			}

//			for(int i = 0;i<CheckResources.resCount;i++)
//			{
//				ResourceItem ri = new ResourceItem();
//				ri.name = CheckResources.resList[i].name;
//				ri.index = CheckResources.resList[i].resId;
//				cbo.Items.Add(ri);
//			}

			
			
			/*string val = Connect.getProperty("EPMLiveCF-" + name, pj);
			int ind = val.IndexOf(";#");
			if(ind > 0)
			{
				val = val.Substring(ind + 2);
				cbo.Text = val;
			}*/
		}

		private static  bool validType(string type)
		{
			if(type == "Text" || type == "Note")
				return true;
            if (type == "Choice" || type == "MultiChoice")
				return true;
			if(type == "Number")
				return true;
			if(type == "Currency")
				return true;
			if(type == "Url")
				return true;
			if(type == "Boolean")
				return true;
			if(type == "DateTime")
				return true;
			if(type == "User")
				return true;
			if(type == "Lookup")
				return true;

			return false;
		}

		private static bool validField(string name)
		{

            switch (name)
            {
                case "AutoCalculate":
                case "TimesheetHours":
                case "BaselineSaved":
                case "IsProjectServer":
                case "ProjectServerURL":
                case "PublishToPWA":
                case "SharePointProject":
                case "Title":
                case "Priority":
                case "Status":
                case "PercentComplete":
                case "AssignedTo":
                case "Start":
                case "Finish":
                case "Priority0":
                case "Actual_x0020_Start":
                case "Actual_x0020_Finish":
                case "Duration":
                case "Actual_x0020_Duration":
                case "Cost":
                case "Actual_x0020_Cost":
                case "Work":
                case "Actual_x0020_Work":
                case "Baseline_x0020_Duration":
                case "Baseline_x0020_Start":
                case "Baseline_x0020_Finish":
                case "Baseline_x0020_Cost":
                case "Baseline_x0020_Work":
                case "Remaining_x0020_Duration":
                case "Work_x0020_Variance":
                case "Cost_x0020_Variance":
                case "Work_x0020__x0025__x0020_Complet":
                case "Fixed_x0020_Cost":
                case "Physical_x0020__x0025__x0020_Com":
                case "Attachments":
                    return false;
            }

			return true;
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

		private static void saveResults(Microsoft.Office.Interop.MSProject.Project pj)
		{

			System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo( );

			provider.NumberDecimalSeparator = ".";
			provider.NumberGroupSeparator = ",";
			provider.NumberGroupSizes = new int[ ] { 3 };

			Connect.setProperty("EPMLiveHideProjInfo",pj,frmProjInfo.chkHideProjInfo.Checked.ToString());

			foreach(Object obj in frmProjInfo.listView1.Controls)
			{
				if(obj.GetType().ToString() == "System.Windows.Forms.TextBox")
				{
					try
					{
						TextBox txt = (TextBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(txt.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						string val = txt.Text;
						if(getAttribute(nd,"Percentage") == "TRUE")
						{
							if(val!="")
							{
								try
								{
									val = (float.Parse(val)/100).ToString();
								}
								catch{}
							}
						}
						if(getAttribute(nd,"Type").ToUpper() == "NUMBER" || getAttribute(nd,"Type").ToUpper() == "CURRENCY")
						{
							Connect.projectCenterFields.Add(getAttribute(nd,"Name"), Convert.ToString(Convert.ToDouble(val),provider));
						}
						else
							Connect.projectCenterFields.Add(getAttribute(nd,"Name"), val);
						//fieldUpload = fieldUpload + "<Field Name='" +  + "'>" + val + "</Field>";

						//Connect.setProperty("EPMLiveCF-" + getAttribute(nd,"Name"),pj,val);
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.ComboBox")
				{
					try
					{
						ComboBox cbo = (ComboBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(cbo.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						switch (getAttribute(nd,"Type"))
						{
							case "Choice":
								Connect.projectCenterFields.Add(getAttribute(nd,"Name"), cbo.Text );
								//fieldUpload = fieldUpload + "<Field Name='" + getAttribute(nd,"Name") + "'>" + + "</Field>";
								break;
							case "User":
							case "Lookup":
								try
								{
									ResourceItem ri = (ResourceItem)cbo.SelectedItem;
									Connect.projectCenterFields.Add(getAttribute(nd,"Name"), ri.index.ToString() + ";#" + ri.name);
									//fieldUpload = fieldUpload + "<Field Name='" + getAttribute(nd,"Name") + "'>" +  + "</Field>";
								}
								catch{}
								break;
						};
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
				{
					try
					{
						DateTimePicker dt = (DateTimePicker)obj;
                        ListViewItem li = frmProjInfo.listView1.Items[int.Parse(dt.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;

                        if(dt.Checked)
                        {
                            DateTime date = DateTime.Parse(dt.Text);
                            Connect.projectCenterFields.Add(getAttribute(nd, "Name"), date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString());
                        }
                        else
                        {
                            Connect.projectCenterFields.Add(getAttribute(nd, "Name"), null);
                        }
						//fieldUpload = fieldUpload + "<Field Name='" + getAttribute(nd,"Name") + "'>" +  + "</Field>";
					}
					catch{}
				}
				if(obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
				{
					try
					{
						CheckBox chk = (CheckBox)obj;
						ListViewItem li = frmProjInfo.listView1.Items[int.Parse(chk.Tag.ToString())];
						XmlNode nd = (XmlNode)li.Tag;
						Connect.projectCenterFields.Add(getAttribute(nd,"Name"), chk.Checked.ToString());
						//fieldUpload = fieldUpload + "<Field Name='" + getAttribute(nd,"Name") + "'>" + chk.Checked.ToString() + "</Field>";
					}
					catch{}
				}
                if (obj.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
                {
                    try
                    {
                        CheckedListBox lstCheckbox = (CheckedListBox)obj;
                        string strChkBoxData = string.Empty;
                        ListViewItem li = frmProjInfo.listView1.Items[int.Parse(lstCheckbox.Tag.ToString())];
                        XmlNode nd = (XmlNode)li.Tag;
                        foreach (var chkbox in lstCheckbox.CheckedItems)
                        {
                            strChkBoxData += chkbox + ";#";
                        }
                        Connect.projectCenterFields.Add(getAttribute(nd, "Name"), strChkBoxData.TrimEnd(new char[] { ';', '#' }));                        
                    }
                    catch { }
                }
			}
		}
	}
}
