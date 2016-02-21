Imports System.Drawing.Text
Imports System.IO

Public Class frmFontImporter
    Dim wizardStep As Integer = 1
    Dim utFontsPath As String = ""
    Dim dataWinPath As String = ""
    Dim translationPath As String = ""
    Dim imgPath As String = ""
    Dim advanced As Boolean = False

    Public Overloads Sub ShowDialog(advanced As Boolean)
        Me.advanced = advanced
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

                btnNext.Text = "&Export"
                If utFontsPath = "" Or dataWinPath = "" Or translationPath = "" Or Not imgPath = "" Then
                    btnNext.Enabled = False
                Else
                    btnNext.Enabled = True
                End If
            Case 4
                wizardStep = 5
                Dim saveFileDialog1 As New SaveFileDialog()
                Dim winPath As String = ""
                saveFileDialog1.Title = "Save as..."
                saveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                saveFileDialog1.Filter = ".WIN file | *.win"
                saveFileDialog1.FilterIndex = 2
                saveFileDialog1.RestoreDirectory = True

                If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    repackFonts(saveFileDialog1.FileName)
                Else
                    Panel4.Visible = True
                    wizardStep = 4
                End If
        End Select
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

    Private Function repackFonts(ByVal winFile As String)
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
        MsgBox("Process finished", vbInformation)
        Me.Close()
        Return True
    End Function

    Private Sub frmFontImporter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            btnOpenUTFonts.Visible = False
            lblUTFonts.Visible = False
            btnBack.Enabled = False
            btnNext.Text = "&Export"
            utFontsPath = GetTempFolder() & "\UTFontsASCII.win"
            File.WriteAllBytes(utFontsPath, My.Resources.UTFontsASCII)
            updateStrings()
            If utFontsPath = "" Or dataWinPath = "" Or translationPath = "" Or Not imgPath = "" Then
                btnNext.Enabled = False
            Else
                btnNext.Enabled = True
            End If
        End If
    End Sub
End Class