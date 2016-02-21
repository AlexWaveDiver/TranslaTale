Public Class LineCompare
    Public Property number As Integer

    Public Property textLeft As String
    Public Property groupLeft As Group
    Public Property textRight As String
    Public Property groupRight As Group

    Public Property selectedText As Trilean = Trilean.Nothing_

    Public Sub New(numero As Integer, testo1 As String, testo2 As String, testoselezionato As Trilean)
        Me.number = numero
        Me.textLeft = testo1
        Me.groupLeft = New Group(-1, "Default")
        Me.textRight = testo2
        Me.groupRight = New Group(-1, "Default")
        Me.selectedText = testoselezionato
    End Sub

    Public Sub New(numero As Integer, testo1 As LineSingle, gruppo1 As Group, testo2 As LineSingle, gruppo2 As Group, testoselezionato As Trilean)
        Me.number = numero
        Me.textLeft = testo1.text
        Me.groupLeft = gruppo1
        Me.textRight = testo2.text
        Me.groupRight = gruppo2
        Me.selectedText = testoselezionato
    End Sub

    Public Sub New(numero As Integer, testo1 As String, testo2 As String)
        Me.number = numero
        Me.textLeft = testo1
        Me.groupLeft = New Group(-1, "Default")
        Me.textRight = testo2
        Me.groupRight = New Group(-1, "Default")
        Me.selectedText = Trilean.Nothing_
    End Sub

    Public Sub New(numero As Integer, testo1 As LineSingle, gruppo1 As Group, testo2 As LineSingle, gruppo2 As Group)
        Me.number = numero
        Me.textLeft = testo1.text
        Me.groupLeft = gruppo1
        Me.textRight = testo2.text
        Me.groupRight = gruppo2
        Me.selectedText = Trilean.Nothing_
    End Sub

    Public Sub New(numero As Integer, testi As LineDouble, group As Group)
        Me.number = numero
        Me.textLeft = testi.originalText
        Me.groupLeft = group
        Me.textRight = testi.translatedText
        Me.groupRight = group
        Me.selectedText = Trilean.Nothing_
    End Sub

    Public Sub New(numero As Integer, testi As LineDouble, group As Group, testoselezionato As Trilean)
        Me.number = numero
        Me.textLeft = testi.originalText
        Me.groupLeft = group
        Me.textRight = testi.translatedText
        Me.groupRight = group
        Me.selectedText = testoselezionato
    End Sub

    Public Sub New(numero As Integer, testo1 As String)
        Me.number = numero
        Me.textLeft = testo1
        Me.groupLeft = New Group(-1, "Default")
        Me.textRight = vbNullString
        Me.groupRight = New Group(-1, "Default")
        Me.selectedText = Trilean.Nothing_
    End Sub

    Public Sub New(numero As Integer, testo1 As LineSingle, gruppo1 As Group)
        Me.number = numero
        Me.textLeft = testo1.text
        Me.groupLeft = gruppo1
        Me.textRight = vbNullString
        Me.groupRight = New Group(-1, "Default")
        Me.selectedText = Trilean.Nothing_
    End Sub
End Class

Public Enum Trilean
    Nothing_
    First
    Second
End Enum