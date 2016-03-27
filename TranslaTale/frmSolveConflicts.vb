Public Class frmSolveConflicts
    Private Sub frmSolveConflicts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstConflicts.View = View.Details
        lstConflicts.Clear()
        lstConflicts.ShowGroups = False
        lstConflicts.Columns.Clear()
        lstConflicts.Columns.Add("Line #", 60, HorizontalAlignment.Center)
        lstConflicts.Columns.Add("Translation Line", CInt((lstConflicts.Width - 60) / 2), HorizontalAlignment.Center)
        lstConflicts.Columns.Add("Additional Line", CInt((lstConflicts.Width - 60) / 2), HorizontalAlignment.Center)

        With frmFileMerge
            For i As Integer = 0 To .conflictList.Count - 1
                lstConflicts.Items.Add(New ListViewItem({ .conflictList(i), .translatedFile(.conflictList(i)), .thirdFile(.conflictList(i))}))
            Next
        End With
    End Sub

    Private Sub frmSolveConflicts_Resize(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        With lstConflicts
            .Columns(1).Width = CInt((lstConflicts.Width - 60) / 2)
            .Columns(2).Width = CInt((lstConflicts.Width - 60) / 2) - 5
        End With
    End Sub

    Private Sub btnThird_Click(sender As Object, e As EventArgs) Handles btnThird.Click
        If (lstConflicts.SelectedItems.Count > 0) Then
            For Each item In lstConflicts.SelectedItems
                frmFileMerge.exportBuffer(CInt(item.SubItems(0).Text)) = (item.SubItems(2).Text)
                item.Remove()
            Next

            If lstConflicts.Items.Count = 0 Then
                frmFileMerge.finishUp()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnTransl_Click(sender As Object, e As EventArgs) Handles btnTransl.Click
        If (lstConflicts.SelectedItems.Count > 0) Then
            For Each item In lstConflicts.SelectedItems
                frmFileMerge.exportBuffer(CInt(item.SubItems(0).Text)) = (item.SubItems(1).Text)
                item.Remove()
            Next

            If lstConflicts.Items.Count = 0 Then
                frmFileMerge.finishUp()
                Me.Close()
            End If
        End If
    End Sub
End Class