Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions

<Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", GetType(IDesigner))> _
Public Class TTgroupControl
    Inherits System.Windows.Forms.UserControl

    Private ctlBackColor As Color = System.Drawing.ColorTranslator.FromHtml("#3b4241")
    Private ctlBorderColor As Color = System.Drawing.ColorTranslator.FromHtml("#505253")
    Private ctlLabelColor As Color = System.Drawing.ColorTranslator.FromHtml("#494a4a")
    Private ctlLabelFontColor As Color = System.Drawing.ColorTranslator.FromHtml("#c5c5c5")
    Private ctlHeaderText As String = "Title"
    Private ctlShowLabel As Boolean = True
    Private _designMode As Boolean = LicenseManager.UsageMode = LicenseUsageMode.Designtime

    Public Sub New()
        InitializeComponent()
        Me.BackColor = ctlBackColor
        lblLabel.BackColor = ctlLabelColor
        lblLabel.ForeColor = ctlLabelFontColor
    End Sub

    <System.ComponentModel.Description("Border color")> _
    <System.ComponentModel.Category("Appearance")> _
    Property BorderColor() As Color
        Get
            Return ctlBorderColor
        End Get
        Set(ByVal value As Color)
            ctlBorderColor = value
            Me.Refresh()
        End Set
    End Property

    <System.ComponentModel.Description("Header background color")> _
    <System.ComponentModel.Category("Appearance")> _
    Property HeaderBackgroundColor() As Color
        Get
            Return ctlLabelColor
        End Get
        Set(ByVal value As Color)
            ctlLabelColor = value
            lblLabel.BackColor = value
            Me.Refresh()
        End Set
    End Property

    <System.ComponentModel.Description("Header text foreground color")> _
    <System.ComponentModel.Category("Appearance")> _
    Property HeaderForegroundColor() As Color
        Get
            Return ctlLabelFontColor
        End Get
        Set(ByVal value As Color)
            ctlLabelFontColor = value
            lblLabel.ForeColor = value
            Me.Refresh()
        End Set
    End Property

    <System.ComponentModel.Description("Is the header visible?")> _
    <System.ComponentModel.Category("Appearance")> _
    Property HeaderVisible() As Boolean
        Get
            Return ctlShowLabel
        End Get
        Set(ByVal value As Boolean)
            ctlShowLabel = value
            Me.Refresh()
        End Set
    End Property

    <System.ComponentModel.Description("Header text")> _
    <System.ComponentModel.Category("Appearance")> _
    Property HeaderText() As String
        Get
            Return ctlHeaderText
        End Get
        Set(ByVal value As String)
            ctlHeaderText = value
            lblLabel.Text = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim formGraphics As System.Drawing.Graphics
        Dim brshBackgroundColor As New System.Drawing.SolidBrush(Me.BackColor)

        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, ctlBorderColor, ButtonBorderStyle.Solid)
        formGraphics = Me.CreateGraphics()

        If ctlShowLabel = True Then
            Dim brshLabel As New System.Drawing.SolidBrush(ctlLabelColor)
            Dim brshBorder As New System.Drawing.SolidBrush(ctlBorderColor)
            formGraphics.FillRectangle(brshBorder, New Rectangle(New Size(0, 0), New Size(Me.Width, 28)))
            formGraphics.FillRectangle(brshLabel, New Rectangle(New Size(1, 1), New Size(Me.Width - 2, 26)))
            brshLabel.Dispose()
            brshBorder.Dispose()
            formGraphics.Dispose()
            lblLabel.Text = ctlHeaderText
            lblLabel.Visible = True
            lblLabel.Left = 1
            lblLabel.Top = 1
            lblLabel.Width = Me.Width - 2
            lblLabel.Height = 25
        Else
            lblLabel.Visible = False
        End If
    End Sub
End Class