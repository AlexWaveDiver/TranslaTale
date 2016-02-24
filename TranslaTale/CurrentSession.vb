Imports TranslaTale.frmMain

Public Class CurrentSession
    Public Shared lines As New Dictionary(Of Integer, LineDouble)
    Public Shared listViewObjects As New Dictionary(Of Integer, ListViewItem)
    Public Shared groups As New Dictionary(Of Short, Group)
    Public Shared undertaleWIN As Byte() = New Byte() {}
    Public Shared undertaleEXE As Byte() = New Byte() {}
    Public Shared sprites As New List(Of FileImage)
    Public Shared projectName As String = "New project"
    Public Shared isProjectFile As Boolean = False
    Public Shared projectPath As String = ""

    Public Shared Function getIndex(item As ListViewItem) As Integer
        If Integer.TryParse(item.SubItems(0).Text, 0) Then
            Return Integer.Parse(item.SubItems(0).Text) - 1
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function getLine(item As ListViewItem) As LineDouble
        If isLine(item) Then
            Dim numb As Integer = getIndex(item)
            If lines.ContainsKey(numb) Then
                Return lines(numb)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function getLine(item As Integer) As LineDouble
        If lines.ContainsKey(item) Then
            Return lines(item)
        Else
            Return New LineDouble("", "")
        End If
    End Function

    Public Shared Function isLine(item As ListViewItem) As Integer
        If Integer.TryParse(item.SubItems(0).Text, 0) Then
            Return True
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function length() As Integer
        Dim maxnumb As Integer = -1
        For Each item In lines
            If item.Key > maxnumb Then
                maxnumb = item.Key
            End If
        Next
        Return maxnumb + 1
    End Function

    Public Shared Sub Reorder()
        Dim newlines As New Dictionary(Of Integer, LineDouble)
        For i As Integer = 0 To length() - 1
            newlines.Add(i, lines(i))
        Next
        lines = newlines
    End Sub

    Public Shared Sub ComputeListViewLines()
        listViewObjects.Clear()
        For Each item In lines
            Dim itemToAdd As New ListViewItem({item.Key + 1, item.Value.originalText, item.Value.translatedText})
            If item.Value.Tradotto() Then
                itemToAdd.BackColor = Color.LightGreen
            Else
                itemToAdd.BackColor = Color.LightSalmon
            End If
            CurrentSession.listViewObjects.Add(item.Key, itemToAdd)
        Next
    End Sub

    Public Shared Function areOriginalStringsEmpty() As Object
        Dim num As Integer = -1
        Dim count As Integer = CurrentSession.lines.Count - 1
        Dim num1 As Integer = 0
        If count >= 0 Then
            Do
                If (CurrentSession.lines(num1).originalText <> vbNullString) Then
                    num = num1
                End If
                num1 = num1 + 1
            Loop While num1 <= count
        End If
        Return If(num <> -1, False, True)
    End Function

    Public Shared Function areTranslatedStringsEmpty() As Object
        Dim num As Integer = -1
        Dim count As Integer = CurrentSession.lines.Count - 1
        Dim num1 As Integer = 0
        If count >= 0 Then
            Do
                If (CurrentSession.lines(num1).translatedText <> vbNullString) Then
                    num = num1
                End If
                num1 = num1 + 1
            Loop While num1 <= count
        End If
        Return If(num <> -1, False, True)
    End Function

    Public Shared Function getListViewLines(filtro As Efiltro, filtrogruppo As Integer) As ListViewItem()
        Dim newarr As ListViewItem() = New ListViewItem() {}
        Dim i As Integer = 0
        For Each item In lines
            If listViewObjects.ContainsKey(item.Key) Then
                If filtro = Efiltro.NotTranslated Then
                    If Not item.Value.Tradotto Then
                        ReDim Preserve newarr(i)
                        newarr(i) = listViewObjects(item.Key)
                        i += 1
                    End If
                ElseIf filtro = Efiltro.Translated Then
                    If item.Value.Tradotto Then
                        ReDim Preserve newarr(i)
                        newarr(i) = listViewObjects(item.Key)
                        i += 1
                    End If
                ElseIf filtro = Efiltro.SpecificGroup Then
                    If item.Value.group = filtrogruppo Or filtrogruppo = -1 Then
                        ReDim Preserve newarr(i)
                        newarr(i) = listViewObjects(item.Key)
                        i += 1
                    End If
                ElseIf filtro = Efiltro.Default_mode Then
                    ReDim Preserve newarr(i)
                    newarr(i) = listViewObjects(item.Key)
                    i += 1
                End If
            End If
        Next
        Return newarr
    End Function

    Public Shared Sub ChangeStringsFile(strings As String(), changeOriginalStrings As Boolean)
        If Not IsNothing(strings) Then
            Dim max As Integer = strings.Length - 1
            'First pass (edit lines)
            For Each line In CurrentSession.lines
                If line.Key > max Then
                    If changeOriginalStrings Then
                        line.Value.originalText = ""
                    Else
                        line.Value.translatedText = ""
                    End If
                Else
                    If changeOriginalStrings Then
                        line.Value.originalText = strings(line.Key)
                    Else
                        line.Value.translatedText = strings(line.Key)
                    End If
                End If
            Next
            'Second pass (add lines)
            For x = 0 To max
                If Not CurrentSession.lines.ContainsKey(x) Then
                    CurrentSession.lines.Add(x, New LineDouble(strings(x), vbNullString))
                End If
            Next
            'Third pass (delete last empty lines)
            Dim firstemptylineindex As Integer = CurrentSession.length
            While firstemptylineindex > 0 And CurrentSession.lines(firstemptylineindex - 1).originalText = vbNullString And CurrentSession.lines(firstemptylineindex - 1).translatedText = vbNullString
                firstemptylineindex -= 1
            End While
            If firstemptylineindex < CurrentSession.length Then
                For x = firstemptylineindex To CurrentSession.length - 1
                    CurrentSession.lines.Remove(x)
                Next
            End If

            Reorder()

            CurrentSession.ComputeListViewLines()
            frmMain.Ricalcola()
            frmMain.saved = False
        End If
    End Sub

    Public Shared Sub clear()
        listViewObjects.Clear()
        lines.Clear()
        groups.Clear()
        groups.Add(-1, New Group(-1, "Default", Color.Red))
    End Sub
End Class
