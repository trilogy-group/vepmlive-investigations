if not exists (select emailid from EMAILTEMPLATES where emailid = 2)
begin
    INSERT INTO EMAILTEMPLATES (emailid,title,subject,body) VALUES (2,'Build Team Grant','You have been granted access to a WorkEngine site','<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} has granted you access to the <u><a href="{SiteUrl}" style="font-size:20px;color:#3366CC;">{SiteName}</a></u> site.<br></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Access your EPM Live site now:<br><u><a href="{SiteUrl}" style="font-size:15px;color:#3366CC;">{SiteUrl}</a></u>
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Use the following username:<br>{ToUser_Username}
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">If you have any questions, please contact {CurUser_Name} at <a href="mailto:{CurUser_Email}" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Email}</a>
</td>
</tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">For help, please visit <a href="http://support.epmlive.com" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">http://support.epmlive.com</a>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>

</body>

</html>')
end
else
begin
    UPDATE EMAILTEMPLATES SET subject='You have been granted access to a WorkEngine site', body='<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} has granted you access to the <u><a href="{SiteUrl}" style="font-size:20px;color:#3366CC;">{SiteName}</a></u> site.<br></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Access your EPM Live site now:<br><u><a href="{SiteUrl}" style="font-size:15px;color:#3366CC;">{SiteUrl}</a></u>
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Use the following username:<br>{ToUser_Username}
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">If you have any questions, please contact {CurUser_Name} at <a href="mailto:{CurUser_Email}" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Email}</a>
</td>
</tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">For help, please visit <a href="http://support.epmlive.com" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">http://support.epmlive.com</a>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>

</body>

</html>' where emailid=2
end
if not exists (select emailid from EMAILTEMPLATES where emailid = 3)
begin
    INSERT INTO EMAILTEMPLATES (emailid,title,subject,body) VALUES (3,'Comments','{CurUser_Name} commented on: {ItemName}','<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled 1</title>
<style type="text/css">

.spacer
{
height: 10px;
}
.commentTitle
{
font-size:20px;
color:#666666
}

.commentText
{
font-size:15px;
color:#666666
}


.commentLinkText
{
                text-decoration:none;
                color:#3366CC;                  
}

.footer
{
                font-size:9px;
                color:#999999    
}



</style>

</head>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td class="commentTitle"><font face="Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} commented on: <a href="{ItemLink}" target="_blank" class="commentLinkText">{ItemName}</a></font></td>
</tr>
<tr><td height="2px"></td></tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3">List:&nbsp;<a href="{ListLink}" target="_blank" class="commentLinkText">{ListName}</a></font></td>
</tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3">Site:&nbsp;<a href="{SiteUrl}" target="_blank" class="commentLinkText">{SiteName}</a></font></td>
</tr>
<tr><td height="5px"></td></tr>
<tr>
<td width="300px">
<br />
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">{CurUser_Name} said:</font>
<table width="300px" cellpadding="10" cellspacing="5" border="0" bgcolor="#eef4f9">
<tr>
<td>
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">"{Comment}"</font>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<table width="100%" cellpadding="0" cellspacing="5" border="0">
<tr>
<td class="spacer"></td>
</tr>
<tr>
<td>
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">Please do not reply back to this email - instead, click <a href="{CommentsPageUrl}" target="_blank" class="commentLinkText">HERE</a> to reply.</font></td>
</tr>
<tr>
<td class="spacer"></td>
</tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3"><a href="{CommentsPageUrl}" target="_blank" class="commentLinkText">View Comment Thread</a></font></td>
</tr>
<tr>
<td class="spacer"></td>
</tr>
</table>
</td>
</table>
</body>
</html>
')
end
else
begin
    UPDATE EMAILTEMPLATES SET subject='{CurUser_Name} commented on: {ItemName}', body='<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled 1</title>
<style type="text/css">

.spacer
{
height: 10px;
}
.commentTitle
{
font-size:20px;
color:#666666
}

.commentText
{
font-size:15px;
color:#666666
}


.commentLinkText
{
                text-decoration:none;
                color:#3366CC;                  
}

.footer
{
                font-size:9px;
                color:#999999    
}



</style>

</head>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td class="commentTitle"><font face="Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} commented on: <a href="{ItemLink}" target="_blank" class="commentLinkText">{ItemName}</a></font></td>
</tr>
<tr><td height="2px"></td></tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3">List:&nbsp;<a href="{ListLink}" target="_blank" class="commentLinkText">{ListName}</a></font></td>
</tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3">Site:&nbsp;<a href="{SiteUrl}" target="_blank" class="commentLinkText">{SiteName}</a></font></td>
</tr>
<tr><td height="5px"></td></tr>
<tr>
<td width="300px">
<br />
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">{CurUser_Name} said:</font>
<table width="300px" cellpadding="10" cellspacing="5" border="0" bgcolor="#eef4f9">
<tr>
<td>
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">"{Comment}"</font>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<table width="100%" cellpadding="0" cellspacing="5" border="0">
<tr>
<td class="spacer"></td>
</tr>
<tr>
<td>
<font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="2">Please do not reply back to this email - instead, click <a href="{CommentsPageUrl}" target="_blank" class="commentLinkText">HERE</a> to reply.</font></td>
</tr>
<tr>
<td class="spacer"></td>
</tr>
<tr>
<td><font face="Lucida Grande,Arial Unicode MS,sans-serif" color="#666666" size="3"><a href="{CommentsPageUrl}" target="_blank" class="commentLinkText">View Comment Thread</a></font></td>
</tr>
<tr>
<td class="spacer"></td>
</tr>
</table>
</td>
</table>
</body>
</html>
' where emailid=3
end
if not exists (select emailid from EMAILTEMPLATES where emailid = 4)
begin
    INSERT INTO EMAILTEMPLATES (emailid,title,subject,body) VALUES (4,'Assigned To','{ListName} - {ItemName} has been assigned to you','<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} has assigned item <a href="{ItemUrl}" style="font-size:20px;color:#3366CC;">{ItemName}</a> to you in <a href="{SiteUrl}" target="_blank" style="color:#3366CC;">{SiteName}</a>.</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">If you have any questions regarding the assignment you can contact {CurUser_Name} at <u><a href="mailto:{CurUser_Email}" style="font-size:14px;color:#3366CC;">{CurUser_Email}</a></u>.</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">View <u><a href="{ItemUrl}" target="_blank" style="font-size:12px;color:#3366CC;">{ItemName}</a></u> details:</td>
</tr>
<tr>
<td>
<ul style="padding-top:10px;font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif;line-height:20px;">
                <li><strong>Name:</strong>&nbsp;&nbsp;{ItemName}</li>
                <li><strong>Start Date:</strong>&nbsp;&nbsp;{StartDate}</li>
                <li><strong>Due Date:</strong>&nbsp;&nbsp;{DueDate}</li>
                <li><strong>Priority:</strong>&nbsp;&nbsp;{Priority}</li>
                <li><strong>Status:</strong>&nbsp;&nbsp;{Status}</li>
                <li><strong>Description:</strong>&nbsp;&nbsp;{Body}</li>
</ul>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>
</body>
</html>
')
end
else
begin
    UPDATE EMAILTEMPLATES SET subject='{ListName} - {ItemName} has been assigned to you', body='<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">{CurUser_Name} has assigned item <a href="{ItemUrl}" style="font-size:20px;color:#3366CC;">{ItemName}</a> to you in <a href="{SiteUrl}" target="_blank" style="color:#3366CC;">{SiteName}</a>.</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">If you have any questions regarding the assignment you can contact {CurUser_Name} at <u><a href="mailto:{CurUser_Email}" style="font-size:14px;color:#3366CC;">{CurUser_Email}</a></u>.</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">View <u><a href="{ItemUrl}" target="_blank" style="font-size:12px;color:#3366CC;">{ItemName}</a></u> details:</td>
</tr>
<tr>
<td>
<ul style="padding-top:10px;font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif;line-height:20px;">
                <li><strong>Name:</strong>&nbsp;&nbsp;{ItemName}</li>
                <li><strong>Start Date:</strong>&nbsp;&nbsp;{StartDate}</li>
                <li><strong>Due Date:</strong>&nbsp;&nbsp;{DueDate}</li>
                <li><strong>Priority:</strong>&nbsp;&nbsp;{Priority}</li>
                <li><strong>Status:</strong>&nbsp;&nbsp;{Status}</li>
                <li><strong>Description:</strong>&nbsp;&nbsp;{Body}</li>
</ul>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>
</body>
</html>
' where emailid=4
end
if not exists (select emailid from EMAILTEMPLATES where emailid = 5)
begin
    INSERT INTO EMAILTEMPLATES (emailid,title,subject,body) VALUES (5,'Project Pending Updates','{ProjectName} has pending updates awaiting your approval','<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">There are pending updates awaiting your approval for: <a href="{SiteUrl}" style="font-size:20px;color:#3366CC;">{ProjectName}</a></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"><u><a target="_blank" href="{SiteUrl}/_layouts/epmlive/workplanner.aspx?listid={ListId}&id={ItemId}" style="font-size:15px;color:#3366CC;">Click here</a></u> to view the updates now.
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">You have received this email because you are either the creator or one of the planners for "{ProjectName}".</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">For help, please visit <a target="_blank" href="http://support.epmlive.com" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">http://support.epmlive.com</a>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>
</body>
</html>')
end
else
begin
    UPDATE EMAILTEMPLATES SET subject='{ProjectName} has pending updates awaiting your approval', body='<html>
<body>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">There are pending updates awaiting your approval for: <a href="{SiteUrl}" style="font-size:20px;color:#3366CC;">{ProjectName}</a></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"><u><a target="_blank" href="{SiteUrl}/_layouts/epmlive/workplanner.aspx?listid={ListId}&id={ItemId}" style="font-size:15px;color:#3366CC;">Click here</a></u> to view the updates now.
</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">You have received this email because you are either the creator or one of the planners for "{ProjectName}".</td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td style="font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">For help, please visit <a target="_blank" href="http://support.epmlive.com" style="font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif">http://support.epmlive.com</a>
</td>
</tr>
<tr><td><hr></td></tr>
<tr>
<td style="font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif">Powered by EPM Live :)</td>
</tr>
</table>
</body>
</html>' where emailid=5
end
