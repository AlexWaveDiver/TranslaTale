Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Drawing.Imaging

Public Class TTpreviewBox
    Dim toClean() As String = {"\C", _
                               "\E0", "\E1", "\E2", "\E3", "\E4", "\E5", "\E6", "\E7", "\E8", "\E9", _
                               "\F0", "\F1", "\F2", "\F3", "\F4", "\F5", "\F6", "\F7", "\F8", "\F9", _
                               "\M0", "\M1", "\M2", "\M3", "\M4", "\M5", "\M6", "\M7", "\M8", "\M9", _
                               "^1", "^2", "^3", "^4", "^5", "^6", "^7", "^8", "^9", _
                               "\z4", "/%%", "/%", "/" _
                              }

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim gmxFile As New XmlDocument()
        Dim lineHeight As Integer = 36
        Dim text As String = "Hello, World"
        Dim actualColor As Color = Color.White
        Dim textBitmap As New Bitmap(1, 1)

        For Each element As String In toClean
            text = text.Replace(element, "")
        Next

        gmxFile.Load("C:\Users\Alex\Documents\Visual Studio 2013\Projects\UTPreviewBox\UTFonts.gmx\fonts\UT_sans.font.gmx")

        text = text.Replace("\Y", "₠")
        text = text.Replace("\O", "₡")
        text = text.Replace("\R", "₢")
        text = text.Replace("\B", "₣")
        text = text.Replace("\L", "₤")
        text = text.Replace("\P", "₥")
        text = text.Replace("\p", "₦")
        text = text.Replace("\G", "₧")
        text = text.Replace("\W", "₨")
        text = text.Replace("^0", "^")

        Dim lines As String() = text.Split(New Char() {"&"c})

        Dim fontBitmapPath As String = gmxFile.SelectSingleNode("//font/image").InnerText
        Dim fontBitmap As Bitmap = Bitmap.FromFile("C:\Users\Alex\Documents\Visual Studio 2013\Projects\UTPreviewBox\UTFonts.gmx\fonts\" & fontBitmapPath)
        Dim line As String
        Dim lineIteration As Integer = 1
        Dim fullCanvas As New Bitmap(999, 999)

        Dim gr As Graphics = Graphics.FromImage(fullCanvas)

        gr.FillRectangle(Brushes.White, 1, 1, 578, 152)
        gr.FillRectangle(Brushes.Black, 7, 7, 566, 140)
        For Each line In lines
            Dim lineBitmap As New Bitmap(1, 1)
            For i As Integer = 0 To line.Length - 1
                Dim c As Char = line(i)
                Select Case c
                    Case "₠"
                        actualColor = Color.Yellow
                        Continue For
                    Case "₡"
                        actualColor = Color.Orange
                        Continue For
                    Case "₢"
                        actualColor = Color.Red
                        Continue For
                    Case "₣"
                        actualColor = Color.Blue
                        Continue For
                    Case "₤"
                        actualColor = Color.Cyan
                        Continue For
                    Case "₥"
                        actualColor = Color.Purple
                        Continue For
                    Case "₦"
                        actualColor = Color.Pink
                        Continue For
                    Case "₧"
                        actualColor = Color.Green
                        Continue For
                    Case "₨"
                        actualColor = Color.White
                        Continue For
                End Select

                Dim glyph As XmlElement = gmxFile.SelectSingleNode("//font/glyphs/glyph[@character='" & Asc(c) & "']")
                If glyph.Attributes.GetNamedItem("character").Value.ToString = Asc(c) Then
                    Dim characterInfo = New Dictionary(Of String, Integer)
                    characterInfo.Add("x", glyph.Attributes.GetNamedItem("x").Value)
                    characterInfo.Add("y", glyph.Attributes.GetNamedItem("y").Value)
                    characterInfo.Add("h", glyph.Attributes.GetNamedItem("h").Value)
                    characterInfo.Add("w", glyph.Attributes.GetNamedItem("w").Value)
                    characterInfo.Add("shift", glyph.Attributes.GetNamedItem("shift").Value)
                    characterInfo.Add("offset", glyph.Attributes.GetNamedItem("offset").Value)

                    Dim char1 As Bitmap = ResizeBitmap(getCharacter(fontBitmap, characterInfo("x"), characterInfo("y"), characterInfo("w"), characterInfo("h"), actualColor), 2)
                    Dim charGr As Graphics = Graphics.FromImage(char1)

                    charGr.ScaleTransform(3.0F, 1.0F)
                    charGr.Dispose()
                    Clipboard.SetImage(ResizeBitmap(char1, 2))
                    Dim lineBitmapTemp As New Bitmap(lineBitmap)
                    Dim kerning As Integer = 4
                    If c = "w" Or c = "W" Then
                        kerning = 2
                    Else
                        kerning = 4
                    End If

                    lineBitmap = New Bitmap(char1.Width + characterInfo("offset") + lineBitmapTemp.Width + kerning, Math.Max(char1.Height, lineBitmapTemp.Height))

                    Dim g As Graphics = Graphics.FromImage(lineBitmap)
                    g.DrawImage(lineBitmapTemp, 0, 0)
                    g.DrawImage(char1, lineBitmapTemp.Width + characterInfo("offset"), 0)
                    g.Dispose()
                End If
            Next

            gr.DrawImage(lineBitmap, 144, (lineIteration * lineHeight) - 15)

            Me.BackgroundImageLayout = ImageLayout.None
            Me.BackgroundImage = fullCanvas
            lineIteration += 1
        Next
        gr.Dispose()
        Clipboard.SetImage(fullCanvas)
    End Sub

    Private Function getCharacter(ByRef bmpCharmap As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, Optional ByVal colorParam As Color = Nothing) As Bitmap
        Dim rect As New Rectangle(x, y, w, h)
        Dim character As Bitmap = bmpCharmap.Clone(rect, bmpCharmap.PixelFormat)
        If Not colorParam = Nothing Then
            Dim c As Color
            Dim imgX, imgY As Int32
            For imgX = 0 To character.Width - 1
                For imgY = 0 To character.Height - 1
                    c = character.GetPixel(imgX, imgY)
                    If c.ToArgb = "-1" Then
                        character.SetPixel(imgX, imgY, colorParam)
                    End If
                Next
            Next
        End If
        Return character
    End Function
    Private Function ResizeBitmap(ByVal bmp As Bitmap, ByVal percentResize As Double)
        Dim bm As New Bitmap(bmp)
        Dim width As Integer = bm.Width * percentResize + 1
        Dim height As Integer = bm.Height * percentResize

        Dim scaledBmp As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(scaledBmp)
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
bm.Height), GraphicsUnit.Pixel)

        g.Dispose()
        bm.Dispose()
        Return scaledBmp
    End Function


End Class