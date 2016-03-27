Imports System.IO

Public NotInheritable Class frmMain

    Dim fontResource As String = Application.StartupPath + "\fonts.png"
    Dim actualColor As String = "white"
    Dim lastClicked As Integer = 0
    Dim opened As Boolean = True
    Dim saved As Boolean = True

    Dim ProjectName As String = ""
    Dim CleanScript As String
    Dim TransScript As String

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

        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("{0}", ApplicationTitle)
    End Sub

    Private Sub ListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As ColumnWidthChangedEventArgs) Handles lstStrings.ColumnWidthChanged
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            Dim pnlWidth As Integer = pnlPreview.Width / 2
            Dim pnfrmWidth As Integer = Me.Width / 2
            Dim colFreeWidth = ((lstStrings.Width - 60) / 2) - 20
            If lstStrings.Columns.Count > 2 Then
                With lstStrings
                    .Columns(0).Width = 60
                    .Columns(1).Width = colFreeWidth
                    .Columns(2).Width = colFreeWidth
                End With
            End If
            FireMe = True
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As ColumnWidthChangingEventArgs) Handles lstStrings.ColumnWidthChanging
        e.Cancel = True
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lstStrings.Size = New Size(TableLayoutPanel.Width, TableLayoutPanel.Height)
        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((lstStrings.Width - 60) / 2) - 20
        pnlPreview.Left = pnlWidth + pnfrmWidth
        TextBox1.Width = Me.Width
        If lstStrings.Columns.Count > 0 Then
            With lstStrings
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If
    End Sub

    Private Sub RepackProject()
        Dim tempFolder As String = GetTempFolder()
        Dim unpackProcess As Process
        Dim repackProcess As Process

        Dim winExtract As String = Application.StartupPath & "\Resources\WinExtract.exe"
        Dim winPack As String = Application.StartupPath & "\Resources\WinPack.exe"
        Dim fontsPath As String = Application.StartupPath & "\Resources\UTFonts.win"
        Dim inData As String = ProjectManager.GetInputDirectory & "\data.win"
        Dim outData As String = ProjectManager.GetOutputDirectory & "\data.win"

        If Not My.Computer.FileSystem.FileExists(winExtract) Then
            MsgBox("Error: couldn't find WinExtract.exe!", MsgBoxStyle.Exclamation, "File Not found!")
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(winPack) Then
            MsgBox("Error: couldn't find WinPack.exe!", MsgBoxStyle.Exclamation, "File Not found!")
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(fontsPath) Then
            MsgBox("Error: couldn't find UTFonts.win!", MsgBoxStyle.Exclamation, "File Not found!")
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(inData) Then
            MsgBox("Error: couldn't find Data.win!", MsgBoxStyle.Exclamation, "File Not found!")
            Exit Sub
        End If

        Dim p As New ProcessStartInfo
        p.FileName = winExtract
        p.Arguments = """" & fontsPath & """ """ & tempFolder & "\UTFONTS"" -tt"

        unpackProcess = Process.Start(p)
        unpackProcess.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not unpackProcess.HasExited Then
                unpackProcess.Refresh()
            Else
                Exit For
            End If
        Next i

        p.FileName = winExtract
        p.Arguments = """" & inData & """ """ & tempFolder & "\DATAWIN"" -tt"

        unpackProcess = Process.Start(p)
        unpackProcess.WaitForExit()
        i = 0

        For i = 0 To 4
            If Not unpackProcess.HasExited Then
                unpackProcess.Refresh()
            Else
                Exit For
            End If
        Next i

        My.Computer.FileSystem.DeleteFile(tempFolder & "\DATAWIN\translate.txt")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_8bit.font.gmx", tempFolder & "\DATAWIN\FONT_new\0_UT_8bit (8bitoperator JVE).font.gmx")
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_8bit.png", tempFolder & "\DATAWIN\FONT_new\UT_8bit.png")

        Dim patchFile As System.IO.StreamWriter
        patchFile = My.Computer.FileSystem.OpenTextFileWriter(tempFolder & "\DATAWIN\FONT_new\patch.txt", True)
        patchFile.WriteLine("2;0_UT_8bit (8bitoperator JVE).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_8bitLarge.font.gmx", tempFolder & "\DATAWIN\FONT_new\1_UT_8bitLarge (8bitoperator JVE).font.gmx")
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_8bitLarge.png", tempFolder & "\DATAWIN\FONT_new\UT_8bitLarge.png")
        patchFile.WriteLine("1;1_UT_8bitLarge (8bitoperator JVE).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_Papyrus.font.gmx", tempFolder & "\DATAWIN\FONT_new\2_UT_Papyrus (Papyrus).font.gmx")
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_Papyrus.png", tempFolder & "\DATAWIN\FONT_new\UT_Papyrus.png")
        patchFile.WriteLine("9;2_UT_Papyrus (Papyrus).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_sans.font.gmx", tempFolder & "\DATAWIN\FONT_new\3_UT_sans (Comic Sans MS).font.gmx")
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_sans.png", tempFolder & "\DATAWIN\FONT_new\UT_sans.png")
        patchFile.WriteLine("8;3_UT_sans (Comic Sans MS).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_Hachicro.font.gmx", tempFolder & "\DATAWIN\FONT_new\4_UT_Hachicro (Hachicro).font.gmx")
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_Hachicro.png", tempFolder & "\DATAWIN\FONT_new\UT_Hachicro.png")
        patchFile.WriteLine("6;4_UT_Hachicro (Hachicro).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_DotumChe.font.gmx", tempFolder & "\DATAWIN\FONT_new\5_UT_DotumChe (DotumChe).font.gmx", True)
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_DotumChe.png", tempFolder & "\DATAWIN\FONT_new\UT_DotumChe.png", True)
        patchFile.WriteLine("5;5_UT_DotumChe (DotumChe).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_DotumCheSmall.font.gmx", tempFolder & "\DATAWIN\FONT_new\6_UT_DotumCheSmall (DotumChe).font.gmx", True)
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_DotumCheSmall.png", tempFolder & "\DATAWIN\FONT_new\UT_DotumCheSmall.png", True)
        patchFile.WriteLine("4;6_UT_DotumCheSmall (DotumChe).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_CryptOfTomorrow.font.gmx", tempFolder & "\DATAWIN\FONT_new\7_UT_CryptOfTomorrow (Crypt of Tomorrow).font.gmx", True)
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_CryptOfTomorrow.png", tempFolder & "\DATAWIN\FONT_new\UT_CryptOfTomorrow.png", True)
        patchFile.WriteLine("3;7_UT_CryptOfTomorrow (Crypt of Tomorrow).font.gmx")

        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_MarsNeedsCunninlingus.font.gmx", tempFolder & "\DATAWIN\FONT_new\8_UT_MarsNeedsCunninlingus (Mars Needs Cunnilingus).font.gmx", True)
        System.IO.File.Copy(tempFolder & "\UTFONTS\FONT\UT_MarsNeedsCunninlingus.png", tempFolder & "\DATAWIN\FONT_new\UT_MarsNeedsCunninlingus.png", True)
        patchFile.WriteLine("7;8_UT_MarsNeedsCunninlingus (Mars Needs Cunnilingus).font.gmx")

        patchFile.Close()

        For Each f In Directory.GetFiles(ProjectManager.GetImagesDirectory, "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f)))
                End If
                File.Copy(f, Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f)))
            End If
        Next

        System.IO.File.Copy(ProjectManager.GetTranslatedScript, tempFolder & "\DATAWIN\translate.txt")

        p.FileName = winPack
        p.Arguments = """" & tempFolder & "\DATAWIN "" """ & tempFolder & "\packed.win"" -tt"

        repackProcess = Process.Start(p)
        repackProcess.WaitForExit()
        i = 0

        For i = 0 To 4
            If Not repackProcess.HasExited Then
                repackProcess.Refresh()
            Else
                Exit For
            End If
        Next i

        If File.Exists(outData) Then
            My.Computer.FileSystem.DeleteFile(outData)
        End If

        System.IO.File.Copy(tempFolder & "\packed.win", outData)
        System.IO.Directory.Delete(tempFolder, True)

        For Each f In Directory.GetFiles(ProjectManager.GetInputDirectory)
            If Not File.Exists(Path.Combine(GetOutputDirectory, Path.GetFileName(f))) Then
                File.Copy(f, Path.Combine(GetOutputDirectory, Path.GetFileName(f)))
            End If
        Next
    End Sub

    Public Sub OpenFile(ByVal projectFilePath As String)
        Dim numLines As Integer
        Dim numLines2 As Integer

        ProjectManager.CurrentProject = projectFilePath
        ProjectName = ProjectManager.GetName
        CleanScript = ProjectManager.GetCleanScript
        TransScript = ProjectManager.GetTranslatedScript

        lstStrings.Enabled = False
        TextBox1.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ttipUntranslated.Text = "0"
        ttipTranslated.Text = "0"
        ttipTotal.Text = "0"
        AddToolStripMenuItem.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = False
        ShowText("")
        TextBox1.Text = ""
        lstStrings.Clear()
        lstStrings.View = View.Details
        lstStrings.Clear()
        lstStrings.ShowGroups = False
        lstStrings.Columns.Clear()
        lstStrings.Columns.Add("Line", 100, HorizontalAlignment.Left)
        lstStrings.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        lstStrings.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        lstStrings.HideSelection = True
        lstStrings.FullRowSelect = True
        lstStrings.CheckBoxes = False
        lstStrings.OwnerDraw = False

        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((lstStrings.Width - 60) / 2) - 20

        If lstStrings.Columns.Count > 0 Then
            With lstStrings
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If

        Dim sr As New System.IO.StreamReader(CleanScript)
        Dim lines() As String = IO.File.ReadAllLines(CleanScript)
        numLines = lines.Count()
        sr.Close()

        Dim sr2 As New System.IO.StreamReader(TransScript)
        Dim lines2() As String = IO.File.ReadAllLines(TransScript)
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
            lstStrings.Items.Add(itemToAdd)
        Next i
        lstStrings.Enabled = True
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
            lstStrings.Items(0).Selected = True
        End If
        lstStrings.Focus()
        lstStrings.HideSelection = False

        ShowText(lstStrings.Items(0).SubItems(2).Text)
        TextBox1.Text = lstStrings.Items(0).SubItems(2).Text
        frmSearch.Close()
        Me.Text = "TranslaTale - " + ProjectName

        ProjectManager.CurrentProject = projectFilePath
    End Sub

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
        OpenFileDialog1.Title = "Open a Project file"
        OpenFileDialog1.Filter = "TranslaTale Project files (*.ttp)|*.ttp"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            OpenFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If lstStrings.SelectedItems.Count > 0 Then
            lstStrings.SelectedItems(0).SubItems(2).Text = TextBox1.Text
            If lstStrings.SelectedItems(0).SubItems(1).Text <> TextBox1.Text Then
                lstStrings.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + ProjectName + " *"
                SaveToolStripMenuItem.Enabled = True
            Else
                lstStrings.SelectedItems(0).BackColor = Color.LightSalmon
            End If
        End If
        SpriteFontBox1.Text = TextBox1.Text
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim W As IO.StreamWriter = New IO.StreamWriter(TransScript)
        For i As Integer = 0 To lstStrings.Items.Count - 1
            If lstStrings.Items.Count - 1 < ttipTotal.Text Or lstStrings.Items.Count - 1 = ttipTotal.Text Then
                On Error Resume Next
                W.WriteLine(lstStrings.Items.Item(i).SubItems(2).Text)
            End If
        Next
        W.Close()
        saved = True
        Me.Text = "TranslaTale - " + ProjectName
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'My.Settings.Reset()
        lstStrings.View = View.Details
        lstStrings.Clear()
        lstStrings.ShowGroups = False
        lstStrings.Columns.Clear()
        lstStrings.Columns.Add("Line", 100, HorizontalAlignment.Left)
        lstStrings.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        lstStrings.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        lstStrings.HideSelection = True
        lstStrings.FullRowSelect = True
        lstStrings.CheckBoxes = False
        lstStrings.OwnerDraw = False
        cbFonts.SelectedIndex = 0

        Dim pnlWidth As Integer = pnlPreview.Width / 2
        Dim pnfrmWidth As Integer = Me.Width / 2
        Dim colFreeWidth = ((lstStrings.Width - 60) / 2) - 20

        If lstStrings.Columns.Count > 0 Then
            With lstStrings
                .Columns(0).Width = 60
                .Columns(1).Width = colFreeWidth
                .Columns(2).Width = colFreeWidth
            End With
        End If
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim stat As Integer
        If saved = False Then
            stat = MsgBox("Do you want to save your changes?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                e.Cancel = True
            ElseIf stat = 6 Then
                Dim W As IO.StreamWriter
                Dim i As Integer
                W = New IO.StreamWriter(TransScript)
                For i = 0 To lstStrings.Items.Count
                    If lstStrings.Items.Count - 1 < ttipTotal.Text Or lstStrings.Items.Count - 1 = ttipTotal.Text Then
                        On Error Resume Next
                        W.WriteLine(lstStrings.Items.Item(i).SubItems(2).Text)
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
                Dim W As IO.StreamWriter
                W = New IO.StreamWriter(TransScript)
                For i = 0 To lstStrings.Items.Count
                    If lstStrings.Items.Count - 1 < ttipTotal.Text Or lstStrings.Items.Count - 1 = ttipTotal.Text Then
                        On Error Resume Next
                        W.WriteLine(lstStrings.Items.Item(i).SubItems(2).Text)
                    End If
                Next
                W.Close()
                saved = True
                End
            Else
                Exit Sub
            End If
        End If
        End
    End Sub

    Private Sub DumpStringstxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Public Function CountTranslated()
        Dim stringsTranslated As Integer = 0
        Dim stringsUntranslated As Integer = 0
        For Each item As ListViewItem In Me.lstStrings.Items
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

    Public Function ShowText(ByVal txt As String)
        SpriteFontBox1.Text = txt
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub ListBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBookmarksToolStripMenuItem.Click
        frmBookmarks.ShowDialog()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstStrings.SelectedIndexChanged
        If lstStrings.SelectedItems.Count > 0 Then
            If lstStrings.SelectedItems(0) IsNot Nothing Then
                Dim val As String = lstStrings.SelectedItems(0).SubItems(2).Text
                TextBox1.Text = val
                ShowText(val)
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        If lstStrings.SelectedItems.Count > 0 Then
            Dim tag As String = InputBox("Bookmark name")
            If tag <> "" Then
                SaveBookmark(lstStrings.SelectedItems(0).Index + 1, tag)
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

    Private Sub DumpImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        ShowText(TextBox1.Text)
        CountTranslated()
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

    Private Sub StringsMigrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringsMigrationToolStripMenuItem.Click
        frmStringsConverter.ShowDialog()
    End Sub

    Private Sub ProjectSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectSettingsToolStripMenuItem.Click
        frmProjOptions.ShowDialog()
    End Sub

    Private Sub CompileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem.Click
        RepackProject()
    End Sub

    Private Sub CompileAndRunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompileAndRunToolStripMenuItem.Click
        RepackProject()
        If File.Exists(Path.Combine(ProjectManager.GetOutputDirectory, "UNDERTALE.exe")) Then
            Process.Start(Path.Combine(ProjectManager.GetOutputDirectory, "UNDERTALE.exe"))
        ElseIf File.Exists(Path.Combine(ProjectManager.GetOutputDirectory, "Undertale.exe")) Then
            Process.Start(Path.Combine(ProjectManager.GetOutputDirectory, "Undertale.exe"))
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        CompileAndRunToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub MergeFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeFilesToolStripMenuItem.Click
        frmFileMerge.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        ReloadProjectToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ReloadProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadProjectToolStripMenuItem.Click
        OpenFile(CurrentProject)
    End Sub

    Private Sub LoadTranslationFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadTranslationFileToolStripMenuItem.Click
        OpenFileDialog1.Title = "Select your translated script file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Write(CurrentProject, GetName, GetCleanScript, OpenFileDialog1.FileName, GetImagesDirectory,
                                 GetInputDirectory, GetOutputDirectory)
            OpenFile(CurrentProject)
        End If
    End Sub
End Class
