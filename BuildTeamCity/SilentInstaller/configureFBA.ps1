
param (
    [string]$wa = "http://win-6j09gf4nbp8",
    [string]$ldapserver = "epmldev.com",
    [string]$userDN = "DC=epmldev,DC=com",
    [string]$domain = "epmldev",
    [string]$userName = "farmadmin"
);

$connectionname = "adconn"
$ldapmembername = "admembers"

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$farm = get-spfarm
$key = "HKLM:\software\microsoft\shared tools\web server extensions\" + $farm.BuildVersion.Major + ".0"
$loc = (Get-ItemProperty -path $key).location
$ca = 0
$changes = $false
#$wa = read-host "Enter Web Application URL"
$webapplication = Get-SPWebApplication $wa
if (!$webapplication.useclaimsauthentication) { 
    write-host "Web App is not claims aware. Please convert the web app to claims first" 
    break
}
Write-host "following zones found for the web application" 
write-host "================"
write-host "Zones"
write-host "================"

$webapplication.iissettings.keys

$zonecount = $webapplication.iissettings.keys.count - 1
$zone = 0
#do {
#    $zone = read-host "press number corresponding to zone you want to configure(0-"$zonecount")" 
#    if (($zone -lt 0) -or ($zone -gt $zonecount)) { write-host "Invalid Zone! Please re-enter" }
#}while (($zone -lt 0) -or ($zone -gt $zonecount))
$pathwa = $webapplication.IisSettings[$zone].path.fullname

