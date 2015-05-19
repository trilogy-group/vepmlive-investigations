<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EPMLive.ChangePassword" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <script type="text/javascript">
        var oldPWClientId = '<%=oldpassword.ClientID%>';
        var newPWClientId = '<%=newpassword.ClientID%>';
        var checknewPWClientId = '<%=checknewpassword.ClientID%>';
        var ignorepwd = false;

        window.onload = function () {
            tboldpw = document.getElementById(oldPWClientId);
            tbnewpw = document.getElementById(newPWClientId);
            tbchecknewpw = document.getElementById(checknewPWClientId);

            tboldpw.value = '';

            tboldpw.onkeyup = function () { checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 3); };
            tboldpw.onclick = function () { checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 3); };

            tbnewpw.onblur = function () { hideHelp(); };
            tbnewpw.onkeyup = function () { checkPWD(tbnewpw.value); checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 1); };
            tbnewpw.onclick = function () { checkPWD(tbnewpw.value); checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 1); };

            tbchecknewpw.onkeyup = function () { checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 2); };
            tbchecknewpw.onclick = function () { checkMatchPWD(tbchecknewpw.value, tbnewpw.value, 2); };

            tboldpw.focus();
        }
    </script>
    <script language="javascript" type="text/javascript">
        var isValidPWD = false;
        var isValidMatch = false;

        function PerformResize() {
            ht = (document.body.scrollHeight + 32) + 'px';
            wt = (document.body.scrollWidth + 16) + 'px';
            window.dialogHeight = ht;
            window.dialogWidth = wt;
        }

        function hasLowerCase(str) {
            return (/[a-z]/.test(str));
        }

        function hasUpperCase(str) {
            return (/[A-Z]/.test(str));
        }

        function hasNumber(str) {
            return (/[0-9]/.test(str));
        }

        function hasSpecials(str) {
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?~_";
            for (var i = 0; i < str.length; i++) {
                if (iChars.indexOf(str.charAt(i)) != -1) {
                    return ("true");
                }
            }
        }


        function checkMatchPWD(pwd2, pwd1, id) {
            //id 2 comes from Match box
            //id 1 comes from 1st Pwd box
            if (id == 2) {
                if (pwd2 != '') {
                    document.getElementById('Match').style.visibility = "visible";
                }
                else {
                    document.getElementById('Match').style.visibility = "hidden";
                }
            }

            if (pwd2 != '') {
                if (pwd2 == pwd1) {
                    document.getElementById('Match').innerHTML = "<img src='../images/green.gif'></img>";
                    isValidMatch = true;
                }
                else {
                    document.getElementById('Match').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                }

            }
            else {
                if (id == 2) {
                    document.getElementById('Match').style.visibility = "visible";
                    document.getElementById('Match').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                }
                else {
                    document.getElementById('Match').style.visibility = "hidden";
                }
            }
        }


        function getElementPosition(elemID) {
            var offsetTrail = document.getElementById(elemID);
            var offsetLeft = 0;
            var offsetTop = 0;
            while (offsetTrail) {
                offsetLeft += offsetTrail.offsetLeft;
                offsetTop += offsetTrail.offsetTop;
                offsetTrail = offsetTrail.offsetParent;
            }
            return { left: offsetLeft, top: offsetTop };
        }

        function flipNoteVisibility() {
            if (document.getElementById("Checker").style.visibility === "visible") {
                document.getElementById("Note").style.visibility = "hidden";
            }
            else {
                document.getElementById("Note").style.visibility = "visible";
            }
        }

        function checkPWD(pwd) {
            var PWDHeight = getElementPosition('pwdtd').top - 4;
            var PWDLeft = getElementPosition('pwdtd').left + 300;

            document.getElementById("checkerTD").style.top = PWDHeight + 'px';
            document.getElementById("checkerTD").style.left = PWDLeft + 'px';
            //document.getElementById("checkerTD").style.position = 'absolute';
            document.getElementById("Checker").style.visibility = "visible";
            flipNoteVisibility();

            if (pwd.length == 0) {
                document.getElementById('Length').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                document.getElementById('Upper').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                document.getElementById('Lower').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                document.getElementById('Number').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                document.getElementById('Overall').innerHTML = "<img src='../images/green.gif' style='visibility:hidden'></img>";
                document.getElementById('Match').innerHTML = "<img src='../images/green.gif' style='visibility:hidden'></img>";
                document.getElementById('Chars').innerHTML = "<img src='../images/green.gif' class='opacity30'></img>";
                return;
            }

            var pwdlen = pwd.length;
            var counter = 0;
            var lengrade = false;
            var greenhtml = "<img src='../images/green.gif' class=''></img>";
            var disabled = "<img src='../images/green.gif' class='opacity30'></img>";

            if (pwdlen < 7 || pwdlen > 16) {
                document.getElementById('Length').innerHTML = disabled;
            }
            else {
                document.getElementById('Length').innerHTML = greenhtml;
                lengrade = true;
            }

            if (hasLowerCase(pwd)) {
                document.getElementById('Lower').innerHTML = greenhtml;
                counter = counter + 1;
            }
            else {
                document.getElementById('Lower').innerHTML = disabled;
            }

            if (hasUpperCase(pwd)) {
                document.getElementById('Upper').innerHTML = greenhtml;
                counter = counter + 1;
            }
            else {
                document.getElementById('Upper').innerHTML = disabled;
            }

            if (hasNumber(pwd)) {
                document.getElementById('Number').innerHTML = greenhtml;
                counter = counter + 1;
            }
            else {
                document.getElementById('Number').innerHTML = disabled;
            }
            if (hasSpecials(pwd)) {
                document.getElementById('Chars').innerHTML = greenhtml;
                counter = counter + 1;
            }
            else {
                document.getElementById('Chars').innerHTML = disabled;
            }

            if (counter > 2) {
                if (lengrade == true) {
                    document.getElementById("Overall").innerHTML = "<img src='../images/green.gif' style='visibility:visible'></img>";
                    document.getElementById("Checker").style.visibility = 'hidden';
                    flipNoteVisibility();
                    isValidPWD = true;
                }
                else {
                    document.getElementById('Overall').innerHTML = "<img src='../images/green.gif' style='visibility:hidden'></img>";
                }
            }
            else {
                document.getElementById('Overall').innerHTML = "<img src='../images/green.gif' style='visibility:hidden'></img>";
            }
        }

        function hideHelp() {
            document.getElementById("Checker").style.visibility = 'hidden';
            flipNoteVisibility();
        }

        function showdlg() {
            if (ignorepwd)
                return true;

            if (isValidPWD) {
                if (isValidMatch) {
                    return true;
                }
                else {
                    alert("Passwords do not match.");
                    return false;
                }
            }
            else {
                alert("Password does not meet complexity requirements.");
                return false;
            }
        }
    </script>
    <style type="text/css">
        
     input{ outline:none;}
        
    .opacity30 
    {
        filter:alpha(opacity=30);
        -moz-opacity:0.3;
        -khtml-opacity: 0.3;
        opacity: 0.3;
    }

    .tableBorder
    {
        background-image: url(./images/shadow.png);
        padding: 25px 35px 20px 30px;
        overflow: visible;
    }

    .callout 
    {
        position: relative;
        margin: 5px 0;
        padding: 18px 20px;
        background-color: #eef4f9;
        /* easy rounded corners for modern browsers */
        -moz-border-radius: 6px;
        -webkit-border-radius: 6px;
        border-radius: 6px;
        top: 0px;
    }
    
    .callout .notch 
    {
        position: absolute;
        top: 55px;
        left: -10px;
        margin: 0;
        border-left: 0;
        border-bottom: 10px solid transparent;
        border-top: 10px solid transparent;
        border-right: 10px solid #eef4f9;
        padding: 0;
        width: 0;
        height: 0;
        /* ie6 height fix */
        font-size: 0;
        line-height: 0;
         /* ie6 transparent fix */
        _border-right-color: pink;
        _border-left-color: pink;
        _filter: chroma(color=pink);
    }

    .border-callout 
    { 
        border: 1px solid #c5d9e8; 
        padding: 17px 19px; 
    }

    .border-callout .border-notch 
    {
        border-right: 10px solid #c5d9e8; 
        top: 55px; 
        left:-11px;
    }

    @-moz-document url-prefix() 
    {
        .border-notch
	    {
		    visibility:hidden;	
	    }
    }
        
    .signupbutton
    {
        width: 100px;
        height: 20px;
    }
    .errortable
    {
        border: 2px solid #550000;
        background-color: #C99E9E;
        width: 600px;
        height: 30px;
    }

	.textbox
	{
    	background: none repeat scroll 0 0 #F0F0F0;
    	border: 1px solid #C7C7C7;
    	border-radius: 5px 5px 5px 5px;
    	color: #333333;
    	font-size: 16px;
    	padding: 13px 10px 9px;
    	width: 380px;
	}

     .txtLabel
	{
    	color: #424242;
    	display: block;
    	float: left;
    	font-size: 14px;
    	padding-top: 13px;
    	text-shadow: 1px 1px 0 rgba(255, 255, 255, 0.5);
    	width: 150px;
	}

    .input-text:focus
    {
        border-color: #55A4F2;
        box-shadow: 0 0 8px #55A4F2;
    }

    .regularText
	{
    	color: #424242;
    	display: block;
    	float: left;
    	font-size: 14px;
    	font-weight: bold;
    	padding-top: 13px;
    	text-shadow: 1px 1px 0 rgba(255, 255, 255, 0.5);    		
	}

	.txtLabelHeader
	{
    	color: #424242;
    	font-size: 20px;
    	font-weight: bold;
    	padding-top: 5px;
    	text-shadow: 1px 1px 0 rgba(255, 255, 255, 0.5);
    	width: 150px;
	}

    .txtLabelSpanEmail
	{
        color: #424242;
        font-size: 14px;
        padding-top: 10px;
        padding-bottom: 10px;
        padding-left: 10px;
        padding-right: 10px;
        text-shadow: 1px 1px 0 rgba(255, 255, 255, 0.5);
        width: 150px;
        background-color:#FFFFCC;
        border: 1px solid #CCCCCC;
        line-height:1.5;
	}
     
    .txtLabelSpan
	{
    	color: #424242;
    	font-size: 14px;
    	padding-top: 5px;
    	text-shadow: 1px 1px 0 rgba(255, 255, 255, 0.5);
    	width: 150px;
		font-weight: bold;
	}

    /*body 
    {
        background: url("images/bg-top-tile.gif") repeat-x scroll 0 0 #D0D9E0;
        color: #FFFFFF;
        font: 12px sans-serif;
    }*/


    #page-heading 
    {
        background: url(images/bg-page-title.jpg) no-repeat top center;
        height: 173px;
    }



    /*mainTable
    {
        font-size:14px;
        width:100%;
        text-align:left;
        border-collapse:collapse;
        margin:15px 0 20px;
    }*/

    /*tableHeader th
    {
        font-size:12px;
        font-weight:400;
        background:#e9e9e9;
        color:#555;
        padding:8px 10px;
        text-align:center; 
        border:1px solid #d4d4d4;
    }*/

    tableColumns
    {
        background:#fcfcfc;
        color:#333;
        padding:9px; 
        border:1px solid #d4d4d4;
    }

    input.text, input.input-text, input.password, textarea, textarea.input-textarea, iframe.editor 
    {
        background: -moz-linear-gradient(center top , #E6E6E6, #FFFFFF) repeat-x scroll center top #FFFFFF;
        border: 1px solid #CCCCCC;
        border-radius: 3px 3px 3px 3px;
        font-size: 13px;
        height: 16px;
        margin: 0;
        padding: 6px 5px;
        vertical-align: top;
    }

    input, textarea {
        font-family: Helvetica,Arial,sans-serif;
    }


    .button-neutral {
        background: none repeat scroll 0 0 #55A4F2;
    }
    
    .btnSubmit {
        
        float: left;
    }
    
    .btnCancel {
        
        float:right;
    }

    .button-positive, .button-neutral, .button-negative {
        border: 0 none;
        border-radius: 6px 6px 6px 6px;
        color: #FFFFFF;
        display: block;
        font-size: 13px;
        font-weight: bold;
        line-height: 16px;
        padding: 10px 20px;
        text-align: center;
        text-transform: uppercase;
    }

    .button-positive:hover {
        background: none repeat scroll 0 0 #537A26;
    }

    .button-neutral:hover {
        background: none repeat scroll 0 0 #1071D1;
    }

    </style>
    <table border="0">
        <tr>
            <td>
                <table border="0">
                    <tr>
                        <td class="txtLabel" align="left">
                            Current Password:
                        </td>
                        <td style="padding: 8px" valign="top" id="Td1">
                            <asp:TextBox ID="oldpassword" runat="server" CssClass="input-text text" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <div id="Div1">
                                <img src='../images/green.gif' style="visibility: hidden" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="txtLabel" align="left">
                            Password:
                        </td>
                        <td style="padding: 8px" valign="top" id="pwdtd">
                            <asp:TextBox ID="newpassword" runat="server" CssClass="input-text text" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <div id="Overall">
                                <img src='../images/green.gif' style="visibility: hidden" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="txtLabel" align="left">
                            Confirm Password:
                        </td>
                        <td style="padding: 8px">
                            <asp:TextBox ID="checknewpassword" runat="server" CssClass="input-text text" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <div id="Match">
                                <img src='../images/green.gif' style="visibility: hidden" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="height: 25px;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Button ID="btn_ChangePassword" runat="server" CssClass="ms-ButtonHeightWidth"
                                Text="Change Password" UseSubmitBehavior="true" Visible="True" OnClientClick="return showdlg()" />
                            <asp:Button ID="btn_Cancel" runat="server" CssClass="ms-ButtonHeightWidth" Text="Cancel"
                                UseSubmitBehavior="false" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
            <td id="checkerTD">
                <table border="0">
                    <tr>
                        <td valign="top">
                            <div id="Checker" style="visibility: hidden;" class="callout border-callout" valign="top">
                                <table cellpadding="0" cellspacing="5">
                                    <tr>
                                        <td style="font-size: 12px; font-family: Arial; color: #333333;" align="left">
                                            Length: (must be between 7 and 16 characters)
                                        </td>
                                        <td>
                                            <div id="Length">
                                                <img src='../images/green.gif' class='opacity30' /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 12px; font-family: Arial; color: #333333;" align="left">
                                            Uppercase: (at least 1 uppercase)
                                        </td>
                                        <td>
                                            <div id="Upper">
                                                <img src='../images/green.gif' class='opacity30' /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 12px; font-family: Arial; color: #333333;" align="left">
                                            Lowercase: (at least 1 lowercase)
                                        </td>
                                        <td>
                                            <div id="Lower">
                                                <img src='../images/green.gif' class='opacity30' /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 12px; font-family: Arial; color: #333333;" align="left">
                                            Number: (at least 1 number)
                                        </td>
                                        <td>
                                            <div id="Number">
                                                <img src='../images/green.gif' class='opacity30' /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 12px; font-family: Arial; color: #333333;" align="left">
                                            Special Character: (at least 1 special character)
                                        </td>
                                        <td>
                                            <div id="Chars">
                                                <img src='../images/green.gif' class='opacity30' /></div>
                                        </td>
                                    </tr>
                                    <div class="border-notch notch">
                                    </div>
                                    <div class="notch">
                                    </div>
                                </table>
                            </div>
                            <div id="Note" style="border: 1px solid #C7C7C7; float: left; margin-left: 20px;
                                margin-top: -185px; padding: 12px; visibility: visible; width: 240px; 
                                border-radius:5px; color: rgb(102, 102, 102); line-height:17px;">
                                Once you click the Change Password button and this box closes, a message will be
                                displayed indicating the result of your password change. Assuming your password
                                was successfully set, you may want to log out and then back in using your new password.
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Change My Password
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <div style="margin-bottom: 10px">
        Change My Password
    </div>
</asp:Content>
