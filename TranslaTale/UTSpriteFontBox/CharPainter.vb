Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions

Namespace UTSpriteFontBox
    Public Class CharPainter
        Public indexes As Integer()

        Public colors As Color()

        Public Sub New(ByVal text As String)
            MyBase.New()
            Dim matchCollections As MatchCollection = Regex.Matches(text, "\\W|\\X|\\Y|\\R|\\B|\\L|\\G|\\P|\\p|\\O")
            ReDim Me.indexes(matchCollections.Count - 1)
            ReDim Me.colors(matchCollections.Count - 1)
            For Each match As System.Text.RegularExpressions.Match In matchCollections
                For i As Integer = 0 To matchCollections.Count - 1
                    Me.indexes(i) = matchCollections(i).Index
                    Dim value As String = matchCollections(i).Value
                    If (value = "\X") Then
                        'Me.colors(i) = ColorTranslator.FromHtml("#000000")
                        Me.colors(i) = ColorTranslator.FromHtml("#ffffff")
                    ElseIf (value = "\Y") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#fafa00")
                    ElseIf (value = "\R") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#ff0000")
                    ElseIf (value = "\W") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#ffffff")
                    ElseIf (value = "\P") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#fa00fa")
                    ElseIf (value = "\L") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#0ebbf7")
                    ElseIf (value = "\O") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#ffa341")
                    ElseIf (value = "\B") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#0000ff")
                    ElseIf (value = "\p") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#ffbbd4")
                    ElseIf (value = "\G") Then
                        Me.colors(i) = ColorTranslator.FromHtml("#00f800")
                    End If
                Next

            Next
        End Sub
    End Class
End Namespace