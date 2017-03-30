<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editpersonal.aspx.cs" Inherits="EPMLiveAccountManagement.Layouts.epmlive.editpersonal" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<SCRIPT language="javascript">

    function close() {
        alert('Your information has been updated');
        parent.location.href = parent.location.href;
    }

    function elementchange() {

        var EnableSubmitButton = true;
        var submitbutton = document.getElementById("submitbutton");

        //var countrytitle = document.getElementById("countrytitle");
        var othercountrytitle = document.getElementById("othercountrytitle");
        var othercountry = document.getElementById("othercountry");
        //var statetitle = document.getElementById("statetitle");
        var RegionSelect = document.getElementById("<%=xregion.ClientID %>");
        var StateSelect = document.getElementById("xstate");
        var StateSelectSelect = document.getElementById("Select1");
        var CountrySelect = document.getElementById("countryselect");
        var xcountry = document.getElementById("xcountry");
        var MSCountry = document.getElementById("mscountry");
        var hdnCountry = document.getElementById("<%=hdnCountry.ClientID %>");
        var hdnState = document.getElementById("<%=hdnState.ClientID %>");



        if (RegionSelect.value == "USA")  //this is US
        {

            xcountry.style.display = "none";
            StateSelect.style.display = "";

            MSCountry.value = "USA";
            othercountry.value = "";
            CountrySelect.value = "";
            if (hdnState.value != "") {
                for (var i = 0; i < StateSelectSelect.options.length; i++) {
                    if (StateSelectSelect.options[i].value == hdnState.value) {
                        StateSelectSelect.options[i].selected = true;
                    }
                }
                hdnState.value = "";
            }

        } else {

            xcountry.style.display = "";
            StateSelectSelect.value = "";
            StateSelect.style.display = "none";

            rcsplit = CountrySelect.value.split("|");

            if (rcsplit[0] != RegionSelect.value) {
                othercountry.value = "";

                CountrySelect.options[0] = new Option("Please select", "");

                CountrySelect.options[1] = new Option("Australia", "AUS|Australia");

                CountrySelect.options[2] = new Option("Austria", "EURAT|Austria");

                CountrySelect.options[3] = new Option("Bangladesh", "Asia|Bangladesh");

                CountrySelect.options[4] = new Option("Belgium", "EURZZ|Belgium");

                CountrySelect.options[5] = new Option("Brazil", "LAT|Brazil");

                CountrySelect.options[6] = new Option("Bulgaria", "EURZZ|Bulgaria");

                CountrySelect.options[7] = new Option("Cameroon", "AFR|Cameroon");

                CountrySelect.options[8] = new Option("Canada", "CAN|Canada");

                CountrySelect.options[9] = new Option("Chile", "LAT|Chile");

                CountrySelect.options[10] = new Option("China", "Asia|China");

                CountrySelect.options[11] = new Option("Croatia", "EURZZ|Croatia");

                CountrySelect.options[12] = new Option("Czech Republic", "EURZZ|Czech Republic");

                CountrySelect.options[13] = new Option("Denmark", "EURZZ|Denmark");

                CountrySelect.options[14] = new Option("Dominican Republic", "LAT|Dominican Republic");

                CountrySelect.options[15] = new Option("Ecuador", "LAT|Ecuador");

                CountrySelect.options[16] = new Option("Egypt", "AFR|Egypt");

                CountrySelect.options[17] = new Option("Estonia", "EURZZ|Estonia");

                CountrySelect.options[18] = new Option("Finland", "EURZZ|Finland");

                CountrySelect.options[19] = new Option("France", "EURFR|France");

                CountrySelect.options[20] = new Option("Germany", "EURDE|Germany");

                CountrySelect.options[21] = new Option("Greece", "EURZZ|Greece");

                CountrySelect.options[22] = new Option("Guatemala", "LAT|Guatemala");

                CountrySelect.options[23] = new Option("Hong Kong", "Asia|Hong Kong");

                CountrySelect.options[24] = new Option("Hungary", "EURZZ|Hungary");

                CountrySelect.options[25] = new Option("Iceland", "EURZZ|Iceland");

                CountrySelect.options[26] = new Option("India", "Asia|India");

                CountrySelect.options[27] = new Option("Indonesia", "Asia|Indonesia");

                CountrySelect.options[28] = new Option("Ireland", "EURZZ|Ireland");

                CountrySelect.options[29] = new Option("Israel", "AFR|Israel");

                CountrySelect.options[30] = new Option("Italy", "EURIT|Italy");

                CountrySelect.options[31] = new Option("Japan", "Asia|Japan");

                CountrySelect.options[32] = new Option("Kazakhstan", "AFR|Kazakhstan");

                CountrySelect.options[33] = new Option("Korea", "Asia|Korea");

                CountrySelect.options[34] = new Option("Latvia", "EURZZ|Latvia");

                CountrySelect.options[35] = new Option("Lithuania", "EURZZ|Lithuania");

                CountrySelect.options[36] = new Option("Madagascar", "AFR|Madagascar");

                CountrySelect.options[37] = new Option("Malaysia", "Asia|Malaysia");

                CountrySelect.options[38] = new Option("Mexico", "LAT|Mexico");

                CountrySelect.options[39] = new Option("Netherlands", "EURNL|Netherlands");

                CountrySelect.options[40] = new Option("New Caledonia", "AFR|New Caledonia");

                CountrySelect.options[41] = new Option("New Zealand", "AUS|New Zealand");

                CountrySelect.options[42] = new Option("Norway", "EURZZ|Norway");

                CountrySelect.options[43] = new Option("Pakistan", "AFR|Pakistan");

                CountrySelect.options[44] = new Option("Peru", "LAT|Peru");

                CountrySelect.options[45] = new Option("Philippines", "Asia|Philippines");

                CountrySelect.options[46] = new Option("Poland", "EURZZ|Poland");

                CountrySelect.options[47] = new Option("Portugal", "EURZZ|Portugal");

                CountrySelect.options[48] = new Option("Puerto Rico", "LAT|Puerto Rico");

                CountrySelect.options[49] = new Option("Romania", "EURZZ|Romania");

                CountrySelect.options[50] = new Option("Russia", "EURZZ|Russia");

                CountrySelect.options[51] = new Option("Saudi Arabia", "AFR|Saudi Arabia");

                CountrySelect.options[52] = new Option("Singapore", "Asia|Singapore");

                CountrySelect.options[53] = new Option("Slovakia", "EURZZ|Slovakia");

                CountrySelect.options[54] = new Option("South Africa", "AFR|South Africa");

                CountrySelect.options[55] = new Option("Spain", "EURZZ|Spain");

                CountrySelect.options[56] = new Option("Sweden", "EURZZ|Sweden");

                CountrySelect.options[57] = new Option("Switzerland", "EURCH|Switzerland");

                CountrySelect.options[58] = new Option("Taiwan", "Asia|Taiwan");

                CountrySelect.options[59] = new Option("Thailand", "Asia|Thailand");

                CountrySelect.options[60] = new Option("Turkey", "EURZZ|Turkey");

                CountrySelect.options[61] = new Option("UAE", "AFR|UAE");

                CountrySelect.options[62] = new Option("UK", "EURUK|UK");

                CountrySelect.options[63] = new Option("Ukraine", "EURZZ|Ukraine");

                CountrySelect.options[64] = new Option("Uruguay", "LAT|Uruguay");

                CountrySelect.options[65] = new Option("USA", "USA|USA");

                CountrySelect.options[66] = new Option("Venezuela", "LAT|Venezuela");

                CountrySelect.options[67] = new Option("Vietnam", "Asia|Vietnam");

                CountrySelect.options[68] = new Option("Other", RegionSelect.value + "|Other");

                for (var i = 0; i < CountrySelect.length; i++) {
                    rcsplit = CountrySelect.options[i].value.split("|");

                    if (rcsplit[0] != RegionSelect.value && rcsplit[0] != "Other" && rcsplit[0] != "") {
                        CountrySelect.options[i] = null;

                        i = i - 1;
                    }

                    if (rcsplit[0] == RegionSelect.value && rcsplit[1] == hdnCountry.value) {
                        CountrySelect.options[i].selected = true;
                    }
                }



                if (CountrySelect.length == 3) {  //if just one country in the list get rid of "please select" and "other"
                    //CountrySelect.style.display="none";
                    xcountry.style.display = "none";
                    //			countrytitle.style.display = "none";
                    CountrySelect.options[2] = null;
                    CountrySelect.options[0] = null;

                    rcsplit = CountrySelect.options[0].value.split("|");
                    MSCountry.value = rcsplit[1];

                }
            }
            rcsplit = CountrySelect.value.split("|");
            if (rcsplit[0] == "noselection") {
                MSCountry.value = "";
                othercountry.value = "";
            } else {
                MSCountry.value = rcsplit[1];
            }



            if (MSCountry.value == "Other") {
                othercountrytitle.style.display = "";
                othercountry.style.display = "";

                if (othercountry.value == "") { EnableSubmitButton = false; }
            } else {
                othercountry.value = "";
                othercountrytitle.style.display = "none";
                othercountry.style.display = "none";
            }

        }


    }
