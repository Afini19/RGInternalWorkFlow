<%@ WebHandler Language="VB" Class="JsonResponse" %>

Imports System
Imports System.Web
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.SessionState

Public Class JsonResponse
    Implements IHttpHandler,IRequiresSessionState

    Public Sub ProcessRequest(ByVal context As HttpContext)
        context.Response.ContentType = "application/json"
        Dim start As DateTime = New DateTime(1970, 1, 1)
        Dim [end] As DateTime = New DateTime(1970, 1, 1)
        'start = start.AddSeconds(Double.Parse(context.Request.QueryString("start")))
        '[end] = [end].AddSeconds(Double.Parse(context.Request.QueryString("end")))
        Dim result As String = String.Empty
        result += "["
        Dim idList As List(Of Integer) = New List(Of Integer)()

        Dim usercode As String = ""
        Dim status As String = ""
        Dim searchstr As String = ""

        If String.IsNullOrEmpty(context.Request.QueryString("usercode")) <> True Then
            usercode = context.Request.QueryString("usercode")
        End If
        If String.IsNullOrEmpty(context.Request.QueryString("status")) <> True Then
            status = context.Request.QueryString("status")
        End If
        If String.IsNullOrEmpty(context.Request.QueryString("phsearchstr")) <> True Then
            searchstr = context.Request.QueryString("phsearchstr")
        End If

        For Each cevent As CalendarEvent In backend.getEvents(usercode, status, searchstr)
            result += convertCalendarEventIntoString(cevent)
            idList.Add(cevent.id)
        Next

        If result.EndsWith(",") Then
            result = result.Substring(0, result.Length - 1)
        End If

        result += "]"
        context.Session("idList") = idList
        context.Response.Write(result)
    End Sub

    Private Function convertCalendarEventIntoString(ByVal cevent As CalendarEvent) As String
        Dim allDay As String = "true"

        If ConvertToTimestamp(cevent.start).ToString().Equals(ConvertToTimestamp(cevent.[end]).ToString()) Then
            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 Then
                allDay = "true"
            Else
                allDay = "false"
            End If
        Else
            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 AndAlso cevent.[end].Hour = 0 AndAlso cevent.[end].Minute = 0 AndAlso cevent.[end].Second = 0 Then
                allDay = "true"
            Else
                allDay = "false"
            End If
        End If
        Return "{" & """id""" & ": """ & cevent.id & """," & """usrid""" & ": """ & cevent.usrid & """," & """title""" & ": """ + HttpContext.Current.Server.HtmlEncode(cevent.title) & """," & """start""" & ":""" & ConvertToTimestamp(cevent.start).ToString() & """," & """end""" & ": """ & ConvertToTimestamp(cevent.[end]).ToString() & """," & """allDay""" & ":""" & allDay & """," & """description""" & ": """ + HttpContext.Current.Server.HtmlEncode(cevent.description) & """},"
    End Function

    Public ReadOnly Property IsReusable As Boolean
        Get
            Return False
        End Get
    End Property

    Private ReadOnly Property IHttpHandler_IsReusable As Boolean Implements IHttpHandler.IsReusable
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Private Function ConvertToTimestamp(ByVal value As DateTime) As Long
        Dim epoch As Long = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000
        Return epoch
    End Function

    Private Sub IHttpHandler_ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "application/json"
        Dim start As DateTime = New DateTime(1970, 1, 1)
        Dim [end] As DateTime = New DateTime(1970, 1, 1)
        Dim usercode As String = ""
        Dim status As String = ""
        Dim searchstr As String = ""

        If String.IsNullOrEmpty(context.Request.QueryString("usercode")) <> True Then
            usercode = context.Request.QueryString("usercode")
        End If
        If String.IsNullOrEmpty(context.Request.QueryString("status")) <> True Then
            status = context.Request.QueryString("status")
        End If
        If String.IsNullOrEmpty(context.Request.QueryString("phsearchstr")) <> True Then
            searchstr = context.Request.QueryString("phsearchstr")
        End If
        'start = start.AddSeconds(Double.Parse(context.Request.QueryString("start")))
        '[end] = [end].AddSeconds(Double.Parse(context.Request.QueryString("end")))
        Dim result As String = String.Empty
        result += "["
        Dim idList As List(Of Integer) = New List(Of Integer)()

        For Each cevent As CalendarEvent In backend.getEvents(usercode, status, searchstr)
            result += convertCalendarEventIntoString(cevent)
            idList.Add(cevent.id)
        Next

        If result.EndsWith(",") Then
            result = result.Substring(0, result.Length - 1)
        End If

        result += "]"
        context.Session("idList") = idList

        context.Response.Write(result)
    End Sub
End Class
