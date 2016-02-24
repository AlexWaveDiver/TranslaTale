Public Class FileImage
    Public Property content As Byte()
    Public Property fileName As String

    Public Sub New(ByVal content As Byte(), ByVal fileName As String)
        Me.content = content
        Me.fileName = fileName
    End Sub
End Class