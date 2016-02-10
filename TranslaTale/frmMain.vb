﻿Imports System.Drawing
Imports System.Resources
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Xml
Imports System.Text

Public NotInheritable Class frmMain

    Dim fontResource As String = Application.StartupPath + "\fonts.png"

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not My.Settings.fontsheetPath = "" And Not File.Exists(My.Settings.fontsheetPath) Then
            MsgBox("Custom fontsheet not found. Using default fontsheet instead.", vbInformation)
            SpriteFontBox1.ImageLocation = fontResource
        Else
            SpriteFontBox1.ImageLocation = My.Settings.fontsheetPath
        End If

        MenuStrip1.BackColor = Color.Transparent
        ToolStrip1.BackColor = Color.Transparent
        If TypeOf ToolStrip1.Renderer Is ToolStripProfessionalRenderer Then
            CType(ToolStrip1.Renderer, ToolStripProfessionalRenderer).RoundedEdges = False
        End If
        If Not File.Exists(fontResource) Then
            My.Resources.fonts.Save(fontResource)
        End If

        SpriteFontBox1.FontPath = fontResource
        SpriteFontBox1.LoadFont()

        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("{0}", ApplicationTitle)
    End Sub

    Private Sub ListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListView1.ColumnWidthChanged
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            Dim pnlWidth As Integer = pnlPreview.Width / 2
            Dim pnfrmWidth As Integer = Me.Width / 2
            Dim colFreeWidth = ((ListView1.Width - 60) / 2) - 20
            If ListView1.Columns.Count > 2 Then
                With ListView1
                    .Columns(0).Width = 60
                    .Columns(1).Width = colFreeWidth
                    .Columns(2).Width = colFreeWidth
                End With
            End If
            FireMe = True
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        e.Cancel = True
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ListView1.Size = New Size(TableLayoutPanel.Width, TableLayoutPanel.Height)
        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((ListView1.Width - 60) / 2) - 20
        pnlPreview.Left = pnlWidth + pnfrmWidth
        TextBox1.Width = Me.Width
        If ListView1.Columns.Count > 0 Then
            With ListView1
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If
    End Sub
    Dim actualColor As String = "white"
    Dim lastClicked As Integer = 0
    Dim opened As Boolean = True
    Dim saved As Boolean = True
    Dim fileNameTitle As String = ""
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTextbox.CheckedChanged
        SpriteFontBox1.Visible = True
        picTxtEnemy.Visible = False
        SpriteFontBox1.ShowFaces = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFacebox.CheckedChanged
        SpriteFontBox1.Visible = True
        picTxtEnemy.Visible = False
        SpriteFontBox1.ShowFaces = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        SpriteFontBox1.Visible = False
        picTxtEnemy.Visible = True
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim path1 As String
        Dim path2 As String
        Dim numLines As Integer
        Dim numLines2 As Integer

        SaveFileDialog1.Filter = "Text file|*.txt"
        OpenFileDialog1.Title = "Open base file"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            path1 = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        SaveFileDialog1.Filter = "Text file|*.txt"
        OpenFileDialog1.Title = "Open translation file"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            path2 = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If
        ListView1.Enabled = False
        TextBox1.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ttipUntranslated.Text = "0"
        ttipTranslated.Text = "0"
        ttipTotal.Text = "0"
        AddToolStripMenuItem.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = False
        showText("")
        TextBox1.Text = ""
        fileNameTitle = OpenFileDialog1.SafeFileName
        ListView1.Clear()
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

        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((ListView1.Width - 60) / 2) - 20

        If ListView1.Columns.Count > 0 Then
            With ListView1
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If

        Dim sr As New System.IO.StreamReader(path1)
        Dim lines() As String = IO.File.ReadAllLines(path1)
        numLines = lines.Count()
        sr.Close()

        Dim sr2 As New System.IO.StreamReader(path2)
        Dim lines2() As String = IO.File.ReadAllLines(path2)
        numLines2 = lines2.Count()
        sr2.Close()

        If numLines <> numLines2 Then
            MsgBox("Both files must have the same number of lines", vbExclamation)
            Exit Sub
        End If

        If numLines < 1 Or numLines2 < 1 Then
            MsgBox("The files must not be empty", vbExclamation)
            Exit Sub
        End If

        Dim i As Integer
        Dim transLines As Integer = 0
        Dim untransLines As Integer = 0
        For i = 0 To numLines - 1
            Dim itemToAdd As New ListViewItem({i + 1, lines(i), lines2(i)})
            If lines(i) <> lines2(i) Then
                itemToAdd.BackColor = Color.LightGreen
                transLines = transLines + 1
            Else
                itemToAdd.BackColor = Color.LightSalmon
                untransLines = untransLines + 1
            End If
            ListView1.Items.Add(itemToAdd)
        Next i
        ListView1.Enabled = True
        TextBox1.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        ttipUntranslated.Text = untransLines
        ttipTranslated.Text = transLines
        ttipTotal.Text = numLines
        AddToolStripMenuItem.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True
        ToolStripButton4.Enabled = True
        If numLines < 1 Or numLines2 < 1 Then
            ListView1.Items(0).Selected = True
        End If
        ListView1.Focus()
        ListView1.HideSelection = False
        showText(ListView1.Items(0).SubItems(2).Text)
        TextBox1.Text = ListView1.Items(0).SubItems(2).Text
        frmSearch.Close()
        Me.Text = "TranslaTale - " + fileNameTitle
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.SelectedItems(0).SubItems(2).Text = TextBox1.Text
            If ListView1.SelectedItems(0).SubItems(1).Text <> TextBox1.Text Then
                ListView1.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + fileNameTitle + " *"
                SaveToolStripMenuItem.Enabled = True
            Else
                ListView1.SelectedItems(0).BackColor = Color.LightSalmon
            End If
        End If
        SpriteFontBox1.Text = TextBox1.Text
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save translation file"
        SaveFileDialog1.Filter = "Text file|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim W As IO.StreamWriter
            Dim i As Integer
            W = New IO.StreamWriter(SaveFileDialog1.FileName)
            For i = 0 To ListView1.Items.Count - 1
                If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                    On Error Resume Next
                    W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                End If
            Next
            W.Close()
            saved = True
        End If
        Me.Text = "TranslaTale - " + fileNameTitle
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Settings.Reset()
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
        cbFonts.SelectedIndex = 0

        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((ListView1.Width - 60) / 2) - 20

        If ListView1.Columns.Count > 0 Then
            With ListView1
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim stat As Integer
        If saved = False Then
            stat = MsgBox("Do you want to save your changes?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                e.Cancel = True
            ElseIf stat = 6 Then
                SaveFileDialog1.Filter = "Text file|*.txt"
                SaveFileDialog1.Title = "Save translation file"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Dim W As IO.StreamWriter
                    Dim i As Integer
                    W = New IO.StreamWriter(SaveFileDialog1.FileName)
                    For i = 0 To ListView1.Items.Count
                        If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                            On Error Resume Next
                            W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                        End If
                    Next
                    W.Close()
                    saved = True
                    End
                Else
                    saved = False
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If saved = False Then
            Dim stat As Integer
            stat = MsgBox("Do you want to save your file?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                Exit Sub
            ElseIf stat = 7 Then
                End
            ElseIf stat = 6 Then
                SaveFileDialog1.Filter = "Text file|*.txt"
                SaveFileDialog1.Title = "Save translation file"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Dim W As IO.StreamWriter
                    Dim i As Integer
                    W = New IO.StreamWriter(SaveFileDialog1.FileName)
                    For i = 0 To ListView1.Items.Count
                        If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                            On Error Resume Next
                            W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                        End If
                    Next
                    W.Close()
                    saved = True
                    End
                Else
                    Exit Sub
                End If
            End If
        Else
            End
        End If
    End Sub

    Private Sub DumpStringstxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpStringstxtToolStripMenuItem.Click
        Dim winPath As String
        Dim stringsPath As String
        Dim sPath As String
        Dim unpackStringsProc As Process

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        SaveFileDialog2.Filter = "Text file|*.txt"
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            stringsPath = SaveFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim tmpPath As String = GetTempFolder(True)
        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ """ & tmpPath & """"
        unpackStringsProc = Process.Start(p)
        unpackStringsProc.WaitForExit()
        Dim i As Integer
        For i = 0 To 4
            If Not unpackStringsProc.HasExited Then
                unpackStringsProc.Refresh()
            Else
                Exit For
            End If
        Next i

        File.Copy(tmpPath & "\STRG.txt", stringsPath, True)
        System.IO.Directory.Delete(tmpPath, True)
        MsgBox("Process finished", vbInformation)

        sPath = StrReverse(SaveFileDialog2.FileName)
        sPath = Mid(sPath, InStr(sPath, "\"), Len(sPath))
        sPath = StrReverse(sPath)
        Process.Start(sPath)
    End Sub

    Public Function countTranslated()
        Dim stringsTranslated As Integer = 0
        Dim stringsUntranslated As Integer = 0
        For Each item As ListViewItem In Me.ListView1.Items
            If item.BackColor = Color.LightGreen Then
                stringsTranslated = stringsTranslated + 1
            Else
                stringsUntranslated = stringsUntranslated + 1
            End If
        Next
        ttipUntranslated.Text = stringsUntranslated
        ttipTranslated.Text = stringsTranslated
        Return True
    End Function

    Public Function showText(ByVal txt As String)
        SpriteFontBox1.Text = txt
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ListBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBookmarksToolStripMenuItem.Click
        frmBookmarks.ShowDialog()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            If ListView1.SelectedItems(0) IsNot Nothing Then
                Dim val As String = ListView1.SelectedItems(0).SubItems(2).Text
                TextBox1.Text = val
                showText(val)
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim tag As String = InputBox("Bookmark name")
            If tag <> "" Then
                saveBookmark(ListView1.SelectedItems(0).Index + 1, tag)
            End If
        Else
            MsgBox("You must select the line you want to add to the bookmarks list", vbExclamation)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        OpenToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmGoTo.ShowDialog()
    End Sub

    Private Sub cbFonts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFonts.SelectedIndexChanged
        If cbFonts.SelectedIndex = 0 Then
            SpriteFontBox1.CurrentSpriteFont = UTSpriteFontBox.SpriteFontBox.SpriteFonts.BitOperator
        End If
        If cbFonts.SelectedIndex = 1 Then
            SpriteFontBox1.CurrentSpriteFont = UTSpriteFontBox.SpriteFontBox.SpriteFonts.ComicSans
        End If
        If cbFonts.SelectedIndex = 2 Then
            SpriteFontBox1.CurrentSpriteFont = UTSpriteFontBox.SpriteFontBox.SpriteFonts.Papyrus
        End If
    End Sub

    Private Sub DumpImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpImagesToolStripMenuItem.Click
        Dim winPath As String
        Dim imgPath As String
        Dim unpackImagesProc As Process

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        FolderBrowserDialog1.Description = "Choose an extraction location"
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            imgPath = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim p As New ProcessStartInfo
        Dim tmpPath As String = GetTempFolder(True)
        p.FileName = filename
        p.Arguments = """" & winPath & """ """ & tmpPath & """ -tt"
        unpackImagesProc = Process.Start(p)
        unpackImagesProc.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not unpackImagesProc.HasExited Then
                unpackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i

        For Each f In Directory.GetFiles(tmpPath & "\TXTR\", "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(imgPath, Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(imgPath, Path.GetFileName(f)))
                End If
                File.Move(f, Path.Combine(imgPath, Path.GetFileName(f)))
            End If
        Next
        System.IO.Directory.Delete(tmpPath, True)
        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub RepackImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim winPath As String
        Dim imgPath As String
        Dim repackImagesProc As Process
        FolderBrowserDialog1.Description = "Choose the resources location"
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            imgPath = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim p As New ProcessStartInfo
        Dim tmpPath As String = GetTempFolder(True)
        p.FileName = filename
        p.Arguments = """" & winPath & """ """ & tmpPath & """ -tt"
        repackImagesProc = Process.Start(p)
        repackImagesProc.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not repackImagesProc.HasExited Then
                repackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i

        For Each f In Directory.GetFiles(imgPath, "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(tmpPath & "\TXTR\", Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(tmpPath & "\TXTR\", Path.GetFileName(f)))
                End If
                File.Copy(f, Path.Combine(tmpPath & "\TXTR\", Path.GetFileName(f)))
            End If
        Next

        'My.Computer.FileSystem.DeleteFile(tmpPath & "\translate.txt")

        filename = Application.StartupPath + "\WinPack.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinPack)

        p = New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & tmpPath & """ """ & winPath & """ -tt"
        repackImagesProc = Process.Start(p)
        repackImagesProc.WaitForExit()

        i = 0
        For i = 0 To 4
            If Not repackImagesProc.HasExited Then
                repackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i
        'System.IO.Directory.Delete(tmpPath, True)
        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        showText(TextBox1.Text)
        countTranslated()
        Timer1.Enabled = False
    End Sub

    Private Sub tsSearchPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each item As ListViewItem In Me.ListView1.Items
        '    If item.SubItems(1).Text.Contains("demon") Then
        '        MsgBox(item.Index.ToString())
        '    End If
        'Next
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        frmSearch.Show()
    End Sub

    Private Sub SpriteFontBox1_GotFocus(sender As Object, e As EventArgs) Handles SpriteFontBox1.GotFocus
        TextBox1.Select()
    End Sub

    Private Sub FontImporterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontImporterToolStripMenuItem.Click
        MsgBox("This is an EXPERIMENTAL feature." & vbCr & "Please make backups of your files before proceeding!", vbExclamation)
        frmFontImporter.ShowDialog()
    End Sub

    Private Sub StringsMigrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringsMigrationToolStripMenuItem.Click
        MsgBox("This is an EXPERIMENTAL feature." & vbCr & "Please make backups of your files before proceeding!", vbExclamation)
        frmStringsConverter.ShowDialog()
    End Sub
End Class
