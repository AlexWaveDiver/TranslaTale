Public Class frmSearch
    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.ShowGroups = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Line", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        ListView1.HideSelection = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = False
        ListView1.OwnerDraw = False
        With ListView1
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.45)
            .Columns(2).Width = CInt(.Width * 0.45)
        End With
        cbIgnoreFormat.Checked = My.Settings.dofiltertext
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.ShowGroups = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Line", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        ListView1.HideSelection = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = False
        ListView1.OwnerDraw = False
        With ListView1
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.45)
            .Columns(2).Width = CInt(.Width * 0.45)
        End With

        Dim searchIn As String = "base"
        Dim searchTerm As String = txtSearch.Text
        If rdBase.Checked = True Then
            searchIn = "base"
        End If
        If rdTranslation.Checked = True Then
            searchIn = "translation"
        End If
        If rdBoth.Checked = True Then
            searchIn = "both"
        End If

        For Each item As KeyValuePair(Of Integer, LineDouble) In CurrentSession.lines
            Dim sub1 As String = item.Value.originalText
            Dim sub2 As String = item.Value.translatedText

            Dim strLineNumber = item.Key + 1
            Dim strBase = item.Value.originalText
            Dim strTranslation = item.Value.translatedText

            If chkIgnoreCase.Checked = False Then
                sub1 = sub1.ToLower
                sub2 = sub2.ToLower
                searchTerm = searchTerm.ToLower
            End If

            If cbIgnoreFormat.Checked = True Then
                sub1 = sub1.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
                sub2 = sub2.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
                searchTerm = searchTerm.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")
            End If
            strBase = frmMain.FilterText(strBase, False, cbIgnoreFormat.Checked)
            strTranslation = frmMain.FilterText(strTranslation, False, cbIgnoreFormat.Checked)
            Select Case searchIn
                Case "base"
                    If sub1.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        ListView1.Items.Add(itemToAdd)
                    End If
                Case "translation"
                    If sub2.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        ListView1.Items.Add(itemToAdd)
                    End If
                Case "both"
                    If sub1.Contains(searchTerm) Or sub2.Contains(searchTerm) Then
                        Dim itemToAdd As New ListViewItem({strLineNumber, strBase, strTranslation})
                        ListView1.Items.Add(itemToAdd)
                    End If
            End Select
            If ListView1.Items.Count > 0 Then
                ListView1.Enabled = True
            Else
                ListView1.Enabled = False
            End If
        Next
    End Sub

    Private Sub frmSearch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtSearch.Focus()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If (frmMain.filtro <> frmMain.Efiltro.Default_mode) Then
            frmMain.filtro = frmMain.Efiltro.Default_mode
            frmMain.filtroGruppo = 0
            frmMain.Ricalcola()
        End If
        Dim line As Integer = ListView1.SelectedItems(0).Text
        For Each item As ListViewItem In frmMain.stringsPnl.Items
            If item.Text = line.ToString Then
                frmMain.stringsPnl.SelectedItems().Clear()
                item.Selected = True
                item.EnsureVisible()
                frmMain.stringsPnl.Focus()
                If frmMain.stringsPnl.SelectedItems(0) IsNot Nothing Then
                    Dim val As String = frmMain.stringsPnl.Items(line - 1).SubItems(2).Text
                    frmMain.showText(val)
                    frmMain.stringTextEditor.Text = val
                End If
                Exit Sub
            End If
        Next

    End Sub
End Class