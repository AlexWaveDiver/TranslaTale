Public Class frmCreateGroup

    Public Const notSet As Integer = -2

    Public Function Popup() As Group
        Return Popup("Create group")
    End Function

    Public Function Popup(title As String) As Group
        Return Popup(title, New Group(notSet, "", Color.Green), "&Done")
    End Function

    Public Function Popup(title As String, group As Group) As Group
        Return Popup(title, group, "&Done")
    End Function

    Public Function Popup(title As String, group As Group, btnOk As String) As Group
        Return Popup(title, group, "&Cancel", btnOk)
    End Function

    Public Function Popup(title As String, group As Group, btnCancel As String, btnOk As String) As Group
        Me.Text = title
        Button1.Text = btnCancel
        Button2.Text = btnOk
        If group.numero = notSet Then
            For Each gruppo In CurrentSession.groups
                If gruppo.Value.numero > group.numero Then
                    group.numero = gruppo.Value.numero
                End If
            Next
            group.numero = group.numero + 1
        End If
        Panel1.BackColor = group.colore
        groupName.Text = group.name
        ShowDialog()
        If ok Then
            Return New Group(group.numero, groupName.Text, Panel1.BackColor)
        Else
            Return Nothing
        End If
    End Function

    Dim ok As Boolean = False
    Dim number As Integer
    Dim color As Color

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ok = True
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Panel1.BackColor = ColorDialog1.Color
        End If
    End Sub
End Class