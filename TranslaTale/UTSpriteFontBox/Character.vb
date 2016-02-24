Imports System

Namespace UTSpriteFontBox
	Public Class Character
		Public character As Char = Strings.ChrW(32)

		Public width As Integer = 7

		Public height As Integer = 14

		Public cell_width As Integer = 8

		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace