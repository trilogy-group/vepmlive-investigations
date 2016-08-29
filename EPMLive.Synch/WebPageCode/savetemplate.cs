using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EPMLiveSynch
{
    public partial class SaveTemplate : LayoutsPageBase
    {
        protected string result;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            SPSite site = SPContext.Current.Site;
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{

                //using ( = new SPSite(web.Site.ID))
                {
                    site.AllowUnsafeUpdates = true;
                    site.RootWeb.AllowUnsafeUpdates = true;
                    web.AllowUnsafeUpdates = true;
                    try
                    {
                        try
                        {
                            Microsoft.SharePoint.SPUserSolution delSolution = null;
                            foreach (Microsoft.SharePoint.SPUserSolution s in web.Site.Solutions)
                            {
                                string name = s.Name;
                                if (name == web.Title + ".wsp")
                                {
                                    delSolution = s;
                                    break;
                                }
                            }
                            if (delSolution != null)
                            {
                                EnsureSiteCollectionFeaturesDeActivated(delSolution, site);
                                site.AllowUnsafeUpdates = true;
                                site.Solutions.Remove(delSolution);
                            }

                            SPList solGallery1 = web.Site.RootWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);
                            foreach (SPListItem item in solGallery1.Items)
                            {
                                if (item.File.Name.Equals(web.Title + ".wsp"))
                                {
                                    solGallery1.Items.DeleteItemById(item.ID);
                                    break;
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            result = ex.Message;
                        }
                        if (result != "")
                        {
                            bool bSaveContent;
                            if (Request["savecontent"] != null && Request["savecontent"].ToString().ToUpper() == "NO")
                            {
                                bSaveContent = false;
                            }
                            else
                            {
                                bSaveContent = true;
                            }

                            site.AllowUnsafeUpdates = true;
                            site.RootWeb.AllowUnsafeUpdates = true;
                            web.AllowUnsafeUpdates = true;
                            web.SaveAsTemplate(web.Title, web.Title, "", bSaveContent);
                            web.AllowUnsafeUpdates = false;
                            web.Site.AllowUnsafeUpdates = false;
                            web.Site.RootWeb.AllowUnsafeUpdates = false;
                            result = "Success";
                        }
                    }
                    catch (Exception Ex)
                    {
                        result = Ex.Message;
                    }
                }
            //});

            
            //finally
            //{
            //    Label1.Text = result;
            //}

        }

        static void EnsureSiteCollectionFeaturesDeActivated(SPUserSolution solution, SPSite site)
        {
            SPUserSolutionCollection solutions = site.Solutions;
            List<SPFeatureDefinition> oListofFeatures = GetFeatureDefinitionsInSolution(solution, site);
            foreach (SPFeatureDefinition def in oListofFeatures)
            {
                if (((def.Scope == SPFeatureScope.Site) && def.ActivateOnDefault) && (site.Features[def.Id] != null))
                {
                    site.Features.Remove(def.Id);
                    //site.Features.Add(def.Id);


                }
            }
        }
        static List<SPFeatureDefinition> GetFeatureDefinitionsInSolution(SPUserSolution solution, SPSite site)
        {
            List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
            foreach (SPFeatureDefinition definition in site.FeatureDefinitions)
            {
                if (definition.SolutionId.Equals(solution.SolutionId))
                {
                    list.Add(definition);
                }
            }
            return list;
        }


            //SPWeb web = SPContext.Current.Web;
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        using (SPSite site = new SPSite("http://jasondev2008/p1"))
        //        {
        //            site.AllowUnsafeUpdates = true;
        //            site.RootWeb.AllowUnsafeUpdates = true;
        //            site.WebApplication.FormDigestSettings.Enabled = false;
        //            using (SPWeb web = site.OpenWeb())
        //            {

        //                try
        //                {
        //                    SPWebTemplateCollection oWebTmpltCol = web.GetAvailableWebTemplates((uint)web.Locale.LCID);
        //                    try
        //                    {
        //                        SPWebTemplate oWebTmplt = oWebTmpltCol[web.Title];
        //                        string sFileName = oWebTmplt.Name;

        //                        SPSite site = SPContext.Current.Site;
        //                        {
        //                            SPWeb rootWeb = web.Site.RootWeb;
        //                            {
        //                                SPSecurity.RunWithElevatedPrivileges(delegate()
        //                                {
        //                                    SPFile fTmplt = rootWeb.GetFile(rootWeb.Site.Url + "/_catalogs/solutions/" + sFileName);
        //                                    if (fTmplt != null && fTmplt.Exists)
        //                                    {
        //                                        rootWeb.AllowUnsafeUpdates = true;
        //                                        fTmplt.Delete();
        //                                        rootWeb.Update();
        //                                        rootWeb.AllowUnsafeUpdates = false;
        //                                    }
        //                                });
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        result = ex.Message;
        //                    }

        //                    bool bSaveContent;
        //                    if (Request["savecontent"] != null && Request["savecontent"].ToString().ToUpper() == "NO")
        //                    {
        //                        bSaveContent = false;
        //                    }
        //                    else
        //                    {
        //                        bSaveContent = true;
        //                    }
        //                    web.AllowUnsafeUpdates = true;

        //                    web.SaveAsTemplate(web.Title, web.Title, "", bSaveContent);
        //                    SPSolutionExporter.ExportWebToGallery(web, web.Title, web.Title, "", SPSolutionExporter.ExportMode.FullPortability, bSaveContent);

        //                    web.AllowUnsafeUpdates = false;
        //                    result = "Success";
        //                }
        //                catch (Exception exc)
        //                {
        //                    result = exc.Message;
        //                }
        //            }
        //            site.WebApplication.FormDigestSettings.Enabled = true;
        //        }
        //    });
        //}
        

    }
}