Imports ATSMS
Imports ATSMS.SMS
Imports ATSMS.Common
Imports System.Collections.Specialized

Public Class gsmmain
    Private WithEvents _objGSMModem As GSMModem
    Private msgIDs As Array
    Public Property PORT As String
    Public Event NewMessageReceived(e As ATSMS.NewMessageReceivedEventArgs)
    Public Event messageSent(ByVal gsmnumber As String, message As String, ByVal name As String)
    Public Property modemConnected As Boolean = False


    Public Sub New(ByVal port As String)
        _objGSMModem = New GSMModem
        Try
            If _objGSMModem.IsConnected Then _objGSMModem.Disconnect()
            _objGSMModem.Port = port
            _objGSMModem.BaudRate = 9600
            _objGSMModem.DataBits = 8
            _objGSMModem.Parity = EnumParity.None
            _objGSMModem.StopBits = EnumStopBits.One
            _objGSMModem.FlowControl = EnumFlowControl.RTS_CTS
            _objGSMModem.Connect()
            'MsgBox("Connected to " + _objGSMModem.Port, MsgBoxStyle.Information)
            port = _objGSMModem.Port
            _objGSMModem.Echo = False
            modemConnected = True
        Catch ex As GeneralException
            modemConnected = False
            MsgBox("Error connecting: " + ex.Message)
        End Try

    End Sub
    Public Function getMessages() As OrderedDictionary
        If _objGSMModem.IsConnected Then


            Dim msgStore As MessageStore = _objGSMModem.MessageStore
            _objGSMModem.MessageMemory = EnumMessageMemory.PHONE

            msgStore.Refresh()
            Dim dict As New OrderedDictionary
            Dim i As Integer
            For i = 0 To msgStore.Count - 1
                Dim sms As SMSMessage = msgStore.Message(i)
                dict.Add(i, sms)
            Next
            Return dict
        End If

        Return Nothing
    End Function
    Public Overloads Sub send(ByVal gsmnumber As String, message As String)
        If Len(gsmnumber) = 0 Then
            MsgBox("Please enter a phone number", MsgBoxStyle.Information)
            Exit Sub
        End If
        _objGSMModem.Encoding = EnumEncoding.GSM_Default_7Bit
        Dim msgId As String = _objGSMModem.SendSMS(gsmnumber, message)
        'msgIDs.SetValue(msgId, msgIDs.Length)
        RaiseEvent messageSent(gsmnumber, message, "")
    End Sub
    Public Overloads Sub send(ByVal gsmnumber As String, message As String, ByVal name As String)
        If Len(gsmnumber) = 0 Then
            MsgBox("Please enter a phone number", MsgBoxStyle.Information)
            Exit Sub
        End If
        _objGSMModem.Encoding = EnumEncoding.GSM_Default_7Bit
        Dim msgId As String = _objGSMModem.SendSMS(gsmnumber, message)
        'msgIDs.SetValue(msgId, msgIDs.Length)
        clearMessages()
        RaiseEvent messageSent(gsmnumber, message, name)
    End Sub
    Public Sub clearMessages()
        If _objGSMModem.IsConnected Then
            Dim msgStore As MessageStore = _objGSMModem.MessageStore
            _objGSMModem.MessageMemory = EnumMessageMemory.PHONE
            msgStore.Refresh()
            Dim i As Integer
            For i = 0 To msgStore.Count - 1
                Dim sms As SMSMessage = msgStore.Message(i)
                sms.Delete()
            Next

            Dim msgStoreSIM As MessageStore = _objGSMModem.MessageStore
            _objGSMModem.MessageMemory = EnumMessageMemory.SM

            msgStoreSIM.Refresh()
            Dim j As Integer
            For j = 0 To msgStore.Count - 1
                Dim sms As SMSMessage = msgStoreSIM.Message(j)
                sms.Delete()
            Next

        End If
    End Sub

    Private Sub _objGSMModem_NewMessageReceived(e As ATSMS.NewMessageReceivedEventArgs) Handles _objGSMModem.NewMessageReceived
        RaiseEvent NewMessageReceived(e)
    End Sub
End Class
