Public Class frmGoTo

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If Asc(e.KeyChar) = 13 Then
            btnJump.PerformClick()
        End If
    End Sub

    Dim chiudicercando As Boolean = False

    Public Function PopupGoTo() As Integer
        ShowDialog()
        If chiudicercando Then
            Return NumericUpDown1.Value
        Else
            Return -1
        End If
    End Function

    Private Sub btnJump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJump.Click
        chiudicercando = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmGoTo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        NumericUpDown1.Focus()
        NumericUpDown1.Maximum = Int32.MaxValue - 1
    End Sub
End Class