using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for SynchFields.
	/// </summary>
	public class SynchFields
	{
		public SynchFields()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void synchFields(Microsoft.Office.Interop.MSProject.Project pj, bool silent)
		{
			string url = Connect.connectToSite(pj,silent,false);

			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Downloading Fields...";
			frmStatus.Refresh();

			if(silent)
			{
				pj.Application.StatusBar = "Download Fields...";
			}
			else
			{
				frmStatus.Show();
				frmStatus.Refresh();
			}
			if(url != "")
			{
				string sLists = "";
				XmlNode ndProjectCenter = null;
				CheckLists.check(out sLists,out ndProjectCenter,false,silent, pj.Application, pj);

                SPSLists.Lists spList = Connection.GetListService(Connection.url);

				try
				{
					XmlNode ndTaskCenter = spList.GetList(Connect.getProperty("EPMLiveTCList", pj));

					foreach(XmlNode nd in ndTaskCenter.ChildNodes[0].ChildNodes)
					{
						string type = "";
						string name = "";
						string dName = "";
						try
						{
							type = nd.Attributes["Type"].Value;
						}
						catch{}
						try
						{
							name = nd.Attributes["Name"].Value;
						}
						catch{}
						try
						{
							dName = nd.Attributes["DisplayName"].Value;
						}
						catch{}
						if(type == "Choice")
						{
							if(isValidField(name))
							{
								foreach(XmlNode ndChild in nd.ChildNodes)
								{
									if(ndChild.Name == "CHOICES")
									{
										if(Connect.hPprojectFields.Contains(name.ToUpper()))
										{
											ArrayList arrChoice = new ArrayList();
											
											foreach(XmlNode ndChoice in ndChild.ChildNodes)
											{
												arrChoice.Add(ndChoice.InnerText);
											}
											
											setupField(pj, arrChoice, name, dName);
											
										}
									}
								}
							}
						}
						else if(type == "Lookup")
						{
							if(isValidField(name))
							{
								string list = "";
								string showField = "Title";
								try
								{
									list = nd.Attributes["List"].Value;
								}
								catch{}
								try
								{
									showField = nd.Attributes["ShowField"].Value;
								}
								catch{}
								if(list!="")
								{
									XmlDocument xmlDoc = new System.Xml.XmlDocument();

									XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element,"Query","");
									XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element,"ViewFields","");
									XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element,"QueryOptions","");
									ndQueryOptions.InnerXml = "";
									ndViewFields.InnerXml = "<FieldRef Name=\"" + showField + "\"/>";

									//ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"Project\"/><Value Type=\"Text\"><![CDATA[" + Connection.getProjectName(pj) + "]]></Value></Eq></Where>";
									XmlNode ndListItems = null;
					
									try
									{
										ndListItems = spList.GetListItems(list,string.Empty,ndQuery,ndViewFields,"0",ndQueryOptions,string.Empty);
									}
									catch(Exception ex)
									{
										MessageBox.Show("Error Downloading Lookup Items: " + ex.Message);
									}
									if(ndListItems != null)
									{
										ArrayList arrChoice = new ArrayList();

										foreach(XmlNode ndData in ndListItems.ChildNodes)
										{
											if(ndData.Name == "rs:data")
											{
												foreach(XmlNode ndChild in ndData.ChildNodes)
												{
													if(ndChild.Name == "z:row")
													{
														arrChoice.Add(ndChild.Attributes["ows_ID"].Value + " - " + ndChild.Attributes["ows_" + showField].Value);
													}
												}
											}
										}
											
										setupField(pj, arrChoice, name, dName);
									}
								}
							}
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error downloading task fields: " + ex.Message);
				}
			}
			if(silent)
			{
				pj.Application.StatusBar = false;
			}
			else
			{
				frmStatus.Dispose();
			}
		}


		private static void setupField(Microsoft.Office.Interop.MSProject.Project pj, ArrayList arrChoice, string name, string dName)
		{
			Connect.TaskField tf = (Connect.TaskField)Connect.hPprojectFields[name.ToUpper()];
			ArrayList deleteFields = new ArrayList();
			int counter = 1;
			try
			{
				while(true)
				{
					string item = pj.Application.CustomFieldValueListGetItem((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,Microsoft.Office.Interop.MSProject.PjValueListItem.pjValueListValue,(short)counter);
					if(!arrChoice.Contains(item))
					{
						deleteFields.Add(counter);														
					}
					else
						arrChoice.Remove(item);
					counter++;
				}
												
			}
			catch{}

			for(int i = deleteFields.Count - 1 ;i>=0;i--)
			{
				pj.Application.CustomFieldValueListDelete((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,short.Parse(deleteFields[i].ToString()));
			}
			counter = 0;

			foreach(string sValue in arrChoice)
			{
				try
				{
					pj.Application.CustomFieldValueListAdd((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,sValue,"","",1,false);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message + ex.StackTrace);
				}
			}

			
			pj.Application.CustomFieldPropertiesEx((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,
				Microsoft.Office.Interop.MSProject.PjCustomFieldAttribute.pjFieldAttributeValueList,
				Microsoft.Office.Interop.MSProject.PjSummaryCalc.pjCalcNone,
				false,
				false,
				false);

			pj.Application.CustomOutlineCodeEditEx((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,Missing.Value,Microsoft.Office.Interop.MSProject.PjCustomOutlineCodeSequence.pjCustomOutlineCodeCharacters,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,1);

			pj.Application.CustomFieldRename((Microsoft.Office.Interop.MSProject.PjCustomField)tf.fieldId,dName,Missing.Value);
		}

		private static bool isValidField(string fieldName)
		{
			try
			{
				if(fieldName.Length > 4)
				{
					if(fieldName.Substring(0,4) == "Text")
					{
						string sNumber = fieldName.Substring(4);
						try
						{
							int number = int.Parse(sNumber);
							if(number >0 && number <= 30)
								return true;
						}
						catch{}
					}
				}
			}
			catch{}
			return false;
		}
	}
}
