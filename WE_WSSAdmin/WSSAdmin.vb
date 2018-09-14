Public Class WSSAdmin
    Private Enum EXTENDED_NAME_FORMAT
        NameUnknown = 0
        NameFullyQualifiedDN = 1
        NameSamCompatible = 2
        NameDisplay = 3
        NameUniqueId = 6
        NameCanonical = 7
        NameUserPrincipal = 8
        NameCanonicalEx = 9
        NameServicePrincipal = 10
    End Enum
    Private Declare Function GetUserNameEx Lib "secur32.dll" Alias "GetUserNameExA" (ByVal NameFormat As EXTENDED_NAME_FORMAT, ByVal lpNameBuffer As String, ByRef nSize As Long) As Long

    '//////////////////////////////////////////////////////////////////////////////
    Public Function SendWSSRequest(ByRef sTargetURL As String, ByRef sSOAPAction As String, ByRef sXMLRequest As String, ByRef sXMLResponse As String) As Long
        On Error GoTo Exception_Error

        Dim oXMLHTTP As New MSXML2.ServerXMLHTTP
        oXMLHTTP = CreateObject("Msxml2.ServerXMLHTTP")

        Call oXMLHTTP.open("POST", sTargetURL, False)
        Call oXMLHTTP.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
        Call oXMLHTTP.setRequestHeader("SOAPAction", sSOAPAction)

        Call oXMLHTTP.send(sXMLRequest)

        Dim oXMLDocument As MSXML2.DOMDocument
        oXMLDocument = oXMLHTTP.responseXML
        If Not oXMLDocument Is Nothing Then
            sXMLResponse = oXMLDocument.xml
        End If
        oXMLDocument = Nothing
        oXMLHTTP = Nothing

        SendWSSRequest = 0

        Exit Function

Exception_Error:
        sXMLResponse = Format$(Err.Number) & " : " & Err.Description
        oXMLDocument = Nothing
        oXMLHTTP = Nothing
        SendWSSRequest = 8805
    End Function

    '//////////////////////////////////////////////////////////////////////////////
    Public Function GetSecurityPrincipal(ByRef sName As String) As Long
        Dim sBuffer As String, ret As Long
        sBuffer = New String("", 512)
        ret = Len(sBuffer)
        If GetUserNameEx(EXTENDED_NAME_FORMAT.NameSamCompatible, sBuffer, ret) <> 0 Then
            sName = Left$(sBuffer, ret)
        End If
        GetSecurityPrincipal = 0
    End Function


    Public Function XMLRequest(ByVal sContext As String, ByVal sCookie As String, ByVal sXML As String) As String
        'Dim oEPK As WE_PDSExt.CMain
        'oEPK = New WE_PDSExt.CMain
        Dim oEPK As Object
        Select Case (sContext)
            Case "EPKRequest"
                oEPK = New WE_PDSExt.CMain()
            Case "EPKCSRequest"
                oEPK = New WE_CSRequest.CMain()
            Case "DBARequest"
                oEPK = New WE_DBASvr.CMain()
            Case Else
                oEPK = New WE_PDSExt.CMain()
        End Select

        Dim s As String
        s = oEPK.SoapXMLRequest(sCookie, sXML, "-a")
        oEPK = Nothing
        XMLRequest = s
    End Function

    Public Function RSVPRequest(ByVal sContext As String, ByVal sBasepath As String, Optional ByVal sTargetJobGuid As String = "") As String
        Dim oRequestMgr As Object
        oRequestMgr = New WE_RSVP.RequestMgr()

        Dim l As Long
        Dim s As String = String.Empty

        Select Case (sContext)
            Case "ManageQueue"
                Call oRequestMgr.ManageQueue(sBasepath, sTargetJobGuid)
                s = "<Reply><HRESULT>0</HRESULT><STATUS>0</STATUS></Reply>"
            Case "ManageTimerJobs"
                l = oRequestMgr.ManageTimedJobs(sBasepath)
                s = "<Reply><HRESULT>0</HRESULT><STATUS>" & Format$(l, "0") & "</STATUS></Reply>"
        End Select
        oRequestMgr = Nothing
        RSVPRequest = s
    End Function
End Class
