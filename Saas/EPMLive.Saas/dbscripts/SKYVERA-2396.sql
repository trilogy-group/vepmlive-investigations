update [dbo].[Emails] set EMAILBody= N'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        
        <!-- Facebook sharing information tags -->
        <meta property="You have been given access to an EPM Live site" content="*|MC:SUBJECT|*" />
        
        <title>You have been given access to an EPM Live site</title>
        <style type="text/css">
            /* Client-specific Styles */
            #outlook a{padding:0;} /* Force Outlook to provide a "view in browser" button. */
            body{width:100% !important;} .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail to display emails at full width */
            body{-webkit-text-size-adjust:none;} /* Prevent Webkit platforms from changing default text sizes. */

            /* Reset Styles */
            body{margin:0; padding:0;}
            img{border:0; height:auto; line-height:100%; outline:none; text-decoration:none;}
            table td{border-collapse:collapse;}
            #backgroundTable{height:100% !important; margin:0; padding:0; width:100% !important;}

            /**
            * @tab Page
            * @section background color
            * @tip Set the background color for your email. You may want to choose one that matches your company''s branding.
            * @theme page
            */
            body, #backgroundTable{
                /*@editable*/ background-color:#FAFAFA;
            }

            /**
            * @tab Page
            * @section email border
            * @tip Set the border for your email.
            */
            #templateContainer{
                /*@editable*/ border: 1px solid #DDDDDD;
            }

            /**
            * @tab Page
            * @section heading 1
            * @tip Set the styling for all first-level headings in your emails. These should be the largest of your headings.
            * @style heading 1
            */
            h1, .h1{
                /*@editable*/ color:#202020;
                display:block;
                /*@editable*/ font-family:Segoe UI Light, Segoe, Verdana,Arial;
                /*@editable*/ font-size:34px;
                /*@editable*/ font-weight:bold;
                /*@editable*/ line-height:100%;
                margin-top:0;
                margin-right:0;
                margin-bottom:10px;
                margin-left:0;
                /*@editable*/ text-align:left;
            }

            

            /**
            * @tab Page
            * @section heading 3
            * @tip Set the styling for all third-level headings in your emails.
            * @style heading 3
            */
            h3, .h3{
                /*@editable*/ color:#202020;
                display:block;
                /*@editable*/ font-family:Segoe UI Light, Segoe, Verdana,Arial;
                /*@editable*/ font-size:22px;
                /*@editable*/ font-weight:bold;
                /*@editable*/ line-height:100%;
                margin-top:0;
                margin-right:0;
                margin-bottom:20px;
                margin-left:0;
                /*@editable*/ text-align:left;
            }

            /**
            * @tab Page
            * @section heading 4
            * @tip Set the styling for all fourth-level headings in your emails. These should be the smallest of your headings.
            * @style heading 4
            */
            h4, .h4{
                /*@editable*/ color:#202020;
                display:block;
                /*@editable*/ font-family:Segoe UI Light, Segoe, Verdana,Arial;
                /*@editable*/ font-size:22px;
                /*@editable*/ font-weight:bold;
                /*@editable*/ line-height:100%;
                margin-top:0;
                margin-right:0;
                margin-bottom:10px;
                margin-left:0;
                /*@editable*/ text-align:left;
            }

            /* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: PREHEADER /\/\/\/\/\/\/\/\/\/\ */

            /**
            * @tab Header
            * @section preheader style
            * @tip Set the background color for your email''s preheader area.
            * @theme page
            */
            #templatePreheader{
                /*@editable*/ background-color:#FAFAFA;
            }

            /**
            * @tab Header
            * @section preheader text
            * @tip Set the styling for your email''s preheader text. Choose a size and color that is easy to read.
            */
            .preheaderContent div{
                /*@editable*/ color:#505050;
                /*@editable*/ font-family:Arial;
                /*@editable*/ font-size:10px;
                /*@editable*/ line-height:100%;
                /*@editable*/ text-align:left;
            }

            /**
            * @tab Header
            * @section preheader link
            * @tip Set the styling for your email''s preheader links. Choose a color that helps them stand out from your text.
            */
            .preheaderContent div a:link, .preheaderContent div a:visited, /* Yahoo! Mail Override */ .preheaderContent div a .yshortcuts /* Yahoo! Mail Override */{
                /*@editable*/ color:#336699;
                /*@editable*/ font-weight:normal;
                /*@editable*/ text-decoration:underline;
            }

            /* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: HEADER /\/\/\/\/\/\/\/\/\/\ */

            /**
            * @tab Header
            * @section header style
            * @tip Set the background color and border for your email''s header area.
            * @theme header
            */
            #templateHeader{
                /*@editable*/ background-color:#FFFFFF;
                /*@editable*/ border-bottom:0;
            }

            /**
            * @tab Header
            * @section header text
            * @tip Set the styling for your email''s header text. Choose a size and color that is easy to read.
            */
            

            /**
            * @tab Header
            * @section header link
            * @tip Set the styling for your email''s header links. Choose a color that helps them stand out from your text.
            */
            .headerContent a:link, .headerContent a:visited, /* Yahoo! Mail Override */ .headerContent a .yshortcuts /* Yahoo! Mail Override */{
                /*@editable*/ color:#336699;
                /*@editable*/ font-weight:normal;
                /*@editable*/ text-decoration:underline;
            }

            #headerImage{
                height:auto;
                max-width:600px !important;
            }

            /* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: MAIN BODY /\/\/\/\/\/\/\/\/\/\ */

            /**
            * @tab Body
            * @section body style
            * @tip Set the background color for your email''s body area.
            */
            #templateContainer, .bodyContent{
                /*@editable*/ background-color:#FFFFFF;
            }

            /**
            * @tab Body
            * @section body text
            * @tip Set the styling for your email''s main content text. Choose a size and color that is easy to read.
            * @theme main
            */
            .bodyContent div{
                /*@editable*/ color:#505050;
                /*@editable*/ font-family:Segoe UI Light, Segoe,Verdana,Arial;
                /*@editable*/ font-size:15px;
                /*@editable*/ line-height:150%;
                /*@editable*/ text-align:left;
            }

            /**
            * @tab Body
            * @section body link
            * @tip Set the styling for your email''s main content links. Choose a color that helps them stand out from your text.
            */
            .bodyContent div a:link, .bodyContent div a:visited, /* Yahoo! Mail Override */ .bodyContent div a .yshortcuts /* Yahoo! Mail Override */{
                /*@editable*/ color:#336699;
                /*@editable*/ font-weight:normal;
                /*@editable*/ text-decoration:underline;
            }

            .bodyContent img{
                display:inline;
                height:auto;
            }

            /* /\/\/\/\/\/\/\/\/\/\ STANDARD STYLING: FOOTER /\/\/\/\/\/\/\/\/\/\ */

            /**
            * @tab Footer
            * @section footer style
            * @tip Set the background color and top border for your email''s footer area.
            * @theme footer
            */
            #templateFooter{
                /*@editable*/ background-color:#FFFFFF;
                /*@editable*/ border-top:0;
            }

            /**
            * @tab Footer
            * @section footer text
            * @tip Set the styling for your email''s footer text. Choose a size and color that is easy to read.
            * @theme footer
            */
            .footerContent div{
                /*@editable*/ color:#707070;
                /*@editable*/ font-family:Arial;
                /*@editable*/ font-size:12px;
                /*@editable*/ line-height:125%;
                /*@editable*/ text-align:left;
            }

            /**
            * @tab Footer
            * @section footer link
            * @tip Set the styling for your email''s footer links. Choose a color that helps them stand out from your text.
            */
            .footerContent div a:link, .footerContent div a:visited, /* Yahoo! Mail Override */ .footerContent div a .yshortcuts /* Yahoo! Mail Override */{
                /*@editable*/ color:#336699;
                /*@editable*/ font-weight:normal;
                /*@editable*/ text-decoration:underline;
            }

    
        .style1 {
                color: #3366CC;
                text-decoration: underline;
}

    
        </style>
    </head>
    <body leftmargin="0" marginwidth="0" topmargin="0" marginheight="0" offset="0">
        <center>
            <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="backgroundTable" style="background-color: #FAFAFA;">
                <tr>
                    <td align="center" valign="top">
                        <!-- // Begin Template Preheader \\ -->
                        <table border="0" cellpadding="10" cellspacing="0" width="600" id="templatePreheader">
                            <tr>
                                <td valign="top" class="preheaderContent">
                                </td>
                            </tr>
                        </table>
                        <!-- // End Template Preheader \\ -->
                        <table cellpadding="0" cellspacing="0" width="600" id="templateContainer" style="border: 1px solid #DDDDDD;">
                            <tr>
                                <td>
                                    <div style="text-align:left;background-color:#008BBE;height:10px;">&nbsp;</div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <div style="text-align:left;background-color:#008BBE;">
                                        &nbsp;&nbsp;&nbsp;<img src="http://www.epmlive.com/emailimages/logo-epmlive.png" />
                                    </div>
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align:left;background-color:#008BBE;height:7px;">&nbsp;</div>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" valign="top">
                                    <!-- // Begin Template Body \\ -->
                                    <table border="0" cellpadding="0" cellspacing="0" width="600" id="templateBody" style="text-align:left;line-height:20px;">
                                        <tr>
                                            <td valign="top" class="bodyContent" style="background-color:#FFFFFF;">
                                
                                                <!-- // Begin Module: Standard Content \\ -->
                                                <table border="0" cellpadding="20" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <div style="color:#505050 !important;">
                                                               
                                                                <h3 class="h3" style="color:#505050;">Welcome to EPM Live!</h3>
                                                                  
                                                                An EPM Live account has been created for you either because you or someone you know has signed you up for the EPM Live service.
																<br />
																<br />
																Your EPM Live account information is shown below. An invitation email will arrive shortly containing a link to a specific site that you have been invited to use. Until then, we strongly recommend that you change your password <a href="https://apps22.epmlive.com/_layouts/15/epmlive/changepassword.aspx" target="_blank" style="color:#3366CC;text-decoration:underline;">here</a>.  To reset your password you will need to log in using the account information shown below.
                                                                <br />
																<br />
																Username: [param0]<br />Password: [param1]<br />
																<br />

                                                                Check out the information below to help you get started:
                                                                <br />
                                                                -&nbsp;
                                                                <a href="https://support.skyvera.com/hc/sections/360002196053-EPM-Live-2016-User-Guide">
                                                                <span class="style1">
                                                                User Guides</span></a>
                                                                <br />
                                                                -&nbsp;
                                                                <a href="http://elearning.vitalect.com/epmlive/">
                                                                <span class="style1">
                                                                Training Videos</span></a>
                                                                 <br />
                                                                -&nbsp;
                                                                <a href="https://support.skyvera.com">
                                                                <span class="style1">
                                                                Support Community</span></a>

                                                                <br />
                                                                <br />
															If you have any questions or need support, please feel free to contact us through our <a style="color:#3366CC;text-decoration:none;" href="https://support.skyvera.com">Support Community</a>. 											
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left:20px;">
                                                            <div style="color:#505050;">
                                                                Best Regards,<br /><br />
                                                                <img src="http://www.epmlive.com/emailimages/teamepmlive.png" style="padding-bottom:10px;"/>
                                                                <br />
                                                                Team EPM Live
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!-- // End Module: Standard Content \\ -->
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- // End Template Body \\ -->
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <!-- // Begin Template Footer \\ -->
                                    <table border="0" cellpadding="10" cellspacing="0" width="600" id="templateFooter" style="background-color:#FFFFFF;">
                                        <tr>
                                            <td valign="top" class="footerContent">
                                            
                                                <!-- // Begin Module: Standard Footer \\ -->
                                                <table border="0" cellpadding="10" cellspacing="0" width="100%">
                                                    
                                                    <tr>
                                                        <td valign="top" width="400">
                                                            <div mc:edit="std_footer" style="font-size:10px;">
                                                                <em>Copyright &copy; 2012 EPM Live, All rights reserved.</em>
                                                                <br />
                                                                Please do not reply to this message. This e-mail address is not monitored and replies cannot be responded to. 
                                                                <br />
                                                                
                                                                <br />
                                                                
                                                            </div>
                                                        </td>
                                                       
                                                    </tr>
                                               
                                                </table>
                                                <!-- // End Module: Standard Footer \\ -->
                                            
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- // End Template Footer \\ -->
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
            </table>
        </center>
    </body>
</html>​' where email_id=4