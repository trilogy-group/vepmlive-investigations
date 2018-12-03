using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;
using WorkEnginePPM.Layouts.ppm;

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
            var grid = InitializeGrid();
            AddToolBar(grid);
            AddPanel(grid);
            AddConfig(grid);
            AddDefinition(grid);
            CStruct cols;
            CStruct header;
            var leftCols = AddColumns(grid, out cols, out header);
            AddFieldIDColumn(leftCols);
            AddNameColumn(leftCols, header);
            var levels = AddCbColumn(cols, header, grid);

            if (dt != null)
            {
                XmlHelper.FillFieldsXml(dt, levels);
            }
            return grid;
        }

        private static CStruct[] AddCbColumn(CStruct cols, CStruct header, CStruct grid)
        {
            var xC = cols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "CB");
            header.CreateStringAttr("CB", "");
            xC.CreateStringAttr("Type", "Bool");

            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("MinWidth", 30);

            var levels = new CStruct[2];

            var body = grid.CreateSubStruct("Body");
            var xB = body.CreateSubStruct("B");
            levels[0] = xB;
            return levels;
        }

        private static void AddNameColumn(CStruct leftCols, CStruct header)
        {
            var xC = leftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Permission");
            header.CreateStringAttr("Permission", "");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("MinWidth", 350);
        }

        private static void AddFieldIDColumn(CStruct leftCols)
        {
            var xC = leftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "FieldID");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
        }

        private static CStruct AddColumns(CStruct grid, out CStruct cols, out CStruct header)
        {
            var leftCols = grid.CreateSubStruct("LeftCols");
            cols = grid.CreateSubStruct("Cols");
            header = grid.CreateSubStruct("Header");
            header.CreateIntAttr("Visible", 1);
            header.CreateIntAttr("SortIcons", 0);
            return leftCols;
        }

        private static void AddDefinition(CStruct grid)
        {
            var definition = grid.CreateSubStruct("Def");
            var xD = definition.CreateSubStruct("D");
            xD.CreateStringAttr("Name", "R");
            xD.CreateStringAttr("HoverCell", "Color");
            xD.CreateStringAttr("HoverRow", "Color");
            xD.CreateStringAttr("FocusCell", "");
            xD.CreateStringAttr("FocusRow", "Color");
        }

        private static void AddConfig(CStruct grid)
        {
            var config = grid.CreateSubStruct("Cfg");
            config.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            config.CreateIntAttr("SuppressCfg", 1);
            config.CreateIntAttr("InEditMode", 0);

            config.CreateIntAttr("Dragging", 0);
            config.CreateIntAttr("Dropping", 0);
            config.CreateIntAttr("ColsMoving", 0);
            config.CreateIntAttr("ColsPostLap", 1);
            config.CreateIntAttr("ColsLap", 1);
            config.CreateBooleanAttr("ShowDeleted", false);
            config.CreateBooleanAttr("DateStrings", true);

            config.CreateIntAttr("ConstWidth", 2);

            config.CreateIntAttr("MaxWidth", 1);
            config.CreateIntAttr("AppendId", 0);
            config.CreateIntAttr("FullId", 0);
            config.CreateStringAttr("IdChars", "0123456789");

            config.CreateIntAttr("SelectingCells", 1);
            config.CreateStringAttr("Style", "GM");
            config.CreateStringAttr("CSS", "TGrid");
            config.CreateIntAttr("Sorting", 0);
            config.CreateIntAttr("FastColumns", 1);
            config.CreateIntAttr("StaticCursor", 1);
            config.CreateIntAttr("FocusWholeRow", 1);
            config.CreateBooleanAttr("NoTreeLines", true);

            config.CreateStringAttr("MainCol", "Permission");
        }

        private static void AddPanel(CStruct grid)
        {
            var panel = grid.CreateSubStruct("Panel");
            panel.CreateIntAttr("Visible", 0);
            panel.CreateIntAttr("Delete", 0);
        }

        private static void AddToolBar(CStruct grid)
        {
            var toolbar = grid.CreateSubStruct("Toolbar");
            toolbar.CreateIntAttr("Visible", 0);
        }

        private static CStruct InitializeGrid()
        {
            var grid = new CStruct();
            grid.Initialize("Grid");
            return grid;
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
