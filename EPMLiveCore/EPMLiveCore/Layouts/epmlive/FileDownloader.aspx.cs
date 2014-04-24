using System;
using System.Web;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class FileDownloader : LayoutsPageBase
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            string file = Request.Params["fileid"];
            string fileName = Request.Params["filename"];
            string delete = Request.Params["delete"];
            string contentType = Request.Params["ct"];

            if (string.IsNullOrEmpty(file)) throw new HttpException(404, "HTTP/1.1 404 Not Found");
            if (string.IsNullOrEmpty(fileName)) fileName = file;

            try
            {
                byte[] bytes;

                using (var epmLiveFileStore = new EPMLiveFileStore(SPContext.Current.Web))
                {
                    bytes = epmLiveFileStore.Get(file);

                    if (!string.IsNullOrEmpty(delete) && delete.Equals("1"))
                    {
                        epmLiveFileStore.Delete(file);
                    }
                }

                if (!string.IsNullOrEmpty(contentType)) Response.ContentType = contentType;

                Response.AddHeader("Content-Disposition", @"attachment;filename=""" + fileName + @"""");
                Response.Buffer = true;
                EnableViewState = false;

                Response.BinaryWrite(bytes);
                Response.End();
            }
            catch (Exception)
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
        }

        #endregion Methods 
    }
}