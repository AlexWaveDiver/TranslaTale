Public Class frmGoTo

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLineNumber.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If Asc(e.KeyChar) = 13 Then
            btnJump.PerformClick()
        End If
    End Sub

    Private Sub btnJump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJump.Click
        If txtLineNumber.Text <> "" Then
            Dim line As Integer = Convert.ToInt16(txtLineNumber.Text)
            If frmMain.ttipTotal.Text < line Then
                MsgBox("Line " + line.ToString + " not found", vbInformation)
            Else
                Dim lvItem As ListViewItem

                For Each lvItem In frmMain.ListView1.Items
                    lvItem.Checked = False
                Next

                frmMain.ListView1.SelectedItems().Clear()
                frmMain.ListView1.Items(line - 1).Selected = True
                frmMain.ListView1.EnsureVisible(line - 1)
                frmMain.ListView1.Focus()
                If frmMain.ListView1.SelectedItems(0) IsNot Nothing Then
                    Dim val As String = frmMain.ListView1.Items(line - 1).SubItems(2).Text
                    frmMain.showText(val)
                    frmMain.TextBox1.Text = val
                End If
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmGoTo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtLineNumber.Focus()
    End Sub

    Private Sub txtLineNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineNumber.TextChanged
        If txtLineNumber.Text.Length > 0 Then
            btnJump.Enabled = True
        Else
            btnJump.Enabled = False
        End If
    End Sub
End Class