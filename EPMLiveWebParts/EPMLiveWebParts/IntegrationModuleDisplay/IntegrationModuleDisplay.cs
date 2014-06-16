using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:IntegrationModuleDisplay runat=server></{0}:IntegrationModuleDisplay>")]
    [Guid("F27DF1AA-4D78-43F0-AE48-F61BAF42E155")]
    [XmlRoot(Namespace = "IntegrationModuleDisplay")]
    public class IntegrationModuleDisplay : Microsoft.SharePoint.WebPartPages.WebPart
    {
        protected override void CreateChildControls()
        {



        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            try
            {
                if (SPContext.Current.Item != null)
                {
                    //int itemid = SPContext.Current.Item.ID;
                    //string Errors = "";
                    //EPMLiveCore.API.Integration.IntegrationCore c = new EPMLiveCore.API.Integration.IntegrationCore(SPContext.Current.Site.ID, SPContext.Current.Web.ID);
                    //List<EPMLiveCore.API.Integration.IntegrationCore.IntegrationControlDef> cs = c.GetEmbbededControls(SPContext.Current.ListId, SPContext.Current.ListItem, out Errors);

                    //foreach (EPMLiveCore.API.Integration.IntegrationCore.IntegrationControlDef def in cs)
                    //{
                    //    output.WriteLine("<!----------------------Integration: " + def.id + "-------------------------->");
                    //    output.WriteLine(def.HTML);
                    //    output.WriteLine("<!----------------------Integration-------------------------->");
                    //}

                    //if (Errors != "")
                    //{
                    //    output.WriteLine("<br><br>Errors:<br>" + Errors);
                    //}

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("select platformintegrationid, integrationurl FROM PLATFORMINTEGRATIONS where listid=@listid", cn);
                        cmd.Parameters.AddWithValue("@listid", SPContext.Current.ListId);


                        int counter = 0;
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            string url = dr.GetString(1);
                            url = url.Substring(0, url.LastIndexOf("/"));
                            output.WriteLine(@"
                            <div id=""phupland" + counter + @"""></div><br>
                            <div id=""phuplandc" + counter + @"""></div>
                            <script>
                             $.ajax({
                                url:""" + url + @"/getlinksstyles.aspx"",
                                success:function(data){
                                        $(""<style></style>"").appendTo(""head"").html(data);
                                        $.ajax({
                                                    url: '" + url + @"/getlinks.aspx?integrationid=" + dr.GetGuid(0) + @"&ID=' + window.epmLive.currentItemID,
                                                    cache: false,
                                                    success: function (data) {
                                                        $(""#phupland" + counter + @""").html('');
                                                        $(""#phupland" + counter + @""").html(data);
                                                    },
                                                    error: function (msg) {
                                                        alert('An error occurred.');
                                                    }
                                                });
                                                    $.ajax({
                                                    url: '" + url + @"/getcontrols.aspx?integrationid=" + dr.GetGuid(0) + @"&ID=' + window.epmLive.currentItemID,
                                                    cache: false,
                                                    success: function (data) {
                                                        $(""#phuplandc" + counter + @""").html('');
                                                        $(""#phuplandc" + counter + @""").html(data);
                                                    },
                                                    error: function (msg) {
                                                        alert('An error occurred.');
                                                    }
                                                });
                                            }
                                        });
                            </script>
                                ");
                        }

                        cn.Close();
                    });

                }
                else
                    output.WriteLine("This web part must be used on a display form");
            }
            catch (Exception ex)
            {
                output.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
