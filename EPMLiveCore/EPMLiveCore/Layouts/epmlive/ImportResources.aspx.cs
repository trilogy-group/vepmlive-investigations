using System;
using System.IO;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ImportResources : LayoutsPageBase
    {
        

        #region Methods (2) 

        // Protected Methods (2) 

        protected void ImportButtonOnClick(object sender, EventArgs e)
        {
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
    }
}