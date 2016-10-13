using System;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.MSProject;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for Publish.
	/// </summary>
	public class Publish
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


		public Publish(Microsoft.Office.Interop.MSProject.Application app)
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

        private static void processPfEWork(Microsoft.Office.Interop.MSProject.Project pj)
        {
            if(RegistryClass.GetSetting("Tr", "EnablePPM", "").ToLower() == "true")
            {
                frmStatus.label1.Text = "Processing Work...";
                frmStatus.Refresh();
                try
                {
                    string ProjectList = Connect.getProperty("EPMLivePCList", pj);


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

                    string itemprojid = projectID;
                    itemprojid = itemprojid.Replace(";#", "\n").Split('\n')[0];

                    string sData = "<UpdateScheduledWork><Params Worktype=\"1\"/><Data><Project ID='" + itemprojid + "' List='" + ProjectList + "'>";

                    frmStatus.progressBar1.Maximum = pj.Resources.Count;

                    int counter = 0;

                    foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
                    {
                        if(Connect.getResField(fieldId, res) != "")
                        {
                            sData += "<Resource Id=\"" + Connect.getResField(fieldId, res) + "\">";
                            TimeScaleValues tsvs = res.TimeScaleData(pj.ProjectStart, pj.ProjectFinish, PjResourceTimescaledData.pjResourceTimescaledWork, PjTimescaleUnit.pjTimescaleDays);
                            foreach(TimeScaleValue tsv in tsvs)
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
                        frmStatus.progressBar1.Value = counter++;
                        frmStatus.Refresh();
                        System.Windows.Forms.Application.DoEvents();
                    }

                    sData += "</Project></Data></UpdateScheduledWork>";

                    EPMLivePortfolioEngine.PortfolioEngineAPI pfe = Connection.GetPortfolioEngineService(Connection.url);

                    string ret = pfe.Execute("UpdateScheduledWork", sData);

                    ret = ret.Trim();
                }
                catch { }
            }
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
				if(processProjectCenter(pj,spList,sPropList) == "0")
				{
					processTasks(pj, spList, v2ResMap);
					if(v2ResMap)
						processResourcesV2(pj, spList);
					else
						processResources(pj, spList);
                    processPfEWork(pj);
				}

                

				frmStatus.Hide();
				frmStatus.Refresh();
				frmStatus.Dispose();

                //if(Connect.getProperty("EPMLiveTimePhased",pj) == "True")
                //    publishTimePhased(pj, spList);

				if(strErrors != "")
				{
					DialogResult drE = MessageBox.Show("Some tasks failed to publish. Would you like to view the errors?","Task Failures",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
					if(drE == DialogResult.Yes)
					{
						FormErrors frmErrors = new FormErrors();
						frmErrors.textBox1.Text = strErrors;
						frmErrors.ShowDialog();
						frmErrors.Dispose();
					}
				}

				DialogResult dr = MessageBox.Show("Your project has been published. Would you like to generate an email to send to your team?","Success",MessageBoxButtons.YesNo);

				if(dr == DialogResult.Yes)
				{
					string subject = "Tasks have been updated on Project " + Connection.getProjectName(pj);
					string body = "Project: " + Connection.getProjectName(pj) + "\r\n\r\nPlease visit: " + Connect.getProperty("EPMLiveURL",pj).Replace(" ","%20") + " to update your task status";

					MapiMailMessage message = new MapiMailMessage(subject, body);
					foreach(Resource res in pj.Resources)
					{
						if(res!=null)
						{
							for(int i = 0;i<CheckResources.resCount;i++)
							{
								if(CheckResources.resList[i].matchedResID == res.UniqueID)
								{
									//MessageBox.Show(res.Name);
									if(res.EMailAddress != "")
										message.Recipients.Add(res.EMailAddress);
								}
							}
						}
					}

					message.ShowDialog();
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

		private static void publishTimePhased(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList)
		{
			string url = Connection.resUrl;

            EPMLiveTimePhased.EPMLiveTimePhased tpService = Connection.GetTimePhasedService(Connection.url);

			try
			{
				tpService.getConfigSetting("temp");
			}
			catch(System.Exception ex)
			{
				if(ex.Message.IndexOf("Object moved") > 0)
				{
					FormTimePhasedAd frm = new FormTimePhasedAd();
					frm.ShowDialog();
					frm.Dispose();
					return;
				}
				else
					MessageBox.Show("Error reading Time-Phased Service: " + ex.Message);
			}

			if(url != "")
			{
				Hashtable hshDataFields = new Hashtable();

				foreach(Microsoft.Office.Interop.MSProject.PjAssignmentTimescaledData val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjAssignmentTimescaledData)))
				{
					hshDataFields.Add(val.ToString().Replace("pjAssignmentTimescaled",""),val);
				}

				FormStatus frmStatus = new FormStatus();
				frmStatus.label1.Text = "Downloading Time Phased Information...";
				frmStatus.Show();
				frmStatus.Refresh();

				try
				{

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

					string []sDataTypes = tpService.getAllValueTypes(url);
					EPMLiveTimePhased.Period []periods = tpService.getAllTimePeriods(url);

					frmStatus.label1.Text = "Rendering Time Phased Data...";
					frmStatus.progressBar1.Maximum = pj.Tasks.Count;
					frmStatus.progressBar1.Value = 0;
					frmStatus.Refresh();

					DateTime dtStart = DateTime.Now;

					string sTsData = "<Data>";
					foreach(Task task in pj.Tasks)
					{
						sTsData = sTsData + "<Task Name=\"" + task.Name + " \" WBS=\"" + task.WBS + "\">";
						foreach(Assignment assn in task.Assignments)
						{
							//assn.ResourceUniqueID
							sTsData = sTsData + "<Resource Name=\"" + assn.ResourceName + " \">";
							
							if(Connect.getResField(fieldId,pj.Resources[assn.ResourceID]) != "0")
							{
								foreach(string sDataType in sDataTypes)
								{
									if(hshDataFields.Contains(sDataType))
									{
										sTsData = sTsData + "<ValueType Name=\"" + sDataType + " \">";
										foreach(EPMLiveTimePhased.Period p in periods)
										{
											TimeSpan ts = p.end - p.start;
											Microsoft.Office.Interop.MSProject.TimeScaleValues tsvs = 
												assn.TimeScaleData
												(p.start.ToShortDateString(),
												p.end.ToShortDateString(),
												(Microsoft.Office.Interop.MSProject.PjAssignmentTimescaledData)hshDataFields[sDataType],
												Microsoft.Office.Interop.MSProject.PjTimescaleUnit.pjTimescaleDays,
												1
												);
											try
											{
												float val = 0;

												foreach(TimeScaleValue tsv in tsvs)
												{
													if(tsv.Value != null)
													{
														string sVal = Convert.ToString(tsv.Value);
														if(sVal != "")
														{
															if(sDataType.IndexOf("Work") >= 0)
																val = val + float.Parse(sVal) / (float)60;
															else
																val = val + float.Parse(sVal);
														}
													}
													Connect.NAR(tsv);
												}							  
											
												Connect.NAR(tsvs);
											
												sTsData = sTsData + "<Period Name=\"" + p.name + " \" Value=\"" + val.ToString() + "\"/>";
											}
											catch
											{
												sTsData = sTsData + "<Period Name=\"" + p.name + " \" Value=\"0\"/>";
											}
										}
										sTsData = sTsData + "</ValueType>";
									}
								}
							}
							sTsData =sTsData + "</Resource>";
						}
						sTsData =sTsData + "</Task>";
						frmStatus.progressBar1.Value = frmStatus.progressBar1.Value + 1;
						frmStatus.Refresh();
					}

					sTsData = sTsData + "</Data>";

					frmStatus.label1.Text = "Uploading Time Phased Data...";
					frmStatus.Refresh();

					if(!tpService.saveTimePhasedData(url,Connection.getProjectName(pj),sTsData))
					{
						MessageBox.Show("Time-Phased data failed to upload");
					}
				}
				catch(System.Web.Services.Protocols.SoapException ex0)
				{
					MessageBox.Show("SOAP Error Publishing Time Phased Data: " + ex0.Message);
				}
				catch(System.Exception ex)
				{
					if(ex.Message.IndexOf("Object moved") > 0)
					{
						MessageBox.Show("Your site does not appear to be set up for time-phased publishing; this feature is a component of the EPM Live Toolkit.  You may be receiving this message either because you do not have the Toolkit installed or because you have an older version of the Toolkit installed.  Please visit http://www.epmlive.com/ to purchase a Toolkit or visit the EPM Live Support Forums for instructions on how to upgrade your existing Toolkit environment.");
					}
					else
					{
						MessageBox.Show("Error Publishing Time Phased Data: " + ex.Message);
					}
				}
				frmStatus.Dispose();
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
                        if(entry.Key.ToString() != "ID")
                        {
                            if(entry.Value != null)
                                strBatch = strBatch + "<Field Name='" + entry.Key.ToString() + "'><![CDATA[" + entry.Value.ToString() + "]]></Field>";
                            else
                                strBatch = strBatch + "<Field Name='" + entry.Key.ToString() + "'></Field>";
                        }
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

		public static bool disableModeration(SPSLists.Lists spLists, Microsoft.Office.Interop.MSProject.Project pj)
		{
			XmlNode ndList = spLists.GetList(Connect.getProperty("EPMLiveTCList", pj));
			XmlNode ndVersion = ndList.Attributes["Version"];
			string listName = ndList.Attributes["ID"].Value;

			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
			XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
			XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
			XmlAttribute ndModeration = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "EnableModeration", "");
			XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

			ndTitleAttrib.Value = Connect.getProperty("EPMLiveTCList", pj);
            ndDescriptionAttrib.Value = "Use the " + Connect.getProperty("EPMLiveTCList", pj) + " list to keep track of tasks and activities that your team needs to work on.  Using the \"Project Publisher\" add-in, tasks can be published and updated using Microsoft Office Project.";
			ndModeration.Value = "False";

			ndProperties.Attributes.Append(ndTitleAttrib);
			ndProperties.Attributes.Append(ndDescriptionAttrib);
			ndProperties.Attributes.Append(ndModeration);

			try
			{

				XmlNode ndReturn = spLists.UpdateList(listName, ndProperties, null, null, null, ndVersion.Value);
				return true;

			}
			catch (System.Exception ex)
			{
				if(ex.Message.IndexOf(" 401") > 0)
					MessageBox.Show("You do not have access to publish projects to this site.");
				else
					MessageBox.Show(ex.Message.ToString());
				return false;
			}
		}

		public static bool enableModeration(SPSLists.Lists spLists, Microsoft.Office.Interop.MSProject.Project pj)
		{
			XmlNode ndList = spLists.GetList(Connect.getProperty("EPMLiveTCList", pj));
			XmlNode ndVersion = ndList.Attributes["Version"];
			string listName = ndList.Attributes["ID"].Value;

			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
			
			XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
			XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
			XmlAttribute ndModeration = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "EnableModeration", "");

			XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

			ndTitleAttrib.Value = Connect.getProperty("EPMLiveTCList", pj);
            ndDescriptionAttrib.Value = "Use the " + Connect.getProperty("EPMLiveTCList", pj) + " list to keep track of tasks and activities that your team needs to work on.  Using the \"Project Publisher\" add-in, tasks can be published and updated using Microsoft Office Project.";
			ndModeration.Value = "True";

			ndProperties.Attributes.Append(ndTitleAttrib);
			ndProperties.Attributes.Append(ndDescriptionAttrib);
			ndProperties.Attributes.Append(ndModeration);

			try
			{
				XmlNode ndReturn = spLists.UpdateList(listName, ndProperties, null, null, null, ndVersion.Value);
				return true;
			}

			catch (System.Exception)
			{
				return false;
				//MessageBox.Show("Message:\n" + ex.Message + "\nStackTrace:\n" + ex.StackTrace);
			}
		}

		private static string processTasks(Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList, bool v2ResMap)
		{
			string moderationEnabled = "";

			XmlNode tskNode = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));
			//MessageBox.Show(tskNode.OuterXml);

			try
			{
				moderationEnabled = tskNode.Attributes["EnableModeration"].Value;
			}
			catch{}

			int maxTasks = 100;

			if(moderationEnabled.ToUpper() == "TRUE")
				disableModeration(spList, pj);

			frmStatus.label1.Text = "Reading Tasks...";
			frmStatus.Refresh();

			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
			XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
			XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

			ndQueryOptions.InnerXml = "";
			ndViewFields.InnerXml = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"IsAssignment\"/><FieldRef Name=\"Modified\"/>";
            //EPML-5188 : use the project id instead project title.
            ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" LookupId=\"TRUE\" /><Value Type=\"Integer\"><![CDATA[" + Connection.getProjectIdByTitle(pj) + "]]></Value></Eq></Where>";
			XmlNode ndListItems = null;
			try
			{
				ndListItems = spList.GetListItems(Connect.getProperty("EPMLiveTCList", pj), string.Empty, ndQuery, ndViewFields, "0", ndQueryOptions, string.Empty);
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
				frmStatus.Dispose();
				MessageBox.Show("Error Reading Tasks:\n" + ex.Message + "\n\n" + ex.StackTrace);
				return "-1";
			}
			
			frmStatus.label1.Text = "Reading Tasks...";
			frmStatus.Refresh();

			string strBatch = "";
			int methodId = 1;

			string assnString = "";

			breadCrumbHash = new Hashtable();
			Hashtable myHash = new Hashtable();
			Hashtable assignmentHash = new Hashtable();
			Hashtable taskHash = new Hashtable();
			allTaskHash = new Hashtable();
			allAssnHash = new Hashtable();

			int counter = 1;

			try
			{
				frmStatus.progressBar1.Maximum = pj.Tasks.Count + 1;
				foreach(Task tsk in pj.Tasks)
				{
					if(!(tsk == null) && tsk.ExternalTask.ToString().ToLower() == "false" && (Convert.ToString(tsk.Active).ToLower() == "true"))
					{
						if(tsk.Summary.ToString() == "False" || Connect.getProperty("EPMLivePubSummary",pj) == "True")
						{
							myHash.Add(tsk.UniqueID.ToString(),tsk);
							allTaskHash.Add(tsk.UniqueID.ToString(),tsk);
							breadCrumbHash.Add(tsk.UniqueID.ToString(),buildCrumbs(tsk.OutlineLevel));
							taskHash.Add(tsk.UniqueID.ToString(),tsk);
							if(pubType==1)
							{
								int assnCounter = 1;
								foreach(Assignment assn in tsk.Assignments)
								{
									assignmentHash.Add(tsk.UniqueID.ToString() + "." + assn.UniqueID.ToString(),assn);
									allAssnHash.Add(tsk.UniqueID.ToString() + "." + assn.UniqueID.ToString(),assn);
									assnCounter++;
								}
							}
							if(tsk.Summary.ToString() == "True")
								breadCrumb[tsk.OutlineLevel] = tsk.Name;
						}
						else
						{
							breadCrumb[tsk.OutlineLevel] = tsk.Name;
						}
					}
					try
					{
						frmStatus.progressBar1.Value = counter++;
						frmStatus.Refresh();
					}
					catch{}
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Error Building Task Hash: " + ex.Message.ToString() + "\n\n\n" + ex.StackTrace.ToString());
			}

			frmStatus.label1.Text = "Processing Current Tasks...";
			frmStatus.Refresh();
			frmStatus.progressBar1.Maximum = ndListItems.ChildNodes[1].ChildNodes.Count + 1;
			counter = 1;
			frmStatus.progressBar1.Value = 0;
			string pushRet = "0";
			string modified = "";
			foreach(XmlNode nd in ndListItems.ChildNodes[1].ChildNodes)
			{
				if(nd.OuterXml.Trim() != "")
				{
					string taskuid = "0";
					//					string mspan = "0";
					//					float fltModSpan = 0;
					//					try
					//					{
					//						int location = nd.Attributes["ows_ModifySpan"].Value.IndexOf(";#");
					//						mspan = nd.Attributes["ows_ModifySpan"].Value.Substring(location + 2);
					//						float.Parse(mspan);
					//					}
					//					catch{}
					//					if(fltModSpan < 0)
					//					{
					modified = "";
					try
					{
						modified = DateTime.Parse(nd.Attributes["ows_Modified"].Value).ToString();
					}
					catch{}
					if(nd.Attributes["ows_IsAssignment"] == null || nd.Attributes["ows_IsAssignment"].Value == "0")							
					{
						try
						{
							taskuid=nd.Attributes["ows_taskuid"].Value;
						}
						catch(System.Exception){}
							
						if(taskuid!="0")
						{
							if(myHash.ContainsKey(taskuid))
							{
								//Task tsk = pj.Tasks[int.Parse(myHash[taskuid].ToString())];
								Task tsk = (Task)myHash[taskuid];
								taskHash.Remove(tsk.UniqueID.ToString());
									
								if(Connect.getTaskLMF(pj,tsk) == modified)
								{
									//if(pubType==0)
								{
									if(pubType == 0)
										assnString = getAssnString(tsk, v2ResMap);
									else
										assnString = "";

									strBatch = strBatch + buildTaskString(tsk, false, methodId, taskuid, nd.Attributes["ows_ID"].Value, assnString, pj);
									methodId++;
								}
										
								}
							}
							else
							{
								strBatch = strBatch + 
									"<Method ID='" + methodId + "' Cmd='Delete'>" + 
									"<Field Name='ID'>" + nd.Attributes["ows_ID"].Value + "</Field></Method>";
								methodId++;
							}
						}
					}
					else
					{

						string assnId = "";
						try
						{
							string tmp = nd.Attributes["ows_taskuid"].Value;
							taskuid = tmp.Substring(0,tmp.IndexOf("."));
							assnId = tmp.Substring(tmp.IndexOf(".")+1);
						}
						catch(System.Exception){}
							
						if(taskuid != "0")
						{
							if(myHash.ContainsKey(taskuid) && pubType==1)
							{
								//Task tsk = pj.Tasks[int.Parse(myHash[taskuid].ToString())];
								Task tsk = (Task)myHash[taskuid];
								bool found = false;
								int assnCount;
								assnCount = 1;
								foreach(Assignment assn in tsk.Assignments)
								{
									assnString = "";
									if(assn.UniqueID.ToString() == assnId)
									{
										for(int i = 0;i<CheckResources.resCount;i++)
										{
											if(CheckResources.resList[i].matchedResID == assn.ResourceUniqueID)
											{
												taskHash.Remove(tsk.UniqueID.ToString());
												found = true;
												assnString = "";
												if(v2ResMap)
												{
													if(CheckResources.resList[i].ResourceID != 0)
														assnString = CheckResources.resList[i].ResourceID.ToString() + ";#" + CheckResources.resList[i].name.Replace(";","");
												}
												else
													assnString = CheckResources.resList[i].resId.ToString() + ";#" + assn.ResourceName.Replace(";","");
												if(Connect.getAssignmentLMF(pj,assn) == modified)
												{
													strBatch = strBatch + buildAssnString(tsk, assn, false, methodId, taskuid + "." + assn.UniqueID.ToString(), "1", nd.Attributes["ows_ID"].Value, assnString, pj);
												}
												methodId++;
												assignmentHash.Remove(taskuid + "." + assn.UniqueID.ToString());
												break;
											}
										}
									}
									assnCount++;
								}
								if(!found)
								{
									strBatch = strBatch + 
										"<Method ID='" + methodId + "' Cmd='Delete'>" + 
										"<Field Name='ID'>" + nd.Attributes["ows_ID"].Value + "</Field></Method>";
									methodId++;
								}
							}
							else
							{
								strBatch = strBatch + 
									"<Method ID='" + methodId + "' Cmd='Delete'>" + 
									"<Field Name='ID'>" + nd.Attributes["ows_ID"].Value + "</Field></Method>";
								methodId++;
							}//
						}//
					}//
					//					}//if ows_moderationstatus!=2
					//					else
					//					{
					//						taskuid = "";
					//						try
					//						{
					//							taskuid=nd.Attributes["ows_taskuid"].Value;
					//						}
					//						catch(System.Exception){}
					//						if(taskuid!="")
					//						{
					//							//myHash.Remove(taskuid);
					//							assignmentHash.Remove(taskuid);
					//							taskHash.Remove(taskuid);
					//						}
					//					}
				}//
				frmStatus.progressBar1.Value = counter++;
				frmStatus.Refresh();
				if(methodId >= maxTasks)
				{
					pushRet = pushTaskItems(pj, spList, strBatch);
					strBatch = "";
					methodId = 1;
					frmStatus.label1.Text = "Processing Current Tasks...";
					frmStatus.Refresh();
					if(pushRet != "0")
						break;
				}
				
			}

			counter = 1;
			
			
			frmStatus.progressBar1.Value = 1;
			
			if(pubType == 1)
				frmStatus.progressBar1.Maximum = assignmentHash.Keys.Count + taskHash.Keys.Count;
			else
				frmStatus.progressBar1.Maximum = taskHash.Keys.Count;

			frmStatus.label1.Text = "Processing New Tasks...";
			frmStatus.Refresh();

			frmStatus.label1.Text = "Processing New Tasks...";
			frmStatus.Refresh();
			if(pushRet == "0")
			{
				foreach (DictionaryEntry myEntry in taskHash)
				{
					//MessageBox.Show("New Task: " + myEntry.Key.ToString());
					//Task tsk = pj.Tasks[int.Parse(myEntry.Value.ToString())];
					
					Task tsk = (Task)myEntry.Value;
					
					if(!(tsk == null))
					{
						
						if(tsk.Summary.ToString() == "False" ||  Connect.getProperty("EPMLivePubSummary",pj) == "True")
						{
							if(pubType == 0)
								assnString = getAssnString(tsk, v2ResMap);
							else
								assnString = "";

							strBatch = strBatch + buildTaskString(tsk, true, methodId, tsk.UniqueID.ToString(), "",assnString,pj);

							if(pubType == 1)
							{
								foreach(Microsoft.Office.Interop.MSProject.Assignment assn in tsk.Assignments)
								{
									if(assignmentHash.Contains(tsk.UniqueID + "." + assn.UniqueID))
									{
										for(int i = 0;i<CheckResources.resCount;i++)
										{
											if(CheckResources.resList[i].matchedResID == assn.ResourceUniqueID)
											{
												assignmentHash.Remove(tsk.UniqueID + "." + assn.UniqueID);
												methodId++;
												assnString = "";
												if(v2ResMap)
												{
													if(CheckResources.resList[i].ResourceID != 0)
														assnString = CheckResources.resList[i].ResourceID.ToString() + ";#" + CheckResources.resList[i].name.Replace(";","");
												}
												else
													assnString = CheckResources.resList[i].resId.ToString() + ";#" + assn.ResourceName.Replace(";","");

												strBatch = strBatch + buildAssnString(tsk, assn, true, methodId, tsk.UniqueID + "." + assn.UniqueID.ToString(), "1", "", assnString, pj);
											}
										}
									}
								}
							}

							methodId++;
							if(methodId >= maxTasks)
							{
								pushTaskItems(pj, spList, strBatch);
								strBatch = "";
								methodId = 1;
								frmStatus.label1.Text = "Processing New Tasks...";
								frmStatus.Refresh();
							}
						}
					}
					frmStatus.progressBar1.Value = counter++;
					frmStatus.Refresh();
				}
				if(pubType==1)
				{
					foreach (DictionaryEntry myEntry in assignmentHash)
					{
						Assignment assn = (Assignment)myEntry.Value;

						Task tsk = (Task)myHash[assn.TaskUniqueID.ToString()];
						string taskuid = assn.TaskUniqueID.ToString();
						
						//Task tsk = pj.Tasks[int.Parse(taskid)];
						//Assignment assn = tsk.Assignments[int.Parse(assnid)];

						for(int i = 0;i<CheckResources.resCount;i++)
						{
							if(CheckResources.resList[i].matchedResID == assn.ResourceUniqueID)
							{
								taskHash.Remove(taskuid);
								assnString = "";
								if(v2ResMap)
								{
									if(CheckResources.resList[i].ResourceID != 0)
										assnString = CheckResources.resList[i].ResourceID.ToString() + ";#" + CheckResources.resList[i].name.Replace(";","");
								}
								else
									assnString = CheckResources.resList[i].resId.ToString() + ";#" + assn.ResourceName.Replace(";","");

								strBatch = strBatch + buildAssnString(tsk, assn, true, methodId, taskuid + "." + assn.UniqueID.ToString(), "1", "", assnString, pj);
								methodId++;
								break;
							}
						}
						if(methodId >= maxTasks)
						{
							pushRet = pushTaskItems(pj, spList, strBatch);
							strBatch = "";
							methodId = 1;
							frmStatus.label1.Text = "Processing New Tasks...";
							frmStatus.Refresh();
							if(pushRet != "0")
								break;
						}
						frmStatus.progressBar1.Value = counter++;
						frmStatus.Refresh();
					}
				}
			}
			
			if(strBatch.Length > 0)
				pushTaskItems(pj, spList, strBatch);
			
			if(moderationEnabled.ToUpper() == "TRUE")
				enableModeration(spList, pj);

			foreach (DictionaryEntry myEntry in myHash)
				Connect.NAR(myEntry.Value);
			
			foreach (DictionaryEntry myEntry in assignmentHash)
				Connect.NAR(myEntry.Value);
			
			foreach (DictionaryEntry myEntry in taskHash)
				Connect.NAR(myEntry.Value);
			
			foreach (DictionaryEntry myEntry in allTaskHash)
				Connect.NAR(myEntry.Value);
			
			foreach (DictionaryEntry myEntry in allAssnHash)
				Connect.NAR(myEntry.Value);

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();

			return "0";
		}

		private static void processErrors(XmlNode ndResult, XmlNode elBatch)
		{
			try
			{
				string []id = ndResult.Attributes["ID"].Value.Split(',');
				string errorNumber = ndResult.ChildNodes[0].InnerText;
				string errorText = ndResult.ChildNodes[1].InnerText;
				
				if(errorNumber != "0x00000000")
				{
					
					XmlNode ndItem = elBatch.SelectSingleNode("Method[@ID=" + id[0] + "]");
					
					string title = "";
					string taskuid = "";
					try
					{
						title = ndItem.SelectSingleNode("Field[@Name='Title']").InnerText;
					}
					catch{}
					try
					{
						taskuid = ndItem.SelectSingleNode("Field[@Name='taskuid']").InnerText;
					}
					catch{}
					string []arrTaskuid = taskuid.Split('.');
					if(arrTaskuid.Length > 1)
					{
						strErrors += "Task (ID: " + arrTaskuid[0] + "): " + title + "\r\nAssignment ID: " + arrTaskuid[1] + "\r\nReason: " + errorText.Replace("\n","\r\n") + "\r\n------------------------------------------\r\n";
					}
					else
						strErrors += "Task (ID: " + arrTaskuid[0] + "): " + title + "\r\nReason: " + errorText.Replace("\n","\r\n") + "\r\n------------------------------------------\r\n";
				}
			}
			catch{}
		}

		private static string pushTaskItems(Project pj, SPSLists.Lists spList, string strBatch)
		{
			try
			{
				frmStatus.label1.Text = "Uploading Tasks...";
				frmStatus.Refresh();

				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				string uploadBatch = strBatch;

				DateTime lp = DateTime.Now.AddSeconds(60);
				uploadBatch = uploadBatch.Replace("</Method>","<Field Name='LastPublished'>" + lp.Year.ToString() + "-" + lp.Month.ToString() + "-" + lp.Day.ToString() + " " + lp.Hour.ToString() + ":" + lp.Minute.ToString() + ":" + lp.Second.ToString() + "</Field></Method>");
				uploadBatch = uploadBatch.Replace("</Method>","<Field Name='Modified'>" + lp.Year.ToString() + "-" + lp.Month.ToString() + "-" + lp.Day.ToString() + " " + lp.Hour.ToString() + ":" + lp.Minute.ToString() + ":" + lp.Second.ToString() + "</Field></Method>");
				elBatch.InnerXml = uploadBatch;

				XmlNode ndReturn = spList.UpdateListItems(Connect.getProperty("EPMLiveTCList", pj), elBatch);

				//MessageBox.Show(ndReturn.OuterXml);

				if(ndReturn.OuterXml.IndexOf("<ErrorCode>0x81020014</ErrorCode>") > 0)
				{
                    MessageBox.Show("The " + Connect.getProperty("EPMLiveTCList", pj) + " list does not appear to have the correct structure. You will need to delete and recreate the '" + Connect.getProperty("EPMLiveTCList", pj) + "' list using the current version of Project Publisher.");
					return "-1";
				}

				foreach(XmlNode nd in ndReturn)
				{
					processErrors(nd,elBatch);
					
					string taskuid="";
					try
					{
						taskuid = nd.ChildNodes[1].Attributes["ows_taskuid"].Value;
					}
					catch
					{
						try
						{
							taskuid = nd.ChildNodes[2].Attributes["ows_taskuid"].Value;
						}
						catch{}
					}
					if(taskuid.IndexOf(".") > 0)
					{
						try
						{
							Assignment assn = (Assignment)allAssnHash[taskuid];
							Connect.setAssignmentLMF(pj,assn,DateTime.Parse(nd.ChildNodes[1].Attributes["ows_Modified"].Value).ToString());
						}
						catch
						{
							try
							{
								Assignment assn = (Assignment)allAssnHash[taskuid];
								Connect.setAssignmentLMF(pj,assn,DateTime.Parse(nd.ChildNodes[2].Attributes["ows_Modified"].Value).ToString());
							}
							catch{}
						}
					}
					else if (taskuid != "")
					{
						try
						{
							Task tsk = (Task)allTaskHash[taskuid];
							Connect.setTaskLMF(pj,tsk,DateTime.Parse(nd.ChildNodes[1].Attributes["ows_Modified"].Value).ToString());
						}
						catch
						{
							try
							{
								Task tsk = (Task)allTaskHash[taskuid];
								Connect.setTaskLMF(pj,tsk,DateTime.Parse(nd.ChildNodes[2].Attributes["ows_Modified"].Value).ToString());
							}
							catch{}
						}
					}
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Error uploading tasks: " + ex.Message.ToString() + "\n\n\n" + ex.StackTrace.ToString());
			}
			return "0";
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
		private static string buildTaskString(Task tsk, bool isNew, int methodId, string taskId, string itemId, string assn, Microsoft.Office.Interop.MSProject.Project pj)
		{

			string retVal = "";
			if(isNew)
			{
				retVal = 
					"<Method ID='" + methodId + "' Cmd='New'>";
			}
			else
			{
				retVal = "<Method ID='" + methodId + "' Cmd='Update'>" + 
					"<Field Name='ID'>" + itemId + "</Field>";
			}
			retVal = retVal + "<Field Name='Title'><![CDATA[" + tsk.Name + "]]></Field>";
			retVal = retVal + "<Field Name='taskuid'>" + taskId + "</Field>";
			retVal = retVal + "<Field Name='WBS'>" + tsk.WBS + "</Field>";
			retVal = retVal + "<Field Name='taskorder'>" + tsk.ID.ToString() + "</Field>";
			retVal = retVal + "<Field Name='IsAssignment'>0</Field>";
			retVal = retVal + "<Field Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'><![CDATA[" + projectID + "]]></Field>";

			if(Connect.hTaskCenterFields.Contains("ASSIGNEDTO"))
				retVal = retVal + "<Field Name='AssignedTo'>" + assn + "</Field>";

            if(Connect.hTaskCenterFields.Contains("ISPUBLISHED"))
                retVal = retVal + "<Field Name='IsPublished'>1</Field>";

			if(Connect.hTaskCenterFields.Contains("TASKHIERARCHY"))
			{
				if(breadCrumbHash.Contains(tsk.UniqueID.ToString()))
				{
					Connect.TaskField tf = (Connect.TaskField)Connect.hTaskCenterFields["TASKHIERARCHY"];
					retVal = retVal + "<Field Name='" + tf.wssFieldName + "'><![CDATA[" + breadCrumbHash[tsk.UniqueID.ToString()] + "]]></Field>";
				}
			}
			//			retVal = retVal + "<Field Name='PercentComplete'>" + Convert.ToString((Convert.ToDouble(tsk.PercentComplete.ToString(),provider) / 100.0),provider) + "</Field>";
			//			retVal = appendDateTime(tsk.Start.ToString(),retVal,"StartDate");
			//			retVal = appendDateTime(tsk.Finish.ToString(),retVal,"DueDate");
			//
			//			if(Connect.hTaskCenterFields.Contains("ActualStart"))
			//				retVal = appendDateTime(tsk.ActualStart.ToString(),retVal,"Actual_x0020_Start");
			//
			//			retVal = appendDateTime(tsk.ActualFinish.ToString(),retVal,"Actual_x0020_Finish");
			//			retVal = retVal + "<Field Name='Duration'>" + Convert.ToString((Convert.ToDouble(tsk.Duration.ToString(),provider) / 480.0),provider) + "</Field>";
			//			retVal = retVal + "<Field Name='Actual_x0020_Duration'>" + Convert.ToString((Convert.ToDouble(tsk.ActualDuration.ToString(),provider) / 480.0),provider) + "</Field>";
			//			retVal = retVal + "<Field Name='Cost'>" + tsk.Cost.ToString() + "</Field>";
			//			retVal = retVal + "<Field Name='Actual_x0020_Cost'>" + tsk.ActualCost.ToString() + "</Field>";
			//
			//			retVal = retVal + "<Field Name='Work'>" + Convert.ToString((Convert.ToDouble(tsk.Work.ToString(),provider) / 60.0),provider) + "</Field>";
			//
			//			retVal = retVal + "<Field Name='Actual_x0020_Work'>" + Convert.ToString((Convert.ToDouble(tsk.ActualWork.ToString(),provider) / 60.0),provider) + "</Field>";
			//			retVal = retVal + "<Field Name='Notes'><![CDATA[" + tsk.Notes.ToString().Replace("\r","<br><br>").Replace("\v","<br>") + "]]></Field>";
			//			
			//			retVal = retVal + "<Field Name='Milestone'>" + tsk.Milestone.ToString() + "</Field>";
			//			retVal = retVal + "<Field Name='Critical'>" + tsk.Critical.ToString() + "</Field>";
			//			
			//			retVal = retVal + "<Field Name='AssignedTo'>" + assn + "</Field>";
			//			
			//
			//			
			//			retVal = appendDateTime(tsk.Deadline.ToString(),retVal,"Deadline");
			//
			//			//retVal = retVal + "<Field Name='_ModerationStatus'>2</Field>";
			//			if(breadCrumbHash.Contains(tsk.UniqueID.ToString()))
			//				retVal = retVal + "<Field Name='Task_x0020_Hierarchy'><![CDATA[" + breadCrumbHash[tsk.UniqueID.ToString()] + "]]></Field>";
			//

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
                        retVal = retVal + "<Field Name='Complete'>1</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjFutureTask:
						retVal = retVal + "<Field Name='Status'>Not Started</Field>";
                        retVal = retVal + "<Field Name='Complete'>0</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjLate:
						retVal = retVal + "<Field Name='Status'>In Progress</Field>";
                        retVal = retVal + "<Field Name='Complete'>0</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjNoData:
						retVal = retVal + "<Field Name='Status'>Not Started</Field>";
                        retVal = retVal + "<Field Name='Complete'>0</Field>";
						break;
					case Microsoft.Office.Interop.MSProject.PjStatusType.pjOnSchedule:
						retVal = retVal + "<Field Name='Status'>In Progress</Field>";
                        retVal = retVal + "<Field Name='Complete'>0</Field>";
						break;
				};
			}
			retVal = retVal + buildCustomFields(tsk, null);

//			string flagField = Connect.getProperty("EPMLiveTSFlag",pj);
//
//			if(flagField != "")
//			{
//				try
//				{
//					Connect.TaskField tField = (Connect.TaskField)Connect.hPprojectFields[flagField];
//					int iField = tField.fieldId;
//					string flagVal = tsk.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
//					retVal = retVal + "<Field Name='Timesheet'>" + flagVal + "</Field>";
//				}
//				catch{}
//			}

			retVal = retVal + "</Method>";

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
                                        sFieldVal = getFieldForAssignment(tsk, assn, iField);
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
                        else if(sField == "NOTES")
                        {

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
                                catch { }
                                if(iField != 0)
                                {
                                    string sFieldVal = "";
                                    try
                                    {
                                        sFieldVal = pj.ProjectSummaryTask.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
                                    }
                                    catch { }
                                    retVal = retVal + addCustomField(sFieldVal, entry, iField, pj.ProjectSummaryTask);

                                }
                            }
                        }
					}
				}
			}
			return retVal;
		}

		public static string getFieldForAssignment(Task tsk, Assignment assn, int iField)
		{
			
			try
			{
				switch(iField)
				{
					case 188743683:
						return (float.Parse(assn.WorkVariance.ToString()) / 60).ToString();
					case 188743693:
						return assn.SV.ToString();
					case 188743725:
						return assn.StartVariance.ToString();
					case 188743726:
						return assn.FinishVariance.ToString();
					case 188743681:
						return assn.BaselineWork.ToString();
					case 188743682:
						return (float.Parse(assn.ActualWork.ToString()) / 60).ToString();
					case 188743684:
						return (float.Parse(assn.RemainingWork.ToString()) / 60).ToString();
					case 188743686:
						return assn.BaselineCost.ToString();
					case 188743690:
						return assn.RemainingCost.ToString();
					case 188743691:
						return assn.BCWP.ToString();
					case 188743692:
						return assn.BCWS.ToString();
					case 188743723:
						return assn.BaselineStart.ToString();
					case 188743800:
						return assn.ACWP.ToString();
					case 188743843:
						return assn.OvertimeWork.ToString();
					case 188743848:
						return assn.OvertimeCost.ToString();
					case 188743844:
						return assn.ActualOvertimeWork .ToString();
					case 188743845:
						return (float.Parse(assn.RemainingOvertimeWork.ToString()) / 60).ToString();
					case 188743846:
						return (float.Parse(assn.RegularWork.ToString()) / 60).ToString();
					case 188743849:
						return assn.ActualOvertimeCost.ToString();
					case 188743850:
						return assn.RemainingOvertimeCost.ToString();
					case 188743724:
						return assn.BaselineFinish.ToString();
					case 188743695:
						return assn.Notes;
					case 188743680:
						return (float.Parse(assn.Work.ToString()) / 60).ToString();
					case 188743687:
						return assn.ActualCost.ToString();
					case 188743685:
						return assn.Cost.ToString();
					case 188743722:
						return assn.ActualFinish.ToString();
					case 188743721:
						return assn.ActualStart.ToString();
					case 188743712:
						return assn.PercentWorkComplete.ToString();
					case 188743716:
						return assn.Finish.ToString();
					case 188743715:
						return assn.Start.ToString();
					case 188743729:
						return assn.ResourceName;

					case 188743731:
						return assn.Text1;
					case 188743732:
						return assn.Start1.ToString();
					case 188743733:
						return assn.Finish1.ToString();
					case 188743734:
						return assn.Text2;
					case 188743735:
						return assn.Start2.ToString();
					case 188743736:
						return assn.Finish2.ToString();
					case 188743737:
						return assn.Text3;
					case 188743738:
						return assn.Start3.ToString();
					case 188743739:
						return assn.Finish3.ToString();
					case 188743740:
						return assn.Text4;
					case 188743741:
						return assn.Start4.ToString();
					case 188743742:
						return assn.Finish4.ToString();
					case 188743743:
						return assn.Text5;
					case 188743744:
						return assn.Start5.ToString();
					case 188743745:
						return assn.Finish5.ToString();
					case 188743746:
						return assn.Text6;
					case 188743747:
						return assn.Text7;
					case 188743748:
						return assn.Text8;
					case 188743749:
						return assn.Text9;
					case 188743750:
						return assn.Text10;
					case 188743752:
						return assn.Flag1.ToString();
					case 188743753:
						return assn.Flag2.ToString();
					case 188743754:
						return assn.Flag3.ToString();
					case 188743755:
						return assn.Flag4.ToString();
					case 188743756:
						return assn.Flag5.ToString();
					case 188743757:
						return assn.Flag6.ToString();
					case 188743758:
						return assn.Flag7.ToString();
					case 188743759:
						return assn.Flag8.ToString();
					case 188743760:
						return assn.Flag9.ToString();
					case 188743761:
						return assn.Flag10.ToString();
					case 188743767:
						return assn.Number1.ToString();
					case 188743768:
						return assn.Number2.ToString();
					case 188743769:
						return assn.Number3.ToString();
					case 188743770:
						return assn.Number4.ToString();
					case 188743771:
						return assn.Number5.ToString();
					case 188743786:
						return assn.Cost1.ToString();
					case 188743787:
						return assn.Cost2.ToString();
					case 188743788:
						return assn.Cost3.ToString();
					case 188743938:
						return assn.Cost4.ToString();
					case 188743939:
						return assn.Cost5.ToString();
					case 188743940:
						return assn.Cost6.ToString();
					case 188743941:
						return assn.Cost7.ToString();
					case 188743942:
						return assn.Cost8.ToString();
					case 188743943:
						return assn.Cost9.ToString();
					case 188743944:
						return assn.Cost10.ToString();
					case 188743945:
						return assn.Date1.ToString();
					case 188743946:
						return assn.Date2.ToString();
					case 188743947:
						return assn.Date3.ToString();
					case 188743948:
						return assn.Date4.ToString();
					case 188743949:
						return assn.Date5.ToString();
					case 188743950:
						return assn.Date6.ToString();
					case 188743951:
						return assn.Date7.ToString();
					case 188743952:
						return assn.Date8.ToString();
					case 188743953:
						return assn.Date9.ToString();
					case 188743954:
						return assn.Date10.ToString();
					case 188743962:
						return assn.Start6.ToString();
					case 188743963:
						return assn.Finish6.ToString();
					case 188743964:
						return assn.Start7.ToString();
					case 188743965:
						return assn.Finish7.ToString();
					case 188743966:
						return assn.Start8.ToString();
					case 188743967:
						return assn.Finish8.ToString();
					case 188743968:
						return assn.Start9.ToString();
					case 188743969:
						return assn.Finish9.ToString();
					case 188743970:
						return assn.Start10.ToString();
					case 188743971:
						return assn.Finish10.ToString();
					case 188743972:
						return assn.Flag11.ToString();
					case 188743973:
						return assn.Flag12.ToString();
					case 188743974:
						return assn.Flag13.ToString();
					case 188743975:
						return assn.Flag14.ToString();
					case 188743976:
						return assn.Flag15.ToString();
					case 188743977:
						return assn.Flag16.ToString();
					case 188743978:
						return assn.Flag17.ToString();
					case 188743979:
						return assn.Flag18.ToString();
					case 188743980:
						return assn.Flag19.ToString();
					case 188743981:
						return assn.Flag20.ToString();
					case 188743982:
						return assn.Number6.ToString();
					case 188743983:
						return assn.Number7.ToString();
					case 188743984:
						return assn.Number8.ToString();
					case 188743985:
						return assn.Number9.ToString();
					case 188743986:
						return assn.Number10.ToString();
					case 188743987:
						return assn.Number11.ToString();
					case 188743988:
						return assn.Number12.ToString();
					case 188743989:
						return assn.Number13.ToString();
					case 188743990:
						return assn.Number14.ToString();
					case 188743991:
						return assn.Number15.ToString();
					case 188743992:
						return assn.Number16.ToString();
					case 188743993:
						return assn.Number17.ToString();
					case 188743994:
						return assn.Number18.ToString();
					case 188743995:
						return assn.Number19.ToString();
					case 188743996:
						return assn.Number20.ToString();
					case 188743997:
						return assn.Text11;
					case 188743998:
						return assn.Text12;
					case 188743999:
						return assn.Text13;
					case 188744000:
						return assn.Text14;
					case 188744001:
						return assn.Text15;
					case 188744002:
						return assn.Text16;
					case 188744003:
						return assn.Text17;
					case 188744004:
						return assn.Text18;
					case 188744005:
						return assn.Text19;
					case 188744006:
						return assn.Text20;
					case 188744007:
						return assn.Text21;
					case 188744008:
						return assn.Text22;
					case 188744009:
						return assn.Text23;
					case 188744010:
						return assn.Text24;
					case 188744011:
						return assn.Text25;
					case 188744012:
						return assn.Text26;
					case 188744013:
						return assn.Text27;
					case 188744014:
						return assn.Text28;
					case 188744015:
						return assn.Text29;
					case 188744016:
						return assn.Text30;
					case 188744162:
						return assn.Baseline1Start.ToString();
					case 188744163:
						return assn.Baseline1Finish.ToString();
					case 188744164:
						return assn.Baseline1Cost.ToString();
					case 188744173:
						return assn.Baseline2Start.ToString();
					case 188744174:
						return assn.Baseline2Finish.ToString();
					case 188744175:
						return assn.Baseline2Cost.ToString();
					case 188744184:
						return assn.Baseline3Start.ToString();
					case 188744185:
						return assn.Baseline3Finish.ToString();
					case 188744186:
						return assn.Baseline3Cost.ToString();
					case 188744195:
						return assn.Baseline4Start.ToString();
					case 188744196:
						return assn.Baseline4Finish.ToString();
					case 188744197:
						return assn.Baseline4Cost.ToString();
					case 188744206:
						return assn.Baseline5Start.ToString();
					case 188744207:
						return assn.Baseline5Finish.ToString();
					case 188744208:
						return assn.Baseline5Cost.ToString();
					case 188744224:
						return assn.Baseline6Start.ToString();
					case 188744225:
						return assn.Baseline6Finish.ToString();
					case 188744226:
						return assn.Baseline6Cost.ToString();
					case 188744235:
						return assn.Baseline7Start.ToString();
					case 188744236:
						return assn.Baseline7Finish.ToString();
					case 188744237:
						return assn.Baseline7Cost.ToString();
					case 188744246:
						return assn.Baseline8Start.ToString();
					case 188744247:
						return assn.Baseline8Finish.ToString();
					case 188744248:
						return assn.Baseline8Cost.ToString();
					case 188744257:
						return assn.Baseline9Start.ToString();
					case 188744258:
						return assn.Baseline9Finish.ToString();
					case 188744259:
						return assn.Baseline9Cost.ToString();
					case 188744268:
						return assn.Baseline10Start.ToString();
					case 188744269:
						return assn.Baseline10Finish.ToString();
					case 188744270:
						return assn.Baseline10Cost.ToString();

					default:
						try
						{
							return tsk.GetField((Microsoft.Office.Interop.MSProject.PjField)iField);
						}
						catch{}
						return "";
				}
			}
			catch{
				return "";
			}
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
					retVal = appendDateTime(sFieldVal,retVal,fName, task, iField);
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

		private static string buildAssnString(Task tsk, Assignment assn, bool isNew, int methodId, string taskId, string type, string itemId, string assns, Microsoft.Office.Interop.MSProject.Project pj)
		{
			

			string retVal = "";
			if(isNew)
			{
				retVal = 
					"<Method ID='" + methodId + "' Cmd='New'>";
			}
			else
			{
				retVal = "<Method ID='" + methodId + "' Cmd='Update'>" + 
					"<Field Name='ID'>" + itemId + "</Field>";	
			}

			retVal = retVal + "<Field Name='Title'><![CDATA[" + assn.TaskName + "]]></Field>";
			retVal = retVal + "<Field Name='taskuid'>" + taskId + "</Field>";

//			retVal = retVal + "<Field Name='PercentComplete'>" + Convert.ToString((Convert.ToDouble(assn.PercentWorkComplete.ToString(),provider) / 100.0),provider) + "</Field>";
//			retVal = appendDateTime(assn.Start.ToString(),retVal,"StartDate");
//			retVal = appendDateTime(assn.Finish.ToString(),retVal,"DueDate");
//			retVal = appendDateTime(assn.ActualStart.ToString(),retVal,"Actual_x0020_Start");
//			retVal = appendDateTime(assn.ActualFinish.ToString(),retVal,"Actual_x0020_Finish");
//			retVal = retVal + "<Field Name='Duration'>" + Convert.ToString((Convert.ToDouble(tsk.Duration.ToString(),provider) / 480.0),provider) + "</Field>";
//			retVal = retVal + "<Field Name='Actual_x0020_Duration'>" + Convert.ToString((Convert.ToDouble(tsk.ActualDuration.ToString(),provider) / 480.0),provider) + "</Field>";
//			retVal = retVal + "<Field Name='Cost'>" + assn.Cost.ToString() + "</Field>";
//			retVal = retVal + "<Field Name='Actual_x0020_Cost'>" + assn.ActualCost.ToString() + "</Field>";
//			retVal = retVal + "<Field Name='Work'>" + Convert.ToString((Convert.ToDouble(assn.Work.ToString(),provider) / 60.0),provider) + "</Field>";
//			retVal = retVal + "<Field Name='Actual_x0020_Work'>" + Convert.ToString((Convert.ToDouble(assn.ActualWork.ToString(),provider) / 60.0),provider) + "</Field>";
//			retVal = retVal + "<Field Name='Notes'><![CDATA[" + assn.Notes.ToString().Replace("\r","<br><br>").Replace("\v","<br>") + "]]></Field>";
//			retVal = retVal + "<Field Name='taskorder'>" + tsk.ID.ToString() + "</Field>";
//			retVal = retVal + "<Field Name='Milestone'>" + tsk.Milestone.ToString() + "</Field>";
//			retVal = retVal + "<Field Name='Critical'>" + tsk.Critical.ToString() + "</Field>";
//			retVal = retVal + "<Field Name='IsAssignment'>1</Field>";
//			retVal = retVal + "<Field Name='AssignedTo'>" + assns + "</Field>";
//			retVal = retVal + "<Field Name='Project'><![CDATA[" + projectID + "]]></Field>";
//			retVal = retVal + "<Field Name='WBS'>" + tsk.WBS + "</Field>";
//			retVal = appendDateTime(tsk.Deadline.ToString(),retVal,"Deadline");
//			if(breadCrumbHash.Contains(tsk.UniqueID.ToString()))
//				retVal = retVal + "<Field Name='Task_x0020_Hierarchy'><![CDATA[" + breadCrumbHash[tsk.UniqueID.ToString()] + "]]></Field>";
			
			retVal = retVal + "<Field Name='WBS'>" + tsk.WBS + "</Field>";
			retVal = retVal + "<Field Name='taskorder'>" + tsk.ID.ToString() + "</Field>";
			retVal = retVal + "<Field Name='IsAssignment'>1</Field>";
			retVal = retVal + "<Field Name='" + Connect.getProperty("EPMLiveTCListPC", pj) + "'><![CDATA[" + projectID + "]]></Field>";

			if(Connect.hTaskCenterFields.Contains("ASSIGNEDTO"))
				retVal = retVal + "<Field Name='AssignedTo'>" + assns + "</Field>";

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

			retVal = retVal + buildCustomFields(tsk, assn);

			retVal = retVal + "</Method>";

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
