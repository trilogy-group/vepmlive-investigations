using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI;
using EPMLiveCore;
using EPMLiveWebParts.Utilities;
using Microsoft.SharePoint;
using System.Security.Authentication;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.CONTROLTEMPLATES.EPMLiveWebParts
{
    public partial class ContextualHelpSlideOutControl : UserControl
    {
        #region Fields (4) 

        public string ContentLocation;
        protected string SlideOutId;
        public int SlideOutOffset;
        public string SlideOutTitle;

        #endregion Fields 

        #region Methods (4) 

        // Protected Methods (1) 

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = string.Empty;

            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int featureLicenseStatus = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if (featureLicenseStatus != 0)
            {
                Response.Write(act.translateStatus(featureLicenseStatus));
                return;
            }
            
            if (!string.IsNullOrEmpty(ContentLocation))
            {
                Uri uri;
                if (Uri.TryCreate(ContentLocation, UriKind.Absolute, out uri))
                {
                    SlideOutId = Path.GetFileNameWithoutExtension(uri.LocalPath);

                    if (IsSlideOutVisible())
                    {
                        try
                        {
                            DisplaySlideOut(uri);
                        }
                        catch (WebException)
                        {
                            ContentPanel.Visible = false;
                            message = string.Format(@"<strong>ERROR: </strong> Unable to connect to: {0}",
                                                    ContentLocation);
                        }
                    }
                    else
                    {
                        ContentPanel.Visible = false;
                    }
                }
                else
                {
                    message = string.Format(@"<strong>ERROR: </strong> {0} is not a valid URL.",
                                            ContentLocation);
                }
            }
            else
            {
                message = @"<strong>ERROR: </strong> Please provide a valid Content Location URL.";
            }

            if (string.IsNullOrEmpty(message)) return;

            DisplayMessage(message);
        }

        // Private Methods (3) 

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void DisplayMessage(string message)
        {
            litMessages.Text = message;
            ContentPanel.Visible = false;
        }

        /// <summary>
        /// Displays the slide out.
        /// </summary>
        /// <param name="uri">The URI.</param>
        private void DisplaySlideOut(Uri uri)
        {
            string content;

            ServicePointManager.ServerCertificateValidationCallback +=
            delegate(
                object sender,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }; 

            using (WebResponse webResponse = WebRequest.Create(uri).GetResponse())
            {
                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    content = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }

            content = content.Trim().XSSProtect();

            if (!string.IsNullOrEmpty(content))
            {
                litContent.Text = content;
            }
            else
            {
                ContentPanel.Visible = false;
            }
        }

        /// <summary>
        /// Determines whether [is slide out visible].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is slide out visible]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSlideOutVisible()
        {
            if (SPContext.Current.FormContext.FormMode != SPControlMode.Display) return false;

            bool isVisible = true;

            try
            {
                Guid siteId = SPContext.Current.Site.ID;

                using (var spSite = new SPSite(siteId))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        const string queryString =
                            @"
                            SELECT      COUNT(*) AS Total
                            FROM        dbo.PERSONALIZATIONS
                            GROUP BY    [Key], Value, SiteId, UserId
                            HAVING      ([Key] = N'ContextualSlideOutId') 
                                        AND (Value = @value) 
                                        AND (SiteId = @siteId) 
                                        AND (UserId = @userId)";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@value", SlideOutId);
                            sqlCommand.Parameters.AddWithValue("@siteId", siteId);
                            sqlCommand.Parameters.AddWithValue("@userId", SPContext.Current.Web.CurrentUser.ID);

                            SPSecurity.RunWithElevatedPrivileges(() =>
                                                                     {
                                                                         sqlConnection.Open();

                                                                         object scalar = sqlCommand.ExecuteScalar();

                                                                         isVisible = scalar == null;

                                                                         sqlConnection.Close();
                                                                     });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                isVisible = false;
                DisplayMessage(
                    string.Format(
                        @"<strong>ERROR: </strong>Unable to retrieve Slide Out settings from the database.<br/><strong>Exception: <strong>{0}",
                        e.Message));
            }

            return isVisible;
        }

        #endregion Methods 
    }
}
