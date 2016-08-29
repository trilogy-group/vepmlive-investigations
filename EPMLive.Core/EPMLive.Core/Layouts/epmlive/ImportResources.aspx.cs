using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.IO;
using System.Xml;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ImportResources : LayoutsPageBase
    {
        private bool isRunning;
        private Guid jobUid;
        private Int32 percentComplete;

        protected string msg = "A resource import job is currently running and is {0}% complete. Would you like to cancel it and run this new import job instead?";
        #region Methods (2) 

        // Protected Methods (2) 

        protected void ImportButtonOnClick(object sender, EventArgs e)
        {
            IsImportResourceAlreadyRunning();

            if (isRunning)
            {
                msg = string.Format(msg, percentComplete);
                WarningPanel.Visible = true;
                MainPanel.Visible = false;
            }
            else
            {
                WarningPanel.Visible = false;
                MainPanel.Visible = true;
                ImportMain(false);
            }
        }

        private void IsImportResourceAlreadyRunning()
        {
            string result = Timer.IsImportResourceAlreadyRunning(SPContext.Current.Web);

            XmlDocument resultDoc = new XmlDocument();
            resultDoc.LoadXml(result);

            XmlNode elementNode = resultDoc.SelectSingleNode("ResourceImporter");
            if (elementNode != null)
            {
                isRunning = Convert.ToBoolean(elementNode.Attributes["Success"].Value);
                jobUid = new Guid(elementNode.Attributes["JobUid"].Value);
                percentComplete = Convert.ToInt32(elementNode.Attributes["PercentComplete"].Value);
            }
        }

        protected void ImportMain(bool cancelExistingJob)
        {
            if (cancelExistingJob)
            {
                // Again calling this method to fetch currently running job id to cancel it.
                IsImportResourceAlreadyRunning();
                Timer.CancelTimerJob(SPContext.Current.Web, jobUid);
            }
            if (!FileUpload.HasFile) return;

            string extension = Path.GetExtension(FileUpload.FileName);
            if (string.IsNullOrEmpty(extension)) return;

            if (!extension.ToLower().Equals(".xlsm"))
            {
                CustomValidator.ErrorMessage = "Files with extension " + extension + " are not allowed.";
                CustomValidator.IsValid = false;
            }
            else
            {
                string fileId;

                SPWeb spWeb = SPContext.Current.Web;

                using (var epmLiveFileStore = new EPMLiveFileStore(spWeb))
                {
                    fileId = epmLiveFileStore.Add(FileUpload.FileBytes);
                }

                SPSite spSite = spWeb.Site;

                Guid jobId = Timer.AddTimerJob(spSite.ID, spWeb.ID, "Import Resources", 60, fileId, string.Empty, -1, 9,
                                                string.Empty);
                Timer.Enqueue(jobId, 0, spSite);

                Response.Redirect(spWeb.Url + "/_layouts/epmlive/importresourcestatus.aspx?isdlg=1&jobid=" + jobId);
            }           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        #endregion Methods 

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            WarningPanel.Visible = false;
            MainPanel.Visible = true;
            ImportMain(true);
        }
    }
}