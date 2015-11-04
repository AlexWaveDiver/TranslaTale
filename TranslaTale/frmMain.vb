Imports System.Drawing
Imports System.Resources
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Xml
Imports System.Text

Public Class frmMain
    Dim actualColor As String = "white"
    Dim lastClicked As Integer = 0
    Dim opened As Boolean = True
    Dim saved As Boolean = True
    Dim fileNameTitle As String = ""
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTextbox.CheckedChanged
        picTxtFlowey.Visible = False
        picTxtEnemy.Visible = False
        picTxtBox.Visible = True

        c1.Visible = True
        c2.Visible = True
        c3.Visible = True
        cf1.Visible = False
        cf2.Visible = False
        cf3.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFacebox.CheckedChanged
        picTxtFlowey.Visible = True
        picTxtEnemy.Visible = False
        picTxtBox.Visible = False

        c1.Visible = False
        c2.Visible = False
        c3.Visible = False
        cf1.Visible = True
        cf2.Visible = True
        cf3.Visible = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        picTxtFlowey.Visible = False
        picTxtEnemy.Visible = True
        picTxtBox.Visible = False
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim path1 As String
        Dim path2 As String
        Dim numLines As Integer
        Dim numLines2 As Integer

        SaveFileDialog1.Filter = "Text file|*.txt"
        OpenFileDialog1.Title = "Open base file"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            path1 = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        SaveFileDialog1.Filter = "Text file|*.txt"
        OpenFileDialog1.Title = "Open translation file"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            path2 = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If
        ListView1.Enabled = False
        TextBox1.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ttipUntranslated.Text = "0"
        ttipTranslated.Text = "0"
        ttipTotal.Text = "0"
        AddToolStripMenuItem.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = False
        showText("")
        TextBox1.Text = ""
        fileNameTitle = OpenFileDialog1.SafeFileName
        ListView1.Clear()
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.ShowGroups = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Line", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        ListView1.HideSelection = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = False
        ListView1.OwnerDraw = False

        With ListView1
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.4)
            .Columns(2).Width = CInt(.Width * 0.4)
        End With

        Dim sr As New System.IO.StreamReader(path1)
        Dim lines() As String = IO.File.ReadAllLines(path1)
        numLines = lines.Count()
        sr.Close()

        Dim sr2 As New System.IO.StreamReader(path2)
        Dim lines2() As String = IO.File.ReadAllLines(path2)
        numLines2 = lines2.Count()
        sr2.Close()

        If numLines <> numLines2 Then
            MsgBox("Both files must have the same number of lines", vbExclamation)
            Exit Sub
        End If

        If numLines < 1 Or numLines2 < 1 Then
            MsgBox("The files must not be empty", vbExclamation)
            Exit Sub
        End If

        Dim i As Integer
        Dim transLines As Integer = 0
        Dim untransLines As Integer = 0
        For i = 0 To numLines - 1
            Dim itemToAdd As New ListViewItem({i + 1, lines(i), lines2(i)})
            If lines(i) <> lines2(i) Then
                itemToAdd.BackColor = Color.LightGreen
                transLines = transLines + 1
            Else
                itemToAdd.BackColor = Color.LightSalmon
                untransLines = untransLines + 1
            End If
            ListView1.Items.Add(itemToAdd)
        Next i
        ListView1.Enabled = True
        TextBox1.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        ttipUntranslated.Text = untransLines
        ttipTranslated.Text = transLines
        ttipTotal.Text = numLines
        AddToolStripMenuItem.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True
        ToolStripButton4.Enabled = True
        If numLines < 1 Or numLines2 < 1 Then
            ListView1.Items(0).Selected = True
        End If
        ListView1.Focus()
        ListView1.HideSelection = False
        showText(ListView1.Items(0).SubItems(2).Text)
        TextBox1.Text = ListView1.Items(0).SubItems(2).Text
        Me.Text = "TranslaTale - " + fileNameTitle
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.SelectedItems(0).SubItems(2).Text = TextBox1.Text
            showText(TextBox1.Text)
            If ListView1.SelectedItems(0).SubItems(1).Text <> TextBox1.Text Then
                ListView1.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + fileNameTitle + " *"
                SaveToolStripMenuItem.Enabled = True
            Else
                ListView1.SelectedItems(0).BackColor = Color.LightSalmon
            End If
            countTranslated()
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save translation file"
        SaveFileDialog1.Filter = "Text file|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim W As IO.StreamWriter
            Dim i As Integer
            W = New IO.StreamWriter(SaveFileDialog1.FileName)
            For i = 0 To ListView1.Items.Count - 1
                If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                    On Error Resume Next
                    W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                End If
            Next
            W.Close()
            saved = True
        End If
        Me.Text = "TranslaTale - " + fileNameTitle
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Settings.Reset()
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.ShowGroups = False
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Line", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Base text", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Translated text", 150, HorizontalAlignment.Left)

        ListView1.HideSelection = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = False
        ListView1.OwnerDraw = False
        cbFonts.SelectedIndex = 0
        With ListView1
            .Columns(0).Width = CInt(.Width * 0.1)
            .Columns(1).Width = CInt(.Width * 0.4)
            .Columns(2).Width = CInt(.Width * 0.4)
        End With
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim stat As Integer
        If saved = False Then
            stat = MsgBox("Do you want to save your changes?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                e.Cancel = True
            ElseIf stat = 6 Then
                SaveFileDialog1.Filter = "Text file|*.txt"
                SaveFileDialog1.Title = "Save translation file"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Dim W As IO.StreamWriter
                    Dim i As Integer
                    W = New IO.StreamWriter(SaveFileDialog1.FileName)
                    For i = 0 To ListView1.Items.Count
                        If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                            On Error Resume Next
                            W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                        End If
                    Next
                    W.Close()
                    saved = True
                    End
                Else
                    saved = False
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If saved = False Then
            Dim stat As Integer
            stat = MsgBox("Do you want to save your file?", vbYesNoCancel + vbInformation)
            If stat = 2 Then
                Exit Sub
            ElseIf stat = 7 Then
                End
            ElseIf stat = 6 Then
                SaveFileDialog1.Filter = "Text file|*.txt"
                SaveFileDialog1.Title = "Save translation file"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    Dim W As IO.StreamWriter
                    Dim i As Integer
                    W = New IO.StreamWriter(SaveFileDialog1.FileName)
                    For i = 0 To ListView1.Items.Count
                        If ListView1.Items.Count - 1 < ttipTotal.Text Or ListView1.Items.Count - 1 = ttipTotal.Text Then
                            On Error Resume Next
                            W.WriteLine(ListView1.Items.Item(i).SubItems(2).Text)
                        End If
                    Next
                    W.Close()
                    saved = True
                    End
                Else
                    Exit Sub
                End If
            End If
        Else
            End
        End If
    End Sub

    Private Sub DumpStringstxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpStringstxtToolStripMenuItem.Click
        Dim winPath As String
        Dim stringsPath As String
        Dim sPath As String
        Dim unpackStringsProc As Process

        OpenFileDialog2.Filter = "data.win|data.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        SaveFileDialog2.Filter = "Text file|*.txt"
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            stringsPath = SaveFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\libgcc_s_dw2-1.dll"
        System.IO.File.WriteAllBytes(filename, My.Resources.libgcc_s_dw2_1)

        filename = Application.StartupPath + "\gmktool.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.gmktool)


        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ strings unpack """ & stringsPath & """"

        unpackStringsProc = Process.Start(p)
        unpackStringsProc.WaitForExit()
        Dim i As Integer
        For i = 0 To 4
            If Not unpackStringsProc.HasExited Then
                unpackStringsProc.Refresh()
            Else
                Exit For
            End If
        Next i

        MsgBox("Process finished", vbInformation)

        sPath = StrReverse(SaveFileDialog2.FileName)
        sPath = Mid(sPath, InStr(sPath, "\"), Len(sPath))
        sPath = StrReverse(sPath)
        Process.Start(sPath)
    End Sub

    Public Function drawTextLine(ByVal elem As PictureBox, ByVal text As String)
        Dim output As New Bitmap(1547, 30)
        Dim gfx As Graphics = Graphics.FromImage(output)
        Dim line As Integer = 0
        Dim baseFont As String = "font1"

        If cbFonts.SelectedItem = "Standard" Then
            baseFont = "font1"
        ElseIf cbFonts.SelectedItem = "Sans" Then
            baseFont = "font2"
        ElseIf cbFonts.SelectedItem = "Papyrus" Then
            baseFont = "font3"
        End If

        text = text.Replace("\W", "⁰").Replace("\X", "⁰").Replace("\L", "⁹").Replace("\Y", "⁴").Replace("\G", "⁵").Replace("\B", "⁶").Replace("\O", "⁷").Replace("\R", "⁸").Replace("\P", "ⁿ").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")

        'With text



        'End With
        'Dim image As New Bitmap(CType(My.Resources.ResourceManager.GetObject("font1"), Image))
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!?(){}-.:;,$[]@*'"" "
        Dim charmap As Char() = chars.ToCharArray()
        Dim left As Integer = 0
        Dim fr_bm As New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont), Image))
        Select Case actualColor
            Case "white"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont), Image))
            Case "yellow"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "y"), Image))
            Case "green"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "g"), Image))
            Case "blue"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "b"), Image))
            Case "orange"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "o"), Image))
            Case "red"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "r"), Image))
            Case "purple"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "p"), Image))
            Case "lightblue"
                fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "l"), Image))
        End Select
        For Each c As Char In text
            Dim partOfCharmap As String = Array.IndexOf(charmap, c)
            If partOfCharmap <> -1 Then
                Dim charPos As Integer = 0

                Select Case baseFont
                    Case "font1"
                        Dim itemindex As Integer = Array.IndexOf(charmap, c)
                        Dim charPosition = itemindex * 17

                        Dim gr As Graphics = Graphics.FromImage(output)

                        Dim fr_rect As New Rectangle(charPosition, 0, 16, 30)
                        Dim to_rect As New Rectangle(left, 0, 17, 30)

                        gr.DrawImage(fr_bm, to_rect, fr_rect, GraphicsUnit.Pixel)
                        left = left + 16
                    Case "font2"
                        Dim itemindex As Integer = Array.IndexOf(charmap, c)
                        Dim charPosition = itemindex * 17

                        Dim gr As Graphics = Graphics.FromImage(output)

                        Dim fr_rect As New Rectangle(charPosition, 0, 16, 30)
                        Dim to_rect As New Rectangle(left, 0, 17, 30)

                        gr.DrawImage(fr_bm, to_rect, fr_rect, GraphicsUnit.Pixel)
                        If c = "i" Or c = "l" Then
                            left = left + 11
                        Else
                            left = left + 16
                        End If
                    Case "font3"
                        Dim itemindex As Integer = Array.IndexOf(charmap, c)
                        Dim charPosition = itemindex * 28

                        Dim gr As Graphics = Graphics.FromImage(output)

                        Dim fr_rect As New Rectangle(charPosition, 0, 26, 30)
                        Dim to_rect As New Rectangle(left, 0, 26, 30)

                        gr.DrawImage(fr_bm, to_rect, fr_rect, GraphicsUnit.Pixel)
                        Select Case c
                            Case "A"
                                left = left + 26
                            Case "B"
                                left = left + 24
                            Case "C"
                                left = left + 24
                            Case "D"
                                left = left + 24
                            Case "E"
                                left = left + 22
                            Case "F"
                                left = left + 22
                            Case "G"
                                left = left + 24
                            Case "H"
                                left = left + 25
                            Case "I"
                                left = left + 10
                            Case "J"
                                left = left + 22
                            Case "K"
                                left = left + 20
                            Case "L"
                                left = left + 20
                            Case "M"
                                left = left + 24
                            Case "N"
                                left = left + 22
                            Case "O"
                                left = left + 26
                            Case "P"
                                left = left + 18
                            Case "Q"
                                left = left + 28
                            Case "R"
                                left = left + 18
                            Case "S"
                                left = left + 24
                            Case "T"
                                left = left + 20
                            Case "U"
                                left = left + 22
                            Case "V"
                                left = left + 22
                            Case "W"
                                left = left + 26
                            Case "X"
                                left = left + 22
                            Case "Y"
                                left = left + 24
                            Case "Z"
                                left = left + 18
                            Case "!"
                                left = left + 18
                            Case "a"
                                left = left + 24
                            Case "b"
                                left = left + 22
                            Case "c"
                                left = left + 22
                            Case "d"
                                left = left + 22
                            Case "e"
                                left = left + 20
                            Case "f"
                                left = left + 22
                            Case "g"
                                left = left + 24
                            Case "h"
                                left = left + 26
                            Case "i"
                                left = left + 17
                            Case "j"
                                left = left + 28
                            Case "k"
                                left = left + 26
                            Case "l"
                                left = left + 22
                            Case "m"
                                left = left + 22
                            Case "n"
                                left = left + 22
                            Case "o"
                                left = left + 22
                            Case "p"
                                left = left + 22
                            Case "q"
                                left = left + 22
                            Case "r"
                                left = left + 22
                            Case "s"
                                left = left + 20
                            Case "t"
                                left = left + 24
                            Case "u"
                                left = left + 20
                            Case "v"
                                left = left + 22
                            Case "w"
                                left = left + 22
                            Case "x"
                                left = left + 26
                            Case "y"
                                left = left + 22
                            Case "z"
                                left = left + 22
                            Case "0"
                                left = left + 26
                            Case "1"
                                left = left + 20
                            Case "2"
                                left = left + 22
                            Case "3"
                                left = left + 20
                            Case "4"
                                left = left + 24
                            Case "5"
                                left = left + 22
                            Case "6"
                                left = left + 22
                            Case "7"
                                left = left + 22
                            Case "8"
                                left = left + 20
                            Case "9"
                                left = left + 26
                            Case "!"
                                left = left + 16
                            Case "?"
                                left = left + 18
                            Case "("
                                left = left + 20
                            Case ")"
                                left = left + 20
                            Case "{"
                                left = left + 20
                            Case "}"
                                left = left + 20
                            Case "-"
                                left = left + 20
                            Case "_"
                                left = left + 20
                            Case ":"
                                left = left + 20
                            Case ";"
                                left = left + 22
                            Case "."
                                left = left + 18
                            Case ","
                                left = left + 24
                            Case "$"
                                left = left + 22
                            Case "["
                                left = left + 22
                            Case "]"
                                left = left + 20
                            Case "@"
                                left = left + 22
                            Case "`"
                                left = left + 22
                            Case "'"
                                left = left + 12
                            Case """"
                                left = left + 14
                            Case "*"
                                left = left + 22
                            Case " "
                                left = left + 20
                            Case Else
                                left = left + 26
                        End Select
                End Select

            Else
                Select Case c
                    Case "⁰"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont), Image))
                        actualColor = "white"
                    Case "⁴"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "y"), Image))
                        actualColor = "yellow"
                    Case "⁵"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "g"), Image))
                        actualColor = "green"
                    Case "⁶"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "b"), Image))
                        actualColor = "blue"
                    Case "⁷"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "o"), Image))
                        actualColor = "orange"
                    Case "⁸"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "r"), Image))
                        actualColor = "red"
                    Case "ⁿ"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "p"), Image))
                        actualColor = "purple"
                    Case "⁹"
                        fr_bm = New Bitmap(CType(My.Resources.ResourceManager.GetObject(baseFont + "l"), Image))
                        actualColor = "lightblue"
                End Select
            End If
        Next

        elem.Image = output
        Return True
    End Function

    Public Function countTranslated()
        Dim stringsTranslated As Integer = 0
        Dim stringsUntranslated As Integer = 0
        For Each item As ListViewItem In Me.ListView1.Items
            If item.BackColor = Color.LightGreen Then
                stringsTranslated = stringsTranslated + 1
            Else
                stringsUntranslated = stringsUntranslated + 1
            End If
        Next
        ttipUntranslated.Text = stringsUntranslated
        ttipTranslated.Text = stringsTranslated
        Return True
    End Function

    Public Function showText(ByVal txt As String)
        Dim textToPrint As String() = Split(txt, "&")
        drawTextLine(c1, "")
        drawTextLine(c2, "")
        drawTextLine(c3, "")
        drawTextLine(cf1, "")
        drawTextLine(cf2, "")
        drawTextLine(cf3, "")
        If textToPrint.Count > 0 Then
            drawTextLine(c1, textToPrint(0))
            drawTextLine(cf1, textToPrint(0))
        End If
        If textToPrint.Count > 1 Then
            drawTextLine(c2, textToPrint(1))
            drawTextLine(cf2, textToPrint(1))
        End If
        If textToPrint.Count > 2 Then
            drawTextLine(c3, textToPrint(2))
            drawTextLine(cf3, textToPrint(2))
        End If
        actualColor = "white"
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ListBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBookmarksToolStripMenuItem.Click
        frmBookmarks.ShowDialog()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            If ListView1.SelectedItems(0) IsNot Nothing Then
                Dim val As String = ListView1.SelectedItems(0).SubItems(2).Text
                TextBox1.Text = val
                showText(val)
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Dim tag As String = InputBox("Bookmark name")
        If tag <> "" Then
            saveBookmark(ListView1.SelectedItems(0).Index + 1, tag)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        OpenToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        frmSearch.Show()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        frmGoTo.ShowDialog()
    End Sub

    Private Sub cbFonts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFonts.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            If ListView1.SelectedItems(0) IsNot Nothing Then
                Dim val As String = ListView1.SelectedItems(0).SubItems(2).Text
                TextBox1.Text = val
                showText(val)
            End If
        End If
    End Sub

    Private Sub RepackStringstxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepackStringstxtToolStripMenuItem.Click
        Dim winPath As String
        Dim stringsPath As String
        Dim repackStringsProc As Process

        OpenFileDialog2.Filter = "Text files|*.txt"
        OpenFileDialog2.Title = "Select your Strings.txt file"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            stringsPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If
        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\libgcc_s_dw2-1.dll"
        System.IO.File.WriteAllBytes(filename, My.Resources.libgcc_s_dw2_1)

        filename = Application.StartupPath + "\gmktool.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.gmktool)

        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ strings repack """ & stringsPath & """"

        repackStringsProc = Process.Start(p)
        repackStringsProc.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not repackStringsProc.HasExited Then
                repackStringsProc.Refresh()
            Else
                Exit For
            End If
        Next i

        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub DumpImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpImagesToolStripMenuItem.Click
        Dim winPath As String
        Dim imgPath As String
        Dim unpackImagesProc As Process

        OpenFileDialog2.Filter = "data.win|data.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        FolderBrowserDialog1.Description = "Choose an extraction location"
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            imgPath = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If


        Dim filename As String = Application.StartupPath + "\libgcc_s_dw2-1.dll"
        System.IO.File.WriteAllBytes(filename, My.Resources.libgcc_s_dw2_1)

        filename = Application.StartupPath + "\gmktool.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.gmktool)

        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ textures unpack"
        unpackImagesProc = Process.Start(p)
        unpackImagesProc.WaitForExit()

        Clipboard.SetText(p.FileName + " " + p.Arguments)
        Dim i As Integer
        For i = 0 To 4
            If Not unpackImagesProc.HasExited Then
                unpackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i

        For Each f In Directory.GetFiles(Application.StartupPath, "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(imgPath, Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(imgPath, Path.GetFileName(f)))
                End If
                File.Move(f, Path.Combine(imgPath, Path.GetFileName(f)))
            End If
        Next
        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub RepackImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepackImagesToolStripMenuItem.Click
        Dim winPath As String
        Dim imgPath As String
        Dim repackImagesProc As Process
        FolderBrowserDialog1.Description = "Choose the resources location"
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            imgPath = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        For Each f In Directory.GetFiles(imgPath, "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(Application.StartupPath, Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(Application.StartupPath, Path.GetFileName(f)))
                End If
                File.Copy(f, Path.Combine(Application.StartupPath, Path.GetFileName(f)), True)
            End If
        Next

        Dim filename As String = Application.StartupPath + "\libgcc_s_dw2-1.dll"
        System.IO.File.WriteAllBytes(filename, My.Resources.libgcc_s_dw2_1)

        filename = Application.StartupPath + "\gmktool.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.gmktool)

        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ textures repack"
        repackImagesProc = Process.Start(p)
        repackImagesProc.WaitForExit()
        Dim i As Integer
        For i = 0 To 4
            If Not repackImagesProc.HasExited Then
                repackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i
        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class