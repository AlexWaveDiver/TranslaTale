Imports System.IO
Imports NBT.IO
Imports NBT.Tags

Friend Class TranslataleStringFile
    Public lines As New Dictionary(Of Integer, LineSingle)

    Public Function NumeroRighe() As Integer
        Return lines.Count
    End Function

    Public Sub SetLines(olines As String())
        Dim i As Integer
        For Each line In olines
            lines.Add(i, New LineSingle(olines(i)))
            i += 1
        Next
    End Sub

    Friend Shared Function Load(path1 As String) As TranslataleStringFile
        Dim ttx1 As New TranslataleStringFile()

        Dim sr As New System.IO.StreamReader(path1)
        Dim textSource As String()
        Try
            textSource = File.ReadAllLines(path1)
        Catch
            sr.Close()
            Return Nothing
        End Try
        sr.Close()
        ttx1.SetLines(textSource)
        Return ttx1
    End Function

    Public Function lineeString() As String()
        Dim returnvalue As String() = New String(Me.NumeroRighe) {}
        For Each item As KeyValuePair(Of Integer, LineSingle) In lines
            returnvalue(item.Key) = item.Value.text
        Next
        Return returnvalue
    End Function

    Public Function lineeStringDictionary() As Dictionary(Of Integer, String)
        Dim returnvalue As New Dictionary(Of Integer, String)
        For Each item As KeyValuePair(Of Integer, LineSingle) In lines
            returnvalue(item.Key) = item.Value.text
        Next
        Return returnvalue
    End Function
End Class
