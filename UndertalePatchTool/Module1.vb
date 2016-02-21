Imports System.IO

Module Module1

    Dim title As String
    Dim subtitle As String

    Function fulllengthstring(chr As String) As String
        Dim out As String = ""
        For index = 1 To Console.BufferWidth
            out = out & chr
        Next
        Return out
    End Function

    Dim modalitaexe As Boolean = True

    Private Function filename() As String
        If modalitaexe Then
            Return "UNDERTALE.exe"
        Else
            Return "data.win"
        End If
    End Function

    Private Function fileext() As String
        If modalitaexe Then
            Return ".exe"
        Else
            Return ".win"
        End If
    End Function

    Sub Main()
inizio: title = "Undertale patcher tool v9"
        subtitle = "Welcome in Undertale patcher tool."
        impostaschermata()
        'Console.Write("1. Decomprimi le stringhe da " & filename())
        'Console.SetCursorPosition(1, 6)
        'Console.Write("2. Decomprimi le immagini da " & filename())
        'Console.SetCursorPosition(1, 7)
        'Console.Write("3. Comprimi le stringhe in " & filename())
        'Console.SetCursorPosition(1, 8)
        'Console.Write("4. Comprimi le immagini in " & filename())
        'Console.SetCursorPosition(1, 9)
        'Console.ForegroundColor = ConsoleColor.Red
        'If modalitaexe = False Then
        'Console.Write("5. Modalita' UNDERTALE.exe")
        'Else
        'Console.Write("5. Modalita' data.win")
        'End If
        Console.SetCursorPosition(1, 11)
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("6. Make final patch")

        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.SetCursorPosition(0, 0)
        Dim response = Console.ReadKey()
        If response.Key = ConsoleKey.D1 Then
            GoTo inizio
