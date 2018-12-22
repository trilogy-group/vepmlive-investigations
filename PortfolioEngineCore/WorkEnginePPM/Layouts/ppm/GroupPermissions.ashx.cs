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
                                    string sTreegridData = GroupPermissionsGridHelper.BuildGridLayout(dt).XML();
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
    }
}
