Imports System.Drawing.Text
Imports System.IO
Imports System.Threading

Public Class frmGameCompiler
    Dim wizardStep As Integer = 1
    Dim utFontsPath As String = ""
    Dim dataWinPath As String = ""
    Dim translationPath As String = ""
    Dim imgPath As String = ""
    Dim advanced As Boolean = False
    Dim debug As Boolean = False

    Public Overloads Sub ShowDialog(advanced As Boolean, Optional debug As Boolean = False)
        Me.advanced = advanced
        Me.debug = debug
        Me.ShowDialog()
    End Sub

    Private Sub frmFontImporter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeForm()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start("http://www.yoyogames.com/download/studio/free")
    End Sub

    Function checkFontCollection()
        Dim fontsCollection As New InstalledFontCollection()
        Dim fontsToFind As Array = {"Crypt of Tomorrow", "8bitoperator JVE", "Hachicro", "DotumChe", "Mars Needs Cunnilingus", "Papyrus", "Comic Sans MS"}
        lblCheck.Text = "Checking installed fonts..."
        lstFontsNotFound.Items.Clear()

        For Each fontToFind As String In fontsToFind
            Dim fontFound = False
            For Each fontFamiliy In fontsCollection.Families
                If fontFamiliy.Name = fontToFind Then
                    fontFound = True
                End If
            Next
            If fontFound = False Then
                lstFontsNotFound.Items.Add(fontToFind)
            End If
        Next
        If lstFontsNotFound.Items.Count > 0 Then
            lblCheck.Text = "You need to install the next fonts in order to continue." & vbCr & "Double-click in any item to open its" & vbCr & "download page."
            btnNext.Enabled = False
            lstFontsNotFound.Visible = True
            lblRebootTT.Enabled = True
        Else
            lblCheck.Text = "Everything seems in order! Click Next to continue."
            lstFontsNotFound.Visible = False
            btnNext.Enabled = True
            lstFontsNotFound.Visible = False
            lblRebootTT.Visible = False
        End If
        Return True
    End Function

    Function closeForm()
        wizardStep = 1
        btnNext.Text = "&Next >"
        Panel4.Visible = False
        Panel3.Visible = False
        Panel2.Visible = False
        Panel1.Visible = True
        ofdPaths.FileName = ""
        lblDataWin.Text = "UT Data.win: None selected"
        lblUTFonts.Text = "UTFonts: None selected"
        lblImages.Text = "Images: None selected"
        utFontsPath = ""
        dataWinPath = ""
        translationPath = ""
        imgPath = ""
        btnBack.Enabled = True
        btnNext.Enabled = True
        btnCancel.Enabled = True
        btnBack.Visible = False
        btnNext.Visible = True
        btnCancel.Visible = True
        Me.Close()
        Return True
    End Function

    Private Sub btnCheckConfig_Click(sender As Object, e As EventArgs)
        checkFontCollection()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Select Case wizardStep
            Case 1
                wizardStep = 2
                checkFontCollection()
                btnBack.Visible = True
                Panel1.Visible = False
                Panel2.Visible = True
            Case 2
                wizardStep = 3
                Panel2.Visible = False
                Panel3.Visible = True
            Case 3
                wizardStep = 4
                Panel3.Visible = False
                Panel4.Visible = True

                updateStrings()

                If CurrentSession.undertaleEXE.Count > 10 Then
                    exeOutput.Enabled = True
                    exeOutput.Checked = True
                Else
                    exeOutput.Enabled = False
                    RadioButton2.Checked = True
                End If

                btnNext.Text = "&Export"
                If utFontsPath = "" Or dataWinPath = "" Or translationPath = "" Or Not imgPath = "" Then
                    btnNext.Enabled = False
                Else
                    btnNext.Enabled = True
                End If
            Case 4
                wizardStep = 5
                Dim exemode As Boolean = exeOutput.Checked
                Dim saveFileDialog1 As New SaveFileDialog()
                Dim winPath As String = ""
                saveFileDialog1.Title = "Save as..."
                saveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                If exemode Then
                    saveFileDialog1.Filter = ".EXE file | *.exe"
                Else
                    saveFileDialog1.Filter = ".WIN file | *.win"
                End If
                saveFileDialog1.RestoreDirectory = True

                If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Dim tf As String = GetTempFolder(True, "extr")
                    If exemode Then
                        ExtractUndertaleEXE(CurrentSession.undertaleEXE, Path.Combine(tf, "extr"), "UtTEMP.exe")
                        makeExe(tf, saveFileDialog1.FileName)
                        MsgBox("Exported successfully!", vbInformation)
                        closeForm()
                    Else
                        repackFonts(saveFileDialog1.FileName)
                    End If
                Else
                    Panel4.Visible = True
                    wizardStep = 4
                End If
        End Select
    End Sub


    Private Sub makeExe(ByVal workingdir As String, ByVal outputExePath As String)
        If (Not Directory.Exists(workingdir)) Then
            Directory.CreateDirectory(workingdir)
        End If
        If (Not File.Exists(String.Concat(workingdir, "\UDTRebuildSFXCAB.exe"))) Then
            Directory.CreateDirectory(String.Concat(workingdir, "\bin"))
            Directory.CreateDirectory(String.Concat(workingdir, "\res"))
            Dim str As String = String.Concat(workingdir, "\bin\7z.dll")
            File.WriteAllBytes(str, My.Resources._7zDLL)
            str = String.Concat(workingdir, "\bin\7z.exe")
            File.WriteAllBytes(str, My.Resources._7zEXE)
            str = String.Concat(workingdir, "\bin\Aut2exe.exe")
            File.WriteAllBytes(str, My.Resources.Aut2exeEXE)
            str = String.Concat(workingdir, "\res\Crypt.au3")
            File.WriteAllBytes(str, My.Resources.CryptAU3)
            str = String.Concat(workingdir, "\res\FileConstants.au3")
            File.WriteAllBytes(str, My.Resources.FileConstantsAU3)
            str = String.Concat(workingdir, "\res\UDTSFXCAB_Template.au3")
            File.WriteAllBytes(str, My.Resources.UDTSFXCAB_TemplateAU3)
            str = String.Concat(workingdir, "\res\UNDERTALE.ico")
            File.WriteAllBytes(str, My.Resources.gameicon)
            str = String.Concat(workingdir, "\UDTRebuildSFXCAB.exe")
            File.WriteAllBytes(str, My.Resources.UDTRebuildSFXCAB)
        End If
        Dim processStartInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo() With
            {
                .WorkingDirectory = workingdir,
                .FileName = String.Concat("""", workingdir, "\UDTRebuildSFXCAB.exe"""),
                .WindowStyle = ProcessWindowStyle.Normal,
                .Arguments = ""
            }
        Dim process As System.Diagnostics.Process = System.Diagnostics.Process.Start(processStartInfo)
        File.Delete(String.Concat(workingdir, "\UDTREBUILT.exe"))
        While Not File.Exists(String.Concat(workingdir, "\UDTREBUILT.exe"))
            Thread.Sleep(500)
        End While
        process.Kill()
        File.Delete(outputExePath)
        Dim num As Integer = 1
        Do
            Try
                Try
                    If (Not process.HasExited) Then
                        process.Refresh()
                    End If
                Catch exception As System.Exception
                End Try
                Try
                    If (Not process.HasExited) Then
                        process.CloseMainWindow()
                    End If
                Catch exception1 As System.Exception
                End Try
                Try
                    If (Not process.HasExited) Then
                        process.Close()
                    End If
                Catch exception2 As System.Exception
                End Try
                Try
                    If (Not process.HasExited) Then
                        process.Kill()
                    End If
                Catch exception3 As System.Exception
                End Try
                File.Copy(String.Concat(workingdir, "\UDTREBUILT.exe"), outputExePath)
                Exit Do
            Catch exception4 As System.Exception
                Thread.Sleep(500)
            End Try
            num = num + 1
        Loop While num <= 30
        Directory.Delete(String.Concat(workingdir, "\extr"), True)
    End Sub

    Private Sub updateStrings()
        Dim stringspath As String = GetTempFolder(True, "fontimporter") & "\tmp_strings.txt"
        If SaveTTX(stringspath) = True Then
            translationPath = stringspath
        End If

        If Not dataWinPath = "" And Not utFontsPath = "" And Not translationPath = "" And Not imgPath = "" Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        closeForm()
    End Sub

    Private Sub lstFontsNotFound_DoubleClick(sender As Object, e As EventArgs) Handles lstFontsNotFound.DoubleClick
        Dim fontsWebpage As Array = {"https://www.dropbox.com/s/m8afdau0haacmdh/CryptOfTomorrow.zip?dl=0", "http://www.fonts2u.com/8bitoperator-jve-regular.fuente", "http://www.dafont.com/hachicro.font", "https://www.dropbox.com/s/lugykkvho2brx4s/marsneedscunnilingus.zip?dl=0", "http://psdbundle.com/2012/09/papyrus-font-download-free/", "http://www.911fonts.com/font-download/download_ComicSansMSRegular_2086.htm", "http://cooltext.com/Download-Font-%EB%8F%8B%EC%9B%80+Dotum"}
        Select Case lstFontsNotFound.SelectedItems(0)
            Case "Crypt of Tomorrow"
                Process.Start(fontsWebpage(0))
            Case "8bitoperator JVE"
                Process.Start(fontsWebpage(1))
            Case "Hachicro"
                Process.Start(fontsWebpage(2))
            Case "Mars Needs Cunnilingus"
                Process.Start(fontsWebpage(3))
            Case "Papyrus"
                Process.Start(fontsWebpage(4))
            Case "Comic Sans MS"
                Process.Start(fontsWebpage(5))
            Case "DotumChe"
                Process.Start(fontsWebpage(6))
        End Select
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Select Case wizardStep
            Case 2
                Panel1.Visible = True
                Panel2.Visible = False
                btnBack.Visible = False
                btnNext.Visible = True
                btnNext.Enabled = True
                wizardStep = 1
            Case 3
                Panel2.Visible = True
                Panel3.Visible = False
                wizardStep = 2
            Case 4
                Panel3.Visible = True
                Panel4.Visible = False
                btnNext.Text = "&Next >"
                wizardStep = 3
                btnNext.Enabled = True
            Case 5
                Panel4.Visible = True
                wizardStep = 4
        End Select
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://www.undertale-spanish.com/wp-content/uploads/2016/01/UTFonts.zip")
    End Sub

    Private Sub btnOpenUTFonts_Click(sender As Object, e As EventArgs) Handles btnOpenUTFonts.Click
        ofdPaths.Filter = ".WIN file | *.win"
        If ofdPaths.ShowDialog = Windows.Forms.DialogResult.OK Then
            utFontsPath = ofdPaths.FileName
            lblUTFonts.Text = "UTFonts: " & ofdPaths.FileName
        Else
            utFontsPath = ""
            lblUTFonts.Text = "UTFonts: None selected"
        End If

        If Not dataWinPath = "" And Not utFontsPath = "" And Not translationPath = "" And Not imgPath = "" Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub btnOpenDataWin_Click(sender As Object, e As EventArgs) Handles btnOpenDataWin.Click
        ofdPaths.Filter = ".WIN file | *.win"
        If ofdPaths.ShowDialog = Windows.Forms.DialogResult.OK Then
            dataWinPath = ofdPaths.FileName
            lblDataWin.Text = "UT Data.win: " & ofdPaths.FileName
        Else
            dataWinPath = ""
            lblDataWin.Text = "UT Data.win: None selected"
        End If

        If Not dataWinPath = "" And Not utFontsPath = "" And Not translationPath = "" And Not imgPath = "" Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If
    End Sub

    Private Function repackFonts(ByVal winFile As String, Optional ByVal silent As Boolean = False) As Boolean
        Dim tempFolder As String = GetTempFolder()
        Dim unpackProcess As Process
        Dim repackProcess As Process

        btnCancel.Visible = False
        btnBack.Visible = False
        btnNext.Visible = False

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim filenamePack As String = Application.StartupPath + "\WinPack.exe"
        System.IO.File.WriteAllBytes(filenamePack, My.Resources.WinPack)

        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & utFontsPath & """ """ & tempFolder & "\UTFONTS"" -tt"

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

        p.FileName = filename
        p.Arguments = """" & dataWinPath & """ """ & tempFolder & "\DATAWIN"" -tt"

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

        For Each f In Directory.GetFiles(imgPath, "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f)))
                End If
                File.Copy(f, Path.Combine(tempFolder & "\DATAWIN\TXTR\", Path.GetFileName(f)))
            End If
        Next

        System.IO.File.Copy(translationPath, tempFolder & "\DATAWIN\translate.txt")

        p.FileName = filenamePack
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

        If File.Exists(winFile) Then
            My.Computer.FileSystem.DeleteFile(winFile)
        End If

        System.IO.File.Copy(tempFolder & "\packed.win", winFile)
        System.IO.Directory.Delete(tempFolder, True)
        If (Not silent) Then
            MsgBox("Process finished", vbInformation)
        End If
        Me.Close()
        Return True
    End Function

    Private Sub frmFontImporter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.debug Then
            Me.Text = "Debug"
        End If
    End Sub

    Private Sub btnImages_Click(sender As Object, e As EventArgs) Handles btnImages.Click

        Dim options As Integer = &H40 + &H20
        options += &H10   '' Adds edit box
        Dim shellAppType As Type = Type.GetTypeFromProgID("Shell.Application")
        Dim shell As Object = Activator.CreateInstance(shellAppType)
        Dim root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim folder = CType(shell.BrowseForFolder(Nothing, "Choose images' folder", options, root), Shell32.Folder2)
        If folder Is Nothing Then
            imgPath = ""
            lblImages.Text = "Images: None selected"
            Exit Sub
        Else
            imgPath = folder.Self.Path
            If Not Directory.Exists(imgPath) Then
                imgPath = ""
                lblImages.Text = "Images: None selected"
                MsgBox("Directory doesn't exists!", MsgBoxStyle.Exclamation, "TranslaTale")
                Exit Sub
            Else
                lblImages.Text = "Images: " & imgPath
            End If
        End If

        If Not dataWinPath = "" And Not utFontsPath = "" And Not translationPath = "" And Not imgPath = "" Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub frmFontImporter_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Enabled = False
        If advanced Then
            wizardStep = 1
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False
            btnOpenUTFonts.Visible = True
            lblUTFonts.Visible = True
        Else
            wizardStep = 4
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = True
            If (Me.debug) Then
                Me.Panel4.Visible = False
                Me.Panel5.Visible = True
            End If
            btnOpenUTFonts.Visible = False
            lblUTFonts.Visible = False
            btnBack.Enabled = False
            btnNext.Text = "&Export"
            Dim tempFolder As String = funcs.GetTempFolder(False)
            Me.utFontsPath = String.Concat(tempFolder, "\UTFontsASCII.win")
            File.WriteAllBytes(Me.utFontsPath, My.Resources.UTFontsASCII)

            If CurrentSession.undertaleEXE.Count > 10 Then
                exeOutput.Enabled = True
                exeOutput.Checked = True
            Else
                exeOutput.Enabled = False
                RadioButton2.Checked = True
            End If

            'Test images
            Dim imagesok As Boolean = True
            If CurrentSession.sprites.Count <= 0 Then
                imagesok = False
            Else
                Try
                    Dim maxnumb As Integer = 0
                    For Each img In CurrentSession.sprites
                        If Integer.Parse(Path.GetFileNameWithoutExtension(img.fileName)) > maxnumb Then
                            maxnumb = Integer.Parse(Path.GetFileNameWithoutExtension(img.fileName))
                        End If
                    Next
                    If maxnumb = CurrentSession.sprites.Count - 1 Then
                        imagesok = True
                    Else
                        imagesok = False
                    End If
                Catch ex As Exception
                    imagesok = False
                End Try
            End If
            'End images test
            If imagesok Then
                Me.imgPath = String.Concat(tempFolder, "\images")
                Directory.CreateDirectory(Me.imgPath)
                Dim enumerator As List(Of FileImage).Enumerator = New List(Of FileImage).Enumerator()
                Try
                    enumerator = CurrentSession.sprites.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As FileImage = enumerator.Current
                        File.WriteAllBytes(String.Concat(Me.imgPath, "\", current.fileName), current.content)
                    End While
                Finally
                    DirectCast(enumerator, IDisposable).Dispose()
                End Try
                lblImages.Text = "Images: ✔ Project default"
            End If
            If CurrentSession.undertaleEXE.Count > 10 And ExtractUndertaleEXE(CurrentSession.undertaleEXE, Path.Combine(tempFolder, "rebuild\extr"), "UndertaleTMP.exe") = ExtractionResult.OK Then
                File.Delete(Path.Combine(tempFolder, "rebuild\extr\UndertaleTMP.exe"))
                Try
                    File.Move(Path.Combine(tempFolder, "rebuild\extr\data.win"), Path.Combine(tempFolder, "data.win"))
                    dataWinPath = Path.Combine(tempFolder, "data.win")
                    lblDataWin.Text = "UT Data.win: ✔ Project default"
                Catch exception As System.Exception
                    MsgBox(exception.Message, vbCritical)
                End Try
                Me.updateStrings()
                If Me.utFontsPath = "" Or Me.dataWinPath = "" Or Me.translationPath = "" Or Me.imgPath = "" Then
                    Me.btnNext.Enabled = False
                    Me.Panel5.Visible = False
                    Me.Panel4.Visible = True
                Else
                    Me.btnNext.Enabled = True
                    If (Me.debug) Then
                        Me.btnCancel.Visible = False
                        Me.btnBack.Visible = False
                        Me.btnNext.Visible = False
                        Me.Panel5.Visible = True
                        Me.Panel4.Visible = False
                        Me.repackFonts(Path.Combine(tempFolder, "rebuild\extr\data.win"), True)
                        Dim str As String = funcs.GetTempFolder(True, "")
                        Directory.Move(Path.Combine(tempFolder, "rebuild\extr"), Path.Combine(str, "extr"))
                        Try
                            Directory.Delete(tempFolder, True)
                        Catch exception1 As System.Exception
                        End Try
                        Process.Start(str & "\extr\UNDERTALE.exe")
                        Me.closeForm()
                    End If
                End If
            Else
                Me.btnNext.Enabled = False
                Me.Panel5.Visible = False
                Me.Panel4.Visible = True
            End If
        End If
        Me.Enabled = True
    End Sub
End Class