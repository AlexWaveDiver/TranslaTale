Imports System.ComponentModel

Public Class TranslationPercentageBox

    Dim _numLeft As Double = 0

    <Category("behaviour"),
    Description("Left value")>
    Public Property LeftValue As Double
        Get
            Return _numLeft
        End Get
        Set(value As Double)
            If value < 0 Then
                value = 0
            End If
            _numLeft = value
            txtLeft.Text = _numLeft
            txtTotal.Text = _numLeft + _numRight
            updateSize()
        End Set
    End Property

    Dim _numRight As Double = 0

    <Category("behaviour"),
    Description("Right value")>
    Public Property RightValue As Double
        Get
            Return _numRight
        End Get
        Set(value As Double)
            If value < 0 Then
                value = 0
            End If
            _numRight = value
            txtRight.Text = _numRight
            txtTotal.Text = _numLeft + _numRight
            updateSize()
        End Set
    End Property

    Dim _enabled As Boolean = True

    <Category("behaviour"),
    Description("Enables clicking on percentages")>
    Public Overloads Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
        End Set
    End Property

    Dim _selectedpercentage As Percentage = Percentage.All

    <Category("behaviour"),
    Description("Enables clicking on percentages")>
    Public Property SelectedPercentage As Percentage
        Get
            Return _selectedpercentage
        End Get
        Set(value As Percentage)
            _selectedpercentage = value
            If _selectedpercentage = Percentage.All Then
                btnResetFilter.Visible = False
                percLeftBtn.BackColor = colorLeft
                If isSet() Then
                    percRightBtn.BackColor = colorRight
                End If
            ElseIf _selectedpercentage = Percentage.Other Then
                btnResetFilter.Visible = True
                percLeftBtn.BackColor = colorLeft
                If isSet() Then
                    percRightBtn.BackColor = colorRight
                End If
            Else
                btnResetFilter.Visible = True
                If _selectedpercentage = Percentage.Left Then
                    percLeftBtn.BackColor = colorLeftHover
                ElseIf _selectedpercentage = Percentage.Right Then
                    If isSet() Then
                        percRightBtn.BackColor = colorRightHover
                    End If
                End If
            End If
        End Set
    End Property

    Private Function isSet() As Boolean
        If LeftValue + RightValue <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Shared colorLeftHover As Color = Color.Lime
    Private Shared colorLeft As Color = Color.LimeGreen
    Private Shared colorRightHover As Color = Color.Red
    Private Shared colorRight As Color = Color.Tomato
    Private Shared colorDisabledHover As Color = Color.Gray
    Private Shared colorDisabled As Color = Color.Silver

    Public Sub New()
        InitializeComponent()

        updateSize()
    End Sub

    Private Sub percLeftBtn_MouseEnter(sender As Panel, e As EventArgs) Handles percLeftBtn.MouseEnter, percLeft.MouseEnter
        If _selectedpercentage <> Percentage.Left Then
            percLeftBtn.BackColor = colorLeftHover
        End If
    End Sub

    Private Sub percLeftBtn_MouseLeave(sender As Panel, e As EventArgs) Handles percLeftBtn.MouseLeave, percLeft.MouseLeave
        If _selectedpercentage <> Percentage.Left Then
            percLeftBtn.BackColor = colorLeft
        End If
    End Sub

    Private Sub percRightBtn_MouseEnter(sender As Object, e As EventArgs) Handles percRightBtn.MouseEnter, Panel2.MouseEnter
        If isSet() Then
            If _selectedpercentage <> Percentage.Right Then
                percRightBtn.BackColor = colorRightHover
            End If
        Else
            percRightBtn.BackColor = colorDisabledHover
        End If
    End Sub

    Private Sub percRightBtn_MouseLeave(sender As Object, e As EventArgs) Handles percRightBtn.MouseLeave, Panel2.MouseLeave
        If isSet() Then
            If _selectedpercentage <> Percentage.Right Then
                percRightBtn.BackColor = colorRight
            End If
        Else
            percRightBtn.BackColor = colorDisabled
        End If
    End Sub

    Private Sub Panel2_Resize(sender As Panel, e As EventArgs) Handles Panel2.Resize
        updateSize()
    End Sub

    Private Sub updateSize()
        If isSet() Then
            Panel2.BackColor = colorRightHover
            percRightBtn.BackColor = colorRight
            percLeft.Width = LeftValue / (LeftValue + RightValue) * Panel2.Width
            If percLeft.Width < 6 Then
                If Panel2.Width >= 8 Then
                    percLeft.Width = 6
                End If
            End If
            percLeftBtn.Width = percLeft.Width - 4
            percLeft.Visible = True
            percRightBtn.Width = Panel2.Width - percLeft.Width - 4
            percRightBtn.Location = New Point(percLeft.Width + 2, percRightBtn.Location.Y)
        Else
            Panel2.BackColor = colorDisabledHover
            percRightBtn.BackColor = colorDisabled
            percLeft.Visible = False
            percLeft.Width = 0
            percRightBtn.Width = Panel2.Width - 4
            percRightBtn.Location = New Point(2, percRightBtn.Location.Y)
        End If
    End Sub

    Private Sub percLeftBtn_Click(sender As Object, e As EventArgs) Handles percLeftBtn.Click, percLeft.Click
        If Enabled Then
            SelectedPercentage = Percentage.Left
            RaiseEvent ClickOnLeftValue(sender, e)
            percLeftBtn.BackColor = colorLeftHover
        End If
    End Sub

    Private Sub percRightBtn_Click(sender As Object, e As EventArgs) Handles percRightBtn.Click, Panel2.Click
        If Enabled Then
            If isSet() Then
                SelectedPercentage = Percentage.Right
                RaiseEvent ClickOnRightValue(sender, e)
                percRightBtn.BackColor = colorRightHover
            End If
        End If
    End Sub

    <Category("Default"),
    Description("Click on left percentage")>
    Public Event ClickOnLeftValue(sender As Object, e As EventArgs)

    <Category("Default"),
    Description("Click on right percentage")>
    Public Event ClickOnRightValue(sender As Object, e As EventArgs)

    <Category("Default"),
    Description("Click on reset button")>
    Public Event ClickOnResetButton(sender As Object, e As EventArgs)

    Public Enum Percentage
        Left
        Right
        All
        Other
    End Enum

    Private Sub btnResetFilter_Click(sender As Object, e As EventArgs) Handles btnResetFilter.Click
        If Enabled Then
            SelectedPercentage = Percentage.All
            RaiseEvent ClickOnResetButton(sender, e)
        End If
    End Sub
End Class
