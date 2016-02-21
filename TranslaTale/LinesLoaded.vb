Imports TranslaTale.frmMain

Public Class CurrentSession
    Public Shared lines As New Dictionary(Of Integer, LineDouble)
    Public Shared listViewObjects As New Dictionary(Of Integer, ListViewItem)
    Public Shared groups As New Dictionary(Of Short, Group)

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
        Dim maxnumb As Integer = 0
        For Each item In lines
            If item.Key > maxnumb Then
                maxnumb = item.Key
            End If
        Next
        Return maxnumb
    End Function

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

    Public Shared Sub clear()
        listViewObjects.Clear()
        lines.Clear()
        groups.Clear()
        groups.Add(-1, New Group(-1, "Default", Color.Red))
    End Sub
End Class
