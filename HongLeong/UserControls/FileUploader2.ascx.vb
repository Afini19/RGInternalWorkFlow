Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class fileuploader2_class
    Inherits System.Web.UI.UserControl
    'Protected _Width As String = "100px"
    'Protected _Height As String = "120px"
    'Protected _ImgWidth As String = "300px"
    'Protected _ImgHeight As String = "300px"

    'Protected _MerchantID As String = ""
    Protected _moduleName As String = ""
    Protected _formucode As String = ""
    'Protected _doctype As String = ""
    'Protected _wfalevel As String = ""
    'Protected title As String = ""

    'Protected curlevel As String
    ''Public lblformnamespace, lblAppcode, lbluploadstatus, flddoc1, lblfilename, ltimage, btnupload, btndelete, lbluniqueid As Object

    Protected _FileName As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = ""
        loadpr()
    End Sub

    Public Sub loadpr()
        Try
            rep_pr.DataSource = backend.getDocsDs(formucode, _moduleName)
            rep_pr.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub rep_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rep_pr.ItemCommand
        If e.CommandName = "Del" Then
            DeleteDoc(backend.deleteFile(e.CommandArgument, formucode))

        End If
    End Sub
    'Public Sub setUpload(ByVal rights As String, ByVal level As String, ByVal uploadrights1 As Integer, Optional ByVal uploadrights2 As Integer = 0, Optional ByVal uploadrights3 As Integer = 0, Optional ByVal uploadrights4 As Integer = 0, Optional ByVal uploadrights5 As Integer = 0)
    '    If backend.uploadRights(level, rights, uploadrights1, uploadrights2, uploadrights3, uploadrights4, uploadrights5) Then 'And Not backend.closed(_formucode)
    '        uploadrights.Value = "True"
    '    Else
    '        uploadrights.Value = "False"
    '    End If

    'End Sub
    'Public Property wfalevel() As String
    '    Get
    '        Return _wfalevel
    '    End Get
    '    Set(ByVal value As String)
    '        _wfalevel = value

    '    End Set
    'End Property
    'Public Property errormessage() As String
    '    Get
    '        Return lblMessage.Text
    '    End Get
    '    Set(ByVal value As String)
    '        lblMessage.Text = value

    '    End Set
    'End Property
    'Public Property doctype() As String
    '    Get
    '        Return _doctype
    '    End Get
    '    Set(ByVal value As String)
    '        _doctype = value

    '        Select Case value
    '            Case "PR" : title = "Production Report"


    '            Case "TR" : title = "QA Inspection Reports"
    '            Case "C" : title = "Final Report"

    '        End Select
    '        formtitle.Text = title
    '    End Set
    'End Property
    Public Property formucode() As String
        Get
            Return _formucode
        End Get
        Set(ByVal value As String)
            _formucode = value
            '       
        End Set
    End Property
    Public Property moduleName() As String
        Get
            Return _moduleName
        End Get
        Set(ByVal value As String)
            _moduleName = value
            '       
        End Set
    End Property
    'Public Property MerchantID() As String
    '    Get
    '        Return _MerchantID
    '    End Get
    '    Set(ByVal value As String)
    '        _MerchantID = value
    '        '            flddoc1.Width = _Width
    '    End Set
    'End Property

    'Public Property ImgWidth() As String
    '    Get
    '        Return _ImgWidth
    '    End Get
    '    Set(ByVal value As String)
    '        _ImgWidth = value
    '        '            flddoc1.Width = _Width
    '    End Set
    'End Property
    Public Property Preview() As Boolean
        Get
            Return ltimage.Visible
        End Get
        Set(ByVal value As Boolean)
            ltimage.Visible = value
        End Set
    End Property

    'Public Property ImgHeight() As String
    '    Get
    '        Return _ImgHeight
    '    End Get
    '    Set(ByVal value As String)
    '        _ImgHeight = value
    '        '            flddoc1.Width = _Width
    '    End Set
    'End Property
    'Public Property Width() As String
    '    Get
    '        Return _Width
    '    End Get
    '    Set(ByVal value As String)
    '        _Width = value
    '        '            flddoc1.Width = _Width
    '    End Set
    'End Property
    Public Property FormNamespace() As String
        Get
            Return lblformnamespace.Text
        End Get
        Set(ByVal value As String)
            lblformnamespace.Text = value
        End Set
    End Property
    Public Property UniqueID() As String
        Get
            Return lblformnamespace.Text
        End Get
        Set(ByVal value As String)
            lbluniqueid.Text = value
        End Set
    End Property

    Public Property AppCode() As String
        Get
            Return lblappcode.Text
        End Get
        Set(ByVal value As String)
            lblappcode.Text = value
        End Set
    End Property
    'Public Property Height() As String
    '    Get
    '        Return _Height
    '    End Get
    '    Set(ByVal value As String)
    '        _Height = value
    '        'flddoc1.Height = _Height
    '    End Set
    'End Property

    Public Property text() As String
        Get
            Return lblfilename.Text
        End Get
        Set(ByVal value As String)
            _FileName = value
            Call activatefile(_FileName)
            '            flddoc1.FileName = value
        End Set
    End Property
    Public Property FilePathHttp() As String
        Get
            If FileName.Trim <> "" Then
                Return getPath(True)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property FileName() As String
        Get
            Return lblfilename.Text
        End Get
        Set(ByVal value As String)
            _FileName = value
            Call activatefile(_FileName)
            '            flddoc1.FileName = value
        End Set
    End Property
    Private Function getPath(Optional ByVal pForHttp As Boolean = False) As String
        If AppCode.Trim = "" Then
            lbluploadstatus.Text = "Application not defined"
            Return ""
        End If

        If FormNamespace.Trim = "" Then
            lbluploadstatus.Text = "Namespace not defined"
            Return ""
        End If

        If UniqueID.Trim = "" Then
            lbluploadstatus.Text = "Invalid Unique ID"
            Return ""
        End If

        If (ConfigurationSettings.AppSettings("filespath") & "").Trim = "" Then
            lbluploadstatus.Text = "Document storage not defined"
            Return ""
        End If


        If pForHttp = False Then
            Return System.Configuration.ConfigurationSettings.AppSettings("filespath") & "\" & "WORKFLOW" & "\" & AppCode & "\" & FormNamespace & "\" & UniqueID & "\"
        Else
            Return System.Configuration.ConfigurationSettings.AppSettings("filespathhttp") & "WORKFLOW" & "/" & AppCode & "/" & FormNamespace & "/" & UniqueID & "/"
        End If


    End Function
    Public Sub uc_file1_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim counter As Integer = 0
        Dim ldocno As String = ""
        Dim strpath As String = getPath()
        Dim fileExt As String = ""
        Dim lfilename As String = ""
        Dim sSQL As String = ""
        lbluploadstatus.Text = ""


        If strpath.Trim = "" Then Exit Sub


        If (flddoc1.HasFile) = True Then


            Select Case Path.GetExtension(flddoc1.PostedFile.FileName).ToLower()
                Case ".exe", ".js", ".vbs", ".vb"
                    lbluploadstatus.Text = "Illegal file type"
                    Exit Sub

                Case Else

            End Select

        Else
            lbluploadstatus.Text = "Please select a document"
            Exit Sub
        End If
        Try


            'Dim flImages As HttpFileCollection = Request.Files
            Dim oldname As String = ""
            'For key As Integer = 0 To (flImages.Count - 1)
            '    Dim flfile As HttpPostedFile = flImages(key)
            '    If flfile.FileName <> "" Then
            '        If Directory.Exists(Server.MapPath(strpath)) = False Then
            '            Directory.CreateDirectory(Server.MapPath(strpath))
            '        End If
            '        fileExt = System.IO.Path.GetExtension(flfile.FileName)
            '        oldname = flfile.FileName.Replace(fileExt, "")
            '        lfilename = WebLib.getUniqueKey & fileExt
            '        flfile.SaveAs(Server.MapPath(strpath) & lfilename)
            '        'backend.saveUploaded(strpath, lfilename, oldname, _formucode, moduleName, doctype, fileExt, wfalevel)
            '    End If
            'Next


            If (flddoc1.HasFile) Then
                fileExt = System.IO.Path.GetExtension(flddoc1.FileName)
                oldname = flddoc1.FileName  '"text" & fileExt
                lfilename = WebLib.getUniqueKey() & fileExt


                If Directory.Exists(strpath) = False Then
                    Directory.CreateDirectory(strpath)

                End If

                flddoc1.PostedFile.SaveAs(strpath + lfilename)
                'backend.saveUploaded(strpath, lfilename, oldname, _formucode, moduleName, "", fileExt)
            End If

            Call activatefile(lfilename)
            backend.saveUploaded(FilePathHttp, lfilename, oldname, _formucode, moduleName, "", fileExt)
            loadpr()
        Catch Err As Exception
            lbluploadstatus.Text = Err.Message
        Finally

        End Try
    End Sub
    Public Sub DeleteDoc(ByVal lfilename As String)

        Dim counter As Integer = 0
        Dim ldocno As String = ""
        Dim strpath As String = getPath()
        Dim fileExt As String = ""

        Dim sSQL As String = ""

        If strpath.Trim = "" Then Exit Sub

        lbluploadstatus.Text = "File uploaded"
        ' lfilename = FileName


        Try


            If lfilename <> "" Then
                'If File.Exists(Server.MapPath(strpath) + lfilename) = True Then
                '    File.Delete(Server.MapPath(strpath) + lfilename)
                '    lbluploadstatus.Text = "File Deleted"
                '    Call activatefile("")
                'Else
                '    lbluploadstatus.Text = "File cannot be found "
                '    Call activatefile("")
                'End If

                If File.Exists(strpath + lfilename) = True Then
                    File.Delete(strpath + lfilename)
                    lbluploadstatus.Text = "File Deleted"
                    Call activatefile("")
                Else
                    lbluploadstatus.Text = "File cannot be found "
                    Call activatefile("")
                End If

            Else
                lbluploadstatus.Text = "No File Exists"
            End If

        Catch Err As Exception

            lbluploadstatus.Text = Err.Message

        Finally
            loadpr()
        End Try
    End Sub
    Private Sub activatefile(ByVal _p_FileName As String)
        ltimage.Text = ""

        If (_p_FileName & "").Trim = "" Then
            lblfilename.Text = ""
            '    btndelete.visible = False
            btnupload.Visible = True
            flddoc1.Visible = True

        Else
            lblfilename.Text = "" & _p_FileName & ""
            '   btndelete.visible = True
            '     btnupload.visible = False
            '    flddoc1.visible = False
            If Preview = True Then

                Dim strpath As String = FilePathHttp
                If strpath.Trim <> "" Then
                    '                    ltimage.text = "<div style=""overflow:hidden;height:" & Height & ";width:" & Width & """><img src=""" & strpath & lblfilename.text & """ width=""" & Width & """ height=""" & Height & """></div>"
                End If
            End If
        End If
    End Sub
End Class

