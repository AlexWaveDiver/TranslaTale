Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports NBT.IO
Imports NBT.Tags

Public Class frmMain
    Dim actualColor As String = "white"
    Dim lastClicked As Integer = 0
    Dim opened As Boolean = True
    Dim saved As Boolean = True
    Public fileNameTitle As String = ""
    Dim fontResource As String = Application.StartupPath + "\fonts.png"

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTextbox.CheckedChanged
        If rbTextbox.Checked Then
            SpriteFontBox1.ShowFaces = False
        Else
            SpriteFontBox1.ShowFaces = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFacebox.CheckedChanged
        If rbFacebox.Checked Then
            SpriteFontBox1.ShowFaces = True
        Else
            SpriteFontBox1.ShowFaces = False
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Timer1.Enabled = False
        If stringsPnl.SelectedItems.Count > 0 Then
            Dim index As Integer = CurrentSession.getIndex(stringsPnl.SelectedItems(0))
            Dim linea As LineDouble = CurrentSession.getLine(index)
            CurrentSession.listViewObjects(index).SubItems(2).Text = TextBox1.Text
            CurrentSession.lines(index).translatedText = TextBox1.Text
            stringsPnl.SelectedItems(0).SubItems(2).Text = TextBox1.Text
            If stringsPnl.SelectedItems(0).SubItems(1).Text <> TextBox1.Text Then
                CurrentSession.listViewObjects(index).BackColor = Color.LightGreen
                stringsPnl.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + fileNameTitle + " *"
                SaveToolStripMenuItem.Enabled = True
                ResetBtn.Visible = True
            Else
                CurrentSession.listViewObjects(index).BackColor = Color.LightSalmon
                stringsPnl.SelectedItems(0).BackColor = Color.LightSalmon
                ResetBtn.Visible = False
            End If
        Else
            TextBox1.Enabled = False
            TextBox1.Text = ""
            showText(TextBox1.Text)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not My.Settings.fontsheetPath = "" And Not File.Exists(My.Settings.fontsheetPath) Then
            MsgBox("Custom fontsheet not found. Using default fontsheet instead.", vbInformation)
            SpriteFontBox1.ImageLocation = fontResource
        Else
            SpriteFontBox1.ImageLocation = My.Settings.fontsheetPath
        End If

        If Not File.Exists(fontResource) Then
            My.Resources.fonts.Save(fontResource)
        End If

        SpriteFontBox1.FontPath = fontResource
        SpriteFontBox1.LoadFont()

        stringsPnl.View = View.Details
        stringsPnl.Clear()
        stringsPnl.ShowGroups = False
        stringsPnl.Columns.Clear()
        stringsPnl.Columns.Add("Line", 100, HorizontalAlignment.Left)
        stringsPnl.Columns.Add("Base text", 150, HorizontalAlignment.Left)
        stringsPnl.Columns.Add("Translated text", 200, HorizontalAlignment.Left)

        stringsPnl.HideSelection = True
        stringsPnl.FullRowSelect = True
        stringsPnl.CheckBoxes = False

        Dim filename As String
        filename = Application.StartupPath + "\NBT.dll"
        System.IO.File.WriteAllBytes(filename, My.Resources.NBT_edit)

        ListViewHelper.EnableDoubleBuffer(stringsPnl)
        cbFonts.SelectedIndex = 0
        With stringsPnl
            .Columns(0).Width = 65
            .Columns(1).Width = CInt((.Width - 65) * 0.45)
            .Columns(2).Width = CInt((.Width - 65) * 0.5)
        End With

        viewMode = ViewModes.Default
    End Sub

    Private _viewMode As ViewModes
    Public Property viewMode As ViewModes
        Get
            Return _viewMode
        End Get
        Set(value As ViewModes)
            If value = ViewModes.Editor Then
                projectmanagerPnl.Visible = False
                welcomePnl.Visible = False
                stringsPnl.Visible = True

                stringsPnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = False

                topPnl.Visible = True
                bottomPnl.Visible = True

                stringsPnl.Enabled = True
                TextBox1.Enabled = True
                SaveToolStripMenuItem.Enabled = True
                ToolStripButton3.Enabled = True
                RepackGameASCIICharactersToolStripMenuItem.Enabled = True
                RepackGamecustomFontsToolStripMenuItem.Enabled = True
                ToolStripButton4.Enabled = True
                pnlGroups.Enabled = True
                btnSetGroup.Enabled = True
                TranslationPercentageBox1.Enabled = True
                projectManagerToolBtn.Enabled = True
                stringsEditorToolBtn.Enabled = False

                With stringsPnl
                    .Columns(0).Width = 65
                    .Columns(1).Width = CInt((.Width - 65) * 0.45)
                    .Columns(2).Width = CInt((.Width - 65) * 0.5)
                End With
                stringsPnl.Focus()
                RicalcolaGruppi()
            ElseIf value = ViewModes.ProjectManager Then
                stringsPnl.Visible = False
                welcomePnl.Visible = False
                projectmanagerPnl.Visible = True
                projectmanagerPnl.Focus()

                projectmanagerPnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = False

                topPnl.Visible = True
                bottomPnl.Visible = False

                TextBox1.Enabled = False
                SaveToolStripMenuItem.Enabled = True
                ToolStripButton3.Enabled = False
                RepackGameASCIICharactersToolStripMenuItem.Enabled = True
                RepackGamecustomFontsToolStripMenuItem.Enabled = True
                ToolStripButton4.Enabled = False
                filtermenubtn.Enabled = False
                pnlGroups.Enabled = True
                btnSetGroup.Enabled = False
                TranslationPercentageBox1.Enabled = False
                showText("")
                TextBox1.Text = ""
                projectManagerToolBtn.Enabled = False
                stringsEditorToolBtn.Enabled = True

            ElseIf value = ViewModes.Default Then
                stringsPnl.Visible = False
                projectmanagerPnl.Visible = False
                welcomePnl.Visible = True
                welcomePnl.Focus()

                welcomePnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = True

                topPnl.Visible = False
                bottomPnl.Visible = False

                SaveToolStripMenuItem.Enabled = False
                ToolStripButton3.Enabled = False
                RepackGameASCIICharactersToolStripMenuItem.Enabled = False
                RepackGamecustomFontsToolStripMenuItem.Enabled = False
                ToolStripButton4.Enabled = False
                filtermenubtn.Enabled = False
                pnlGroups.Enabled = False
                btnSetGroup.Enabled = False
                TranslationPercentageBox1.Enabled = False
                showText("")
                TextBox1.Text = ""
                projectManagerToolBtn.Enabled = False
                stringsEditorToolBtn.Enabled = False
            End If
            _viewMode = value
        End Set
    End Property

    Public Enum ViewModes
        Editor
        ProjectManager
        [Default]
    End Enum

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles openProjectBtn.LinkClicked
        LoadTTX()
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
                    W = New IO.StreamWriter(SaveFileDialog1.FileName)
                    For i = 0 To CurrentSession.length - 1
                        If i = CurrentSession.length Then
                            If CurrentSession.lines.ContainsKey(i) Then
                                W.Write(CurrentSession.lines(i).translatedText)
                            Else
                                W.Write("")
                            End If
                        Else
                            If CurrentSession.lines.ContainsKey(i) Then
                                W.WriteLine(CurrentSession.lines(i).translatedText)
                            Else
                                W.WriteLine("")
                            End If
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

    Public Function countTranslated()
        Dim stringsTranslated As Integer = 0
        Dim stringsUntranslated As Integer = 0
        For Each item In CurrentSession.lines
            If item.Value.Tradotto Then
                stringsTranslated = stringsTranslated + 1
            Else
                stringsUntranslated = stringsUntranslated + 1
            End If
        Next
        TranslationPercentageBox1.RightValue = stringsUntranslated
        TranslationPercentageBox1.LeftValue = stringsTranslated
        GC.Collect()
        Return True
    End Function

    Public Function showText(ByVal txt As String)
        SpriteFontBox1.Text = txt
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub stringsPnl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles stringsPnl.SelectedIndexChanged
        If stringsPnl.SelectedItems.Count > 0 Then
            If stringsPnl.SelectedItems(0) IsNot Nothing Then
                Dim val As String = stringsPnl.SelectedItems(0).SubItems(2).Text
                TextBox1.Enabled = True
                TextBox1.Text = FilterText(val, True, False)
                If stringsPnl.SelectedItems(0).SubItems(1).Text <> stringsPnl.SelectedItems(0).SubItems(2).Text Then
                    ResetBtn.Visible = True
                Else
                    ResetBtn.Visible = False
                End If
                showText(val)
            Else
                TextBox1.Enabled = False
                TextBox1.Text = ""
                ResetBtn.Visible = False
                showText(TextBox1.Text)
            End If
        Else
            TextBox1.Enabled = False
            TextBox1.Text = ""
            ResetBtn.Visible = False
            showText(TextBox1.Text)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.Enabled = False
        Dim fil As Efiltro = filtro
        Dim filg As Integer = filtroGruppo
        If (filtro <> Efiltro.Default_mode) Then
            filtro = Efiltro.Default_mode
            filtroGruppo = -1
            Ricalcola()
            Me.Enabled = False
        End If
        Dim lineslength = CurrentSession.length
        filtro = fil
        filtroGruppo = filg
        fil = Nothing
        SaveFileDialog1.Title = "Save translation file"
        SaveFileDialog1.Filter = "TranslaTale file|*.ttx|Export translation Strings.txt|*.txt"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            saved = SaveTTX(SaveFileDialog1.FileName)
            If saved = False Then
                MsgBox("Error during file saving!" & vbCrLf & "Please, retry.", MsgBoxStyle.Critical, "TranslaTale")
            End If
        End If
        Me.Text = "TranslaTale - " + fileNameTitle
        Me.Enabled = True
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openProjectBtn2.Click
        LoadTTX()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim frmgoto As New frmGoTo()
        Dim line As Integer = frmgoto.PopupGoTo()

        If (Me.filtro <> frmMain.Efiltro.Default_mode) Then
            Me.filtro = frmMain.Efiltro.Default_mode
            filtroGruppo = -1
            Me.Ricalcola()
        End If
        If CurrentSession.listViewObjects.ContainsKey(line - 1) Then
            Dim item As ListViewItem = CurrentSession.listViewObjects(line - 1)
            If item.Text = line.ToString Then
                stringsPnl.SelectedItems().Clear()
                item.Selected = True
                item.EnsureVisible()
                stringsPnl.Focus()
                Dim val As String = CurrentSession.getLine(line - 1).translatedText
                Me.showText(val)
                Me.TextBox1.Text = FilterText(val, True, False)
                Return
            End If
        End If

        If line <> -1 Then
            MsgBox("Line " + line.ToString + " not found", vbInformation)
            ToolStripButton4.PerformClick()
        End If
    End Sub

    Private Sub cbFonts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFonts.SelectedIndexChanged
        If stringsPnl.SelectedItems.Count > 0 Then
            SpriteFontBox1.CurrentSpriteFont = DirectCast([Enum].Parse(GetType(UTSpriteFontBox.SpriteFontBox.SpriteFonts), cbFonts.SelectedItem), UTSpriteFontBox.SpriteFontBox.SpriteFonts)
            If stringsPnl.SelectedItems(0) IsNot Nothing Then
                Dim val As String = stringsPnl.SelectedItems(0).SubItems(2).Text
                TextBox1.Text = FilterText(val, True, False)
                showText(val)
            End If
        End If
    End Sub

    Private Sub DumpOriginalImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpOriginalImagesToolStripMenuItem.Click
        Dim winPath As String
        Dim imgPath As String
        Dim unpackImagesProc As Process

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim options As Integer = &H40 + &H20
        options += &H10   '' Adds edit box
        Dim shellAppType As Type = Type.GetTypeFromProgID("Shell.Application")
        Dim shell As Object = Activator.CreateInstance(shellAppType)
        Dim root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim folder = CType(shell.BrowseForFolder(Nothing, "Choose an extraction location", options, root), Shell32.Folder2)
        If folder Is Nothing Then
            Exit Sub
        Else
            imgPath = folder.Self.Path
            If Not Directory.Exists(imgPath) Then
                MsgBox("Directory doesn't exists!", MsgBoxStyle.Exclamation, "TranslaTale")
                Exit Sub
            End If
        End If

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim p As New ProcessStartInfo
        Dim tmpPath As String = GetTempFolder(True)
        p.FileName = filename
        p.Arguments = """" & winPath & """ """ & tmpPath & """ -tt"
        unpackImagesProc = Process.Start(p)
        unpackImagesProc.WaitForExit()

        Dim i As Integer
        For i = 0 To 4
            If Not unpackImagesProc.HasExited Then
                unpackImagesProc.Refresh()
            Else
                Exit For
            End If
        Next i

        For Each f In Directory.GetFiles(tmpPath & "\TXTR\", "*.png")
            If File.Exists(f) Then
                If File.Exists(Path.Combine(imgPath, Path.GetFileName(f))) Then
                    File.Delete(Path.Combine(imgPath, Path.GetFileName(f)))
                End If
                File.Move(f, Path.Combine(imgPath, Path.GetFileName(f)))
            End If
        Next
        System.IO.Directory.Delete(tmpPath, True)
        MsgBox("Process finished", vbInformation)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        showText(TextBox1.Text)
        countTranslated()
        Timer1.Enabled = False
    End Sub

    Private Sub tsSearchPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each item As ListViewItem In Me.stringsPnl.Items
        '    If item.SubItems(1).Text.Contains("demon") Then
        '        MsgBox(item.Index.ToString())
        '    End If
        'Next
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        frmSearch.Show()
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If stringsPnl.Columns.Count >= 3 Then
            With stringsPnl
                .Columns(0).Width = 65
                .Columns(1).Width = CInt((.Width - 65) * 0.45)
                .Columns(2).Width = CInt((.Width - 65) * 0.5)
            End With
        End If
    End Sub

    Private Sub stringsPnl_DrawColumnHeader(ender As Object, e As DrawListViewColumnHeaderEventArgs) Handles stringsPnl.DrawColumnHeader
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        Dim pb As Rectangle = e.Bounds
        pb.Width = pb.Width * 2 + 20
        e.Graphics.DrawImage(My.Resources.ttxbgcol, pb)
        Dim pf As Rectangle = e.Bounds
        pf.X += 10
        pf.Y += 5
        e.Graphics.DrawString(e.Header.Text, e.Font, New SolidBrush(Color.Black), pf)
    End Sub

    Private Sub stringsPnl_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles stringsPnl.DrawSubItem
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim txt As String = FilterText(e.SubItem.Text, e.Item.Selected)
        Dim didanything As Boolean = False
        While e.Graphics.MeasureString(txt, e.SubItem.Font).Width > e.Bounds.Width And txt.Length > 0
            txt = txt.Substring(0, txt.Length - 1)
            didanything = True
        End While

        If txt.Length > 4 And didanything And e.ColumnIndex <> 0 And txt.Length >= 3 Then
            txt = txt.Substring(0, txt.Length - 3) & "..."
        End If

        If e.ColumnIndex = 0 And CurrentSession.isLine(e.Item) Then
            If CurrentSession.groups.ContainsKey(CurrentSession.getLine(e.Item).group) Then
                e.Graphics.FillRectangle(New SolidBrush(CurrentSession.groups(CurrentSession.getLine(e.Item).group).colore), e.Bounds)
            ElseIf CurrentSession.getLine(e.Item).group = -1 Then
                CurrentSession.groups.Add(-1, New Group(-1, "Default"))
            Else
                CurrentSession.getLine(e.Item).group = -1
            End If
        Else
            If (e.Item.Selected) Then
                e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds)
                Dim sb As New SolidBrush(Color.FromArgb(90, e.Item.BackColor.R, e.Item.BackColor.G, e.Item.BackColor.B))
                e.Graphics.FillRectangle(sb, e.Bounds)
            Else
                e.Graphics.FillRectangle(New SolidBrush(e.Item.BackColor), e.Bounds)
            End If
        End If
        e.Graphics.DrawString(txt, e.SubItem.Font, New SolidBrush(e.Item.ForeColor), e.Bounds.Location)
        txt = ""
        e.Graphics.Dispose()
    End Sub

    Public Function FilterText(txt As String, selected As Boolean) As String
        Return FilterText(txt, selected, My.Settings.dofiltertext)
    End Function

    Public Function FilterText(txt As String, selected As Boolean, dofiltertext As Boolean) As String
        If dofiltertext = False Or selected Then
            Return txt
        End If
        txt = txt.Replace("\W", "").Replace("\X", "").Replace("&", " ").Replace("\L", "").Replace("\Y", "").Replace("\G", "").Replace("\B", "").Replace("\O", "").Replace("\R", "").Replace("\P", "").Replace("^1", "").Replace("^2", "").Replace("^3", "").Replace("^4", "").Replace("^5", "").Replace("^6", "").Replace("^7", "").Replace("^8", "").Replace("^9", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\C", "").Replace("\X", "").Replace("\%%", "").Replace("\E0", "").Replace("\E1", "").Replace("\E2", "").Replace("\E3", "").Replace("\E4", "").Replace("\E5", "").Replace("\E6", "").Replace("\E7", "").Replace("\E8", "").Replace("\E9", "").Replace("\F0", "").Replace("\F1", "").Replace("\F2", "").Replace("\F3", "").Replace("\F4", "").Replace("\F5", "").Replace("\F6", "").Replace("\F7", "").Replace("\F8", "").Replace("\F9", "").Replace("\TS", "").Replace("\Ts", "").Replace("\TP", "").Replace("\TU", "").Replace("\TA", "").Replace("\TT", "").Replace("\Ta", "").Replace("\C", "").Replace("\%%", "")

        Dim count As Integer = 0
        For Each character As Char In txt
            If character = " " Then
                count += 1
            Else
                Exit For
            End If
        Next
        txt = txt.Remove(0, count)
        Return txt
    End Function

    Private Sub stringsPnl_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles stringsPnl.DrawItem
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim txt As String = FilterText(e.Item.Text, e.Item.Selected)
        Dim didanything As Boolean = False
        While e.Graphics.MeasureString(txt, e.Item.Font).Width > e.Bounds.Width And txt.Length > 0
            txt = txt.Substring(0, txt.Length - 1)
            didanything = True
        End While
        If txt.Length > 4 And didanything Then
            txt = txt.Substring(0, txt.Length - 3) & "..."
        End If
        If (e.Item.Selected) Then
            e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(90, e.Item.BackColor.R, e.Item.BackColor.G, e.Item.BackColor.B)), e.Bounds)
        Else
            e.Graphics.FillRectangle(New SolidBrush(e.Item.BackColor), e.Bounds)
        End If
        e.Graphics.DrawString(e.Item.Text, e.Item.Font, New SolidBrush(e.Item.ForeColor), e.Bounds.Location)
        txt = ""
        e.Graphics.Dispose()
    End Sub

    Private Sub stringsPnl_MouseMove(sender As Object, e As MouseEventArgs) Handles stringsPnl.MouseMove
        If Not IsNothing(stringsPnl.GetItemAt(e.X, e.Y)) Then
            stringsPnl.Invalidate(stringsPnl.GetItemRect(stringsPnl.GetItemAt(e.X, e.Y).Index))
        End If
    End Sub

    Private Sub stringsPnl_Mouseho(sender As Object, e As ListViewItemMouseHoverEventArgs) Handles stringsPnl.ItemMouseHover
        Try
            stringsPnl.Invalidate(stringsPnl.GetItemRect(e.Item.Index))
        Catch ex As Exception
        End Try
    End Sub

    Public Enum ListViewExtendedStyles
        ''' <summary>
        ''' LVS_EX_GRIDLINES
        ''' </summary>
        GridLines = &H1
        ''' <summary>
        ''' LVS_EX_SUBITEMIMAGES
        ''' </summary>
        SubItemImages = &H2
        ''' <summary>
        ''' LVS_EX_CHECKBOXES
        ''' </summary>
        CheckBoxes = &H4
        ''' <summary>
        ''' LVS_EX_TRACKSELECT
        ''' </summary>
        TrackSelect = &H8
        ''' <summary>
        ''' LVS_EX_HEADERDRAGDROP
        ''' </summary>
        HeaderDragDrop = &H10
        ''' <summary>
        ''' LVS_EX_FULLROWSELECT
        ''' </summary>
        FullRowSelect = &H20
        ''' <summary>
        ''' LVS_EX_ONECLICKACTIVATE
        ''' </summary>
        OneClickActivate = &H40
        ''' <summary>
        ''' LVS_EX_TWOCLICKACTIVATE
        ''' </summary>
        TwoClickActivate = &H80
        ''' <summary>
        ''' LVS_EX_FLATSB
        ''' </summary>
        FlatsB = &H100
        ''' <summary>
        ''' LVS_EX_REGIONAL
        ''' </summary>
        Regional = &H200
        ''' <summary>
        ''' LVS_EX_INFOTIP
        ''' </summary>
        InfoTip = &H400
        ''' <summary>
        ''' LVS_EX_UNDERLINEHOT
        ''' </summary>
        UnderlineHot = &H800
        ''' <summary>
        ''' LVS_EX_UNDERLINECOLD
        ''' </summary>
        UnderlineCold = &H1000
        ''' <summary>
        ''' LVS_EX_MULTIWORKAREAS
        ''' </summary>
        MultilWorkAreas = &H2000
        ''' <summary>
        ''' LVS_EX_LABELTIP
        ''' </summary>
        LabelTip = &H4000
        ''' <summary>
        ''' LVS_EX_BORDERSELECT
        ''' </summary>
        BorderSelect = &H8000
        ''' <summary>
        ''' LVS_EX_DOUBLEBUFFER
        ''' </summary>
        DoubleBuffer = &H10000
        ''' <summary>
        ''' LVS_EX_HIDELABELS
        ''' </summary>
        HideLabels = &H20000
        ''' <summary>
        ''' LVS_EX_SINGLEROW
        ''' </summary>
        SingleRow = &H40000
        ''' <summary>
        ''' LVS_EX_SNAPTOGRID
        ''' </summary>
        SnapToGrid = &H80000
        ''' <summary>
        ''' LVS_EX_SIMPLESELECT
        ''' </summary>
        SimpleSelect = &H100000
    End Enum

    Public Enum ListViewMessages
        First = &H1000
        SetExtendedStyle = (First + 54)
        GetExtendedStyle = (First + 55)
    End Enum

    ''' <summary>
    ''' Contains helper methods to change extended styles on ListView, including enabling double buffering.
    ''' Based on Giovanni Montrone's article on <see href="http://www.codeproject.com/KB/list/listviewxp.aspx"/>
    ''' </summary>
    Public Class ListViewHelper
        Private Shared nativemethod As New NativeMethods()
        Private Sub New()
        End Sub

        Public Shared Sub SetExtendedStyle(control As Control, exStyle As ListViewExtendedStyles)
            Dim styles As ListViewExtendedStyles
            styles = CType(nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.GetExtendedStyle), 0, 0), ListViewExtendedStyles)
            styles = styles Or exStyle
            nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.SetExtendedStyle), 0, CInt(styles))
        End Sub

        Public Shared Sub EnableDoubleBuffer(control As Control)
            Dim styles As ListViewExtendedStyles
            ' read current style
            styles = CType(nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.GetExtendedStyle), 0, 0), ListViewExtendedStyles)
            ' enable double buffer and border select
            styles = styles Or ListViewExtendedStyles.DoubleBuffer Or ListViewExtendedStyles.BorderSelect
            ' write new style
            nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.SetExtendedStyle), 0, CInt(styles))
        End Sub
        Public Shared Sub DisableDoubleBuffer(control As Control)
            Dim styles As ListViewExtendedStyles
            ' read current style
            styles = CType(nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.GetExtendedStyle), 0, 0), ListViewExtendedStyles)
            ' disable double buffer and border select
            styles -= styles And ListViewExtendedStyles.DoubleBuffer
            styles -= styles And ListViewExtendedStyles.BorderSelect
            ' write new style
            nativemethod.SendMessageFunction(control.Handle, CInt(ListViewMessages.SetExtendedStyle), 0, CInt(styles))
        End Sub
    End Class

    Public filtro As Efiltro = Efiltro.Default_mode
    Public filtroGruppo As Integer = -1
    Public Enum Efiltro
        Default_mode
        NotTranslated
        Translated
        SpecificGroup
    End Enum

    Private Sub TranslatedStringsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TranslationPercentageBox1.ClickOnLeftValue
        If viewMode = ViewModes.Editor And filtro <> Efiltro.Translated Then
            filtro = Efiltro.Translated
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Public Sub Ricalcola()
        Me.Enabled = False
        TextBox1.Enabled = False
        TextBox1.Text = ""
        stringsPnl.BeginUpdate()
        stringsPnl.Items.Clear()
        stringsPnl.Items.AddRange(CurrentSession.getListViewLines(filtro, filtroGruppo))
        stringsPnl.EndUpdate()

        RicalcolaGruppi()

        countTranslated()
        Me.Enabled = True
    End Sub

    Public Sub RicalcolaGruppi()
        filterByGroupBtn.DropDownItems.Clear()
        For Each group In CurrentSession.groups
            Dim bmp As New Bitmap(32, 32)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.Clear(group.Value.colore)
            filterByGroupBtn.DropDownItems.Add(New ToolStripMenuItem(group.Value.numero & " - " & group.Value.name, bmp, AddressOf filterbygroup))
        Next
        btnCreateGroup.Enabled = True
        If filterByGroupBtn.DropDownItems.Count <= 1 Then
            filterByGroupBtn.Enabled = False
            btnEditGroup.Enabled = False
            btnDeleteGroup.Enabled = False
            btnSetGroup.Enabled = False
        Else
            filterByGroupBtn.Enabled = True
            btnEditGroup.Enabled = True
            btnDeleteGroup.Enabled = True
            If viewMode = ViewModes.Editor Then
                btnSetGroup.Enabled = True
            Else
                btnSetGroup.Enabled = False
            End If
        End If
        If CurrentSession.length > 0 Then
            filtermenubtn.Enabled = True
        Else
            filtermenubtn.Enabled = False
        End If
    End Sub

    Private Sub filterbygroup(sender As ToolStripMenuItem, e As EventArgs)
        If Integer.TryParse(sender.Text.Split(" - ").FirstOrDefault, 0) Then
            filtroGruppo = Integer.Parse(sender.Text.Split(" - ").FirstOrDefault)
            filtro = Efiltro.SpecificGroup
            Ricalcola()
            TranslationPercentageBox1.SelectedPercentage = TranslationPercentageBox.Percentage.Other
        End If
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TranslationPercentageBox1.ClickOnResetButton
        If viewMode = ViewModes.Editor And filtro <> Efiltro.Default_mode Then
            filtro = Efiltro.Default_mode
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Private Sub NotTranslatedStringsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TranslationPercentageBox1.ClickOnRightValue
        If viewMode = ViewModes.Editor And filtro <> Efiltro.NotTranslated Then
            filtro = Efiltro.NotTranslated
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Private Sub stringsPnl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stringsPnl.KeyPress
        If Not Char.IsControl(e.KeyChar) Then
            TextBox1.Focus()
            TextBox1.AppendText(e.KeyChar)
        End If
    End Sub

    Private Sub ShowSymbolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSymbolsToolStripMenuItem.Click
        My.Settings.dofiltertext = Not My.Settings.dofiltertext
        My.Settings.Save()
        ShowSymbolsToolStripMenuItem.Checked = Not My.Settings.dofiltertext
        stringsPnl.Invalidate()
    End Sub

    Private Sub CompareTranslationFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompareTranslationFilesToolStripMenuItem.Click
        Dim f As New frmCompare
        f.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Timer1.Enabled = False
        If stringsPnl.SelectedItems.Count > 0 Then
            Dim index As Integer = CurrentSession.getIndex(stringsPnl.SelectedItems(0))
            Dim linea As LineDouble = CurrentSession.getLine(index)
            TextBox1.Text = FilterText(linea.originalText, True, False)
            Dim testooriginale As String = linea.originalText
            CurrentSession.listViewObjects(index).SubItems(2).Text = testooriginale
            CurrentSession.lines(index).translatedText = testooriginale
            stringsPnl.SelectedItems(0).SubItems(2).Text = FilterText(linea.originalText, True, True)
            If stringsPnl.SelectedItems(0).SubItems(1).Text <> testooriginale Then
                CurrentSession.listViewObjects(index).BackColor = Color.LightGreen
                stringsPnl.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + fileNameTitle + " *"
                SaveToolStripMenuItem.Enabled = True
            Else
                ResetBtn.Visible = False
                CurrentSession.listViewObjects(index).BackColor = Color.LightSalmon
                stringsPnl.SelectedItems(0).BackColor = Color.LightSalmon
                saved = False
                Me.Text = "TranslaTale - " + fileNameTitle + " *"
                SaveToolStripMenuItem.Enabled = True
            End If
        Else
            TextBox1.Enabled = False
            TextBox1.Text = ""
            showText(TextBox1.Text)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) 'Handles MyBase.Shown

        'MY UPDATE CHECK. NOW IT'S DISABLED
        Using b As New Net.WebClient
            Try
                Dim newversion As String() = b.DownloadString("http://gdb.altervista.org/dev/translatalex.version").Split(".") 'UPDATE CHECK
                Dim oldversion As String() = My.Application.Info.Version.ToString.Split(".")
                Dim aggiornato As Boolean = True

                If (newversion(0) > oldversion(0)) Then
                    aggiornato = False
                ElseIf (newversion(0) = oldversion(0)) Then
                    If (newversion(1) > oldversion(1)) Then
                        aggiornato = False
                    ElseIf (newversion(0) = oldversion(0)) Then
                        If (newversion(2) > oldversion(2)) Then
                            aggiornato = False
                        ElseIf (newversion(0) = oldversion(0)) Then
                            If (newversion(3) > oldversion(3)) Then
                                aggiornato = False
                            Else
                                aggiornato = True
                            End If
                        Else
                            aggiornato = True
                        End If
                    Else
                        aggiornato = True
                    End If
                Else
                    aggiornato = True
                End If
                If aggiornato = False Then
                    MsgBox("Questo programma non è aggiornato. Scarica subito la nuova versione!", MsgBoxStyle.Exclamation)
                    Process.Start("http://gdb.altervista.org/dev/ut/")
                End If
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Private Sub UndertalePatchToolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndertalePatchToolToolStripMenuItem.Click
        Dim filename As String
        Try
            If Not Directory.Exists(Application.StartupPath & "\bin") Then
                Directory.CreateDirectory(Application.StartupPath & "\bin")
            End If
            If Not Directory.Exists(Application.StartupPath & "\res") Then
                Directory.CreateDirectory(Application.StartupPath & "\res")
            End If
            filename = Application.StartupPath + "\xdelta.exe"
            System.IO.File.WriteAllBytes(filename, My.Resources.xdelta)
            filename = Application.StartupPath + "\main.bin"
            System.IO.File.WriteAllBytes(filename, My.Resources.UndertalePatchTool)
            filename = Application.StartupPath + "\UndertalePatchTool.bat"
            System.IO.File.WriteAllBytes(filename, My.Resources.UndertalePatchToolbat)

            filename = Application.StartupPath + "\UndertalePatchTool.bat"
            Dim p As New ProcessStartInfo
            p.FileName = filename
            p.Arguments = ""
            Dim unpackStringsProc As Process
            unpackStringsProc = Process.Start(p)
        Catch ex As IOException
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub stringsPnl_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles stringsPnl.ColumnWidthChanging
        e.Cancel = True
        e.NewWidth = stringsPnl.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As MouseEventArgs) Handles OptionsToolStripMenuItem.MouseDown

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs)
        TextBox1.Focus()
    End Sub

    <Obsolete("Obsolete! ")>
    Private Sub addGroupButton_Click(sender As Object, e As EventArgs)
        Dim nome As String = InputBox("Inserisci il nome del gruppo", "Aggiungi un gruppo", "default")
        If nome = "" Then
            Return
        End If
        Dim numero As Integer = 0
        For Each gruppo In CurrentSession.groups
            If gruppo.Value.numero > numero Then
                numero = gruppo.Value.numero
            End If
        Next
        numero += 1
        CurrentSession.groups.Add(numero, New Group(numero, nome))
    End Sub

    Private Sub btnSetGroup_Click(sender As Object, e As EventArgs) Handles btnSetGroup.Click
        Dim frm As New frmSelectGroup
        Dim number = frm.Popup(True)
        If number <> -2 Then
            For Each itm As ListViewItem In stringsPnl.SelectedItems
                CurrentSession.lines(CurrentSession.getIndex(itm)).group = number
            Next
            stringsPnl.Invalidate()
        End If
        RicalcolaGruppi()
        saved = False
    End Sub

    Private Sub AggiungiGruppoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnCreateGroup.Click
        Dim frm As New frmCreateGroup
        Dim gr As Group = frm.Popup()
        If Not IsNothing(gr) Then
            CurrentSession.groups.Add(gr.numero, gr)
        End If
        RicalcolaGruppi()
        saved = False
    End Sub

    Private Sub btnDeleteGroup_Click(sender As Object, e As EventArgs) Handles btnDeleteGroup.Click
        Dim frm As New frmSelectGroup
        Dim number = frm.Popup(False, "&Delete")
        If number <> -2 And number <> -1 Then
            For Each itm In CurrentSession.lines
                If itm.Value.group = number Then
                    itm.Value.group = -1
                End If
            Next
            CurrentSession.groups.Remove(number)
        End If
        RicalcolaGruppi()
        saved = False
    End Sub

    Private Sub TranslatedStringsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TranslatedStringsToolStripMenuItem.Click
        TranslatedStringsToolStripMenuItem_Click(sender, e)
        TranslationPercentageBox1.SelectedPercentage = TranslationPercentageBox.Percentage.Left
    End Sub

    Private Sub UntranslatedStringsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UntranslatedStringsToolStripMenuItem.Click
        NotTranslatedStringsToolStripMenuItem_Click(sender, e)
        TranslationPercentageBox1.SelectedPercentage = TranslationPercentageBox.Percentage.Right
    End Sub

    Private Sub ClearFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFilterToolStripMenuItem.Click
        AllToolStripMenuItem_Click(sender, e)
        TranslationPercentageBox1.SelectedPercentage = TranslationPercentageBox.Percentage.All
    End Sub

    Private Sub btnEditGroup_Click(sender As Object, e As EventArgs) Handles btnEditGroup.Click
        Dim frm As New frmSelectGroup()
        Dim number = frm.Popup(False)
        If number = -2 Then
            Return
        End If
        If number = -1 Then
            MsgBox("You can't modify Default group!", MsgBoxStyle.Critical)
            Return
        End If

        If Not CurrentSession.groups.ContainsKey(number) Then
            MsgBox("This group doesn't exists!" & vbCrLf & "You must create a group before modifying it!", MsgBoxStyle.Critical)
            Return
        End If
        Dim frm2 As New frmCreateGroup()
        Dim gruppomod As Group = frm2.Popup("Edit group", CurrentSession.groups(number), "&Cancel", "&Edit")
        If Not IsNothing(gruppomod) Then
            CurrentSession.groups(number) = gruppomod
            RicalcolaGruppi()
            stringsPnl.Invalidate()
        End If
        saved = False
    End Sub

    Private Sub MigrationToolToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmStringsConverter.ShowDialog()
    End Sub

    Private Sub DumpStringstxtToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DumpStringstxtToolStripMenuItem.Click
        Dim winPath As String
        Dim outputStringsPath As String
        Dim tempTXTStringsPath As String
        Dim sPath As String
        Dim unpackStringsProc As Process

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        SaveFileDialog2.Filter = "TranslaTale file|*.ttx"
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            outputStringsPath = SaveFileDialog2.FileName
        Else
            Exit Sub
        End If

        Dim filename As String = Application.StartupPath + "\WinExtract.exe"
        System.IO.File.WriteAllBytes(filename, My.Resources.WinExtract)

        Dim tmpPath As String = GetTempFolder(True)
        tempTXTStringsPath = tmpPath & "\tmp_strings.txt"
        Dim p As New ProcessStartInfo
        p.FileName = filename
        p.Arguments = """" & winPath & """ """ & tmpPath & """"
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

        File.Copy(tmpPath & "\STRG.txt", tempTXTStringsPath, True)

        Dim ttx2 As New TranslataleFile()
        Dim sr2 As New System.IO.StreamReader(tempTXTStringsPath)
        Dim translatedStrings As String() = File.ReadAllLines(tempTXTStringsPath)
        ttx2.SetLines(translatedStrings, translatedStrings)
        sr2.Close()

        ttx2.Save(outputStringsPath)

        ttx2 = Nothing

        System.IO.Directory.Delete(tmpPath, True)

        MsgBox("Process finished", vbInformation)

        sPath = StrReverse(SaveFileDialog2.FileName)
        sPath = Mid(sPath, InStr(sPath, "\"), Len(sPath))
        sPath = StrReverse(sPath)
        Process.Start(sPath)
    End Sub

    Private Sub RepackGamecustomFontsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepackGamecustomFontsToolStripMenuItem.Click
        frmFontImporter.ShowDialog(True)
    End Sub

    Private Sub RepackGameASCIICharactersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepackGameASCIICharactersToolStripMenuItem.Click
        frmFontImporter.ShowDialog(False)
    End Sub

    Private Sub MigrationToolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MigrationToolToolStripMenuItem.Click
        Dim frm As New frmStringsConverter()
        frm.ShowDialog()
    End Sub

    Private Sub SpriteFontBox1_Click(sender As Object, e As EventArgs) Handles SpriteFontBox1.GotFocus
        TextBox1.Focus()
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStrip1.MouseEnter
        ttipMenu.Location = New Point(PointToClient(MousePosition).X, ttipMenu.Location.Y)
        ttipMenu.Visible = True
        ttipMenu.Text = ""
    End Sub

    Private Sub ToolStrip1_MouseLeave(sender As Object, e As EventArgs) Handles ToolStrip1.MouseLeave
        ttipMenu.Visible = False
    End Sub

    Private Sub ToolStrip1_ItemAdded(sender As Object, e As System.Windows.Forms.ToolStripItemEventArgs) Handles ToolStrip1.ItemAdded
        AddHandler e.Item.MouseEnter, AddressOf ToolStrip1_MouseMove
    End Sub

    Private Sub ToolStrip1_ControlAdded(sender As Object, e As System.Windows.Forms.ControlEventArgs) Handles ToolStrip1.ControlAdded
        AddHandler e.Control.MouseEnter, AddressOf ToolStrip1_MouseMove
    End Sub

    Private Sub ToolStrip1_MouseMove(sender As Object, e As EventArgs)
        If sender.Name = ToolStrip1.Name Then
            ttipMenu.Text = ""
        ElseIf Not IsNothing(TryCast(sender, ToolStripItem)) Then
            ttipMenu.Text = DirectCast(sender, ToolStripItem).ToolTipText
        ElseIf Not IsNothing(TryCast(sender, ToolStripButton)) Then
            ttipMenu.Text = DirectCast(sender, ToolStripButton).ToolTipText
        End If
    End Sub

    Private Sub newProjectBtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles newProjectBtn.LinkClicked
        newProjectToolStripBtn.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles projectManagerToolBtn.Click
        viewMode = ViewModes.ProjectManager
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles stringsEditorToolBtn.Click
        viewMode = ViewModes.Editor
    End Sub

    Private Sub compareMainBtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles compareMainBtn.LinkClicked
        Dim f As New frmCompare
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles migrationToolBtn.LinkClicked
        Dim frm As New frmStringsConverter()
        frm.ShowDialog()
    End Sub

    Private Sub infoBtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles infoBtn.LinkClicked
        AboutBox1.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim strings As String() = readStringsTXT("Open original Strings.txt file")
        If Not IsNothing(strings) Then
            Dim stringsN As Integer = 0
            For x As Integer = 0 To strings.Length - 1 Step 1
                If CurrentSession.lines.ContainsKey(x) Then
                    CurrentSession.lines(x).originalText = strings(x)
                Else
                    CurrentSession.lines.Add(x, New LineDouble(strings(x), vbNullString))
                End If
                stringsN = x
            Next
            CurrentSession.ComputeListViewLines()
            Ricalcola()
            saved = False
            MsgBox("Done! Imported " & stringsN & " strings!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim strings As String() = readStringsTXT("Open translated Strings.txt file")
        If Not IsNothing(strings) Then
            Dim stringsN As Integer = 0
            For x As Integer = 0 To strings.Length - 1 Step 1
                If CurrentSession.lines.ContainsKey(x) Then
                    CurrentSession.lines(x).translatedText = strings(x)
                Else
                    CurrentSession.lines.Add(x, New LineDouble(vbNullString, strings(x)))
                End If
                stringsN = x
            Next
            CurrentSession.ComputeListViewLines()
            Ricalcola()
            saved = False
            MsgBox("Done! Imported " & stringsN & " strings!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        viewMode = ViewModes.Editor
    End Sub

    Private Sub newProjectToolStripBtn_Click(sender As Object, e As EventArgs) Handles newProjectToolStripBtn.Click
        SaveFileDialog1.Title = "Create a new project"
        SaveFileDialog1.Filter = "TranslaTale file|*.ttx"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            viewMode = ViewModes.Default
            CurrentSession.clear()
            saved = SaveTTX(SaveFileDialog1.FileName)
            If saved = False Then
                MsgBox("Error during project creation!" & vbCrLf & "Please, retry.", MsgBoxStyle.Critical, "TranslaTale")
                Exit Sub
            End If
            LoadTTX(SaveFileDialog1.FileName)
        End If
    End Sub
End Class

Public Class NativeMethods

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(handle As IntPtr, messg As Integer, wparam As IntPtr, lparam As IntPtr) As IntPtr
    End Function

    Public Function SendMessageFunction(handle As IntPtr, messg As Integer, wparam As IntPtr, lparam As IntPtr) As IntPtr
        Return SendMessage(handle, messg, wparam, lparam)
    End Function
End Class