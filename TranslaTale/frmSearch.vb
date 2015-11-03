Public Class frmSearch

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim searchTo As Integer = 1

        If rbbase.Checked = True Then
            searchTo = 0
        End If
        If rbtranslation.Checked = True Then
            searchTo = 1
        End If
        If rbboth.Checked = True Then
            searchTo = 2
        End If

        My.Settings.caseSensitive = Convert.ToInt16(cbCS.CheckState)
        'My.Settings.ignoreFormat = Convert.ToInt16(cbIgnore.CheckState)
        My.Settings.searchType = searchTo
        My.Settings.lastSearch = txtSearch.Text
        My.Settings.Save()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.searchType = 0 Then
            rbbase.Checked = True
        End If
        If My.Settings.searchType = 1 Then
            rbtranslation.Checked = True
        End If
        If My.Settings.searchType = 2 Then
            rbboth.Checked = True
        End If

        cbCS.CheckState = Convert.ToBoolean(My.Settings.caseSensitive)
        'cbIgnore.CheckState = Convert.ToBoolean(My.Settings.ignoreFormat)
        txtSearch.Text = My.Settings.lastSearch

    End Sub
End Class