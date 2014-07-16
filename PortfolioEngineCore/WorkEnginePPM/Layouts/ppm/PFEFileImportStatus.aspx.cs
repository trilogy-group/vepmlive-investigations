using Microsoft.SharePoint.WebControls;
using System;
using System.Xml;
using System.Xml.Linq;
using WorkEnginePPM.Core.PFEDataServiceManager;
using WorkEnginePPM.DataServiceModules;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class PFEFileImportStatus : LayoutsPageBase
    {

        private string _jobId;


        protected string JobId
        {
            get { return _jobId; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _jobId = Request.Params["jobid"] ?? string.Empty;
                string format = Request.Params["format"] ?? string.Empty;

                if (!format.Trim().ToLower().Equals("json"))
                {
                    if (string.IsNullOrEmpty(_jobId))
                    {
                        lblError.Text = "No Job ID was provided.";
                        statusPanel.Visible = false;
                    }
                    else
                    {
                        statusPanel.Visible = true;
                    }
                }
                else
                {
                    string response = "{warmingUp:true}";

                    if (string.IsNullOrEmpty(_jobId))
                    {
                        response = "{error:\"No Job ID was provided.\"}";
                    }
                    else
                    {

                        /// Incase we are integrating using webservice
                        XDocument collectDataImportResultXDocument;
                        XElement collectDataImportResultXElement;
                        using (PortfolioEngineAPI api = new PortfolioEngineAPI())
                        {
                            collectDataImportResultXDocument = XDocument.Parse(api.Execute("CollectDataImportResult", _jobId));
                            collectDataImportResultXElement = collectDataImportResultXDocument.Root;
                            PFEDataServiceUtils.ValidateResponse(collectDataImportResultXElement);
                            if (!String.IsNullOrEmpty(collectDataImportResultXElement.Value))
                                response = collectDataImportResultXElement.Value;
                        }

                        //XmlNode timerJobStatus = EPMLiveCore.API.Timer.GetTimerJobStatus(Web, new Guid(_jobId));

                        //XmlNode node = timerJobStatus.FirstChild;
                        //if (node != null)
                        //{
                        //    response = node.Value;
                        //}
                    }

                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.Write(Server.HtmlDecode(response));
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }



    }
}
