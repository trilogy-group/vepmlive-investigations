<%@ Page Language="C#" ContentType="application/vnd.ms-excel" %>

<% Response.AppendHeader("Content-Disposition","attachment; filename=\"PlannerExcelExport.xls\"");

   Response.AppendHeader("Cache-Control","max-age=1, must-revalidate");

   Response.Write(HttpUtility.HtmlDecode(Request["Data"])); %>