</SCRIPT>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    

    <input type=hidden Name="MSCountry" id=mscountry >
    <asp:HiddenField ID="hdnCountry" runat="server" />
    <asp:HiddenField ID="hdnState" runat="server" />
    <div>
        <div class="ms-listdescription">
    	 <table class="ms-descriptiontext" cellspacing="0" border="0">
		<tr>
			<td colspan="2" width="100%">
				<span id="ctl00_PlaceHolderMain_LabelGroupDescription"><asp:Label ID="lblUserSearch" Text="Use this page to manage your basic contact information" runat="server"></asp:Label></span>
			</td>
		</tr>
		
	 </table>
	 </div>
	 <br />
	 <table border="0" cellpadding="10">
	    <tr>
	        <td>
	             <table border="0" cellpadding="1" cellspacing="0">
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>First Name:</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Last Name:</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtLastName" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Address1</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Address2</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>City</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtCity" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Region</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:DropDownList ID="xregion" name="Region" onchange="javascript:elementchange();" class="input text" runat="server">
                                <asp:ListItem Value="USA" Text="United States"></asp:ListItem>
                                <asp:ListItem Value="CAN" Text="Canada"></asp:ListItem>
                                <asp:ListItem Value="LAT" Text="Latin America"></asp:ListItem>
                                <asp:ListItem Value="AFR" Text="Africa/Middle East"></asp:ListItem>
                                <asp:ListItem Value="Asia" Text="Asia"></asp:ListItem>
                                <asp:ListItem Value="AUS" Text="Australia"></asp:ListItem>
                                <asp:ListItem Value="EURAT" Text="Austria"></asp:ListItem>
                                <asp:ListItem Value="EURCH" Text="Switzerland"></asp:ListItem>
                                <asp:ListItem Value="EURDE" Text="Germany"></asp:ListItem>
                                <asp:ListItem Value="EURFR" Text="France"></asp:ListItem>
                                <asp:ListItem Value="EURIT" Text="Italy"></asp:ListItem>
                                <asp:ListItem Value="EURNL" Text="Netherlands"></asp:ListItem>
                                <asp:ListItem Value="EURUK" Text="United Kingdom"></asp:ListItem>
                                <asp:ListItem Value="EURZZ" Text="Other Europe"></asp:ListItem>
                            </asp:DropDownList>
	                    </td>
	                </tr>
	                <TR id="xstate">
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>State</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <select title="State" name="State" id="Select1"  onchange="javascript:elementchange();" class="input text">
                                <option value="" selected="selected">Please select</option>
                                <option value="AK" <%if(strState == "AK"){%>selected<%}%>>Alaska</option>
                                <option value="AL" <%if(strState == "AL"){%>selected<%}%>>Alabama</option>
                                <option value="AR" <%if(strState == "AR"){%>selected<%}%>>Arkansas</option>
                                <option value="AZ" <%if(strState == "AZ"){%>selected<%}%>>Arizona</option>
                                <option value="CA" <%if(strState == "CA"){%>selected<%}%>>California</option>
                                <option value="CO" <%if(strState == "CO"){%>selected<%}%>>Colorado</option>
                                <option value="CT" <%if(strState == "CT"){%>selected<%}%>>Connecticut</option>
                                <option value="DC" <%if(strState == "DC"){%>selected<%}%>>District of Columbia</option>
                                <option value="DE" <%if(strState == "DE"){%>selected<%}%>>Delaware</option>
                                <option value="FL" <%if(strState == "FL"){%>selected<%}%>>Florida</option>
                                <option value="GA" <%if(strState == "GA"){%>selected<%}%>>Georgia</option>
                                <option value="HI" <%if(strState == "HI"){%>selected<%}%>>Hawaii</option>
                                <option value="IA" <%if(strState == "IA"){%>selected<%}%>>Iowa</option>
                                <option value="ID" <%if(strState == "ID"){%>selected<%}%>>Idaho</option>
                                <option value="IL" <%if(strState == "IL"){%>selected<%}%>>Illinois</option>
                                <option value="IN" <%if(strState == "IN"){%>selected<%}%>>Indiana</option>
                                <option value="KS" <%if(strState == "KS"){%>selected<%}%>>Kansas</option>
                                <option value="KY" <%if(strState == "KY"){%>selected<%}%>>Kentucky</option>
                                <option value="LA" <%if(strState == "LA"){%>selected<%}%>>Louisiana</option>
                                <option value="MA" <%if(strState == "MA"){%>selected<%}%>>Massachusetts</option>
                                <option value="MD" <%if(strState == "MD"){%>selected<%}%>>Maryland</option>
                                <option value="ME" <%if(strState == "ME"){%>selected<%}%>>Maine</option>
                                <option value="MI" <%if(strState == "MI"){%>selected<%}%>>Michigan</option>
                                <option value="MN" <%if(strState == "MN"){%>selected<%}%>>Minnesota</option>
                                <option value="MO" <%if(strState == "MO"){%>selected<%}%>>Missouri</option>
                                <option value="MS" <%if(strState == "MS"){%>selected<%}%>>Mississippi</option>
                                <option value="MT" <%if(strState == "MT"){%>selected<%}%>>Montana</option>
                                <option value="NC" <%if(strState == "NC"){%>selected<%}%>>North Carolina</option>
                                <option value="ND" <%if(strState == "ND"){%>selected<%}%>>North Dakota</option>
                                <option value="NE" <%if(strState == "NE"){%>selected<%}%>>Nebraska</option>
                                <option value="NH" <%if(strState == "NH"){%>selected<%}%>>New Hampshire</option>
                                <option value="NJ" <%if(strState == "NJ"){%>selected<%}%>>New Jersey</option>
                                <option value="NM" <%if(strState == "NM"){%>selected<%}%>>New Mexico</option>
                                <option value="NV" <%if(strState == "NV"){%>selected<%}%>>Nevada</option>
                                <option value="NY" <%if(strState == "NY"){%>selected<%}%>>New York</option>
                                <option value="OH" <%if(strState == "OH"){%>selected<%}%>>Ohio</option>
                                <option value="OK" <%if(strState == "OK"){%>selected<%}%>>Oklahoma</option>
                                <option value="OR" <%if(strState == "OR"){%>selected<%}%>>Oregon</option>
                                <option value="PA" <%if(strState == "PA"){%>selected<%}%>>Pennsylvania</option>
                                <option value="RI" <%if(strState == "RI"){%>selected<%}%>>Rhode Island</option>
                                <option value="SC" <%if(strState == "SC"){%>selected<%}%>>South Carolina</option>
                                <option value="SD" <%if(strState == "SD"){%>selected<%}%>>South Dakota</option>
                                <option value="TN" <%if(strState == "TN"){%>selected<%}%>>Tennessee</option>
                                <option value="TX" <%if(strState == "TX"){%>selected<%}%>>Texas</option>
                                <option value="UT" <%if(strState == "UT"){%>selected<%}%>>Utah</option>
                                <option value="VA" <%if(strState == "VA"){%>selected<%}%>>Virginia</option>
                                <option value="VT" <%if(strState == "VT"){%>selected<%}%>>Vermont</option>
                                <option value="WA" <%if(strState == "WA"){%>selected<%}%>>Washington</option>
                                <option value="WI" <%if(strState == "WI"){%>selected<%}%>>Wisconsin</option>
                                <option value="WV" <%if(strState == "WV"){%>selected<%}%>>West Virginia</option>
                                <option value="WY" <%if(strState == "WY"){%>selected<%}%>>Wyoming</option>
                            </select>
	                    </td>
	                </tr>
	                <TR id="xcountry" style="display:none;" >
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Country</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <select title="CountrySelect" name="Country" id="countryselect" onchange="javascript:elementchange();" class="input text">
                            </select>
                            <span id=othercountrytitle style="display:none"><br>Other:<br></span>
                            <input type=text name=OtherCountry id=othercountry style="display:none" onChange="javascript:elementchange();">
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Zip</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtZip" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Phone</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtPhone" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <TR>
		                <TD nowrap="true" valign="top" width="100px" class="ms-formlabel">
		                <H3 class="ms-standardheader">
		                <nobr>Fax</nobr></H3></TD>
		                <TD valign="top" class="ms-formbody" width="400px">
		                    <asp:TextBox ID="txtFax" runat="server" CssClass="ms-input" Width="300px"></asp:TextBox>
	                    </td>
	                </tr>
	                <tr>
	                    <td class="ms-formlabel"><IMG SRC="/_layouts/images/blank.gif" width=1 height=5 alt=""></td>
	                    <td class="ms-formlabel"><IMG SRC="/_layouts/images/blank.gif" width=1 height=5 alt=""></td>
	                </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="ms-ButtonHeightWidth" OnClick="btnOK_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ms-ButtonHeightWidth" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
	             </table>
	        </td>
	    </tr>
	 </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Edit Personal Information
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Edit Personal Information
</asp:Content>
