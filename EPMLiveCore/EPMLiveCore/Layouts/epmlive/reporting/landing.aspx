<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landing.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.reportslanding" DynamicMasterPageFile="~masterurl/default.master" %>


    text-align:left;
    margin:0px;
}


.skyblue {
    background-color:#4DAD7F;
    border:2px solid #43966E;
    color:#2D5441 !important;
    font-weight:600;
border-radius: 5px 5px 5px 5px;
}

.skyblue: hover {
    opacity:.8;
}

.skyblue h2 {

    color:#2D5441 !important;

}

.orange-crush {
    background-color:#3AA8F2;
    border:2px solid #2E86C1;
    color:#1F5C84 !important;
    font-weight:600;
    text-decoration:none !important;
border-radius: 5px 5px 5px 5px;
}

.orange-crush a {
    
    color:#1F5C84 !important;
    
    text-decoration:none !important;
}

.orange-crush h2 {

    color:#1F5C84 !important;

}

.bi-chart {
    font-size: 100px;
    margin-right: 50px;
    margin-top: -11px;
}


#advanced:hover {
opacity:.9;
}

#classic:hover {
opacity:.9;
}


</style>


</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">


<div id="bi-wrapper">
    <div>
        <h1>Business Intelligence Center</h1>
    </div>
    <div id="bi-desc">
        <p>Welcome to the BI Center.  You can use this page to access various reports throughout the system.  Click on one of the boxes below to add, edit, or view reports.</p>
    </div>
    <div id="bi-main">
        <ul>
            <a href="./reporting.aspx" id="advanced"><li class="skyblue">
		<div style="float:left;">
                <h2>Advanced Reporting</h2>
                <p>Access advanced reporting.</p>
		</div>
		<div style="float:right;" class="bi-chart">
		<span class="icon-pie-5"></span>
		</div>
            </li></a>
            <a href="../../../sitepages/report.aspx" id="classic"><li class="orange-crush">
		<div style="float:left;">
                <h2>Classic Reporting</h2>
                <p>Access classic reporting.</p>
		</div>
		<div style="float:right;" class="bi-chart">
		<span class="icon-chart"></span>
		</div>
            </li></a>
        </ul>
    </div>
</div>



</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Reporting
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Reporting
</asp:Content>
