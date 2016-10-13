using System;
using System.IO;

namespace ProjectPublisher2016
{
	/// <summary>
	/// Summary description for RA.
	/// </summary>
	public class RA
	{
		
		public RA()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static bool checkActivation(string url, bool hideActivation, bool isActivateButton)
		{
            return true;
			try
			{
				if(url == "" && !isActivateButton)
					return true;

				if(!checkURL(url) || isActivateButton)
				{
					if(checkActCode())
						return true;

					if(isActivateButton)
						return false;

					DateTime dtCreated = DateTime.Now.AddDays(-31);
					try
					{
						string strDtInst = RegistryClass.GetSetting("Tr","ID","");
						if(strDtInst == "")
							dtCreated = DateTime.Now.AddDays(-30);
						else
							dtCreated = new DateTime(long.Parse(strDtInst));
					}
					catch
					{
						dtCreated = DateTime.Now.AddDays(-30);
					}
					TimeSpan ts = DateTime.Now - dtCreated;

					int daysLeft = 30 - ts.Days;
					if(daysLeft < 0)
						daysLeft = 0;

					FormRegister frmReg = new FormRegister();
					frmReg.label4.Text = "You have " + daysLeft.ToString() + " days left on your 30 day trial.";
					if(daysLeft <= 0)
					{
						frmReg.button2.Enabled = false;
						frmReg.ShowDialog();
					}
					else if(!hideActivation)
					{
						frmReg.ShowDialog();
					}
					else
						return true;
				
					string company = frmReg.txtCompany.Text;
					string cdKey = frmReg.txtSerial.Text;

					frmReg.Dispose();

					if(frmReg.DialogResult == System.Windows.Forms.DialogResult.Ignore)
					{
						return true;
					}

					if(frmReg.DialogResult == System.Windows.Forms.DialogResult.OK)
						return true;

					return false;
				}
				else
					return true;
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("RA: " + ex.Message.ToString() + "\n" + ex.StackTrace.ToString());
			}
			return false;
		}



		private static bool checkURL(string url)
		{
			try
			{
                url = url.Substring(url.IndexOf("//") + 2);
                url = url.Substring(url.IndexOf(".") + 1);
                url = url.Substring(0, url.IndexOf("/"));

                //if(url.Substring(0, 22) == "http://my.epmlive.com/" || url.Substring(0, 23) == "https://my.epmlive.com/" || url.Substring(0, 27) == "http://apps.workengine.com/" || url.Substring(0, 28) == "https://apps.workengine.com/" || url.Substring(0, 26) == "https://my.workengine.com/" || url.Substring(0, 29) == "https://my.projectengine.com/")
                if(url == "epmlive.com" || url == "workengine.com" || url == "projectengine.com" || url == "portfolioengine.com")
				{
					return true;
				}
			}
			catch{}
			return false;
		}

		private static bool checkActCode()
		{
			try
			{
				string company = RegistryClass.GetSetting("Tr","Company","");
				string cdKey = RegistryClass.GetSetting("Tr","Key","");
				string actCode = RegistryClass.GetSetting("Tr","Code","");
				if((company == "") || (cdKey == "") || (actCode == ""))
					return false;
				
				if(computerCode(genCode(company,cdKey)) == actCode)
				{
					return true;
				}
				return false;
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Unable to read activation: " + ex.Message);
				return false;
			}
		}

		private static string genCode(string company, string cdKey)
		{
			string pwd = "H3fd65TR" + company;
			string actCode = "";
			int counter = 0;
			for(int i = 0;i<cdKey.Length;i++)
			{
				if(counter + 1 >= pwd.Length)
					counter = 0;
				actCode = actCode + (pwd[counter++] ^ cdKey[i]);
			}
			return actCode;
		}

		public static string computerCode(string code)
		{
			string computer = System.Net.Dns.GetHostName();
			string actCode = "";
			int counter = 0;
			for(int i = 0;i<code.Length;i++)
			{
				if(counter + 1 >= computer.Length)
					counter = 0;
				actCode = actCode + (computer[counter++] ^ code[i]);
			}
			return actCode;
		}

	}
}
