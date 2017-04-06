Imports ATSMS.Common
Imports ATSMS.SMS
Imports System.Collections.Specialized

Public Class frmlogs
    Public Property restcon As restcon
    Public Property gsmmain As gsmmain
    Private Event evt_gsm_messageSent(gsmnumber As String, message As String, name As String)
    Private Event evt_gsm_NewMessageReceived(e As ATSMS.NewMessageReceivedEventArgs)

    Private Sub frmlogs_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AddHandler gsmmain.messageSent, AddressOf gsm_messageSent
        AddHandler gsmmain.NewMessageReceived, AddressOf gsm_NewMessageReceived
        AddHandler restcon.onrestStatus, AddressOf onrestStatus


        loadMessageInit()
    End Sub
    Private Sub loadMessageInit()
        Dim smsg As OrderedDictionary = gsmmain.getMessages()
        If smsg.Count > 0 Then
            recursiveloadMessages(smsg, smsg.Count - 1)
            'now delete
            For Each sms As SMSMessage In smsg
                ' sms.Delete()
            Next
        End If
    End Sub
    Private Sub recursiveloadMessages(smsg, index)
        Dim sms As SMSMessage = smsg(index)
        If sms.Text.ToString.ToLower.IndexOf("coc") > -1 Then
            Dim mobile As String = sms.PhoneNumber.Substring(3)
            Dim drs As DataRow() = restcon.DTUSERS.Select("mobile like'%" & mobile & "%'")


            If drs.Length > 0 Then
                Dim objRow As DataRow = drs(0)

                restcon.getmosquitoactivity(objRow("lat") & "," & objRow("lng"),
                                    objRow("location_key"), Function(forecast)
                                                                Dim msg As String = ""
                                                                If forecast.Forecast1 = "" And forecast.Forecast2 = "" Then
                                                                    msg = "Server error please try again..." & vbCrLf
                                                                Else
                                                                    msg = "Mosquito Activity : " & forecast.Eveningforecast & "   " & forecast.Forecast1 & "  " & forecast.Forecast2 & vbCrLf
                                                                End If
                                                                gsmmain.send(sms.PhoneNumber, msg, objRow("name"))
                                                                sms.Delete()
                                                                smsg.RemoveAt(smsg.Count - 1)
                                                                If (smsg.Count > 0) Then
                                                                    recursiveloadMessages(smsg, smsg.Count)
                                                                End If
                                                                Return 0
                                                            End Function)

            End If
        End If

    End Sub

    Private Sub onrestStatus(ByVal msg As String)
        Dim msgrest As String = ">> " & msg & vbCrLf
        If Me.txtlogs.InvokeRequired Then
            Me.txtlogs.Invoke(New dlgWriteLogs(AddressOf writelogs), msgrest)
        Else
            writelogs(msgrest)
        End If
    End Sub
    Private Sub gsm_messageSent(gsmnumber As String, message As String, name As String)
        Dim msgrest As String = ">> " & "Notification sent to: " & name & " (" & gsmnumber & ")  --- " & message & vbCrLf
        If Me.txtlogs.InvokeRequired Then
            Me.txtlogs.Invoke(New dlgWriteLogs(AddressOf writelogs), msgrest)
        Else
            writelogs(msgrest)
        End If
    End Sub
    Private Delegate Sub dlgWriteLogs(ByVal w As String)
    Private Sub writelogs(ByVal w As String)
        txtlogs.Text += w
    End Sub
    Private Sub replyfrom(ByVal mobile As String)
        Dim drs() As DataRow = restcon.DTUSERS.Select("mobile like'%" & mobile.ToString.Substring(3) & "'")
        If drs.Length = 0 Then
            Exit Sub
        End If

        Dim objRow As DataRow = drs(0)
        restcon.getmosquitoactivity(objRow("lat") & "," & objRow("lng"),
                                       objRow("location_key"), Function(forecast)
                                                                   Dim msg As String = ""
                                                                   If forecast.Forecast1 = "" And forecast.Forecast2 = "" Then
                                                                       msg = "Server error please try again..." & vbCrLf
                                                                   Else
                                                                       msg = "Mosquito Activity : " & forecast.Eveningforecast & "   " & forecast.Forecast1 & "  " & forecast.Forecast2 & vbCrLf
                                                                   End If

                                                                   gsmmain.send(mobile, msg, objRow("name"))
                                                                   gsmmain.clearMessages()
                                                                   Return 0
                                                               End Function)

    End Sub

    Private Sub gsm_NewMessageReceived(e As ATSMS.NewMessageReceivedEventArgs)
        Dim msg As String = ">> Received msg from: " & e.MSISDN & " | Message: " & e.TextMessage & " | Time Stamp: " & CDate(e.Timestamp).ToString & vbCrLf
        If Me.txtlogs.InvokeRequired Then
            Me.txtlogs.Invoke(New dlgWriteLogs(AddressOf writelogs), msg)
        Else
            writelogs(msg)
        End If


        If e.TextMessage.ToLower.IndexOf("coc") > -1 Then
            replyfrom(e.MSISDN)
        End If

        gsmmain.clearMessages()
    End Sub



End Class