Imports System.Collections.Specialized

Public Class frmuserlist
    Public Property restcon As restcon
    Public Property gsmmain As gsmmain



    Private _bdsUserlist As New BindingSource
    Private Function sendSMStouser(objRow As DataRow, forecast As MosquitoForecast) As Byte
        If forecast.Forecast1 = "" And forecast.Forecast2 = "" Then Return 0
        Dim drs() As DataRow = restcon.DTUSERS.Select("location_key='" & objRow("location_key") + "'")
        For Each dr In drs
            Dim msg As String = "Mosquito Activity : " & forecast.Eveningforecast & "   " & forecast.Forecast1 & "  " & forecast.Forecast2
            gsmmain.send(dr("mobile"), msg, dr("name"))
            gsmmain.clearMessages()
        Next

        Return 1
    End Function
    Private Sub recursiveRequest(ByVal dic As OrderedDictionary, ByVal index As Integer)
        Dim objRow As DataRow = dic(index)
        restcon.getmosquitoactivity(objRow("lat") & "," & objRow("lng"),
                                        objRow("location_key"), Function(forecast)
                                                                    sendSMStouser(objRow, forecast)
                                                                    Dim xint As Integer = index + 1
                                                                    If xint < dic.Count Then
                                                                        recursiveRequest(dic, xint)
                                                                        Me.btnsend.Enabled = True
                                                                    End If
                                                                    Return 0
                                                                End Function)
    End Sub


    Private Sub sendNotification()
        Dim ht As New Hashtable
        Dim dict As New OrderedDictionary

        For Each row In restcon.DTUSERS.Rows
            If Not dict.Contains(row("location_key")) Then                
                dict.Add(row("location_key"), row)
            End If
        Next

        Me.btnsend.Enabled = False
        recursiveRequest(dict, 0)

        'For Each objRow As DataRow In ht.Values
        '    Dim row = objRow
        '    restcon.getmosquitoactivity(objRow("lat") & "," & objRow("lng"),
        '                                objRow("location_key"), Function(forecast)
        '                                                            Return sendSMStouser(row, forecast)
        '                                                        End Function)

        'Next



    End Sub

    Private Sub frmuserlist_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _bdsUserlist.DataSource = restcon.DTUSERS
        Me.dtguser.DataSource = _bdsUserlist
    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        _bdsUserlist.DataSource = Nothing
        restcon.getusers(Function(dt)
                             _bdsUserlist.DataSource = dt
                             Return 0
                         End Function)

    End Sub
    Private Sub btnsend_Click(sender As System.Object, e As System.EventArgs) Handles btnsend.Click
        sendNotification()
    End Sub
End Class