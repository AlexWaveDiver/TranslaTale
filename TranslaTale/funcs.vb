Imports System.IO
Imports System.Xml
Imports NBT.IO
Imports NBT.Tags

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

    Function LoadTTX(Optional path1 As String = Nothing) As Boolean
        Dim showpopup As Boolean = IIf(path1 = Nothing, True, False)
        frmMain.Enabled = False

        If showpopup Then
            frmMain.SaveFileDialog1.Filter = "TranslaTale file|*.ttx;*.txt|Text file|*.txt"
            frmMain.OpenFileDialog1.Filter = "TranslaTale file|*.ttx;*.txt|Text file (Translation Strings)|*.txt"
            frmMain.OpenFileDialog1.Title = "Open Project file"

            If frmMain.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                path1 = frmMain.OpenFileDialog1.FileName
            Else
                frmMain.Enabled = True
                Return False
            End If
        End If

        frmMain.stringsPnl.Enabled = False
        frmMain.TextBox1.Enabled = False
        frmMain.SaveToolStripMenuItem.Enabled = False
        frmMain.TranslationPercentageBox1.RightValue = 0
        frmMain.TranslationPercentageBox1.LeftValue = 0
        frmMain.fileNameTitle = frmMain.OpenFileDialog1.SafeFileName
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
        frmMain.showText(CurrentSession.getLine(0).translatedText)
        frmMain.stringsPnl.HideSelection = False
        frmMain.TextBox1.Text = frmMain.FilterText(CurrentSession.getLine(0).translatedText, True, False)
        frmSearch.Close()
        frmMain.Text = "TranslaTale - " + frmMain.fileNameTitle
        frmMain.countTranslated()
        frmMain.Ricalcola()
        frmMain.RicalcolaGruppi()
        If ttx1.NumeroRighe > 0 Then
            frmMain.stringsPnl.Items(0).Selected = True
        End If
        frmMain.viewMode = frmMain.ViewModes.ProjectManager
        frmMain.Enabled = True
        Return True
    End Function

    Function SaveTTX(savepath As String) As Boolean
        Try
            Dim lineslength = CurrentSession.length
            If Path.GetExtension(savepath) = ".ttx" Then
                Dim nbt2 As New NBTFile

                Dim linestag2 As New TagList(10)
                Dim groupstag2 As New TagList(10)
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
                If Not wrotedefault Then
                    Dim grouptag2 As New TagCompound()
                    grouptag2.Add("nome", New TagString("Default"))
                    grouptag2.Add("numero", New TagInt(-1))
                    grouptag2.Add("colore", New TagInt(New Group(-1, "Default").colore.ToArgb))
                    groupstag2.Add(grouptag2)
                End If
                nbt2.RootTag.Add("Lines", linestag2)
                nbt2.RootTag.Add("Groups", groupstag2)
                Try
                    nbt2.Save(savepath)
                Catch ex As Exception
                    Return False
                End Try

            Else
                Dim W As IO.StreamWriter
                Dim i As Integer
                W = New IO.StreamWriter(savepath)
                For i = 0 To lineslength
                    If i = lineslength Then
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

    Public Function FindKey(Of T, T2)(this As Dictionary(Of T, T2), val As T2) As T
        For Each item As KeyValuePair(Of T, T2) In this
            If item.Value.Equals(val) Then
                Return item.Key
            End If
        Next
        Return Nothing
    End Function
End Module
