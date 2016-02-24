Imports System

Namespace UTSpriteFontBox
	Public Class FontInformation
		Public name As String = "Default"

		Public x_index As Integer

		Public y_index As Integer

		Public max_width As Integer = 9

		Public font As Character() = New Character(-1) {}

		Public y_offsets As Integer() = New Integer(-1) {}

		Public char_lines As Integer() = New Integer(-1) {}

		Public Sub New()
			MyBase.New()
		End Sub

		Public Function getCharacter(ByVal [Char] As Char) As Character
			Dim num As Integer = 0
			Do
				If (Me.font(num).character = [Char]) Then
					Return Me.font(num)
				End If
				num = num + 1
			Loop While num < CInt(Me.font.Length)
			Return New Character()
		End Function
	End Class
End Namespace