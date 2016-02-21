Public Class Group
    Public Property numero As Short
    Public Property name As String
    Public Property colore As Color

    Public Sub New(numero As Short, nome As String, colore As Color)
        Me.numero = numero
        Me.name = nome
        Me.colore = colore
    End Sub

    Public Sub New(numero As Short, nome As String, colore As String)
        Me.numero = numero
        Me.name = nome
        Me.colore = ColorTranslator.FromHtml(colore)
    End Sub

    Public Sub New(numero As Short, nome As String)
        Me.numero = numero
        Me.name = nome
        Me.colore = Color.Gainsboro
    End Sub
End Class
