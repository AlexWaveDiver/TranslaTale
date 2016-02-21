Public Class frmSelectGroup
    Public Function Popup(showDefaultGroup As Boolean, Optional buttonName As String = "&OK") As Integer
        gruppiBox.Items.Clear()
        If CurrentSession.groups.Count = 0 Then
            MsgBox("Non è disponibile nessun gruppo!", MsgBoxStyle.Exclamation, "TranslaTale")
            Return -1
        End If
        For Each group In CurrentSession.groups
            If Not (showDefaultGroup = False And group.Value.numero = -1) Then
                gruppiBox.Items.Add(group.Value.numero & " - " & group.Value.name)
            End If
        Next
        If gruppiBox.Items.Count <= 0 Then
            noGroups.Visible = True
        End If
        gruppiBox.SelectedIndex = gruppiBox.Items.Count - 1
        ShowDialog()
        If ok And gruppiBox.Items.Count > 0 Then
            Return Integer.Parse(gruppiBox.Text.Split(" - ").FirstOrDefault)
        Else
            Return -2
        End If
    End Function

    Dim ok As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ok = True
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class