$ca = Get-SPWebApplication -IncludeCentralAdministration | Where-Object {$_.displayname -eq “SharePoint Central Administration v4"}

$pathca = $ca.IisSettings[0].Path

$pathsts = $loc + "WebServices\SecurityToken"

function ldaptest($ldapstring1) {



    try {

        $Connection = [adsi]($ldapstring1)

    } Catch {

    }

    If ($Connection.Path) {

        Write-Host -ForegroundColor Green "LDAP Connection Successful"
        return $false 

    }
    Else {

        Write-Host -ForegroundColor red "LDAP Connection Failed, re-enter LDAP details"
        return $true

    }

}

$ldapstring = "LDAP://" + $ldapserver + ":389"
if (ldaptest $ldapstring) {
    write-host -foregroundcolor red "Can't connect to LDAP'"
    break
}

#================================== display function ===============

function display ($ca, $message) {

    $changes = $true
    if ($ca -eq 0) {

        write-host -ForegroundColor Cyan "Updating WA :" $message
    }
    if ($ca -eq 1) {
        write-host -ForegroundColor Magenta "Updating CA :" $message
    }
    if ($ca -eq 2) {
        write-host -ForegroundColor Yellow "Updating STS:" $message
    }
}
  
#=============================================================== backing up ===============
function backup($path) {
    $path = $path + "\web.config"
    $content = Get-Content $path 
    [System.Xml.XmlDocument] $xd = new-object System.Xml.XmlDocument
    $xd.LoadXml($content)
    $date = Get-Date
    $datestring = $date.ToString("yyyy MM dd H mm") + "web.config.bak"
    $backuppath = $path.Replace("web.config", $datestring)
    $xd.save($backuppath)

}

 
#=============================================================== adding membership ===================================

function addmembership($xmld, $ca) {

    $tempmembername = $ldapMembername
    $tempstring3 = "/configuration/system.web/membership/providers/add[@name='" + $tempMembername + "']"
    $membernode = $xmld.SelectSingleNode($tempstring3)

    if ($membernode)

    { display $ca "Membership info with same name already exist in web.config" }

    if (!$membernode) {
        $systemWeb = $xmld.SelectSingleNode("/configuration/system.web")

        if (!$systemWeb) {

            $systemWebnode = $xmld.CreateNode("element", "system.web", "")
            $xmld.SelectSingleNode("/configuration").appendchild($systemWebnode)
            display $ca "Added system.web node"
            $authnode = $xmld.CreateNode("element", "authentication", "")
            $winattr = $xmld.CreateAttribute("mode")
            $winattr.value = "Windows"
            $authnode.attributes.append($winattr)
            $systemWebnode.appendchild($authnode)
        }

        $mmship = $xmld.SelectSingleNode("/configuration/system.web/membership")

        if (!$mmship) {

            $mmshipnode = $xmld.CreateNode("element", "membership", "")
            $tempnode = $xmld.CreateNode("element", "providers", "")
            $mmshipnode.appendchild($tempnode)
            $xmld.SelectSingleNode("/configuration/system.web").appendchild($mmshipnode)
            display $ca "Added membership and membership/providers node"
        }

        $mmship = $xmld.SelectSingleNode("/configuration/system.web/membership")

        $mmshipprovider = $xmld.SelectSingleNode("/configuration/system.web/membership/providers")

        $mmshipaddnode = $xmld.CreateNode("element", "add", "")

        
        $nameattr = $xmld.CreateAttribute("name")
        $nameattr.value = $tempMembername
        $mmshipaddnode.attributes.append($nameattr)

        $typeattr = $xmld.CreateAttribute("type")
        $typeattr.Value = "System.Web.Security.ActiveDirectoryMembershipProvider, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        $mmshipaddnode.attributes.append($typeattr)

        $connectionStringNameattr = $xmld.createattribute("connectionStringName")
        $connectionStringNameattr.value = $connectionname
        $mmshipaddnode.attributes.append($connectionStringNameattr)

        $enableSearchMethodsattr = $xmld.createattribute("enableSearchMethods")
        $enableSearchMethodsattr.value = "true"
        $mmshipaddnode.attributes.append($enableSearchMethodsattr)

        $usrnameattr = $xmld.createattribute("attributeMapUsername")
        $usrnameattr.value = "sAMAccountName"
        $mmshipaddnode.attributes.append($usrnameattr)
              
        $mmshipprovider.AppendChild($mmshipaddnode)
        
  
        display $ca "Added membership/providers settings"
    }

    
}



#==================================================================================== add connectionstrings =======================

function addconnectionstring($xmld, $ca) {

    $tempconstring = "/configuration/connectionStrings/add[@name='" + $connectionname + "']"
    $connectionnode = $xmld.SelectSingleNode($tempconstring)

    if ($connectionnode) {
        display $ca "Connection string with the same name already exist in web.config"
    }

    if (!$connectionnode) {

        $cnode1 = $xmld.SelectSingleNode("/configuration/connectionStrings")

        if (!$cnode1) {
      
            $cnode1 = $xmld.CreateNode("element", "connectionStrings", "")
            $xmld.selectsinglenode("/configuration").AppendChild($cnode1)
            display $ca "Added connectionstrings node"

        }

        $cnode1 = $xmld.SelectSingleNode("/configuration/connectionStrings")

        $caddnode = $xmld.CreateNode("element", "add", "")

        $nameattr = $xmld.CreateAttribute("name")
        $nameattr.value = $connectionname
        $caddnode.attributes.append($nameattr)


        $connectstring = $xmld.CreateAttribute("connectionString")
        $connectstring.value = "LDAP://$ldapserver/$userDN"
        $caddnode.attributes.append($connectstring)

        $cnode1.appendchild($caddnode)
        display $ca "Added connectionstrings settings"
        $xd.save($path)
    }

}

#==================================================================================== configure STS =======================

function configureAuthSTS($xmld, $ca, $authType) {
    $cnode1 = $xmld.SelectSingleNode("/configuration/system.webServer/security/authentication")
    $authenticationstring = "/configuration/system.webServer/security/authentication/$authType"
    $authenticationnode = $xmld.SelectSingleNode($authenticationstring)

    if ($authenticationnode) {
        $cnode1.removeChild($authenticationnode)
    }

    $caddnode = $xmld.CreateNode("element", "$authType", "")

    $nameattr = $xmld.CreateAttribute("enabled")
    $nameattr.value = "false"
    $caddnode.attributes.append($nameattr)

    $cnode1.appendchild($caddnode)
    display $ca "Added authType settings"
    $xd.save($path)    
}


#==================================================================================== add appsetting =======================

function addappsetting($xmld, $ca, $settingname, $settingvalue, $overwritesetting) {

    $tempappstring = "/configuration/appSettings/add[@key='$settingname']"
    $appsettingnode = $xmld.SelectSingleNode($tempappstring)

    if ($appsettingnode) {
        if ($overwritesetting) {
            $appsettingnode.SetAttribute("value", $settingvalue);
        }
        else {
            display $ca "App setting with the same name already exist in web.config"
        }    
        return    
    }

    if (!$appsettingnode) {

        $cnode1 = $xmld.SelectSingleNode("/configuration/appSettings")

        if (!$cnode1) {
      
            $cnode1 = $xmld.CreateNode("element", "appSettings", "")
            $xmld.selectsinglenode("/configuration").AppendChild($cnode1)
            display $ca "Added appSettings node"

        }

        $cnode1 = $xmld.SelectSingleNode("/configuration/appSettings")

        $caddnode = $xmld.CreateNode("element", "add", "")

        $nameattr = $xmld.CreateAttribute("key")
        $nameattr.value = $settingname
        $caddnode.attributes.append($nameattr)


        $connectstring = $xmld.CreateAttribute("value")
        $connectstring.value = $settingvalue
        $caddnode.attributes.append($connectstring)

        $cnode1.appendchild($caddnode)
        display $ca "Added connectionstrings settings"
        $xd.save($path)
    }

}

#=================================================================

function processca($path) {
    $ca = 1
    $path = $path + "\web.config"
    $content = Get-Content $path
    [System.Xml.XmlDocument] $xd = new-object System.Xml.XmlDocument
    $xd.LoadXml($content)
    addmembership $xd $ca
    addconnectionstring $xd $ca 
    
    $xd.save($path) 
}

#==============================================================

function processwa($path) {

    $ca = 0
    $path = $path + "\web.config"
    $content = Get-Content $path
    [System.Xml.XmlDocument] $xd = new-object System.Xml.XmlDocument
    $xd.LoadXml($content)
    addmembership $xd $ca
    addconnectionstring $xd $ca
    addappsetting $xd $ca "Prefix" "i:0#.f|$ldapmembername|" $true
    addappsetting $xd $ca "siteUrl" $wa
    addappsetting $xd $ca "ignoreuser" "$domain\$username"
    addappsetting $xd $ca "WebApplication" $webapplication.DisplayName
    addappsetting $xd $ca "domain" "$domain"
    $xd.Save($path)
}
#=================================================================
function processsts($path) {

    $ca = 2
    $path = $path + "\web.config"
    $content = Get-Content $path
    [System.Xml.XmlDocument] $xd = new-object System.Xml.XmlDocument
    $xd.LoadXml($content)
    
    addmembership $xd $ca
    addconnectionstring $xd $ca
    configureAuthSTS  $xd $ca "basicAuthentication"
    configureAuthSTS  $xd $ca "digestAuthentication"
    
    $mmship = $xd.SelectSingleNode("/configuration/system.web/membership")
    $mmship.SetAttribute("defaultProvider", $ldapmembername);


    $xd.Save($path)
}

$NTLM = New-SPAuthenticationProvider -UseWindowsIntegratedAuthentication -DisableKerberos
$FBA = New-SPAuthenticationProvider -ASPNETMembershipProvider "$ldapmembername" -ASPNETRoleProviderName "MyRoleProvider"
$webApplication.UseClaimsAuthentication = $true
$webApplication.Update()
$webApplication.MigrateUsers($true)
 
Set-SPWebApplication -AuthenticationProvider $NTLM, $FBA -Identity $webApplication -Zone "Default"

#===============================================Getp=================
foreach ($server in $farm.servers) {
    if ($server.Role -eq "Application" -or $server.Role -eq "SingleServerFarm") { 
        $servername = $server.name

        write-host -ForegroundColor Green "Working on Server :" $server.name
        $pathwatemp = $pathwa.Substring(0, 1)
        $pathwatemp1 = $pathwa.Substring(0, 2)
        $pathwatemp = "\\" + $servername + "\" + $pathwatemp + "$"
        $pathwaserver = $pathwa.Replace($pathwatemp1, $pathwatemp)
        backup($pathwaserver)
        processwa $pathwaserver
        if ($pathca.exists) {
            $pathca1 = $pathca.fullname
            $pathcatemp = $pathca1.Substring(0, 1)
            $pathcatemp1 = $pathca1.Substring(0, 2)
            $pathcatemp = "\\" + $servername + "\" + $pathcatemp + "$"
            $pathcaserver = $pathca1.Replace($pathcatemp1, $pathcatemp)
            backup($pathcaserver)
            processca($pathcaserver)
        }
        $pathststemp = $pathsts.Substring(0, 1)
        $pathststemp1 = $pathsts.Substring(0, 2)
        $pathststemp = "\\" + $servername + "\" + $pathststemp + "$"
        $pathstsserver = $pathsts.Replace($pathststemp1, $pathststemp)
        backup($pathstsserver)
        processsts($pathstsserver)
    }   
}    

