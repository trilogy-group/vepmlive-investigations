using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Globalization;
using System.IO;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for Update.
	/// </summary>
	public class Update
	{

		private static NumberFormatInfo provider;
		private static Hashtable hshResFields;
		private static string pubType = "";		

		public Update()
		{
			
			//
			// TODO: Add constructor logic here
			//
		}
		public static int getUpdateCount(Microsoft.Office.Interop.MSProject.Project pj)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.Show();

			frmStatus.label1.Text = "Checking For Updates...";
			frmStatus.Refresh();

            SPSLists.Lists spList = Connection.GetListService(Connection.url);
			
			Hashtable myHash = new Hashtable();
			Hashtable assnHash = new Hashtable();
			foreach(Task tsk in pj.Tasks)
			{
				if(tsk != null)
				{
					if(tsk.Summary.ToString() == "False" || Connect.getProperty("EPMLivePubSummary",pj) == "True")
					{
						myHash.Add(tsk.UniqueID.ToString(),tsk);
						foreach(Assignment assn in tsk.Assignments)
						{
							assnHash.Add(tsk.UniqueID.ToString() + "." + assn.UniqueID.ToString(),assn);
						}
					}
				}
			}
			
			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
			XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
			XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");
			ndQueryOptions.InnerXml = "";
			ndViewFields.InnerXml = 
				"<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"Modified\"/>";

            //EPML-5188 : use the project id instead project title.
            ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" LookupId=\"TRUE\"/><Value Type=\"Integer\"><![CDATA[" + Connection.getProjectIdByTitle(pj) + "]]></Value></Eq></Where>";

			XmlNode ndListItems = null;
			try
			{
				ndListItems = spList.GetListItems(Connect.getProperty("EPMLiveTCList", pj), string.Empty, ndQuery, ndViewFields, "10", ndQueryOptions, string.Empty);
				
				foreach(XmlNode nd in ndListItems.ChildNodes[1].ChildNodes)
				{
					if(nd.OuterXml.Trim() != "")
					{
						string ListID = nd.Attributes["ows_ID"].Value;
						string taskuid = "";
						string modified = "";
						try
						{
							taskuid = nd.Attributes["ows_taskuid"].Value;
						}
						catch(System.Exception){}

						try
						{
							modified = DateTime.Parse(nd.Attributes["ows_Modified"].Value).ToString();
						}
						catch{}

						if(taskuid.IndexOf(".") > 0)
						{
							try
							{
								Assignment na = (Assignment)assnHash[taskuid];
								if(na!=null)
								{
									string dtMod = "";
									try
									{
										dtMod = Connect.getAssignmentLMF(pj,na);
									}
									catch{}
									if(dtMod != modified)
									{
										frmStatus.Dispose();
										return 1;
									}
								}
							}
							catch{}
						}
						else if (taskuid != "")
						{
							try
							{
								Task nt = (Task)myHash[taskuid];
								if(nt!=null)
								{
									string dtMod = "";
									try
									{
										dtMod = Connect.getTaskLMF(pj,nt);
									}
									catch{}
									if(dtMod != modified)
									{
										frmStatus.Dispose();
										return 1;
									}
								}
							}
							catch{}
						}
						else
						{
							frmStatus.Dispose();
							return 1;
						}
					}
				}
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
				MessageBox.Show("Soap Error Reading Tasks:\n" + ex1.Message + "\n\n" + ex1.Detail.OuterXml);
				return 0;
			}
			catch (System.Exception ex)
			{
				
				MessageBox.Show("Error Reading Tasks:\n" + ex.Message + "\n\n" + ex.StackTrace);
				return 0;
			}
			frmStatus.Dispose();
			//MessageBox.Show("D6");
			return 0;
			
		}

		public static int update(Microsoft.Office.Interop.MSProject.Project pj,Microsoft.Office.Interop.MSProject.Application app)
		{
			pubType = Connect.getProperty("EPMLiveType",pj);

			int ret = 0;
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Downloading Tasks...";
			frmStatus.Show();

			frmStatus.Refresh();


            SPSLists.Lists spList = Connection.GetListService(Connection.url);

			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
			XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
			XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

			ndQueryOptions.InnerXml = "";

			string viewFields =
				"<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"IsAssignment\"/><FieldRef Name=\"Modified\"/><FieldRef Name=\"Editor\"/>";
			
				//+ 
				//"<FieldRef Name=\"PercentComplete\"/><FieldRef Name=\"Notes\"/><FieldRef Name=\"AssignedTo\"/>"+
				//"<FieldRef Name=\"StartDate\"/><FieldRef Name=\"DueDate\"/><FieldRef Name=\"Actual_x0020_Start\"/>" + 
				//"<FieldRef Name=\"Actual_x0020_Finish\"/><FieldRef Name=\"Task_x0020_Hierarchy\"/>" + 
				//"<FieldRef Name=\"Milestone\"/>";

			Hashtable hTaskFields = new Hashtable();

			foreach(DictionaryEntry entry in Connect.hTaskCenterFields)
			{
				
				Connect.TaskField tField = (Connect.TaskField)entry.Value;

				//if((tField.editable && !tField.builtin) || (tField.fieldName.ToUpper() == "ACTUAL_X0020_WORK" && tField.editable) || (tField.fieldName.ToUpper() == "PHYSICAL_X0020__X0025__X0020_COM" && tField.editable))
				if(tField.fieldName.ToUpper() == "ASSIGNEDTO")
				{
					if(tField.editable)
						hTaskFields.Add(tField.fieldName,188743729);
					viewFields += "<FieldRef Name=\"" + tField.wssFieldName + "\"/>";
				}
				else if(tField.editable)
				{
					string sField = tField.fieldName.ToUpper();
					if(sField == "PHYSICAL_X0020__X0025__X0020_COM")
						sField = "PHYSICALPERCENTCOMPLETE";

					if(sField == "STARTDATE")
						sField = "START";
					if(sField == "DUEDATE")
						sField = "FINISH";

					if(Connect.hPprojectFields.Contains(sField.Replace("_X0020_","")))
					{
						Connect.TaskField tField2 = (Connect.TaskField)Connect.hPprojectFields[sField.Replace("_X0020_","")];
						hTaskFields.Add(tField.fieldName,tField2.fieldId);
						viewFields += "<FieldRef Name=\"" + tField.wssFieldName + "\"/>";
					}
				}
				else if(tField.fieldName.ToUpper()=="TASKHIERARCHY")
				{
					viewFields += "<FieldRef Name=\"" + tField.wssFieldName + "\"/>";
				}
			}

			ndViewFields.InnerXml = viewFields;
			//ndQuery.InnerXml = "<Where><And><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\">" + Connection.getProjectName(pj) + "</Value></Eq><Eq><FieldRef Name=\"_ModerationStatus\"/><Value Type=\"Text\">Pending</Value></Eq></And></Where>";

			//ndQuery.InnerXml = "<Where><And><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\">" + Connection.getProjectName(pj) + "</Value></Eq><Gt><FieldRef Name=\"ModifySpan\"/><Value Type=\"Number\">0</Value></Gt></And></Where>";
            //EPML-5188 : use the project id instead project title.
            ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"" + Connect.getProperty("EPMLiveTCListPC", pj) + "\" LookupId=\"TRUE\"/><Value Type=\"Integer\"><![CDATA[" + Connection.getProjectIdByTitle(pj) + "]]></Value></Eq></Where>";
			XmlNode ndListItems = null;

			try
			{
				ndListItems = spList.GetListItems(Connect.getProperty("EPMLiveTCList", pj), string.Empty, ndQuery, ndViewFields, "0", ndQueryOptions, string.Empty);
			}
			catch
			{
				frmStatus.Dispose();
				MessageBox.Show("This site has not been setup for the EPM Live Publisher. Please publish your project first.");
				return -1;
			}

			int counter = 0;

			Hashtable myHash = new Hashtable();
			Hashtable assnHash = new Hashtable();

			foreach(Task tsk in pj.Tasks)
			{
				if(tsk != null)
				{
					if(tsk.Summary.ToString() == "False" || Connect.getProperty("EPMLivePubSummary",pj) == "True")
					{
						myHash.Add(tsk.UniqueID.ToString(),tsk);
						foreach(Assignment assn in tsk.Assignments)
						{
							assnHash.Add(tsk.UniqueID.ToString() + "." + assn.UniqueID.ToString(),assn);
						}
					}
				}
			}

			frmStatus.progressBar1.Maximum = int.Parse(ndListItems.ChildNodes[1].Attributes["ItemCount"].Value);

			Hashtable newTasks = new Hashtable();
			int newCounter = 1;
			provider = new NumberFormatInfo( );

			provider.NumberDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			provider.NumberGroupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
			provider.NumberGroupSizes = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes;

			NumberFormatInfo providerEn = new NumberFormatInfo( );

			providerEn.NumberDecimalSeparator = ".";
			providerEn.NumberGroupSeparator = ",";
			providerEn.NumberGroupSizes = new int[ ] { 3 };

			foreach(XmlNode nd in ndListItems.ChildNodes[1].ChildNodes)
			{
				if(nd.OuterXml.Trim() != "")
				{
					
					string taskuid = "";
					string modified = "";
					try
					{
						taskuid = nd.Attributes["ows_taskuid"].Value;
					}
					catch(System.Exception){}
					try
					{
						modified = DateTime.Parse(nd.Attributes["ows_Modified"].Value).ToString();
					}
					catch{}

					if(taskuid.IndexOf(".") > 0)
					{
						try
						{
							Assignment na = (Assignment)assnHash[taskuid];
							if(na!=null)
							{
								string dtMod = "";
								try
								{
									dtMod = Connect.getAssignmentLMF(pj,na);
								}
								catch{}
								if(dtMod != modified)
								{
									Connect.Tasks newTask = getTask(nd,hTaskFields,providerEn);
									newTask.taskuid = taskuid;
									newTasks.Add(taskuid,newTask);
								}
							}
						}
						catch{}
					}
					else if (taskuid != "")
					{
						try
						{
							Task nt = (Task)myHash[taskuid];
							if(nt != null)
							{
								string dtMod ="";
								try
								{
									dtMod = Connect.getTaskLMF(pj, nt);
								}
								catch{}
								if(dtMod != modified)
								{
									Connect.Tasks newTask = getTask(nd,hTaskFields,providerEn);
									newTask.taskuid = taskuid;
									newTasks.Add(taskuid,newTask);
								}
							}
						}
						catch{}
					}
					else
					{
						Connect.Tasks newTask = getTask(nd,hTaskFields, providerEn);
						newTask.taskuid = "0:" + newCounter.ToString();
						newTasks.Add(newTask.taskuid,newTask);
						newCounter++;
					}
					try
					{
						frmStatus.progressBar1.Value = frmStatus.progressBar1.Value + 1;
					}
					catch{}
				}
			}

			//int taskCount = int.Parse(ndListItems.ChildNodes[1].Attributes["ItemCount"].Value);
			Connect.taskList = new Connect.Tasks[newTasks.Count];
			counter = 0;

			foreach(DictionaryEntry entry in newTasks)
			{
				Connect.taskList[counter] = new Connect.Tasks();
				Connect.Tasks nt = (Connect.Tasks)entry.Value;
				
				Connect.taskList[counter].ListID = nt.ListID;
				Connect.taskList[counter].actualFinish = nt.actualFinish;
				Connect.taskList[counter].actualStart  = nt.actualStart;
				Connect.taskList[counter].breadCrumbs = nt.breadCrumbs;
				Connect.taskList[counter].finish = nt.finish;
				Connect.taskList[counter].milestone = nt.milestone;
				Connect.taskList[counter].notes = nt.notes;
				Connect.taskList[counter].pctComplete = nt.pctComplete;
				Connect.taskList[counter].resource = nt.resource;
				Connect.taskList[counter].start = nt.start;
				Connect.taskList[counter].taskname = nt.taskname;
				Connect.taskList[counter].customFields = nt.customFields;
				Connect.taskList[counter].moderationStatus = 0;
				Connect.taskList[counter].modifiedBy = nt.modifiedBy;
				Connect.taskList[counter].isValid = false;

				if(nt.taskuid.IndexOf(":") > 0)
					Connect.taskList[counter].taskuid = "";
				else
					Connect.taskList[counter].taskuid = nt.taskuid;

				Connect.taskList[counter].type = nt.type;

				counter++;
			}

			frmStatus.Hide();
			if(Connect.taskList.Length > 0)
			{
				FormApproveTasks frmApprove = new FormApproveTasks(Connect.taskList,pj, myHash);
				frmApprove.ShowDialog();
				if(frmApprove.DialogResult == System.Windows.Forms.DialogResult.OK)
				{
					Update.hshResFields = new Hashtable();
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

					frmStatus.Show();
					frmStatus.label1.Text = "Processing Tasks...";
					frmStatus.progressBar1.Maximum = Connect.taskList.Length;
					frmStatus.Refresh();
					counter = 1;
					for(int i=0;i<Connect.taskList.Length;i++)
					{
						try
						{
							if(Connect.taskList[i].isValid)
							{
								string tuid =  processItem(Connect.taskList[i],pj,myHash);
								Connect.taskList[i].taskuid = tuid;
							}
						}
						catch{}
						frmStatus.progressBar1.Value = counter++;
						frmStatus.Refresh();
					}

					frmStatus.Hide();
					frmStatus.Dispose();
					//}
					//if(frmApprove.DialogResult == DialogResult.OK)
					//{
					DialogResult dRes = MessageBox.Show("Your project has been updated. Would you like to save your project?","Updated",MessageBoxButtons.YesNo);
					if(dRes == DialogResult.Yes)
						app.FileSave();
				}	
				else
				{
					ret = -1;
					Connect.taskList = new Connect.Tasks[0];
				}
				frmApprove.Dispose();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("There are no task updates to process.");
			}
			try
			{
				frmStatus.Dispose();
			}
			catch{}
			return ret;
		}

		private static Connect.Tasks getTask(XmlNode nd, Hashtable hTaskFields, IFormatProvider providerEn)
		{
			string ListID = nd.Attributes["ows_ID"].Value;
			string taskuid = "";
			string taskname = "";
			string notes = "";
			string resource = "";
			string milestone = "";
			int type = 0;
			string start = "";
			string finish = "";
			string actualStart = "";
			string actualFinish = "";
			string pctComplete = "0";
			string breadCrumbs = "";
			string modified = "";
			string editor = "";
			try
			{
				taskuid = nd.Attributes["ows_taskuid"].Value;
			}
			catch(System.Exception){}
			try
			{
				editor = nd.Attributes["ows_Editor"].Value;
				editor = editor.Replace(";#","\n").Split('\n')[1];
			}
			catch(System.Exception){}
			try
			{
				taskname = nd.Attributes["ows_Title"].Value;
			}
			catch(System.Exception){}
			try
			{
				notes = cleanUp(nd.Attributes["ows_Notes"].Value);
			}
			catch(System.Exception){}
			try
			{
				resource = nd.Attributes["ows_AssignedTo"].Value;
				resource = resource.Replace(";;",";");
			}
			catch(System.Exception){}
			try
			{
				milestone = nd.Attributes["ows_Milestone"].Value;
			}
			catch{}
			try
			{
				type = int.Parse(nd.Attributes["ows_IsAssignment"].Value);
			}
			catch(System.Exception){}
			try
			{
				pctComplete = (Convert.ToDouble(nd.Attributes["ows_PercentComplete"].Value.ToString(),providerEn) * 100).ToString();
			}
			catch(System.Exception){}
			try
			{
				breadCrumbs = nd.Attributes["ows_TaskHierarchy"].Value;
				breadCrumbs = nd.Attributes["ows_Task_x0020_Hierarchy"].Value;
			}
			catch(System.Exception){}
					
			try
			{
				modified = DateTime.Parse(nd.Attributes["ows_Modified"].Value).ToString();
			}
			catch{}

			Hashtable customFields = new Hashtable();

			foreach(DictionaryEntry entry in hTaskFields)
			{
				string field = entry.Key.ToString().ToUpper();
				string iField = entry.Value.ToString();
				if(field == "STARTDATE")
					field = "START";
				if(field == "DUEDATE")
					field="FINISH";

				string fName = ((Microsoft.Office.Interop.MSProject.PjField)Convert.ToInt32(iField)).ToString();
				//if(Connect.hPprojectFields.Contains(fName.Replace("pjTask","").ToUpper()))
				if(Connect.hTaskCenterFields.Contains(field))
				{
					//Connect.TaskField tField = (Connect.TaskField)Connect.hPprojectFields[fName.Replace("pjTask","").ToUpper()];
					Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields[field];

					if(tField.type != 9)
					{

						string sFieldVal = Connect.getAttribute(nd,"ows_" + tField.wssFieldName);

						if(tField.type == 2 || tField.type == 3)
						{
							try
							{
								sFieldVal = Convert.ToString(Convert.ToDouble(sFieldVal,providerEn));
							}
							catch{}
						}
						else if(tField.type == 4)
						{
						
							try
							{
								if(sFieldVal.IndexOf("00:00:00") > 0)
									sFieldVal = Convert.ToDateTime(sFieldVal).ToShortDateString();
								else
									sFieldVal = Convert.ToDateTime(sFieldVal).ToString();

								switch(int.Parse(iField))
								{
									case 188743715:
										start = sFieldVal;
										break;
									case 188743716:
										finish = sFieldVal;
										break;
									case 188743721:
										actualStart = sFieldVal;
										break;
									case 188743722:
										actualFinish = sFieldVal;
										break;
								};
							}
							catch{}
						}
						else if(iField == "188743729")
						{}
						else
						{
							sFieldVal = sFieldVal.Replace(";#"," - ");
						}
						customFields.Add(iField,sFieldVal);
					}
				}
			}
			Connect.Tasks newTask = new Connect.Tasks();
			newTask.customFields = customFields;
			newTask.actualStart = actualStart;
			newTask.actualFinish = actualFinish;
			newTask.breadCrumbs = breadCrumbs;
			newTask.finish = finish;
			newTask.ListID = ListID;
			newTask.milestone = milestone;
			newTask.notes = notes;
			newTask.pctComplete = pctComplete;
			newTask.resource = resource;
			newTask.start = start;
			newTask.taskname = taskname;
			newTask.type = type;
			newTask.modifiedBy = editor;

			

			return newTask;
		}

		private static string cleanUp(string str)
		{
			str = str.Replace("</div> <div>","\r\n");
			str = str.Replace("<div>","");
			str = str.Replace("</div>","");
			str = str.Replace("<br>","\r\n");
			str = str.Replace("&nbsp;"," ");
			return str;
		}

		private static void processTask(Connect.Tasks newTask, Microsoft.Office.Interop.MSProject.Project pj, Hashtable myHash)
		{

			try
			{
				Task tsk = (Task)myHash[newTask.taskuid];
				Microsoft.Office.Interop.MSProject.PjTaskFixedType type = tsk.Type ;

				try
				{
					if(Connect.hTaskCenterFields.Contains("START"))
					{
						Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["START"];
						if(tField.editable)
						{
							DateTime dt = Convert.ToDateTime(newTask.start);
							if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
							{
								DateTime dt2 = Convert.ToDateTime(tsk.Start);
								tsk.Start = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
							}
							else
							{
								tsk.Start = newTask.start;
							}
						}
					}
				}
				catch(System.Exception){}
				try
				{
					if(Connect.hTaskCenterFields.Contains("FINISH"))
					{
						Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["FINISH"];
						if(tField.editable)
						{
							DateTime dt = Convert.ToDateTime(newTask.finish);
							if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
							{
								DateTime dt2 = Convert.ToDateTime(tsk.Finish);
								tsk.Finish = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
							}
							else
							{
								tsk.Finish = newTask.finish;
							}
						}
					}
				}
				catch(System.Exception){}
				try
				{
					if(Connect.hTaskCenterFields.Contains("PERCENTCOMPLETE"))
					{
						Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["PERCENTCOMPLETE"];
						if(tField.editable)
						{
							tsk.PercentComplete = newTask.pctComplete;
						}
					}
				}
				catch(System.Exception){}
				
				try
				{
					if(newTask.milestone == "1")
					{
						tsk.Milestone = true;
					}
					tsk.Notes = newTask.notes;
					tsk.Type = type;
				}
				catch{}
				//Custom Fields
				string actualwork = "";
				string remainingwork = "";
				foreach(DictionaryEntry entry in newTask.customFields)
				{
					try
					{
						
						int iField = 0;
						try
						{
							iField = Convert.ToInt32(entry.Key.ToString());
						}
						catch{}
						string fieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString();

						switch(iField)
						{
							case 188743729:
							case 188743715:
							case 188743716:
							case 188743712:
							case 188743721:
							case 188743722:
							case 188743695:
								break;
							default:
								string sFieldVal =  entry.Value.ToString();

								if(iField == 188743684)
									remainingwork = sFieldVal;
								else if(iField == 188743682)
									actualwork = sFieldVal;
								else if(iField == 188744799)
								{
									try
									{
										sFieldVal = (Convert.ToDouble(sFieldVal) * 100).ToString();
										tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
									}
									catch{}
								}
								else
								{
									Connect.TaskField tField = null;
									if(Connect.hTaskCenterFields.Contains(fieldName.Replace("pjTask","").ToUpper()))
									{
										tField = (Connect.TaskField)Connect.hTaskCenterFields[fieldName.Replace("pjTask","").ToUpper()];
									}

									if(tField != null && tField.wssFieldName == "TimesheetHours")
									{
										if(sFieldVal != "0")
										{
											if(fieldName.Replace("pjTask","").ToLower() == Connect.getProperty("EPMLiveTSTimesheetHours",pj).ToString().ToLower())
											{
												if(pubType == "1")
												{
													Assignment assn = null;
													foreach(Assignment a in tsk.Assignments)
													{
														if(a.ResourceName == "Other Timesheet Hours")
														{
															assn = a;
															break;
														}
													}
													if(assn == null)
													{
														Resource res = null;;
														foreach(Resource r in pj.Resources)
														{
															if(r.Name == "Other Timesheet Hours")
															{
																res = r;
																break;
															}
														}
														if(res == null)
														{
															res = pj.Resources.Add("Other Timesheet Hours", Missing.Value);
															res.Type = Microsoft.Office.Interop.MSProject.PjResourceTypes.pjResourceTypeCost;
															System.Windows.Forms.Application.DoEvents();
														}

														assn = tsk.Assignments.Add(tsk.ID, res.ID, 0);
													}
												
													pj.Application.CalculateProject();
													System.Windows.Forms.Application.DoEvents();

													foreach(Assignment a in tsk.Assignments)
													{
														if(a.ResourceName == "Other Timesheet Hours")
														{
															setAssignmentField(iField,sFieldVal,a,tsk);
														}
													}

													double total = 0;
													foreach(Microsoft.Office.Interop.MSProject.Assignment assn2 in tsk.Assignments)
													{
														total += double.Parse(Publish.getFieldForAssignment(tsk, assn2, iField));
													}
													tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField, total.ToString());
												}
												else
												{
													tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
												}
											}
										}
									}
									else
									{
										tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
									}
								}
								//tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
								break;
						};
					}
					catch{}
				}
				try
				{
					if(actualwork != "" && remainingwork != "")
					{
						tsk.ActualWork = actualwork;
						tsk.RemainingWork = remainingwork;
					}
					else if(remainingwork != "")
					{
						tsk.RemainingWork = remainingwork;
					}
					else if(actualwork != "")
					{
						tsk.ActualWork = actualwork;
					}
				}
				catch{}
				try
				{
					if(Connect.hTaskCenterFields.Contains("ACTUALSTART"))
					{
						Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALSTART"];
						if(tField.editable)
						{
							
							DateTime dt = Convert.ToDateTime(newTask.actualStart);
							if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0 && tsk.ActualStart.ToString() != "NA")
							{
								DateTime dt2 = Convert.ToDateTime(tsk.ActualStart);
								tsk.ActualStart = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
								
							}
							else
							{
								tsk.ActualStart = newTask.actualStart;
							}
						}
					}
				}
				catch{}
				try
				{
					if(Connect.hTaskCenterFields.Contains("ACTUALFINISH"))
					{
						Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALFINISH"];
						if(tField.editable)
						{
							DateTime dt = Convert.ToDateTime(newTask.actualFinish);
							if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0 && tsk.ActualFinish.ToString() != "NA")
							{
								DateTime dt2 = Convert.ToDateTime(tsk.ActualFinish);
								tsk.ActualFinish = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
							}
							else
							{
								tsk.ActualFinish = newTask.actualFinish;
							}
						}
					}
				}
				catch(System.Exception){}
				if(tsk.Assignments.Count == 0)
				{
					if(Connection.resUrl == "")
					{
						string[] ress = newTask.resource.Replace(";#","\n").Split('\n');
						for(int i = 0;i<ress.Length;i=i+2)
						{
							try
							{
								for(int j = 0;j<CheckResources.resCount;j++)
									if(CheckResources.resList[j].resId == int.Parse(ress[i]))
										tsk.Assignments.Add(tsk.ID,CheckResources.resList[j].ResourceID,Missing.Value);
							}
							catch{}
						}
					}
					else
					{
						string field = Connect.getProperty("EPMLiveResField",pj);
						if(field == "")
							field = "Number15";
						int fieldId = 0;
						if(Update.hshResFields.Contains(field))
						{
							fieldId = (int)Update.hshResFields[field];
						}

						string[] ress = newTask.resource.Replace(";#","\n").Split('\n');
			
						for(int i = 0;i<ress.Length;i=i+2)
						{
							if(ress[i] != "")
							{
								for(int j = 0;j<CheckResources.resCount;j++)
									if(CheckResources.resList[j].ResourceID == int.Parse(ress[i]))
										foreach(Resource res in pj.Resources)
											if(Connect.getResField(fieldId,res) == CheckResources.resList[j].resId.ToString())
												tsk.Assignments.Add(tsk.ID,res.ID,Missing.Value);
							}
						}
					}
				}
			}
			catch(System.Exception e)
			{
				//MessageBox.Show("Error updating task (" + newTask.taskname + "): " + e.Message);
			}
		}

		public static void setAssignmentField(int iField, string sFieldVal, Assignment assn, Task tsk)
		{
			string fieldname = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString().Replace("pjTask","").ToUpper();

			if(Connect.hPprojectFields.Contains(fieldname))
			{
				Connect.TaskField tf = (Connect.TaskField)Connect.hPprojectFields[fieldname];
				if(tf.type == 5)
				{
					if(sFieldVal == "1")
						sFieldVal = "true";
					else if(sFieldVal == "0")
						sFieldVal = "false";
				}
			}
			switch(iField)
			{
				case 188743681:
					assn.BaselineWork = sFieldVal;
					break;
				case 188743686:
					assn.BaselineCost = sFieldVal;
					break;
				case 188743723:
					assn.BaselineStart = sFieldVal;
					break;
				case 188743843:
					assn.OvertimeWork = sFieldVal;
					break;
				case 188743844:
					assn.ActualOvertimeWork = sFieldVal;
					break;
				case 188743845:
					assn.RemainingOvertimeWork = sFieldVal;
					break;
				case 188743846:
					assn.RegularWork = sFieldVal;
					break;
				case 188743724:
					assn.BaselineFinish = sFieldVal;
					break;
				case 188743680:
					assn.Work = sFieldVal;
					break;
				case 188743687:
					assn.ActualCost = sFieldVal;
					break;
				case 188743685:
					assn.Cost = sFieldVal;
					break;
				
				case 188743731:
					assn.Text1 = sFieldVal;
					break;
				case 188743732:
					assn.Start1 = sFieldVal;
					break;
				case 188743733:
					assn.Finish1 = sFieldVal;
					break;
				case 188743734:
					assn.Text2 = sFieldVal;
					break;
				case 188743735:
					assn.Start2 = sFieldVal;
					break;
				case 188743736:
					assn.Finish2 = sFieldVal;
					break;
				case 188743737:
					assn.Text3 = sFieldVal;
					break;
				case 188743738:
					assn.Start3 = sFieldVal;
					break;
				case 188743739:
					assn.Finish3 = sFieldVal;
					break;
				case 188743740:
					assn.Text4 = sFieldVal;
					break;
				case 188743741:
					assn.Start4 = sFieldVal;
					break;
				case 188743742:
					assn.Finish4 = sFieldVal;
					break;
				case 188743743:
					assn.Text5 = sFieldVal;
					break;
				case 188743744:
					assn.Start5 = sFieldVal;
					break;
				case 188743745:
					assn.Finish5 = sFieldVal;
					break;
				case 188743746:
					assn.Text6 = sFieldVal;
					break;
				case 188743747:
					assn.Text7 = sFieldVal;
					break;
				case 188743748:
					assn.Text8 = sFieldVal;
					break;
				case 188743749:
					assn.Text9 = sFieldVal;
					break;
				case 188743750:
					assn.Text10 = sFieldVal;
					break;
				case 188743752:
					assn.Flag1 = bool.Parse(sFieldVal);
					break;
				case 188743753:
					assn.Flag2 = bool.Parse(sFieldVal);
					break;
				case 188743754:
					assn.Flag3 = bool.Parse(sFieldVal);
					break;
				case 188743755:
					assn.Flag4 = bool.Parse(sFieldVal);
					break;
				case 188743756:
					assn.Flag5 = bool.Parse(sFieldVal);
					break;
				case 188743757:
					assn.Flag6 = bool.Parse(sFieldVal);
					break;
				case 188743758:
					assn.Flag7 = bool.Parse(sFieldVal);
					break;
				case 188743759:
					assn.Flag8 = bool.Parse(sFieldVal);
					break;
				case 188743760:
					assn.Flag9 = bool.Parse(sFieldVal);
					break;
				case 188743761:
					assn.Flag10 = bool.Parse(sFieldVal);
					break;
				case 188743767:
					assn.Number1 = double.Parse(sFieldVal);
					break;
				case 188743768:
					assn.Number2 = double.Parse(sFieldVal);
					break;
				case 188743769:
					assn.Number3 = double.Parse(sFieldVal);
					break;
				case 188743770:
					assn.Number4 = double.Parse(sFieldVal);
					break;
				case 188743771:
					assn.Number5 = double.Parse(sFieldVal);
					break;
				case 188743783:
					assn.Duration1 = sFieldVal;
					break;
				case 188743784:
					assn.Duration2 = sFieldVal;
					break;
				case 188743785:
					assn.Duration3 = sFieldVal;
					break;
				case 188743786:
					assn.Cost1 = sFieldVal;
					break;
				case 188743787:
					assn.Cost2 = sFieldVal;
					break;
				case 188743788:
					assn.Cost3 = sFieldVal;
					break;
				case 188743938:
					assn.Cost4 = sFieldVal;
					break;
				case 188743939:
					assn.Cost5 = sFieldVal;
					break;
				case 188743940:
					assn.Cost6 = sFieldVal;
					break;
				case 188743941:
					assn.Cost7 = sFieldVal;
					break;
				case 188743942:
					assn.Cost8 = sFieldVal;
					break;
				case 188743943:
					assn.Cost9 = sFieldVal;
					break;
				case 188743944:
					assn.Cost10 = sFieldVal;
					break;
				case 188743945:
					assn.Date1 = sFieldVal;
					break;
				case 188743946:
					assn.Date2 = sFieldVal;
					break;
				case 188743947:
					assn.Date3 = sFieldVal;
					break;
				case 188743948:
					assn.Date4 = sFieldVal;
					break;
				case 188743949:
					assn.Date5 = sFieldVal;
					break;
				case 188743950:
					assn.Date6 = sFieldVal;
					break;
				case 188743951:
					assn.Date7 = sFieldVal;
					break;
				case 188743952:
					assn.Date8 = sFieldVal;
					break;
				case 188743953:
					assn.Date9 = sFieldVal;
					break;
				case 188743954:
					assn.Date10 = sFieldVal;
					break;
				case 188743955:
					assn.Duration4 = sFieldVal;
					break;
				case 188743956:
					assn.Duration5 = sFieldVal;
					break;
				case 188743957:
					assn.Duration6 = sFieldVal;
					break;
				case 188743958:
					assn.Duration7 = sFieldVal;
					break;
				case 188743959:
					assn.Duration8 = sFieldVal;
					break;
				case 188743960:
					assn.Duration9 = sFieldVal;
					break;
				case 188743961:
					assn.Duration10 = sFieldVal;
					break;
				case 188743962:
					assn.Start6 = sFieldVal;
					break;
				case 188743963:
					assn.Finish6 = sFieldVal;
					break;
				case 188743964:
					assn.Start7 = sFieldVal;
					break;
				case 188743965:
					assn.Finish7 = sFieldVal;
					break;
				case 188743966:
					assn.Start8 = sFieldVal;
					break;
				case 188743967:
					assn.Finish8 = sFieldVal;
					break;
				case 188743968:
					assn.Start9 = sFieldVal;
					break;
				case 188743969:
					assn.Finish9 = sFieldVal;
					break;
				case 188743970:
					assn.Start10 = sFieldVal;
					break;
				case 188743971:
					assn.Finish10 = sFieldVal;
					break;
				case 188743972:
					assn.Flag11 = bool.Parse(sFieldVal);
					break;
				case 188743973:
					assn.Flag12 = bool.Parse(sFieldVal);
					break;
				case 188743974:
					assn.Flag13 = bool.Parse(sFieldVal);
					break;
				case 188743975:
					assn.Flag14 = bool.Parse(sFieldVal);
					break;
				case 188743976:
					assn.Flag15 = bool.Parse(sFieldVal);
					break;
				case 188743977:
					assn.Flag16 = bool.Parse(sFieldVal);
					break;
				case 188743978:
					assn.Flag17 = bool.Parse(sFieldVal);
					break;
				case 188743979:
					assn.Flag18 = bool.Parse(sFieldVal);
					break;
				case 188743980:
					assn.Flag19 = bool.Parse(sFieldVal);
					break;
				case 188743981:
					assn.Flag20 = bool.Parse(sFieldVal);
					break;
				case 188743982:
					assn.Number6 = double.Parse(sFieldVal);
					break;
				case 188743983:
					assn.Number7 = double.Parse(sFieldVal);
					break;
				case 188743984:
					assn.Number8 = double.Parse(sFieldVal);
					break;
				case 188743985:
					assn.Number9 = double.Parse(sFieldVal);
					break;
				case 188743986:
					assn.Number10 = double.Parse(sFieldVal);
					break;
				case 188743987:
					assn.Number11 = double.Parse(sFieldVal);
					break;
				case 188743988:
					assn.Number12 = double.Parse(sFieldVal);
					break;
				case 188743989:
					assn.Number13 = double.Parse(sFieldVal);
					break;
				case 188743990:
					assn.Number14 = double.Parse(sFieldVal);
					break;
				case 188743991:
					assn.Number15 = double.Parse(sFieldVal);
					break;
				case 188743992:
					assn.Number16 = double.Parse(sFieldVal);
					break;
				case 188743993:
					assn.Number17 = double.Parse(sFieldVal);
					break;
				case 188743994:
					assn.Number18 = double.Parse(sFieldVal);
					break;
				case 188743995:
					assn.Number19 = double.Parse(sFieldVal);
					break;
				case 188743996:
					assn.Number20 = double.Parse(sFieldVal);
					break;
				case 188743997:
					assn.Text11 = sFieldVal;
					break;
				case 188743998:
					assn.Text12 = sFieldVal;
					break;
				case 188743999:
					assn.Text13 = sFieldVal;
					break;
				case 188744000:
					assn.Text14 = sFieldVal;
					break;
				case 188744001:
					assn.Text15 = sFieldVal;
					break;
				case 188744002:
					assn.Text16 = sFieldVal;
					break;
				case 188744003:
					assn.Text17 = sFieldVal;
					break;
				case 188744004:
					assn.Text18 = sFieldVal;
					break;
				case 188744005:
					assn.Text19 = sFieldVal;
					break;
				case 188744006:
					assn.Text20 = sFieldVal;
					break;
				case 188744007:
					assn.Text21 = sFieldVal;
					break;
				case 188744008:
					assn.Text22 = sFieldVal;
					break;
				case 188744009:
					assn.Text23 = sFieldVal;
					break;
				case 188744010:
					assn.Text24 = sFieldVal;
					break;
				case 188744011:
					assn.Text25 = sFieldVal;
					break;
				case 188744012:
					assn.Text26 = sFieldVal;
					break;
				case 188744013:
					assn.Text27 = sFieldVal;
					break;
				case 188744014:
					assn.Text28 = sFieldVal;
					break;
				case 188744015:
					assn.Text29 = sFieldVal;
					break;
				case 188744016:
					assn.Text30 = sFieldVal;
					break;
				case 188744162:
					assn.Baseline1Start = sFieldVal;
					break;
				case 188744163:
					assn.Baseline1Finish = sFieldVal;
					break;
				case 188744164:
					assn.Baseline1Cost = sFieldVal;
					break;
				case 188744173:
					assn.Baseline2Start = sFieldVal;
					break;
				case 188744174:
					assn.Baseline2Finish = sFieldVal;
					break;
				case 188744175:
					assn.Baseline2Cost = sFieldVal;
					break;
				case 188744184:
					assn.Baseline3Start = sFieldVal;
					break;
				case 188744185:
					assn.Baseline3Finish = sFieldVal;
					break;
				case 188744186:
					assn.Baseline3Cost = sFieldVal;
					break;
				case 188744195:
					assn.Baseline4Start = sFieldVal;
					break;
				case 188744196:
					assn.Baseline4Finish = sFieldVal;
					break;
				case 188744197:
					assn.Baseline4Cost = sFieldVal;
					break;
				case 188744206:
					assn.Baseline5Start = sFieldVal;
					break;
				case 188744207:
					assn.Baseline5Finish = sFieldVal;
					break;
				case 188744208:
					assn.Baseline5Cost = sFieldVal;
					break;
				case 188744224:
					assn.Baseline6Start = sFieldVal;
					break;
				case 188744225:
					assn.Baseline6Finish = sFieldVal;
					break;
				case 188744226:
					assn.Baseline6Cost = sFieldVal;
					break;
				case 188744235:
					assn.Baseline7Start = sFieldVal;
					break;
				case 188744236:
					assn.Baseline7Finish = sFieldVal;
					break;
				case 188744237:
					assn.Baseline7Cost = sFieldVal;
					break;
				case 188744246:
					assn.Baseline8Start = sFieldVal;
					break;
				case 188744247:
					assn.Baseline8Finish = sFieldVal;
					break;
				case 188744248:
					assn.Baseline8Cost = sFieldVal;
					break;
				case 188744257:
					assn.Baseline9Start = sFieldVal;
					break;
				case 188744258:
					assn.Baseline9Finish = sFieldVal;
					break;
				case 188744259:
					assn.Baseline9Cost = sFieldVal;
					break;
				case 188744268:
					assn.Baseline10Start = sFieldVal;
					break;
				case 188744269:
					assn.Baseline10Finish = sFieldVal;
					break;
				case 188744270:
					assn.Baseline10Cost = sFieldVal;
					break;
				default:
					tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
					break;
			}
			
		}

		private static void processAssignment(Connect.Tasks newTask, Microsoft.Office.Interop.MSProject.Project pj, Hashtable myHash)
		{
			if(newTask.taskuid.IndexOf(".") > 0)
			{
				int taskuid = 0;
				int assid=0;
				try
				{
					taskuid = int.Parse(newTask.taskuid.Substring(0,newTask.taskuid.IndexOf(".")));
					assid = int.Parse(newTask.taskuid.Substring(newTask.taskuid.IndexOf(".") + 1));
				}
				catch(System.Exception){}
				Task tsk = (Task)myHash[taskuid.ToString()];

				foreach(Assignment assn in tsk.Assignments)
				{
					if(assn.UniqueID == assid)
					{
						try
						{
							if(Connect.hTaskCenterFields.Contains("START"))
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["START"];
								if(tField.editable)
								{
									DateTime dt = Convert.ToDateTime(newTask.start);
									if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
									{
										DateTime dt2 = Convert.ToDateTime(assn.Start);
										assn.Start = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
									}
									else
									{
										assn.Start = newTask.start;
									}
								}
							}
						}
						catch(System.Exception){}
						try
						{
							if(Connect.hTaskCenterFields.Contains("FINISH"))
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["FINISH"];
								if(tField.editable)
								{
									DateTime dt = Convert.ToDateTime(newTask.finish);
									if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
									{
										DateTime dt2 = Convert.ToDateTime(assn.Finish);
										assn.Finish = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
									}
									else
									{
										assn.Finish = newTask.finish;
									}
								}
							}
						}
						catch(System.Exception){}
						try
						{
							if(Connect.hTaskCenterFields.Contains("PERCENTCOMPLETE"))
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["PERCENTCOMPLETE"];
								if(tField.editable)
								{
									assn.PercentWorkComplete = newTask.pctComplete;
								}
							}
						}
						catch(System.Exception){}
						
						try
						{
							if(Connect.hTaskCenterFields.Contains("NOTES"))
								assn.Notes = newTask.notes;
						}
						catch(System.Exception){}
						
						if(Connection.resUrl == "")
						{
							string[] ress = newTask.resource.Replace(";#","\n").Split('\n');
							if(ress.Length > 1)
							{
								int resUid = 0;
								for(int i = 0;i<CheckResources.resCount;i++)
								{
									if(CheckResources.resList[i].resId.ToString() == ress[0])
										resUid = CheckResources.resList[i].matchedResID;
								}
								if(resUid != 0)
								{
									if(resUid != assn.ResourceUniqueID)
										assn.ResourceUniqueID = resUid;
								}
							}
						}
						else
						{
							string field = Connect.getProperty("EPMLiveResField",pj);
							if(field == "")
								field = "Number15";
							int fieldId = 0;
							if(Update.hshResFields.Contains(field))
							{
								fieldId = (int)Update.hshResFields[field];
							}
							
							string[] ress = newTask.resource.Replace(";#","\n").Split('\n');

							if(ress.Length > 1)
							{
								for(int j = 0;j<CheckResources.resCount;j++)
									if(CheckResources.resList[j].ResourceID == int.Parse(ress[0]))
										if(CheckResources.resList[j].matchedResID != assn.ResourceUniqueID)
											assn.ResourceUniqueID = CheckResources.resList[j].matchedResID;
							}
						}
						string actualwork = "";
						string remainingwork = "";
						string fieldName = "";
						//Custom Fields
						foreach(DictionaryEntry entry in newTask.customFields)
						{
							try
							{
								int iField = 0;
								try
								{
									iField = Convert.ToInt32(entry.Key.ToString());
								}
								catch{}
	
								fieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString();

								switch(iField)
								{
									case 188743729:
									case 188743715:
									case 188743716:
									case 188743712:
									case 188743721:
									case 188743722:
									case 188743695:
										break;
									default:
										string sFieldVal =  entry.Value.ToString();
									
										
										//listView1.Items.Add(fieldName.Replace("pjTask","")).SubItems.Add(sFieldVal);

										if(iField == 188743684)
											remainingwork = sFieldVal;
										else if(iField == 188743682)
											actualwork = sFieldVal;
										else if(iField == 188744799)
										{
											try
											{
												sFieldVal = (Convert.ToDouble(sFieldVal) * 100).ToString();
												tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
											}
											catch{}
										}
										else
										{
											
											Connect.TaskField tField = null;
											if(Connect.hTaskCenterFields.Contains(fieldName.Replace("pjTask","").ToUpper()))
											{
												tField = (Connect.TaskField)Connect.hTaskCenterFields[fieldName.Replace("pjTask","").ToUpper()];
											}

											if(tField.type == 2 && sFieldVal == "")
												sFieldVal = "0";
	
											setAssignmentField(iField,sFieldVal,assn,tsk);

											if(tField != null && tField.wssFieldName == "TimesheetHours" && sFieldVal != "")
											{
												if(fieldName.Replace("pjTask","").ToLower() == Connect.getProperty("EPMLiveTSTimesheetHours",pj).ToString().ToLower())
												{
													double total = 0;
													foreach(Microsoft.Office.Interop.MSProject.Assignment assn2 in tsk.Assignments)
													{
														total += double.Parse(Publish.getFieldForAssignment(tsk, assn2, iField));
													}
													tsk.SetField((Microsoft.Office.Interop.MSProject.PjField)iField, total.ToString());
												}
											}
											
										
										}
										break;
								};
								fieldName = "";
							}
							catch(System.Exception ex)
							{
								MessageBox.Show("Error updating field (" + fieldName + "): " + ex.Message);
							}
						}
						try
						{
							if(actualwork != "" && remainingwork != "")
							{
								assn.ActualWork = actualwork;
								assn.RemainingWork = remainingwork;
							}
							else if(remainingwork != "")
							{
								assn.RemainingWork = remainingwork;
							}
							else if(actualwork != "")
							{
								assn.ActualWork = actualwork;
							}
						}
						catch{}
						try
						{
							if(Connect.hTaskCenterFields.Contains("ACTUALSTART"))
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALSTART"];
								if(tField.editable)
								{
									DateTime dt = Convert.ToDateTime(newTask.actualStart);
									if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
									{
										DateTime dt2 = Convert.ToDateTime(assn.ActualStart);
										assn.ActualStart = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
									}
									else
									{
										assn.ActualStart = newTask.actualStart;
									}
								}
							}
						}
						catch(System.Exception){}
						try
						{
							if(Connect.hTaskCenterFields.Contains("ACTUALFINISH"))
							{
								Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALFINISH"];
								if(tField.editable)
								{
									DateTime dt = Convert.ToDateTime(newTask.actualFinish);
									if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
									{
										DateTime dt2 = Convert.ToDateTime(assn.ActualFinish);
										assn.ActualFinish = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
									}
									else
									{
										assn.ActualFinish = newTask.actualFinish;
									}
								}
							}
						}
						catch(System.Exception){}
					}
				}
			}
			else
			{
				try
				{
					Task tsk = (Task)myHash[newTask.taskuid.ToString()];
					string[] ress = newTask.resource.Split(";#".ToCharArray());
					if(ress.Length > 2)
						for(int i = 0;i<CheckResources.resCount;i++)
							if(CheckResources.resList[i].matchedResID != 0)
								if(CheckResources.resList[i].name == ress[2])
									tsk.Assignments.Add(tsk.ID,CheckResources.resList[i].ResourceID,Missing.Value);
				}
				catch{}

			}
		}

		private static string addNewTask(Connect.Tasks newTask, Microsoft.Office.Interop.MSProject.Project pj)
		{
			Task nTask = pj.Tasks.Add(newTask.taskname,Missing.Value);
			nTask.Type = Microsoft.Office.Interop.MSProject.PjTaskFixedType.pjFixedUnits;
			//nTask.EffortDriven = false;

			DateTime dtStart = DateTime.Now;
			DateTime dtFinish = DateTime.Now;
			try
			{
				dtStart = DateTime.Parse(newTask.start);
			}
			catch{}
			try
			{
				dtFinish = DateTime.Parse(newTask.finish);
			}
			catch{}

			TimeSpan ts = dtFinish-dtStart;
			
			try
			{
				nTask.Start = newTask.start;
			}
			catch(System.Exception){}
			try
			{
				nTask.Finish = newTask.finish;
			}
			catch(System.Exception){}
			try
			{
				nTask.PercentComplete = newTask.pctComplete;
			}
			catch(System.Exception){}

			
			nTask.Notes = newTask.notes;
			//Custom Fields
			string actualwork = "";
			string remainingwork = "";
			foreach(DictionaryEntry entry in newTask.customFields)
			{
				try
				{
					int iField = 0;
					try
					{
						iField = Convert.ToInt32(entry.Key.ToString());
					}
					catch{}
					switch(iField)
					{
						case 188743729:
						case 188743715:
						case 188743716:
						case 188743712:
						case 188743721:
						case 188743722:
						case 188743680:
						case 188743682:
						case 188743684:
						case 188743695:
							break;
						default:
							string sFieldVal =  entry.Value.ToString();

							string fieldName = ((Microsoft.Office.Interop.MSProject.PjField)iField).ToString();

							if(iField == 188743684)
								remainingwork = sFieldVal;
							else if(iField == 188743682)
								actualwork = sFieldVal;
							else if(iField == 188744799)
							{
								try
								{
									sFieldVal = (Convert.ToDouble(sFieldVal) * 100).ToString();
									nTask.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
								}
								catch{}
							}
							else
							{
								nTask.SetField((Microsoft.Office.Interop.MSProject.PjField)iField,sFieldVal);
							}
							break;
					};
				}
				catch{}
			}

			if(actualwork != "" && remainingwork != "")
			{
				nTask.ActualWork = actualwork;
				nTask.RemainingWork = remainingwork;
			}
			else if(remainingwork != "")
			{
				nTask.RemainingWork = remainingwork;
			}
			try
			{
				if(Connect.hTaskCenterFields.Contains("ACTUALSTART"))
				{
					Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALSTART"];
					if(tField.editable)
					{
						DateTime dt = Convert.ToDateTime(newTask.actualStart);
						if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
						{
							DateTime dt2 = Convert.ToDateTime(nTask.ActualStart);
							nTask.ActualStart = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
						}
						else
						{
							nTask.ActualStart = newTask.actualStart;
						}
					}
				}
			}
			catch(System.Exception){}
			try
			{
				if(Connect.hTaskCenterFields.Contains("ACTUALFINISH"))
				{
					Connect.TaskField tField = (Connect.TaskField)Connect.hTaskCenterFields["ACTUALFINISH"];
					if(tField.editable)
					{
						DateTime dt = Convert.ToDateTime(newTask.actualFinish);
						if(dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
						{
							DateTime dt2 = Convert.ToDateTime(nTask.ActualFinish);
							nTask.ActualFinish = dt.ToShortDateString() + " " + dt2.ToShortTimeString();
						}
						else
						{
							nTask.ActualFinish = newTask.actualFinish;
						}
					}
				}
			}
			catch(System.Exception){}

			//===========Resource Assignments==============
			if(Connection.resUrl == "")
			{
				string[] ress = newTask.resource.Split(";#".ToCharArray());
				if(ress.Length >2)
				{
					for(int i=2;i<ress.Length;i=i+4)
					{
						foreach(Resource resAssn in pj.Resources)
						{
							if(resAssn!=null)
							{
								if(resAssn.Name == ress[i])
								{
									nTask.Assignments.Add(Missing.Value, resAssn.ID, Missing.Value);
								}
							}
						}
					}
				}
			}
			else
			{
				string field = Connect.getProperty("EPMLiveResField",pj);
				if(field == "")
					field = "Number15";
				int fieldId = 0;

				if(Update.hshResFields.Contains(field))
				{
					fieldId = (int)Update.hshResFields[field];
				}

				string[] ress = newTask.resource.Replace(";#","\n").Split('\n');

				for(int i = 0;i<ress.Length;i=i+2)
				{
					for(int j = 0;j<CheckResources.resCount;j++)
						if(ress[i] != "")
							if(CheckResources.resList[j].ResourceID == int.Parse(ress[i]))
								foreach(Resource res in pj.Resources)
									if(Connect.getResField(fieldId,res) == CheckResources.resList[j].resId.ToString())
										nTask.Assignments.Add(Missing.Value,res.ID,Missing.Value);
				}
			}

			return nTask.UniqueID.ToString();
		}

		private static string processItem(Connect.Tasks taskItem, Microsoft.Office.Interop.MSProject.Project pj, Hashtable myHash)
		{
			if(taskItem.moderationStatus == 2)
			{
				//Connect.Tasks newTask = Connect.taskList[int.Parse(li.Tag.ToString())];
				if(taskItem.taskuid == null || taskItem.taskuid == "")
				{
					return addNewTask(taskItem,pj);
				}
				else
				{
					if(taskItem.type == 0)
					{
						processTask(taskItem,pj,myHash);
					}
					else//Assignment Based Task
					{
						processAssignment(taskItem,pj,myHash);
					}
					
				}
			}
			return taskItem.taskuid;
		}
	}
}
