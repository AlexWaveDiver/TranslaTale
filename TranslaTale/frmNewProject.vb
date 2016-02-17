Imports System.IO
Imports System.Xml

Public Class frmNewProject

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        frmStartUp.Show()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If tabModeSelect.SelectedIndex = 0 Then
            Dim dataPath As String = txtFolder1.Text & "\data.win"

            If txtFolder1.Text = "" Or txtFolder2.Text = "" Or txtName.Text = "" Then
                Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(dataPath) Then
                MsgBox("Error: Couldn't find Data.win!", MsgBoxStyle.Exclamation, "File Not found!")
                Exit Sub
            End If

            If Not My.Computer.FileSystem.DirectoryExists(txtFolder2.Text) Then
                My.Computer.FileSystem.CreateDirectory(txtFolder2.Text)
            End If

            Dim projFilePath As String = txtFolder2.Text & "\" & txtName.Text & ".ttp"

            DumpText(dataPath, txtFolder2.Text)
            File.Copy(txtFolder2.Text & "\CleanStrings.txt", txtFolder2.Text & "\TranslatedStrings.txt", True)
            My.Computer.FileSystem.CreateDirectory(txtFolder2.Text & "\Images")
            DumpImages(dataPath, txtFolder2.Text & "\Images")
            ProjectManager.Write(projFilePath, txtName.Text, txtFolder2.Text & "\CleanStrings.txt",
                                         txtFolder2.Text & "\TranslatedStrings.txt", txtFolder2.Text & "\Images",
                                         txtFolder1.Text, txtFolder3.Text)

            SaveRecentProject(txtName.Text, projFilePath)
            Me.Hide()
            frmMain.Show()
            frmMain.OpenFile(projFilePath)
        Else
            If txtFile1.Text = "" Or txtFile2.Text = "" Or txtFile3.Text = "" Or txtFile4.Text = "" Or txtName2.Text = "" Or txtFile5.Text = "" Then
                Exit Sub
            End If

            If Not My.Computer.FileSystem.DirectoryExists(txtFile1.Text) Or Not My.Computer.FileSystem.FileExists(txtFile2.Text) Or Not My.Computer.FileSystem.FileExists(txtFile3.Text) Or Not My.Computer.FileSystem.DirectoryExists(txtFile4.Text) Or Not My.Computer.FileSystem.DirectoryExists(txtFile5.Text) Then
                MsgBox("Error: Couldn't find one or more files!", MsgBoxStyle.Exclamation, "File Not found!")
                Exit Sub
            End If
            SaveFileDialog1.Title = "Save Project file as..."
            SaveFileDialog1.Filter = "TranslaTale Project files (*.ttp)|*.ttp"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                ProjectManager.Write(SaveFileDialog1.FileName, txtName2.Text, txtFile2.Text,
                                             txtFile3.Text, txtFile4.Text, txtFile1.Text, txtFile5.Text)
                SaveRecentProject(txtName2.Text, SaveFileDialog1.FileName)
                Me.Hide()
                frmMain.Show()
                frmMain.OpenFile(SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub tabModeSelected_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabModeSelect.SelectedIndexChanged
        If tabModeSelect.SelectedIndex = 0 Then
            btnDone.Text = "Create Project"
        ElseIf tabModeSelect.SelectedIndex = 1 Then
            btnDone.Text = "Save As..."
        End If
    End Sub

    Private Sub frmNewProject_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        frmStartUp.Show()
    End Sub

    Private Sub DumpText(ByVal inDirectory As String, ByVal outDirectory As String)
        Dim tmpPath As String = GetTempFolder(True)

        Dim extractProcess As Process
        Dim pInfo As New ProcessStartInfo

        pInfo.FileName = Application.StartupPath & "\Resources\WinExtract.exe"
        pInfo.Arguments = """" & inDirectory & """ """ & tmpPath & """"

        extractProcess = Process.Start(pInfo)
        extractProcess.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not extractProcess.HasExited Then
                extractProcess.Refresh()
            Else
                Exit For
            End If
        Next i
        File.Copy(tmpPath & "\STRG.txt", outDirectory & "\CleanStrings.txt", True)
        System.IO.Directory.Delete(tmpPath, True)
    End Sub

    Private Sub DumpImages(ByVal inDirectory As String, ByVal outDirectory As String)
        Dim tmpPath As String = GetTempFolder(True)

        Dim extractProcess As Process
        Dim pInfo As New ProcessStartInfo

        pInfo.FileName = Application.StartupPath & "\Resources\WinExtract.exe"
        pInfo.Arguments = """" & inDirectory & """ """ & tmpPath & """ -tt"

        extractProcess = Process.Start(pInfo)
        extractProcess.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not extractProcess.HasExited Then
                extractProcess.Refresh()
            Else
                Exit For
            End If
        Next i

        For Each f In Directory.GetFiles(tmpPath & "\TXTR\", "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(outDirectory, Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(outDirectory, Path.GetFileName(f)))
                End If
                File.Move(f, Path.Combine(outDirectory, Path.GetFileName(f)))
            End If
        Next
        System.IO.Directory.Delete(tmpPath, True)
    End Sub

    Private Sub btnFolder1_Click(sender As Object, e As EventArgs) Handles btnFolder1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder2_Click(sender As Object, e As EventArgs) Handles btnFolder2.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder3_Click(sender As Object, e As EventArgs) Handles btnFolder3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder3.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder4_Click(sender As Object, e As EventArgs) Handles btnFolder4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFile5.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFile1_Click(sender As Object, e As EventArgs) Handles btnFile1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFile1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFile2_Click(sender As Object, e As EventArgs) Handles btnFile2.Click
        OpenFileDialog1.Title = "Select your clean script file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFile2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnFile3_Click(sender As Object, e As EventArgs) Handles btnFile3.Click
        OpenFileDialog1.Title = "Select your translated script file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFile3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnFile4_Click(sender As Object, e As EventArgs) Handles btnFile4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFile4.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class