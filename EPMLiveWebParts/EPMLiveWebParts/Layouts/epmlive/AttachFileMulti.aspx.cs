using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.IO;
using System.Web;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class AttachFileMulti : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnOk_click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["ListId"]) && !string.IsNullOrEmpty(Request["ItemId"]))
                {
                    Guid listId = new Guid(Request["ListId"]);
                    Int32 itemId = Convert.ToInt32(Request["ItemId"]);
                    SPWeb webObj = SPContext.Current.Web;
                    SPList lstObj = webObj.Lists[listId];
                    if (lstObj != null)
                    {
                        SPListItem thisItem = lstObj.GetItemById(itemId);
                        if (thisItem != null)
                        {
                            if (fileUploadControl.HasFiles)
                            {
                                SPAttachmentCollection attach = thisItem.Attachments;
                                HttpFileCollection uploadedFiles = Request.Files;
                                Stream attachmentStream;
                                Byte[] attachmentContent;
                                for (int i = 0; i < uploadedFiles.Count; i++)
                                {
                                    HttpPostedFile userPostedFile = uploadedFiles[i];
                                    String fileName = userPostedFile.FileName;
                                    attachmentStream = userPostedFile.InputStream;
                                    attachmentContent = new Byte[attachmentStream.Length];
                                    attachmentStream.Read(attachmentContent, 0, (int)attachmentStream.Length);
                                    attachmentStream.Close();
                                    attachmentStream.Dispose();
                                    attach.Add(fileName, attachmentContent);
                                }
                                thisItem.Update();
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallClosePopup", "closePopup(1);", true);
                            }
                            else
                            {
                                lblError.Text = "The file name is invalid or the file is empty. A file name cannot contain any of the following characters: \\ / : * ? \" < > | # { } % ~ &";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
