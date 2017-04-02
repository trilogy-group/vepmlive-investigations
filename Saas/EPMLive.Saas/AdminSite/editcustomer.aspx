<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="editcustomer.aspx.cs" Inherits="AdminSite.editcustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<link rel="STYLESHEET" type="text/css" href="dhtmlxtab/dhtmlxtabbar.css">
<link rel="STYLESHEET" type="text/css" href="modal/modal.css">
<script  src="dhtmlxtab/dhtmlxcommon.js"></script>
<script  src="dhtmlxtab/dhtmlxtabbar.js"></script>
<script  src="dhtmlxtab/dhtmlxtabbar_start.js"></script>
<script  src="modal/modal.js"></script>


    <script language="javascript">
        function addpubkey()
        {
            var url = "addpubkey.aspx?customer_id=<%=Request["customer_id"] %>"
            sm('addpubkey',400,350);
            document.getElementById("addpubkeyframe").src=url;
        }
        function closeadd()
        {
            hm('addpubkey');
        }
        
        function resetKey(key_id)
        {
            sm('divresetkey',400,100);
            var url = "resetkey.aspx?customer_id=<%=Request["customer_id"] %>&key_id=" + URLEncode(key_id);
            document.getElementById("iframeresetkey").src=url;
            document.getElementById("iframeresetkey").style.height=90;
            
        }
        function closereset()
        {
            hm('divresetkey');
        }
        
        
        function resetfKey(key_id)
        {
            sm('divresetkey',400,100);
            var url = "resetfkey.aspx?customer_id=<%=Request["customer_id"] %>&key_id=" + URLEncode(key_id);
	        document.getElementById("iframeresetkey").style.height=90;
            document.getElementById("iframeresetkey").src=url;
        }

	    function tksupport(key_id)
        {
            sm('divresetkey',400,300);
            var url = "tksupport.aspx?customer_id=<%=Request["customer_id"] %>&key_id=" + URLEncode(key_id);
	        document.getElementById("iframeresetkey").style.height=290;
            document.getElementById("iframeresetkey").src=url;
        }

        function activate(key_id)
        {
            sm('divresetkey',500,150);
            var url = "activatekey.aspx?customer_id=<%=Request["customer_id"] %>&key_id=" + URLEncode(key_id);
	        document.getElementById("iframeresetkey").style.height=140;
            document.getElementById("iframeresetkey").src=url;
        }
        
        function pubsupport(key_id)
        {
            sm('divresetkey',400,300);
            var url = "pubsupport.aspx?customer_id=<%=Request["customer_id"] %>&key_id=" + URLEncode(key_id);
            document.getElementById("iframeresetkey").src=url;
	        document.getElementById("iframeresetkey").style.height=290;
            
        }

        function closefreset()
        {
            hm('divresetkey');
        }
        
        function viewKeyInfo(featurekey)
        {
            var url = "viewkeyinfo.aspx?featurekey=" + URLEncode(featurekey);

            sm('viewKeyInfo',400,280);
            
            document.getElementById("frmViewKeyInfo").src=url;
        }
        
        function closekeyinfo()
        {
            hm('viewKeyInfo');
        }
        
        
        function addfeature()
        {
            var url = "addfeature.aspx?customer_id=<%=Request["customer_id"] %>";
            var w = getWidth() - 100;
            var h = getHeight()-100;
            document.getElementById("frmaddfeature").height = h;
            sm('addfeature',w,h);
            
            document.getElementById("frmaddfeature").src=url;
        }
        function closeaddfeature()
        {
            hm('addfeature');
        }
        
        function getWidth()
        {
            var winW = 640;
            if (parseInt(navigator.appVersion)>3) {
             if (navigator.appName=="Netscape") {
              winW = window.innerWidth;
             }
             if (navigator.appName.indexOf("Microsoft")!=-1) {
              winW = document.body.offsetWidth;
             }
            }
            return winW;
        }
        function getHeight()
        {
            var winW = 480;
            if (parseInt(navigator.appVersion)>3) {
             if (navigator.appName=="Netscape") {
              winH = window.innerHeight;
             }
             if (navigator.appName.indexOf("Microsoft")!=-1) {
              winH = document.body.offsetHeight;
             }
            }
            return winH;
        }
        function URLEncode(plaintext )
        {
	        // The Javascript escape and unescape functions do not correspond
	        // with what browsers actually do...
	        var SAFECHARS = "0123456789" +					// Numeric
					        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +	// Alphabetic
					        "abcdefghijklmnopqrstuvwxyz" +
					        "-_.!~*'()";					// RFC2396 Mark characters
	        var HEX = "0123456789ABCDEF";

	        var encoded = "";
	        for (var i = 0; i < plaintext.length; i++ ) {
		        var ch = plaintext.charAt(i);
	            if (ch == " ") {
		            encoded += "+";				// x-www-urlencoded, rather than %20
		        } else if (SAFECHARS.indexOf(ch) != -1) {
		            encoded += ch;
		        } else {
		            var charCode = ch.charCodeAt(0);
			        if (charCode > 255) {
			            alert( "Unicode Character '" 
                                + ch 
                                + "' cannot be encoded using standard URL encoding.\n" +
				                  "(URL encoding only supports 8-bit characters.)\n" +
						          "A space (+) will be substituted." );
				        encoded += "+";
			        } else {
				        encoded += "%";
				        encoded += HEX.charAt((charCode >> 4) & 0xF);
				        encoded += HEX.charAt(charCode & 0xF);
			        }
		        }
	        } // for

	        return encoded;
        };
    </script>




    
    
    
    
    <div id="a_tabbar" class="dhtmlxTabBar" select="a<%=strTab %>" imgpath="dhtmlxtab/imgs/" style="width:100%;height:100%;"  skinColors="#FCFBFC,#F4F3EE" >
        <div id="a1" name="Contact Information">
            <div style="padding:5px">
                <asp:Label ID="lblSaved" runat="server" Text="Information Saved" ForeColor="green" Visible="False"></asp:Label>
                <table border="0" cellpadding="1" cellspacing="2">
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">First Name:</td>
                            <td><asp:TextBox ID="txtFirstName" runat="server" /></td>
                            <td width="100" bgcolor="#c9c9c9">Address1:</td>
                            <td><asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox></td>
                            <td width="130" bgcolor="#c9c9c9">Customer Number:</td>
                            <td><asp:Label ID="lblCustomerNumber" runat="server"/></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Last Name:</td>
                            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                            <td width="100" bgcolor="#c9c9c9">Address2:</td>
                            <td><asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">E-Mail:</td>
                            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                            <td width="100" bgcolor="#c9c9c9">City:</td>
                            <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Company:</td>
                            <td><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></td>
                            <td width="100" bgcolor="#c9c9c9">State:</td>
                            <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9"></td>
                            <td></td>
                            <td width="100" bgcolor="#c9c9c9">Zip:</td>
                            <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Title:</td>
                            <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                            <td width="100" bgcolor="#c9c9c9">Country:</td>
                            <td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Phone:</td>
                            <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            <td width="100" bgcolor="#c9c9c9">Region:</td>
                            <td><asp:TextBox ID="lblRegion" runat="server"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9"></td>
                            <td><asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="searchbutton"/></td>
                            <td width="100"></td>
                            <td></td>
                            <td></td><td></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="a2" name="Publisher" >
                <div style="padding:5px">
                    <a href="javascript:addpubkey();"  >[Add Publisher Key]</a><br /><br />
                    
                    <asp:GridView ID="gvPublisher" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="Black" GridLines="Vertical" Width="100%" OnRowCommand="gvPublisher_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>
                        <asp:BoundField DataField="publisherordernumber" HeaderText="Order #" />
                        <asp:BoundField DataField="cdkey" HeaderText="Key" />
                        <asp:BoundField DataField="company" HeaderText="Company" />
                        <asp:BoundField DataField="purchasedate" HeaderText="Purchase Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="activations" HeaderText="Activations" />
                        <asp:BoundField DataField="supportexpires" HeaderText="Support Expires" DataFormatString="{0:d}" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:resetKey('<%# Eval("key_id") %>');">Reset Key</a>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:pubsupport('<%# Eval("key_id") %>');">Support Date</a>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" 
                                CommandArgument='<%# Eval("key_id") %>' 
                                CommandName="remove" runat="server">
                                Remove</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                </div>
            </div>
            <div id="a3" name="Toolkit v2">
                <div style="padding:5px">
                    <a href="addkey.aspx?customer_id=<%=Request["customer_id"] %>">[Add Feature Key]</a><br />
                    <br />
                    <asp:GridView ID="gvToolkitV2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="Black" GridLines="Vertical" Width="100%" OnRowCommand="gvToolkitV2_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <a href="javascript:resetfKey('<%# Eval("toolkitorderid") %>');">Reset Key</a>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Wrap="false">
                         <ItemTemplate>
                           <asp:LinkButton ID="LinkButton2" 
                             CommandArgument='<%# Eval("toolkitorderid") %>' 
                             CommandName="remove" runat="server">
                             Remove</asp:LinkButton>
                         </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                         </asp:TemplateField>

			            <asp:TemplateField ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <a href="javascript:tksupport('<%# Eval("toolkitorderid") %>');">Support Date</a>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <a href="javascript:activate('<%# Eval("toolkitorderid") %>');">Activate</a>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Key" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <%# Eval("featurekey", "<a href=\"javascript:viewKeyInfo('{0}')\">View Key Info</a>")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="toolkitordernumber" HeaderText="Order Number" />
                        <asp:BoundField DataField="dtcreated" HeaderText="Created" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="activations" HeaderText="Activations" />
                        <asp:BoundField DataField="supportexpires" HeaderText="Support Expires" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="featurekey" HeaderText="Key" />
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
		<br>
		<br>
		Purchased Applications:
		<br><br>
		<%=strApps%>
		<br>
		<asp:Button ID="btnSaveApps" runat="server" OnClick="btnSaveApps_Click" Text="Save" CssClass="searchbutton"/>
                </div>
            </div>
            <div id="a4" name="Toolkit V1">
                <div style="padding:5px">
                    <table border="0" cellpadding="1" cellspacing="2">
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Key:</td>
                            <td><asp:Label ID="lblV1Key" runat="Server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Activations:</td>
                            <td><asp:Label ID="lblV1Activations" runat="Server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="100" bgcolor="#c9c9c9">Purchase Date:</td>
                            <td><asp:Label ID="lblV1Purchase" runat="Server"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <div id="viewKeyInfo" class="dialog">

            <iframe id="frmViewKeyInfo" width="100%" height="250" frameborder="0">
                
            </iframe>
            <br />
            <a href="javascript:closekeyinfo()">Close</a>

        </div>
    
        <div id="addpubkey" class="dialog">
            <iframe id="addpubkeyframe" width="100%" height="340" frameborder="0">
                
            </iframe>
        </div>
        
        <div id="addfeature" class="dialog">
            <iframe id="frmaddfeature" width="100%" height="100%" frameborder="0">
                
            </iframe>
        </div>
        
        
        <div id="divresetkey" class="dialog">
            <iframe id="iframeresetkey" width="100%" height="100" frameborder="0">
                
            </iframe>
        </div>
    
        <script language="javascript">
            initmb();
        </script>
</asp:Content>
