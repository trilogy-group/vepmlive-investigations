using System;
using System.Xml;
using System.Windows.Forms;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for CheckLists.
	/// </summary>
	public class CheckLists
	{
		private static string projectReportsList;
		public CheckLists()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private static bool checkProjectCenter()
		{
			return true;
		}

		private static void buildTaskCenterList(XmlNode xmlRet, Microsoft.Office.Interop.MSProject.Project pj)
		{
			int iField = 0;
			try
			{
				
				foreach(XmlNode nd in xmlRet["Fields"].ChildNodes)
				{
					string wssfieldname = Connect.getAttribute(nd,"Name");
					string name = wssfieldname.Replace("_x0020_","");
					string displayname = Connect.getAttribute(nd,"DisplayName");
					string type = Connect.getAttribute(nd,"Type");
					string editable = Connect.getAttribute(nd,"ShowInEditForm");
					string format = Connect.getAttribute(nd,"Format");
					string required = Connect.getAttribute(nd,"Required");
				
					//string displayname = getAttribute(nd,"DisplayName");
					int fieldType = 0;
					bool builtin = false;
					
					
					if(name == "TimesheetHours" && type == "Number" && Connect.getProperty("EPMLiveTSTimesheetHours",pj) != "")
					{
						Connect.TaskField tskField = new Connect.TaskField();
						tskField.fieldId = iField;
						tskField.fieldName = Connect.getProperty("EPMLiveTSTimesheetHours",pj);
						tskField.type = 2;
						tskField.displayName = displayname;
						tskField.format = format;
						tskField.builtin = builtin;
						tskField.innerXml = nd.InnerXml;
						tskField.outerXml = nd.OuterXml;
						tskField.required = required;
						tskField.wssFieldName = wssfieldname;
						tskField.editable = true;
						Connect.hTaskCenterFields.Add(Connect.getProperty("EPMLiveTSTimesheetHours",pj).ToUpper(),tskField);
					}
					else if(name == "Timesheet" && type == "Boolean" && Connect.getProperty("EPMLiveTSFlag",pj) != "")
					{

						Connect.TaskField tskField = new Connect.TaskField();
						tskField.fieldId = iField;
						tskField.fieldName = Connect.getProperty("EPMLiveTSFlag",pj);
						tskField.type = 5;
						tskField.displayName = displayname;
						tskField.format = format;
						tskField.builtin = builtin;
						tskField.innerXml = nd.InnerXml;
						tskField.outerXml = nd.OuterXml;
						tskField.required = required;
						tskField.wssFieldName = wssfieldname;
						if(editable.ToUpper() == "TRUE")
							tskField.editable = true;
						else if(editable == "" && !lockedField(name.ToUpper()))
							tskField.editable = true;
						else
							tskField.editable = false;

						Connect.hTaskCenterFields.Add(Connect.getProperty("EPMLiveTSFlag",pj).ToUpper(),tskField);
					}
					else if(Connect.validWssField(type, name, out fieldType, out builtin, false))
					{
						string sField = name.ToUpper();
						if(sField == "TASKTYPE")
							sField = "TYPE";
						if(sField == "PHYSICAL_X0025_COM")
							sField = "PHYSICALPERCENTCOMPLETE";
						if(sField == "STARTDATE")
							sField = "START";
						if(sField == "DUEDATE")
							sField = "FINISH";

						iField = 0;
						try
						{
							iField = Convert.ToInt32(Connect.hPprojectFields[sField].ToString());
						}
						catch{}

						Connect.TaskField tskField = new Connect.TaskField();
						tskField.fieldId = iField;
						tskField.fieldName = name;
						tskField.type = fieldType;
						tskField.displayName = displayname;
						tskField.format = format;
						tskField.builtin = builtin;
						tskField.innerXml = nd.InnerXml;
						tskField.outerXml = nd.OuterXml;
						tskField.required = required;
						tskField.wssFieldName = wssfieldname;

						if(editable.ToUpper() == "TRUE")
							tskField.editable = true;
						else if(editable == "" && !lockedField(name.ToUpper()))
							tskField.editable = true;
						else
							tskField.editable = false;

						Connect.hTaskCenterFields.Add(sField,tskField);
					}
				}
			}
			catch{}
		}

		private static bool lockedField(string field)
		{
			switch(field)
			{
				case "RESOURCENAMES":
					return true;
			}
			return false;
		}

		private static void buildProjectCenterList(XmlNode xmlRet)
		{
			int iField = 0;
			try
			{
				foreach(XmlNode nd in xmlRet["Fields"].ChildNodes)
				{
					string wssfieldname = Connect.getAttribute(nd,"Name");
					string name = wssfieldname.Replace("_x0020_","");
					string displayname = Connect.getAttribute(nd,"DisplayName");
					string type = Connect.getAttribute(nd,"Type");
					string editable = Connect.getAttribute(nd,"ShowInEditForm");
					string format = Connect.getAttribute(nd,"Format");
					string required = Connect.getAttribute(nd,"Required");

					//string displayname = getAttribute(nd,"DisplayName");
					int fieldType = 0;
					bool builtin = false;
					
					if(Connect.validWssField(type, name, out fieldType, out builtin, true))
					{
						string sField = name.ToUpper();
						iField = 0;
						try
						{
							iField = Convert.ToInt32(Connect.hPprojectFields[sField].ToString());
						}
						catch{}

						Connect.TaskField tskField = new Connect.TaskField();
						tskField.fieldId = iField;
						tskField.fieldName = name;
						tskField.type = fieldType;
						tskField.displayName = displayname;
						tskField.format = format;
						tskField.builtin = builtin;
						tskField.innerXml = nd.InnerXml;
						tskField.required = required;
						tskField.wssFieldName = wssfieldname;

						if(editable.ToUpper() == "TRUE")
							tskField.editable = true;
						else if(editable == "")
							tskField.editable = true;
						else
							tskField.editable = false;

						Connect.hProjectCenterFields.Add(tskField.fieldName,tskField);
					}
				}
			}
			catch{}
		}

		public static string check(out string sLists, out System.Xml.XmlNode ndProjectCenter, bool ignoreResourceCenter, bool silent, Microsoft.Office.Interop.MSProject.Application app, Microsoft.Office.Interop.MSProject.Project pj)
		{
			ndProjectCenter = null;
			
			sLists = "";
			bool myTasksExists = false;
			bool projectReportsExists = false;
			bool resourceCenterExists = false;
			FormStatus frmStatus = new FormStatus();
			if(silent)
			{
                app.StatusBar = "Checking '" + Connect.getProperty("EPMLiveTCList", pj) + "' List...";
			}
			else
			{
				frmStatus.Show();
                frmStatus.label1.Text = "Checking '" + Connect.getProperty("EPMLiveTCList", pj) + "' List...";
				frmStatus.Refresh();
			}
            SPSLists.Lists spList = Connection.GetListService(Connection.url);
            SPSViews.Views spView = Connection.GetViewsService(Connection.url);
			
			//==============myTasksExists
			try
			{
				XmlNode xmlRet = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));
				buildTaskCenterList(xmlRet, pj);
				myTasksExists = true;
			}
			catch
			{
				//System.Windows.Forms.MessageBox.Show("Error Check Lists:\n" + ex.Message.ToString() , "Error");
			}
			
			//============projectReportsExists
			try
			{
				if(silent)
				{
                    app.StatusBar = "Checking '" + Connect.getProperty("EPMLivePCList", pj) + "' List...";
				}
				else
				{
                    frmStatus.label1.Text = "Checking '" + Connect.getProperty("EPMLivePCList", pj) + "' List...";
					frmStatus.Refresh();
				}
				System.Xml.XmlNode xmlRet = spList.GetList(Connect.getProperty("EPMLivePCList", pj));
				ndProjectCenter = xmlRet;

				buildProjectCenterList(xmlRet);

				projectReportsList = xmlRet.Attributes["ID"].Value;
				projectReportsExists = true;
			}
			catch(Exception)
			{
				//System.Windows.Forms.MessageBox.Show("Error Check Lists:\n" + ex.Message.ToString() , "Error");
			}
			//==============resourceCenterExists
			if(!ignoreResourceCenter)
			{
				try
				{
					if(silent)
					{
						app.StatusBar = "Checking 'Resource Center' List...";
					}
					else
					{
						frmStatus.label1.Text = "Checking 'Resource Center' List...";
						frmStatus.Refresh();
					}
					System.Xml.XmlNode xmlRet = spList.GetList("Resource Center");
				
					resourceCenterExists = true;
				}
				catch(Exception)
				{
					//System.Windows.Forms.MessageBox.Show("Error Check Lists:\n" + ex.Message.ToString() , "Error");
				}
			}
			else
				resourceCenterExists = true;
			//===================
			frmStatus.Dispose();
			string lists = "\n";
			if(!myTasksExists)
                lists = "-" + Connect.getProperty("EPMLiveTCList", pj) + "\n";
			if(!projectReportsExists)
                lists = lists + "-" + Connect.getProperty("EPMLivePCList", pj) + "\n";
			if(!resourceCenterExists)
				lists = lists + "-Resource Center\n";
			lists = lists.Substring(0,lists.Length -1);
			if(lists.Length > 0)
			{
				FormCreateLists frmCreate = new FormCreateLists();
				frmCreate.label1.Text = lists;
				frmCreate.Refresh();
				frmCreate.ShowDialog();
				if(frmCreate.DialogResult == System.Windows.Forms.DialogResult.OK)
				{
					string ret = "";
					frmStatus = new FormStatus();
					frmStatus.Show();
                    frmStatus.label1.Text = "Creating '" + Connect.getProperty("EPMLivePCList", pj) + "' List...";
					frmStatus.Refresh();
					if(!projectReportsExists)
					{
						ret = createProjectReports(spList, pj);
						if(ret != "0")
						{
							frmStatus.Dispose();
							return "1";
						}
						try
						{
							XmlNode xmlRet = spList.GetList(Connect.getProperty("EPMLivePCList", pj));
							buildProjectCenterList(xmlRet);
						}
						catch{}
                        sLists = sLists + "" + Connect.getProperty("EPMLivePCList", pj) + ",";
                        frmStatus.label1.Text = "Creating '" + Connect.getProperty("EPMLivePCList", pj) + "' Views...";
						frmStatus.Refresh();
						createProjectReportViews(spView, pj);
					}

                    frmStatus.label1.Text = "Creating '" + Connect.getProperty("EPMLiveTCList", pj) + "' List...";
					frmStatus.Refresh();
					if(!myTasksExists)
					{
						ret = createMyTasks(spList, pj);
						if(ret != "0")
						{
							frmStatus.Dispose();
							return "1";
						}
						try
						{
							XmlNode xmlRet = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));
							buildTaskCenterList(xmlRet, pj);
						}
						catch
						{
							//System.Windows.Forms.MessageBox.Show("Error Check Lists:\n" + ex.Message.ToString() , "Error");
						}
						sLists = sLists + Connect.getProperty("EPMLiveTCList", pj);
                        frmStatus.label1.Text = "Creating '" + Connect.getProperty("EPMLiveTCList", pj) + "' Views...";
						frmStatus.Refresh();
						createMyTasksViews(spView, pj);
					}
					
					frmStatus.label1.Text = "Creating 'Resource Center' List...";
					frmStatus.Refresh();
					if(!resourceCenterExists)
					{
						ret = createResourceCenter(spList, pj);
						if(ret != "0")
						{
							frmStatus.Dispose();
							return "1";
						}
						sLists = sLists + "Resource Center,";
						frmStatus.label1.Text = "Creating 'Resource Center' Views...";
						frmStatus.Refresh();
						createResourceViews(spView, pj);
					}
					if(silent)
					{
						app.StatusBar = false;
					}
					else
					{
						frmStatus.Dispose();
					}
					
					
				}
				else
				{
					return "1";
				}
			}
			return "0";
			
		}

		private static string createResourceViews(SPSViews.Views spViews, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				System.Xml.XmlNode xmlRet = spViews.GetViewCollection("Resource Center");
				for(int i=0;i<xmlRet.ChildNodes.Count;i++)
				{
					spViews.DeleteView("Resource Center",xmlRet.ChildNodes[i].Attributes["Name"].Value);
				}

				//===============Project Resources=======================================
				string strQuery = 
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
					"<OrderBy><FieldRef Name=\"Title\" /></OrderBy>";
				
				string strRowLimit = "150";

				string strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"Actual_x0020_Work\" /><FieldRef Name=\"Work_x0020__x0025__x0020_Complet\" /><FieldRef Name=\"Overallocated\" />";

				System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				System.Xml.XmlNode ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				System.Xml.XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				XmlNode retNode = spViews.AddView("Resource Center", "Project Resources", ndViewFields, ndQuery, ndRowLimit ,"HTML", true);
				//===============Overallocated Resources=======================================
				strQuery =
					"<Where><Eq><FieldRef Name='Overallocated'/><Value Type='Integer'>1</Value></Eq></Where>" +
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
					"<OrderBy><FieldRef Name=\"Title\" /></OrderBy>";
				
				strRowLimit = "150";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"Actual_x0020_Work\" /><FieldRef Name=\"Work_x0020__x0025__x0020_Complet\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView("Resource Center", "Overallocated Resources", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============Resource Projects=======================================
				strQuery =
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name=\"Title\" /></GroupBy>";
				
				strRowLimit = "150";

				strViewFields = "<FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/><FieldRef Name=\"Work\" /><FieldRef Name=\"Actual_x0020_Work\" /><FieldRef Name=\"Work_x0020__x0025__x0020_Complet\" /><FieldRef Name=\"Overallocated\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView("Resource Center", "Resource Projects", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				return "0";
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
				MessageBox.Show("Error: " + ex1.Message.ToString() + ex1.Detail);
				return "-1";
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error CV: " + ex.Message.ToString(),"Cancel");
				return "-1";
			}
		}
		private static string createProjectReportViews(SPSViews.Views spViews, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				System.Xml.XmlNode xmlRet = spViews.GetViewCollection(Connect.getProperty("EPMLivePCList", pj));
				for(int i=0;i<xmlRet.ChildNodes.Count;i++)
				{
					spViews.DeleteView(Connect.getProperty("EPMLivePCList", pj),xmlRet.ChildNodes[i].Attributes["Name"].Value);
				}

				//===============Executive Summary=======================================
				string strQuery = "";

				string strRowLimit = "10";

				string strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Status\" /><FieldRef Name=\"Start\" /><FieldRef Name=\"Finish\" /><FieldRef Name=\"Cost\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"% Complete\" />";

				System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				System.Xml.XmlNode ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				System.Xml.XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				XmlNode retNode = spViews.AddView(Connect.getProperty("EPMLivePCList", pj), "Executive Summary", ndViewFields, ndQuery, ndRowLimit ,"HTML", true);

				//===============Cost Summary=======================================
				strQuery = "";

				strRowLimit = "10";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Cost\" /><FieldRef Name=\"Actual Cost\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLivePCList", pj), "Cost Summary", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============Schedule Summary=======================================
				strQuery = "";

				strRowLimit = "10";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Duration\" /><FieldRef Name=\"Start\" /><FieldRef Name=\"Finish\" /><FieldRef Name=\"Actual Duration\" /><FieldRef Name=\"Actual Start\" /><FieldRef Name=\"Actual Finish\" /><FieldRef Name=\"Remaining Duration\" /><FieldRef Name=\"% Complete\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLivePCList", pj), "Schedule Summary", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============Work Summary=======================================
				strQuery = "";

				strRowLimit = "10";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"Actual Work\" /><FieldRef Name=\"% Complete\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLivePCList", pj), "Work Summary", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);

				return "0";
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
				MessageBox.Show("Error: " + ex1.Message.ToString() + ex1.Detail);
				return "-1";
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error CV: " + ex.Message.ToString(),"Cancel");
				return "-1";
			}
		}
		private static string createMyTasksViews(SPSViews.Views spViews, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{

				System.Xml.XmlNode xmlRet = spViews.GetViewCollection(Connect.getProperty("EPMLiveTCList", pj));
				for(int i=0;i<xmlRet.ChildNodes.Count;i++)
				{
					spViews.DeleteView(Connect.getProperty("EPMLiveTCList", pj),xmlRet.ChildNodes[i].Attributes["Name"].Value);
				}
				//===============My Tasks=======================================
				string strQuery = 
					"<Where><And><Eq><FieldRef Name='AssignedTo'/><Value Type='Integer'><UserID/></Value></Eq><Eq><FieldRef Name='Milestone'/><Value Type='Integer'>0</Value></Eq></And></Where>" +
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";
				
				string strRowLimit = "150";

				string strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Status\" /><FieldRef Name=\"Priority\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"TaskHierarchy\" />";

				System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				System.Xml.XmlNode ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				System.Xml.XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				XmlNode retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "All My Tasks", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============My Tasks Status=======================================
				strQuery = 
					"<Where><And><Eq><FieldRef Name='AssignedTo'/><Value Type='Integer'><UserID/></Value></Eq><Eq><FieldRef Name='Milestone'/><Value Type='Integer'>0</Value></Eq></And></Where>" +
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/><FieldRef Name='Status'/></GroupBy>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";
				
				strRowLimit = "150";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Priority\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"TaskHierarchy\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "My Tasks Status", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============My Approval Status=======================================
				strQuery = 
					"<Where><And><Eq><FieldRef Name='AssignedTo'/><Value Type='Integer'><UserID/></Value></Eq><IsNotNull><FieldRef Name='Publisher_x0020_Approval_x0020_S'/></IsNotNull></And></Where>" +
					"<GroupBy Collapse='FALSE' GroupLimit='100' ><FieldRef Name='Publisher_x0020_Approval_x0020_S' Ascending='FALSE'/><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
					"<OrderBy><FieldRef Name='LastPublished' Ascending='FALSE'/></OrderBy>";
				
				strRowLimit = "150";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"LastPublished\" /><FieldRef Name=\"Publisher_x0020_Approval_x0020_C\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"Modified\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "My Approval Status", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============All OverDue Tasks=======================================
				strQuery = 
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
					"<Where><And><Eq><FieldRef Name='IsAssignment'/><Value Type='Boolean'>0</Value></Eq><And><Neq><FieldRef Name='PercentComplete'/><Value Type='Number'>1</Value></Neq><Lt><FieldRef Name='DueDate'/><Value Type='Text'><Today/></Value></Lt></And></And></Where>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";

				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"PercentComplete\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "All Overdue Tasks", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				
				//===============My OverDue Tasks=======================================
				strQuery = 
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
					"<Where><And><Eq><FieldRef Name='AssignedTo'/><Value Type='Integer'><UserID/></Value></Eq><And><Neq><FieldRef Name='PercentComplete'/><Value Type='Number'>1</Value></Neq><Lt><FieldRef Name='DueDate'/><Value Type='Text'><Today/></Value></Lt></And></And></Where>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";

				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"PercentComplete\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "My Overdue Tasks", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============Project Schedule=======================================
				strQuery = 
					"<Where><Eq><FieldRef Name='IsAssignment'/><Value Type='Boolean'>0</Value></Eq></Where><GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"taskorder\" /></OrderBy>";

				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"Title\" /><FieldRef Name=\"Status\" /><FieldRef Name=\"Priority\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"TaskHierarchy\" /><FieldRef Name=\"AssignedTo\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "Project Schedule", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============All Unassigned Tasks=======================================
				strQuery = 
					"<Where><And><Neq><FieldRef Name='Milestone'/><Value Type='Integer'>1</Value></Neq><And><Neq><FieldRef Name='PercentComplete'/><Value Type='Integer'>1</Value></Neq><IsNull><FieldRef Name='AssignedTo'/></IsNull></And></And></Where>"+
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"StartDate\" /></OrderBy>";

				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"TaskHierarchy\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "All Unassigned Tasks", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);
				//===============My Active Tasks=======================================
				strQuery = 
					"<Where><And><Neq><FieldRef Name='PercentComplete'/><Value Type='Number'>1</Value></Neq><Eq><FieldRef Name='AssignedTo'/><Value Type='Integer'><UserID/></Value></Eq></And></Where>"+
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>" +
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";

				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"Status\" /><FieldRef Name=\"Priority\" /><FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Work\" /><FieldRef Name=\"PercentComplete\" /><FieldRef Name=\"TaskHierarchy\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "My Active Tasks", ndViewFields, ndQuery, ndRowLimit ,"HTML", true);

				//===============Project Milestones=======================================
				strQuery = 
					"<Where><Eq><FieldRef Name='Milestone'/><Value Type='Integer'>1</Value></Eq></Where>"+
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>"+
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";
				
				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Actual_x0020_Finish\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "Project Milestones", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);

				//===============Project Late Milestones=======================================
				strQuery = 
					"<Where><And><Neq><FieldRef Name='PercentComplete'/><Value Type='Number'>1</Value></Neq><And><Lt><FieldRef Name='DueDate'/><Value Type='Text'><Today/></Value></Lt><Eq><FieldRef Name='Milestone'/><Value Type='Integer'>1</Value></Eq></And></And></Where>"+
					"<GroupBy Collapse='FALSE' GroupLimit='100'><FieldRef Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'/></GroupBy>"+
                    "<OrderBy><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"taskorder\" /></OrderBy>";
				
				strRowLimit = "100";

				strViewFields = "<FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"DueDate\" /><FieldRef Name=\"Actual_x0020_Finish\" />";

				xmlDoc = new System.Xml.XmlDocument();

				ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query","");
				ndRowLimit = xmlDoc.CreateNode(XmlNodeType.Element, "RowLimit","");
				ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields","");

				ndQuery.InnerXml = strQuery;
				ndRowLimit.InnerXml = strRowLimit;
				ndViewFields.InnerXml = strViewFields;

				retNode = spViews.AddView(Connect.getProperty("EPMLiveTCList", pj), "Project Late Milestones", ndViewFields, ndQuery, ndRowLimit ,"HTML", false);



				return "0";
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
				System.Windows.Forms.MessageBox.Show("Soap Error CMTV: " + ex1.Message.ToString() + "\r\n" + ex1.Detail,"Cancel");
				return "-1";
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error CMTV: " + ex.Message.ToString(),"Cancel");
				return "-1";
			}
		}
		
		private static string createMyTasks(SPSLists.Lists spLists, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				System.Xml.XmlNode xmlRet = spLists.AddList(Connect.getProperty("EPMLiveTCList", pj),"",107);
				XmlNode ndList = spLists.GetList(Connect.getProperty("EPMLiveTCList", pj));
				XmlNode ndVersion = ndList.Attributes["Version"];
				string listName = ndList.Attributes["ID"].Value;

				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
				XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
				XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
				XmlAttribute ndModerationAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Moderation", "");

				XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

				ndTitleAttrib.Value = Connect.getProperty("EPMLiveTCList", pj);
				ndModerationAttrib.Value = "FALSE";
                ndDescriptionAttrib.Value = "Use the " + Connect.getProperty("EPMLiveTCList", pj) + " list to keep track of tasks and activities that your team needs to work on.  Using the \"Project Publisher\" add-in, tasks can be published and updated using Microsoft Office Project.";
				ndProperties.Attributes.Append(ndTitleAttrib);
				ndProperties.Attributes.Append(ndDescriptionAttrib);
				ndProperties.Attributes.Append(ndModerationAttrib);

				ndDeleteFields.InnerXml =
					"<Method ID='1'><Field Name='Task Group'/></Method>" + 
					"<Method ID='2'><Field Name='Description'/></Method>";

				ndNewFields.InnerXml = 
					"<Method ID='7'><Field Type='DateTime' Name='ActualStart' Format='DateOnly' DisplayName='Actual Start'  ShowInNewForm='FALSE'/></Method>" + 
					"<Method ID='8'><Field Type='DateTime' Name='ActualFinish' Format='DateOnly' DisplayName='Actual Finish'  ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='9'><Field Type='Text' Name='taskuid' DisplayName='taskuid'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Hidden='TRUE'/></Method>" + 
					"<Method ID='10'><Field Type='Number' Name='Duration' DisplayName='Duration'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					"<Method ID='11'><Field Type='Number' Name='ActualDuration' DisplayName='Actual Duration'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='12'><Field Type='Currency' Name='Cost' DisplayName='Cost'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					"<Method ID='13'><Field Type='Currency' Name='ActualCost' DisplayName='Actual Cost'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					"<Method ID='14'><Field Type='Number' Name='Work' DisplayName='Work'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					"<Method ID='15'><Field Type='Number' Name='ActualWork' DisplayName='Actual Work'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='16'><Field Type='Note' Name='Notes' DisplayName='Notes'  RichText='TRUE'/></Method>" +
					"<Method ID='17'><Field Type='Number' Name='taskorder' DisplayName='taskorder'  ShowInEditForm='FALSE' ShowInNewForm='FALSE'/></Method>" + 
					"<Method ID='18'><Field Type='Boolean' Name='Milestone' DisplayName='Milestone'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Description='Edits to this field do not sync with Microsoft Project'/></Method>" +
					"<Method ID='19'><Field Type='Boolean' Name='Critical' DisplayName='Critical'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Description='Edits to this field do not sync with Microsoft Project'/></Method>" +
					"<Method ID='20'><Field Type='Boolean' Name='IsAssignment' DisplayName='IsAssignment'  ShowInEditForm='FALSE' ShowInNewForm='FALSE' Hidden='FALSE'/></Method>" +
					"<Method ID='21'><Field Type='Lookup' Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "' DisplayName='" + Connect.getProperty("EPMLiveTCListPC", pj) + "' Required='TRUE' ShowInEditForm='FALSE' List='" + projectReportsList + "' ShowField='Title'/></Method>" + 
					"<Method ID='22'><Field Type='Note' Name='TaskHierarchy' DisplayName='TaskHierarchy' ShowInEditForm='FALSE'  ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='23'><Field Type='Text' Name='WBS' DisplayName='WBS' ShowInEditForm='FALSE'  ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='24'><Field Type='Text' Name='OutlineNumber' DisplayName='OutlineNumber' ShowInEditForm='FALSE' ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='25'><Field Type='DateTime'  Format='DateOnly' Name='Deadline' DisplayName='Deadline' ShowInEditForm='FALSE'  ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='36'><Field Type='DateTime' Name='LastPublished' DisplayName='LastPublished' Hidden='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='31'><Field Type='Text' Name='PublisherApprovalStatus' DisplayName='Publisher Approval Status' ShowInEditForm='FALSE'  ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='32'><Field Type='Text' Name='PublisherApprovalComments' DisplayName='Publisher Approval Comments' ShowInEditForm='FALSE'  ShowInNewForm='FALSE'/></Method>";

				ndUpdateFields.InnerXml = 
					"<Method ID='4'><Field Type='DateTime' Name='DueDate' DisplayName='Finish' Format='DateOnly' StaticName='DueDate' Required='TRUE'><Default>[today]</Default><DefaultFormulaValue>2007-10-01T00:00:00Z</DefaultFormulaValue></Field></Method>" +
					"<Method ID='3'><Field Type='DateTime' Name='StartDate' DisplayName='Start' Format='DateOnly' StaticName='StartDate' Required='TRUE'><Default>[today]</Default><DefaultFormulaValue>2007-10-01T00:00:00Z</DefaultFormulaValue></Field></Method>" +
					"<Method ID='26'><Field Type='Text' Name='Title' DisplayName='Task Name' Required='TRUE'  ShowInEditForm='TRUE' Description='Edits to this field do not sync with Microsoft Project'/></Method>" +
					"<Method ID='27'><Field Type='UserMulti' List='UserInfo' Name='AssignedTo' DisplayName='Assigned To' StaticName='AssignedTo' Required='FALSE' Group='' ShowField='ImnName' UserSelectionMode='PeopleAndGroups' UserSelectionScope='0' Mult='TRUE' Sortable='FALSE' Version='1' RowOrdinal='0'/></Method>" +
					"<Method ID='29'><Field Type='Number' Name='PercentComplete' DisplayName='% Complete' Percentage='TRUE'  ShowInEditForm='TRUE' ShowInNewForm='FALSE' Max='1'/></Method>";

				try
				{
					XmlNode ndReturn = spLists.UpdateList(listName, ndProperties, ndNewFields, ndUpdateFields, ndDeleteFields, ndVersion.Value);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Message:\n" + ex.Message + "\nStackTrace:\n" + ex.StackTrace);
				}
				return "0";
			}
			catch(Exception ex)
			{
				if(ex.Message.ToString().IndexOf("401") >= 0)
				{
					MessageBox.Show("You do not have access to create lists on that site.");
					return "-2";
				}
				System.Windows.Forms.MessageBox.Show("Error CL: " + ex.Message.ToString() + ex.StackTrace,"Cancel");
				return "-1";
			}
		}
		private static string createResourceCenter(SPSLists.Lists spLists, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				System.Xml.XmlNode xmlRet = spLists.AddList("Resource Center","",100);
				XmlNode ndList = spLists.GetList("Resource Center");
				XmlNode ndVersion = ndList.Attributes["Version"];
				string listName = ndList.Attributes["ID"].Value;

				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
				XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
				XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
				XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

				ndTitleAttrib.Value = "Resource Center";
				ndDescriptionAttrib.Value = "Use the Resource Center list to keep track of projects and portfolio item status.  Using the \"Project Publisher\" add-in, Resource information can be published using Microsoft Office Project. Information entered in this list will not be updated in Microsoft Office Project.";

				ndProperties.Attributes.Append(ndTitleAttrib);
				ndProperties.Attributes.Append(ndDescriptionAttrib);

				ndNewFields.InnerXml = 
					"<Method ID='3'><Field Type='Boolean' Name='Overallocated' DisplayName='Overallocated' /></Method>" +
					"<Method ID='4'><Field Type='Number' Name='Work' DisplayName='Work'  Decimals='2'><Default>0</Default></Field></Method>" +
					"<Method ID='5'><Field Type='Number' Name='ActualWork' DisplayName='Actual Work'  Decimals='2'><Default>0</Default></Field></Method>" +
					
					"<Method ID='7'><Field Type='Number' Name='BaselineWork' DisplayName='Baseline Work'  Decimals='2'><Default>0</Default></Field></Method>" +
					
					"<Method ID='8'><Field Type='Calculated' Name='RemainingWork' DisplayName='Remaining Work' ResultType='Number' Decimals='2'><Formula>=Work-[Actual Work]</Formula><FieldRefs><FieldRef Name='Actual Work' /><FieldRef Name='Work' /></FieldRefs></Field></Method>" +
					
					"<Method ID='9'><Field Type='Number' Name='WorkPercentComplete' DisplayName='Work % Complete'  Percentage='TRUE'><Default>0</Default></Field></Method>" +
					"<Method ID='6'><Field Type='Lookup' Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "' DisplayName='" + Connect.getProperty("EPMLiveTCListPC", pj) + "' ShowInEditForm='TRUE' List='" + projectReportsList + "'/></Method>";

				ndUpdateFields.InnerXml = "<Method ID='10'>" +
					"<Field Type='Text' Name='Title' DisplayName='Name' Required='TRUE'  ShowInEditForm='TRUE'  ShowInNewForm='TRUE' />" +
					"</Method>";

				try
				{
					XmlNode ndReturn = spLists.UpdateList(listName, ndProperties, ndNewFields, ndUpdateFields, null, ndVersion.Value);
				}

				catch (Exception ex)
				{
					MessageBox.Show("Message:\n" + ex.Message + "\nStackTrace:\n" + ex.StackTrace);
				}


				return "0";
			}
			catch(Exception ex)
			{
				if(ex.Message.ToString().IndexOf("401") >= 0)
				{
					MessageBox.Show("You do not have access to create lists on that site.");
					return "-2";
				}
				System.Windows.Forms.MessageBox.Show("Error CL: " + ex.Message.ToString(),"Cancel");
				return "-1";
			}
		}
		private static string createProjectReports(SPSLists.Lists spLists, Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				System.Xml.XmlNode xmlRet = spLists.AddList(Connect.getProperty("EPMLivePCList", pj),"",107);

				XmlNode ndList = spLists.GetList(Connect.getProperty("EPMLivePCList", pj));
				XmlNode ndVersion = ndList.Attributes["Version"];
				string listName = ndList.Attributes["ID"].Value;
				projectReportsList = ndList.Attributes["ID"].Value;
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
				XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
				XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
				XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
				XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

				ndTitleAttrib.Value = Connect.getProperty("EPMLivePCList", pj);
                ndDescriptionAttrib.Value = "Use the " + Connect.getProperty("EPMLivePCList", pj) + " list to keep track of projects and portfolio item status.  Using the \"Project Publisher\" add-in, Project information can be published using Microsoft Office Project.   Information entered in this list will not be updated in Microsoft Office Project.";

				ndProperties.Attributes.Append(ndTitleAttrib);
				ndProperties.Attributes.Append(ndDescriptionAttrib);

				ndDeleteFields.InnerXml=
					"<Method ID='1'><Field Name='Task Group'/></Method>" + 
					"<Method ID='2'><Field Name='Description'/></Method>" +
					"<Method ID='3'><Field Name='StartDate'/></Method>" + 
					"<Method ID='4'><Field Name='DueDate'/></Method>";

				ndNewFields.InnerXml = 
					"<Method ID='5'><Field Type='DateTime' Name='Start' Format='DateOnly' DisplayName='Start'  Required='TRUE'/></Method>" + 
					"<Method ID='6'><Field Type='DateTime' Name='Finish' Format='DateOnly' DisplayName='Finish'  Required='TRUE'/></Method>" +

					"<Method ID='7'><Field Type='Number' Name='Priority' DisplayName='Priority'  ShowInEditForm='TRUE' ShowInNewForm='TRUE' Decimals='0' Description='Enter a numeric value between 0 and 1000 to indicate the priority of this project; this value will be used to prioritize your portfolio of projects.  The default value is 500.'><Default>500</Default></Field></Method>" +
					"<Method ID='8'><Field Type='DateTime' Name='ActualStart' Format='DateOnly' DisplayName='Actual Start' FromBaseType='FALSE' ShowInNewForm='FALSE'/></Method>" + 
					"<Method ID='9'><Field Type='DateTime' Name='ActualFinish' Format='DateOnly' DisplayName='Actual Finish' FromBaseType='FALSE' ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='10'><Field Type='Number' Name='Duration' DisplayName='Duration' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					"<Method ID='11'><Field Type='Number' Name='ActualDuration' DisplayName='Actual Duration' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +

					"<Method ID='12'><Field Type='Currency' Name='Cost' DisplayName='Cost' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='TRUE' Decimals='2'><Default>0</Default></Field></Method>" + 
					"<Method ID='13'><Field Type='Currency' Name='ActualCost' DisplayName='Actual Cost' FromBaseType='FALSE' ShowInEditForm='TRUE' ShowInNewForm='FALSE' Decimals='2'><Default>0</Default></Field></Method>" + 
					"<Method ID='14'><Field Type='Number' Name='Work' DisplayName='Work' FromBaseType='FALSE' ShowInEditForm='TRUE' ShowInNewForm='TRUE' Decimals='2'><Default>0</Default></Field></Method>" + 
					"<Method ID='15'><Field Type='Number' Name='ActualWork' DisplayName='Actual Work' FromBaseType='FALSE' ShowInEditForm='TRUE' ShowInNewForm='FALSE' Decimals='2'><Default>0</Default></Field></Method>" +
					
					"<Method ID='16'><Field Type='Number' Name='BaselineDuration' DisplayName='Baseline Duration' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='17'><Field Type='DateTime' Name='BaselineStart' DisplayName='Baseline Start' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Format='DateOnly'/></Method>" +
					"<Method ID='18'><Field Type='DateTime' Name='BaselineFinish' DisplayName='Baseline Finish' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Format='DateOnly'/></Method>" +
					"<Method ID='19'><Field Type='Currency' Name='BaselineCost' DisplayName='Baseline Cost' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='20'><Field Type='Number' Name='BaselineWork' DisplayName='Baseline Work' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					
					"<Method ID='21'><Field Type='Calculated' Name='RemainingWork' DisplayName='Remaining Work' ResultType='Number' Decimals='2'><Formula>=Work-[Actual Work]</Formula><FieldRefs><FieldRef Name='Actual Work' /><FieldRef Name='Work' /></FieldRefs></Field></Method>" +
					"<Method ID='22'><Field Type='Calculated' Name='RemainingCost' DisplayName='Remaining Cost' ResultType='Number' Decimals='2'><Formula>=Cost-[Actual Cost]</Formula><FieldRefs><FieldRef Name='Actual Cost' /><FieldRef Name='Cost' /></FieldRefs></Field></Method>" +
					
					"<Method ID='23'><Field Type='Number' Name='RemainingDuration' DisplayName='Remaining Duration' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='24'><Field Type='Number' Name='WorkVariance' DisplayName='Work Variance' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" +
					"<Method ID='25'><Field Type='Currency' Name='CostVariance' DisplayName='Cost Variance' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>" + 
					
					"<Method ID='27'><Field Type='Currency' Name='FixedCost' DisplayName='Fixed Cost' FromBaseType='FALSE' ShowInEditForm='FALSE' ShowInNewForm='FALSE' Decimals='2'/></Method>";
					
				ndUpdateFields.InnerXml = 
					"<Method ID='29'><Field Type='Text' Name='Title' DisplayName='Project Name' Required='TRUE'  ShowInEditForm='TRUE'/></Method>" +
					"<Method ID='30'><Field Type='Number' Name='PercentComplete' DisplayName='% Complete' Percentage='TRUE'  ShowInEditForm='TRUE' ShowInNewForm='FALSE'/></Method>" +
					"<Method ID='31'><Field Type='User' Name='AssignedTo' DisplayName='Owner'  ShowInEditForm='TRUE' ShowInNewForm='TRUE'/></Method>" + 
					"<Method ID='32'><Field Type='Choice' Name='Status' DisplayName='Status'  ShowInEditForm='TRUE' ShowInNewForm='TRUE'><CHOICES><CHOICE>Complete</CHOICE><CHOICE>Future Project</CHOICE><CHOICE>Late</CHOICE><CHOICE>No Data</CHOICE><CHOICE>On Schedule</CHOICE></CHOICES></Field></Method>";

				try
				{
					XmlNode ndReturn = spLists.UpdateList(listName, ndProperties, ndNewFields, ndUpdateFields, ndDeleteFields, ndVersion.Value);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Message:\n" + ex.Message + "\nStackTrace:\n" + ex.StackTrace);
				}
				return "0";
			}
			catch(Exception ex)
			{
				if(ex.Message.ToString().IndexOf("401") >= 0)
				{
					MessageBox.Show("You do not have access to create lists on that site.");
					return "-2";
				}
				System.Windows.Forms.MessageBox.Show("Error CL: " + ex.Message.ToString(),"Cancel");
				return "-1";
			}
		}
	}
}
