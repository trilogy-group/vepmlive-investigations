using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.Applications
{
    public class Uninstall : API.BaseJob
    {
        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            if (string.IsNullOrEmpty(strConn))
            {
                strConn = strConn = EPMLiveCore.CoreFunctions.getConnectionString(osite.WebApplication.Id);
            }
            SqlConnection cn = new SqlConnection(strConn);
            try
            {
                cn.Open();
                DataTable dtMessages;
                int maxErrorLevel;

                bool bVerify = false;
                bool.TryParse(data, out bVerify);

                SPList oList = oweb.Lists[base.ListUid];
                SPListItem oListItem = oList.GetItemById(base.ItemID);

                base.totalCount = 100;

                API.ApplicationUninstaller installer = new API.ApplicationUninstaller(oListItem["EXTID"].ToString(), cn, this);
                installer.UninstallApp(bVerify, oweb);

                string retMessage = installer.Message;
                maxErrorLevel = installer.MaxErrorLevel;
                dtMessages = installer.DtMessagesHTML;


                base.sErrors = installer.XmlMessages.OuterXml;

                if (installer.MaxErrorLevel > 1)
                {
                    base.bErrors = true;
                }
            }
            catch (Exception ex)
            {
                base.bErrors = true;
                base.sErrors += "General Failure: " + ex.Message;
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        public void SetPercent(float percent)
        {
            updateProgress(percent);
        }
    }
}
