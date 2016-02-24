Imports System.Collections.Specialized
Imports System.IO
Imports System.Xml
Imports NBT.IO
Imports NBT.Tags
Imports TranslaTale.frmMain

Module funcs
    Function GetTempFolder(Optional ByVal customFolder As Boolean = False, Optional ByVal subfolder As String = "") As String
        Dim folder As String = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
        Do While Directory.Exists(folder) Or File.Exists(folder)
            folder = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
        Loop

        System.IO.Directory.CreateDirectory(folder)
        If customFolder = True Then
            If Not subfolder = "" Then
                System.IO.Directory.CreateDirectory(folder & "\" & subfolder)
            End If
        Else
            System.IO.Directory.CreateDirectory(folder & "\UTFONTS")
            System.IO.Directory.CreateDirectory(folder & "\DATAWIN")
        End If
        Return folder
    End Function

    Function readStringsTXT(open_file_title As String) As String()
        Dim path1 As String
        frmMain.OpenFileDialog1.Filter = "Text file (Original Strings.txt file)|*.txt"
        frmMain.OpenFileDialog1.Title = open_file_title

        If frmMain.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            path1 = frmMain.OpenFileDialog1.FileName
        Else
            Return Nothing
        End If
        Dim sr As New System.IO.StreamReader(path1)
        Dim textSource As String()
        Try
            textSource = File.ReadAllLines(path1)
        Catch
            sr.Close()
            MsgBox("Can't read source file!", MsgBoxStyle.Critical)
            Return Nothing
        End Try
        sr.Close()
        Return textSource
    End Function

    Function LoadTTXPopup() As Boolean
        frmMain.SaveFileDialog1.Filter = "TranslaTale file|*.ttx;*.txt|Text file|*.txt"
        frmMain.OpenFileDialog1.Filter = "TranslaTale file|*.ttx;*.txt|Text file (Translation Strings)|*.txt"
        frmMain.OpenFileDialog1.Title = "Open Project file"

        If frmMain.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Return LoadTTX(frmMain.OpenFileDialog1.FileName)
        Else
            Return False
        End If
    End Function

    Function LoadTTX(path1 As String) As Boolean
        frmMain.Enabled = False

        frmMain.stringsPnl.Enabled = False
        frmMain.stringTextEditor.Enabled = False
        frmMain.SaveToolStripMenuItem.Enabled = False
        frmMain.TranslationPercentageBox1.RightValue = 0
        frmMain.TranslationPercentageBox1.LeftValue = 0
        frmMain.stringsPnl.Clear()
        frmMain.stringsPnl.View = View.Details
        frmMain.stringsPnl.Clear()
        CurrentSession.clear()
        frmMain.stringsPnl.ShowGroups = False
        frmMain.stringsPnl.Columns.Clear()
        frmMain.stringsPnl.Columns.Add("Line", 100, HorizontalAlignment.Left)
        frmMain.stringsPnl.Columns.Add("Base text", 150, HorizontalAlignment.Left)
        frmMain.stringsPnl.Columns.Add("Translated text", 200, HorizontalAlignment.Left)

        frmMain.stringsPnl.HideSelection = True
        frmMain.stringsPnl.FullRowSelect = True
        frmMain.stringsPnl.CheckBoxes = False

        frmMain.ListViewHelper.EnableDoubleBuffer(frmMain.stringsPnl)

        With frmMain.stringsPnl
            .Columns(0).Width = 65
            .Columns(1).Width = CInt((.Width - 65) * 0.45)
            .Columns(2).Width = CInt((.Width - 65) * 0.5)
        End With

        Dim ttx1 As TranslataleFile = TranslataleFile.Load(path1)


        If IsNothing(ttx1) Then
            frmMain.Enabled = True
            Return False
        End If

        If ttx1.NumeroRighe < 0 Then
            MsgBox("The files can't be empty!", vbExclamation)
            frmMain.Enabled = True
            Return False
        End If

        Dim i As Integer
        For i = 0 To ttx1.NumeroRighe - 1
            Dim lnToAdd As LineDouble = ttx1.lines(i)
            Dim itemToAdd As New ListViewItem({i + 1, ttx1.lines(i).originalText, ttx1.lines(i).translatedText})
            If lnToAdd.Tradotto() Then
                itemToAdd.BackColor = Color.LightGreen
            Else
                itemToAdd.BackColor = Color.LightSalmon
            End If
            CurrentSession.lines.Add(i, lnToAdd)
            CurrentSession.listViewObjects.Add(i, itemToAdd)
        Next i
        CurrentSession.groups.Clear()
        For Each group In ttx1.groups
            CurrentSession.groups.Add(group.Value.numero, group.Value)
        Next
        CurrentSession.sprites = ttx1.images
        CurrentSession.undertaleWIN = ttx1.undertaleWIN
        CurrentSession.undertaleEXE = ttx1.undertaleEXE
        CurrentSession.projectName = ttx1.projectName
        frmMain.showText(CurrentSession.getLine(0).translatedText)
        frmMain.stringsPnl.HideSelection = False
        frmMain.stringTextEditor.Text = frmMain.FilterText(CurrentSession.getLine(0).translatedText, True, False)
        frmSearch.Close()
        frmMain.Text = "TranslaTale - " + ttx1.projectName
        frmMain.countTranslated()
        frmMain.Ricalcola()
        frmMain.RicalcolaGruppi()
        If ttx1.NumeroRighe > 0 Then
            frmMain.stringsPnl.Items(0).Selected = True
        End If

        'WORK WITH HISTORY
        'This variables have random names because i recovered them using a decompiler.
        If (IsNothing(My.Settings.filesHistory)) Then
            My.Settings.filesHistory = New StringCollection()
        End If
        Dim count As Integer = My.Settings.filesHistory.Count
        If (count < 1) Then
            My.Settings.filesHistory.Add(path1 & "|" & ttx1.projectName)
        Else
            My.Settings.filesHistory.Add(My.Settings.filesHistory(count - 1))
            For ii As Integer = count - 1 To 1 Step -1
                My.Settings.filesHistory(ii) = My.Settings.filesHistory(ii - 1)
            Next

            My.Settings.filesHistory(0) = path1 & "|" & ttx1.projectName
        End If
        Dim count1 As Integer = My.Settings.filesHistory.Count
        Dim stringCollections As StringCollection = New StringCollection()
        For j As Integer = count1 - 1 To 0 Step -1
            Dim num2 As Integer = count1 - 1
            Dim num3 As Integer = 0
            Do
                If (My.Settings.filesHistory(num3).Split("|").FirstOrDefault = My.Settings.filesHistory(j).Split("|").FirstOrDefault And num3 <> j) Then
                    My.Settings.filesHistory(j) = ""
                End If
                num3 = num3 + 1
            Loop While num3 <= num2
            If My.Settings.filesHistory(j) <> "" Then
                stringCollections.Add(My.Settings.filesHistory(j))
            End If
        Next

        Dim stringCollections1 As StringCollection = New StringCollection()
        For k As Integer = stringCollections.Count - 1 To 0 Step -1
            stringCollections1.Add(stringCollections(k))
        Next

        My.Settings.filesHistory = stringCollections1
        My.Settings.Save()
        'END HISTORY UPDATING

        frmMain.viewMode = frmMain.ViewModes.ProjectManager
        frmMain.Enabled = True
        Return True
    End Function

    Public Enum SaveResultAsk
        YES
        Yes_but_Errors
        No
        Cancel
        AlreadySaved
    End Enum

    Public Enum SaveResult
        Done
        Errors
        Cancel
    End Enum

    Function SaveTTXDialogAsk() As SaveResultAsk
        Dim stat As Integer
        If frmMain.saved = False Then
            stat = MsgBox("Do you want to save your changes?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                Return SaveResult.Cancel
            ElseIf stat = 6 Then
                Dim stat2 = SaveTTXDialog()
                If stat2 = SaveResult.Done Then
                    Return SaveResultAsk.YES
                ElseIf stat2 = SaveResult.Cancel Then
                    Return SaveResultAsk.Cancel
                ElseIf stat2 = SaveResult.Errors Then
                    Return SaveResultAsk.Yes_but_Errors
                Else
                    Return SaveResultAsk.Yes_but_Errors
                End If
            Else
                Return SaveResultAsk.No
            End If
        Else
            Return SaveResultAsk.AlreadySaved
        End If
    End Function

    Function SaveTTXDialog() As SaveResult
        frmMain.Enabled = False
        Dim fil As Efiltro = frmMain.filtro
        Dim filg As Integer = frmMain.filtroGruppo
        If (frmMain.filtro <> Efiltro.Default_mode) Then
            frmMain.filtro = Efiltro.Default_mode
            frmMain.filtroGruppo = -1
            frmMain.Ricalcola()
            frmMain.Enabled = False
        End If
        frmMain.filtro = fil
        frmMain.filtroGruppo = filg
        fil = Nothing
        frmMain.SaveFileDialog1.Title = "Save translation file"
        frmMain.SaveFileDialog1.Filter = "TranslaTale file|*.ttx|Export translation Strings.txt|*.txt"
        If frmMain.SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            frmMain.saved = SaveTTX(frmMain.SaveFileDialog1.FileName)
            If frmMain.saved = False Then
                MsgBox("Error during file saving!" & vbCrLf & "Please, retry.", MsgBoxStyle.Critical, "TranslaTale")
                frmMain.Enabled = True
                Return SaveResult.Errors
            End If
        Else
            frmMain.Enabled = True
            Return SaveResult.Cancel
        End If
        frmMain.Text = "TranslaTale - " + CurrentSession.projectName
        frmMain.Enabled = True
        Return SaveResult.Done
    End Function

    Function SaveTTX(savepath As String) As Boolean
        Try
            Dim lineslength = CurrentSession.length
            If Path.GetExtension(savepath) = ".ttx" Then
                Dim nbt2 As New NBTFile

                Dim linestag2 As New TagList(10)
                Dim groupstag2 As New TagList(10)
                Dim imageslst As New TagCompound()
                For Each linea In CurrentSession.lines
                    Dim linetag2 As New TagCompound()
                    If linea.Value.originalText <> Nothing Then
                        linetag2.Add("testoOriginale", New TagString(linea.Value.originalText))
                    Else
                        linetag2.Add("testoOriginale", New TagString(""))
                    End If
                    If linea.Value.translatedText <> Nothing Then
                        linetag2.Add("testo", New TagString(linea.Value.translatedText))
                    Else
                        linetag2.Add("testo", New TagString(""))
                    End If
                    linetag2.Add("numero", New TagInt(linea.Key))
                    linetag2.Add("gruppo", New TagInt(linea.Value.group))
                    linestag2.Add(linetag2)
                Next
                Dim wrotedefault As Boolean = False
                For Each gruppo In CurrentSession.groups
                    Dim grouptag2 As New TagCompound()
                    grouptag2.Add("nome", New TagString(gruppo.Value.name))
                    grouptag2.Add("numero", New TagInt(gruppo.Value.numero))
                    grouptag2.Add("colore", New TagInt(gruppo.Value.colore.ToArgb))
                    groupstag2.Add(grouptag2)
                    If (gruppo.Value.numero = -1) Then
                        wrotedefault = True
                    End If
                Next
                For Each image In CurrentSession.sprites
                    imageslst.Add(image.fileName, New TagByteArray(image.content))
                Next
                If Not wrotedefault Then
                    Dim grouptag2 As New TagCompound()
                    grouptag2.Add("nome", New TagString("Default"))
                    grouptag2.Add("numero", New TagInt(-1))
                    grouptag2.Add("colore", New TagInt(New Group(-1, "Default").colore.ToArgb))
                    groupstag2.Add(grouptag2)
                End If
                nbt2.RootTag.Add("Lines", linestag2)
                nbt2.RootTag.Add("Groups", groupstag2)
                nbt2.RootTag.Add("Images", imageslst)
                nbt2.RootTag.Add("Undertale", New TagByteArray(CurrentSession.undertaleEXE))
                nbt2.RootTag.Add("data.win", New TagByteArray(CurrentSession.undertaleWIN))
                nbt2.RootTag.Add("Project name", New TagString(CurrentSession.projectName))
                Try
                    nbt2.Save(savepath)
                Catch ex As Exception
                    Return False
                End Try

            Else
                Dim W As IO.StreamWriter
                Dim i As Integer
                W = New IO.StreamWriter(savepath)
                For i = 0 To lineslength - 1
                    If i = lineslength - 1 Then
                        If CurrentSession.lines.ContainsKey(i) Then
                            W.Write(CurrentSession.lines(i).translatedText)
                        Else
                            W.Write("")
                        End If
                    Else
                        If CurrentSession.lines.ContainsKey(i) Then
                            W.WriteLine(CurrentSession.lines(i).translatedText)
                        Else
                            W.WriteLine("")
                        End If
                    End If
                Next
                W.Close()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Enum ExtractionResult
        OK
        CantExtract
        Problematic
        EmptyFile
    End Enum

    Public Function ExtractUndertaleEXE(ByVal undertaleEXESource As Byte(), ByVal outputPath As String, ByVal outputName As String) As ExtractionResult
        Dim flag As ExtractionResult = ExtractionResult.OK
        Dim str As String = outputPath
        If (Not Directory.Exists(outputPath)) Then
            Directory.CreateDirectory(outputPath)
        End If
        If (undertaleEXESource.Count <= 10) Then
            flag = ExtractionResult.EmptyFile
        Else
            File.WriteAllBytes(Path.Combine(str, outputName), undertaleEXESource)
            File.WriteAllBytes(Path.Combine(str, "7z.exe"), My.Resources._7zEXE)
            File.WriteAllBytes(Path.Combine(str, "7z.dll"), My.Resources._7zDLL)
            Dim processStartInfo As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo(Path.Combine(str, "7z.exe"), String.Concat("x -y -aoa """, outputName, """")) With
                {
                    .RedirectStandardError = True,
                    .RedirectStandardOutput = False,
                    .CreateNoWindow = False,
            .WindowStyle = ProcessWindowStyle.Normal,
                    .UseShellExecute = False,
                    .WorkingDirectory = str
                }
            Dim process As System.Diagnostics.Process = New System.Diagnostics.Process() With
                {
                    .StartInfo = processStartInfo
                }
            process.Start()
            process.WaitForExit()
            If (Not IsError(process.StandardError.ReadToEnd()) And process.StandardError.ReadToEnd().Count > 0) Then
                MsgBox(process.StandardOutput.ReadToEnd & vbCrLf & vbCrLf & vbCrLf & process.StandardError.ReadToEnd, vbCritical)
                undertaleEXESource = Nothing
                flag = ExtractionResult.CantExtract
            ElseIf Not File.Exists(Path.Combine(str, "data.win")) Then
                undertaleEXESource = Nothing
                flag = ExtractionResult.Problematic
            End If
            File.Delete(Path.Combine(str, "7z.exe"))
            File.Delete(Path.Combine(str, "7z.dll"))
            If IsNothing(undertaleEXESource) And flag = ExtractionResult.OK Then
                flag = ExtractionResult.EmptyFile
            End If
        End If
        Return flag
    End Function

    Public Function extractStringsFromWIN(ByVal undertaleWINSource As Byte(), ByVal outputFile As String) As ExtractionResult
        Dim winPath As String
        Dim unpackStringsProc As Process

        Dim tmpPath As String = GetTempFolder(True)

        winPath = Path.Combine(tmpPath, "mydatawin.win")
        File.WriteAllBytes(winPath, undertaleWINSource)

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

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

        Try
            File.Copy(tmpPath & "\STRG.txt", outputFile, True)
        Catch ex As Exception
            Return ExtractionResult.Problematic
        End Try

        System.IO.Directory.Delete(tmpPath, True)

        Return ExtractionResult.OK
    End Function

    Public Function extractSpritesFromWIN(ByVal undertaleWINSource As Byte(), ByVal outputPath As String) As ExtractionResult
        Dim tmpPath As String = GetTempFolder(True)
        Dim winPath As String = Path.Combine(tmpPath, "mydatawin.win")
        File.WriteAllBytes(winPath, undertaleWINSource)
        Dim unpackImagesProc As Process

        If Not Directory.Exists(outputPath) Then
            Directory.CreateDirectory(outputPath)
        End If

        Dim filename As String = Path.Combine(Application.StartupPath, "WinExtract.exe")
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim p As New ProcessStartInfo
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
        Try

            For Each f In Directory.GetFiles(tmpPath & "\TXTR\", "*.png")
                If File.Exists(f) Then
                    If File.Exists(Path.Combine(outputPath, Path.GetFileName(f))) Then
                        File.Delete(Path.Combine(outputPath, Path.GetFileName(f)))
                    End If
                    File.Move(f, Path.Combine(outputPath, Path.GetFileName(f)))
                End If
            Next
        Catch
        End Try
        System.IO.Directory.Delete(tmpPath, True)
        Return ExtractionResult.OK
    End Function

    Public Function importSprites(ByVal paths As String(), Optional ByVal silent As Boolean = False, Optional ByVal canOverwrite As Boolean = True) As Object
        Dim result As Object
        Try
            Dim spritesAdded As Integer = 0
            Dim spritesOverwrited As Integer = 0
            Dim images As String() = paths
            Dim max = images.Count - 1
            For i As Integer = 0 To max
                Dim image As String = images(i)
                Try
                    If (Integer.TryParse(Path.GetFileNameWithoutExtension(image), False)) Then
                        Dim streamReader As New StreamReader(image)
                        Dim fileImage As TranslaTale.FileImage = New TranslaTale.FileImage(File.ReadAllBytes(image), Path.GetFileName(image))
                        streamReader.Close()
                        Dim foundSameImageIndex As Integer = -1
                        Dim existingImageIndex As Integer = 0
                        For Each existingImage In CurrentSession.sprites
                            If existingImage.fileName <> fileImage.fileName Then
                                existingImageIndex = existingImageIndex + 1
                            Else
                                foundSameImageIndex = existingImageIndex
                                Exit For
                            End If
                        Next
                        If (foundSameImageIndex = -1) Then
                            spritesAdded = spritesAdded + 1
                            CurrentSession.sprites.Add(fileImage)
                        ElseIf (canOverwrite) Then
                            spritesOverwrited = spritesOverwrited + 1
                            CurrentSession.sprites(foundSameImageIndex) = fileImage
                        End If
                    Else
                        MsgBox(image, vbCritical)
                    End If
                Catch
                    If (Not silent) Then
                        Interaction.MsgBox(String.Concat("Can't import ", Path.GetFileName(image)), MsgBoxStyle.Exclamation, Nothing)
                    End If
                End Try
            Next
            frmMain.saved = False
            If (Not silent) Then
                Interaction.MsgBox("Done!" & vbCrLf & "" & spritesAdded & " sprites added." & vbCrLf & "" & spritesOverwrited & " sprites overwrited.", MsgBoxStyle.Information, Nothing)
            End If
            frmMain.updateComponents()
            result = True
        Catch exception1 As System.Exception
            result = False
        End Try
        Return result
    End Function

    Public Function FindKey(Of T, T2)(this As Dictionary(Of T, T2), val As T2) As T
        For Each item As KeyValuePair(Of T, T2) In this
            If item.Value.Equals(val) Then
                Return item.Key
            End If
        Next
        Return Nothing
    End Function
End Module
