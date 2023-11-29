Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Public Class wbuilder_class
    Inherits listpage
    Private showtracking As Boolean = False
    'Generated by VI FEANDI SOFTLABS FORM GENERATOR (http://www.vifeandi.net) VER 2014.1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _searchkeystr = ""
        listingpage = "wlist.aspx"
        _FormsName = "Workflow Builder"
        'columnscount = "10"
        TableName = "workflowitems"
        DetailPage = "wd.aspx"
        IDPField = "wui_wid"
        IDField = "wui_id"
        AppIDField = ""
        MerchantIDField = ""
        FilterField = "wui_filter"
        Orderby = " order by isnull(wui_no,0) asc, wui_seq asc"
        '_pagesize = 20
        APPCode = "" '"SMS"
        AddRights = "" '"SM0001"
        DelRights = "" ' "SM0003"
        ModRights = "" '"SM0002"
        ViewRights = "" '"SM0004"
        FullRights = ""
        NmSpace = "workflowitems"
        pFieldNames = " * "
        pJoinFields = ""
        btnback.Visible = False

        showtracking = False

        If Page.IsPostBack = False Then
            pg.Value = Request("rc")
        End If
        If IsNumeric(pg.Value) = False Then
            pg.Value = 1
        End If

        _searchfilter = ""
        Call InitLoad()

        If Page.IsPostBack = False Then
            Call LoadDataHeader()
            viewmode.value = Request("da") & ""
            st.value = Request("st") & ""
            tc.value = Request("tc") & ""

        End If

        If Viewmode.value.trim = "T" Then
            showtracking = True
        Else
            showtracking = False
        End If

        Call LoadDataData()



    End Sub
    Private Sub assignname()
        _FormsName = "WORKFLOW : " & sname.Value
    End Sub
    Public Function LoadDataHeader() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        If IsNumeric(bid.Value) = False Then
            Exit Function
        End If

        Try
            cmd.CommandText = "Select * from [workflow] where wf_id=" & bid.Value
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1
                sname.Value = dr("wf_name") & ""
                Exit For
            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
            Call assignname()
        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Function
    Public Function LoadDataData() As Boolean
        Dim cn As New OleDbConnection(connectionstring)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()
        Dim counter As Integer = 0
        Dim dr As DataRow
        If IsNumeric(bid.Value) = False Then
            Exit Function
        End If

        Dim obj As ImageButton
        Dim lit As Literal
        Dim lwidth As String = "48px"
        Dim lheight As String = "48px"
        Dim isEnd As Boolean = False
        phMap.Controls.Clear()
        lit = New Literal
        lit.Text = "Start of Workflow<br>"
        lit.ID = "lit00S"
        phMap.Controls.Add(lit)


        obj = New ImageButton
        obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circlegreen.png")
        obj.Style.Add("width", lwidth)
        obj.Style.Add("height", lheight)
        phMap.Controls.Add(obj)



        lit = New Literal
        lit.Text = "<br>"
        phMap.Controls.Add(lit)

        obj = New ImageButton
        obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowdown.png")
        obj.Style.Add("width", lwidth)
        obj.Style.Add("height", lheight)
        phMap.Controls.Add(obj)

        lit = New Literal
        lit.Text = "<br>"
        phMap.Controls.Add(lit)


        Dim bStop As Boolean = False

        Try
            '            cmd.CommandText = "Select " & TableName & ".* from " & TableName & " where " & IDPField & "=" & bid.Value & " " & Orderby

            If showtracking = True Then
                cmd.CommandText = "Select " & TableName & ".*,workflowtrack.* from " & TableName & " left outer join workflowtrack on wui_merchantid = ws_merchantid and wui_filter = ws_filtercode and wui_no = ws_wno and wui_wid = ws_wid where wui_wid=" & bid.Value & " " & Orderby
            Else
                cmd.CommandText = "Select " & TableName & ".* from " & TableName & " where " & IDPField & "=" & bid.Value & " " & Orderby

            End If
            '            response.write(cmd.commandtext)
            '           response.end()
            cmd.Connection = cn
            ad.SelectCommand = cmd
            ad.Fill(ds, "datarecords")
            For Each dr In ds.Tables("datarecords").Rows
                counter = counter + 1

                '    obj = New ImageButton
                '   obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowleftyellow.png")
                '   obj.Style.Add("width", "48px")
                '   obj.Style.Add("height", "48px")
                '   phMap.Controls.Add(obj)


                lit = New Literal
                lit.Text = "<span><b>" & dr("wui_name") & "</b></span><br>"
                phMap.Controls.Add(lit)


                '******* Status



                If WebLib.BitToBoolean(dr("wui_cancel")) = True Then


                    obj = New ImageButton
                    Select Case dr("wui_cancelstep")
                        Case "1"
                            obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circleblue.png")
                        Case "3"
                            obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circlegreen.png")
                        Case Else
                            obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    End Select
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "LE"
                    phMap.Controls.Add(obj)

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowleftyellow.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "L"
                    phMap.Controls.Add(obj)
                Else

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "LE"
                    phMap.Controls.Add(obj)

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "L"
                    phMap.Controls.Add(obj)

                End If

                obj = New ImageButton
                obj.ImageUrl = WebLib.ClientURL("graphics/workflow/group.png")
                obj.Style.Add("width", lwidth)
                obj.Style.Add("height", lheight)
                obj.ID = "obj" & dr("wui_id")
                AddHandler obj.Click, AddressOf Me.image_Click

                phMap.Controls.Add(obj)

                If WebLib.BitToBoolean(dr("wui_reject")) = True Then

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowrightred.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "R"
                    phMap.Controls.Add(obj)



                    obj = New ImageButton
                    Select Case dr("wui_rejectstep")
                        Case "1"
                            obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circleblue.png")
                        Case "3"
                            obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circlegreen.png")
                        Case "4"
                            obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circleyellow.png")

                        Case Else
                            obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    End Select
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "RE"
                    phMap.Controls.Add(obj)

                Else
                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "R"
                    phMap.Controls.Add(obj)

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/misc/blank.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "RE"
                    phMap.Controls.Add(obj)
                End If

                lit = New Literal
                lit.Text = "<br>"
                phMap.Controls.Add(lit)


                obj = New ImageButton
                obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowdown.png")
                obj.Style.Add("width", "48px")
                obj.Style.Add("height", "48px")
                phMap.Controls.Add(obj)

                lit = New Literal
                lit.Text = "<br>"
                phMap.Controls.Add(lit)

                If dr("wui_approvestep") = "1" Then

                    obj = New ImageButton
                    obj.ImageUrl = WebLib.ClientURL("graphics/workflow/circleblue.png")
                    obj.Style.Add("width", lwidth)
                    obj.Style.Add("height", lheight)
                    obj.ID = "obj" & dr("wui_id") & "E"
                    phMap.Controls.Add(obj)

                    lit = New Literal
                    lit.Text = "<br>End of Workflow"
                    lit.ID = "lit00E"
                    phMap.Controls.Add(lit)

                    isEnd = True

                End If

                '               obj = New ImageButton
                '               obj.ImageUrl = WebLib.ClientURL("graphics/workflow/arrowdown.png")
                '               obj.Style.Add("width", "48px")
                '               obj.Style.Add("height", "48px")
                '               phMap.Controls.Add(obj)



            Next
            cn.Close()
            cmd.Dispose()
            cn.Dispose()

            If isEnd = False Then

                obj = New ImageButton
                obj.ImageUrl = WebLib.ClientURL("graphics/workflow/clickhere.png")
                obj.Style.Add("width", lwidth)
                obj.Style.Add("height", lheight)
                obj.ID = "obj"
                obj.AlternateText = "Click here to define next step"
                AddHandler obj.Click, AddressOf Me.image_Click
                phMap.Controls.Add(obj)




            End If


        Catch ex As Exception
            lblMessage.Text = WebLib.getAlertMessageStyle(ex.Message)
        End Try
    End Function
    Public Sub image_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lID As String = ""
        lID = sender.id.ToString.Replace("obj", "")
        Response.Redirect("postpage.aspx?NextPage=wbuilderd.aspx&ga=" & lID & "&ba=" & rid.Value)

    End Sub
End Class

