Public Class LineDouble

    Public Property originalText As String
    Public Property translatedText As String

    Public Property group As Short

    Public Sub New(testoOriginale As String, testoTradotto As String, gruppo As Integer)
        Me.originalText = testoOriginale
        Me.translatedText = testoTradotto
        Me.group = gruppo
    End Sub

    Public Sub New(testoOriginale As String, testoTradotto As String)
        Me.originalText = testoOriginale
        Me.translatedText = testoTradotto
        Me.group = -1
    End Sub

    Public Sub New(testoOriginale As LineSingle, testoTradotto As LineSingle)
        Me.originalText = testoOriginale.text
        Me.translatedText = testoTradotto.text
        Me.group = testoTradotto.group
    End Sub

    Public Function Tradotto() As Boolean
        If translatedText = originalText Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Enum LineType
        English
        Translated
    End Enum
End Class
