using System;
using System.Windows.Forms;
using System.Xml;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for DeleteProject.
	/// </summary>
	public class DeleteProject
	{
		public DeleteProject() 
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void deleteProject(Microsoft.Office.Interop.MSProject.Project pj)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Deleting Resources...";
			frmStatus.Show();
			frmStatus.Refresh();

			try
			{

                SPSLists.Lists spList = Connection.GetListService(Connection.url);

                try
                {
                    if(!Connect.isProjServer)
                    {
                        //deleteListItemsByProject(pj, spList, "Resource Center");
                    }
                }
                catch { }

				frmStatus.label1.Text = "Deleting Tasks...";
				frmStatus.Refresh();

                try
                {
                    //deleteListItemsByProject(pj, spList, Connect.getProperty("EPMLiveTCList", pj));
                }
                catch { }

				frmStatus.label1.Text = "Deleting Project...";
				frmStatus.Refresh();
	
				deleteProjectCenter(pj,spList);

				frmStatus.Dispose();
				MessageBox.Show("Your project has been successfully deleted");
			}
			catch(Exception ex)
			{
				frmStatus.Dispose();
				MessageBox.Show("Error deleting project: " + ex.Message);
			}
			

			
		}

		private static void deleteProjectCenter(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList)
		{
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
				XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
				XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

				ndQueryOptions.InnerXml = "";
				ndViewFields.InnerXml = "<FieldRef Name=\"Title\"/>";
				ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Value></Eq></Where>";
				XmlNode ndListItems = null;
				try
				{
					ndListItems = spList.GetListItems(Connect.getProperty("EPMLivePCList", pj), string.Empty, ndQuery, ndViewFields, "150", ndQueryOptions, string.Empty);
				}
				catch (System.Web.Services.Protocols.SoapException ex)
				{
                    MessageBox.Show("Error Reading " + Connect.getProperty("EPMLivePCList", pj) + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
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
						}
					}
				}
				if(id != "")
				{
					deleteItems(spList,"<Method ID='1' Cmd='Delete'><Field Name='ID'>" + id + "</Field></Method>", Connect.getProperty("EPMLivePCList", pj));
				}
		}


		private static void deleteListItemsByProject(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList, string list)
		{
			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
			XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
			XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

			ndQueryOptions.InnerXml = "";
			ndViewFields.InnerXml = "<FieldRef Name=\"Title\"/>";
            ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\"/><Value Type=\"Text\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Value></Eq></Where>";
			XmlNode ndListItems = null;

			try
			{
				ndListItems = spList.GetListItems(list, string.Empty, ndQuery, ndViewFields, "0", ndQueryOptions, string.Empty);
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
				MessageBox.Show("Error Reading " + list + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
			}

			string strBatch = "";
			int methodId = 1;

			foreach(XmlNode nd in ndListItems.ChildNodes[1])
			{
				if(nd.OuterXml.Trim() != "")
				{
					strBatch = strBatch + 
						"<Method ID='" + methodId++ + "' Cmd='Delete'>" + 
						"<Field Name='ID'>" + nd.Attributes["ows_ID"].Value + "</Field></Method>";
					if(methodId >= 100)
					{
						deleteItems(spList, strBatch,list);
						strBatch = "";
						methodId = 1;
					}
				}
			}
			if(methodId > 1)
			{
				deleteItems(spList,strBatch,list);
			}
		}
		private static string deleteItems(SPSLists.Lists spList, string strBatch,string list)
		{
			try
			{
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				elBatch.InnerXml = strBatch;

				XmlNode ndReturn = spList.UpdateListItems(list, elBatch);
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Error Deleting Items: " + ex.Message.ToString() + "\n\n\n" + ex.StackTrace.ToString());
			}
			
			return "0";
		}
	}
}
