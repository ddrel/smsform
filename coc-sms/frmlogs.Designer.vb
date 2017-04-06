<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlogs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtlogs = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtlogs
        '
        Me.txtlogs.BackColor = System.Drawing.SystemColors.WindowText
        Me.txtlogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlogs.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtlogs.Location = New System.Drawing.Point(0, 0)
        Me.txtlogs.Multiline = True
        Me.txtlogs.Name = "txtlogs"
        Me.txtlogs.Size = New System.Drawing.Size(677, 340)
        Me.txtlogs.TabIndex = 0
        '
        'frmlogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 340)
        Me.Controls.Add(Me.txtlogs)
        Me.Name = "frmlogs"
        Me.Text = "SMS Activity"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtlogs As System.Windows.Forms.TextBox
End Class
