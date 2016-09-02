<%@ Control Language="C#" Inherits="EPMLiveCore.TotalsRollupProperties,EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" AutoEventWireup="false" compilationMode="Always" %>

<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>


<wssuc:InputFormSection runat="server" id="TotalRollupSection" Title="Rollup Options">


       <Template_InputFormControls>
       
            
                 
             <wssuc:InputFormControl runat="server"

                    LabelText="Select List">

                    <Template_Control>
    
                            <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlList_SelectedIndexChanged"></asp:DropDownList>

                    </Template_Control>

             </wssuc:InputFormControl>
             
             <wssuc:InputFormControl runat="server"

                        LabelText="Select Lookup Column">

                        <Template_Control>
        
                                <asp:DropDownList ID="ddlLookup" runat="server">
                                </asp:DropDownList>

                        </Template_Control>

                 </wssuc:InputFormControl>

             <wssuc:InputFormControl runat="server"

                    LabelText="Select Aggregation Type">

                    <Template_Control>
    
                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Text="Count" Value=""></asp:ListItem>
                                <asp:ListItem Text="Sum" Value="Sum"></asp:ListItem>
                                <asp:ListItem Text="Average" Value="Avg"></asp:ListItem>
                            </asp:DropDownList>

                    </Template_Control>

             </wssuc:InputFormControl>
             
             <div id="divCol">
                 <wssuc:InputFormControl runat="server"

                        LabelText="Select Aggregation Column" id="dCol">

                        <Template_Control>
        
                                <asp:DropDownList ID="ddlColumn" runat="server">
                                </asp:DropDownList>

                        </Template_Control>

                 </wssuc:InputFormControl>
            </div>
            
            <wssuc:InputFormControl runat="server"

                    LabelText="Select Output Type">

                    <Template_Control>
    
                            <asp:DropDownList ID="ddlOutput" runat="server">
                                <asp:ListItem Text="Number" Value=""></asp:ListItem>
                                <asp:ListItem Text="Currency" Value="currency"></asp:ListItem>
                                <asp:ListItem Text="Percentage" Value="percent"></asp:ListItem>
                            </asp:DropDownList>

                    </Template_Control>

             </wssuc:InputFormControl>

            <wssuc:InputFormControl runat="server"

                    LabelText="Select Number of Decimals">

                    <Template_Control>
    
                            <asp:DropDownList ID="ddlDecimals" runat="server">
                                <asp:ListItem Text="Automatic" Value=""></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            </asp:DropDownList>

                    </Template_Control>

             </wssuc:InputFormControl>
             
		<wssuc:InputFormControl runat="server"

                    LabelText="Enter CAML Query">

                    <Template_Control>

                           <asp:TextBox id="txtQuery" runat="server" Height="100px" TextMode="MultiLine" Width="100%"/><br>
				<B>Example:</b><br> &lt;Eq&gt;&lt;FieldRef Name='Status'/&gt;&lt;Value Type='Choice'&gt;Active&lt;/Value&gt;&lt;/Eq&gt;

                    </Template_Control>

             </wssuc:InputFormControl>

       </Template_InputFormControls>
       


</wssuc:InputFormSection>
    <script language="javascript">
        function hideCols(obj)
        {
            var val = obj.options[obj.selectedIndex].value;
            if(val == "Sum" || val == "Avg")
            {
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow1").style.display = "";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow2").style.display = "";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow3").style.display = "";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow5").style.display = "";
            }
            else
            {
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow1").style.display = "none";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow2").style.display = "none";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow3").style.display = "none";
                document.getElementById("ctl00_PlaceHolderMain_ctl01_TotalRollupSection_dCol_tablerow5").style.display = "none";
            }
        }
        hideCols(document.getElementById("<%=ddlType.ClientID%>"));
    </script>