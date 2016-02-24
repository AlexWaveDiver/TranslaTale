Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Namespace UTSpriteFontBox
	Public Class SpriteFontBox
		Inherits PictureBox
		Public BitOperator As SpriteFont

		Public Sans As SpriteFont

		Public Papyrus As SpriteFont

        Private input As String = ""

        Private curframe As Integer = -1

        Private _SpriteFont As SpriteFontBox.SpriteFonts

        Private _fontpath As String

        Private _showfaces As Boolean

        Private _showcommands As Boolean

        Public FaceImage As System.Drawing.Image = SpriteFont.ResizeImage(SpriteFont.Base64ToImage("iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAIAAAD8GO2jAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAB3RJTUUH3wwUER0NqQ7wdQAAAPFJREFUSMfNVskOxCAILcT//2V6MCEMsknHtJ4aecj2gF7XW4eIiOgEuKXgq+DpTIzYKQCYHx4mBWAl9rbUNTD92j2mFpgeMbRYaoWXlmAr3kY0EL8ufVGAQCQBGHvB7GZGSRHTP6gZri5M9HzCc1PhGbniMeXfqmnee/Ub9T7gtKzfSR94JVKxqxSpTJpmiAgrLer5mBIpYZFX1Yr0p9FMgjeazlQ8Pq7fMLAOrHZ+9iJQo+L/KSrSxjBQoXlj1cx7rGiajcqX+ahIN60cO9KYB9urAdPD3AdpGksLq7LvvBfGwzLmisGS6f3RPnzhe+cGt2XJN9OX1h4AAAAASUVORK5CYII="), 64, 64, ImageFormat.Png)

		Private components As IContainer

        <Browsable(False)>
        Public Shadows Property BackgroundImage As System.Drawing.Image
			Get
				Return MyBase.BackgroundImage
			End Get
			Set(ByVal value As System.Drawing.Image)
				MyBase.BackgroundImage = value
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property BackgroundImageLayout As ImageLayout
			Get
				Return MyBase.BackgroundImageLayout
			End Get
			Set(ByVal value As ImageLayout)
				MyBase.BackgroundImageLayout = value
			End Set
		End Property

		<Category("MessageBox")>
		<Description("Sets the current SpriteFont to one of 8BitOperator, Comic Sans or Papyrus.")>
		Public Property CurrentSpriteFont As SpriteFontBox.SpriteFonts
			Get
				Return Me._SpriteFont
			End Get
			Set(ByVal value As SpriteFontBox.SpriteFonts)
				Me._SpriteFont = value
				Me.Image = Me.RenderBox()
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property ErrorImage As System.Drawing.Image
			Get
				Return MyBase.ErrorImage
			End Get
			Set(ByVal value As System.Drawing.Image)
				MyBase.ErrorImage = value
			End Set
		End Property

		<Category("MessageBox")>
		<Description("The path to the image where the spritefont is located. (Normally 6.png)")>
		Public Property FontPath As String
			Get
                Return _fontpath
            End Get
			Set(ByVal value As String)
                _fontpath = value
                Try
					Me.LoadFont()
				Catch
				End Try
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property Image As System.Drawing.Image
			Get
				Return MyBase.Image
			End Get
			Set(ByVal value As System.Drawing.Image)
				MyBase.Image = value
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property ImageLocation As String
			Get
				Return MyBase.ImageLocation
			End Get
			Set(ByVal value As String)
				MyBase.ImageLocation = value
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property InitialImage As System.Drawing.Image
			Get
				Return MyBase.InitialImage
			End Get
			Set(ByVal value As System.Drawing.Image)
				MyBase.InitialImage = value
			End Set
		End Property

		Public Shadows Property MinimumSize As System.Drawing.Size
			Get
				Return MyBase.MinimumSize
			End Get
			Set(ByVal value As System.Drawing.Size)
				MyBase.MinimumSize = value
			End Set
		End Property

		<Browsable(False)>
		Public Shadows Property Padding As System.Windows.Forms.Padding
			Get
				Return MyBase.Padding
			End Get
			Set(ByVal value As System.Windows.Forms.Padding)
				MyBase.Padding = value
			End Set
		End Property

		<Category("MessageBox")>
		<Description("Toggles the display of text-commands.")>
		Public Property ShowCommands As Boolean
			Get
                Return _showcommands
            End Get
			Set(ByVal value As Boolean)
                _showcommands = value
                Me.Image = Me.RenderBox()
			End Set
		End Property

		<Category("MessageBox")>
		<Description("Toggles the display of faces.")>
		Public Property ShowFaces As Boolean
			Get
                Return _showfaces
            End Get
			Set(ByVal value As Boolean)
                _showfaces = value
                Me.Image = Me.RenderBox()
			End Set
		End Property

        <Browsable(True)>
        <Category("MessageBox")>
        <Description("The text of the box. Will automatically render on change.")>
        Public Overrides Property Text As String
            Get
                Return Me.input
            End Get
            Set(ByVal value As String)
                Me.Frame = -1
                Me.input = value
                Me.Image = Me.RenderBox()
            End Set
        End Property

        <Browsable(True)>
        <Category("MessageBox")>
        <Description("The current frame of the box. Will automatically render on change.")>
        Public Property Frame As Integer
            Get
                If curframe < Frames And curframe >= -1 Then
                    Return curframe
                Else
                    Return -1
                End If
            End Get
            Set(ByVal value As Integer)
                Me.curframe = value
                Me.Image = Me.RenderBox()
            End Set
        End Property

        Public ReadOnly Property Frames
            Get
                Return SpriteFont.CountFrames(Me.Text)
            End Get
        End Property

        Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
			MyBase.SetStyle(ControlStyles.Selectable, True)
			MyBase.TabStop = True
            AddHandler MyBase.KeyPress, New KeyPressEventHandler(AddressOf UT_OnKeyPress)
            Me.MinimumSize = New System.Drawing.Size(578, 152)
			MyBase.SizeMode = PictureBoxSizeMode.CenterImage
			MyBase.Focus()
		End Sub

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing AndAlso Me.components IsNot Nothing) Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
		End Sub

        Public Sub LoadFont()
            If (Not String.IsNullOrEmpty(Me.FontPath)) Then
                Me.BitOperator = SpriteFont.Create(Me.FontPath, My.Resources.BitOperatorJSON)
                Me.Sans = SpriteFont.Create(Me.FontPath, My.Resources.ComicSansJSON)
                Me.Papyrus = SpriteFont.Create(Me.FontPath, My.Resources.PapyrusJSON)
            End If
        End Sub

        Private Function MessageBox() As System.Drawing.Image
			Dim bitmap As System.Drawing.Image = New System.Drawing.Bitmap(578, 152)
			Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(New Point(20, 30), New System.Drawing.Size(100, 74))
			Using graphic As Graphics = Graphics.FromImage(bitmap)
				Dim pen As System.Drawing.Pen = New System.Drawing.Pen(Brushes.White) With
				{
					.Width = 6!
				}
				graphic.FillRectangle(Brushes.Black, New System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height))
				graphic.DrawRectangle(pen, New System.Drawing.Rectangle(3, 3, bitmap.Width - 6, bitmap.Height - 6))
				If (Me.ShowFaces) Then
					graphic.DrawImage(Me.FaceImage, New Point((rectangle.Width - Me.FaceImage.Width) / 2 + rectangle.X, rectangle.Y))
				End If
			End Using
			Return bitmap
		End Function

		Protected Overrides Sub OnEnter(ByVal e As EventArgs)
			MyBase.Invalidate()
			MyBase.OnEnter(e)
		End Sub

		Protected Overrides Sub OnLeave(ByVal e As EventArgs)
			MyBase.Invalidate()
			MyBase.OnLeave(e)
		End Sub

		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.Focus()
			MyBase.OnMouseDown(e)
		End Sub

		Protected Overrides Sub OnPaint(ByVal paintEventArgs As System.Windows.Forms.PaintEventArgs)
			paintEventArgs.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor
			MyBase.OnPaint(paintEventArgs)
		End Sub

		Public Function RenderBox() As System.Drawing.Image
			Dim point As System.Drawing.Point
			Dim image As System.Drawing.Image = Me.MessageBox()
			If (Not String.IsNullOrEmpty(Me.FontPath)) Then
				Using graphic As Graphics = Graphics.FromImage(image)
					point = If(Not Me.ShowFaces, New System.Drawing.Point(27, 19), New System.Drawing.Point(143, 19))
					If (Me.CurrentSpriteFont = SpriteFontBox.SpriteFonts.BitOperator) Then
                        graphic.DrawImage(Me.BitOperator.Render_String(Me.Text, Frame, Me.ShowCommands, Me.ShowFaces), point)
                    ElseIf (Me.CurrentSpriteFont <> SpriteFontBox.SpriteFonts.ComicSans) Then
                        graphic.DrawImage(Me.Papyrus.Render_String(Me.Text, Frame, Me.ShowCommands, Me.ShowFaces), point)
                    Else
                        graphic.DrawImage(Me.Sans.Render_String(Me.Text, Frame, Me.ShowCommands, Me.ShowFaces), point)
                    End If
				End Using
			End If
			Return image
		End Function

		Private Sub UT_OnKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
			If (e.KeyChar = Strings.ChrW(10) OrElse e.KeyChar = Strings.ChrW(13) OrElse e.KeyChar = Strings.ChrW(9)) Then
				Me.Text = String.Concat(Me.Text, "&")
			ElseIf (e.KeyChar = Strings.ChrW(8)) Then
				Me.Text = If(Me.Text.Length > 0, Me.Text.Remove(Me.Text.Length - 1, 1), Me.Text)
			Else
				Dim text As String = Me.Text
				Dim keyChar As Char = e.KeyChar
				Me.Text = String.Concat(text, keyChar.ToString())
			End If
			e.Handled = True
		End Sub

		Public Enum SpriteFonts
			BitOperator
			ComicSans
			Papyrus
		End Enum
	End Class
End Namespace