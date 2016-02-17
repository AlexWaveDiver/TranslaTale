Imports System.Xml

Public Class frmBookmarks
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim line As Integer
        If lstBookmarks.SelectedItems.Count > 0 Then
            line = Convert.ToInt16(lstBookmarks.SelectedItems(0).SubItems(0).Text)
        Else
            Exit Sub
        End If

        If frmMain.ttipTotal.Text < Convert.ToInt16(lstBookmarks.SelectedItems(0).SubItems(0).Text) Then
            MsgBox("Line " + line.ToString + " not found", vbInformation)
        Else
            frmMain.lstStrings.SelectedItems().Clear()
            frmMain.lstStrings.Items(line - 1).Selected = True
            frmMain.lstStrings.EnsureVisible(line - 1)
            frmMain.lstStrings.Focus()
            If frmMain.lstStrings.SelectedItems(0) IsNot Nothing Then
                Dim val As String = frmMain.lstStrings.Items(line - 1).SubItems(2).Text
                frmMain.TextBox1.Text = val
                frmMain.ShowText(val)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub frmBookmarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bookmarks As System.Xml.XmlNodeList = GetBookmarks()
        lstBookmarks.View = View.Details
        lstBookmarks.Clear()
        lstBookmarks.ShowGroups = False
        lstBookmarks.Columns.Clear()
        lstBookmarks.Columns.Add("Line", 100, HorizontalAlignment.Left)
        lstBookmarks.Columns.Add("Tag", 150, HorizontalAlignment.Left)

        lstBookmarks.HideSelection = True
        lstBookmarks.FullRowSelect = True
        lstBookmarks.CheckBoxes = False
        lstBookmarks.OwnerDraw = False

        With lstBookmarks
            .Columns(0).Width = CInt(.Width * 0.2)
            .Columns(1).Width = CInt(.Width * 0.8)
        End With

        If bookmarks.Count > 0 Then
            btnOk.Enabled = True
            btnRemove.Enabled = True
            For Each bookmark As XmlElement In bookmarks
                Dim itemToAdd As New ListViewItem({bookmark.SelectSingleNode("page").InnerText, bookmark.SelectSingleNode("tag").InnerText})
                lstBookmarks.Items.Add(itemToAdd)
            Next
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstBookmarks.SelectedItems.Count > 0 Then
            Dim selected As Integer = lstBookmarks.SelectedItems(0).Index
            Dim label As String = lstBookmarks.SelectedItems(0).SubItems(1).Text
            Dim stat As Integer = MsgBox("Do you want to delete """ + label + """?", vbYesNo + vbInformation)
            If stat = 6 Then
                lstBookmarks.Items.Remove(lstBookmarks.Items(selected))
                DeleteBookmark(selected + 1)
            End If
        End If
        Dim bookmarks As System.Xml.XmlNodeList = GetBookmarks()
        If bookmarks.Count < 1 Then
            btnOk.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        sfdExport.Title = "Bookmarks exporting"

        If sfdExport.ShowDialog() = DialogResult.OK Then
            Dim W As IO.StreamWriter
            W = New IO.StreamWriter(sfdExport.FileName)

            W.Write(My.Settings.Bookmarks.ToString)
            W.Close()
        End If
    End Sub
End Class