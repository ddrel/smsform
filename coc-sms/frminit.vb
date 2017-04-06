Public Class frminit
    Public Property gsmmain As gsmmain


    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        Dim _gsmmain = New gsmmain(Me.cboComPort.Text)


        If _gsmmain.modemConnected Then
            gsmmain = _gsmmain
            Me.DialogResult = DialogResult.OK
        End If
        


    End Sub
End Class