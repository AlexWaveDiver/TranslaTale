Imports TranslaTale

Public Class LineSingle
    'Line text
    Public Property text As String

    'Line group index (-1 for Default)
    Public Property group As Short

    Public Sub New(text As String, group As Short)
        Me.text = text
        Me.group = group
    End Sub

    Public Sub New(text As String)
        Me.text = text
        Me.group = -1
    End Sub
End Class
