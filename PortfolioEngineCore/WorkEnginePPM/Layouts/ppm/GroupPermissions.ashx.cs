using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class GroupPermissions : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.GroupPermissions";
            StreamReader sr = new StreamReader(context.Request.InputStream);
            string sRequest = sr.ReadToEnd();
            try
            {
                context.Server.ScriptTimeout = 86400;
                s = WebAdmin.CheckRequest(context, this_class, sRequest);
                if (s == "")
                {
                    CStruct xPageRequest = new CStruct();
                    if (xPageRequest.LoadXML(sRequest))
                    {
                        string sFunction = xPageRequest.GetStringAttr("function");
                        string sRequestContext = xPageRequest.GetStringAttr("context");
                        try
                        {
                            Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                            Type thisClass = assemblyInstance.GetType(this_class, true, true);
                            MethodInfo m = thisClass.GetMethod(sFunction);
                            CStruct xData = xPageRequest.GetSubStruct("data");
                            object result = m.Invoke(null, new object[] { context, sRequestContext, xData });
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, result.ToString());
                        }
                        catch (Exception ex)
                        {
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                s = WebAdmin.BuildReply(this_class, this_class + ".ProcessRequest", sRequest, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
            }
            context.Response.ContentType = "text/xml; charset=utf-8";
            context.Response.Write(CStruct.ConvertXMLToJSON(s));
        }

        public static string GroupPermissionsRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "GetGroupPermissionsInfo":
                    {
                        int nGroupId = Int32.Parse(xData.InnerText);
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo);
                        DBAccess dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            DataTable dt;

                            if (dbaGroups.SelectGroup(dba, nGroupId, out dt) != StatusEnum.rsSuccess)
                            {
                                sReply = WebAdmin.FormatError("exception", "GroupPermissions.GetGroupPermissionsInfo", dba.StatusText);
                            }
                            else
                            {
                                CStruct xGroupPermissions = new CStruct();
                                xGroupPermissions.Initialize("groupPermissions");
                                if (dt.Rows.Count == 1)
                                {
                                    DataRow row = dt.Rows[0];
                                    xGroupPermissions.CreateIntAttr("groupid", DBAccess.ReadIntValue(row["GROUP_ID"]));
                                    xGroupPermissions.CreateStringAttr("name", DBAccess.ReadStringValue(row["GROUP_NAME"]));
                                    xGroupPermissions.CreateStringAttr("notes", DBAccess.ReadStringValue(row["GROUP_NOTES"]));
                                }
                                else
                                {
                                    xGroupPermissions.CreateIntAttr("groupid", 0);
                                    xGroupPermissions.CreateStringAttr("name", "New Permission Group");
                                    xGroupPermissions.CreateStringAttr("notes", "");
                                }
                                dbaUsers.SelectGroupPermissions(dba, nGroupId, out dt);
                                dba.Close();

                                if (dba.Status != StatusEnum.rsSuccess)
                                {
                                    sReply = WebAdmin.FormatError("exception", "GroupPermissions.SelectGroupPermissions", dba.StatusText);
                                }
                                else
                                {
                                    string sTreegridData = BuildGridLayout(dt).XML();
                                    xGroupPermissions.CreateStringAttr("treegridData", sTreegridData);

                                    sReply = xGroupPermissions.XML();
                                }
                            }
                        }
                        break;
                    }
                    case "UpdateGroupPermissionsInfo":
                    {
                        sReply = UpdateGroupPermissionsInfo(Context, xData);
                        break;
                    }
                    case "DeleteGroupPermission":
                    {
                        sReply = DeleteGroupPermission(Context, xData);
                        break;
                    }
                    case "GetGroupMembersInfo":
                    {
                        sReply = GetGroupMembersInfo(Context, xData);
                        break;
                    }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "GroupPermissions.GroupPermissionsRequest", ex.Message);
            }

            return sReply;
        }
        private static string UpdateGroupPermissionsInfo(HttpContext Context, CStruct xData)
        {
            int nGroupId = xData.GetIntAttr("groupid");
            string sName = xData.GetStringAttr("name");
            string sNotes = xData.GetStringAttr("notes");
            string sGridData = xData.GetString("treegridData");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    // pick up lines from Permissions grid that are set on
                    //<Grid>
                    //   <IO/>
                    //   <Head/>
                    //   <Solid/>
                    //   <Body>
                    //      <B>
                    //         <I id="AR1" Def="R" FieldID="99999999" Permission="Admin" CB="">
                    //            <I id="AR2" Def="R" FieldID="3009" Permission="A01 Base and Timesheet SysAdmin" CB="1"/>
                    //            <I id="AR3" Def="R" FieldID="3025" Permission="A03 Portfolio, Resource, and Capacity SysAdmin" CB="1"/>
                    CStruct xGrid = new CStruct();
                    xGrid.LoadXML(sGridData);
                    CStruct xBody = xGrid.GetSubStruct("Body");
                    CStruct xB = xBody.GetSubStruct("B");
                    List<CStruct> listIParent = xB.GetList("I");

                    CStruct xPerms = new CStruct();
                    xPerms.Initialize("Perms");

                    foreach (CStruct xIParent in listIParent)
                    {
                        List<CStruct> listI = xIParent.GetList("I");
                        foreach (CStruct xI in listI)
                        {
                            int nId = xI.GetIntAttr("FieldID");
                            bool bChecked = xI.GetBooleanAttr("CB");
                            if (bChecked == true)
                            {
                                CStruct xPerm = xPerms.CreateSubStruct("Perm");
                                xPerm.CreateIntAttr("ID", nId);
                            }
                        }
                    }
                    if (dbaGroups.UpdateGroupPermissionsInfo(dba, ref nGroupId, sName, sNotes, xPerms, out sReply) != StatusEnum.rsSuccess)
                    { 
                        if(sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "GroupPermissions.UpdateGroupPermissionsInfo2", dba.StatusText); 
                    }
                    else 
                    { 
                        //sReply = ReadCustomFieldInfo(dba, nGroupId); 
                        CStruct xGroupPermissions = new CStruct();
                        xGroupPermissions.Initialize("groupPermissions");
                        xGroupPermissions.CreateIntAttr("groupid", nGroupId);
                        xGroupPermissions.CreateStringAttr("name", sName);
                        xGroupPermissions.CreateStringAttr("notes", sNotes);
                        sReply = xGroupPermissions.XML();
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "GroupPermissions.UpdateGroupPermissionsInfo3", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteGroupPermission(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nGroupId = xData.GetIntAttr("groupid");
                try
                {
                    dbaGroups.DeleteGroupPermission(dba, nGroupId, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "GroupPermissions.DeleteGroupPermission", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string GetGroupMembersInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nGroupId = Int32.Parse(xData.InnerText);
                try
                {
                    DataTable dt;

                    if (dbaGroups.SelectGroupMembers(dba, nGroupId, out dt) != StatusEnum.rsSuccess)
                    {
                        sReply = WebAdmin.FormatError("exception", "GroupPermissions.GetGroupMembersInfo1", dba.StatusText);
                    }
                    else
                    {
                        CStruct xGroupMembers = new CStruct();
                        xGroupMembers.Initialize("groupMembers");

                        _DGrid dg = new _DGrid();
                        dg.AddColumn(title: "ID", width: 50, name: "MEMBER_UID", isId: true);
                        dg.AddColumn(title: "Name", width: 180, name: "RES_NAME");

                        dg.SetDataTable(dt);

                        string columnData;
                        string tableData;
                        dg.Build(out columnData, out tableData);
                        xGroupMembers.CreateString("columnData", columnData);
                        xGroupMembers.CreateString("tableData", tableData);

                        sReply = xGroupMembers.XML();
                    }
                        dba.Close();
               }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "GroupPermissions.GetGroupMembersInfo2", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static CStruct BuildGridLayout(DataTable dt)
        {
            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Delete", 0);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("InEditMode", 0);
            //xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Dropping", 0);
            xCfg.CreateIntAttr("ColsMoving", 0);
            xCfg.CreateIntAttr("ColsPostLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            //xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateBooleanAttr("ShowDeleted", false);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            //xCfg.CreateIntAttr("NumberId", 1);
            //xCfg.CreateIntAttr("LastId", 1);
            //xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "TGrid");
            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            xCfg.CreateStringAttr("MainCol", "Permission");

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xHeader = xGrid.CreateSubStruct("Header");
            xHeader.CreateIntAttr("Visible", 1);
            xHeader.CreateIntAttr("SortIcons", 0);

            // Add FieldID column
            CStruct xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "FieldID");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);

            // Add name column
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Permission");
            xHeader.CreateStringAttr("Permission", "");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("MinWidth", 350);

            //Add cb column
            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "CB");
            xHeader.CreateStringAttr("CB", "");
            xC.CreateStringAttr("Type", "Bool");
            //xC.CreateStringAttr("BoolIcon", "6");  ugly X when checked
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("MinWidth", 30);

            CStruct[] xLevels = new CStruct[2];


            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");

            //CStruct xI = xB.CreateSubStruct("I");
            //xI.CreateStringAttr("Permission", "Totals");
            //xI.CreateBooleanAttr("CanEdit", false);
            //xI.CreateStringAttr("Def", "Summary");
            xLevels[0] = xB;

            //List<ComponentWeight> Weights = new List<ComponentWeight>();
            //if (dt_Weights != null)
            //{
            //    foreach (DataRow row in dt_Weights.Rows)
            //    {
            //        ComponentWeight cw = new ComponentWeight();
            //        cw.ScenarioId = DBAccess.ReadIntValue(row["CW_RESULT"]);
            //        cw.ComponentId = DBAccess.ReadIntValue(row["CW_COMPONENT"]);
            //        cw.Weight = DBAccess.ReadDoubleValue(row["CW_RATIO"]);
            //        Weights.Add(cw);
            //    }
            //}

            if (dt != null)
            {
                CStruct xI;
                foreach (DataRow row in dt.Rows)
                {
                    int nPermLevel = DBAccess.ReadIntValue(row["PERM_LEVEL"]);
                    if (nPermLevel > 0)
                    {
                        int nPermUID = DBAccess.ReadIntValue(row["PERM_UID"]);

                        string sPermName = DBAccess.ReadStringValue(row["PERM_NAME"]);

                        CStruct xIParent;
                        if (nPermLevel == 1)
                        {
                            xIParent = xLevels[0];                      // grab the node we are adding a child to
                            xI = xIParent.CreateSubStruct("I");         // add a new child
                            xLevels[1] = xI;                            // save a new parent node at this new level
                            xI.CreateIntAttr("FieldID", nPermUID);      //  carry on and define details for our new node
                            xI.CreateStringAttr("CBType", "Text");        // don't want a cb on title lines
                            xI.CreateBooleanAttr("CanEdit", false);
                            //xI.CreateStringAttr("CB", "");
                        }
                        else
                        {
                            xIParent = xLevels[1];
                            xI = xIParent.CreateSubStruct("I");
                            xI.CreateIntAttr("FieldID", nPermUID);
                            xI.CreateBooleanAttr("CanEdit", true);
                            int nJoinedGroup = DBAccess.ReadIntValue(row["GROUP_ID"]);
                            bool bPermSet;
                            if (nJoinedGroup > 0) bPermSet = true; else bPermSet = false;
                            xI.CreateBooleanAttr("CB", bPermSet);
                        }
                        xI.CreateStringAttr("Permission", sPermName);

                        xI.CreateStringAttr("Color", "254,254,254");
                        xI.CreateIntAttr("NoColorState", 1);
                    }
                }
            }
            return xGrid;
        }

        #endregion
    }

    //#region Nested type: PublicAPI

    //public class PublicAPI : Attribute
    //{
    //    // positional parameters
    //    public PublicAPI(bool isPublic)
    //    {
    //        IsPublic = isPublic;
    //    }

    //    // property for named parameter
    //    public bool IsPublic { get; set; }
    //}

    //#endregion
}
