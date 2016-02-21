<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompare
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompare))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AllElementsOfTheFirstFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllElementsOfTheSecondFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.File1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.File2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LeftNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RightNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DiscrepanciesNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EqualNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StringsList = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.CheckSecondCol = New System.Windows.Forms.Button()
        Me.CheckFirstCol = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.StatusStrip1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.StringsList, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(837, 258)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TableLayoutPanel1.SetColumnSpan(Me.StatusStrip1, 2)
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.ToolStripDropDownButton1, Me.SaveButton, Me.ToolStripStatusLabel7, Me.LeftNumber, Me.RightNumber, Me.DiscrepanciesNumber, Me.EqualNumber, Me.TotalNumber})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 222)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(837, 36)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllElementsOfTheFirstFileToolStripMenuItem, Me.AllElementsOfTheSecondFileToolStripMenuItem, Me.GoToToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = Global.TranslaTale.My.Resources.Resources.text_list_numbers1
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(83, 36)
        Me.ToolStripSplitButton1.Text = "Select"
        '
        'AllElementsOfTheFirstFileToolStripMenuItem
        '
        Me.AllElementsOfTheFirstFileToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.arrow_left1
        Me.AllElementsOfTheFirstFileToolStripMenuItem.Name = "AllElementsOfTheFirstFileToolStripMenuItem"
        Me.AllElementsOfTheFirstFileToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AllElementsOfTheFirstFileToolStripMenuItem.Text = "All elements of the first file"
        '
        'AllElementsOfTheSecondFileToolStripMenuItem
        '
        Me.AllElementsOfTheSecondFileToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.arrow_right1
        Me.AllElementsOfTheSecondFileToolStripMenuItem.Name = "AllElementsOfTheSecondFileToolStripMenuItem"
        Me.AllElementsOfTheSecondFileToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AllElementsOfTheSecondFileToolStripMenuItem.Text = "All elements of the second file"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.page_go1
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.GoToToolStripMenuItem.Text = "Go to line"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File1ToolStripMenuItem, Me.File2ToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.TranslaTale.My.Resources.Resources.tag_green
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(199, 36)
        Me.ToolStripDropDownButton1.Text = "Keep groups and settings of"
        '
        'File1ToolStripMenuItem
        '
        Me.File1ToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.check_box1
        Me.File1ToolStripMenuItem.Name = "File1ToolStripMenuItem"
        Me.File1ToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.File1ToolStripMenuItem.Tag = "yes"
        Me.File1ToolStripMenuItem.Text = "First file"
        '
        'File2ToolStripMenuItem
        '
        Me.File2ToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.check_box_uncheck
        Me.File2ToolStripMenuItem.Name = "File2ToolStripMenuItem"
        Me.File2ToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.File2ToolStripMenuItem.Text = "Second file"
        '
        'SaveButton
        '
        Me.SaveButton.Enabled = False
        Me.SaveButton.Image = Global.TranslaTale.My.Resources.Resources.save_as1
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(0)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.ShowDropDownArrow = False
        Me.SaveButton.Size = New System.Drawing.Size(67, 36)
        Me.SaveButton.Text = "Save"
        Me.SaveButton.ToolTipText = "Save"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(197, 31)
        Me.ToolStripStatusLabel7.Spring = True
        '
        'LeftNumber
        '
        Me.LeftNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LeftNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.LeftNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.LeftNumber.Image = Global.TranslaTale.My.Resources.Resources.arrow_left1
        Me.LeftNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.LeftNumber.Name = "LeftNumber"
        Me.LeftNumber.Size = New System.Drawing.Size(49, 36)
        Me.LeftNumber.Text = "0"
        '
        'RightNumber
        '
        Me.RightNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RightNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.RightNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.RightNumber.Image = Global.TranslaTale.My.Resources.Resources.arrow_right1
        Me.RightNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.RightNumber.Name = "RightNumber"
        Me.RightNumber.Size = New System.Drawing.Size(49, 36)
        Me.RightNumber.Text = "0"
        '
        'DiscrepanciesNumber
        '
        Me.DiscrepanciesNumber.BackColor = System.Drawing.Color.Gainsboro
        Me.DiscrepanciesNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.DiscrepanciesNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.DiscrepanciesNumber.Image = Global.TranslaTale.My.Resources.Resources.page_red1
        Me.DiscrepanciesNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.DiscrepanciesNumber.Name = "DiscrepanciesNumber"
        Me.DiscrepanciesNumber.Size = New System.Drawing.Size(49, 36)
        Me.DiscrepanciesNumber.Text = "0"
        '
        'EqualNumber
        '
        Me.EqualNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.EqualNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.EqualNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.EqualNumber.Image = Global.TranslaTale.My.Resources.Resources.page_green1
        Me.EqualNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.EqualNumber.Name = "EqualNumber"
        Me.EqualNumber.Size = New System.Drawing.Size(49, 36)
        Me.EqualNumber.Text = "0"
        '
        'TotalNumber
        '
        Me.TotalNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TotalNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalNumber.Image = Global.TranslaTale.My.Resources.Resources.text_list_numbers1
        Me.TotalNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalNumber.Name = "TotalNumber"
        Me.TotalNumber.Size = New System.Drawing.Size(49, 36)
        Me.TotalNumber.Text = "0"
        '
        'StringsList
        '
        Me.StringsList.AllowDrop = True
        Me.StringsList.BackColor = System.Drawing.Color.White
        Me.StringsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.TableLayoutPanel1.SetColumnSpan(Me.StringsList, 2)
        Me.StringsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StringsList.Font = New System.Drawing.Font("Lucida Sans", 8.25!)
        Me.StringsList.FullRowSelect = True
        Me.StringsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.StringsList.HideSelection = False
        Me.StringsList.Location = New System.Drawing.Point(0, 0)
        Me.StringsList.Margin = New System.Windows.Forms.Padding(0)
        Me.StringsList.Name = "StringsList"
        Me.StringsList.ShowGroups = False
        Me.StringsList.Size = New System.Drawing.Size(837, 222)
        Me.StringsList.TabIndex = 58
        Me.StringsList.UseCompatibleStateImageBehavior = False
        Me.StringsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Line"
        Me.ColumnHeader0.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "DRAG HERE FILE 1"
        Me.ColumnHeader1.Width = 337
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.Width = 25
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 25
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "DRAG HERE FILE 2"
        Me.ColumnHeader4.Width = 346
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 200
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CreatePrompt = True
        Me.SaveFileDialog1.FileName = "output_strings.txt"
        Me.SaveFileDialog1.Filter = "TranslaTale file|*.ttx|Text file|*.txt|All files|*.*"
        Me.SaveFileDialog1.Title = "Save output file"
        '
        'CheckSecondCol
        '
        Me.CheckSecondCol.Image = Global.TranslaTale.My.Resources.Resources.check_box
        Me.CheckSecondCol.Location = New System.Drawing.Point(436, 3)
        Me.CheckSecondCol.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckSecondCol.Name = "CheckSecondCol"
        Me.CheckSecondCol.Size = New System.Drawing.Size(20, 20)
        Me.CheckSecondCol.TabIndex = 5
        Me.CheckSecondCol.UseVisualStyleBackColor = True
        '
        'CheckFirstCol
        '
        Me.CheckFirstCol.Image = Global.TranslaTale.My.Resources.Resources.check_box
        Me.CheckFirstCol.Location = New System.Drawing.Point(411, 3)
        Me.CheckFirstCol.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckFirstCol.Name = "CheckFirstCol"
        Me.CheckFirstCol.Size = New System.Drawing.Size(20, 20)
        Me.CheckFirstCol.TabIndex = 4
        Me.CheckFirstCol.UseVisualStyleBackColor = True
        '
        'frmCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(837, 258)
        Me.Controls.Add(Me.CheckSecondCol)
        Me.Controls.Add(Me.CheckFirstCol)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(853, 9999)
        Me.MinimumSize = New System.Drawing.Size(853, 297)
        Me.Name = "frmCompare"
        Me.Text = "Compare two language files"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripSplitButton1 As ToolStripDropDownButton
    Friend WithEvents AllElementsOfTheFirstFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllElementsOfTheSecondFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeftNumber As ToolStripStatusLabel
    Friend WithEvents RightNumber As ToolStripStatusLabel
    Friend WithEvents DiscrepanciesNumber As ToolStripStatusLabel
    Friend WithEvents EqualNumber As ToolStripStatusLabel
    Friend WithEvents TotalNumber As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents GoToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StringsList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents CheckFirstCol As Button
    Friend WithEvents CheckSecondCol As Button
    Friend WithEvents ColumnHeader0 As ColumnHeader
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents File1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents File2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveButton As ToolStripDropDownButton
End Class
