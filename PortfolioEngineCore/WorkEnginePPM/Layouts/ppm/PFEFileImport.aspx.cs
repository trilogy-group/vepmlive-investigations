using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Web.UI;
using System.Xml;
using EPMLiveCore.API;
using System.IO;
using EPMLiveCore.Infrastructure;
using System.Web.Services;
using System.Xml.Linq;
using WorkEnginePPM.DataServiceModules;
using System.Text;
using System.Runtime.Serialization;
using WorkEnginePPM.Core.PFEDataServiceManager;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class PFEFileImport : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImportButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                if (!FileUpload.HasFile)
                {
                    lblError.Text = "Please upload the pfe cost planner csv file.";
                    return;
                };

                string extension = Path.GetExtension(FileUpload.FileName);

                if (string.IsNullOrEmpty(extension))
                {
                    lblError.Text = "Please upload correct pfe cost planner file with csv extension.";
                    return;
                }

                if (!extension.ToLower().Equals(".csv"))
                {
                    lblError.Text = String.Format("Files with extension {0} are not allowed.", extension);
                    return;
                }

                if (Request["listid"] == null)
                {
                    lblError.Text = String.Format("Please select a proper list for importing cost data.");
                    return;
                }

                /// Incase we are integrating using webservice
                using (PortfolioEngineAPI api = new PortfolioEngineAPI())
                {
                    XDocument uploadFileXDocument;
                    XElement uploadFileXElement;
                    XDocument scheduleDataImportXDocument;
                    XElement scheduleDataImportXElement;
                    Guid fileId;

                    uploadFileXDocument = XDocument.Parse(api.UploadFile(FileUpload.FileBytes, FileUpload.FileName));
                    uploadFileXElement = uploadFileXDocument.Root;
                    PFEDataServiceUtils.ValidateResponse(uploadFileXElement);

                    if (Guid.TryParse(uploadFileXElement.Value, out fileId))
                    {
                        ScheduleDataImportRequest scheduleDataImportRequest = new ScheduleDataImportRequest();
                        scheduleDataImportRequest.Module = DSMModule.CostPlanner;
                        scheduleDataImportRequest.ListId = new Guid(Request["listid"]);
                        scheduleDataImportRequest.FileId = fileId;

                        scheduleDataImportXDocument = XDocument.Parse(api.Execute("ScheduleDataImport", PFEDataServiceUtils.JsonSerializer(scheduleDataImportRequest)));
                        scheduleDataImportXElement = scheduleDataImportXDocument.Root;
                        PFEDataServiceUtils.ValidateResponse(scheduleDataImportXElement);

                        ScheduleDataImportResponse scheduleDataImportResponse = PFEDataServiceUtils.JsonDeserialize<ScheduleDataImportResponse>(scheduleDataImportXElement.Value);

                        if (scheduleDataImportResponse.JobId != Guid.Empty)
                        {
                            SPWeb spWeb = SPContext.Current.Web;
                            SPSite spSite = spWeb.Site;
                            Response.Redirect(spWeb.Url + "/_layouts/15/ppm/pfefileimportstatus.aspx?isdlg=1&jobid=" + scheduleDataImportResponse.JobId);
                        }
                        else
                        {
                            lblError.Text = "Problem in import process. Please contact administrator.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Problem in uploading file. Please contact administrator.";
                    }


                    //string fileId;

                    //SPWeb spWeb = SPContext.Current.Web;

                    //using (var epmLiveFileStore = new EPMLiveFileStore(spWeb))
                    //{
                    //    fileId = epmLiveFileStore.Add(FileUpload.FileBytes);
                    //}

                    //SPSite spSite = spWeb.Site;

                    //Guid jobId = EPMLiveCore.API.Timer.AddTimerJob(spSite.ID, spWeb.ID, "Import PFE Cost Planner CSV Data", 25, fileId, string.Empty, -1, 9,
                    //                               string.Empty);
                    //EPMLiveCore.API.Timer.Enqueue(jobId, 0, spSite);

                    //Response.Redirect(spWeb.Url + "/_layouts/15/ppm/pfefileimportstatus.aspx?isdlg=1&jobid=" + jobId);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


    }
}
