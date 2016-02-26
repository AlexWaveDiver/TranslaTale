Imports System.Collections.Specialized
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports NBT.IO
Imports NBT.Tags
Imports TranslaTale.UTSpriteFontBox

Public Class frmMain
    Dim actualColor As String = "white"
    Dim lastClicked As Integer = 0
    Dim opened As Boolean = True
    Public saved As Boolean = True
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

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles stringTextEditor.KeyUp
        Timer1.Enabled = False
        If stringsPnl.SelectedItems.Count > 0 Then
            Dim index As Integer = CurrentSession.getIndex(stringsPnl.SelectedItems(0))
            Dim linea As LineDouble = CurrentSession.getLine(index)
            CurrentSession.listViewObjects(index).SubItems(2).Text = stringTextEditor.Text
            CurrentSession.lines(index).translatedText = stringTextEditor.Text
            stringsPnl.SelectedItems(0).SubItems(2).Text = stringTextEditor.Text
            If stringsPnl.SelectedItems(0).SubItems(1).Text <> stringTextEditor.Text Then
                CurrentSession.listViewObjects(index).BackColor = Color.LightGreen
                stringsPnl.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + CurrentSession.projectName + " *"
                SaveToolStripMenuItem.Enabled = True
                ResetBtn.Visible = True
            Else
                CurrentSession.listViewObjects(index).BackColor = Color.LightSalmon
                stringsPnl.SelectedItems(0).BackColor = Color.LightSalmon
                ResetBtn.Visible = False
            End If
        Else
            stringTextEditor.Enabled = False
            stringTextEditor.Text = ""
            showText(stringTextEditor.Text)
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
            If value = ViewModes.EditorStrings Then
                projectmanagerPnl.Visible = False
                spritesPnl.Visible = False
                welcomePnl.Visible = False
                tblEditor.Visible = True

                tblEditor.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = False

                topPnl.Visible = True
                bottomPnl.Visible = True

                stringsPnl.Enabled = True
                stringTextEditor.Enabled = True
                SaveToolStripMenuItem.Enabled = True
                searchToolStripBtn.Enabled = True
                RepackGameASCIICharactersToolStripMenuItem.Enabled = True
                RepackGamecustomFontsToolStripMenuItem.Enabled = True
                goToLineToolStripBtn.Enabled = True
                pnlGroups.Enabled = True
                btnSetGroup.Enabled = True
                TranslationPercentageBox1.Enabled = True
                projectManagerToolBtn.Enabled = True
                stringsEditorToolBtn.Enabled = False
                spritesEditorToolBtn.Enabled = True

                With stringsPnl
                    .Columns(0).Width = 65
                    .Columns(1).Width = CInt((.Width - 65) * 0.45)
                    .Columns(2).Width = CInt((.Width - 65) * 0.5)
                End With
                stringsPnl.Focus()
                RicalcolaGruppi()
                updateComponents()
            ElseIf value = ViewModes.ProjectManager Then
                tblEditor.Visible = False
                spritesPnl.Visible = False
                welcomePnl.Visible = False
                projectmanagerPnl.Visible = True
                projectmanagerPnl.Focus()

                Label9.Text = CurrentSession.projectName

                projectmanagerPnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = False

                topPnl.Visible = True
                bottomPnl.Visible = False


                stringTextEditor.Enabled = False
                SaveToolStripMenuItem.Enabled = True
                searchToolStripBtn.Enabled = False
                RepackGameASCIICharactersToolStripMenuItem.Enabled = True
                RepackGamecustomFontsToolStripMenuItem.Enabled = True
                goToLineToolStripBtn.Enabled = False
                filtermenubtn.Enabled = False
                pnlGroups.Enabled = True
                btnSetGroup.Enabled = False
                TranslationPercentageBox1.Enabled = False
                showText("")
                stringTextEditor.Text = ""
                projectManagerToolBtn.Enabled = False
                stringsEditorToolBtn.Enabled = True
                spritesEditorToolBtn.Enabled = True
                updateComponents()
            ElseIf value = ViewModes.EditorSprites Then
                tblEditor.Visible = False
                welcomePnl.Visible = False
                projectmanagerPnl.Visible = False
                spritesPnl.Visible = True
                spritesPnl.Focus()

                spritesPnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = False

                topPnl.Visible = True
                bottomPnl.Visible = False

                stringTextEditor.Enabled = False
                SaveToolStripMenuItem.Enabled = True
                searchToolStripBtn.Enabled = False
                RepackGameASCIICharactersToolStripMenuItem.Enabled = True
                RepackGamecustomFontsToolStripMenuItem.Enabled = True
                goToLineToolStripBtn.Enabled = False
                filtermenubtn.Enabled = False
                pnlGroups.Enabled = False
                btnSetGroup.Enabled = False
                TranslationPercentageBox1.Enabled = False
                showText("")
                stringTextEditor.Text = ""
                projectManagerToolBtn.Enabled = True
                stringsEditorToolBtn.Enabled = True
                spritesEditorToolBtn.Enabled = False
                updateComponents()
                updateSpritesPanel()
            ElseIf value = ViewModes.Default Then
                tblEditor.Visible = False
                spritesPnl.Visible = False
                projectmanagerPnl.Visible = False
                welcomePnl.Visible = True
                welcomePnl.Focus()

                welcomePnl.Dock = DockStyle.Fill
                splitMain.Panel2Collapsed = True

                topPnl.Visible = False
                bottomPnl.Visible = False

                'Update history
                historyListView.Items.Clear()
                If Not IsNothing(My.Settings.filesHistory) Then
                    For Each current As String In My.Settings.filesHistory
                        Dim lwi As ListViewItem = New ListViewItem(current.Split("|").LastOrDefault & " (" & current.Split("|").FirstOrDefault & ")")
                        lwi.ImageIndex = 0
                        lwi.Tag = current.Split("|").FirstOrDefault
                        historyListView.Items.Add(lwi)
                    Next
                End If
                'End update history


                SaveToolStripMenuItem.Enabled = False
                searchToolStripBtn.Enabled = False
                RepackGameASCIICharactersToolStripMenuItem.Enabled = False
                RepackGamecustomFontsToolStripMenuItem.Enabled = False
                goToLineToolStripBtn.Enabled = False
                filtermenubtn.Enabled = False
                pnlGroups.Enabled = False
                btnSetGroup.Enabled = False
                TranslationPercentageBox1.Enabled = False
                showText("")
                stringTextEditor.Text = ""
                projectManagerToolBtn.Enabled = False
                stringsEditorToolBtn.Enabled = False
                spritesEditorToolBtn.Enabled = False
            End If
            _viewMode = value
        End Set
    End Property

    Private Sub updateSpritesPanel()
        spritesListView.Items.Clear()
        spritesImageList.Images.Clear()
        For Each sprite In CurrentSession.sprites
            Dim li As New ListViewItem()
            li.Text = sprite.fileName
            li.Tag = sprite.fileName
            spritesImageList.Images.Add(li.Text, Image.FromStream(New MemoryStream(sprite.content)))
            li.ImageKey = li.Text
            spritesListView.Items.Add(li)
        Next
    End Sub

    Public Enum ViewModes
        EditorStrings
        ProjectManager
        EditorSprites
        [Default]
    End Enum

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles openProjectBtn.LinkClicked
        LoadTTXPopup()
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim res = SaveTTXDialogAsk()
        If res = SaveResultAsk.YES Or res = SaveResultAsk.No Or res = SaveResultAsk.AlreadySaved Then
        Else
            e.Cancel = True
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

    Dim manualframechange As Boolean = True
    Public Function showText(ByVal txt As String)
        manualframechange = False
        frameTrackBar.Minimum = 0
        Dim val As Integer = frameTrackBar.Value
        frameTrackBar.Maximum = SpriteFont.CountFrames(txt) - 1
        If val <= frameTrackBar.Maximum Then
            frameTrackBar.Value = val
        End If
        If frameTrackBar.Maximum = frameTrackBar.Minimum Then
            frameTrackBar.Visible = False
            Label5.Visible = False
            startAnimationBtn.Visible = False
        Else
            frameTrackBar.Visible = True
            Label5.Visible = True
            startAnimationBtn.Visible = True
        End If
        SpriteFontBox1.Text = txt
        SpriteFontBox1.Frame = frameTrackBar.Value
        manualframechange = True
        Return True
    End Function

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub stringsPnl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles stringsPnl.SelectedIndexChanged
        If stringsPnl.SelectedItems.Count > 0 Then
            If stringsPnl.SelectedItems(0) IsNot Nothing Then
                Dim val As String = stringsPnl.SelectedItems(0).SubItems(2).Text
                stringTextEditor.Enabled = True
                stringTextEditor.Text = FilterText(val, True, False)
                If stringsPnl.SelectedItems(0).SubItems(1).Text <> stringsPnl.SelectedItems(0).SubItems(2).Text Then
                    ResetBtn.Visible = True
                Else
                    ResetBtn.Visible = False
                End If
                showText(val)
            Else
                stringTextEditor.Enabled = False
                stringTextEditor.Text = ""
                ResetBtn.Visible = False
                showText(stringTextEditor.Text)
            End If
        Else
            stringTextEditor.Enabled = False
            stringTextEditor.Text = ""
            ResetBtn.Visible = False
            showText(stringTextEditor.Text)
        End If

        aniTime.Stop()
        startAnimationBtn.ImageIndex = 0
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveTTXDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openProjectBtn2.ButtonClick
        LoadTTXPopup()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles goToLineToolStripBtn.Click
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
                Me.stringTextEditor.Text = FilterText(val, True, False)
                Return
            End If
        End If

        If line <> -1 Then
            MsgBox("Line " + line.ToString + " not found", vbInformation)
            goToLineToolStripBtn.PerformClick()
        End If
    End Sub

    Private Sub cbFonts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFonts.SelectedIndexChanged
        If stringsPnl.SelectedItems.Count > 0 Then
            SpriteFontBox1.CurrentSpriteFont = DirectCast([Enum].Parse(GetType(UTSpriteFontBox.SpriteFontBox.SpriteFonts), cbFonts.SelectedItem), UTSpriteFontBox.SpriteFontBox.SpriteFonts)
            If stringsPnl.SelectedItems(0) IsNot Nothing Then
                Dim val As String = stringsPnl.SelectedItems(0).SubItems(2).Text
                stringTextEditor.Text = FilterText(val, True, False)
                showText(val)
            End If
        End If
    End Sub

    Private Sub DumpOriginalImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DumpOriginalImagesToolStripMenuItem.Click
        Dim winPath As String
        Dim imgPath As String

        Dim fld As New FolderSelect.FolderSelectDialog

        OpenFileDialog2.Filter = "data.win|*.win"
        OpenFileDialog2.Title = "Select data.win"

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            winPath = OpenFileDialog2.FileName
        Else
            Exit Sub
        End If

        fld.Title = "Choose an extraction location"
        If fld.ShowDialog Then
            imgPath = fld.FileName
            If Not Directory.Exists(imgPath) Then
                MsgBox("Directory doesn't exists!", MsgBoxStyle.Exclamation, "TranslaTale")
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        If extractSpritesFromWIN(File.ReadAllBytes(winPath), imgPath) = ExtractionResult.OK Then
            MsgBox("Process finished", vbInformation)
        Else
            MsgBox("Extraction failed!", vbCritical)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        showText(stringTextEditor.Text)
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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchToolStripBtn.Click
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
        If viewMode = ViewModes.EditorStrings And filtro <> Efiltro.Translated Then
            filtro = Efiltro.Translated
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Public Sub Ricalcola()
        Me.Enabled = False
        stringTextEditor.Enabled = False
        stringTextEditor.Text = ""
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
            If viewMode = ViewModes.EditorStrings Then
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
        If viewMode = ViewModes.EditorStrings And filtro <> Efiltro.Default_mode Then
            filtro = Efiltro.Default_mode
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Private Sub NotTranslatedStringsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TranslationPercentageBox1.ClickOnRightValue
        If viewMode = ViewModes.EditorStrings And filtro <> Efiltro.NotTranslated Then
            filtro = Efiltro.NotTranslated
            filtroGruppo = -1
            Ricalcola()
        End If
    End Sub

    Private Sub stringsPnl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stringsPnl.KeyPress
        If Not Char.IsControl(e.KeyChar) Then
            stringTextEditor.Focus()
            stringTextEditor.AppendText(e.KeyChar)
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
            stringTextEditor.Text = FilterText(linea.originalText, True, False)
            Dim testooriginale As String = linea.originalText
            CurrentSession.listViewObjects(index).SubItems(2).Text = testooriginale
            CurrentSession.lines(index).translatedText = testooriginale
            stringsPnl.SelectedItems(0).SubItems(2).Text = FilterText(linea.originalText, True, True)
            If stringsPnl.SelectedItems(0).SubItems(1).Text <> testooriginale Then
                CurrentSession.listViewObjects(index).BackColor = Color.LightGreen
                stringsPnl.SelectedItems(0).BackColor = Color.LightGreen
                saved = False
                Me.Text = "TranslaTale - " + CurrentSession.projectName + " *"
                SaveToolStripMenuItem.Enabled = True
            Else
                ResetBtn.Visible = False
                CurrentSession.listViewObjects(index).BackColor = Color.LightSalmon
                stringsPnl.SelectedItems(0).BackColor = Color.LightSalmon
                saved = False
                Me.Text = "TranslaTale - " + CurrentSession.projectName + " *"
                SaveToolStripMenuItem.Enabled = True
            End If
        Else
            stringTextEditor.Enabled = False
            stringTextEditor.Text = ""
            showText(stringTextEditor.Text)
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
        stringTextEditor.Focus()
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
        Dim outputStringsPath As String

        SaveFileDialog2.Filter = "TranslaTale file|*.txt"
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            outputStringsPath = SaveFileDialog2.FileName
        Else
            Exit Sub
        End If

        extractStringsFromWIN(CurrentSession.undertaleWIN, outputStringsPath)

        MsgBox("Process finished", vbInformation)

        'Open extraction folder
        Dim sPath As String = StrReverse(SaveFileDialog2.FileName)
        sPath = Mid(sPath, InStr(sPath, "\"), Len(sPath))
        sPath = StrReverse(sPath)
        Process.Start(sPath)
    End Sub

    Private Sub RepackGamecustomFontsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepackGamecustomFontsToolStripMenuItem.Click
        frmGameCompiler.ShowDialog(True)
    End Sub

    Private Sub RepackGameASCIICharactersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepackGameASCIICharactersToolStripMenuItem.Click
        frmGameCompiler.ShowDialog(False)
    End Sub

    Private Sub MigrationToolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MigrationToolToolStripMenuItem.Click
        Dim frm As New frmStringsConverter()
        frm.ShowDialog()
    End Sub

    Private Sub SpriteFontBox1_Click(sender As Object, e As EventArgs) Handles SpriteFontBox1.GotFocus
        stringTextEditor.Focus()
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStrip1.MouseEnter
        ttipMenu.Location = New Point(PointToClient(MousePosition).X, ttipMenu.Location.Y)
        ttipMenu.Visible = True
        ttipMenu.Text = ""
    End Sub

    Private Sub ToolStrip1_MouseLeave(sender As Object, e As EventArgs) Handles ToolStrip1.MouseLeave
        ttipMenu.Visible = False
    End Sub

    Private Sub ToolStrip1_ItemAdded(sender As Object, e As ToolStripItemEventArgs) Handles ToolStrip1.ItemAdded
        AddHandler e.Item.MouseEnter, AddressOf ToolStrip1_MouseMove
    End Sub

    Private Sub ToolStrip1_ControlAdded(sender As Object, e As ControlEventArgs) Handles ToolStrip1.ControlAdded
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
        viewMode = ViewModes.EditorStrings
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
        CurrentSession.ChangeStringsFile(strings, True)
        If Not IsNothing(strings) Then
            MsgBox("Done! Imported the strings!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim strings As String() = readStringsTXT("Open translated Strings.txt file")
        CurrentSession.ChangeStringsFile(strings, False)
        If Not IsNothing(strings) Then
            MsgBox("Done! Imported the strings!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        viewMode = ViewModes.EditorStrings
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

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles componentsList.SelectedIndexChanged
        componentsList.SelectedItems.Clear()
    End Sub


    Public Sub updateComponents()
        Dim candebug As Boolean = True
        For Each itm As ListViewItem In componentsList.Items
            Select Case itm.Tag
                Case "Original"
                    If CurrentSession.areOriginalStringsEmpty() Then
                        itm.ImageIndex = 0
                    Else
                        itm.ImageIndex = 1
                    End If
                Case "Translated"
                    If CurrentSession.areTranslatedStringsEmpty() Then
                        itm.ImageIndex = 0
                    Else
                        itm.ImageIndex = 1
                    End If
                Case "Sprites"
                    If CurrentSession.sprites.Count <= 0 Then
                        itm.ImageIndex = 0
                    Else
                        Try
                            Dim maxnumb As Integer = 0
                            For Each img In CurrentSession.sprites
                                If Integer.Parse(Path.GetFileNameWithoutExtension(img.fileName)) > maxnumb Then
                                    maxnumb = Integer.Parse(Path.GetFileNameWithoutExtension(img.fileName))
                                End If
                            Next
                            If maxnumb = CurrentSession.sprites.Count - 1 Then
                                itm.ImageIndex = 1
                            Else
                                itm.ImageIndex = 2
                                candebug = False
                            End If
                        Catch ex As Exception
                            itm.ImageIndex = 2
                            candebug = False
                        End Try
                    End If
                Case "Undertale"
                    If CurrentSession.undertaleEXE.Count <= 10 Then
                        itm.ImageIndex = 0
                        useDefaultSpritesBtn.Enabled = False
                        useDefaultStringsBtn.Enabled = False
                        PictureBox13.Enabled = False
                        PictureBox15.Enabled = False
                        debugToolBtn.Enabled = False
                        candebug = False
                    Else
                        itm.ImageIndex = 1
                        useDefaultSpritesBtn.Enabled = True
                        useDefaultStringsBtn.Enabled = True
                        PictureBox13.Enabled = True
                        PictureBox15.Enabled = True
                    End If
                Case "data.win"
                    If CurrentSession.undertaleWIN.Count <= 10 Then
                        itm.ImageIndex = 0
                        useDefaultSpritesBtn.Enabled = False
                        useDefaultStringsBtn.Enabled = False
                        PictureBox13.Enabled = False
                        PictureBox15.Enabled = False
                        FromUndertaleToolStripMenuItem.Enabled = False
                        DumpOriginalImagesToolStripMenuItem.Enabled = False
                        DumpStringstxtToolStripMenuItem.Enabled = False
                    Else
                        itm.ImageIndex = 1
                        useDefaultSpritesBtn.Enabled = True
                        useDefaultStringsBtn.Enabled = True
                        PictureBox13.Enabled = True
                        PictureBox15.Enabled = True
                        FromUndertaleToolStripMenuItem.Enabled = True
                        DumpOriginalImagesToolStripMenuItem.Enabled = True
                        DumpStringstxtToolStripMenuItem.Enabled = True
                    End If
            End Select
        Next

        If candebug Then
            debugToolBtn.Enabled = True
        Else
            debugToolBtn.Enabled = False
        End If

        If CurrentSession.isProjectFile And CurrentSession.projectPath <> "" Then
            QSaveToolStripMenuItem.Enabled = True
        Else
            QSaveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim datawinpath As String
        Dim datawin As Byte()
        Dim exemode As Boolean = False
        Dim tf As String = GetTempFolder()
        OpenFileDialog1.Filter = "data.win or Undertale.exe (Not translated)|*.exe;*.win|Undertale.exe (Not translated)|*.exe|data.win (Not translated)|*.win"
        OpenFileDialog1.Title = "Import Undertale"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            If Path.GetExtension(OpenFileDialog1.FileName) = ".exe" Then
                exemode = True
                Dim ut As Byte() = File.ReadAllBytes(OpenFileDialog1.FileName)
                CurrentSession.undertaleEXE = ut
                Select Case ExtractUndertaleEXE(ut, tf, "TempUT.exe")
                    Case ExtractionResult.OK
                        datawinpath = Path.Combine(tf, "data.win")
                    Case ExtractionResult.CantExtract
                        MsgBox("This is not an Undertale.exe copy!", vbCritical)
                        Exit Sub
                    Case ExtractionResult.Problematic
                        MsgBox("This file doesn't contains data.win! It can't be Undertale.exe", vbCritical)
                        Exit Sub
                    Case ExtractionResult.EmptyFile
                        MsgBox("This file is empty! It can't be Undertale.exe", vbCritical)
                        Exit Sub
                    Case Else
                        MsgBox("Unexpected problem during the extraction!", vbCritical)
                        Exit Sub
                End Select
            Else
                datawinpath = OpenFileDialog1.FileName
            End If

            datawin = File.ReadAllBytes(datawinpath)

            If exemode Then
                Directory.Delete(tf, True)
            End If

            CurrentSession.undertaleWIN = datawin
            updateComponents()
            MsgBox("Done!", vbInformation)
        End If

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As EventArgs) Handles LinkLabel4.LinkClicked, ChooseSpritesToolStripMenuItem.Click
        OpenFileDialogMulti.Title = "Import Undertale sprites"
        OpenFileDialogMulti.Filter = "Sprites|*.png"
        If OpenFileDialogMulti.ShowDialog = DialogResult.OK Then
            importSprites(OpenFileDialogMulti.FileNames, False, True)
        End If
        updateSpritesPanel()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As EventArgs) Handles LinkLabel5.LinkClicked, FromFolderToolStripMenuItem.Click
        Dim opendir As New FolderSelect.FolderSelectDialog
        opendir.Title = "Import Undertale sprites"
        If opendir.ShowDialog = True Then
            importSprites(Directory.GetFiles(opendir.FileName, "*.png", SearchOption.TopDirectoryOnly), False, True)
        End If
        updateSpritesPanel()
    End Sub

    Private Sub useDefaultStringsBtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles useDefaultStringsBtn.LinkClicked
        If MsgBox("Would you want to overwrite ALL the original strings side?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "TranslaTale > WARNING!") = MsgBoxResult.Yes Then
            Dim outputStringsPath As String = GetTempFolder(True)
            extractStringsFromWIN(CurrentSession.undertaleWIN, Path.Combine(outputStringsPath, "DefaultStrings.txt"))

            Dim strings As String() = File.ReadAllLines(Path.Combine(outputStringsPath, "DefaultStrings.txt"))

            Directory.Delete(outputStringsPath, True)

            CurrentSession.ChangeStringsFile(strings, True)
            If Not IsNothing(strings) Then
                MsgBox("Done! Imported the strings!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub openProjectBtn2_DropDownOpening(sender As Object, e As EventArgs) Handles openProjectBtn2.DropDownOpening
        sender.DropDown.Items.Clear()
        Dim toolStripMenuItem As ToolStripMenuItem = New ToolStripMenuItem() With
            {
                .Enabled = False,
                .Text = "History"
            }
        sender.DropDown.Items.Add(toolStripMenuItem)
        sender.DropDown.Items.Add(New ToolStripSeparator())

        For Each current As String In My.Settings.filesHistory
            Dim toolStripMenuItem1 As ToolStripMenuItem = New ToolStripMenuItem() With
            {
                 .Text = current.Split("|").LastOrDefault & " (" & current.Split("|").FirstOrDefault & ")",
                 .ImageScaling = ToolStripItemImageScaling.None,
                 .Image = My.Resources.time,
                 .Tag = current.Split("|").FirstOrDefault
            }
            AddHandler toolStripMenuItem1.Click, AddressOf Me.historyOpen
            sender.DropDown.Items.Add(toolStripMenuItem1)
        Next
    End Sub

    Private Sub historyOpen(sender As ToolStripMenuItem, e As EventArgs)
        Dim res = SaveTTXDialogAsk()
        If res = SaveResultAsk.YES Or res = SaveResultAsk.No Or res = SaveResultAsk.AlreadySaved Then
            LoadTTX(sender.Tag)
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        TextBox2.Location = Label9.Location
        If Label9.Width > Label9.Parent.Width / 2 Then
            TextBox2.Width = Label9.Width
        Else
            TextBox2.Width = Label9.Parent.Width / 2
        End If
        TextBox2.Height = Label9.Height
        TextBox2.Font = Label9.Font
        TextBox2.Text = ""
        TextBox2.Text = Label9.Text
        TextBox2.SelectionStart = TextBox2.Text.Length
        TextBox2.SelectionLength = 0
        TextBox2.Visible = True
        TextBox2.Focus()
    End Sub

    Private Sub label9save()
        If TextBox2.Text.Length > 1 And TextBox2.Text <> " " Then
            CurrentSession.projectName = TextBox2.Text
            Label9.Text = CurrentSession.projectName
            saved = False
            Me.Text = "TranslaTale - " & CurrentSession.projectName & IIf(saved, "", " *")
            TextBox2.Visible = False
        End If
    End Sub
    Private Sub label9close() Handles TextBox2.LostFocus
        TextBox2.Visible = False
    End Sub

    Private Sub label9leave2(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.End Then
            label9save()
        ElseIf e.KeyCode = Keys.Escape Then
            label9close()
        End If
    End Sub

    Private Sub useDefaultSpritesBtn_LinkClicked(sender As Object, e As EventArgs) Handles useDefaultSpritesBtn.LinkClicked, FromUndertaleToolStripMenuItem.Click
        Dim tf As String
        Dim result = MsgBox("Would you want to overwrite existing project sprites?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
        If result = MsgBoxResult.Yes Then
            tf = GetTempFolder(True)
            If extractSpritesFromWIN(CurrentSession.undertaleWIN, tf) = ExtractionResult.OK Then
                importSprites(Directory.GetFiles(tf, "*.png"), False, True)
                updateSpritesPanel()
            Else
                MsgBox("Error!", vbExclamation)
            End If
            Directory.Delete(tf, True)
        ElseIf result = MsgBoxResult.No Then
            tf = GetTempFolder(True)
            If extractSpritesFromWIN(CurrentSession.undertaleWIN, tf) = ExtractionResult.OK Then
                importSprites(Directory.GetFiles(tf, "*.png"), False, False)
                updateSpritesPanel()
            Else
                MsgBox("Error!", vbExclamation)
            End If
            Directory.Delete(tf, True)
        End If
    End Sub

    Private Sub spritesEditorToolBtn_Click(sender As Object, e As EventArgs) Handles spritesEditorToolBtn.Click
        viewMode = ViewModes.EditorSprites
    End Sub

    Private Sub spriteContextMenuStrip_Opening(sender As ContextMenuStrip, e As System.ComponentModel.CancelEventArgs) Handles spriteContextMenuStrip.Opening
        If spritesListView.SelectedItems.Count > 0 Then
            sender.Enabled = True
            If spritesListView.SelectedItems.Count = 1 Then
                ChangeToolStripMenuItem.Enabled = True
            Else
                ChangeToolStripMenuItem.Enabled = False
            End If
        Else
            sender.Enabled = False
        End If
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeToolStripMenuItem.Click
        If spritesListView.SelectedItems.Count = 1 Then
            OpenFileDialog1.Title = "Change sprite..."
            OpenFileDialog1.Filter = "Sprite|*.png"
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Dim originalImage As String = spritesListView.SelectedItems(0).Tag
                Dim substituteImage As String = OpenFileDialog1.FileName
                Try
                    Dim streamReader As New StreamReader(substituteImage)
                    Dim fileImage As TranslaTale.FileImage = New TranslaTale.FileImage(File.ReadAllBytes(substituteImage), originalImage)
                    streamReader.Close()
                    Dim foundSameImageIndex As Integer = -1
                    Dim count As Integer = CurrentSession.sprites.Count - 1
                    Dim existingImageIndex As Integer = 0
                    For Each existingImage In CurrentSession.sprites
                        If existingImage.fileName <> fileImage.fileName Then
                            existingImageIndex = existingImageIndex + 1
                        Else
                            foundSameImageIndex = existingImageIndex
                            Exit For
                        End If
                    Next
                    If (foundSameImageIndex = -1) Then
                        CurrentSession.sprites.Add(fileImage)
                    Else
                        CurrentSession.sprites(foundSameImageIndex) = fileImage
                    End If
                    updateSpritesPanel()
                    MsgBox("Done!", vbInformation)
                Catch
                    Interaction.MsgBox(String.Concat("Can't import ", Path.GetFileName(substituteImage)), MsgBoxStyle.Exclamation, Nothing)
                End Try
            End If
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If spritesListView.SelectedItems.Count > 0 Then
            Dim fld As New FolderSelect.FolderSelectDialog
            fld.Title = "Select output folder"
            If fld.ShowDialog() Then
                For Each imageItem As ListViewItem In spritesListView.SelectedItems
                    Dim imageName As String = imageItem.Tag
                    For Each image In CurrentSession.sprites
                        If image.fileName = imageName Then
                            File.WriteAllBytes(Path.Combine(fld.FileName, image.fileName), image.content)
                        End If
                    Next
                Next
                Process.Start(fld.FileName)
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If spritesListView.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure you want to delete selected sprites?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each imageItem As ListViewItem In spritesListView.SelectedItems
                    Dim imageName As String = imageItem.Tag
                    Dim tmplist As New List(Of FileImage)
                    For Each image In CurrentSession.sprites
                        tmplist.Add(image)
                    Next
                    For Each image In tmplist
                        If image.fileName = imageName Then
                            CurrentSession.sprites.Remove(image)
                        End If
                    Next
                Next
                updateSpritesPanel()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click_2(sender As Object, e As EventArgs)
        viewMode = ViewModes.ProjectManager
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        viewMode = ViewModes.EditorSprites
    End Sub

    Private Sub ToolStripButton1_Click_2(sender As Object, e As EventArgs) Handles debugToolBtn.Click
        frmGameCompiler.ShowDialog(False, True)
    End Sub

    Private Sub historyListView_ItemActivate(sender As Object, e As EventArgs) Handles historyListView.ItemActivate
        If sender.SelectedItems.Count = 1 Then
            LoadTTX(sender.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.DropDownOpening
        ShowSymbolsToolStripMenuItem.Enabled = IIf(viewMode = ViewModes.EditorStrings, True, False)
    End Sub

    Private Sub QSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QSaveToolStripMenuItem.Click
        If CurrentSession.isProjectFile And CurrentSession.projectPath <> "" Then
            SaveTTX(CurrentSession.projectPath)
        Else
            MsgBox("Can't save", vbExclamation)
        End If
    End Sub

    Private Sub frameTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles frameTrackBar.ValueChanged
        If manualframechange Then
            showText(stringTextEditor.Text)
        End If
    End Sub

    Private Sub aniTime_Tick(sender As Object, e As EventArgs) Handles aniTime.Tick
        If frameTrackBar.Value + 1 <= frameTrackBar.Maximum Then
            frameTrackBar.Value += 1
        Else
            aniTime.Stop()
            frameTrackBar.Enabled = True
            startAnimationBtn.ImageIndex = 0
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles startAnimationBtn.Click
        If aniTime.Enabled = False Then
            startAnimationBtn.ImageIndex = 1
            frameTrackBar.Enabled = False
            frameTrackBar.Value = 0
            aniTime.Start()
        Else
            aniTime.Stop()
            frameTrackBar.Enabled = True
            startAnimationBtn.ImageIndex = 0
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