Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Text.RegularExpressions

Namespace UTSpriteFontBox
	Public Class SpriteFont
		Private fontinfo As FontInformation

		Private sprites As Bitmap()

		Public Sub New(ByVal _fontinfo As FontInformation, ByVal _image As Bitmap)
			MyBase.New()
			Me.fontinfo = _fontinfo
			ReDim Me.sprites(CInt(Me.fontinfo.font.Length) - 1)
			Dim xIndex As Integer = Me.fontinfo.x_index
			Dim yIndex As Integer = Me.fontinfo.y_index
			Dim num As Integer = 1
			Dim num1 As Integer = 0
            For i As Integer = 0 To CInt(Me.fontinfo.font.Length - 1)
                Me.sprites(i) = SpriteFont.CropImage(_image, xIndex, yIndex, Me.fontinfo.font(i).width, Me.fontinfo.font(i).height)
                If (num <> Me.fontinfo.char_lines(num1)) Then
                    xIndex = xIndex + Me.fontinfo.font(i).width + 1
                    num = num + 1
                Else
                    num1 = num1 + 1
                    xIndex = Me.fontinfo.x_index
                    yIndex = Me.fontinfo.y_offsets(num1)
                    num = 1
                End If
            Next

        End Sub

		Public Shared Function Base64ToImage(ByVal base64String As String) As Image
			Dim numArray As Byte() = Convert.FromBase64String(base64String)
			Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(numArray, 0, CInt(numArray.Length))
			memoryStream.Write(numArray, 0, CInt(numArray.Length))
			Return Image.FromStream(memoryStream, True)
		End Function

		Public Shared Function ChangeColor(ByVal scrBitmap As System.Drawing.Bitmap, ByVal newColor As Color) As System.Drawing.Bitmap
			Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(scrBitmap.Width, scrBitmap.Height)
			Dim num As Integer = 0
			Do
				Dim num1 As Integer = 0
				Do
					Dim pixel As Color = scrBitmap.GetPixel(num, num1)
					If (pixel.A <= 200) Then
						bitmap.SetPixel(num, num1, pixel)
					Else
						bitmap.SetPixel(num, num1, newColor)
					End If
					num1 = num1 + 1
				Loop While num1 < scrBitmap.Height
				num = num + 1
			Loop While num < scrBitmap.Width
			Return bitmap
		End Function

		Public Function Char_Return(ByVal character As Char) As Bitmap
			Dim num As Integer = 0
			Do
				If (Me.fontinfo.font(num).character = character) Then
					Return Me.sprites(num)
				End If
				num = num + 1
			Loop While num < CInt(Me.fontinfo.font.Length)
			Return New Bitmap(10, 20)
		End Function

		Public Shared Function Create(ByVal FontPath As String, ByVal JSONData As String) As SpriteFont
			Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(Image.FromFile(FontPath, True))
            Dim dataContractJsonSerializer As Runtime.Serialization.Json.DataContractJsonSerializer = New Runtime.Serialization.Json.DataContractJsonSerializer(GetType(FontInformation))
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(Encoding.UTF8.GetBytes(JSONData))
            Return New SpriteFont(DirectCast(dataContractJsonSerializer.ReadObject(memoryStream), FontInformation), bitmap)
        End Function

        Public Shared Function Create(ByVal FontDump As Bitmap, ByVal JSONData As String) As SpriteFont
            Dim dataContractJsonSerializer As Runtime.Serialization.Json.DataContractJsonSerializer = New Runtime.Serialization.Json.DataContractJsonSerializer(GetType(FontInformation))
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(Encoding.UTF8.GetBytes(JSONData))
            Return New SpriteFont(DirectCast(dataContractJsonSerializer.ReadObject(memoryStream), FontInformation), FontDump)
        End Function

        Public Shared Function CropAndResizeImage(ByVal img As Image, ByVal targetWidth As Integer, ByVal targetHeight As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal imageFormat As System.Drawing.Imaging.ImageFormat) As Image
			Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(targetWidth, targetHeight)
			Dim graphic As Graphics = Graphics.FromImage(bitmap)
			graphic.InterpolationMode = InterpolationMode.NearestNeighbor
			graphic.SmoothingMode = SmoothingMode.HighSpeed
			graphic.PixelOffsetMode = PixelOffsetMode.HighSpeed
			graphic.CompositingQuality = CompositingQuality.HighSpeed
			Dim num As Integer = x2 - x1
			Dim num1 As Integer = y2 - y1
			graphic.DrawImage(img, New Rectangle(0, 0, targetWidth, targetHeight), x1, y1, num, num1, GraphicsUnit.Pixel)
			Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
			bitmap.Save(memoryStream, imageFormat)
			Return Image.FromStream(memoryStream)
		End Function

		Public Shared Function CropImage(ByVal source As Image, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As System.Drawing.Bitmap
			Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(x, y, width, height)
			Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(rectangle.Width, rectangle.Height)
			Using graphic As Graphics = Graphics.FromImage(bitmap)
				graphic.DrawImage(source, New System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), rectangle, GraphicsUnit.Pixel)
			End Using
			Return bitmap
		End Function

        Public Shared Function CountFrames(ByVal text As String) As Integer
            If IsNothing(text) Then
                Return 0
            End If

            Dim frameParts As String() = Regex.Split(text, "(?:\^)(?=[0-9])")
            If frameParts.Length > 0 Then
                If frameParts.Length > 1 Then
                    For x As Integer = 0 To frameParts.Length - 2
                        If x > 0 Then
                            frameParts(x) = frameParts(x).Remove(0, 1)
                        End If
                        frameParts(x) = frameParts(x + 1).First & frameParts(x)
                    Next
                End If
                If frameParts(frameParts.Length - 1).Length > 0 Then
                    frameParts(frameParts.Length - 1) = "1" & frameParts(frameParts.Length - 1).Remove(0, 1)
                Else
                    frameParts(frameParts.Length - 1) = "1" & frameParts(frameParts.Length - 1)
                End If

                Dim frames As New List(Of String)
                For i As Integer = 0 To frameParts.Length - 1
                    Dim curframestr As String = ""
                    Dim curframelen As Integer = Integer.Parse(frameParts(i).First)
                    For i2 As Integer = 0 To i
                        curframestr = curframestr & frameParts(i2).Remove(0, 1)
                    Next
                    For i3 As Integer = 0 To curframelen - 1
                        frames.Add(curframestr)
                    Next
                Next
                Return frames.Count
            Else
                Return 0
            End If
        End Function

        Public Function Render_String(Optional ByVal text As String = "", Optional CurrentFrame As Integer = -1, Optional ByVal ShowCommands As Boolean = False, Optional ByVal WithFace As Boolean = False) As System.Drawing.Bitmap
            Dim bitmap As System.Drawing.Bitmap
            Dim charPainter As UTSpriteFontBox.CharPainter
            Dim white As Color = Color.White
            Dim point As System.Drawing.Point = New System.Drawing.Point(1, 1)
            Dim num As Integer = 0
            Dim str As String = text
            bitmap = If(Not WithFace, New System.Drawing.Bitmap(265, 60), New System.Drawing.Bitmap(209, 60))

            If CurrentFrame > -1 Then
                Dim frameParts As String() = Regex.Split(text, "(?:\^)(?=[0-9])")
                If frameParts.Length > 0 Then
                    If frameParts.Length > 1 Then
                        For x As Integer = 0 To frameParts.Length - 2
                            If x > 0 Then
                                frameParts(x) = frameParts(x).Remove(0, 1)
                            End If
                            frameParts(x) = frameParts(x + 1).First & frameParts(x)
                        Next
                        If frameParts(frameParts.Length - 1).Length > 0 Then
                            frameParts(frameParts.Length - 1) = "1" & frameParts(frameParts.Length - 1).Remove(0, 1)
                        Else
                            frameParts(frameParts.Length - 1) = "1" & frameParts(frameParts.Length - 1)
                        End If
                    Else
                        frameParts(0) = "1" & frameParts(0)
                    End If

                    Dim frames As New List(Of String)
                    For i As Integer = 0 To frameParts.Length - 1
                        Dim curframestr As String = ""
                        Dim curframelen As Integer = Integer.Parse(frameParts(i).First)
                        For i2 As Integer = 0 To i
                            curframestr = curframestr & frameParts(i2).Remove(0, 1)
                        Next
                        For i3 As Integer = 0 To curframelen - 1
                            frames.Add(curframestr)
                        Next
                    Next
                    text = frames(CurrentFrame)
                    str = frames(CurrentFrame)
                End If
            End If

            If (Not ShowCommands) Then
                str = Regex.Replace(text, "\\E.|\\M.|\^[0-9]|/|%", "")
                charPainter = New UTSpriteFontBox.CharPainter(str)
                str = Regex.Replace(str, "\\.", "")
            Else
                charPainter = New UTSpriteFontBox.CharPainter(str)
            End If
            Dim charArray As Char() = str.ToCharArray()
            Dim num1 As Integer = 0
            Do While num1 < CInt(charArray.Length)
                Dim character As UTSpriteFontBox.Character = Me.fontinfo.getCharacter(charArray(num1))
                Dim num2 As Integer = 0
                Do While num2 < CInt(charPainter.indexes.Length)
                    If (num = charPainter.indexes(num2)) Then
                        white = charPainter.colors(num2)
                        If (Not ShowCommands) Then
                            num = num + 2
                        End If
                    End If
                    num2 = num2 + 1
                Loop
                Using graphic As Graphics = Graphics.FromImage(bitmap)
                    If (Not (charArray(num1) = "&"c Or charArray(num1) = "#"c)) Then
                        If (point.X + character.cell_width / 2 >= bitmap.Width) Then
                            point = New System.Drawing.Point(1, point.Y + 18)
                        End If
                        graphic.DrawImage(SpriteFont.ChangeColor(Me.Char_Return(charArray(num1)), white), point)
                        point.X = point.X + character.cell_width
                    ElseIf (Not ShowCommands) Then
                        point = New System.Drawing.Point(1, point.Y + 18)
                    Else
                        graphic.DrawImage(SpriteFont.ChangeColor(Me.Char_Return(charArray(num1)), white), point)
                        point.X = point.X + character.cell_width
                    End If
                End Using
                num = num + 1
                num1 = num1 + 1
            Loop
            Return DirectCast(SpriteFont.ResizeImage(bitmap, bitmap.Width * 2, bitmap.Height * 2, ImageFormat.Bmp), System.Drawing.Bitmap)
        End Function

        Public Shared Function ResizeImage(ByVal img As Image, ByVal targetWidth As Integer, ByVal targetHeight As Integer, ByVal imageFormat As System.Drawing.Imaging.ImageFormat) As Image
			Return SpriteFont.CropAndResizeImage(img, targetWidth, targetHeight, 0, 0, img.Width, img.Height, imageFormat)
		End Function
	End Class
End Namespace