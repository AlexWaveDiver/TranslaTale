Public Class frmSearch
    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstSearchResults.View = View.Details
        lstSearchResults.Clear()
        lstSearchResults.ShowGroups = False
        lstSearchResults.Columns.Clear()
        lstSearchResults.Columns.Add("Line", 100, HorizontalAlignment.Left)
        lstSearchResults.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        lstSearchResults.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        lstSearchResults.HideSelection = True
        lstSearchResults.FullRowSelect = True
        lstSearchResults.CheckBoxes = False
        lstSearchResults.OwnerDraw = False
        With lstSearchResults
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.45)
            .Columns(2).Width = CInt(.Width * 0.45)
        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lstSearchResults.View = View.Details
        lstSearchResults.Clear()
        lstSearchResults.ShowGroups = False
        lstSearchResults.Columns.Clear()
        lstSearchResults.Columns.Add("Line", 100, HorizontalAlignment.Left)
        lstSearchResults.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        lstSearchResults.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        lstSearchResults.HideSelection = True
        lstSearchResults.FullRowSelect = True
        lstSearchResults.CheckBoxes = False
        lstSearchResults.OwnerDraw = False
        With lstSearchResults
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.45)
            .Columns(2).Width = CInt(.Width * 0.45)
        End With

        Dim searchIn As String = "base"
        Dim searchTerm As String = txtSearch.Text
        If rbBase.Checked = True Then
            searchIn = "base"
        End If
        If rbTranslation.Checked = True Then
            searchIn = "translation"
        End If
        If rbBoth.Checked = True Then
            searchIn = "both"
        End If

        For Each item As ListViewItem In frmMain.lstStrings.Items
            Dim sub1 As String = item.SubItems(1).Text
            Dim sub2 As String = item.SubItems(2).Text

            Dim strLineNumber = frmMain.lstStrings.Items(item.Index).SubItems(0).Text
            Dim strBase = frmMain.lstStrings.Items(item.Index).SubItems(1).Text
            Dim strTranslation = frmMain.lstStrings.Items(item.Index).SubItems(2).Text

            If chkIgnoreCase.Checked = False Then
                sub1 = sub1.ToLower
                sub2 = sub2.ToLower
                searchTerm = searchTerm.ToLower
            End If

            'If cbIgnoreFormat.Checked = True Then
            '    sub1 = sub1.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
            '    sub2 = sub2.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
            '    searchTerm = searchTerm.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
            'End If

            Select Case searchIn
                Case "base"
                    If sub1.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        lstSearchResults.Items.Add(itemToAdd)
                    End If
                Case "translation"
                    If sub2.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        lstSearchResults.Items.Add(itemToAdd)
                    End If
                Case "both"
                    If sub1.Contains(searchTerm) Or sub2.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        lstSearchResults.Items.Add(itemToAdd)
                    End If
            End Select
            If lstSearchResults.Items.Count > 0 Then
                lstSearchResults.Enabled = True
            Else
                lstSearchResults.Enabled = False
            End If
        Next
    End Sub

    Private Sub frmSearch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtSearch.Focus()
    End Sub

    Private Sub lstSearchResults_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSearchResults.Click
        If lstSearchResults.Items.Count > 0 Then
            Dim line As Integer = Convert.ToInt16(lstSearchResults.SelectedItems(0).SubItems(0).Text)
            If frmMain.ttipTotal.Text < line Then
                MsgBox("Line " + line.ToString + " not found", vbInformation)
            Else
                frmMain.lstStrings.SelectedItems().Clear()
                frmMain.lstStrings.Items(line - 1).Selected = True
                frmMain.lstStrings.EnsureVisible(line - 1)
                frmMain.lstStrings.Focus()
                If frmMain.lstStrings.SelectedItems(0) IsNot Nothing Then
                    Dim val As String = frmMain.lstStrings.Items(line - 1).SubItems(2).Text
                    frmMain.ShowText(val)
                    frmMain.TextBox1.Text = val
                End If
            End If
        End If
    End Sub

    Private Sub cbIgnoreFormat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIgnoreFormat.CheckedChanged

    End Sub
End Class