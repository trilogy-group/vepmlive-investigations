using System;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.MSProject;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for Publish.
	/// </summary>
	public class PublishPerf
	{
		private Microsoft.Office.Interop.MSProject.Application app;
		private static FormStatus frmStatus;
		private static int pubType;
		private static string projectID;
		private static string [] breadCrumb = new string[100];
		private static Hashtable breadCrumbHash;
		private static Hashtable allTaskHash;
		private static Hashtable allAssnHash;
		private static NumberFormatInfo provider;
		private static NumberFormatInfo cprovider;
		private static string strErrors;


		public PublishPerf(Microsoft.Office.Interop.MSProject.Application app)
		{
			this.app = app;
		}

		public static Microsoft.Office.Interop.MSProject.Project replaceResourcesV2(Microsoft.Office.Interop.MSProject.Project pj)
		{

			if(CheckResources.resCount == 0)
				return pj;

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

			if(hshResFields.Contains(field))
			{
				int fieldId = (int)hshResFields[field];
				foreach(CheckResources.resListStruct res in CheckResources.resList)
				{
					if(res.newRes)
					{
						Resource r = pj.Resources.Add(res.name,System.Reflection.Missing .Value);
						Connect.setResField(fieldId,r,res.resId.ToString());
					}
					//else
					//if(res.changed)
				{
					foreach(Resource r in pj.Resources)
					{
						if(r.UniqueID == res.matchedResID)
						{
							r.Name = res.name;
							r.EMailAddress = res.email;
							if(res.changed)
								Connect.setResField(fieldId,r,res.resId.ToString());
						}
					}
					
				}
				}
			}

			return pj;
		}

		public static Microsoft.Office.Interop.MSProject.Project replaceResources(Microsoft.Office.Interop.MSProject.Project pj)
		{
			frmStatus = new FormStatus();
			frmStatus.Show();
			try
			{
				frmStatus.label1.Text = "Replacing Resources...";
				frmStatus.Refresh();

                SPSUserGroup.UserGroup spUserGroup = Connection.GetUserGroupService(Connection.url);

				bool spsFailed = false;

				for(int i=0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].changed)
					{
						foreach(Resource res in pj.Resources)
						{
							if(res != null)
							{
								if(res.UniqueID == CheckResources.resList[i].matchedResID)
								{
									res.EMailAddress = CheckResources.resList[i].email;
									res.Name = CheckResources.resList[i].name.Replace(",",";");
									break;
								}
							}
						}
					}
					if(CheckResources.resList[i].sharepointChange && !spsFailed)
					{
						try
						{
							spUserGroup.UpdateUserInfo(CheckResources.resList[i].userLogin,CheckResources.resList[i].name.Replace("&","&amp;"),CheckResources.resList[i].email,"");
						}
						catch(System.Exception ex)
						{
							spsFailed = true;
							if(ex.Message.IndexOf("401") > 0)
							{
								MessageBox.Show("You do not have permissions to modify User E-mail addresses.\n\nYou must have your administrator either add E-mail addresses for each user or give you permissions to modify users.");
							}
							else
								MessageBox.Show("Error updating SharePoint user information, because:\n\n" + ex.Message);
						}
					}
					if(CheckResources.resList[i].newRes)
					{
						CheckResources.resList[i].newRes = false;
						Resource res = pj.Resources.Add(CheckResources.resList[i].name,System.Reflection.Missing.Value);
						res.EMailAddress = CheckResources.resList[i].email;
					}
				}
			}
			catch{}
			frmStatus.Dispose();
			return pj;
		}

		public static string publish(Microsoft.Office.Interop.MSProject.Project pj, string []sPropList)
		{
           
			strErrors = "";
			//breadCrumb = new string[1024];

			provider = new NumberFormatInfo( );

			provider.NumberDecimalSeparator = ".";
			provider.NumberGroupSeparator = ",";
			provider.NumberGroupSizes = new int[ ] { 3 };

			cprovider = new NumberFormatInfo();

			cprovider.NumberDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			cprovider.NumberGroupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
			cprovider.NumberGroupSizes = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes;

			if(Connect.getProperty("EPMLiveType",pj) == "True")
				pubType = 1;
			else
				pubType = 0;

			bool v2ResMap = false;
			if(Connection.resUrl != "")
				v2ResMap = true;

			if(v2ResMap)
				pj = replaceResourcesV2(pj);
			else
				pj = replaceResources(pj);

			frmStatus = new FormStatus();
			frmStatus.Show();

			try
			{
				//app.ScreenUpdating = true;
                SPSLists.Lists spList = Connection.GetListService(Connection.url);
				
				frmStatus.label1.Text = "Saving Project...";
				frmStatus.Refresh();
                string ret = "";

				if(processProjectCenter(pj,spList,sPropList) == "0")
				{
					ret = processTasks(pj, v2ResMap, frmStatus);
					if(v2ResMap)
						processResourcesV2(pj, spList);
					else
						processResources(pj, spList);
				}
			
				frmStatus.Hide();
				frmStatus.Refresh();
				frmStatus.Dispose();


                if (ret == "0")
                {
                    DialogResult dr = MessageBox.Show("Your project has been queued for publishing. Would you like to generate an email to send to your team?", "Success", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        string subject = "Tasks have been updated on Project " + Connection.getProjectName(pj);
                        string body = "Project: " + Connection.getProjectName(pj) + "\r\n\r\nPlease visit: " + Connect.getProperty("EPMLiveURL", pj).Replace(" ", "%20") + " to update your task status";

                        MapiMailMessage message = new MapiMailMessage(subject, body);
                        foreach (Resource res in pj.Resources)
                        {
                            if (res != null)
                            {
                                for (int i = 0; i < CheckResources.resCount; i++)
                                {
                                    if (CheckResources.resList[i].matchedResID == res.UniqueID)
                                    {
                                        //MessageBox.Show(res.Name);
                                        if (res.EMailAddress != "")
                                            message.Recipients.Add(res.EMailAddress);
                                    }
                                }
                            }
                        }

                        message.ShowDialog();
                    }
                }
				return "0";
			}
			catch (System.Exception ex)
			{
				frmStatus.Dispose();
				MessageBox.Show("Error Publishing: " + ex.Message);
				return "-1";
			}
		}

		private static void processResourcesV2(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList)
		{
			
		}

		private static string processResources(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList)
		{
			frmStatus.label1.Text = "Reading Resource Information...";
			frmStatus.Refresh();

			Hashtable myHash = new Hashtable();

			foreach(Resource res in pj.Resources)
			{
				if(res!=null)
				{
					for(int i = 0;i<CheckResources.resCount;i++)
					{
						if(CheckResources.resList[i].matchedResID == res.UniqueID)
						{
							if(!myHash.Contains(res.Name))
								myHash.Add(res.Name,res.ID);
						}
					}
				}
			}

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
				ndListItems = spList.GetListItems("Resource Center", string.Empty, ndQuery, ndViewFields, "0", ndQueryOptions, string.Empty);
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
				frmStatus.Dispose();
				MessageBox.Show("Error Reading Resource Center:\n" + ex.Message + "\n\n" + ex.StackTrace);
				return "-1";
			}


			string strBatch = "";
			int methodId = 1;
			int counter = 1;
			frmStatus.label1.Text = "Processing Current Resources...";
			frmStatus.progressBar1.Maximum = int.Parse(ndListItems.ChildNodes[1].Attributes["ItemCount"].Value);
			frmStatus.Refresh();
			counter=1;
			foreach(XmlNode nd in ndListItems.ChildNodes[1])
			{
				if(nd.OuterXml.Trim() != "")
				{
					string title = "";
					try
					{
						title = nd.Attributes["ows_Title"].Value;
					}
					catch(System.Exception){}
					//MessageBox.Show(title);
					if(myHash.Contains(title))
					{
						Resource res = pj.Resources[int.Parse(myHash[title].ToString())];
						strBatch = strBatch + buildResString(res, false, methodId, nd.Attributes["ows_ID"].Value, pj);
						myHash.Remove(title);
					}
					else
					{
						strBatch = strBatch + 
							"<Method ID='" + methodId + "' Cmd='Delete'>" + 
							"<Field Name='ID'>" + nd.Attributes["ows_ID"].Value + "</Field></Method>";
					}
					methodId++;
					frmStatus.progressBar1.Value = counter;
					frmStatus.Refresh();
					if(methodId >= 100)
					{
						pushResources(spList,strBatch);
						strBatch = "";
						methodId = 1;
						frmStatus.label1.Text = "Processing Current Resources...";
						frmStatus.Refresh();
					}
					counter++;
				}
			}

			frmStatus.label1.Text = "Processing New Resources...";
			frmStatus.progressBar1.Maximum = myHash.Keys.Count;
			frmStatus.Refresh();
			counter=1;
			foreach(DictionaryEntry myItem in myHash)
			{
				Resource res = pj.Resources[int.Parse(myItem.Value.ToString())];
				strBatch = strBatch + buildResString(res, true, methodId, "", pj);
				methodId++;
				frmStatus.progressBar1.Value = counter++;
				frmStatus.Refresh();
				if(methodId >= 100)
				{
					pushResources(spList,strBatch);
					strBatch = "";
					methodId = 1;
					frmStatus.label1.Text = "Processing New Resources...";
					frmStatus.Refresh();
				}
			}

			if(methodId>1)
				pushResources(spList,strBatch);
			//frmStatus.Dispose();

			return "0";
		}

		private static string pushResources(SPSLists.Lists spList, string strBatch)
		{
			try
			{
				frmStatus.label1.Text = "Uploading Resources...";
				frmStatus.Refresh();

				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				elBatch.InnerXml = strBatch;

				XmlNode ndReturn = spList.UpdateListItems("Resource Center", elBatch);
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Error Uploading Resources: " + ex.Message.ToString() + "\n\n\n" + ex.StackTrace.ToString());
			}
			
			return "0";
		}

		private static string processProjectCenter(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList, string []sPropList)
		{
			try
			{
				frmStatus.label1.Text = "Reading Project Information...";
				frmStatus.Refresh();

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
					//MessageBox.Show(ndListItems.OuterXml);
				}
				catch (System.Web.Services.Protocols.SoapException ex)
				{
					frmStatus.Dispose();
                    MessageBox.Show("Error Reading " + Connect.getProperty("EPMLivePCList", pj) + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
					return "-1";
				}

				bool found = false;
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
							found = true;
						}
					}
				}
			
				frmStatus.label1.Text = "Updating Project Information...";
				frmStatus.Refresh();

				string strBatch = "";
				if(!found)
				{
					strBatch = 
						"<Method ID='1' Cmd='New'>" +
						"<Field Name='Title'><![CDATA[" + Connection.getProjectName(pj) + "]]></Field>";
				}
				else
				{
					strBatch = "<Method ID='1' Cmd='Update'>" + 
						"<Field Name='ID'>" + id + "</Field>";
				}

				//strBatch = strBatch + "<Field Name='PercentComplete'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.PercentComplete.ToString(),provider) / 100.0),provider) + "</Field>";
				//				strBatch = appendDateTime(pj.Start.ToString(), strBatch, "Start");
				//				strBatch = appendDateTime(pj.Finish.ToString(), strBatch, "Finish");
				//strBatch = appendDateTime(pj.ProjectSummaryTask.ActualStart.ToString(), strBatch, "Actual_x0020_Start");
				//strBatch = appendDateTime(pj.ProjectSummaryTask.ActualFinish.ToString(), strBatch, "Actual_x0020_Finish");
				//strBatch = strBatch + "<Field Name='Duration'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.Duration.ToString(),provider) / 480.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Actual_x0020_Duration'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.ActualDuration.ToString(),provider) / 480.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Cost'>" + pj.ProjectSummaryTask.Cost.ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Actual_x0020_Cost'>" + pj.ProjectSummaryTask.ActualCost.ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Work'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.Work.ToString(),provider) / 60.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Actual_x0020_Work'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.ActualWork.ToString(),provider) / 60.0),provider) + "</Field>";
			
				//strBatch = strBatch + "<Field Name='Baseline_x0020_Duration'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.BaselineDuration.ToString(),provider) / 480.0),provider) + "</Field>";
				//strBatch = appendDateTime(pj.ProjectSummaryTask.BaselineStart.ToString(), strBatch, "Baseline_x0020_Start");
				//strBatch = appendDateTime(pj.ProjectSummaryTask.BaselineFinish.ToString(), strBatch, "Baseline_x0020_Finish");
				//strBatch = strBatch + "<Field Name='Baseline_x0020_Cost'>" + pj.ProjectSummaryTask.BaselineCost.ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Baseline_x0020_Work'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.BaselineWork.ToString(),provider) / 60.0),provider) + "</Field>";

				//strBatch = strBatch + "<Field Name='Remaining_x0020_Work'>" + (float.Parse(pj.ProjectSummaryTask.RemainingWork.ToString()) / 60.0).ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Remaining_x0020_Cost'>" + pj.ProjectSummaryTask.RemainingCost.ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Remaining_x0020_Duration'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.RemainingDuration.ToString(),provider) / 480.0),provider) + "</Field>";

				//strBatch = strBatch + "<Field Name='Work_x0020_Variance'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.WorkVariance.ToString(),provider) / 60.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Cost_x0020_Variance'>" + pj.ProjectSummaryTask.CostVariance.ToString() + "</Field>";

				//strBatch = strBatch + "<Field Name='Work_x0020__x0025__x0020_Complet'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.PercentWorkComplete.ToString(),provider) / 100.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Physical_x0020__x0025__x0020_Com'>" + Convert.ToString((Convert.ToDouble(pj.ProjectSummaryTask.PhysicalPercentComplete.ToString(),provider) / 100.0),provider) + "</Field>";
				//strBatch = strBatch + "<Field Name='Fixed_x0020_Cost'>" + pj.ProjectSummaryTask.FixedCost.ToString() + "</Field>";
				//strBatch = strBatch + "<Field Name='Priority0'>" + pj.Priority.ToString() + "</Field>";

				switch(pj.ProjectSummaryTask.Status)
				{
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
						strBatch = strBatch + "<Field Name='Status'>Complete</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
						strBatch = strBatch + "<Field Name='Status'>Future Project</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
						strBatch = strBatch + "<Field Name='Status'>Late</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
						strBatch = strBatch + "<Field Name='Status'>No Data</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
						strBatch = strBatch + "<Field Name='Status'>On Schedule</Field>";
						break;
				};

				if(Connect.projectCenterFields != null)
				{
					foreach(DictionaryEntry entry in Connect.projectCenterFields)
					{
                        if(entry.Value != null)
                            strBatch = strBatch + "<Field Name='" + entry.Key.ToString() + "'><![CDATA[" + entry.Value.ToString() + "]]></Field>";
                        else
                            strBatch = strBatch + "<Field Name='" + entry.Key.ToString() + "'></Field>";
					}
				}

				strBatch = strBatch + buildProjectCustomFields(pj);

				strBatch = strBatch + "</Method>";

				xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				elBatch.InnerXml = strBatch;

                XmlNode ndReturn = spList.UpdateListItems(Connect.getProperty("EPMLivePCList", pj), elBatch);

				if(ndReturn.OuterXml.IndexOf("<ErrorCode>0x81020014</ErrorCode>")>0)
				{
                    MessageBox.Show("Your " + Connect.getProperty("EPMLivePCList", pj) + " list does not appear to contain the correct column structure. You will need to recreate that list with the current version of Project Publisher.");
					return "-1";
				}
				projectID = ndReturn.ChildNodes[0]["z:row"].Attributes["ows_ID"].Value + ";#" + ndReturn.ChildNodes[0]["z:row"].Attributes["ows_Title"].Value;
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
                MessageBox.Show("Error Updating " + Connect.getProperty("EPMLivePCList", pj) + ":\n\n" + ex1.Message.ToString() + "\r\n\r\n" + ex1.Detail.OuterXml);
			}
			catch(System.Exception ex)
			{
                MessageBox.Show("Error Updating " + Connect.getProperty("EPMLivePCList", pj) + ":\n\n" + ex.Message.ToString());
			}
			return "0";
		}

		public float parseNumber(string num, float divisor)
		{
			MessageBox.Show(System.Globalization.RegionInfo.CurrentRegion.Name);
			return 0;
		}

		private static string processTasks(Microsoft.Office.Interop.MSProject.Project pj, bool v2ResMap, FormStatus frmStatus)
		{
            
            breadCrumbHash = new Hashtable();

            EPMLiveWorkEngine.WorkEngineAPI oAPI = Connection.GetWorkEngineService(Connection.url);

            frmStatus.progressBar1.Maximum = pj.Tasks.Count;
            frmStatus.label1.Text = "Getting Project Location...";
            frmStatus.Refresh();

            XmlDocument docRet = new XmlDocument();
            docRet.LoadXml(oAPI.Execute("GetProjectInfoFromName", "<Project List=\"" + Connect.getProperty("EPMLivePCList", pj) + "\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Project>"));

            XmlNode nd = docRet.FirstChild;

            if (nd.Attributes["Status"].Value == "0")
            {

                string ID = nd.FirstChild.Attributes["ProjectId"].Value;

                StringBuilder sb = new StringBuilder("<Project ID=\"" + ID.Split('.')[2] + "\" PlannerID=\"" + Connect.getProperty("EPMLivePlanner", pj) + "\" >");

                frmStatus.progressBar1.Maximum = pj.Tasks.Count;
                frmStatus.label1.Text = "Processing Tasks...";
                frmStatus.Refresh();
                int count = 0;
                int refCount = 0;

                foreach(Task tsk in pj.Tasks)
                {
                    if (!(tsk == null) && tsk.ExternalTask.ToString().ToLower() == "false" && (Convert.ToString(tsk.Active).ToLower() == "true"))
                    {
                        if (tsk.Summary.ToString() == "False" || Connect.getProperty("EPMLivePubSummary", pj) == "True")
                        {
                            if (!breadCrumbHash.Contains(tsk.UniqueID.ToString()))
                                breadCrumbHash.Add(tsk.UniqueID.ToString(), buildCrumbs(tsk.OutlineLevel));

                            sb.Append(buildTaskString(tsk, pj, pubType, v2ResMap));

                            if (pubType == 1)
                            {
                                foreach (Assignment assn in tsk.Assignments)
                                {
                                    frmStatus.Refresh();
                                    sb.Append(buildAssnString(tsk, assn, v2ResMap, pj));
                                }
                            }
                            if (tsk.Summary.ToString() == "True")
                                breadCrumb[tsk.OutlineLevel] = tsk.Name;
                            count++;
                            refCount++;
                            if (refCount == 10)
                            {
                                frmStatus.progressBar1.Value = count;
                                frmStatus.Refresh();
                                refCount = 0;
                            }
                        }
                        else
                        {
                            breadCrumb[tsk.OutlineLevel] = tsk.Name;
                        }
                    }

                }

                string processWorkData = processPfEWork(pj);
                sb.Append(processWorkData);

                sb.Append("</Project>");

                frmStatus.progressBar1.Maximum = pj.Tasks.Count;
                frmStatus.label1.Text = "Uploading Project Schedule...";
                frmStatus.Refresh();
                frmStatus.progressBar1.Maximum = 1;
                frmStatus.progressBar1.Value = 1;

                docRet = new XmlDocument();
                docRet.LoadXml(oAPI.Execute("Publish", sb.ToString()));

                

                nd = docRet.FirstChild;

                if (nd.Attributes["Status"].Value == "0")
                {
                    return "0";
                }
                else
                {
                    MessageBox.Show("Error Uploading Project: " + nd.FirstChild.InnerText);
                    return "1";
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                MessageBox.Show("Error Retrieving Project ID: " + nd.FirstChild.InnerText);
                return "1";
            }
		}

        private static string processPfEWork(Microsoft.Office.Interop.MSProject.Project pj)
        {
            string sData = string.Empty;
            try
            {
                string ProjectList = Connect.getProperty("EPMLivePCList", pj);

                Hashtable hshResFields = new Hashtable();
                foreach (Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
                {
                    try
                    {
                        string fieldName = val.ToString();
                        if (fieldName.Length > 16 && fieldName.Substring(0, 16) == "pjResourceNumber")
                        {
                            hshResFields.Add(fieldName.Substring(10), (int)val);
                        }
                    }
                    catch { }
                }

                string field = Connect.getProperty("EPMLiveResField", pj);
                if (field == "")
                    field = "Number15";
                int fieldId = 0;
                if (hshResFields.Contains(field))
                {
                    fieldId = (int)hshResFields[field];
                }

                string itemprojid = projectID;
                itemprojid = itemprojid.Replace(";#", "\n").Split('\n')[0];

                sData = "<UpdateScheduledWork><Params Worktype=\"2\"/><Data><Project ID='" + itemprojid + "' List='" + ProjectList + "'>";

                foreach (Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
                {
                    if (Connect.getResField(fieldId, res) != "")
                    {
                        sData += "<Resource Id=\"" + Connect.getResField(fieldId, res) + "\">";
                        TimeScaleValues tsvs = res.TimeScaleData(pj.ProjectStart, pj.ProjectFinish, PjResourceTimescaledData.pjResourceTimescaledWork, PjTimescaleUnit.pjTimescaleDays);
                        foreach (TimeScaleValue tsv in tsvs)
                        {
                            try
                            {
                                float val = float.Parse(tsv.Value.ToString()) / 60;
                                sData += "<Work Date=\"" + DateTime.Parse(tsv.StartDate.ToString()).ToString("s") + "\" Hours=\"" + val + "\"/>";
                            }
                            catch { }
                        }
                        sData += "</Resource>";
                    }
                }
                sData += "</Project></Data></UpdateScheduledWork>";
            }
            catch 
            {
                // Setting up empty data instead of providing improper XML in case it errors out.
                sData = string.Empty;
            }
            return sData;
        }

		private static string getAssnString(Task tsk, bool v2ResMap)
		{
			string assnString = "";
			foreach(Assignment assn in tsk.Assignments)
			{
				for(int i = 0;i<CheckResources.resCount;i++)
				{
					if(CheckResources.resList[i].matchedResID == assn.ResourceUniqueID)
					{
						if(v2ResMap)
						{
							if(CheckResources.resList[i].ResourceID != 0)
								assnString = assnString + ";#" + CheckResources.resList[i].ResourceID + ";#" + CheckResources.resList[i].name.Replace(";","");
						}
						else
							assnString = assnString + ";#" + CheckResources.resList[i].resId.ToString() + ";#" + assn.ResourceName.Replace(";","");
					}
				}
			}

			if(assnString.Length >2)
				assnString = assnString.Substring(2);

			return assnString;
		}

		private static string buildResString(Resource res, bool isNew, int methodId, string itemId, Microsoft.Office.Interop.MSProject.Project pj)
		{
			string retVal = "";
			if(isNew)
			{
				retVal = 
					"<Method ID='" + methodId + "' Cmd='New'>" +
					"<Field Name='Title'><![CDATA[" + res.Name + "]]></Field>";
			}
			else
			{
				retVal = "<Method ID='" + methodId + "' Cmd='Update'>" + 
					"<Field Name='ID'>" + itemId + "</Field>";	
			}
			retVal = retVal + "<Field Name='Overallocated'>" + res.Overallocated + "</Field>";
			retVal = retVal + "<Field Name='Work'>" + Convert.ToString((Convert.ToDouble(res.Work.ToString(),provider) / 60.0),provider) + "</Field>";
			retVal = retVal + "<Field Name='Actual_x0020_Work'>" + Convert.ToString((Convert.ToDouble(res.ActualWork.ToString(),provider) / 60.0),provider) + "</Field>";
			retVal = retVal + "<Field Name='Baseline_x0020_Work'>" + Convert.ToString((Convert.ToDouble(res.BaselineWork.ToString(),provider) / 60.0),provider) + "</Field>";
			//retVal = retVal + "<Field Name='Remaining_x0020_Work'>" + (float.Parse(res.RemainingWork.ToString()) / 60.0).ToString() + "</Field>";
			retVal = retVal + "<Field Name='Work_x0020__x0025__x0020_Complet'>" + Convert.ToString((Convert.ToDouble(res.PercentWorkComplete.ToString(),provider) / 100.0),provider) + "</Field>";
			retVal = retVal + "<Field Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'><![CDATA[" + projectID + "]]></Field>";

			retVal = retVal + "</Method>";
			return retVal;
		}

		private static string buildTaskString(Task tsk, Microsoft.Office.Interop.MSProject.Project pj, int pubType, bool v2ResMap)
		{

			string retVal = "";
		    retVal = "<Task ID='" + tsk.ID + "' UID='" + tsk.UniqueID + "'>";
			retVal = retVal + "<Title><![CDATA[" + tsk.Name + "]]></Title>";
			retVal = retVal + "<Field Name='WBS'>" + tsk.WBS + "</Field>";
			retVal = retVal + "<Field Name='taskorder'>" + tsk.ID.ToString() + "</Field>";
			retVal = retVal + "<Field Name='IsAssignment'>0</Field>";
			retVal = retVal + "<Field Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'><![CDATA[" + projectID + "]]></Field>";
            DateTime lp = DateTime.Now.AddSeconds(60);
            retVal = retVal + "<Field Name='LastPublished'>" + lp.Year.ToString() + "-" + lp.Month.ToString() + "-" + lp.Day.ToString() + " " + lp.Hour.ToString() + ":" + lp.Minute.ToString() + ":" + lp.Second.ToString() + "</Field>";
            if(pubType != 1)
            {
                if(Connect.hTaskCenterFields.Contains("ASSIGNEDTO"))
                    retVal = retVal + "<Field Name='AssignedTo'>" + getAssnString(tsk, v2ResMap) + "</Field>";
            }
            else
            {
                if(Connect.hTaskCenterFields.Contains("ASSIGNEDTO"))
                    retVal = retVal + "<Field Name='AssignedTo'></Field>";
            }

            if(Connect.hTaskCenterFields.Contains("TASKHIERARCHY"))
            {
                if(breadCrumbHash.Contains(tsk.UniqueID.ToString()))
                {
                    Connect.TaskField tf = (Connect.TaskField)Connect.hTaskCenterFields["TASKHIERARCHY"];
                    retVal = retVal + "<Field Name='" + tf.wssFieldName + "'><![CDATA[" + breadCrumbHash[tsk.UniqueID.ToString()] + "]]></Field>";
                }
            }
			
			if(Connect.hTaskCenterFields.Contains("MSPROJECTSTATUS"))
			{
				switch(tsk.Status)
				{
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
						retVal = retVal + "<Field Name='MSProjectStatus'>Complete</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
						retVal = retVal + "<Field Name='MSProjectStatus'>Future Task</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
						retVal = retVal + "<Field Name='MSProjectStatus'>Late</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
						retVal = retVal + "<Field Name='MSProjectStatus'>No Data</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
						retVal = retVal + "<Field Name='MSProjectStatus'>On Schedule</Field>";
						break;
				};
			}
			if(Connect.hTaskCenterFields.Contains("STATUS"))
			{
				switch(tsk.Status)
				{
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
						retVal = retVal + "<Field Name='Status'>Completed</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
						retVal = retVal + "<Field Name='Status'>Not Started</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
						retVal = retVal + "<Field Name='Status'>In Progress</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
						retVal = retVal + "<Field Name='Status'>Not Started</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
						retVal = retVal + "<Field Name='Status'>In Progress</Field>";
						break;
				};
			}
			retVal = retVal + buildCustomFields(tsk, null);

			retVal = retVal + "</Task>";

			return retVal;
		}

		private static string buildCustomFields(Task tsk, Assignment assn)
		{
			string retVal = "";
			if(Connect.hTaskCenterFields != null)
			{
				if(Connect.hTaskCenterFields.Count > 0)
				{
					foreach(DictionaryEntry entry in Connect.hTaskCenterFields)
					{
						string sField = entry.Key.ToString().ToUpper();
						
						Connect.TaskField tskField = (Connect.TaskField)entry.Value;

						if(sField == "TASKTYPE")
							sField = "TYPE";
						if(sField == "PHYSICAL_X0020__X0025__X0020_COM")
							sField = "PHYSICALPERCENTCOMPLETE";

						int iField = 0;
						if(Connect.hPprojectFields.Contains(sField))
						{
							try
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hPprojectFields[sField];
								iField = tField.fieldId;
							}
							catch{}
							if(tskField.wssFieldName == "TimesheetHours")
								iField = 0;
                            
							else if(iField != 0)
							{
								string sFieldVal = "";
                                if (iField == 188743715)
                                {
                                    if (assn == null)//Task Based Publishing
                                        sFieldVal = tsk.Start.ToString();
                                    else
                                        sFieldVal = assn.Start.ToString();
                                }
                                else if (iField == 188743716)
                                {
                                    if (assn == null)//Task Based Publishing
                                        sFieldVal = tsk.Finish.ToString();
                                    else
                                        sFieldVal = assn.Finish.ToString();
                                }
                                else
                                {
                                    if (assn == null)//Task Based Publishing
                                    {
                                        try
                                        {
                                            if (tskField.fieldName == "Notes")
                                                sFieldVal = tsk.Notes;
                                            else
                                                sFieldVal = tsk.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        sFieldVal = Publish.getFieldForAssignment(tsk, assn, iField);
                                        //MessageBox.Show(sField + " " + iField.ToString());
                                    }
                                    if (tskField.type == 8)
                                    {
                                        int dash = sFieldVal.IndexOf(" - ");
                                        if (dash > 0)
                                        {
                                            sFieldVal = sFieldVal.Substring(0, dash) + ";#" + sFieldVal.Substring(dash + 3);
                                        }
                                    }
                                }
								retVal = retVal + addCustomField(sFieldVal, entry, iField, tsk);
							}
						}
					}
				}
			}
			//retVal = retVal.Replace("Issue1","1;#Issue1");
			return retVal;
			
		}

		private static string buildProjectCustomFields(Project pj)
		{
			string retVal = "";
			if(Connect.hProjectCenterFields != null)
			{
				if(Connect.hProjectCenterFields.Count > 0)
				{
					foreach(DictionaryEntry entry in Connect.hProjectCenterFields)
					{
						string sField = entry.Key.ToString().ToUpper();
						if(sField == "MSPROJECTSTATUS")
						{
							switch(pj.ProjectSummaryTask.Status)
							{
								case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
									retVal = retVal + "<Field Name='MSProjectStatus'>Complete</Field>";
									break;
								case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
									retVal = retVal + "<Field Name='MSProjectStatus'>Future Task</Field>";
									break;
								case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
									retVal = retVal + "<Field Name='MSProjectStatus'>Late</Field>";
									break;
								case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
									retVal = retVal + "<Field Name='MSProjectStatus'>No Data</Field>";
									break;
								case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
									retVal = retVal + "<Field Name='MSProjectStatus'>On Schedule</Field>";
									break;
							};
						}
						else
						{
							int iField = 0;
							if(Connect.hPprojectFields.Contains(sField))
							{
								try
								{
									Connect.TaskField tField = (Connect.TaskField)Connect.hPprojectFields[sField];
									iField = tField.fieldId;
								}
								catch{}
								if(iField != 0)
								{
									string sFieldVal = "";
									try
									{
										sFieldVal = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
									}
									catch{}
									retVal = retVal + addCustomField(sFieldVal, entry, iField, pj.ProjectSummaryTask);
								}
							}
						}
					}
				}
			}
			return retVal;
		}
		
		private static string addCustomField(string sFieldVal, DictionaryEntry entry, int iField, Microsoft.Office.Interop.MSProject.Task task)
		{
			string retVal = "";
			
			

			sFieldVal = sFieldVal.Replace((char)11,' ').Replace("\r","<br><br>").Replace("\v","<br>");

			Connect.TaskField tskField = (Connect.TaskField)entry.Value;
			
			string fName = tskField.wssFieldName;

			if(fName == null || fName == "")
				fName = tskField.wssFieldName;

			if(tskField.type == 4)
			{
				if(sFieldVal != "NA")
				{
					retVal = appendDateTime(sFieldVal,retVal,fName,task,iField);
				}
				else
					retVal = "<Field Name='" + fName + "'></Field>";
			}
			else if(tskField.type == 5)
			{
				if(sFieldVal.ToLower() == "yes" || sFieldVal.ToLower() == "true")
					retVal = "<Field Name='" + fName + "'>1</Field>";
				else
					retVal = "<Field Name='" + fName + "'>0</Field>";
			}
			else if(tskField.type == 2 || tskField.type == 3)
			{
				if(sFieldVal.IndexOf("(") >= 0 && sFieldVal.IndexOf(")") == sFieldVal.Length-1)
				{
					sFieldVal = "-" + sFieldVal.Substring(1,sFieldVal.Length - 2);
				}

				MatchCollection mc = Regex.Matches(sFieldVal, @"(-*\d*[,\.]*\d*)*");

				if (mc.Count > 0)
				{
					sFieldVal = "";
					foreach(Match m in mc)
					{
						if(m.Value != null && m.Value.Trim() != "")
						{
							sFieldVal += m.Value;
						}
					}
				}

				double sVal = 0;

				try
				{
					
					sVal = Convert.ToDouble(sFieldVal);
					switch(iField)
					{
						case 188743712:
							sVal = sVal /100;
							break;
						case 188743843:
						case 188744851:
						case 188744856:
							sVal = sVal / 60.0;
							break;
						case 188743714:
						case 188743711:
							sVal = sVal / 480.0;
							break;
						case 188744799:
							sVal = sVal / 100.0;
							break;
					}
				}
				catch
				{
					int ins = sFieldVal.LastIndexOf(" ");
					if(ins > 0)
					{
						sFieldVal = sFieldVal.Substring(0,ins);
					}
					try
					{
						//MessageBox.Show(tskField.fieldName + "   " + sFieldVal);
						sVal = Convert.ToDouble(sFieldVal);

					}
					catch{}
				}
				
				
				retVal = "<Field Name='" + fName + "'>" + Convert.ToString(sVal,provider) + "</Field>";
			}
			else if(tskField.type == 9)
			{

			}
			else
			{
				retVal = "<Field Name='" + fName + "'><![CDATA[" + sFieldVal + "]]></Field>";
			}
			return retVal;
		}

		private static string buildAssnString(Task tsk, Assignment assn, bool v2ResMap, Microsoft.Office.Interop.MSProject.Project pj)
		{

            string retVal = "";
            retVal = "<Task ID='" + tsk.ID + "' UID='" + tsk.UniqueID +"." + assn.UniqueID + "'>";
            retVal = retVal + "<Title><![CDATA[" + tsk.Name + "]]></Title>";
            retVal = retVal + "<Field Name='WBS'>" + tsk.WBS + "</Field>";
            retVal = retVal + "<Field Name='taskorder'>" + tsk.ID.ToString() + "</Field>";
            retVal = retVal + "<Field Name='IsAssignment'>1</Field>";
            retVal = retVal + "<Field Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'><![CDATA[" + projectID + "]]></Field>";

            if (Connect.hTaskCenterFields.Contains("ASSIGNEDTO"))
            {
                string assnString = "";
                for (int i = 0; i < CheckResources.resCount; i++)
                {
                    if (CheckResources.resList[i].matchedResID == assn.ResourceUniqueID)
                    {
                        if (v2ResMap)
                        {
                            if (CheckResources.resList[i].ResourceID != 0)
                                assnString = CheckResources.resList[i].ResourceID.ToString() + ";#" + CheckResources.resList[i].name.Replace(";", "");
                        }
                        else
                            assnString = CheckResources.resList[i].resId.ToString() + ";#" + assn.ResourceName.Replace(";", "");
                        break;
                    }
                }
                
                retVal = retVal + "<Field Name='AssignedTo'>" + assnString + "</Field>";
            }

            if (Connect.hTaskCenterFields.Contains("TASKHIERARCHY"))
            {
                if (breadCrumbHash.Contains(tsk.UniqueID.ToString()))
                {
                    Connect.TaskField tf = (Connect.TaskField)Connect.hTaskCenterFields["TASKHIERARCHY"];
                    retVal = retVal + "<Field Name='" + tf.wssFieldName + "'><![CDATA[" + breadCrumbHash[tsk.UniqueID.ToString()] + "]]></Field>";
                }
            }

            if (Connect.hTaskCenterFields.Contains("MSPROJECTSTATUS"))
            {
                switch (tsk.Status)
                {
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
                        retVal = retVal + "<Field Name='MSProjectStatus'>Complete</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
                        retVal = retVal + "<Field Name='MSProjectStatus'>Future Task</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
                        retVal = retVal + "<Field Name='MSProjectStatus'>Late</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
                        retVal = retVal + "<Field Name='MSProjectStatus'>No Data</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
                        retVal = retVal + "<Field Name='MSProjectStatus'>On Schedule</Field>";
                        break;
                };
            }
            if (Connect.hTaskCenterFields.Contains("STATUS"))
            {
                switch (tsk.Status)
                {
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjComplete:
                        retVal = retVal + "<Field Name='Status'>Completed</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
                        retVal = retVal + "<Field Name='Status'>Not Started</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
                        retVal = retVal + "<Field Name='Status'>In Progress</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
                        retVal = retVal + "<Field Name='Status'>Not Started</Field>";
                        break;
                    case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
                        retVal = retVal + "<Field Name='Status'>In Progress</Field>";
                        break;
                };
            }
            retVal = retVal + buildCustomFields(tsk, assn);

            retVal = retVal + "</Task>";

            return retVal;
		}

		private static string buildCrumbs(int level)
		{
			string ret = "";
			for(int i = 1;i<level;i++)
			{
				ret = ret + " > " + breadCrumb[i];
			}
			if(ret.Length > 2)
				ret = ret.Substring(2);
			return ret;
		}

        public static string appendDateTime(string date, string str, string field, Microsoft.Office.Interop.MSProject.Task task, int iField)
        {
            try
            {
                string sFieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString().Substring(6);
                //DateTime.ParseExact(, "\\'yy MMM dd", CultureInfo.InvariantCulture)
                DateTime dt = (DateTime)typeof(Microsoft.Office.Interop.MSProject.Task).GetProperty(sFieldName).GetValue(task, null);

                return str + "<Field Name='" + field + "'>" + dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + "</Field>";
            }
            catch(System.Exception)
            {
                return str + "<Field Name='" + field + "'></Field>";
            }
        }
	}
}
