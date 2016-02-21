Imports System.IO
Imports NBT.IO
Imports NBT.Tags

Friend Class TranslataleFile
    Public lines As New Dictionary(Of Integer, LineDouble)
    Public groups As New Dictionary(Of Short, Group)

    Public Sub New()
        groups(-1) = New Group(-1, "Default", Color.Silver)
    End Sub

    Public Function NumeroRighe() As Integer
        Return lines.Count
    End Function

    Public Sub SetLines(linesOriginal As String(), linesTranslated As String())
        Dim i As Integer
        For Each line In linesTranslated
            lines.Add(i, New LineDouble(DirectCast(IIf(IsNothing(linesOriginal(i)), "", linesOriginal(i)), String), DirectCast(IIf(IsNothing(line), "", line), String)))
            i += 1
        Next
    End Sub

    Friend Shared Function Load(path1 As String) As TranslataleFile
        Dim txtmode As Boolean = IIf(Path.GetExtension(path1) = ".txt", True, False)
        Dim ttx1 As New TranslataleFile()
        If txtmode Then
            Dim textSource As String() = readStringsTXT("Open original Strings.txt file")
            If IsNothing(textSource) Then
                Return Nothing
            End If
            Dim textTranslated As String()
            Dim sr As New System.IO.StreamReader(path1)
            Try
                textTranslated = File.ReadAllLines(path1)
            Catch
                sr.Close()
                MsgBox("Can't read translation file!", MsgBoxStyle.Critical)
                Return Nothing
            End Try
            sr.Close()
            ttx1.SetLines(textSource, textTranslated)
        Else
            ttx1.groups.Clear()
            Dim nbt As New NBTFile
            nbt.Load(path1)
            Dim lineslst As TagList = nbt.RootTag("Lines")
            Dim grouplst As TagList = nbt.RootTag("Groups")
            Dim index As Integer = 0
            For Each item As TagCompound In lineslst
                Dim txteng As String
                If item.Keys.Contains("testoOriginale") Then
                    txteng = item.Item("testoOriginale").Value
                Else
                    txteng = ""
                End If
                Dim txt As String = item.Item("testo").Value
                Dim num As Integer = item.Item("numero").Value
                Dim gruppo As Short = item.Item("gruppo").Value
                Dim ls As New LineDouble(txteng, txt, gruppo)
                ttx1.lines.Add(num, ls)
                index += 1
            Next
            For Each group As TagCompound In grouplst
                Dim nome As String = group.Item("nome").Value
                Dim num As Short = group.Item("numero").Value
                Dim col As Integer = group.Item("colore").Value
                Dim gr As New Group(num, nome, Color.FromArgb(col))
                ttx1.groups.Add(num, gr)
            Next
        End If
        Return ttx1
    End Function

    Public Sub Save(path1 As String)
        Dim txtmode As Boolean = IIf(Path.GetExtension(path1) = ".txt", True, False)
        If txtmode Then
            Dim W As IO.StreamWriter
            Dim i As Integer
            W = New IO.StreamWriter(path1)
            For i = 0 To lines.Count - 1
                If i = lines.Count - 1 Then
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
        Else
            Dim nbt2 As New NBTFile

        Dim linestag2 As New TagList(10)
        Dim groupstag2 As New TagList(10)
        For Each linea In lines
            Dim linetag2 As New TagCompound()
            linetag2.Add("testoOriginale", New TagString(linea.Value.originalText))
            linetag2.Add("testo", New TagString(linea.Value.translatedText))
            linetag2.Add("numero", New TagInt(linea.Key))
            linetag2.Add("gruppo", New TagShort(linea.Value.group))
            linestag2.Add(linetag2)
        Next
        For Each gruppo In groups
            Dim grouptag2 As New TagCompound()
            grouptag2.Add("nome", New TagString(gruppo.Value.name))
            grouptag2.Add("numero", New TagShort(gruppo.Value.numero))
            grouptag2.Add("colore", New TagInt(gruppo.Value.colore.ToArgb))
            groupstag2.Add(grouptag2)
        Next
        nbt2.RootTag.Add("Lines", linestag2)
        nbt2.RootTag.Add("Groups", groupstag2)

        nbt2.Save(path1)
        End If
    End Sub

    Public Function lineeString() As String()
        Dim returnvalue As String() = New String(Me.NumeroRighe) {}
        For Each item As KeyValuePair(Of Integer, LineDouble) In lines
            returnvalue(item.Key) = item.Value.translatedText
        Next
        Return returnvalue
    End Function

    Public Function lineeStringDictionary() As Dictionary(Of Integer, String)
        Dim returnvalue As New Dictionary(Of Integer, String)
        For Each item As KeyValuePair(Of Integer, LineDouble) In lines
            returnvalue(item.Key) = item.Value.translatedText
        Next
        Return returnvalue
    End Function
End Class
