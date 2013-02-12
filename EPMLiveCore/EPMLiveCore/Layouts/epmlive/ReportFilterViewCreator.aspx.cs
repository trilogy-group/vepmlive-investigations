using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ReportFilterViewCreator : LayoutsPageBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CreateViewButton.Click += CreateViewButton_Click;
        }

        protected void CreateViewButton_Click(object sender, EventArgs e)
        {
            var listGuidAsString = Request.QueryString["List"];
            var listGuid = new Guid(listGuidAsString);
            var listToCreateViewOn = SPContext.Current.Web.Lists[listGuid];
            var selectedLayout = LayoutListBox.SelectedValue;
            var viewName = ViewNameTextBox.Text;
            
            var view = CreateListView(listToCreateViewOn, viewName);
            
            HideListWebPartAndRemoveOtherWebParts(view);
            
            UpdateViewHtmlAndSave(listToCreateViewOn, selectedLayout, view);

            SPUtility.Redirect(string.Format("{0}/{1}?ControlMode=edit&DisplayMode=design", listToCreateViewOn.ParentWeb.Url, view.Url), SPRedirectFlags.Default, HttpContext.Current);
        }

        /// <summary>
        /// The grid/gant web part and list web part are added by default. This will remove the grid and hide the list web part.
        /// </summary>
        /// <param name="view">The view to do the updates on.</param>
        private static void HideListWebPartAndRemoveOtherWebParts(SPView view)
        {
            var web = SPContext.Current.Web;
            var webPartManager = web.GetLimitedWebPartManager(view.Url, PersonalizationScope.Shared);
            var listViewWebPart = webPartManager.GetWebPartByTypeName("XsltListViewWebPart");
            var webPartsToDelete = new List<WebPart>();

            foreach (WebPart webPart in webPartManager.WebParts)
            {
                if (!webPart.Equals(listViewWebPart))
                {
                    webPartsToDelete.Add(webPart);
                }
            }

            foreach (var webPartToDelete in webPartsToDelete)
            {
                webPartManager.DeleteWebPart(webPartToDelete);
            }

            if (listViewWebPart == null) return;
            
            listViewWebPart.Hidden = true;
            webPartManager.SaveChanges(listViewWebPart);
        }

        /// <summary>
        /// Updates the view HTML to include the web part zone layout the user selected.
        /// </summary>
        /// <param name="listToCreateViewOn">The list to create view on.</param>
        /// <param name="selectedLayout">The selected layout.</param>
        /// <param name="view">The view.</param>
        private static void UpdateViewHtmlAndSave(SPList listToCreateViewOn, string selectedLayout, SPView view)
        {
            var viewAspxFile = listToCreateViewOn.GetViewFile(view);
            var fileContents = viewAspxFile.GetContents();

            var fileContentsWithEpmLiveWebPartTag = AddEpmLiveWebPartTagToTopOfContents(fileContents);
            var viewContent = GetViewContentBasedOnLayoutType(selectedLayout);
            var updatedFileContents = InsertViewContentIntoContentPlaceHolder(fileContentsWithEpmLiveWebPartTag, viewContent);

            viewAspxFile.UpdateContentsAndSave(updatedFileContents);
        }

        /// <summary>
        /// Creates a new view on a given list.
        /// </summary>
        /// <param name="listToCreateViewOn">The list to create view on.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <returns></returns>
        private static SPView CreateListView(SPList listToCreateViewOn, string viewName)
        {
            var viewCollection = listToCreateViewOn.Views;
            var viewFields = new System.Collections.Specialized.StringCollection();

            viewCollection.Add(viewName, viewFields, string.Empty, 100, true, false);

            listToCreateViewOn.ParentWeb.Update();

            return listToCreateViewOn.Views[viewName];
        }

        /// <summary>
        /// Adds the epm live web part tag to the top of the view html.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <returns></returns>
        private static string AddEpmLiveWebPartTagToTopOfContents(string fileContents)
        {
            const string epmLiveWebPartsTag = "<%@ Register TagPrefix=\"WpNs0\" Namespace=\"EPMLiveWebParts\" Assembly=\"EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5\"%>";

            return epmLiveWebPartsTag + fileContents;
        }

        /// <summary>
        /// Gets the web part zone aspx code based on the zone layout the user selected.
        /// </summary>
        /// <param name="selectedLayout">The selected layout.</param>
        /// <returns></returns>
        private static string GetViewContentBasedOnLayoutType(string selectedLayout)
        {
            switch (selectedLayout.ToLower())
            {
                case "headerfooter3column":
                    return GetHeaderFooter3ColumnLayout();
                case "fullpagevertical":
                    return GetFullPageVerticalLayout();
                case "headerleftcolumnbody":
                    return GetHeaderLeftColumnBodyLayout();
                case "headerrightcolumnbody":
                    return GetHeaderRightColumnBodyLayout();
            }

            return string.Empty;
        }

        /// <summary>
        /// Inserts the updated view content containing web part zones into content place holder of the view code.
        /// </summary>
        /// <param name="fileContents">The file contents.</param>
        /// <param name="viewContent">Content of the view.</param>
        /// <returns></returns>
        private static string InsertViewContentIntoContentPlaceHolder(string fileContents, string viewContent)
        {
            const string pattern = "(?<=<asp:Content ContentPlaceHolderId=\"PlaceHolderMain\" runat=\"server\">)(\n|\r|\r\n)(?<content>.+?)(\n|\r|\r\n)(?=</asp:Content>)";
            var regex = new Regex(pattern);
            var result = regex.Replace(fileContents, viewContent);

            return result;
        }

        /// <summary>
        /// Gets the header footer 3 column layout zone aspx code.
        /// </summary>
        /// <returns></returns>
        private static string GetHeaderFooter3ColumnLayout()
        {
            var htmlContentsStringBuilder = new StringBuilder();

            htmlContentsStringBuilder.Append("<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" colspan=\"3\" valign=\"top\" width=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Header\" ID=\"Header\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:LeftColumn\" ID=\"LeftColumn\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:MiddleColumn\" ID=\"MiddleColumn\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:RightColumn\" ID=\"RightColumn\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" colspan=\"3\" valign=\"top\" width=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Footer\" ID=\"Footer\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">if(typeof(MSOLayout_MakeInvisibleIfEmpty) == \"function\") {MSOLayout_MakeInvisibleIfEmpty();}</script>");
            htmlContentsStringBuilder.Append("</table>");

            return htmlContentsStringBuilder.ToString();
        }

        /// <summary>
        /// Gets the full page vertical layout zone aspx code
        /// </summary>
        /// <returns></returns>
        private static string GetFullPageVerticalLayout()
        {
            var htmlContentsStringBuilder = new StringBuilder();

            htmlContentsStringBuilder.Append("<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" width=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:FullPage\" ID=\"FullPage\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">if(typeof(MSOLayout_MakeInvisibleIfEmpty) == \"function\") {MSOLayout_MakeInvisibleIfEmpty();}</script>");
            htmlContentsStringBuilder.Append("</table>");

            return htmlContentsStringBuilder.ToString();
        }

        /// <summary>
        /// Gets the header left column body layout zone aspx code.
        /// </summary>
        /// <returns></returns>
        private static string GetHeaderLeftColumnBodyLayout()
        {
            var htmlContentsStringBuilder = new StringBuilder();

            htmlContentsStringBuilder.Append("<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" colspan=\"2\" valign=\"top\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Header\" ID=\"Header\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\">");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:LeftColumn\" ID=\"LeftColumn\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Body\" ID=\"Body\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">if(typeof(MSOLayout_MakeInvisibleIfEmpty) == \"function\") {MSOLayout_MakeInvisibleIfEmpty();}</script>");
            htmlContentsStringBuilder.Append("</table>");

            return htmlContentsStringBuilder.ToString();
        }

        /// <summary>
        /// Gets the header right column body layout zone aspx code.
        /// </summary>
        /// <returns></returns>
        private static string GetHeaderRightColumnBodyLayout()
        {
            var htmlContentsStringBuilder = new StringBuilder();

            htmlContentsStringBuilder.Append("<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" colspan=\"2\" valign=\"top\" width=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Header\" ID=\"Header\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<tr>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\" width=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Body\" ID=\"Body\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("<td id=\"_invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" height=\"100%\"> ");
            htmlContentsStringBuilder.Append("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:RightColumn\" ID=\"RightColumn\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone> </td>");
            htmlContentsStringBuilder.Append("</tr>");
            htmlContentsStringBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">if(typeof(MSOLayout_MakeInvisibleIfEmpty) == \"function\") {MSOLayout_MakeInvisibleIfEmpty();}</script>");
            htmlContentsStringBuilder.Append("</table>");

            return htmlContentsStringBuilder.ToString();
        }
    }
}
