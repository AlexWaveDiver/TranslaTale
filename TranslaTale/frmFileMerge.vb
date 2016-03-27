Imports System.IO
Imports System.Threading

Public Class frmFileMerge

    Public baseFile As String()
    Public translatedFile As String()
    Public thirdFile As String()

    Public exportBuffer As String()
    Public conflictList As New ArrayList()

    Dim mergeFileCancelled As Boolean = False

    Dim mergeFileDelegated As New ThreadStart(AddressOf mergeFiles)
    Dim mergeFilesThread As New Thread(mergeFileDelegated)

    Private Delegate Sub elementTextInvoker(ByVal text As String, ByVal controlElement As Control)
    Private Delegate Sub elementEnabledInvoker(ByVal bool As Boolean, ByVal controlElement As Control)
    Private Delegate Sub elementVisibleInvoker(ByVal bool As Boolean, ByVal controlElement As Control)

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If btnExit.Text = "Exit" Then
            Me.Close()
        ElseIf btnExit.Text = "Cancel" Then
            mergeFileCancelled = True
            mergeFilesThread.Abort()
            frmFileMerge_Load(sender, e)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If pnlInfo.Visible Then
            OpenFileDialog1.Title = "Select the file you want to merge"
            OpenFileDialog1.Filter = "TXT files (*.txt)|*.txt"
            OpenFileDialog1.RestoreDirectory = True
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                baseFile = File.ReadAllLines(GetCleanScript)
                translatedFile = File.ReadAllLines(GetTranslatedScript)
                thirdFile = File.ReadAllLines(OpenFileDialog1.FileName)

                If baseFile.Length <> translatedFile.Length Or baseFile.Length <> thirdFile.Length Or translatedFile.Length <> thirdFile.Length Then
                    MsgBox("Error: different file sizes!", vbExclamation)
                    Exit Sub
                End If

                ReDim exportBuffer(baseFile.Length - 1)
                pnlInfo.Hide()
                pnlMerging.Show()
                btnNext.Enabled = False

                mergeFilesThread = New Thread(mergeFileDelegated)
                mergeFilesThread.SetApartmentState(ApartmentState.STA)
                mergeFilesThread.Start()

                btnExit.Text = "Cancel"
            End If

        ElseIf pnlMerging.Visible Then
            If conflictList.Count > 0 Then
                pnlMerging.Hide()
                pnlConflicts.Show()
            Else
                saveFile()
                finishUp()
            End If

        ElseIf pnlConflicts.Visible Then
            If rdbTransl.Checked Then
                For Each i As Integer In conflictList
                    exportBuffer(i) = translatedFile(i)
                    saveFile()
                    finishUp()
                Next
            ElseIf rdbThird.Checked Then
                For Each i As Integer In conflictList
                    exportBuffer(i) = thirdFile(i)
                    saveFile()
                    finishUp()
                Next
            ElseIf rdbChoose.Checked Then
                Dim lines As Integer() = conflictList.ToArray(GetType(Integer))
                Dim transLines(lines.Count) As String
                Dim thirdLines(lines.Count) As String

                For i As Integer = 0 To lines.Count - 1
                    transLines(i) = translatedFile(lines(i))
                    thirdLines(i) = thirdFile(lines(i))
                Next
                frmSolveConflicts.ShowDialog()
            End If

        ElseIf pnlDone.Visible Then
            saveFile()
        End If
    End Sub

    Public Sub finishUp()
        pnlConflicts.Hide()
        pnlDone.Show()
        btnNext.Text = "Save"
        btnExit.Text = "Exit"
    End Sub

    Public Sub saveFile()
        SaveFileDialog1.Title = "Save text file as..."
        SaveFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            File.WriteAllLines(SaveFileDialog1.FileName, exportBuffer)
        End If
    End Sub


    Private Sub setElementText(ByVal text As String, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementTextInvoker(AddressOf setElementText), text, controlElement)
        Else
            controlElement.Text = text
        End If
    End Sub

    Private Sub setElementEnabled(ByVal bool As Boolean, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementEnabledInvoker(AddressOf setElementEnabled), bool, controlElement)
        Else
            controlElement.Enabled = bool
        End If
    End Sub

    Private Sub setElementVisible(ByVal bool As Boolean, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementVisibleInvoker(AddressOf setElementVisible), bool, controlElement)
        Else
            controlElement.Visible = bool
        End If
    End Sub
    Private Sub mergeFiles()

        setElementEnabled(False, btnNext)

        For i As Integer = 0 To exportBuffer.Length - 1

            If mergeFileCancelled Then
                Exit Sub
            End If

            If translatedFile(i) = baseFile(i) And translatedFile(i) = thirdFile(i) Then
                exportBuffer(i) = baseFile(i)
            ElseIf translatedFile(i) <> baseFile(i) And thirdFile(i) <> baseFile(i) Then
                If translatedFile(i) = thirdFile(i) Then
                    exportBuffer(i) = thirdFile(i)
                Else
                    conflictList.Add(i)
                    setElementText("Conflicts: " & conflictList.Count, lblConflicts)
                End If
            ElseIf translatedFile(i) = baseFile(i) Then
                exportBuffer(i) = thirdFile(i)
            ElseIf thirdFile(i) = baseFile(i) Then
                exportBuffer(i) = translatedFile(i)
            End If
            setElementText("Lines Processed: " & i & " / " & baseFile.Length, lblProcessed)
        Next

        setElementText("Lines Processed: " & baseFile.Length & " / " & baseFile.Length, lblProcessed)
        setElementEnabled(True, btnNext)

        If conflictList.Count = 0 Then
            setElementText("Save", btnNext)
            setElementVisible(True, lblNoConflicts)
        End If

    End Sub

    Private Sub frmFileMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlMerging.Hide()
        pnlConflicts.Hide()
        pnlDone.Hide()
        pnlInfo.Show()

        baseFile = {0}
        translatedFile = {0}
        thirdFile = {0}
        exportBuffer = {0}
        conflictList.Clear()

        lblConflicts.Text = "Conflicts: 0"
        lblProcessed.Text = "Lines Processed: 0 / 0"

        mergeFileCancelled = False

        btnNext.Text = "Next >"
        btnExit.Text = "Exit"
        btnNext.Enabled = True
        lblNoConflicts.Hide()
    End Sub

    Private Sub rdbChoose_CheckedChanged(sender As Object, e As EventArgs) Handles rdbChoose.CheckedChanged
        If rdbChoose.Checked Then
            btnNext.Text = "Next >"
        Else
            btnNext.Text = "Save"
        End If
    End Sub
End Class