Imports System.IO

Public Class frmCompare
    Dim dataitems As List(Of LineCompare) = New List(Of LineCompare)
    Dim fileslength As Integer() = New Integer() {0, 0}
    Dim files As TranslataleFile() = New TranslataleFile() {Nothing, Nothing}

    Private Sub CheckedListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles StringsList.DragEnter
        If Not e.Data.GetFormats(False).Contains(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.None
        Else
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            If Path.HasExtension(files.FirstOrDefault) And (Path.GetExtension(files.FirstOrDefault) = ".txt" Or Path.GetExtension(files.FirstOrDefault) = ".ttx") Then
                e.Effect = DragDropEffects.Link
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub CheckedListBox1_DragDrop(sender As ListView, e As DragEventArgs) Handles StringsList.DragDrop
        Dim numerofile As UInt16 = 0
        If e.X - PointToScreen(sender.Location).X >= sender.Width / 2 Then
            numerofile = 1
        End If
        AggiungiFile(numerofile, e)
    End Sub


    Private Sub AggiungiFile(numerofile As UInt16, e As DragEventArgs)
        Dim droppedfiles() As String = e.Data.GetData(DataFormats.FileDrop)
        If Path.GetExtension(droppedfiles.FirstOrDefault) = ".txt" Then
            Dim filetxt As String() = File.ReadAllLines(droppedfiles.FirstOrDefault)
            If (numerofile = 0) Then
                If fileslength(0) > filetxt.Length Then
                    If (filetxt.Length < fileslength(1)) Then
                        dataitems.RemoveRange(fileslength(1), fileslength(0) - fileslength(1))
                    Else
                        dataitems.RemoveRange(filetxt.Length, fileslength(0) - filetxt.Length)
                    End If
                End If
                For index = 0 To filetxt.Length - 1
                    If dataitems.Count <= index Then
                        dataitems.Add(New LineCompare(index, filetxt(index)))
                    Else
                        dataitems.Item(index).textLeft = filetxt(index)
                    End If
                Next
            Else
                If fileslength(1) > filetxt.Length Then
                    If (filetxt.Length < fileslength(0)) Then
                        dataitems.RemoveRange(fileslength(0), fileslength(1) - fileslength(0))
                    Else
                        dataitems.RemoveRange(filetxt.Length, fileslength(1) - filetxt.Length)
                    End If
                End If
                For index = 0 To filetxt.Length - 1
                    If dataitems.Count <= index Then
                        dataitems.Add(New LineCompare(index, vbNullString, filetxt(index)))
                    Else
                        dataitems.Item(index).textRight = filetxt(index)
                    End If
                Next
            End If
            fileslength(numerofile) = filetxt.Length
            files(numerofile) = Nothing
        Else
            Dim ttf As TranslataleFile = TranslataleFile.Load(droppedfiles.FirstOrDefault)
            If (numerofile = 0) Then
                If fileslength(0) > ttf.NumeroRighe Then
                    If (ttf.NumeroRighe < fileslength(1)) Then
                        dataitems.RemoveRange(fileslength(1), fileslength(0) - fileslength(1))
                    Else
                        dataitems.RemoveRange(ttf.NumeroRighe, fileslength(0) - ttf.NumeroRighe)
                    End If
                End If
                For index = 0 To ttf.NumeroRighe - 1
                    If dataitems.Count <= index Then
                        dataitems.Add(New LineCompare(index, New LineSingle(ttf.lines(index).translatedText, ttf.lines(index).group), ttf.groups(ttf.lines(index).group)))
                    Else
                        dataitems.Item(index).textLeft = ttf.lines(index).translatedText
                        dataitems.Item(index).groupLeft = ttf.groups(ttf.lines(index).group)
                    End If
                Next
            Else
                If fileslength(1) > ttf.NumeroRighe Then
                    If (ttf.NumeroRighe < fileslength(0)) Then
                        dataitems.RemoveRange(fileslength(0), fileslength(1) - fileslength(0))
                    Else
                        dataitems.RemoveRange(ttf.NumeroRighe, fileslength(1) - ttf.NumeroRighe)
                    End If
                End If
                For index = 0 To ttf.NumeroRighe - 1
                    If dataitems.Count <= index Then
                        dataitems.Add(New LineCompare(index, New LineSingle(vbNullString, -1), New Group(-1, "Default"), New LineSingle(ttf.lines(index).translatedText, ttf.lines(index).group), ttf.groups(ttf.lines(index).group)))
                    Else
                        dataitems.Item(index).textRight = ttf.lines(index).translatedText
                        dataitems.Item(index).groupRight = ttf.groups(ttf.lines(index).group)
                    End If
                Next
            End If
            fileslength(numerofile) = ttf.NumeroRighe
            files(numerofile) = ttf
        End If
        If numerofile = 0 Then
            StringsList.Columns(1).Text = Path.GetFileName(droppedfiles.FirstOrDefault)
        Else
            StringsList.Columns(4).Text = Path.GetFileName(droppedfiles.FirstOrDefault)
        End If
        AggiornaTabelle()
    End Sub

    Private Sub AggiornaTabelle()
        StringsList.Items.Clear()

        Dim listindex As Integer = 0
        For index = 0 To dataitems.Count - 1 Step 1
            Dim lin As LineCompare = dataitems.Item(index)
            If (lin.textLeft <> lin.textRight) And lin.textLeft <> vbNullString And lin.textRight <> vbNullString Then
                If lin.selectedText <> Trilean.First Then
                    lin.selectedText = Trilean.First
                End If
                StringsList.Items.Add(lin.number + 1)
                StringsList.Items(listindex).SubItems.AddRange(New String() {lin.textLeft, IIf(lin.selectedText = Trilean.First, "☑", "☐"), IIf(lin.selectedText = Trilean.Second, "☑", "☐"), lin.textRight})
                listindex += 1
            Else
                If lin.selectedText <> Trilean.Nothing_ Then
                    lin.selectedText = Trilean.Nothing_
                End If
            End If
        Next
        If fileslength(0) > 0 And fileslength(1) > 0 Then
            SaveButton.Enabled = True
        End If
    End Sub
    Private Sub TODOitemclick(sender As CheckedListBox, e As ItemCheckEventArgs)
        For Each item As LineCompare In dataitems
            Dim itemdata As Integer = Integer.Parse(sender.Items.Item(e.Index).ToString.Split(")").FirstOrDefault) - 1
            If item.number.ToString = itemdata Then
                If e.NewValue = CheckState.Indeterminate Then
                    e.NewValue = CheckState.Checked
                End If

                If e.NewValue = CheckState.Checked Then
                    item.selectedText = Trilean.First
                Else
                    item.selectedText = Trilean.Second
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub AllElementsOfTheFirstFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllElementsOfTheFirstFileToolStripMenuItem.Click
        For index2 = 0 To StringsList.Items.Count - 1 Step 1
            Dim lin As LineCompare = dataitems.Item(StringsList.Items(index2).Text - 1)
            lin.selectedText = Trilean.First
            StringsList.Items(index2).SubItems(2).Text = IIf(lin.selectedText = Trilean.First, "☑", "☐")
            StringsList.Items(index2).SubItems(3).Text = IIf(lin.selectedText = Trilean.Second, "☑", "☐")
        Next
    End Sub

    Private Sub AllElementsOfTheSecondFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllElementsOfTheSecondFileToolStripMenuItem.Click
        For index2 = 0 To StringsList.Items.Count - 1 Step 1
            Dim lin As LineCompare = dataitems.Item(StringsList.Items(index2).Text - 1)
            lin.selectedText = Trilean.Second
            StringsList.Items(index2).SubItems(2).Text = IIf(lin.selectedText = Trilean.First, "☑", "☐")
            StringsList.Items(index2).SubItems(3).Text = IIf(lin.selectedText = Trilean.Second, "☑", "☐")
        Next
    End Sub

    Private Sub SaveButton_ButtonClick(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim result As DialogResult = SaveFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            If Path.GetExtension(SaveFileDialog1.FileName) = ".txt" Then
                Dim output As String = ""
                For index = 0 To dataitems.Count - 1 Step 1
                    If index > 0 Then
                        output += vbCrLf
                    End If
                    Dim lin As LineCompare = dataitems.Item(index)
                    If lin.selectedText = Trilean.First Then
                        output += lin.textLeft
                    ElseIf lin.selectedText = Trilean.Second Then
                        output += lin.textRight
                    ElseIf lin.selectedText = Trilean.Nothing_ Then

                        If lin.textLeft <> vbNullString Then
                            output += lin.textLeft
                        ElseIf lin.textRight <> vbNullString Then
                            output += lin.textRight
                        Else
                            output += ""
                        End If
                    End If
                Next
                If File.Exists(SaveFileDialog1.FileName) Then
                    Try
                        File.Delete(SaveFileDialog1.FileName)
                        File.WriteAllText(SaveFileDialog1.FileName, output)
                        MsgBox("Saved!", vbInformation)
                    Catch ex As Exception
                        MsgBox("Can't overwrite the file. Please close all the applications that uses this file.", vbCritical)
                    End Try
                End If
            Else
                Dim outfile As TranslataleFile
                Dim outfilenumb As UInt16 = 0
                If (IsNothing(files(0)) Or File2ToolStripMenuItem.Tag = "yes") And Not IsNothing(files(1)) Then
                    'File 0
                    outfile = files(0)
                    outfilenumb = 0
                ElseIf (IsNothing(files(1)) Or File1ToolStripMenuItem.Tag = "yes") And Not IsNothing(files(0)) Then
                    'File 1
                    outfile = files(1)
                    outfilenumb = 1
                Else
                    MsgBox("Can't save in this format! You must have at lease one .ttx file!", vbCritical)
                    Return
                End If
                For index = 0 To dataitems.Count - 1 Step 1
                    Dim lin As LineCompare = dataitems.Item(index)
                    Dim linstr As String = ""
                    Dim lingroup As Short = -1
                    If lin.selectedText = Trilean.First Then
                        linstr = lin.textLeft
                        If outfilenumb = 0 Then
                            lingroup = lin.groupLeft.numero
                        End If
                    ElseIf lin.selectedText = Trilean.Second Then
                        linstr = lin.textRight
                        If outfilenumb = 1 Then
                            lingroup = lin.groupRight.numero
                        End If
                    ElseIf lin.selectedText = Trilean.Nothing_ Then

                        If lin.textLeft <> vbNullString Then
                            linstr = lin.textLeft
                            If outfilenumb = 0 Then
                                lingroup = lin.groupLeft.numero
                            End If
                        ElseIf lin.textRight <> vbNullString Then
                            linstr = lin.textRight
                            If outfilenumb = 1 Then
                                lingroup = lin.groupRight.numero
                            End If
                        Else
                            linstr = ""
                            lingroup = -1
                        End If
                    End If
                    If outfile.lines.ContainsKey(index) Then
                        outfile.lines(index).translatedText = linstr
                    Else
                        outfile.lines.Add(index, New LineDouble(vbNullString, linstr, lingroup))
                    End If
                Next
                If File.Exists(SaveFileDialog1.FileName) Then
                    Try
                        File.Delete(SaveFileDialog1.FileName)
                        outfile.Save(SaveFileDialog1.FileName)
                        MsgBox("Saved!", vbInformation)
                    Catch ex As Exception
                        MsgBox("Can't overwrite the file. Please close all the applications that uses this file.", vbCritical)
                    End Try
                Else
                    outfile.Save(SaveFileDialog1.FileName)
                    MsgBox("Saved!", vbInformation)
                End If
            End If
        End If
    End Sub

    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        Dim frms As New frmGoTo()

        Dim line As Integer = frms.PopupGoTo()
        Dim found As Boolean = False

        If line = -1 Then
            Return
        End If

        For Each item As ListViewItem In StringsList.Items
            If item.Text = line Then
                line = StringsList.Items.IndexOf(item)
                found = True
                Exit For
            End If
        Next

        If found = False Then
            MsgBox("Line " + line.ToString + " not found", vbExclamation)
            GoToToolStripMenuItem.PerformClick()
        Else
            StringsList.SelectedItems().Clear()
            StringsList.Items(line).Selected = True
            StringsList.Focus()
        End If
    End Sub

    Private Sub CheckFirstCol_Click(sender As Object, e As EventArgs) Handles CheckFirstCol.Click
        For index2 = 0 To StringsList.Items.Count - 1 Step 1
            Dim lin As LineCompare = dataitems.Item(StringsList.Items(index2).Text - 1)
            If StringsList.Items(index2).Selected = True Then
                lin.selectedText = Trilean.First
                StringsList.Items(index2).SubItems(2).Text = "☑"
                StringsList.Items(index2).SubItems(3).Text = "☐"
            End If
        Next
    End Sub

    Private Sub CheckSecondCol_Click(sender As Object, e As EventArgs) Handles CheckSecondCol.Click
        For index2 = 0 To StringsList.Items.Count - 1 Step 1
            Dim lin As LineCompare = dataitems.Item(StringsList.Items(index2).Text - 1)
            If StringsList.Items(index2).Selected = True Then
                lin.selectedText = Trilean.Second
                StringsList.Items(index2).SubItems(2).Text = "☐"
                StringsList.Items(index2).SubItems(3).Text = "☑"
            End If
        Next
    End Sub

    Private Sub File1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles File1ToolStripMenuItem.Click
        File1ToolStripMenuItem.Image = My.Resources.check_box1
        File1ToolStripMenuItem.Tag = "yes"
        File2ToolStripMenuItem.Image = My.Resources.check_box_uncheck
        File2ToolStripMenuItem.Tag = "no"
    End Sub

    Private Sub File2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles File2ToolStripMenuItem.Click
        File1ToolStripMenuItem.Image = My.Resources.check_box_uncheck
        File1ToolStripMenuItem.Tag = "no"
        File2ToolStripMenuItem.Image = My.Resources.check_box1
        File2ToolStripMenuItem.Tag = "yes"
    End Sub
End Class