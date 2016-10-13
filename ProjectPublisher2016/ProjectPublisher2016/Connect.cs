/* 
 * File: Connect.cs
 * Owner: Jason Hughes
 * Last Modification Date: 7/2/2008
 * Description:
 * This file gets loaded when the addin is loaded in Microsoft Office Project.
 * OnStartupComplete gets called first.
 * 
 */
namespace ProjectPublisher2016
{
    
	using System;
	using Microsoft.Office.Core;
	using System.Runtime.InteropServices;
	using System.Reflection;
	using System.Windows.Forms;
	using System.Diagnostics;
	using System.Collections;
	using System.IO;
	using System.Xml;
	using System.Net;
	using System.Threading;
	using System.ComponentModel;
	using Microsoft.Win32;
	//using Microsoft.Office.Interop.MSProject;
    using MSProject = Microsoft.Office.Interop.MSProject;
    using Office = Microsoft.Office.Core;


	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the MyAddin21Setup project 
	// by right clicking the project in the Solution Explorer, then choosing install.
	#endregion
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("CB4B9AEA-C1C0-487E-8555-C391398C6C13"), ProgId("Addin.Connect")]
	public class Connect
	{
        
		public static System.Net.WebProxy webProxy = System.Net.WebProxy.GetDefaultProxy();

		delegate void timerService(Microsoft.Office.Interop.MSProject.Application app);

		public static string strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

		const int ENTVERSION = 3;

		public static Thread worker;

		public static Hashtable logins;
		public static Hashtable opens;
		public static Hashtable hPprojectFields;
		public static Hashtable hLoadedFields;
		public static bool isProjServer;
		public static bool disableProjectServer;

		public static Hashtable hProjectCenterFields;
		public static Hashtable hTaskCenterFields;

		//private Microsoft.Office.Interop.MSProject._EProjectDoc_OpenEventHandler ProjectOpen;
		System.Timers.Timer timer1 = new System.Timers.Timer(1000);
		System.Timers.Timer timerCloseWindows = new System.Timers.Timer(100);
		private Microsoft.Office.Interop.MSProject.Project pj;
		//private Microsoft.Office.Interop.MSProject.Task tsk;

		public struct Tasks
		{
			public string taskname;
			public string taskuid;
			public string pctComplete;
			public string start;
			public string finish;
			public string actualStart;
			public string actualFinish;
			public string notes;
			public string moderationNotes;
			public int moderationStatus;
			public string resource;
			public string breadCrumbs;
			public int type;
			public string ListID;
			public string milestone;
			public Hashtable customFields;
			public bool isValid;
			public string modifiedBy;
		}

		public class TaskField
		{	
			public int fieldId;
			public string fieldName;
			public string displayName = "";
			public string format;
			public bool editable;
			public bool builtin;
			public int type;
			public string innerXml;
			public string outerXml;
			public string required = "";
			public string wssFieldName;
			public override string ToString()
			{
				if(builtin)
					return displayName + "*";

				if(fieldName != displayName && displayName.Trim() != "")
					return fieldName.Replace("_x0020_","") + " (" + displayName + ")";

				return fieldName;
			}
		}	

		public static Tasks[] taskList;
		public string pubType;
		public static Hashtable projectCenterFields;

		public static Hashtable projectUpdateSaves = new Hashtable();

		public Microsoft.Office.Interop.MSProject.Application app;


        public static void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally
            {
                o = null;
            }
        }

		/***********************************************
		* Procedure: shouldCheck
		* Purpose: Determines whether to check for a new version
		* Parameters In: 
		* Parameters Out: boolean (true to check for updates, otherwise false)
		***********************************************/
		public static bool shouldCheck()
		{
			try
			{
				string check = RegistryClass.GetSetting("Tr","versioncheck","");
				if(check=="True")
					return false;
				else
					return true;
			}
			catch(Exception)
			{
				return true;
			}
		}

		/***********************************************
		* Procedure: versionCheck
		* Purpose: Check for a new version of Project Publisher
		* Parameters In: bool (to force a check)
		* Parameters Out:
		***********************************************/
		private void versionCheck(bool force)
		{
			if(Connect.shouldCheck() || force)
			{
				try
				{
					bool isNewVersion = false;
					string newVersion = getVersion();
					string curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

					string []newTemp = newVersion.Split('\n');

					string newVersionFile = newTemp[1];
					string newVersionUrl = newTemp[2];
					string []newVersionArr = newTemp[0].Split('.');
					string []curVersionArr = curVersion.Split('.');
				
					int nv;
					int cv;
					nv = int.Parse(newVersionArr[0]);
					cv = int.Parse(curVersionArr[0]);
					if(nv>cv)
						isNewVersion = true;
					else if(nv==cv)
					{
						nv = int.Parse(newVersionArr[1]);
						cv = int.Parse(curVersionArr[1]);
						if(nv>cv)
							isNewVersion = true;
						else if(nv==cv)
						{
							nv = int.Parse(newVersionArr[2]);
							cv = int.Parse(curVersionArr[2]);
							if(nv>cv)
								isNewVersion = true;
							else if(nv==cv)
							{
								nv = int.Parse(newVersionArr[3]);
								cv = int.Parse(curVersionArr[3]);
								if(nv>cv)
									isNewVersion = true;
							}
						}
					}
					if(isNewVersion)
					{
						FormNewVersion frmNew = new FormNewVersion(newVersionUrl);
						frmNew.ShowDialog();

						RegistryClass.SaveSetting("Tr","versioncheck",frmNew.checkBox1.Checked.ToString());

						if(frmNew.DialogResult == DialogResult.Yes)
							Process.Start("iexplore",newVersionFile);
						frmNew.Hide();
						frmNew.Refresh();
						frmNew.Dispose();
					}
					else if(force)
					{
						MessageBox.Show("You are running the most current version.");
					}
				}
				catch(Exception)
				{
					//MessageBox.Show(ex.Message.ToString() + "\n\n" + ex.StackTrace.ToString());
				}
				
			}
		}
		/***********************************************
		* Procedure: getAttribute
		* Purpose: Gets an attribute from an xml node and does error checking
		* Parameters In: 
		*	XmlNode (Node to do work on)
		*	attr (name of the attribute)
		* Parameters Out:
		*	string (value of the attribute)
		***********************************************/
		public static string getAttribute(XmlNode nd, string attr)
		{
			try
			{
				return nd.Attributes[attr].Value;
			}
			catch{}
			return "";
		}
		/***********************************************
		* Procedure: moveReg
		* Purpose:
		*	If Microsoft Office Project gets updated a new registry location is used due to a version number change
		*	This function moves all the current registry settings into the new version.
		* Parameters In: 
		* Parameters Out: 
		*	boolean (true if everything worked, else false)
		***********************************************/
		private bool moveReg()
		{
			//RegistryKey key = Application.UserAppDataRegistry.CreateSubKey("Tr");
			try
			{
                string ver = Application.UserAppDataRegistry.Name;
                ver = Path.GetDirectoryName(ver);

                ver = ver.Substring(ver.LastIndexOf("\\")+1);

				RegistryKey key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft Corporation").OpenSubKey(ver);
				DateTime final = DateTime.Now;
				string idToUse = "";
				foreach(string rkey in key.GetSubKeyNames())
				{
					try
					{
						RegistryKey tKey = key.OpenSubKey(rkey).OpenSubKey("Tr");
						DateTime dt = new DateTime(long.Parse(tKey.GetValue("ID").ToString()));
						if(dt < final)
						{
							idToUse = rkey;
							final = dt;
						}
					}
					catch{}
				}
				if(idToUse != "")
				{
					try
					{
						RegistryKey key1 = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft Corporation").OpenSubKey(ver).OpenSubKey(idToUse).OpenSubKey("Tr");
						RegistryKey key2 = Application.UserAppDataRegistry.CreateSubKey("Tr");
						foreach(string s in key1.GetValueNames())
						{
							try
							{
								key2.SetValue(s,key1.GetValue(s).ToString());
							}
							catch{}
						}
					}
					catch{}
					return true;
				}
			}
			catch{}
			
			return false;
		}
		/***********************************************
		* Procedure: startupCheck
		* Purpose: Function gets called everytime and puts entry in registry.
		* Parameters In: 
		* Parameters Out: 
		***********************************************/
		private void startupCheck()
		{

			string strDtInst = RegistryClass.GetSetting("Tr","ID","");
			if(strDtInst == "")
			{
				if(!moveReg())
					RegistryClass.SaveSetting("Tr","ID",DateTime.Now.Ticks.ToString());
			}
			else
			{
				try
				{
					DateTime dtInst = DateTime.Parse(strDtInst);
					RegistryClass.SaveSetting("Tr","ID",dtInst.Ticks.ToString());
				}
				catch
				{
					//RegistryClass.SaveSetting("Tr","ID",DateTime.Now.Ticks.ToString());
				}
			}
		}
		/***********************************************
		* Procedure: getVersion
		* Purpose: Gets the version of the current release of publisher from EPM Live
		* Parameters In: 
		* Parameters Out: string a version number
		***********************************************/
		private string getVersion()
		{
			HttpWebRequest request;
			HttpWebResponse response;

            request = (HttpWebRequest)WebRequest.Create("http://www.projectpublisher.com/publisherv4.txt");
			request.AllowAutoRedirect = false;
			
			if(RegistryClass.GetSetting("Tr","UseProxy","") == "True")
			{
				System.Net.WebProxy pr = new System.Net.WebProxy("http://" + RegistryClass.GetSetting("Tr","ProxyServer","") + ":" + RegistryClass.GetSetting("Tr","ProxyPort",""), true);
				if(RegistryClass.GetSetting("Tr","ProxyAuth","") == "True")
					if(RegistryClass.GetSetting("Tr","ProxyUseWindows","") == "True")
						pr.Credentials = System.Net.CredentialCache.DefaultCredentials;
					else
						pr.Credentials = new System.Net.NetworkCredential(RegistryClass.GetSetting("Tr","ProxyUsername",""),RegistryClass.GetSetting("Tr","ProxyPassword",""));
				request.Proxy = pr;
			}

			response = (HttpWebResponse)request.GetResponse();
			string res = "";
			using (Stream s = response.GetResponseStream())
			{
				StreamReader sr = new StreamReader(s);
				while (true)
				{
					string read = sr.ReadLine();
					if(read != null)
						res = res + read + "\n";
					else
						break;
				}
			}

			return res;
		}
		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		/// 
		
		public void StartUp()
		{
            logins = new Hashtable();
			try
			{
				startupCheck();

				if(app.Profiles.ActiveProfile != null && app.Profiles.ActiveProfile.Type == Microsoft.Office.Interop.MSProject.PjProfileType.pjServerProfile)
				{
					Connect.isProjServer = true;
				}
				else
				{
					versionCheck(false);
					Connect.isProjServer = false;
				}

			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message.ToString()  , "MyCOMAddin");
			}

			app.ProjectBeforeSave += new Microsoft.Office.Interop.MSProject._EProjectApp2_ProjectBeforeSaveEventHandler(app_ProjectBeforeSave);
			//app.WindowDeactivate += new Microsoft.Office.Interop.MSProject._EProjectApp2_WindowDeactivateEventHandler(app_WindowDeactivate);
			app.WindowSelectionChange+=new Microsoft.Office.Interop.MSProject._EProjectApp2_WindowSelectionChangeEventHandler(app_WindowSelectionChange);
			app.ProjectBeforePublish +=new Microsoft.Office.Interop.MSProject._EProjectApp2_ProjectBeforePublishEventHandler(app_ProjectBeforePublish);
			//app.ActiveProject.Open += new Microsoft.Office.Interop.MSProject._EProjectDoc_OpenEventHandler(ActiveProject_Open);
			//app.ActiveProject.Open += new Microsoft.Office.Interop.MSProject._EProjectDoc_OpenEventHandler(Project_Open);
			Connection.app = this.app;
			opens = new Hashtable();
			
			hPprojectFields = new Hashtable();

			try
			{
				hLoadedFields = new Hashtable();
				StreamReader sr = new StreamReader(strAppDir + "\\fields.txt");
				string fieldval = sr.ReadLine();
				while((fieldval = sr.ReadLine()) != null)
				{
					string []fvals = fieldval.Split('\t');
					if(fvals.Length > 1)
					{
						hLoadedFields.Add(fvals[0].ToLower(),fvals[1]);
					}
				}
				sr.Close();
			}
			catch{}

			app.ProjectBeforeTaskChange+=new Microsoft.Office.Interop.MSProject._EProjectApp2_ProjectBeforeTaskChangeEventHandler(app_ProjectBeforeTaskChange);

			foreach(Microsoft.Office.Interop.MSProject.PjField val in Enum.GetValues(typeof(Microsoft.Office.Interop.MSProject.PjField)))
			{
				try
				{
					string fieldName = val.ToString();
					int type = 0;
					if(validProjectField(fieldName, out type))
					{
						
						TaskField tField = new TaskField();
						tField.fieldName = fieldName.Replace("pjTask","");
						string icapfieldName = tField.fieldName;
						tField.fieldId = (int)val;
						tField.type = type;
						fieldName = fieldName.Replace("pjTask","").ToUpper();
						hPprojectFields.Add(fieldName, tField);
						
					}
				}
				catch{}	
			}

            if (RegistryClass.GetSetting("Tr", "EnablePPM", "").ToLower() == "true")
            {
                //TODO: Ribbon
                Globals.Ribbons.PublisherRibbon.group3.Visible = true;
                Globals.Ribbons.PublisherRibbon.mnuImportExport.Visible = true;
                Globals.Ribbons.PublisherRibbon.btnEnablePPM.Checked = true;
            }
            else
            {
                Globals.Ribbons.PublisherRibbon.btnEnablePPM.Checked = false;
                Globals.Ribbons.PublisherRibbon.mnuImportExport.Visible = false;
                Globals.Ribbons.PublisherRibbon.group3.Visible = false;
            }

			TaskField tField1 = new TaskField();
			tField1.fieldName = "MSProjectStatus";
			tField1.fieldId = 0;
			tField1.type = 1;
			string fieldName1 = "MSPROJECTSTATUS";
			hPprojectFields.Add(fieldName1,tField1);

			if(isProjServer)
			{


                Globals.Ribbons.PublisherRibbon.cbbDisablePS.Visible = true;
				string strDisable = RegistryClass.GetSetting("Tr","DisableProjectServer","");

				if(strDisable == "True")
				{
					disableProjectServer = true;
					isProjServer = false;
                    Globals.Ribbons.PublisherRibbon.cbbDisablePS.Checked = true;
					
				}
				else
				{
					disableProjectServer = false;
                    Globals.Ribbons.PublisherRibbon.cbbDisablePS.Checked = false;
				}
			}
			else
			{
                Globals.Ribbons.PublisherRibbon.cbbDisablePS.Visible = false;
			}
			if(isProjServer)
			{
				this.disableMenus();
				ThreadStart ts = new ThreadStart(pubWindowClose);
				worker = new Thread (ts);
				worker.IsBackground = true;
				worker.Start();
			}

			runTimer();

		}
		/***********************************************
		* Procedure: validProjectField
		* Purpose: takes a field name and determines if the field is valid
		* Parameters In: 
		*	string (Name of field)
		*	out int (will return the field type)
		* Parameters Out: 
		*	boolean (true if the field is valid)
		***********************************************/
		public bool validProjectField(string fieldName, out int type)
		{
			type = 0;
			if(fieldName.Substring(0,6) == "pjTask")
			{

				fieldName = fieldName.Substring(6);

				if(hLoadedFields.Count > 0)
				{
					if(hLoadedFields.Contains(fieldName.ToLower()))
					{
						string sType = hLoadedFields[fieldName.ToLower()].ToString();
						try
						{
							type = int.Parse(sType);
						}
						catch{}
						return true;
					}
				}
				else
				{

					if(validTextField(fieldName))
					{
						type = 1;
						return true;
					}
					if(validNumberField(fieldName))
					{
						type = 2;
						return true;
					}
					if(validCurrencyField(fieldName))
					{
						type = 3;
						return true;
					}
					if(validDateTimeField(fieldName))
					{
						type = 4;
						return true;
					}
					if(validBooleanField(fieldName))
					{
						type = 5;
						return true;
					}
				}
			}
			return false;
		}

		/***********************************************
		* Procedure: validCurrencyField
		* Purpose: Determines whether a field is a currency field
		* Parameters In:
		*	string (name of field)
		* Parameters Out: 
		*	bool (true if the field is a currency field)
		***********************************************/

		public static bool validCurrencyField(string name)
		{
			switch(name.ToUpper())
			{
				case "ACTUALOVERTIMECOST":
				case "BASELINEBUDGETCOST":
				case "BASELINECOST":
				case "BASELINEFIXEDCOSTACCRUAL":
				case "BUDGETCOST":
				case "COSTVARIANCE":
				case "BCWS":
				case "BCWP":
				case "ACWP":
				case "FIXEDCOST":
				case "FIXEDCOSTACCRUAL":
				case "OVERTIMECOST":
				case "REMAININGCOST":
				case "REMAININGOVERTIMECOST":
				case "CV":
				case "SV":
				case "EAC":
				case "COST":
				case "ACTUALCOST":
					return true;
			}
			if(name.Length > 4)
			{
				if(name.Substring(0,4).ToUpper() == "COST")
				{
					string sNum = name.Substring(4);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 10)
							return true;
					}
					catch{}
				}
			}
			return false;
		}
		/***********************************************
		* Procedure: validDateTimeField
		* Purpose: Determines whether a field is a datetime field
		* Parameters In:
		*	string (name of field)
		* Parameters Out: 
		*	bool (true if the field is a date field)
		***********************************************/

		public static bool validDateTimeField(string name)
		{
			switch(name.ToUpper())
			{
				case "BASELINEDELIVERABLEFINISH":
				case "BASELINEDELIVERABLESTART":
				case "BASELINEFINISH":
				case "BASELINESTART":
				case "EARLYFINISH":
				case "EARLYSTART":
				case "FINISHSLACK":
				case "LATEFINISH":
				case "LATESTART":
				case "ACTUALSTART":
				case "ACTUALFINISH":
				case "DEADLINE":
				case "START":
				case "FINISH":
					return true;
			}
			if(name.Length > 4)
			{
				if(name.Substring(0,4).ToUpper() == "DATE")
				{
					string sNum = name.Substring(4);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <=	10)
							return true;
					}
					catch{}
				}
			}
			if(name.Length >5)
			{
				if(name.Substring(0,5).ToUpper() == "START")
				{
					string sNum = name.Substring(5);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 10)
							return true;
					}
					catch{}
				}
			}
			if(name.Length > 6)
			{
				if(name.Substring(0,6).ToUpper() == "FINISH")
				{
					string sNum = name.Substring(6);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 10)
							return true;
					}
					catch{}
				}
			}
			return false;
		}
		/***********************************************
		* Procedure: validBooleanField
		* Purpose: Determines whether a field is a flag field
		* Parameters In:
		*	string (name of field)
		* Parameters Out: 
		*	bool (true if the field is a flag field)
		***********************************************/
		public static bool validBooleanField(string name)
		{
			switch(name.ToUpper())
			{
				case "SUMMARY":
				case "CRITICAL":
				case "MILESTONE":
					return true;
			}
			if(name.Length > 4)
			{
				if(name.Substring(0,4).ToUpper() == "FLAG")
				{
					string sNum = name.Substring(4);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 20)
							return true;
					}
					catch{}
				}
			}
			return false;
		}
		/***********************************************
		* Procedure: validNumberField
		* Purpose: Determines whether a field is a number field
		* Parameters In:
		*	string (name of field)
		* Parameters Out: 
		*	bool (true if the field is a number field)
		***********************************************/
		public static bool validNumberField(string name)
		{
			switch(name.ToUpper())
			{
				case "ACTUALOVERTIMEWORK":
				case "ACTUALWORK":
				case "BASELINEBUDGETWORK":
				case "BASELINEDURATION":
				case "BASELINEWORK":
				case "BUDGETWORK":
				case "CPI":
				case "CVPERCENT":
				case "DURATIONVARIANCE":
				case "FINISHVARIANCE":
				case "FIXEDDURATION":
				case "FREESLACK":
				case "OVERTIMEWORK":
				case "PHYSICALPERCENTCOMPLETE":
				case "PERCENTCOMPLETE":
				case "REGULARWORK":
				case "REMAININGDURATION":
				case "REMAININGOVERTIMEWORK":
				case "REMAININGWORK":
				case "SPI":
				case "STARTSLACK":
				case "STARTVARIANCE":
				case "SVPERCENT":
				case "TCPI":
				case "TOTALSLACK":
				case "VAC":
				case "WORKVARIANCE":
				case "WORK":
				case "DURATION":
				case "ACTUALDURATION":
				case "PRIORITY":
					return true;
			}
			if(name.Length > 6)
			{
				if(name.Substring(0,6).ToUpper() == "NUMBER")
				{
					string sNum = name.Substring(6);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 20)
							return true;
					}
					catch{}
				}
			}
			if(name.Length > 8)
			{
				if(name.Substring(0,8).ToUpper() == "DURATION")
				{
					string sNum = name.Substring(8);
					int iNum = 0;
					try
					{
						iNum = Convert.ToInt32(sNum);
						if(iNum > 0 && iNum <= 10)
							return true;
					}
					catch{}
				}
			}
			return false;
		}
		/***********************************************
		* Procedure: validTextField
		* Purpose: Determines whether a field is a text field
		* Parameters In:
		*	string (name of field)
		* Parameters Out: 
		*	bool (true if the field is a text field)
		***********************************************/
		public static bool validTextField(string name)
		{
			switch(name.ToUpper())
			{
				case "PREDECESSORS":
				case "SUCCESSORS":
				case "TASKTYPE":
				case "NOTES":
				case "RESOURCENAMES":
				case "OUTLINENUMBER":
					return true;
				default:
					if(name.Length > 4)
					{
						if(name.Substring(0,4).ToUpper() == "TEXT")
						{
							string sNum = name.Substring(4);
							int iNum = 0;
							try
							{
								iNum = Convert.ToInt32(sNum);
								if(iNum > 0 && iNum <= 30)
									return true;
							}
							catch{}
							return false;
						}
					}
					return false;
			};
		}
		/***********************************************
		* Procedure: validWssField
		* Purpose: Determines whether a field is a flag field
		* Parameters In:
		*	string (type of field)
		*	string (name of field)
		*	out in (fieldType)
		*	out bool (whether field is builtin)
		*	bool (if we are checking project center)
		* Parameters Out: 
		*	bool (true if the field is a wss field)
		***********************************************/
		public static bool validWssField(string type, string name, out int fieldType, out bool builtin, bool projectCenter)
		{
			fieldType = 0;
			builtin = false;
			
			name = name.ToUpper().Replace("_x0020_","");

			//if(projectCenter)
			//	MessageBox.Show(name + " " + type);
//			if(!projectCenter)
//			{
//				
//				/*switch(name)
//				{
//					case "DURATION":
//					case "ACTUALDURATION":
//					case "WORK":
//					case "ACTUALWORK":
//					case "PRIORITY":
//					case "PERCENTCOMPLETE":
//					case "PHYSICAL_X0025_COM":
//						fieldType = 2;
//						return true;
//					case "COST":
//					case "ACTUALCOST":
//						fieldType = 3;
//						return true;
//					case "TITLE":
//						fieldType = 1;
//						return true;
//					case "STARTDATE":
//					case "DUEDATE":
//					case "ACTUALSTART":
//					case "ACTUALFINISH":
//						fieldType = 4;
//						return true;
//					case "MILESTONE":
//					case "CRITICAL":
//						fieldType = 5;
//						return true;
//				};*/
//
//				
//			}
//			else
//			{
//				//if(name == "BASELINEDURATION" || name == "BASELINESTART" || name == "BASELINEFINISH" || name == "BASELINEWORK" || name == "REMAININGDURATION" || name == "FIXEDCOST" || name == "WORKVARIANCE" || name == "ACTUALWORK")
//					//return false;																											
//			}

			switch(name)
			{
				case "MSPROJECTSTATUS":
					fieldType = 1;
					return true;
                case "NOTES":
                    if (!projectCenter)
                    {
                        fieldType = 1;
                        return true;
                    }
                    else
                        return false;
				case "STARTDATE":
				case "DUEDATE":
					fieldType = 4;
					return true;
				case "ASSIGNEDTO":
					fieldType = 6;
					return true;
				case "STATUS":
					fieldType = 7;
					return true;
				case "TASKHIERARCHY":
					fieldType = 1;
					return true;
				case "RESOURCENAMES":
					fieldType = 1;
					return true;
                case "ISPUBLISHED":
                    fieldType = 1;
                    return true;
			};

			if(Connect.hPprojectFields.Contains(name.ToUpper()))
			{
				if(type == "Text")
				{
					fieldType = 1;
					return validTextField(name);
				}
				if(type == "Choice")
				{
					fieldType = 7;
					return validTextField(name);
				}
				if(type == "Lookup")
				{
					fieldType = 8;
					return validTextField(name);
				}
				if(type == "Number")
				{
					if(validNumberField(name))
					{
						fieldType = 2;
						return true;
					}
				}

				if(type == "Currency")
				{
					if(validCurrencyField(name))
					{
						fieldType = 3;
						return true;
					}
				}

				if(type == "Boolean")
				{
					fieldType = 5;
					return validBooleanField(name);
				}

				if(type == "DateTime")
				{
					if(validDateTimeField(name))
					{
						fieldType = 4;
						return true;
					}
				}

				if(type == "Calculated")
				{
					fieldType=9;
					if(validTextField(name))
						return true;
					if(validNumberField(name))
						return true;
					if(validCurrencyField(name))
						return true;
					if(validBooleanField(name))
						return true;
					if(validDateTimeField(name))
						return true;
				}
			}
			return false;
		}

		/***********************************************
		* Procedure: runTimer
		* Purpose: Runs through the projects and checks to see if they need to check for updates
		* Parameters In:
		* Parameters Out: 
		***********************************************/
		public void runTimer()
		{
			//while(true)
			{
				foreach(Microsoft.Office.Interop.MSProject.Project pj in app.Projects)
				{
					if(!Connect.opens.Contains(pj.Name))
					{
						pj.Activate();
						Application.DoEvents();
						Thread.Sleep(1000);

						opens.Add(pj.Name," ");
						pj.BeforeClose += new Microsoft.Office.Interop.MSProject._EProjectDoc_BeforeCloseEventHandler(pj_BeforeClose);
						string doUpdate = Connect.getProperty("EPMLiveSU",pj);
						string doSynch = Connect.getProperty("EPMLiveSynchFields",pj);
						string url = Connect.getProperty("EPMLiveURL",pj);

						try
						{
							if(url == "")
							{
								string path = Path.GetDirectoryName(pj.Name).Replace("\\","/").Replace("http:/","http://").Replace("https:/","https://");
								string file = Path.GetFileName(pj.Name);
								if(file.ToLower() != "template.mpp")
								{
                                    int lastslash = path.LastIndexOf("/Project%20Schedules");
									path = path.Substring(0,lastslash);
									Connect.setProperty("EPMLiveURL",pj,path);
									url = path;
								}
							}
						}
						catch{}
						

						if(doSynch.ToUpper() == "TRUE" && url != "")
						{
							SynchFields.synchFields(pj,true);
						}
						if(doUpdate.ToUpper() == "TRUE" && url != "")
						{
							url = Connect.connectToSite(pj,true,true);
							if(url != "")
							{
								Connection.app.StatusBar = "Getting updates for: " + Connection.getProjectName(pj);
								if(Connect.isProjServer)
								{
									runEntTaskUpdates(pj);
								}
								else
								{
									if(Update.getUpdateCount(pj) > 0)
									{
										DialogResult dRes = MessageBox.Show("You have task updates for '" + Connection.getProjectName(pj) + "', would you like to process them now?","Updates",MessageBoxButtons.YesNo);
										Thread.Sleep(500);
										if(dRes==DialogResult.Yes)
										{
											pj.Activate();
											bool cancel = false;
                                            UpdateButton();
										
											//CheckResources.pj = pj;
										
											//										CheckResources.check(true, pj);
											//										Application.DoEvents();
											//										Thread.Sleep(500);
											//										Update.update(pj,Connection.app);
										}
									}
								}
							}
							Connection.app.StatusBar = false;
						}
						
					}
				}
				Connection.app.StatusBar = false;
			}
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
			try
			{
				/*object omissing = System.Reflection.Missing.Value ;
				MyButton.Delete(omissing);
				MyButton = null;
				MyButton1.Delete(omissing);
				MyButton1 = null;
				&MyButton4.Delete(omissing);
				MyButton4 = null;
				MyButton5.Delete(omissing);
				MyButton5 = null;
				MyButton6.Delete(omissing);
				MyButton6 = null;
				MyButton3.Delete(omissing);
				MyButton3 = null;
				EPMLiveMenu.Delete(omissing);
				EPMLiveMenu = null;*/
			}
			catch{}
		}
		public void Updates()
		{
			versionCheck(true);
		}
		/***********************************************
		* Procedure: MyButtonOptions_Click
		* Purpose: Runs when the Options button is clicked
		* Parameters In:
		* Parameters Out: 
		***********************************************/
		public void OptionsButton() 
		{
			//if(!RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject),true,false))
			//	return;
			if(Connect.isProjServer)
			{
				FormEntOptions frmOptions = new FormEntOptions();
				frmOptions.app = app;
				frmOptions.ShowDialog();
				frmOptions.Dispose();
			}
			else
			{
				FormOptions frmOptions = new FormOptions();
				frmOptions.app = app;
				frmOptions.ShowDialog();
				frmOptions.Dispose();
			}
		}
		/***********************************************
		* Procedure: MyButtonActivate_Click
		* Purpose: Runs when the Activate button is clicked
		* Parameters In:
		* Parameters Out: 
		***********************************************/
		public void Activate() 
		{
			if(RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject), false, true))
			{
				MessageBox.Show("Your product has already been activated");
			}
			else
			{
				DateTime dtCreated = DateTime.Now.AddDays(-31);
				try
				{
					dtCreated = new DateTime(long.Parse(RegistryClass.GetSetting("Tr","ID",Convert.ToDateTime("1/1/1900").Ticks.ToString())));
				}
				catch{}
				//DateTime dtCreated = DateTime.Parse(RegistryClass.GetSetting("Tr","ID",Convert.ToDateTime("1/1/1900").Ticks.ToString()));
				TimeSpan ts = DateTime.Now - dtCreated;

				int daysLeft = 30 - ts.Days;
				if(daysLeft < 0)
					daysLeft = 0;
			
				FormRegister frmRegister = new FormRegister();
				frmRegister.label4.Text = "You have " + daysLeft.ToString() + " days left on your 30 day trial.";
			
				frmRegister.ShowDialog();
				frmRegister.Dispose();
			
			}
		}
		public void UpdateButton() 
		{
			try
			{
				Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;

				//pj.Tasks[1].SetField((Microsoft.Office.Interop.MSProject.PjField)188776461,"test");

				string url = connectToSite(pj,false,true);
				string serverUrl = url;
				try
				{
					serverUrl = serverUrl.Substring(0,serverUrl.IndexOf("/",9));
				}
				catch{}
				if(logins.Contains(serverUrl))
				{
                    getPublisherSettings(url, pj);

					if(Connect.isProjServer)
					{
						FormStatus frmStatus = new FormStatus();
						frmStatus.label1.Text = "Downloading Tasks...";
						frmStatus.Show();
						frmStatus.Refresh();

						EPMLivePublisher.UpdateTaskItem[] uTasks = new EPMLivePublisher.UpdateTaskItem[0];
						int pubType = 0;
						try
						{
                            EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(pj.Application.Profiles.ActiveProfile.Server);
			
							pubType = pub.getPublishType(new Guid(pj.GetServerProjectGuid()));
							if(pubType != 1)
								uTasks = pub.getUpdates(pj.GetServerProjectGuid());

						}
						catch(System.Web.Services.Protocols.SoapException ex1)
						{
							MessageBox.Show("Error: " + ex1.Message.ToString() + ex1.Detail);
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message.ToString());
						}
						frmStatus.Dispose();

						if(pubType == 1)
						{
                            app.OpenServerPage(MSProject.PjServerPage.pjServerPageApprovals);

                            /*
							object omissing = System.Reflection.Missing.Value;
							CommandBars oCommandBars;
							//CommandBar oStandardBar;
							CommandBar MenuBar = null;
				
							oCommandBars = (CommandBars)applicationObject.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty , null, applicationObject ,null);
				
							MenuBar = oCommandBars["Menu Bar"];


							//=============Project Publisher Main menu=======================
							try
							{
								CommandBarPopup menuCollab = (CommandBarPopup)MenuBar.Controls["Collaborate"];
								CommandBarButton menuGetUpdates = (CommandBarButton)menuCollab.Controls["Update Project Progress"];
								menuGetUpdates.Execute();
								NAR(menuCollab);
								NAR(menuGetUpdates);
								NAR(MenuBar);
							}
							catch{}

							//app.LoadWebBrowserControl("1", "CollaborateMenu");
                             * */
						}
						else
						{
							hTaskCenterFields = new Hashtable();
							hProjectCenterFields = new Hashtable();
							string sLists = "";
							XmlNode ndProjectCenter =null;
							string ret = CheckLists.check(out sLists, out ndProjectCenter, false, false, app, pj);

							if(uTasks.Length > 0)
							{
								FormApproveEntTasks entApp = new FormApproveEntTasks(pj,uTasks);
								entApp.ShowDialog();
								if(entApp.DialogResult == DialogResult.OK)
								{
									if(projectUpdateSaves.Contains(pj.GetServerProjectGuid()))
										projectUpdateSaves[pj.GetServerProjectGuid()] = entApp.approvedTasks;
									else
										projectUpdateSaves.Add(pj.GetServerProjectGuid(),entApp.approvedTasks);

									DialogResult dRes = MessageBox.Show("Your project has been updated. Would you like to save your project?","Updated",MessageBoxButtons.YesNo);
									if(dRes == DialogResult.Yes)
										app.FileSave();

								}
								entApp.Dispose();
							}
							else
							{
								MessageBox.Show("There are no task updates to be processed");
							}
						}
					}
					else
					{
						FormStatus frmStatus = new FormStatus();
						frmStatus.label1.Text = "Checking Resources...";
						frmStatus.Show();
						frmStatus.Refresh();
					
						//CheckResources.pj = pj;

						bool v2ResMap = false;
						Connection.resUrl = "";
						Connection.resUrl = getConfigSetting("EPMLiveResourceURL",pj);
						if(Connection.resUrl != "")
							v2ResMap = true;

						if(v2ResMap)
						{
							if(!CheckResources.checkV2(true,pj))
							{
								NAR(pj);
								GC.Collect();
								GC.WaitForPendingFinalizers();
								GC.Collect();
								GC.WaitForPendingFinalizers();
								return;
							}
						}
						else
							CheckResources.check(true, pj);

						//CheckResources.check(true, pj);
				
						frmStatus.Dispose();

						hTaskCenterFields = new Hashtable();
						hProjectCenterFields = new Hashtable();
						string sLists = "";
						XmlNode ndProjectCenter =null;
						string ret = CheckLists.check(out sLists, out ndProjectCenter, false, false, app, pj);

                        if(Connect.getProperty("EPMLiveUsePerformance", pj) == "True")
                            UpdatePerf.update(pj, app);
                        else
						    Update.update(pj, app);
					}

				}
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString() + ex.StackTrace,"Error");
			}
		}

		public void RequestUpdates()
		{
			if(!RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject),true, false))
				return;

			string subject = "Please Update EPM Live Tasks for project " + Connection.getProjectName(app.ActiveProject) + ".";
			string body = "Team,\r\n\r\nPlease visit the EPM Live Workspace for project " + Connection.getProjectName(app.ActiveProject) + " to update your tasks.\r\n\r\nSite Address: " + getProperty("EPMLiveURL",app.ActiveProject).Replace(" ","%20");

			MapiMailMessage message = new MapiMailMessage(subject, body);
			foreach(Microsoft.Office.Interop.MSProject.Resource res in app.ActiveProject.Resources)
				if(res.EMailAddress != "")
					message.Recipients.Add(res.EMailAddress);

			message.ShowDialog();

		}
		public void EmailTeam()
		{
			if(!RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject),true, false))
				return;

			string subject = Connection.getProjectName(app.ActiveProject);
			string body = "\r\n\r\nSite Address: " + getProperty("EPMLiveURL",app.ActiveProject).Replace(" ","%20");;;

			MapiMailMessage message = new MapiMailMessage(subject, body);
			foreach(Microsoft.Office.Interop.MSProject.Resource res in app.ActiveProject.Resources)
				if(res.EMailAddress != "")
					message.Recipients.Add(res.EMailAddress);

			message.ShowDialog();
		}

		public void EmailTask() 
		{
			if(!RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject),true, false))
				return;

			string subject = Connection.getProjectName(app.ActiveProject);
			string body = "\r\n\r\nSite Address: " + getProperty("EPMLiveURL",app.ActiveProject).Replace(" ","%20");

			MapiMailMessage message = new MapiMailMessage(subject, body);
		
			Hashtable myHash = new Hashtable();

			foreach(Microsoft.Office.Interop.MSProject.Task tsk in app.ActiveSelection.Tasks)
			{
				if(tsk != null)
				{
					foreach(Microsoft.Office.Interop.MSProject.Resource res in tsk.Resources)
						if(res.EMailAddress != "" && !myHash.Contains(res.EMailAddress))
							myHash.Add(res.EMailAddress," ");
				}
			}

			foreach(DictionaryEntry entry in myHash)
				message.Recipients.Add(entry.Key.ToString());

			message.ShowDialog();
		}
		public void About() 
		{
			FormAbout frmAbout = new FormAbout();
			frmAbout.ShowDialog();
			frmAbout.Dispose();
		}

		public void Help() 
		{
			if(!RA.checkActivation(Connect.getProperty("EPMLiveURL",app.ActiveProject),true, false))
				return;

			FormHelp frmHelp = new FormHelp();
			frmHelp.Show();
			
		}

		private void getPublisherSettings(string url, Microsoft.Office.Interop.MSProject.Project pj)
		{
            if(HasWorkEngineAPI())
            {
                try
                {
                    EPMLiveWorkEngine.WorkEngineAPI api = Connection.GetWorkEngineService(Connection.url);

                    string retVal = api.Execute("GetPublisherSettings", "<Settings><![CDATA[" + pj.Name + "]]></Settings>");

                    XmlDocument doc = new XmlDocument(); 
                    doc.LoadXml(retVal); 
                    if(doc.FirstChild.Attributes["Status"].Value == "1")
                    {
                        if(doc.FirstChild.SelectSingleNode("Error").Attributes["ID"].Value == "1000")
                            getOldPublisherSettings(url, pj);
                        else
                            System.Windows.Forms.MessageBox.Show("Error Downloading Publisher Settings: " + doc.FirstChild.OuterXml);
                    }
                    else
                    {
                        foreach(XmlNode ndProperty in doc.FirstChild.FirstChild.ChildNodes)
                        {
                            if(ndProperty.Attributes["Locked"] != null && ndProperty.Attributes["Locked"].Value == "1")
                            {
                                setProperty(ndProperty.Name, pj, ndProperty.InnerText);
                            }
                            else if(!doesPropertyExist(ndProperty.Name, pj) || ndProperty.Name == "EPMLivePubLock")
                            {
                                setProperty(ndProperty.Name, pj, ndProperty.InnerText);
                            }
                        }
                    }
                }
                catch(System.Web.Services.Protocols.SoapException ex1)
                {
                    
                }
                catch(Exception ex)
                {
                    
                }
            }
            else
                getOldPublisherSettings(url, pj);
		}


        private void getOldPublisherSettings(string url, Microsoft.Office.Interop.MSProject.Project pj)
        {
            EPMLiveTimePhased.EPMLiveTimePhased tpService = Connection.GetTimePhasedService(Connection.url);

            try
            {
                string[] settings = tpService.getPublisherSettings();
                string[] publocks = new string[7];
                foreach(string setting in settings)
                {
                    string[] settingprop = setting.Split('|');
                    if(settingprop[0] == "epmlivepub-lock")
                    {
                        publocks = settingprop[1].Split(',');
                    }
                }
                foreach(string setting in settings)
                {
                    string[] settingprop = setting.Split('|');

                    switch(settingprop[0])
                    {
                        case "epmlivepub-type":

                            if(Connect.isProjServer)
                            {
                                if(publocks[0] == "1" || getProperty("EPMLiveEntPubType", pj) == "")
                                    setProperty("EPMLiveEntPubType", pj, settingprop[1]);
                            }
                            else
                            {
                                if(publocks[0] == "1" || getProperty("EPMLiveType", pj) == "")
                                {
                                    if(settingprop[1] == "1")
                                        setProperty("EPMLiveType", pj, "True");
                                    else
                                        setProperty("EPMLiveType", pj, "False");
                                }
                            }
                            break;
                        case "epmlivepub-lock":
                            setProperty("EPMLivePubLock", pj, settingprop[1]);
                            break;
                        case "epmlivepub-summary":
                            if(publocks[1] == "1" || getProperty("EPMLivePubSummary", pj) == "")
                                setProperty("EPMLivePubSummary", pj, settingprop[1]);
                            break;
                        case "epmlivepub-tp":
                            if(publocks[2] == "1" || getProperty("EPMLiveTimePhased", pj) == "")
                                setProperty("EPMLiveTimePhased", pj, settingprop[1]);
                            break;
                        case "epmlivepub-pubstatus":
                            if(publocks[3] == "1" || getProperty("EPMLiveLMF", pj) == "")
                                setProperty("EPMLiveLMF", pj, settingprop[1]);
                            break;
                        case "epmlivepub-reslink":
                            if(publocks[4] == "1" || getProperty("EPMLiveResField", pj) == "")
                                setProperty("EPMLiveResField", pj, settingprop[1]);
                            break;
                        case "epmlivepub-synchfields":
                            if(publocks[5] == "1" || getProperty("EPMLiveSynchFields", pj) == "")
                                setProperty("EPMLiveSynchFields", pj, settingprop[1]);
                            break;
                        case "epmlivetsflag":
                            setProperty("EPMLiveTSFlag", pj, settingprop[1]);
                            break;
                        case "epmlivetstimesheethours":
                            setProperty("EPMLiveTSTimesheetHours", pj, settingprop[1]);
                            break;
                        
                            break;
                    };
                }
            }
            catch { }
        }

		public void PublishButton() 
		{
            if (app.Version.Substring(0, 2) != "12")
            {
                //MessageBox.Show("The Project Publisher is only supported with Microsoft Office Project 2007. Please upgrade your Project version.", "Version Check");
                //return;
            }

            hTaskCenterFields = new Hashtable();
            hProjectCenterFields = new Hashtable();

            Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;

            Connect.setTaskLMF(pj, pj.ProjectSummaryTask, "");

            string usePerf = "";

            try
            {
                app.FileSave();

                if (!pj.Saved)
                {
                    NAR(pj);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    return;
                }

                string url = Connect.getProperty("EPMLiveURL", pj);


                url = connectToSite(pj, false, false);

                if (url == "")
                {
                    NAR(pj);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    return;
                }

                if (logins.Contains(url))
                { 
                    getPublisherSettings(url, pj);

                    pubType = Connect.getProperty("EPMLiveType", pj);
                    usePerf = Connect.getProperty("EPMLiveUsePerformance", pj);

                    enableMenus();
                    string sLists = "";
                    XmlNode ndProjectCenter = null;
                    string ret = CheckLists.check(out sLists, out ndProjectCenter, false, false, app, pj);

                    if (ret == "0")
                    {
                        FormStatus frmStatus = new FormStatus();
                        frmStatus.label1.Text = "Checking Mapped Resources...";
                        frmStatus.Show();
                        frmStatus.Refresh();

                        int ResMap = 0;
                        Connection.resUrl = "";

                        if(HasWorkEngineAPI())
                        {
                            Connection.resUrl = Connection.url;
                            ResMap = 2;
                        }
                        else
                        {
                            Connection.resUrl = getConfigSetting("EPMLiveResourceURL", pj);
                            if(Connection.resUrl != "")
                                ResMap = 1;
                        }


                        if(ResMap == 2)
                        {
                            if(!CheckResources.checkV3(true, pj))
                            {
                                NAR(pj);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                return;
                            }
                        }
                        else if(ResMap == 1)
                        {
                            if (!CheckResources.checkV2(true, pj))
                            {
                                NAR(pj);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                return;
                            }
                        }
                        else
                            ret = CheckResources.check(true, pj);

                        frmStatus.Dispose();

                        int updates = 0;
                        if (usePerf == "True")
                            updates = UpdatePerf.getUpdateCount(pj);
                        else
                            updates = Update.getUpdateCount(pj);

                        if (updates != 0)
                        {
                            DialogResult dRes = MessageBox.Show("You have updates waiting to be processed, would you like to process these updates now?", "Updates", MessageBoxButtons.YesNo);
                            if (dRes == DialogResult.Yes)
                            {
                                if(usePerf == "True")
                                {
                                    if(UpdatePerf.update(pj, app) != 0)
                                    {
                                        NAR(pj);
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        return;
                                    }
                                }
                                else
                                {
                                    if(Update.update(pj, app) != 0)
                                    {
                                        NAR(pj);
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        return;
                                    }
                                }
                            }
                        }

                        string[] sCustomPropList = null;

                        bool hideForm = false;
                        if (getProperty("EPMLiveHideProjInfo", pj) == "True")
                            hideForm = true;

                        if (ndProjectCenter != null)
                        {
                            bool rInfo = ProjInfo.projInfo(ndProjectCenter, pj, hideForm, false, out sCustomPropList);
                            if (!rInfo)
                            {
                                NAR(pj);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                return;
                            }
                        }

                        //=============Resource Mapping=================
                        //if(ret!="0")
                        string hideRes = getProperty("EPMLiveHideRes", pj);

                        if (hideRes != "True")
                        {
                            if (ResMap > 0)
                            {
                                FormResourceMapV2 frmResMap = new FormResourceMapV2(pj);
                                frmResMap.resMapVersion = ResMap;
                                frmResMap.ShowDialog();

                                ret = "1";
                                if (frmResMap.DialogResult == DialogResult.OK)
                                {
                                    ret = "0";
                                }
                                frmResMap.Dispose();
                            }
                            else
                            {
                                FormResourceMap frmResMap = new FormResourceMap(pj);
                                frmResMap.ShowDialog();

                                ret = "1";
                                if (frmResMap.DialogResult == DialogResult.OK)
                                {
                                    ret = "0";
                                }
                                frmResMap.Dispose();
                            }
                        }
                        else
                            ret = "0";

                        if (ret == "0")
                        {


                            //===================Publish Type====================
                            if (pubType.Trim() == "")
                            {
                                ret = "1";
                                FormPublishType frmPub = new FormPublishType(this.app);
                                frmPub.ShowDialog();
                                if (frmPub.DialogResult == DialogResult.OK)
                                    ret = "0";
                            }
                            //==================PUBLISH======================
                            if (ret == "0")
                            {
                                if (usePerf == "True")
                                    ret = PublishPerf.publish(pj, sCustomPropList);
                                else
                                    ret = Publish.publish(pj, sCustomPropList);
                                app.FileSave();

                                if (sLists != "")
                                {
                                    FormList frmList = new FormList(Connection.url);
                                    int top = frmList.linkLabel1.Top;
                                    if (sLists.IndexOf(Connect.getProperty("EPMLivePCList", pj)) >= 0)
                                    {
                                        frmList.linkLabel1.Visible = true;
                                        top = frmList.linkLabel1.Top + frmList.linkLabel1.Height;
                                    }
                                    if (sLists.IndexOf(Connect.getProperty("EPMLiveTCList", pj)) >= 0)
                                    {
                                        frmList.linkLabel2.Top = top;
                                        frmList.linkLabel2.Visible = true;
                                        top = frmList.linkLabel2.Top + frmList.linkLabel2.Height;
                                    }
                                    if (sLists.IndexOf("Resource Center") >= 0)
                                    {
                                        frmList.linkLabel3.Top = top;
                                        frmList.linkLabel3.Visible = true;
                                        top = frmList.linkLabel3.Top + frmList.linkLabel3.Height;
                                    }
                                    frmList.label2.Top = top + 5;
                                    frmList.linkLabel4.Top = top + 5 + frmList.label2.Height;
                                    top = frmList.linkLabel4.Top + frmList.linkLabel4.Height + 5;
                                    frmList.button1.Top = top;

                                    frmList.Height = frmList.button1.Top + frmList.button1.Height + 35;

                                    frmList.ShowDialog();
                                }

                            }
                        }
                    }
                    else if (ret == "1")
                    {
                        System.Windows.Forms.MessageBox.Show("Publishing cancelled", "Cancel");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(), "Error");
            }

            NAR(pj);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return;
			
		}
		/***********************************************
		* Procedure: setTaskLMF
		* Purpose: Sets the task last modified field based on the prefernce a user has set
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		*	MSProject.Task (The task to process)
		*	string (Date Time to set for that task)
		* Parameters Out: 
		***********************************************/
		public static void setTaskLMF(Microsoft.Office.Interop.MSProject.Project pj, Microsoft.Office.Interop.MSProject.Task tsk, string dt)
		{
			try
			{
				switch(getProperty("EPMLiveLMF",pj))
				{
					case "Text1":
						tsk.Text1 = dt;
						break;
					case "Text2":
						tsk.Text2 = dt;
						break;
					case "Text3":
						tsk.Text3 = dt;
						break;
					case "Text4":
						tsk.Text4 = dt;
						break;
					case "Text5":
						tsk.Text5 = dt;
						break;
					case "Text6":
						tsk.Text6 = dt;
						break;
					case "Text7":
						tsk.Text7 = dt;
						break;
					case "Text8":
						tsk.Text8 = dt;
						break;
					case "Text9":
						tsk.Text9 = dt;
						break;
					case "Text10":
						tsk.Text10 = dt;
						break;
					case "Text11":
						tsk.Text11 = dt;
						break;
					case "Text12":
						tsk.Text12 = dt;
						break;
					case "Text13":
						tsk.Text13 = dt;
						break;
					case "Text14":
						tsk.Text14 = dt;
						break;
					case "Text15":
						tsk.Text15 = dt;
						break;
					case "Text16":
						tsk.Text16 = dt;
						break;
					case "Text17":
						tsk.Text17 = dt;
						break;
					case "Text18":
						tsk.Text18 = dt;
						break;
					case "Text19":
						tsk.Text19 = dt;
						break;
					case "Text20":
						tsk.Text20 = dt;
						break;
					case "Text21":
						tsk.Text21 = dt;
						break;
					case "Text22":
						tsk.Text22 = dt;
						break;
					case "Text23":
						tsk.Text23 = dt;
						break;
					case "Text24":
						tsk.Text24 = dt;
						break;
					case "Text25":
						tsk.Text25 = dt;
						break;
					case "Text26":
						tsk.Text26 = dt;
						break;
					case "Text27":
						tsk.Text27 = dt;
						break;
					case "Text28":
						tsk.Text28 = dt;
						break;
					case "Text29":
						tsk.Text29 = dt;
						break;
					case "Text30":
						tsk.Text30 = dt;
						break;
					default:
						tsk.Text25 = dt;
						break;
				}
			}
			catch{}
		}
		/***********************************************
		* Procedure: getTaskLMF
		* Purpose: Gets the task last modified field based on the preference a user has set
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		*	MSProject.Task (The task to process)
		* Parameters Out: 
		*	string (The date the task was last published)
				***********************************************/
		public static string getTaskLMF(Microsoft.Office.Interop.MSProject.Project pj, Microsoft.Office.Interop.MSProject.Task tsk)
		{
			if(tsk == null)
				return "";
			try
			{
				switch(getProperty("EPMLiveLMF",pj))
				{
					case "Text1":
						return tsk.Text1;
					case "Text2":
						return tsk.Text2;
					case "Text3":
						return tsk.Text3;
					case "Text4":
						return tsk.Text4;
					case "Text5":
						return tsk.Text5;
					case "Text6":
						return tsk.Text6;
					case "Text7":
						return tsk.Text7;
					case "Text8":
						return tsk.Text8;
					case "Text9":
						return tsk.Text9;
					case "Text10":
						return tsk.Text10;
					case "Text11":
						return tsk.Text11;
					case "Text12":
						return tsk.Text12;
					case "Text13":
						return tsk.Text13;
					case "Text14":
						return tsk.Text14;
					case "Text15":
						return tsk.Text15;
					case "Text16":
						return tsk.Text16;
					case "Text17":
						return tsk.Text17;
					case "Text18":
						return tsk.Text18;
					case "Text19":
						return tsk.Text19;
					case "Text20":
						return tsk.Text20;
					case "Text21":
						return tsk.Text21;
					case "Text22":
						return tsk.Text22;
					case "Text23":
						return tsk.Text23;
					case "Text24":
						return tsk.Text24;
					case "Text25":
						return tsk.Text25;
					case "Text26":
						return tsk.Text26;
					case "Text27":
						return tsk.Text27;
					case "Text28":
						return tsk.Text28;
					case "Text29":
						return tsk.Text29;
					case "Text30":
						return tsk.Text30;
					default:
						return tsk.Text25;
				}
			}
			catch{}
			return tsk.Text25;
		}
		/***********************************************
		* Procedure: getResField
		* Purpose: Returns the value of a resource field
		* Parameters In:
		*	int (Id of the field to return)
		*	MSProject.Resource (The resource to process)
		* Parameters Out: 
		*	string (The value in the field)
		***********************************************/
		public static string getResField(int field, Microsoft.Office.Interop.MSProject.Resource res)
		{
			return res.GetField((Microsoft.Office.Interop.MSProject.PjField)field);
		}
		/***********************************************
		* Procedure: setResField
		* Purpose: Sets a field for a resource
		* Parameters In:
		*	int (Id of the field to set)
		*	MSProject.Resource (The resource to process)
		*	string (the value to set)
		* Parameters Out: 
		***********************************************/
		public static void setResField(int field, Microsoft.Office.Interop.MSProject.Resource res, string val)
		{
			res.SetField((Microsoft.Office.Interop.MSProject.PjField)field, val);
		}
		/***********************************************
		* Procedure: getAssignmentLMF
		* Purpose: Gets the assignment last modified field based on the preference a user has set
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		*	MSProject.Assignment (The assignment to process)
		* Parameters Out: 
		*	string (The date the assignment was last published)
		***********************************************/
		public static string getAssignmentLMF(Microsoft.Office.Interop.MSProject.Project pj, Microsoft.Office.Interop.MSProject.Assignment tsk)
		{
			if(tsk == null)
				return "";
			try
			{
				switch(getProperty("EPMLiveLMF",pj))
				{
					case "Text1":
						return tsk.Text1;
					case "Text2":
						return tsk.Text2;
					case "Text3":
						return tsk.Text3;
					case "Text4":
						return tsk.Text4;
					case "Text5":
						return tsk.Text5;
					case "Text6":
						return tsk.Text6;
					case "Text7":
						return tsk.Text7;
					case "Text8":
						return tsk.Text8;
					case "Text9":
						return tsk.Text9;
					case "Text10":
						return tsk.Text10;
					case "Text11":
						return tsk.Text11;
					case "Text12":
						return tsk.Text12;
					case "Text13":
						return tsk.Text13;
					case "Text14":
						return tsk.Text14;
					case "Text15":
						return tsk.Text15;
					case "Text16":
						return tsk.Text16;
					case "Text17":
						return tsk.Text17;
					case "Text18":
						return tsk.Text18;
					case "Text19":
						return tsk.Text19;
					case "Text20":
						return tsk.Text20;
					case "Text21":
						return tsk.Text21;
					case "Text22":
						return tsk.Text22;
					case "Text23":
						return tsk.Text23;
					case "Text24":
						return tsk.Text24;
					case "Text25":
						return tsk.Text25;
					case "Text26":
						return tsk.Text26;
					case "Text27":
						return tsk.Text27;
					case "Text28":
						return tsk.Text28;
					case "Text29":
						return tsk.Text29;
					case "Text30":
						return tsk.Text30;
					default:
						return tsk.Text25;
				}
			}
			catch{}
			return tsk.Text25;
		}
		/***********************************************
		* Procedure: setAssignmentLMF
		* Purpose: Sets the assignment last modified field based on the preference a user has set
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		*	MSProject.Assignment (The assignment to process)
		*	string (The date to set)
		* Parameters Out: 
		***********************************************/
		public static void setAssignmentLMF(Microsoft.Office.Interop.MSProject.Project pj, Microsoft.Office.Interop.MSProject.Assignment tsk, string dt)
		{
			try
			{
				switch(getProperty("EPMLiveLMF",pj))
				{
					case "Text1":
						tsk.Text1 = dt;
						break;
					case "Text2":
						tsk.Text2 = dt;
						break;
					case "Text3":
						tsk.Text3 = dt;
						break;
					case "Text4":
						tsk.Text4 = dt;
						break;
					case "Text5":
						tsk.Text5 = dt;
						break;
					case "Text6":
						tsk.Text6 = dt;
						break;
					case "Text7":
						tsk.Text7 = dt;
						break;
					case "Text8":
						tsk.Text8 = dt;
						break;
					case "Text9":
						tsk.Text9 = dt;
						break;
					case "Text10":
						tsk.Text10 = dt;
						break;
					case "Text11":
						tsk.Text11 = dt;
						break;
					case "Text12":
						tsk.Text12 = dt;
						break;
					case "Text13":
						tsk.Text13 = dt;
						break;
					case "Text14":
						tsk.Text14 = dt;
						break;
					case "Text15":
						tsk.Text15 = dt;
						break;
					case "Text16":
						tsk.Text16 = dt;
						break;
					case "Text17":
						tsk.Text17 = dt;
						break;
					case "Text18":
						tsk.Text18 = dt;
						break;
					case "Text19":
						tsk.Text19 = dt;
						break;
					case "Text20":
						tsk.Text20 = dt;
						break;
					case "Text21":
						tsk.Text21 = dt;
						break;
					case "Text22":
						tsk.Text22 = dt;
						break;
					case "Text23":
						tsk.Text23 = dt;
						break;
					case "Text24":
						tsk.Text24 = dt;
						break;
					case "Text25":
						tsk.Text25 = dt;
						break;
					case "Text26":
						tsk.Text26 = dt;
						break;
					case "Text27":
						tsk.Text27 = dt;
						break;
					case "Text28":
						tsk.Text28 = dt;
						break;
					case "Text29":
						tsk.Text29 = dt;
						break;
					case "Text30":
						tsk.Text30 = dt;
						break;
					default:
						//MessageBox.Show(tsk.TaskName + " Text25 " + dt);
						tsk.Text25 = dt;
						break;
				}
			}
			catch{}
		}
        
        public static bool doesPropertyExist(string prop, Microsoft.Office.Interop.MSProject.Project pj)
        {
            string url = "";

            try
            {
                Microsoft.Office.Core.DocumentProperties docProps = (Microsoft.Office.Core.DocumentProperties)pj.CustomDocumentProperties;

                try
                {
                    url = docProps[prop].Value.ToString();

                }
                catch { }

                NAR(docProps);
            }
            catch { }
            return url != "";
        }

		/***********************************************
		* Procedure: getProperty
		* Purpose: gets the property of a setting in the project
		* Parameters In:
		*	string (The property to read)
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		*	string (the value of the property
		***********************************************/
		public static string getProperty(string prop,Microsoft.Office.Interop.MSProject.Project pj)
		{


            //Hashtable hshProperties = new Hashtable();
            //string curNotes = pj.ProjectSummaryTask.Notes;

            //int statuslocationstart = curNotes.IndexOf("EPMLIVEPROPS:");
            //int statuslocationend = curNotes.IndexOf(":ENDEPMLIVEPROPS");

            //if (statuslocationstart > 0 && statuslocationend > statuslocationstart)
            //{
            //    curNotes = curNotes.Substring(statuslocationstart + 13, statuslocationend - statuslocationstart - 13);
            //}

            //string[] properties = curNotes.Split('*');

            //foreach (string property in properties)
            //{
            //    string[] sproperty = property.Split('|');
            //    if (sproperty[0].ToLower() == prop.ToLower())
            //        return sproperty[1];
            //}

            //return "";

            string url = "";

            try
            {
                Microsoft.Office.Core.DocumentProperties docProps = (Microsoft.Office.Core.DocumentProperties)pj.CustomDocumentProperties;

                try
                {
                    url = docProps[prop].Value.ToString();

                }
                catch { }

                switch(prop)
                {
                    case "EPMLivePCList":
                        if(url == "")
                            url = "Project Center";
                        break;
                   case "EPMLiveTCList":
                        if(url == "")
                            url = "Task Center";
                        break;
                   case "EPMLiveTCListPC":
                        if(url == "")
                            url = "Project";
                        break;
                }

                NAR(docProps);
            }
            catch { }
            return url;
		}
		/***********************************************
		* Procedure: setProperty
		* Purpose: Sets the property of a setting in the project
		* Parameters In:
		*	string (The property to set)
		*	MSProject.Project (The project we are processing)
		*	string (the value to set)
		* Parameters Out: 
		***********************************************/
		public static void setProperty(string prop, Microsoft.Office.Interop.MSProject.Project pj, string val)
		{
            

            //Hashtable hshProperties = new Hashtable();
            //string newprops = "";
            //string oldprops = "";

            //string curNotes = pj.ProjectSummaryTask.Notes;

            //int statuslocationstart = curNotes.IndexOf("EPMLIVEPROPS:");
            //int statuslocationend = curNotes.IndexOf(":ENDEPMLIVEPROPS");

            //if (statuslocationstart > 0 && statuslocationend > statuslocationstart)
            //{
            //    oldprops = curNotes.Substring(statuslocationstart + 13, statuslocationend - statuslocationstart - 13);
            //}

            //if (oldprops != "")
            //{
            //    string[] properties = oldprops.Split('*');
            //    foreach (string property in properties)
            //    {
            //        string[] sproperty = property.Split('|');
            //        if (sproperty[0].ToLower() != prop.ToLower())
            //            newprops += "*" + sproperty[0] + "|" + sproperty[1];
            //    }
            //}

            //newprops += "*" + prop + "|" + val;
            //newprops = newprops.Substring(1);

            ////pj.ProjectSummaryTask.Text30 = newprops;



            //if (statuslocationstart > 0 && statuslocationend > statuslocationstart)
            //{
            //    curNotes = curNotes.Substring(0, statuslocationstart) + "EPMLIVEPROPS:" + newprops + curNotes.Substring(statuslocationend);
            //}
            //else
            //{
            //    curNotes += "\r\n\r\nEPMLIVEPROPS:" + newprops + ":ENDEPMLIVEPROPS";
            //}

            //pj.ProjectSummaryTask.Notes = curNotes;

            try
            {
                Microsoft.Office.Core.DocumentProperties docProps = (Microsoft.Office.Core.DocumentProperties)pj.CustomDocumentProperties;
                try
                {
                    docProps[prop].Value = val;
                }
                catch (Exception)
                {
                    docProps.Add(prop, false, Microsoft.Office.Core.MsoDocProperties.msoPropertyTypeString, val, Missing.Value);
                }
                NAR(docProps);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
			
		}
		/***********************************************
		* Procedure: connectToSite
		* Purpose: First function that gets called when connecting to a site
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		*	bool (set to true to hide the connecting window)
		*	bool (set to true to ignore the activation check)
		* Parameters Out: 
		*	string (returns "0" for successful publish
		***********************************************/
		public static string connectToSite(Microsoft.Office.Interop.MSProject.Project pj, bool silent, bool hideActivation)
		{
			string url=getProperty("EPMLiveURL",pj);
			bool createSite = false;
			string template = "";
			if(url == "")
			{
				if(Connect.isProjServer)
				{
                    EPMLivePublisher.EPMLivePublisher chk = Connection.GetPublisherService(Connection.url);
			
					chk.Url = pj.ServerURL + "/_vti_bin/EPMLivePublisher.asmx";

					FormEntConnect frmConnect = new FormEntConnect();
					frmConnect.app = Connection.app;

					FormStatus frmStatus = new FormStatus();
					frmStatus.label1.Text = "Downloading Settings...";
					frmStatus.Show();
					frmStatus.Refresh();

					bool allowCrossSite = false;

					try
					{
						if(chk.getEnterpriseSetting("ForceWS") == "True")
						{
							frmConnect.btnSkip.Visible = false;
						}
						if(chk.getEnterpriseSetting("CrossSite") == "True")
						{
							allowCrossSite = true;
						}
					}
					catch{}

					try
					{
						foreach(string s in chk.getSiteTemplates())
						{
							FormEntConnect.SiteTemplate st = new FormEntConnect.SiteTemplate();
							string []sTemplate = s.Split('|');
							st.title = sTemplate[0];
							st.name = sTemplate[1];
							frmConnect.cboTemplate.Items.Add(st);
						}
					}
					catch(Exception ex)
					{
						if(ex.Message.IndexOf("getSiteTemplates") > 0)
						{
							frmConnect.cboTemplate.Visible = false;
							frmConnect.lblTemplate.Visible = false;
						}
						else
							MessageBox.Show("Error downloading templates: \r\n" + ex.Message);
					}

					frmStatus.Dispose();

					frmConnect.allowCrossSite = allowCrossSite;

					frmConnect.ShowDialog();
					if(frmConnect.DialogResult == DialogResult.Ignore)
						return "SKIP";

					if(frmConnect.DialogResult != DialogResult.OK)
						return "";
					
					createSite = frmConnect.checkBox2.Checked;
					url = frmConnect.txtURL.Text;
					try
					{
						template = ((FormEntConnect.SiteTemplate)frmConnect.cboTemplate.SelectedItem).name;
					}
					catch{}
					frmConnect.Dispose();
				}
				else
				{
					FormSiteConnect frmConnect = new FormSiteConnect();
					frmConnect.app = Connection.app;
					frmConnect.ShowDialog();
					if(frmConnect.DialogResult != DialogResult.OK)
						return "";
					Connect.setProperty("EPMLiveTimePhased",pj,frmConnect.checkBox2.Checked.ToString());
					url = frmConnect.txtURL.Text;
					frmConnect.Dispose();
				}
				
				
			}
			
			int last = url.LastIndexOf("/");
			int aspx = url.IndexOf(".aspx",last);
			if(aspx > 0)
			{
				url = url.Substring(0,last);
			}
			Connection.url = url;

			if(!RA.checkActivation(url,hideActivation, false))
				return "";

			if(Connect.isProjServer)
				Connection.username = pj.Application.Profiles.ActiveProfile.UserName;
			else
				Connection.username = "";
			Connection.password = "";
			Connection.domain = "";
			
			string serverUrl = url;
			try
			{
				serverUrl = serverUrl.Substring(0,serverUrl.IndexOf("/",9));
			}
			catch{}

			if(logins.Contains(serverUrl))
			{
				string[] loginInfo = logins[serverUrl].ToString().Split('\t');
				Connection.username = loginInfo[0];
				Connection.password = loginInfo[1];
				Connection.domain = loginInfo[2];
			}
			
			string ret = Connection.connect(silent,createSite, pj, template);
			if(ret == "0")
				Connect.setProperty("EPMLiveURL",pj,url);
			else
				serverUrl = "";

			return serverUrl;
			
		}

		public static object applicationObject;
		private object addInInstance;

		/***********************************************
		* Procedure: pushTaskItems
		* Purpose: upload a chunk of tasks to the list
		* Parameters In:
		*	FormStatus (the status form that is being currently displayed)
		*	MSProject.Project (The project we are processing)
		*	string (the xml for the tasks we are publishing)
		*	HashTable (The Tasks)
		*	HashTable (The Assignments)
		* Parameters Out: 
		*	string (Return "0" if it was successful
		***********************************************/
		private static string pushTaskItems(FormStatus frmStatus, Microsoft.Office.Interop.MSProject.Project pj, SPSLists.Lists spList, string strBatch, Hashtable allTaskHash, Hashtable allAssnHash)
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

				elBatch.InnerXml = uploadBatch;

//				Hashtable hshUpdates = new Hashtable();
//				foreach(XmlNode ndMethod in elBatch)
//				{
//					MessageBox.Show("ndMethod.SelectSingleNode("Field[@Name='taskuid']").InnerText);
//					hshUpdates.Add(ndMethod.Attributes["ID"].Value,ndMethod.SelectSingleNode("Field[@Name='taskuid']").InnerText);
//				}

				XmlNode ndReturn = spList.UpdateListItems(Connect.getProperty("EPMLiveTCList", pj), elBatch);

				if(ndReturn.OuterXml.IndexOf("<ErrorCode>0x81020014</ErrorCode>") > 0)
				{
                    MessageBox.Show("The " + Connect.getProperty("EPMLiveTCList", pj) + " list does not appear to have the correct structure. You will need to delete and recreate the '" + Connect.getProperty("EPMLiveTCList", pj) + "' list using the current version of Project Publisher.");
					return "-1";
				}

				foreach(XmlNode nd in ndReturn)
				{
//					string result = nd.Attributes["ID"].Value;
//					result = result.Split(',')[0];
//					MessageBox.Show(result);
//					if(hshUpdates.Contains(result))
//					{
						string taskuid="";//hshUpdates[result].ToString();
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
								Microsoft.Office.Interop.MSProject.Assignment assn = (Microsoft.Office.Interop.MSProject.Assignment)allAssnHash[taskuid];
								Connect.setAssignmentLMF(pj,assn,DateTime.Parse(nd.ChildNodes[1].Attributes["ows_Modified"].Value).ToString());
							}
							catch
							{
								try
								{
									Microsoft.Office.Interop.MSProject.Assignment assn = (Microsoft.Office.Interop.MSProject.Assignment)allAssnHash[taskuid];
									Connect.setAssignmentLMF(pj,assn,DateTime.Parse(nd.ChildNodes[2].Attributes["ows_Modified"].Value).ToString());
								}
								catch{}
							}
						}
						else if (taskuid != "")
						{
							try
							{
								Microsoft.Office.Interop.MSProject.Task tsk = (Microsoft.Office.Interop.MSProject.Task)allTaskHash[taskuid];
								Connect.setTaskLMF(pj,tsk,DateTime.Parse(nd.ChildNodes[1].Attributes["ows_Modified"].Value).ToString());
							}
							catch
							{
								try
								{
									Microsoft.Office.Interop.MSProject.Task tsk = (Microsoft.Office.Interop.MSProject.Task)allTaskHash[taskuid];
									Connect.setTaskLMF(pj,tsk,DateTime.Parse(nd.ChildNodes[2].Attributes["ows_Modified"].Value).ToString());
								}
								catch{}
							}
						}
					//}
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show("Error saving tasks: " + ex.Message.ToString() + "\n\n\n" + ex.StackTrace.ToString());
				return "-1";
			}
			return "0";
		}
		/***********************************************
		* Procedure: getWebTitle
		* Purpose: Returns the site title of a site based on the currently connected project
		* Parameters In:
		* Parameters Out: 
		***********************************************/
		private string getWebTitle()
		{
			SPSSiteData._sWebMetadata webMetaData;
			SPSSiteData._sWebWithTime[] webData;
			SPSSiteData._sListWithTime[] listData;
			SPSSiteData._sFPUrl[] spURL;

			string users;
			//string groups;
			string[] vGroups;
			string[] vRoles;
            SPSSiteData.SiteData siteData = Connection.GetSiteDataService(Connection.url);
			
			siteData.GetWeb(out webMetaData, out webData, out listData, out spURL, out users, out vRoles, out vGroups);

			return webMetaData.Title;
		}

		private void app_ProjectBeforeSave(Microsoft.Office.Interop.MSProject.Project pj, bool SaveAsUi, ref bool Cancel)
		{

			if(Connect.isProjServer)
			{
				if(projectUpdateSaves.Contains(pj.GetServerProjectGuid()))
				{
					FormStatus frmStatus = new FormStatus();
					frmStatus.label1.Text = "Saving Task Updates...";
					frmStatus.Show();
					frmStatus.Refresh();

					try
					{

						string url = connectToSite(pj,false,true);
						string serverUrl = url;
						try
						{
							serverUrl = serverUrl.Substring(0,serverUrl.IndexOf("/",9));
						}
						catch{}
						if(logins.Contains(serverUrl))
						{
                            EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(pj.Application.Profiles.ActiveProfile.Server);

							pub.setApprovedTasks((EPMLivePublisher.TaskApprovalItem[])projectUpdateSaves[pj.GetServerProjectGuid()],new Guid(pj.GetServerProjectGuid()));
							
							projectUpdateSaves.Remove(pj.GetServerProjectGuid());

						}
					}
					catch(Exception ex)
					{
						System.Windows.Forms.MessageBox.Show("Error Saving Task Updates: " + ex.Message.ToString(),"Error");
					}
					frmStatus.Dispose();
				}
			}
			else
			{
                if (taskList != null && taskList.Length > 0)
				{

					try
					{
						Hashtable allTaskHash = new Hashtable();
						Hashtable allAssnHash = new Hashtable();

						foreach(Microsoft.Office.Interop.MSProject.Task tsk in pj.Tasks)
						{
							if(!(tsk == null))
							{
								//if(tsk.Summary.ToString() == "False")
							{
								allTaskHash.Add(tsk.UniqueID.ToString(),tsk);
								foreach(Microsoft.Office.Interop.MSProject.Assignment assn in tsk.Assignments)
								{
									allAssnHash.Add(tsk.UniqueID.ToString() + "." + assn.UniqueID.ToString(),assn);
								}
							}
							}
						}

						System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo( );

						provider.NumberDecimalSeparator = ".";
						provider.NumberGroupSeparator = ",";
						provider.NumberGroupSizes = new int[ ] { 3 };

						string url = connectToSite(app.ActiveProject,false,true);
                        if (logins.Contains(url))
                        {
                            if (Connect.getProperty("EPMLiveUsePerformance", pj) == "True")
                            {
                                //EPMLiveIntegration.Integration oInt = Connection.GetIntegrationService(Connection.url);

                                EPMLiveWorkEngine.WorkEngineAPI oAPI = Connection.GetWorkEngineService(Connection.url);

                                FormStatus frmStatus = new FormStatus();
                                frmStatus.Show();
                                frmStatus.label1.Text = "Getting Project Location...";
                                frmStatus.Refresh();

                                XmlDocument docRet = new XmlDocument();
                                docRet.LoadXml(oAPI.Execute("GetProjectInfoFromName", "<Project List=\"" + Connect.getProperty("EPMLivePCList", pj) + "\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Project>"));

                                XmlNode nd = docRet.FirstChild;

                                if (nd.Attributes["Status"].Value == "0")
                                {
                                    string ID = nd.FirstChild.Attributes["ProjectId"].Value;

                                    string strBatch = "<Project ID=\"" + ID.Split('.')[2] + "\" PlannerID=\"" + Connect.getProperty("EPMLivePlanner", pj) + "\">";

                                    for (int i = 0; i < taskList.Length; i++)
                                    {
                                        if (taskList[i].moderationStatus == 1 || taskList[i].moderationStatus == 2)
                                        {
                                            strBatch = strBatch + "<Task ItemID='" + taskList[i].ListID + "'";

                                            if (taskList[i].moderationStatus == 1)
                                                strBatch += " Status='2'";
                                            else
                                                strBatch += " Status='1'";

                                            strBatch += "><![CDATA[";
                                            strBatch += taskList[i].moderationNotes;
                                            strBatch = strBatch + "]]></Task>";
                                        }
                                    }

                                    strBatch += "</Project>";

                                    

                                    frmStatus.label1.Text = "Saving Project Updates...";
                                    frmStatus.Refresh();

                                    docRet.LoadXml(oAPI.Execute("ProcessUpdates", strBatch));

                                    nd = docRet.FirstChild;

                                    if (nd.Attributes["Status"].Value != "0")
                                    {
                                        MessageBox.Show("Error Saving Updates: " + nd.FirstChild.InnerText);
                                    }
                                }
                                
                                taskList = new Tasks[0];

                                frmStatus.Dispose();
                            }
                            else
                            {
                                SPSLists.Lists spList = Connection.GetListService(Connection.url);
                               
                                string moderationEnabled = "";

                                XmlNode tskNode = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));
                                //MessageBox.Show(tskNode.OuterXml);

                                try
                                {
                                    moderationEnabled = tskNode.Attributes["EnableModeration"].Value;
                                }
                                catch { }

                                if (moderationEnabled.ToUpper() == "TRUE")
                                    Publish.disableModeration(spList, pj);

                                string strBatch = "";
                                int methodId = 1;
                                FormStatus frmStatus = new FormStatus();
                                frmStatus.Show();

                                frmStatus.label1.Text = "Saving Task Updates...";
                                frmStatus.Refresh();

                                string pushRet = "0";

                                frmStatus.progressBar1.Maximum = taskList.Length;

                                for (int i = 0; i < taskList.Length; i++)
                                {
                                    if (taskList[i].moderationStatus == 1 || taskList[i].moderationStatus == 2)
                                    {
                                        strBatch = strBatch + "<Method ID='" + methodId + "' Cmd='Update'>" +
                                            "<Field Name='ID'>" + taskList[i].ListID + "</Field>";
                                        strBatch = strBatch + "<Field Name='taskuid'>" + taskList[i].taskuid + "</Field>";


                                        if (taskList[i].moderationStatus == 1)
                                            strBatch = strBatch + "<Field Name='Publisher_x0020_Approval_x0020_S'>Rejected</Field>";
                                        else
                                            strBatch = strBatch + "<Field Name='Publisher_x0020_Approval_x0020_S'>Accepted</Field>";
                                        //strBatch = strBatch + "<Field Name='_ModerationStatus'>0</Field>";

                                        strBatch = strBatch + "<Field Name='Publisher_x0020_Approval_x0020_C'>" + taskList[i].moderationNotes + "</Field>";
                                        strBatch = strBatch + "</Method>";
                                        methodId++;
                                        if (methodId >= 100)
                                        {
                                            pushRet = pushTaskItems(frmStatus, pj, spList, strBatch, allTaskHash, allAssnHash);
                                            strBatch = "";
                                            methodId = 1;
                                            frmStatus.label1.Text = "Processing Tasks...";
                                            frmStatus.progressBar1.Value = i;
                                            frmStatus.Refresh();

                                            if (pushRet != "0")
                                                break;
                                        }
                                    }
                                }

                                if (methodId > 1 & pushRet == "0")
                                {
                                    pushRet = pushTaskItems(frmStatus, pj, spList, strBatch, allTaskHash, allAssnHash);
                                    frmStatus.progressBar1.Value = frmStatus.progressBar1.Maximum;
                                    frmStatus.Refresh();
                                }

                                if (moderationEnabled.ToUpper() == "TRUE")
                                    Publish.enableModeration(spList, pj);

                                taskList = new Tasks[0];
                                frmStatus.Dispose();
                            }
                        }
					}
					catch(Exception ex)
					{
						System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(),"Error");
					}
				}
			}

		}

		private void app_WindowDeactivate(Microsoft.Office.Interop.MSProject.Window deactivatedWindow)
		{
			runTimer();
			if(Connect.getProperty("EPMLiveURL",app.ActiveProject) != "")
				enableMenus();
			else
				disableMenus();


		}

		private void enableMenus()
		{


            //Globals.Ribbons.Ribbon1.btnPublish.Visible = true;
            //Globals.Ribbons.Ribbon1.btnProjectInformation.Visible = true;
            //MyButton3.Visible = true;
            //MyButton9.Visible = true;
            //Globals.Ribbons.Ribbon1.btnProjectSettings.Visible = true;
            //cbbDeleteProject.Visible = true;

            //if(!isProjServer)
            //{
            //    cbbResourceMapping.Visible = true;
				
            //}
		}

		private void disableMenus()
		{
			if(isProjServer)
			{
                Globals.Ribbons.PublisherRibbon.btnPublish.Visible = false;
                Globals.Ribbons.PublisherRibbon.btnResMapping.Visible = false;
                Globals.Ribbons.PublisherRibbon.btnSynchronizeFields.Visible = false;
				//cbpProjectOptions.Visible = false;
				//cbbCustomFields.Visible = false;
				//MyButton1.Visible = false;
			}
			
//			cbbDeleteProject.Visible = false;
//			cbbProjectInformation.Visible = false;
//			cbbResourceMapping.Visible = false;
//			MyButton3.Visible = false;
//			MyButton9.Visible = false;
		}

		public void GoToWorkspace()
		{
			string url=getProperty("EPMLiveURL",app.ActiveProject);
			if(url!="")
				System.Diagnostics.Process.Start("IExplore"," " + getProperty("EPMLiveURL",app.ActiveProject));
		}

		private void app_WindowSelectionChange(Microsoft.Office.Interop.MSProject.Window Window, Microsoft.Office.Interop.MSProject.Selection sel, object selType)
		{
			runTimer();
//			if(Connect.getProperty("EPMLiveURL",app.ActiveProject) != "")
//				enableMenus();
//			else
//				disableMenus();
		}

		private void pj_BeforeClose(Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
				opens.Remove(pj.Name);
			}
			catch{}
		}

		public void ResourceMapping()
		{
			Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;

			try
			{
				
				app.FileSave();
				
				if(!pj.Saved)
				{
					NAR(pj);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return;
				}

				string url = Connect.getProperty("EPMLiveURL",pj);
				

				url = connectToSite(pj,false,false);

				if(url=="")
				{
					NAR(pj);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return;
				}
				
				if(logins.Contains(url))
				{
					int ResMap = 0;
					Connection.resUrl = "";

                    if(HasWorkEngineAPI())
                    {
                        Connection.resUrl = Connection.url;
                        ResMap = 2;
                    }
                    else
                    {
                        Connection.resUrl = getConfigSetting("EPMLiveResourceURL", pj);
                        if(Connection.resUrl != "")
                            ResMap = 1;
                    }

					FormStatus frmStatus = new FormStatus();
					frmStatus.label1.Text = "Checking Resources...";
					frmStatus.Show();
					frmStatus.Refresh();
                    if(ResMap == 2)
                    {
                        if(!CheckResources.checkV3(true, pj))
                        {
                            NAR(pj);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            return;
                        }
                    }
                    else if(ResMap == 1)
					{
						if(!CheckResources.checkV2(true,pj))
						{
							NAR(pj);
							GC.Collect();
							GC.WaitForPendingFinalizers();
							GC.Collect();
							GC.WaitForPendingFinalizers();
							return;
						}
					}
					else
						CheckResources.check(true, pj);

					frmStatus.Dispose();

					//=============Resource Mapping=================
                    if(ResMap > 0)
					{
						FormResourceMapV2 frmResMap = new FormResourceMapV2(pj);
                        frmResMap.resMapVersion = ResMap;
						frmResMap.ShowDialog();
						if(frmResMap.DialogResult == DialogResult.OK)
						{
							Publish.replaceResourcesV2(pj);
						}
						frmResMap.Dispose();
					}
					else
					{
						FormResourceMap frmResMap = new FormResourceMap(pj);
						frmResMap.ShowDialog();
						if(frmResMap.DialogResult == DialogResult.OK)
						{
							Publish.replaceResources(pj);
						}
						frmResMap.Dispose();
					}
					
				}
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(),"Error");
			}
			NAR(pj);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			return;
		}

		public static bool isVersionGreaterOrEqual(string newVersion, string oldVersion)
		{
			try
			{
				string []nVersion = newVersion.Split('.');
				string []oVersion = oldVersion.Split('.');

				if(int.Parse(nVersion[0]) > int.Parse(oVersion[0]))
				{
					return true;
				}
				else if(int.Parse(nVersion[0]) == int.Parse(oVersion[0]))
				{
					if(int.Parse(nVersion[1]) > int.Parse(oVersion[1]))
					{
						return true;
					}
					else if(int.Parse(nVersion[1]) == int.Parse(oVersion[1]))
					{
						if(int.Parse(nVersion[2]) >= int.Parse(oVersion[2]))
							return true;
					}
				}
				
				return false;
			}
			catch
			{
				return false;
			}
		}

		public void ProjectInformation()
		{
			Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;
			try
			{
				app.FileSave();
				
				if(!pj.Saved)
				{
					NAR(pj);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return;
				}

				string url = Connect.getProperty("EPMLiveURL",pj);

				url = connectToSite(pj,false,false);

				if(url=="")
				{
					NAR(pj);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return;
				}
				
				if(logins.Contains(url))
				{
					string sLists = "";
					XmlNode ndProjectCenter =null;
					string ret = CheckLists.check(out sLists, out ndProjectCenter, true, false, app, pj);
					
					if(ret=="0")
					{
//						FormStatus frmStatus = new FormStatus();
//						frmStatus.label1.Text = "Checking Resources...";
//						frmStatus.Show();
//						frmStatus.Refresh();
//						CheckResources.check(true, pj);
//						frmStatus.Dispose();

						string []sCustomPropList = null;

						if(ndProjectCenter != null)
						{
							bool rInfo = ProjInfo.projInfo(ndProjectCenter,pj, false, true, out sCustomPropList);
							if(!rInfo)
							{
								NAR(pj);
								GC.Collect();
								GC.WaitForPendingFinalizers();
								GC.Collect();
								GC.WaitForPendingFinalizers();
								return;
							}
							
						}
					}
				}
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(),"Error");
			}
			NAR(pj);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			return;
		}

		public void CustomField()
		{

			hTaskCenterFields = new Hashtable();
			hProjectCenterFields = new Hashtable();

			Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;

			try
			{

				string url = Connect.getProperty("EPMLiveURL",pj);

				url = connectToSite(pj,false,false);

				if(url=="")
				{
					NAR(pj);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					return;
				}
				if(logins.Contains(url))
				{
					if(Connect.isProjServer)
					{
						FormStatus frmStatus = new FormStatus();
						frmStatus.label1.Text = "Checking for Tasks Updates...";
						frmStatus.Show();
						frmStatus.Refresh();

						bool isUpdates = false;
						try
						{
                            EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(pj.Application.Profiles.ActiveProfile.Server);
			
							int pubType = pub.getPublishType(new Guid(pj.GetServerProjectGuid()));
							if(pubType != 1)
								isUpdates = pub.isTaskUpdates(new Guid(pj.GetServerProjectGuid()));

						}
						catch(System.Web.Services.Protocols.SoapException ex1)
						{
							MessageBox.Show("Error: " + ex1.Message.ToString() + ex1.Detail);
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message.ToString());
						}
						frmStatus.Dispose();

						if(!isUpdates)
						{
							FormEntCustomFields frmCustomFields = new FormEntCustomFields(pj);
							frmCustomFields.ShowDialog();
							frmCustomFields.Dispose();
						}
						else
						{
							MessageBox.Show("You currently have tasks waiting to be updated. You must accept all task updates before modifying custom fields.");
						}

					}
					else
					{
						string sLists = "";
						XmlNode ndProjectCenter =null;
						string ret = CheckLists.check(out sLists, out ndProjectCenter, false, false, app, pj);

						if(ret == "0")
						{
							FormCustomFields frmCustomFields = new FormCustomFields(pj);
							frmCustomFields.ShowDialog();
							frmCustomFields.Dispose();
						}
					}
				}
			}
			catch{}
		}

        public string getSiteUrl(string url)
        {
            SPSSiteData.SiteData siteData = Connection.GetSiteDataService(url);
            
            string sUrl = "";
            string siteId = "";

            siteData.GetSiteUrl(Connection.url, out sUrl, out siteId);

            return sUrl;
        }

        public void ShowPPMControl(string sparams)
        {
            try
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "");

                string assemblyName = Path.Combine(directory, "PPMUtility.exe");

                Process p = Process.Start(Path.Combine(directory, "PPMUtility.exe"), sparams);
                //p.WaitForInputIdle();
                //p.WaitForExit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ButtonPublishWork()
        {
            Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;
            string url = getProperty("EPMLiveURL", pj);
            
            url = connectToSite(pj, false, true);

            if (logins.Contains(url))
            {
                string sUrl = getSiteUrl(url);

                EPMLiveIntegration.Integration wsInt = Connection.GetIntegrationService(sUrl);

                XmlNode ndRes = wsInt.execute("getsettings", "<Settings Key=\"EPK\"/>");

                int i = ndRes.ChildNodes.Count;

                string epkurl = ndRes.SelectSingleNode("url").InnerText;

                //if (Connection.username != "")
                //    epkurl = epkurl.Replace("//", "//" + Connection.username + ":" + Connection.password + "@");

                //FormEPKWeb frm = new FormEPKWeb();
                //frm.url = epkurl + "/importproject.aspx?simpleui=nobranding,nomenu,notitle";
                //frm.ShowDialog();

                ShowPPMControl(epkurl + "/importproject.aspx?simpleui=nobranding,nomenu,notitle");
            }
            
            NAR(pj);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ButtonUtilTeam(string function)
        {

            Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;
            string url = getProperty("EPMLiveURL", pj);

            url = connectToSite(pj, false, true);

            if (logins.Contains(url))
            {
                string sUrl = getSiteUrl(url);

                EPMLiveIntegration.Integration wsInt = Connection.GetIntegrationService(sUrl);

                XmlNode ndRes = wsInt.execute("getsettings", "<Settings Key=\"EPK\"/>");

                int i = ndRes.ChildNodes.Count;

                //string epkurl = ndRes.SelectSingleNode("url").InnerText;

                switch (function)
                {
                    case "team":
                        EPKTools.processTeam(Connection.getProjectName(pj) + ".mpp", "0", Connection.url, pj);
                        break;
                    case "teamcomm":
                        EPKTools.processTeam(Connection.getProjectName(pj) + ".mpp", "1", Connection.url, pj);
                        break;
                    case "nonwork":
                        EPKTools.processNonWork(Connection.getProjectName(pj) + ".mpp", Connection.url, pj);
                        break;
                    case "all":
                        EPKTools.processTeam(Connection.getProjectName(pj) + ".mpp", "1", Connection.url, pj);
                        EPKTools.processNonWork(Connection.getProjectName(pj) + ".mpp", Connection.url, pj);
                        break;
                };
            }

            NAR(pj);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ButtonEditCosts(string page)
        {
            Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;
            string mainurl = getProperty("EPMLiveURL", pj);

            string url = connectToSite(pj, false, true);
            bool showPPMControl = true;
            if (logins.Contains(url))
            {
                string sUrl = getSiteUrl(mainurl);

                EPMLiveIntegration.Integration wsInt = Connection.GetIntegrationService(sUrl);

                XmlNode ndRes = wsInt.execute("getsettings", "<Settings Key=\"EPK\"/>");

                int i = ndRes.ChildNodes.Count;

                //string epkurl = ndRes.SelectSingleNode("url").InnerText;

                //if (Connection.username != "")
                //    epkurl = epkurl.Replace("//", "//" + Connection.username + ":" + Connection.password + "@");

                //FormEPKWeb frm = new FormEPKWeb();
                //frm.url = epkurl + "/importproject.aspx?simpleui=nobranding,nomenu,notitle";
                //frm.ShowDialog();

                wsInt.Url = mainurl + "/_vti_bin/integration.asmx";

                ndRes = wsInt.execute("GetProjectIdFromName", "<Project><![CDATA[" + Connection.getProjectName(pj) + "]]></Project>");
                // In case of resource planner, check for currently running Resource Import Job if any. 
                if (page.Equals("rpeditor", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (IsImportResourceRunning())
                    {
                        MessageBox.Show("The Resource Planner cannot be opened because there is an active resource import job running.");
                        showPPMControl = false;
                    }
                }
                if (ndRes.InnerText != "" && showPPMControl)
                {
                    string itemid = ndRes.InnerText;

                    ndRes = wsInt.execute("GetMappedView", "<DefaultView Key=\"EPK\" List=\"" + getProperty("EPMLivePCList", pj) + "\"/>");

                    if(ndRes.Attributes["Status"].Value == "0")
                        if(ndRes.FirstChild.Attributes["ViewId"].Value != "")
                            ShowPPMControl(mainurl + "/_layouts/ppm/" + page + ".aspx?itemid=" + itemid + "&isDlg=1&hideCloseBtn=true&view=" + ndRes.FirstChild.Attributes["ViewId"].Value);
                        else
                            ShowPPMControl(mainurl + "/_layouts/ppm/" + page + ".aspx?itemid=" + itemid + "&isDlg=1&hideCloseBtn=true&view=" + ndRes.FirstChild.Attributes["ViewName"].Value);
                }
            }

            NAR(pj);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

		public void ButtonDeleteProject()
		{

			Microsoft.Office.Interop.MSProject.Project pj = app.ActiveProject;
			string url = getProperty("EPMLiveURL",pj);
			if(MessageBox.Show("Are you sure you want to delete this project from " + url + "?","Confirm",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				url = connectToSite(pj,false,true);

				if(logins.Contains(url))
				{
					DeleteProject.deleteProject(pj);
				}
			}
			NAR(pj);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			
		}

		public void ProxySettings()
		{
			FormProxy frmProxy = new FormProxy();
			frmProxy.ShowDialog();
			frmProxy.Dispose();
		}
		/***********************************************
		* Procedure: getLinkedSite
		* Purpose: gets the wss site linked to the project
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		*	string (The URL linked to the project)
		***********************************************/
		private string getLinkedSite(Microsoft.Office.Interop.MSProject.Project pj, out bool boolEpmLive)
		{
			boolEpmLive = false;
			string url = "";

			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Retrieving Project Information...";
			frmStatus.Show();
			frmStatus.Refresh();

			try
			{
                EPMLivePublisher.EPMLivePublisher chk = Connection.GetPublisherService(Connection.url);

				url = chk.getProjectSite(new Guid(pj.GetServerProjectGuid()));
				
				boolEpmLive = true;
			}
			catch(Exception ex)
			{
				if(ex.Message.IndexOf("EPMLivePublisher") < 0)
					MessageBox.Show("Error finding linked site: " + ex.Message);
			}

			frmStatus.Dispose();
			return url;
		}

		private void app_ProjectBeforePublish(Microsoft.Office.Interop.MSProject.Project pj, ref bool Cancel)
		{
			string errLocation = "";
			if(Connect.isProjServer)
			{
				try
				{
					string url = Connect.getProperty("EPMLiveURL",pj);

					setProperty("EPMLiveURL",pj,app.Profiles.ActiveProfile.Server);

					errLocation = "Connect PWA";
					url = connectToSite(pj,false,false);
				

					if(url=="")
					{
						setProperty("EPMLiveURL",pj,"");
						NAR(pj);
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();
						Cancel = true;
						return;
					}

					errLocation = "getLinkedSite";

					bool boolEpmLive = false;

					string linkedurl = getLinkedSite(pj,out boolEpmLive);

					if(!boolEpmLive)
						return;

					setProperty("EPMLiveURL",pj,linkedurl);

					errLocation = "connectToSite";

					url = connectToSite(pj,false,false);

					if(url=="SKIP")
					{
						setProperty("EPMLiveURL",pj,"");
						NAR(pj);
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();
						return;
					}

                    Connect.setTaskLMF(pj, pj.ProjectSummaryTask, DateTime.Now.ToString());

					if(url=="")
					{
						NAR(pj);
						GC.Collect();
						GC.WaitForPendingFinalizers();
						GC.Collect();
						GC.WaitForPendingFinalizers();
						Cancel = true;
						return;
					}

					if(logins.Contains(url))
					{
						FormStatus frmStatus = new FormStatus();
						frmStatus.label1.Text = "Checking Version...";
						frmStatus.Show();
						frmStatus.Refresh();

						errLocation = "getVersion";

						if(getEntPubVersion(pj) != ENTVERSION)
						{
							MessageBox.Show("Your publisher version does not match the server version.");
							NAR(pj);
							GC.Collect();
							GC.WaitForPendingFinalizers();
							GC.Collect();
							GC.WaitForPendingFinalizers();
							return;
						}

						frmStatus.Dispose();

						getPublisherSettings(url, pj);

						pubType = Connect.getProperty("EPMLiveEntPubType",pj);

						//enableMenus();
						string ret = "0";
						if(pubType.Trim() == "")
						{
							ret="1";
							FormEntPublishType frmPub = new FormEntPublishType(this.app);
							frmPub.ShowDialog();
							if(frmPub.DialogResult == DialogResult.OK)
								ret="0";
							pubType = Connect.getProperty("EPMLiveEntPubType",pj);
						}
						if(ret == "0")
						{
							string sLists = "";

							XmlNode ndProjectCenter =null;

							errLocation = "checkLists";

							ret = CheckLists.check(out sLists, out ndProjectCenter, true, false, app, pj);

							if(ret=="0")
							{
								errLocation = "checkResources";

								frmStatus = new FormStatus();
								frmStatus.label1.Text = "Checking Resources...";
								frmStatus.Show();
								frmStatus.Refresh();
								//ret = CheckResources.check(true, pj);
                                //=====================
                                int ResMap = 0;
                                Connection.resUrl = "";

                                if(HasWorkEngineAPI())
                                {
                                    Connection.resUrl = Connection.url;
                                    ResMap = 2;
                                }
                                else
                                {
                                    Connection.resUrl = getConfigSetting("EPMLiveResourceURL", pj);
                                    if(Connection.resUrl != "")
                                        ResMap = 1;
                                }


                                if(ResMap == 2)
                                {
                                    if(!CheckResources.checkV3(true, pj))
                                    {
                                        NAR(pj);
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        return;
                                    }
                                }
                                else if(ResMap == 1)
                                {
                                    if(!CheckResources.checkV2(true, pj))
                                    {
                                        NAR(pj);
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        GC.Collect();
                                        GC.WaitForPendingFinalizers();
                                        return;
                                    }
                                }
                                else
                                    ret = CheckResources.check(true, pj);

                                //=====================
								frmStatus.Dispose();

								string []sCustomPropList = null;

								bool hideForm = false;
								if(getProperty("EPMLiveHideProjInfo",pj) == "True")
									hideForm = true;

								if(ndProjectCenter != null)
								{
									errLocation = "projInfo";

									bool rInfo = ProjInfo.projInfo(ndProjectCenter, pj, hideForm, false, out sCustomPropList);

									if(!rInfo)
									{
										NAR(pj);
										GC.Collect();
										GC.WaitForPendingFinalizers();
										GC.Collect();
										GC.WaitForPendingFinalizers();
										Cancel = true;
										return;
									} 
									frmStatus = new FormStatus();
									frmStatus.label1.Text = "Downloading Enterprise Data...";
									frmStatus.Show();
									frmStatus.Refresh();
									ArrayList arrProjFields = new ArrayList();
									try
									{
										errLocation = "getProjectFields";
										arrProjFields = ProjInfo.getProjectFields(pj);
									}
									catch(Exception ex)
									{
										MessageBox.Show("Publish Error: " + ex.Message + ex.StackTrace);
									}
									
									string strBatch = "";
									foreach(DictionaryEntry entry in Connect.projectCenterFields)
									{
                                        string val = "";
                                        if(entry.Value != null)
                                            val = entry.Value.ToString();

										if(arrProjFields.Contains(entry.Key.ToString()))
										{
											string entFieldId = entry.Key.ToString().Substring(3);

											try
											{
                                                pj.ProjectSummaryTask.SetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId), val);
											}
											catch
											{
												//string val = entry.Value.ToString();
												if(val == "True")
													val = "Yes";
												else
													val = "No";
												try
												{
													pj.ProjectSummaryTask.SetField((Microsoft.Office.Interop.MSProject.PjField)int.Parse(entFieldId),val);
												}
												catch{}
											}
										}
                                        strBatch = strBatch + "<Field Name='" + entry.Key.ToString() + "'><![CDATA[" + val + "]]></Field>";
									}
									frmStatus.Dispose();
									if(strBatch != "")
									{
										errLocation = "saveEnterpriseInfo";
										saveEnterpriseProjectInfo(strBatch, pj);
									}
								}
							}

							//====Publish==========
                            EPMLivePublisher.EPMLivePublisher chk = Connection.GetPublisherService(pj.ServerURL);

							errLocation = "publish";

							chk.publish(new Guid(pj.GetServerProjectGuid()),int.Parse(pubType),Connection.url);
							//==================
						}
						else
							Cancel = true;
					}
					else
						Cancel = true;
				}
				catch(Exception ex)
				{
					MessageBox.Show("Publisher Error (at " + errLocation + "): " + ex.Message);
				}
			}
			NAR(pj);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		/***********************************************
		* Procedure: saveEnterpriseProjectInfo
		* Purpose: Sets the information for a project in the Project Center
		* Parameters In:
		*	string (The property list to set)
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		***********************************************/
		private void saveEnterpriseProjectInfo(string strBatch, Microsoft.Office.Interop.MSProject.Project pj)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Saving Project Information...";
			frmStatus.Show();
			frmStatus.Refresh();
			try
			{
                SPSLists.Lists spsList = Connection.GetListService(Connect.getProperty("EPMLiveURL", pj));
				
				XmlDocument xmlDoc = new System.Xml.XmlDocument();

				XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
				XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
				XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");

				ndQueryOptions.InnerXml = "";
				ndViewFields.InnerXml = "";
				ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"Title\"/><Value Type=\"Text\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Value></Eq></Where>";
				XmlNode ndListItems = null;
				try
				{
					ndListItems = spsList.GetListItems(Connect.getProperty("EPMLivePCList", pj), string.Empty, ndQuery, ndViewFields, "150", ndQueryOptions, string.Empty);
				}
				catch (System.Web.Services.Protocols.SoapException ex)
				{
                    MessageBox.Show("Error Reading " + Connect.getProperty("EPMLivePCList", pj) + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
					return;
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

				if(id == "")
				{
					strBatch = 
						"<Method ID='1' Cmd='New'>" +
						"<Field Name='Title'><![CDATA[" + Connection.getProjectName(pj) + "]]></Field>" + strBatch + "</Method>";
				}
				else
				{
					strBatch = "<Method ID='1' Cmd='Update'>" + 
						"<Field Name='ID'>" + id + "</Field>"+ strBatch + "</Method>";
				}
				xmlDoc = new System.Xml.XmlDocument();

				System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");

				elBatch.SetAttribute("OnError","Continue");
				elBatch.SetAttribute("ListVersion","1");

				elBatch.InnerXml = strBatch;

				XmlNode ndReturn = spsList.UpdateListItems(Connect.getProperty("EPMLivePCList", pj), elBatch);
			}
			catch(Exception ex)
			{
                MessageBox.Show("Error Saving " + Connect.getProperty("EPMLivePCList", pj) + ":\n" + ex.Message + "\n\n" + ex.StackTrace);
			}
			frmStatus.Dispose();
		}

		public static void pubWindowClose()
		{
			ClosePubWindow cw = new ClosePubWindow();
			while(true)
			{
				cw.closeWindow();
				Thread.Sleep(100);
			}
		}
		/***********************************************
		* Procedure: getEntPubVersion
		* Purpose: Gets the version of the server side Project Publisher
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		*	int (The version on the server)
		***********************************************/
		private int getEntPubVersion(Microsoft.Office.Interop.MSProject.Project pj)
		{
			try
			{
                EPMLivePublisher.EPMLivePublisher chk = Connection.GetPublisherService(pj.ServerURL);

				return chk.getVersion();
			}
			catch(System.Web.Services.Protocols.SoapException ex1)
			{
				MessageBox.Show("Error: " + ex1.Message.ToString() + ex1.Detail);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message.ToString());
			}

			return 0;
		}
		/***********************************************
		* Procedure: runEntTaskUpdates
		* Purpose: Checks for updates for a project automatically
		* Parameters In:
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		***********************************************/
		private void runEntTaskUpdates(Microsoft.Office.Interop.MSProject.Project pj)
		{
			EPMLivePublisher.UpdateTaskItem[] uTasks = new EPMLivePublisher.UpdateTaskItem[0];
			int pubType = 0;
			try
			{
                EPMLivePublisher.EPMLivePublisher pub = Connection.GetPublisherService(Connection.url);
				
				pubType = pub.getPublishType(new Guid(pj.GetServerProjectGuid()));
				if(pubType != 1)
				{
					uTasks = pub.getUpdates(pj.GetServerProjectGuid());
					if(uTasks.Length > 0)
					{
						if(MessageBox.Show("There are tasks waiting to be processed, would you like to process them now?","Updates",MessageBoxButtons.YesNo)==DialogResult.Yes)
						{
							FormApproveEntTasks entApp = new FormApproveEntTasks(pj,uTasks);
							entApp.ShowDialog();
							if(entApp.DialogResult == DialogResult.OK)
							{
								if(projectUpdateSaves.Contains(pj.GetServerProjectGuid()))
									projectUpdateSaves[pj.GetServerProjectGuid()] = entApp.approvedTasks;
								else
									projectUpdateSaves.Add(pj.GetServerProjectGuid(),entApp.approvedTasks);

								DialogResult dRes = MessageBox.Show("Your project has been updated. Would you like to save your project?","Updated",MessageBoxButtons.YesNo);
								if(dRes == DialogResult.Yes)
									app.FileSave();

							}
							entApp.Dispose();
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		public void ButtonSynchFields()
		{
			SynchFields.synchFields(app.ActiveProject, false);
		}

        internal static bool HasWorkEngineAPI()
        {
            try
            {
                EPMLiveWorkEngine.WorkEngineAPI api = Connection.GetWorkEngineService(Connection.url);
                
                string ret = api.Execute("testFunction", "testData");

                return true;
            }
            catch { }
            return false;
        }

		/***********************************************
		* Procedure: getConfigSetting
		* Purpose: Gets a config setting from the EPMLiveConfig list
		* Parameters In:
		*	string (The property to get)
		*	MSProject.Project (The project we are processing)
		* Parameters Out: 
		*	string (The value of the requested property)
		***********************************************/
		internal static string getConfigSetting(string key, Microsoft.Office.Interop.MSProject.Project pj)
		{
			string retVal = "";
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Reading Config...";
			frmStatus.Show();
			frmStatus.Refresh();

			try
			{

                EPMLiveTimePhased.EPMLiveTimePhased tp = Connection.GetTimePhasedService(Connection.url);

				string setting = tp.getConfigSetting(key);

				frmStatus.Dispose();
				return setting;
			}
			catch{}
			frmStatus.Dispose();
			return retVal;
		}

		public void DisablePS()
		{
			string ed = (disableProjectServer) ? "enable" : "disable";

			try
			{
				

				CommandBars oCommandBars = (CommandBars)applicationObject.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty , null, applicationObject ,null);
				CommandBar MenuBar = oCommandBars["Menu Bar"];
				CommandBarPopup menuCollaborate = (CommandBarPopup)MenuBar.Controls["Collaborate"];
				CommandBarButton cbbTemp = (CommandBarButton)menuCollaborate.Controls["Update Project Progress"];

				if(disableProjectServer)
				{
					disableProjectServer = false;
                    Globals.Ribbons.PublisherRibbon.cbbDisablePS.Checked = true;
					ThreadStart ts = new ThreadStart(pubWindowClose);
					worker = new Thread (ts);
					worker.IsBackground = true;
					worker.Start();
					isProjServer = true;
					disableMenus();
                    Globals.Ribbons.PublisherRibbon.btnPublish.Visible = false;
					RegistryClass.SaveSetting("Tr","DisableProjectServer","False");

					//cbbTemp.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(this.MyButtonUpdate_Click);
				}
				else
				{
					isProjServer = false;
					enableMenus();
					worker.Suspend();
					NAR(worker);
                    Globals.Ribbons.PublisherRibbon.btnPublish.Visible = true;
					disableProjectServer = true;
                    Globals.Ribbons.PublisherRibbon.cbbDisablePS.Checked = false;
					RegistryClass.SaveSetting("Tr","DisableProjectServer","True");

					cbbTemp.Click += null;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Unable to " + ed + " Project Server Integration:\r\n" + ex.Message);
			}
		}

		private void app_ProjectBeforeTaskChange(Microsoft.Office.Interop.MSProject.Task tsk, Microsoft.Office.Interop.MSProject.PjField Field, object NewVal, ref bool Cancel)
		{

			string field = Field.ToString().Replace("pjTask","").ToLower();
			int iField = (int)Field;
			if(field == getProperty("EPMLiveTSFlag",app.ActiveProject).ToString().ToLower())
			{
				foreach(Microsoft.Office.Interop.MSProject.Assignment assn in tsk.Assignments)
				{
					if(assn.ResourceName != "Other Timesheet Hours")
						Update.setAssignmentField(iField,NewVal.ToString(),assn,tsk);
				}
			}

		}

        private bool IsImportResourceRunning()
        {
            bool isResImportRunning = false;
            try
            {
                EPMLiveWorkEngine.WorkEngineAPI api = Connection.GetWorkEngineService(Connection.url);

                string result = api.Execute("IsImportResourceAlreadyRunning", string.Empty);

                XmlDocument resultDoc = new XmlDocument();
                resultDoc.LoadXml(result);

                XmlNode elementNode = resultDoc.DocumentElement.FirstChild;
                if (elementNode != null)
                {
                    isResImportRunning = Convert.ToBoolean(elementNode.Attributes["Success"].Value);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to check whether any import resource job is running.\r\nError: " + ex.Message);
            }
            return isResImportRunning;
        }
	}

}