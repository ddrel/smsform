Imports System.Windows.Forms
Imports ATSMS

Public Class main



    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Private m_frmlogs As New frmlogs
    Private m_frmuserlist As New frmuserlist
    Private Sub main_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim restcon As New restcon("http://localhost:9080")



        Dim frminit As New frminit
        If frminit.ShowDialog = Windows.Forms.DialogResult.OK Then
            restcon.getusers(Function(dt)
                                 m_frmlogs.restcon = restcon
                                 m_frmuserlist.restcon = restcon
                                 m_frmlogs.gsmmain = frminit.gsmmain
                                 m_frmuserlist.gsmmain = frminit.gsmmain

                                 m_frmlogs.Show()
                                 m_frmuserlist.Show()

                                 m_frmlogs.MdiParent = Me
                                 m_frmuserlist.MdiParent = Me

                                 Me.LayoutMdi(MdiLayout.TileVertical)


                                 Return 0
                             End Function
                         )


            
        End If


        

    End Sub
End Class
