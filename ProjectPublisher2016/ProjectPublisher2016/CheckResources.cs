using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for CheckResources.
	/// </summary>
	public class CheckResources
	{
		public class resListStruct
		{
			public string name;
			public string email;
			public int matchedResID;
			public bool changed;
			public bool newRes;
			public int resId;
			public int ResourceID;
			public string userLogin;
			public bool sharepointChange;
		};
		//public static Microsoft.Office.Interop.MSProject.Project pj;
		public static resListStruct[] resList;
		public static int resCount;
		public CheckResources()
		{

		}

		private static DataTable getRequests()
		{
			try
			{
                WSSService.Service wss = Connection.GetWSSService(Connection.url);

				DataTable dt = new DataTable();
			
				DataSet ds = wss.getWebRequests();
			
				return ds.Tables[0];
			}
			catch(System.Exception)
			{
				return new DataTable();
			}
		}

		public static bool checkV2(bool clear, Microsoft.Office.Interop.MSProject.Project pj)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Downloading Resources...";
			frmStatus.Show();
			frmStatus.Refresh();

            SPSLists.Lists spList = Connection.GetListService(Connection.resUrl);
            SPSUserGroup.UserGroup spUserGroup = Connection.GetUserGroupService(Connection.url);
			
			Hashtable hshEmails = new Hashtable();

			try
			{
				XmlNode ndUsers = spUserGroup.GetUserCollectionFromSite();
				foreach(XmlNode ndUser in ndUsers.FirstChild.ChildNodes)
				{
					try
					{
						hshEmails.Add(ndUser.Attributes["ID"].Value,ndUser.Attributes["Email"].Value);
					}
					catch{}
				}
			}
			catch{}

			try
			{
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
				XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
				XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");
				ndQueryOptions.InnerXml = "";
				ndViewFields.InnerXml = 
					"<FieldRef Name=\"Title\"/><FieldRef Name=\"SharePointAccount\"/>";

				XmlNode ndListItems = null;

				ndListItems = spList.GetListItems("Resources",string.Empty,ndQuery,ndViewFields,"0",ndQueryOptions,string.Empty);
				
				SortedList lstResources = new SortedList();

				foreach(XmlNode ndData in ndListItems.ChildNodes)
				{
					if(ndData.Name == "rs:data")
					{
						foreach(XmlNode ndChild in ndData.ChildNodes)
						{
							if(ndChild.Name == "z:row")
							{
								string spsRes = "";
								string spResId = "";
								string id = ndChild.Attributes["ows_ID"].Value;
								string title = "";
								try
								{
									title = ndChild.Attributes["ows_Title"].Value;
								}
								catch{}
								string email = "";
								if(title != "")
								{
									try
									{
										spsRes = ndChild.Attributes["ows_SharePointAccount"].Value.Replace(";#","\n").Split('\n')[1];
										spResId = ndChild.Attributes["ows_SharePointAccount"].Value.Replace(";#","\n").Split('\n')[0];
										try
										{
											email = hshEmails[spResId].ToString();
										}
										catch{}
									}
									catch{}
									lstResources.Add(title + id, id + "\n" + title + "\n" + spsRes + "\n" + spResId + "\n" + email);
								}
							}
						}
					}
				}

				ArrayList arrNewRes = new ArrayList();
				Hashtable hshMapRes = new Hashtable();

				if(!clear)
				{
					foreach(resListStruct res in resList)
					{
						if(res.newRes)
							arrNewRes.Add(res.resId);
						if(res.changed)
							hshMapRes.Add(res.resId, res.matchedResID);
					}
				}

				Hashtable hshResFields = new Hashtable();
				foreach(Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
				{
					try
					{
						string fieldName = val.ToString();
						if(fieldName.Length > 16 && fieldName.Substring(0,16) == "pjResourceNumber")
						{
							hshResFields.Add(fieldName.Substring(10),(int)val);
						}
					}
					catch{}	
				}

				string field = Connect.getProperty("EPMLiveResField",pj);
				if(field == "")
					field = "Number15";
				int fieldId = 0;
				if(hshResFields.Contains(field))
				{
					fieldId = (int)hshResFields[field];
				}

				resList = new resListStruct[lstResources.Count];
				int counter = 0;
				CheckResources.resCount = 0;
				foreach(DictionaryEntry de in lstResources)
				{
					string []vals = de.Value.ToString().Split('\n');
					resList[counter] = new resListStruct();
					resList[counter].name = vals[1];
					resList[counter].resId = int.Parse(vals[0]);
					resList[counter].email = vals[4];
					
					if(vals[3].Trim() != "")
						resList[counter].ResourceID = int.Parse(vals[3]);
					else
						resList[counter].ResourceID = 0;

					if(arrNewRes.Contains(resList[counter].resId))
						resList[counter].newRes = true;

					if(hshMapRes.Contains(resList[counter].resId))
					{
						resList[counter].changed = true;
						resList[counter].matchedResID = int.Parse(hshMapRes[resList[counter].resId].ToString());
					}
					else
					{
						if(fieldId != 0)
						{
							foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
							{
								if(int.Parse(Connect.getResField(fieldId, res)) == resList[counter].resId)
								{
									resList[counter].matchedResID = res.UniqueID;
								}
							} 
						}
					}
					//resList[counter].email = vals[2];
					counter++;
					CheckResources.resCount++;
				}
			}
			catch(System.Web.Services.Protocols.SoapException)
			{
				MessageBox.Show("Error downloading resources. Make sure your site contains a Resources list.");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			frmStatus.Dispose();

			return true;
		}

        public static bool checkV3(bool clear, Microsoft.Office.Interop.MSProject.Project pj)
        {
            FormStatus frmStatus = new FormStatus();
            frmStatus.label1.Text = "Downloading Resources...";
            frmStatus.Show();
            frmStatus.Refresh();

            SPSUserGroup.UserGroup spUserGroup = Connection.GetUserGroupService(Connection.url);

            Hashtable hshEmails = new Hashtable();

            try
            {
                XmlNode ndUsers = spUserGroup.GetUserCollectionFromSite();
                foreach(XmlNode ndUser in ndUsers.FirstChild.ChildNodes)
                {
                    try
                    {
                        hshEmails.Add(ndUser.Attributes["ID"].Value, ndUser.Attributes["Email"].Value);
                    }
                    catch { }
                }
            }
            catch { }
            

            try
            {
                SortedList lstResources = new SortedList();

                EPMLiveWorkEngine.WorkEngineAPI api = Connection.GetWorkEngineService(Connection.url);

                string projInfo = api.Execute("GetPublisherItemInfo", "<Settings><![CDATA[" + pj.Name + "]]></Settings>");

                XmlDocument docProjInfo = new XmlDocument();
                docProjInfo.LoadXml(projInfo);
                XmlNode ndRes = docProjInfo.FirstChild.FirstChild;

                string sAPIRes = "<Team/>";

                if(ndRes != null && ndRes.Attributes["ListId"] != null && ndRes.Attributes["ItemId"] != null)
                {
                    sAPIRes = api.Execute("GetTeam", "<Team ListId=\"" + ndRes.Attributes["ListId"].Value + "\" ItemId=\"" + ndRes.Attributes["ItemId"].Value + "\"/>");
                }
                else
                {
                    sAPIRes = api.Execute("GetTeam", "");
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sAPIRes);

                foreach(XmlNode nd in doc.FirstChild.SelectNodes("//Team/Member"))
                {
                    string email = "";
                    string title = nd.Attributes["Title"].Value;
                    string spResId = nd.Attributes["SPID"].Value;
                    string id = nd.Attributes["ID"].Value;
                    string spsRes = nd.Attributes["SharePointAccount"].Value;
                    try
                    {
                        email = hshEmails[spResId].ToString();
                    }
                    catch { }

                    lstResources.Add(title + id, id + "\n" + title + "\n" + spsRes + "\n" + spResId + "\n" + email);
                }

                ArrayList arrNewRes = new ArrayList();
                Hashtable hshMapRes = new Hashtable();

                if(!clear)
                {
                    foreach(resListStruct res in resList)
                    {
                        if(res.newRes)
                            arrNewRes.Add(res.resId);
                        if(res.changed)
                            hshMapRes.Add(res.resId, res.matchedResID);
                    }
                }

                Hashtable hshResFields = new Hashtable();
                foreach(Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
                {
                    try
                    {
                        string fieldName = val.ToString();
                        if(fieldName.Length > 16 && fieldName.Substring(0, 16) == "pjResourceNumber")
                        {
                            hshResFields.Add(fieldName.Substring(10), (int)val);
                        }
                    }
                    catch { }
                }

                string field = Connect.getProperty("EPMLiveResField", pj);
                if(field == "")
                    field = "Number15";
                int fieldId = 0;
                if(hshResFields.Contains(field))
                {
                    fieldId = (int)hshResFields[field];
                }

                resList = new resListStruct[lstResources.Count];
                int counter = 0;
                CheckResources.resCount = 0;
                foreach(DictionaryEntry de in lstResources)
                {
                    string[] vals = de.Value.ToString().Split('\n');
                    resList[counter] = new resListStruct();
                    resList[counter].name = vals[1];
                    resList[counter].resId = int.Parse(vals[0]);
                    resList[counter].email = vals[4];

                    if(vals[3].Trim() != "")
                        resList[counter].ResourceID = int.Parse(vals[3]);
                    else
                        resList[counter].ResourceID = 0;

                    if(arrNewRes.Contains(resList[counter].resId))
                        resList[counter].newRes = true;

                    if(hshMapRes.Contains(resList[counter].resId))
                    {
                        resList[counter].changed = true;
                        resList[counter].matchedResID = int.Parse(hshMapRes[resList[counter].resId].ToString());
                    }
                    else
                    {
                        if(fieldId != 0)
                        {
                            foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
                            {
                                if(int.Parse(Connect.getResField(fieldId, res)) == resList[counter].resId)
                                {
                                    resList[counter].matchedResID = res.UniqueID;
                                }
                            }
                        }
                    }
                    //resList[counter].email = vals[2];
                    counter++;
                    CheckResources.resCount++;
                }
                
            }
            catch(System.Web.Services.Protocols.SoapException)
            {
                MessageBox.Show("Error downloading resources. Make sure your site contains a Resources list.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            frmStatus.Dispose();

            return true;
        }

		public static resListStruct[] getResourceList(Microsoft.Office.Interop.MSProject.Project pj, FormStatus frmStatus)
		{
			resListStruct []resRet = new resListStruct[0];

			try
			{
                SPSUserGroup.UserGroup spUserGroup = Connection.GetUserGroupService(Connection.url);

				Hashtable myHash = new Hashtable();
				XmlNode xmlRet = spUserGroup.GetGroupCollectionFromWeb();
				XmlNode xmlGroups = xmlRet["Groups"];
				XmlNode xmlUsers = null;

                frmStatus.progressBar1.Visible = true;
                frmStatus.progressBar1.Maximum = xmlGroups.ChildNodes.Count + 1;

                //for(int j=0;j<xmlGroups.ChildNodes.Count;j++)
                //{
                //    string group = xmlGroups.ChildNodes[j].Attributes["Name"].Value;
                //    try
                //    {
                //        xmlRet = spUserGroup.GetUserCollectionFromGroup(group); 
                //        xmlUsers = xmlRet["Users"];
                //        for(int i = 0; i < xmlUsers.ChildNodes.Count; i++)
                //        {
                //            if(xmlUsers.ChildNodes[i].Attributes["Name"].Value.ToString() != "System Account")
                //                if(!myHash.Contains(xmlUsers.ChildNodes[i].Attributes["ID"].Value))
                //                    myHash.Add(xmlUsers.ChildNodes[i].Attributes["ID"].Value, xmlUsers.ChildNodes[i].Attributes["Name"].Value.Trim());
                //        }
                //        frmStatus.progressBar1.Value = j;
                //        frmStatus.Refresh();
                //        Application.DoEvents();
                //    }
                //    catch(System.Exception){}
                //}
                xmlRet = spUserGroup.GetUserCollectionFromSite();
				xmlUsers = xmlRet["Users"];
				for(int i=0;i<xmlUsers.ChildNodes.Count;i++)
					if(xmlUsers.ChildNodes[i].Attributes["Name"].Value.ToString() != "System Account")
						if(!myHash.Contains(xmlUsers.ChildNodes[i].Attributes["ID"].Value))
							myHash.Add(xmlUsers.ChildNodes[i].Attributes["ID"].Value,xmlUsers.ChildNodes[i].Attributes["Name"].Value.Trim());

				resRet = new resListStruct[myHash.Count];
				int counter = 0;
				foreach(DictionaryEntry de in myHash)
				{
					resRet[counter] = new resListStruct();
					resRet[counter].name = de.Value.ToString();
					resRet[counter].resId = int.Parse(de.Key.ToString());
					counter++;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error downloading Resource List: " + ex.Message);
			}
			return resRet;
		}

		public static string check(bool clear, Microsoft.Office.Interop.MSProject.Project pj)
		{

            SPSUserGroup.UserGroup spUserGroup = Connection.GetUserGroupService(Connection.url);
			
			Hashtable newReses = new Hashtable();
			Hashtable updatedReses = new Hashtable();
			Hashtable spReses = new Hashtable();
			if(!clear)
			{
				for(int i = 0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].newRes == true)
					{
						newReses.Add(resList[i].name,resList[i].email + ";" + resList[i].resId);
					}
					if(CheckResources.resList[i].changed == true)
					{
						updatedReses.Add(resList[i].resId, resList[i].matchedResID);
					}
					if(CheckResources.resList[i].sharepointChange == true)
					{
						spReses.Add(resList[i].resId, resList[i].email);
					}
				}
			}

			Hashtable myHash = new Hashtable();
			XmlNode xmlRet = spUserGroup.GetGroupCollectionFromWeb();
			XmlNode xmlGroups = xmlRet["Groups"];
			XmlNode xmlUsers = null;
			for(int j=0;j<xmlGroups.ChildNodes.Count;j++)
			{
				string group = xmlGroups.ChildNodes[j].Attributes["Name"].Value;
				try
				{
					xmlRet = spUserGroup.GetUserCollectionFromGroup(group);
					xmlUsers = xmlRet["Users"];
					for(int i=0;i<xmlUsers.ChildNodes.Count;i++)
						if(xmlUsers.ChildNodes[i].Attributes["Name"].Value.ToString() != "System Account")
							if(!myHash.Contains(xmlUsers.ChildNodes[i].Attributes["ID"].Value))
								myHash.Add(xmlUsers.ChildNodes[i].Attributes["ID"].Value,xmlUsers.ChildNodes[i]);
				}
				catch(System.Exception){}
			}
			xmlRet = spUserGroup.GetUserCollectionFromWeb();
			xmlUsers = xmlRet["Users"];
			for(int i=0;i<xmlUsers.ChildNodes.Count;i++)
				if(xmlUsers.ChildNodes[i].Attributes["Name"].Value.ToString() != "System Account")
					if(!myHash.Contains(xmlUsers.ChildNodes[i].Attributes["ID"].Value))
						myHash.Add(xmlUsers.ChildNodes[i].Attributes["ID"].Value,xmlUsers.ChildNodes[i]);

			DataTable dt = getRequests();
			foreach(DataRow dr in dt.Rows)
			{
				string name = dr["firstName"].ToString()+ " " + dr["lastName"].ToString();
				
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml("<User ID=\"" + dr["ID"].ToString() + "\" Name=\"" + name + "\" Email=\"" + dr["email"].ToString() + "\"/>");
				if(!myHash.Contains(xmlDoc.FirstChild.Attributes["ID"].Value.Trim()))
					myHash.Add(xmlDoc.FirstChild.Attributes["ID"].Value.Trim(), xmlDoc.FirstChild);
			}

			int resMatch = 0;
			resCount = 0;
			resList = new resListStruct[myHash.Keys.Count];

			try
			{
				foreach(DictionaryEntry entry in myHash)
				{
					XmlNode nd = (XmlNode)entry.Value;
					resList[resCount] = new resListStruct();
					resList[resCount].name = nd.Attributes["Name"].Value.Trim();
					resList[resCount].email = nd.Attributes["Email"].Value.Trim();
					resList[resCount].userLogin = nd.Attributes["LoginName"].Value;
					resList[resCount].resId = int.Parse(nd.Attributes["ID"].Value);

					foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
					{
						if(res!=null)
						{
							if(nd.Attributes["Email"].Value.ToLower().Trim() == res.EMailAddress.ToLower().Trim() && res.EMailAddress.Trim() != "" && nd.Attributes["Email"].Value.Trim() != "")
							{
								if(nd.Attributes["Name"].Value != res.Name)
								{
									resList[resCount].changed = true;
									resList[resCount].name = nd.Attributes["Name"].Value;
								}
								resList[resCount].matchedResID = res.UniqueID;
								resList[resCount].ResourceID = res.ID;
								resMatch++;
							}
						}
					}
					resCount++;
				}
			}
			catch(System.Exception)
			{
				//MessageBox.Show(ex.Message.ToString() + "\n\n" + ex.StackTrace.ToString());
			}

			foreach(DictionaryEntry entry in newReses)
			{
				for(int i = 0;i<CheckResources.resCount;i++)
				{
					if(entry.Key.ToString() == CheckResources.resList[i].name)
					{
						CheckResources.resList[i].newRes = true;
					}
				}
			}

			foreach(DictionaryEntry entry in updatedReses)
			{
				for(int i = 0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].resId.ToString() == entry.Key.ToString())
					{
						CheckResources.resList[i].matchedResID = int.Parse(entry.Value.ToString());
						CheckResources.resList[i].changed = true;
					}
				}
			}

			foreach(DictionaryEntry entry in spReses)
			{
				for(int i = 0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].resId.ToString() == entry.Key.ToString())
					{
						CheckResources.resList[i].email = entry.Value.ToString();
						CheckResources.resList[i].sharepointChange = true;
					}
				}
			}

			if(resMatch < pj.Resources.Count)
				return "1";

			return "0";
		}
	}
}
