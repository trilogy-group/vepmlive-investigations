using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for BuildTeam.
	/// </summary>
	public class BuildTeam
	{
		public BuildTeam()
		{
			//
			// TODO: Add constructor logic here
			// 
		}

		public static string getSiteAdminEmails(SPSUserGroup.UserGroup spUserGroup)
		{
			string emails = "";
			XmlNode nd = spUserGroup.GetAllUserCollectionFromWeb();
			XmlNode xmlUsers = nd["Users"];

			for(int j=0;j<xmlUsers.ChildNodes.Count;j++)
			{
				if(xmlUsers.ChildNodes[j].Attributes["IsSiteAdmin"].Value.Trim() == "True")
				{
					emails = emails + "#" + xmlUsers.ChildNodes[j].Attributes["Email"].Value;
				}
			}
			if(emails.Length > 1)
				emails = emails.Substring(1);
			return emails;
		}

		private static string getSiteURL()
		{
			SPSSiteData._sSiteMetadata sSiteMetadata;
			SPSSiteData._sWebWithTime[] webData;

			string users;
			string groups;
			string[] vGroups;
            SPSSiteData.SiteData siteData = new SPSSiteData.SiteData();
			siteData.Url = Connection.url + "/_vti_bin/sitedata.asmx";
			if(Connection.username == null || Connection.username == "")
			{
				Connection.username = "";
				siteData.Credentials = System.Net.CredentialCache.DefaultCredentials;
			}
			else
			{
				System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username,Connection.password,Connection.domain);
				siteData.Credentials = nw;
			}
			siteData.GetSite(out sSiteMetadata, out webData,out users,out groups,out vGroups);
			//MessageBox.Show(users);
			return webData[0].Url;
			
		}

		public static string build(Microsoft.Office.Interop.MSProject.Project pj, string url)
		{
			FormStatus frmStatus = new FormStatus();
			frmStatus.label1.Text = "Downloading Site Users...";
			frmStatus.Show();
			frmStatus.Refresh();

			SPSUserGroup.UserGroup spUserGroup = new SPSUserGroup.UserGroup();
			spUserGroup.Url = url + "/_vti_bin/UserGroup.asmx";

			if(Connection.username == "")
			{
				Connection.username = "";
				spUserGroup.Credentials = System.Net.CredentialCache.DefaultCredentials;
			}
			else
			{
				System.Net.NetworkCredential nw = new System.Net.NetworkCredential(Connection.username,Connection.password,Connection.domain);
				spUserGroup.Credentials = nw;
			}
			XmlNode nd = spUserGroup.GetUserCollectionFromSite();

			Hashtable myHash = new Hashtable();
			Hashtable myUsers = new Hashtable();
			Hashtable myUserLogins = new Hashtable();
			Hashtable myGroups = new Hashtable();

			XmlNode xmlUsers = nd["Users"];
			for(int j=0;j<xmlUsers.ChildNodes.Count;j++)
			{
				if(xmlUsers.ChildNodes[j].Attributes["Email"].Value.Trim() != "")
				{
					myHash.Add(xmlUsers.ChildNodes[j].Attributes["Email"].Value,xmlUsers.ChildNodes[j].Attributes["Name"].Value);
					myUserLogins.Add(xmlUsers.ChildNodes[j].Attributes["Email"].Value,xmlUsers.ChildNodes[j].Attributes["LoginName"].Value);
				}
			}

			nd = spUserGroup.GetGroupCollectionFromWeb();
			XmlNode xmlGroups = nd["Groups"];
			for(int j=0;j<xmlGroups.ChildNodes.Count;j++)
			{
				string group = xmlGroups.ChildNodes[j].Attributes["Name"].Value;
				try
				{
					nd = spUserGroup.GetUserCollectionFromGroup(group);	
					xmlUsers = nd["Users"];
					myGroups.Add(group," ");
					
					for(int i=0;i<xmlUsers.ChildNodes.Count;i++)
						if(xmlUsers.ChildNodes[i].Attributes["Name"].Value.ToString() != "System Account")
							if(!myHash.Contains(xmlUsers.ChildNodes[i].Attributes["Name"].Value))
								myHash.Remove(xmlUsers.ChildNodes[i].Attributes["Email"].Value);
				}
				catch(System.Exception){ myGroups.Remove(group); }
			}

			nd = spUserGroup.GetUserCollectionFromWeb();
			xmlUsers = nd["Users"];
			for(int i=0;i<xmlUsers.ChildNodes.Count;i++)
				myHash.Remove(xmlUsers.ChildNodes[i].Attributes["Email"].Value);


			foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
			{
				if(myHash.Contains(res.EMailAddress.ToString()))
					myUsers.Add(res.EMailAddress,res.Name);
			}
			
			frmStatus.Hide();
			bool show = false;
			foreach(Microsoft.Office.Interop.MSProject.Resource res in pj.Resources)
			{
				string email = res.EMailAddress.Trim();
				if(email != "")
				{
					if(!myUsers.Contains(email))
					{
						bool found = false;
						for(int i = 0;i<CheckResources.resCount;i++)
						{
							if(CheckResources.resList[i].email == email && CheckResources.resList[i].matchedResID > 0)
							{
								found = true;
							}
						}
						if(!found)
							show = true;
					}
					
				}
			}

			if(myUsers.Keys.Count > 0 || show)
			{
				FormBuildTeam frmBuild = new FormBuildTeam();
				frmBuild.myUsers = myUsers;
				frmBuild.myGroups = myGroups;
				frmBuild.myUserLogins = myUserLogins;
				frmBuild.pj = pj;
				frmBuild.url = url;
				frmBuild.ShowDialog();
				frmBuild.Refresh();
				frmBuild.Hide();
				if(frmBuild.DialogResult == DialogResult.OK)
				{
				
					frmStatus.Show();
					frmStatus.label1.Text = "Processing Resources...";
					frmStatus.progressBar1.Maximum = frmBuild.listView1.Items.Count;
					frmStatus.Refresh();
					int counter = 1;
					string newRes = "";

					/*try
					{
						System.Net.ICredentials cd = spUserGroup.Credentials;
						
						MessageBox.Show(cd.GetCredential(Connection.url,"").UserName);
						XmlNode ndUser = spUserGroup.GetUserInfo(Connection.domain + "\\" + Connection.username);
					
						MessageBox.Show(ndUser.OuterXml);
					}
					catch(Exception ex)
					{
						MessageBox.Show("ERR" + ex.Message.ToString());
					}*/
					string body1 = "Welcome to the EPM Live site: " + Connection.title;
					MapiMailMessage message = new MapiMailMessage("You have been granted permissions to EPM Live site: " + Connection.url, body1);

					foreach(ListViewItem li in frmBuild.listView1.Items)
					{
						if(li.SubItems[4].Text == "1")
						{
							if(li.SubItems[0].Text != "Do Not Process")
							{
								try
								{
									spUserGroup.AddUserToGroup(li.SubItems[0].Text,li.SubItems[1].Text,li.SubItems[3].Text,li.SubItems[2].Text,"");
									message.Recipients.Add(li.SubItems[2].Text);
								}
								catch(Exception ex)
								{
									if(ex.Message.IndexOf("401") >= 0)
										MessageBox.Show("You do not have permissions to add users to group: " + li.SubItems[0]);
								}
							}
						}
						else
						{
							if(li.SubItems[0].Text != "Do Not Process")
							{
								newRes = newRes + "\r\n\r\n" + li.SubItems[1].Text + "\r\n" + li.SubItems[2].Text;
							}
						}
						frmStatus.progressBar1.Value = counter++;
						frmStatus.Refresh();
					}
					if(message.Recipients.Count >0)
						message.ShowDialog();
					if(newRes.Length > 1)
					{
						frmStatus.Show();
						frmStatus.label1.Text = "Getting Site Administrator Email Addresses...";
						frmStatus.progressBar1.Value = 0;
						frmStatus.Refresh();
						//newRes = newRes.Substring(2);
						string emails = getSiteAdminEmails(spUserGroup);
						frmStatus.Hide();
						if(emails.Trim() == "")
						{
							MessageBox.Show("Your site does not appear to have a site administrator with a valid email address.");
						}
						else
						{
							string topurl = getSiteURL().Replace(" ","%20");
							string body="Please add the following users to the top level site <" + topurl + ">" +
										newRes +
										"\n\nClick on the following link to add new users " + topurl + "/_layouts/aclinv.aspx";
							
							message = new MapiMailMessage("EPM Live accounts creation request", body);

							string []arr = emails.Split('#');
							foreach(string str in arr)
							{
								message.Recipients.Add(str);
							}
							message.ShowDialog();
						}
					}
				}	

				frmBuild.Dispose();
				frmStatus.Dispose();
			}
			else
				MessageBox.Show("All resources are mapped correctly");
			return "0";
		}

	}
}