D1:         title = "Decomprimi le stringhe da " & filename()
            subtitle = "Seleziona " & filename()
            impostaschermata()
            Dim openfile = New System.Windows.Forms.OpenFileDialog()
            openfile.Title = "Scegli " & filename()
            openfile.Multiselect = False
            openfile.CheckFileExists = True
            openfile.Filter = "Data file|*" & fileext() & "|Other files|*.*"
            Dim result = openfile.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(openfile.FileName.Replace("""", "")) <> fileext() Then
                    MsgBox("Devi selezionare " & filename() & "!", MsgBoxStyle.Critical)
                    GoTo D1
                End If
                subtitle = "Seleziona strings.txt"
                impostaschermata()
                Dim out As New System.Windows.Forms.SaveFileDialog()
                out.Title = "Scegli dove salvare le stringhe"
                out.CheckFileExists = False
                out.Filter = "Text|*.txt"
                out.ShowDialog()

                Dim winfilename = openfile.FileName.Replace("""", "")
                If modalitaexe Then
                    Dim pe As New ProcessStartInfo
                    pe.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") & "\7za.exe" & """"
                    pe.WindowStyle = ProcessWindowStyle.Hidden
                    pe.Arguments = "e """ & openfile.FileName.Replace("""", "") & """ data.win -aoa"

                    Dim extractStringsProc As Process
                    extractStringsProc = Process.Start(pe)
                    extractStringsProc.WaitForExit()
                    For i = 0 To 4
                        If Not extractStringsProc.HasExited Then
                            extractStringsProc.Refresh()
                        Else
                            Exit For
                        End If
                    Next
                    winfilename = Path.GetDirectoryName(openfile.FileName.Replace("""", "")) & "\data.win"
                End If

                Dim p As New ProcessStartInfo
                p.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\gmktool.exe" & """"
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.Arguments = """" & winfilename & """ strings unpack """ & out.FileName.Replace("""", "") & """"

                Dim unpackStringsProc As Process
                unpackStringsProc = Process.Start(p)
                unpackStringsProc.WaitForExit()
                For i = 0 To 4
                    If Not unpackStringsProc.HasExited Then
                        unpackStringsProc.Refresh()
                    Else
                        Exit For
                    End If
                Next
                subtitle = "Operazione completata!"
                impostaschermata()
                Console.ReadKey()
                GoTo inizio
            Else
                GoTo inizio
            End If
        ElseIf response.Key = ConsoleKey.D2 Then
            GoTo inizio
D2:         title = "Decomprimi le immagini da " & filename()
            subtitle = "Seleziona " & filename()
            impostaschermata()
            Dim openfile = New System.Windows.Forms.OpenFileDialog()
            openfile.Title = "Scegli " & filename()
            openfile.Multiselect = False
            openfile.CheckFileExists = True
            openfile.Filter = "Data file|*" & fileext() & "|Other files|*.*"
            Dim result = openfile.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(openfile.FileName.Replace("""", "")) <> fileext() Then
                    MsgBox("Devi selezionare " & filename() & "!", MsgBoxStyle.Critical)
                    GoTo D2
                End If
                Dim options As Integer = &H40 + &H20
                options += &H10   '' Adds edit box
                Dim shell = Nothing '                           New Shell32.ShellClass
                Dim root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Dim folder = CType(shell.BrowseForFolder(Nothing,
        "Scegli la cartella in cui esportare le immagini", options, root), Shell32.Folder2)
                If folder Is Nothing Then
                    GoTo inizio
                End If
                Dim winfilename = openfile.FileName.Replace("""", "")
                If modalitaexe Then
                    Dim pe As New ProcessStartInfo
                    pe.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") & "\7za.exe" & """"
                    pe.WindowStyle = ProcessWindowStyle.Hidden
                    pe.Arguments = "e """ & openfile.FileName.Replace("""", "") & """ data.win -aoa"

                    Dim extractStringsProc As Process
                    extractStringsProc = Process.Start(pe)
                    extractStringsProc.WaitForExit()
                    For i = 0 To 4
                        If Not extractStringsProc.HasExited Then
                            extractStringsProc.Refresh()
                        Else
                            Exit For
                        End If
                    Next
                    winfilename = Path.GetDirectoryName(openfile.FileName.Replace("""", "")) & "\data.win"
                End If

                Dim p As New ProcessStartInfo
                p.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\gmktool.exe" & """"
                p.WorkingDirectory = folder.Self.Path
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.Arguments = """" & winfilename & """ textures unpack"

                Dim unpackStringsProc As Process
                unpackStringsProc = Process.Start(p)
                unpackStringsProc.WaitForExit()
                For i = 0 To 4
                    If Not unpackStringsProc.HasExited Then
                        unpackStringsProc.Refresh()
                    Else
                        Exit For
                    End If
                Next i
                subtitle = "Operazione completata!"
                impostaschermata()
                Console.ReadKey()
                GoTo inizio
            Else
                GoTo inizio
            End If
        ElseIf response.Key = ConsoleKey.D3 Then
            GoTo inizio
D3:         title = "Comprimi le stringhe in " & filename()
            subtitle = "Seleziona " & filename()
            impostaschermata()
            Dim openfile = New System.Windows.Forms.OpenFileDialog()
            openfile.Title = "Scegli " & filename()
            openfile.Multiselect = False
            openfile.CheckFileExists = True
            openfile.Filter = "Data file|*" & fileext() & "|Other files|*.*"
            Dim result = openfile.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(openfile.FileName.Replace("""", "")) <> fileext() Then
                    MsgBox("Devi selezionare " & filename() & "!", MsgBoxStyle.Critical)
                    GoTo D3
                End If
                subtitle = "Seleziona strings.txt"
                impostaschermata()
                Dim out As New System.Windows.Forms.OpenFileDialog()
                out.Title = "Scegli quali stringhe comprimere"
                out.CheckFileExists = True
                out.Filter = "Text|*.txt"
                out.ShowDialog()

                Dim winfilename = openfile.FileName.Replace("""", "")
                If modalitaexe Then
                    Dim pe As New ProcessStartInfo
                    pe.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") & "\7za.exe" & """"
                    pe.WindowStyle = ProcessWindowStyle.Hidden
                    pe.Arguments = "e """ & openfile.FileName.Replace("""", "") & """ *.* -aoa -oextr"

                    Dim extractStringsProc As Process
                    extractStringsProc = Process.Start(pe)
                    extractStringsProc.WaitForExit()
                    For i = 0 To 4
                        If Not extractStringsProc.HasExited Then
                            extractStringsProc.Refresh()
                        Else
                            Exit For
                        End If
                    Next
                    winfilename = Windows.Forms.Application.StartupPath.Replace("""", "") & "\extr\data.win"
                End If

                subtitle = "Sto comprimento le stringhe..."
                impostaschermata()

                Dim p As New ProcessStartInfo
                p.WorkingDirectory = Path.GetDirectoryName(winfilename)
                p.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\gmktool.exe" & """"
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.Arguments = """" & winfilename & """ strings repack """ & out.FileName & """"
                Dim unpackStringsProc As Process
                unpackStringsProc = Process.Start(p)
                unpackStringsProc.WaitForExit()
                For i = 0 To 4
                    If Not unpackStringsProc.HasExited Then
                        unpackStringsProc.Refresh()
                    Else
                        Exit For
                    End If
                Next

                If modalitaexe Then
                    subtitle = "Sto comprimento data.win..."
                    impostaschermata()

                    Dim rebuildp As New ProcessStartInfo
                    rebuildp.WorkingDirectory = Windows.Forms.Application.StartupPath
                    rebuildp.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTRebuildSFXCAB.exe" & """"
                    rebuildp.WindowStyle = ProcessWindowStyle.Hidden
                    rebuildp.Arguments = ""
                    Dim rebuildProc As Process
                    rebuildProc = Process.Start(rebuildp)
                    File.Delete(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe")
                    While Not File.Exists(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe")
                        Threading.Thread.Sleep(500)
                    End While
                    rebuildProc.Kill()
                    File.Delete(openfile.FileName.Replace("""", ""))
                    For index = 1 To 30
                        Try
                            Try
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Refresh()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.CloseMainWindow()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Close()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Kill()
                                End If
                            Catch ex As Exception
                            End Try
                            File.Move(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe", openfile.FileName.Replace("""", ""))
                            Exit For
                        Catch ex As Exception
                            Threading.Thread.Sleep(500)
                        End Try
                    Next
                    Directory.Delete(Windows.Forms.Application.StartupPath.Replace("""", "") + "\extr", True)
                    If rebuildProc.HasExited Then
                        subtitle = "Operazione completata!"
                    Else
                        subtitle = "Completato.\n Impossibile rinominare 'UDTREBUILT.exe'\n in '" & Path.GetFileName(openfile.FileName.Replace("""", "")) & "'"
                    End If
                Else
                    subtitle = "Operazione completata!"
                End If
                impostaschermata()
                Console.ReadKey()
                GoTo inizio
            Else
                GoTo inizio
            End If
        ElseIf response.Key = ConsoleKey.D4 Then
            GoTo inizio
D4:         title = "Comprimi le immagini in " & filename()
            subtitle = "Seleziona " & filename()
            impostaschermata()
            Dim openfile = New System.Windows.Forms.OpenFileDialog()
            openfile.Title = "Scegli " & filename()
            openfile.Multiselect = False
            openfile.CheckFileExists = True
            openfile.Filter = "Data file|*" & fileext() & "|Other files|*.*"
            Dim result = openfile.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(openfile.FileName.Replace("""", "")) <> fileext() Then
                    MsgBox("Devi selezionare " & filename() & "!", MsgBoxStyle.Critical)
                    GoTo D4
                End If
                Dim options As Integer = &H40 + &H20 + &H200
                options += &H10   '' Adds edit box
                Dim shell = Nothing '                            New Shell32.ShellClass
                Dim root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Dim folder = CType(shell.BrowseForFolder(Nothing,
        "Scegli la cartella contenente le immagini", options, root), Shell32.Folder2)
                If folder Is Nothing Then
                    GoTo inizio
                End If

                Dim winfilename = openfile.FileName.Replace("""", "")
                If modalitaexe Then
                    Dim pe As New ProcessStartInfo
                    pe.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") & "\7za.exe" & """"
                    pe.WindowStyle = ProcessWindowStyle.Hidden
                    pe.Arguments = "e """ & openfile.FileName.Replace("""", "") & """ *.* -aoa -oextr"

                    Dim extractStringsProc As Process
                    extractStringsProc = Process.Start(pe)
                    extractStringsProc.WaitForExit()
                    For i = 0 To 4
                        If Not extractStringsProc.HasExited Then
                            extractStringsProc.Refresh()
                        Else
                            Exit For
                        End If
                    Next
                    winfilename = Windows.Forms.Application.StartupPath.Replace("""", "") & "\extr\data.win"
                End If

                Dim p As New ProcessStartInfo
                p.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\gmktool.exe" & """"
                p.WorkingDirectory = folder.Self.Path
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.Arguments = """" & winfilename & """ textures repack"

                subtitle = "Sto comprimento le immagini..."
                impostaschermata()

                Dim unpackStringsProc As Process
                unpackStringsProc = Process.Start(p)
                unpackStringsProc.WaitForExit()
                For i = 0 To 4
                    If Not unpackStringsProc.HasExited Then
                        unpackStringsProc.Refresh()
                    Else
                        Exit For
                    End If
                Next

                If modalitaexe Then
                    subtitle = "Sto comprimento data.win..."
                    impostaschermata()

                    Dim rebuildp As New ProcessStartInfo
                    rebuildp.WorkingDirectory = Windows.Forms.Application.StartupPath
                    rebuildp.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTRebuildSFXCAB.exe" & """"
                    rebuildp.WindowStyle = ProcessWindowStyle.Hidden
                    rebuildp.Arguments = ""
                    Dim rebuildProc As Process
                    rebuildProc = Process.Start(rebuildp)
                    File.Delete(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe")
                    While Not File.Exists(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe")
                        Threading.Thread.Sleep(500)
                    End While
                    rebuildProc.Kill()
                    File.Delete(openfile.FileName)
                    For index = 1 To 30
                        Try
                            Try
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Refresh()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.CloseMainWindow()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Close()
                                End If
                                If Not rebuildProc.HasExited Then
                                    rebuildProc.Kill()
                                End If
                            Catch ex As Exception
                            End Try
                            File.Move(Windows.Forms.Application.StartupPath.Replace("""", "") + "\UDTREBUILT.exe", openfile.FileName)
                            Exit For
                        Catch ex As Exception
                            Threading.Thread.Sleep(500)
                        End Try
                    Next
                    Directory.Delete(Windows.Forms.Application.StartupPath.Replace("""", "") + "\extr", True)
                    If rebuildProc.HasExited Then
                        subtitle = "Operazione completata!"
                    Else
                        subtitle = "Completato.\n Impossibile rinominare 'UDTREBUILT.exe'\n in '" & Path.GetFileName(openfile.FileName) & "'"
                    End If
                Else
                    subtitle = "Operazione completata!"
                End If
                impostaschermata()
                Console.ReadKey()
                GoTo inizio
            Else
                GoTo inizio
            End If
        ElseIf response.Key = ConsoleKey.D5 Then
            GoTo inizio
D5:         modalitaexe = Not modalitaexe
        ElseIf response.Key = ConsoleKey.D6 Then
D6:         title = "Create final patch"
            subtitle = "Choose an original data.win!"
            impostaschermata()

            Dim olddatawin As String = ""
            Dim oldopenfile = New System.Windows.Forms.OpenFileDialog()
            oldopenfile.Title = "Choose an original data.win"
            oldopenfile.Multiselect = False
            oldopenfile.CheckFileExists = True
            oldopenfile.Filter = "Data file|*.win|Other files|*.*"
            Dim oldresult = oldopenfile.ShowDialog()
            If oldresult = Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(oldopenfile.FileName.Replace("""", "")) <> ".win" Then
                    MsgBox("You must choose data.win!", MsgBoxStyle.Critical)
                    GoTo D6
                End If

                olddatawin = oldopenfile.FileName
                Console.BackgroundColor = ConsoleColor.DarkBlue
                Console.ForegroundColor = ConsoleColor.DarkBlue
                Console.SetCursorPosition(0, 0)
                subtitle = "Choose translated data.win"
                impostaschermata()
                Dim openfile = New System.Windows.Forms.OpenFileDialog()
                openfile.Title = "Choose translated data.win"
                openfile.Multiselect = False
                openfile.CheckFileExists = True
                openfile.Filter = "Data file|*.win|Other files|*.*"
                Dim result = openfile.ShowDialog()
                If result = Windows.Forms.DialogResult.OK Then
                    If Path.GetExtension(openfile.FileName.Replace("""", "")) <> ".win" Then
                        MsgBox("You must choose data.win!", MsgBoxStyle.Critical)
                        GoTo D6
                    End If
                    subtitle = "Choose patch save path"
                    impostaschermata()
                    Dim out As New System.Windows.Forms.SaveFileDialog()
                    out.Title = "Choose where you want to save the patch"
                    out.CheckFileExists = False
                    out.Filter = "Patch|*.xdelta"
                    out.ShowDialog()

                    Dim newwinfilename = openfile.FileName.Replace("""", "")
                    Dim oldwinfilename = olddatawin.Replace("""", "")
                    Dim outputpatchfilename = out.FileName.Replace("""", "")

                    Dim p As New ProcessStartInfo
                    p.FileName = """" & Windows.Forms.Application.StartupPath.Replace("""", "") + "\xdelta.exe" & """"
                    p.WindowStyle = ProcessWindowStyle.Hidden
                    p.Arguments = "-e -s """ & oldwinfilename & """ """ & newwinfilename & """ """ & outputpatchfilename & """"

                    Dim unpackStringsProc As Process
                    unpackStringsProc = Process.Start(p)
                    unpackStringsProc.WaitForExit()
                    For i = 0 To 4
                        If Not unpackStringsProc.HasExited Then
                            unpackStringsProc.Refresh()
                        Else
                            Exit For
                        End If
                    Next
                    subtitle = "Done!"
                    impostaschermata()
                    Console.ReadKey()
                    GoTo inizio
                Else
                    GoTo inizio
                End If
            End If
        End If
        GoTo inizio
    End Sub



    Sub impostaschermata()
        Console.Title = "UT patcher tool by XDrake99"
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.DarkGray
        Console.Clear()
        Console.OutputEncoding = Text.Encoding.ASCII
        Console.CursorVisible = False
        Console.WindowWidth = 45
        Console.BufferWidth = 45
        Console.WindowHeight = 13
        Console.BufferHeight = 13
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.SetCursorPosition(0, 0)
        Console.Write(fulllengthstring(" "))
        Console.SetCursorPosition(0, 1)
        Console.Write(fulllengthstring(" "))
        Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, 1)
        Console.Write(title)
        Console.SetCursorPosition(0, 2)
        Console.Write(fulllengthstring("_"))
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.DarkGray
        Console.SetCursorPosition(1, 4)
        Console.Write(subtitle)

        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.SetCursorPosition(1, 5)
    End Sub

End Module
