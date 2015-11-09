<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBookmarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DumpStringstxtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepackStringstxtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DumpImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepackImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rbTextbox = New System.Windows.Forms.RadioButton()
        Me.rbFacebox = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ttipTranslated = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttipUntranslated = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttipTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cbFonts = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cf3 = New System.Windows.Forms.PictureBox()
        Me.cf2 = New System.Windows.Forms.PictureBox()
        Me.cf1 = New System.Windows.Forms.PictureBox()
        Me.c3 = New System.Windows.Forms.PictureBox()
        Me.c2 = New System.Windows.Forms.PictureBox()
        Me.c1 = New System.Windows.Forms.PictureBox()
        Me.picTxtEnemy = New System.Windows.Forms.PictureBox()
        Me.picTxtBox = New System.Windows.Forms.PictureBox()
        Me.picTxtFlowey = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cf3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cf2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cf1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTxtEnemy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTxtBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTxtFlowey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.BookmarksToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(679, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'BookmarksToolStripMenuItem
        '
        Me.BookmarksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.ListBookmarksToolStripMenuItem})
        Me.BookmarksToolStripMenuItem.Name = "BookmarksToolStripMenuItem"
        Me.BookmarksToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.BookmarksToolStripMenuItem.Text = "&Bookmarks"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Enabled = False
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AddToolStripMenuItem.Text = "Add Boo&kmark"
        '
        'ListBookmarksToolStripMenuItem
        '
        Me.ListBookmarksToolStripMenuItem.Name = "ListBookmarksToolStripMenuItem"
        Me.ListBookmarksToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ListBookmarksToolStripMenuItem.Text = "&List Bookmarks"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DumpStringstxtToolStripMenuItem, Me.RepackStringstxtToolStripMenuItem, Me.ToolStripSeparator2, Me.DumpImagesToolStripMenuItem, Me.RepackImagesToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'DumpStringstxtToolStripMenuItem
        '
        Me.DumpStringstxtToolStripMenuItem.Name = "DumpStringstxtToolStripMenuItem"
        Me.DumpStringstxtToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DumpStringstxtToolStripMenuItem.Text = "&Dump Strings.txt"
        '
        'RepackStringstxtToolStripMenuItem
        '
        Me.RepackStringstxtToolStripMenuItem.Name = "RepackStringstxtToolStripMenuItem"
        Me.RepackStringstxtToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RepackStringstxtToolStripMenuItem.Text = "&Repack Strings.txt"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(164, 6)
        '
        'DumpImagesToolStripMenuItem
        '
        Me.DumpImagesToolStripMenuItem.Name = "DumpImagesToolStripMenuItem"
        Me.DumpImagesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DumpImagesToolStripMenuItem.Text = "Dump &Images"
        '
        'RepackImagesToolStripMenuItem
        '
        Me.RepackImagesToolStripMenuItem.Name = "RepackImagesToolStripMenuItem"
        Me.RepackImagesToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RepackImagesToolStripMenuItem.Text = "Repack I&mages"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        Me.OptionsToolStripMenuItem.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'rbTextbox
        '
        Me.rbTextbox.AutoSize = True
        Me.rbTextbox.Checked = True
        Me.rbTextbox.Location = New System.Drawing.Point(12, 405)
        Me.rbTextbox.Name = "rbTextbox"
        Me.rbTextbox.Size = New System.Drawing.Size(66, 17)
        Me.rbTextbox.TabIndex = 6
        Me.rbTextbox.TabStop = True
        Me.rbTextbox.Text = "Text box"
        Me.rbTextbox.UseVisualStyleBackColor = True
        '
        'rbFacebox
        '
        Me.rbFacebox.AutoSize = True
        Me.rbFacebox.Location = New System.Drawing.Point(84, 405)
        Me.rbFacebox.Name = "rbFacebox"
        Me.rbFacebox.Size = New System.Drawing.Size(112, 17)
        Me.rbFacebox.TabIndex = 7
        Me.rbFacebox.Text = "Text box with face"
        Me.rbFacebox.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(202, 405)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(89, 17)
        Me.RadioButton3.TabIndex = 8
        Me.RadioButton3.Text = "Enemy (short)"
        Me.RadioButton3.UseVisualStyleBackColor = True
        Me.RadioButton3.Visible = False
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(297, 405)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(86, 17)
        Me.RadioButton4.TabIndex = 9
        Me.RadioButton4.Text = "Enemy (long)"
        Me.RadioButton4.UseVisualStyleBackColor = True
        Me.RadioButton4.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(10, 376)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(654, 20)
        Me.TextBox1.TabIndex = 10
        '
        'ListView1
        '
        Me.ListView1.Enabled = False
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        ListViewGroup1.Header = "ListViewGroup"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "ListViewGroup"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "ListViewGroup"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.ListView1.Location = New System.Drawing.Point(10, 50)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(652, 315)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttipTranslated, Me.ttipUntranslated, Me.ttipTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 598)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(679, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 48
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ttipTranslated
        '
        Me.ttipTranslated.AutoSize = False
        Me.ttipTranslated.BackColor = System.Drawing.Color.LightGreen
        Me.ttipTranslated.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ttipTranslated.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ttipTranslated.Name = "ttipTranslated"
        Me.ttipTranslated.Size = New System.Drawing.Size(50, 17)
        Me.ttipTranslated.Text = "0"
        '
        'ttipUntranslated
        '
        Me.ttipUntranslated.AutoSize = False
        Me.ttipUntranslated.BackColor = System.Drawing.Color.LightSalmon
        Me.ttipUntranslated.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ttipUntranslated.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ttipUntranslated.Name = "ttipUntranslated"
        Me.ttipUntranslated.Size = New System.Drawing.Size(50, 17)
        Me.ttipUntranslated.Text = "0"
        '
        'ttipTotal
        '
        Me.ttipTotal.AutoSize = False
        Me.ttipTotal.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ttipTotal.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ttipTotal.Name = "ttipTotal"
        Me.ttipTotal.Size = New System.Drawing.Size(50, 17)
        Me.ttipTotal.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowMerge = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(679, 25)
        Me.ToolStrip1.TabIndex = 49
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.TranslaTale.My.Resources.Resources.ico_open
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Open"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = Global.TranslaTale.My.Resources.Resources.ico_save
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Save"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Enabled = False
        Me.ToolStripButton4.Image = Global.TranslaTale.My.Resources.Resources.ico_step
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Jump to line"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Enabled = False
        Me.ToolStripButton3.Image = Global.TranslaTale.My.Resources.Resources.ico_search
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Search"
        '
        'cbFonts
        '
        Me.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFonts.FormattingEnabled = True
        Me.cbFonts.Items.AddRange(New Object() {"Standard", "Sans", "Papyrus"})
        Me.cbFonts.Location = New System.Drawing.Point(542, 402)
        Me.cbFonts.Name = "cbFonts"
        Me.cbFonts.Size = New System.Drawing.Size(121, 21)
        Me.cbFonts.TabIndex = 53
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'cf3
        '
        Me.cf3.BackColor = System.Drawing.Color.Black
        Me.cf3.Location = New System.Drawing.Point(188, 526)
        Me.cf3.Name = "cf3"
        Me.cf3.Size = New System.Drawing.Size(420, 30)
        Me.cf3.TabIndex = 52
        Me.cf3.TabStop = False
        Me.cf3.Visible = False
        '
        'cf2
        '
        Me.cf2.BackColor = System.Drawing.Color.Black
        Me.cf2.Location = New System.Drawing.Point(188, 493)
        Me.cf2.Name = "cf2"
        Me.cf2.Size = New System.Drawing.Size(420, 30)
        Me.cf2.TabIndex = 51
        Me.cf2.TabStop = False
        Me.cf2.Visible = False
        '
        'cf1
        '
        Me.cf1.BackColor = System.Drawing.Color.Black
        Me.cf1.Location = New System.Drawing.Point(188, 461)
        Me.cf1.Name = "cf1"
        Me.cf1.Size = New System.Drawing.Size(420, 30)
        Me.cf1.TabIndex = 50
        Me.cf1.TabStop = False
        Me.cf1.Visible = False
        '
        'c3
        '
        Me.c3.BackColor = System.Drawing.Color.Black
        Me.c3.Location = New System.Drawing.Point(70, 527)
        Me.c3.Name = "c3"
        Me.c3.Size = New System.Drawing.Size(527, 30)
        Me.c3.TabIndex = 46
        Me.c3.TabStop = False
        '
        'c2
        '
        Me.c2.BackColor = System.Drawing.Color.Black
        Me.c2.Location = New System.Drawing.Point(70, 495)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(527, 30)
        Me.c2.TabIndex = 45
        Me.c2.TabStop = False
        '
        'c1
        '
        Me.c1.BackColor = System.Drawing.Color.Black
        Me.c1.Location = New System.Drawing.Point(70, 461)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(527, 30)
        Me.c1.TabIndex = 12
        Me.c1.TabStop = False
        '
        'picTxtEnemy
        '
        Me.picTxtEnemy.Image = Global.TranslaTale.My.Resources.Resources.img1
        Me.picTxtEnemy.Location = New System.Drawing.Point(229, 440)
        Me.picTxtEnemy.Name = "picTxtEnemy"
        Me.picTxtEnemy.Size = New System.Drawing.Size(234, 135)
        Me.picTxtEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picTxtEnemy.TabIndex = 1
        Me.picTxtEnemy.TabStop = False
        Me.picTxtEnemy.Visible = False
        '
        'picTxtBox
        '
        Me.picTxtBox.Image = Global.TranslaTale.My.Resources.Resources.img2
        Me.picTxtBox.Location = New System.Drawing.Point(50, 436)
        Me.picTxtBox.Name = "picTxtBox"
        Me.picTxtBox.Size = New System.Drawing.Size(575, 140)
        Me.picTxtBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picTxtBox.TabIndex = 2
        Me.picTxtBox.TabStop = False
        '
        'picTxtFlowey
        '
        Me.picTxtFlowey.Image = Global.TranslaTale.My.Resources.Resources.img3
        Me.picTxtFlowey.Location = New System.Drawing.Point(50, 431)
        Me.picTxtFlowey.Name = "picTxtFlowey"
        Me.picTxtFlowey.Size = New System.Drawing.Size(578, 152)
        Me.picTxtFlowey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picTxtFlowey.TabIndex = 3
        Me.picTxtFlowey.TabStop = False
        Me.picTxtFlowey.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Black
        Me.PictureBox4.Location = New System.Drawing.Point(12, 428)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(652, 158)
        Me.PictureBox4.TabIndex = 5
        Me.PictureBox4.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 620)
        Me.Controls.Add(Me.cbFonts)
        Me.Controls.Add(Me.cf3)
        Me.Controls.Add(Me.cf2)
        Me.Controls.Add(Me.cf1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.c3)
        Me.Controls.Add(Me.c2)
        Me.Controls.Add(Me.c1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.rbFacebox)
        Me.Controls.Add(Me.rbTextbox)
        Me.Controls.Add(Me.picTxtEnemy)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.picTxtBox)
        Me.Controls.Add(Me.picTxtFlowey)
        Me.Controls.Add(Me.PictureBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TranslaTale"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cf3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cf2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cf1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTxtEnemy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTxtBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTxtFlowey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents rbTextbox As System.Windows.Forms.RadioButton
    Friend WithEvents rbFacebox As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DumpStringstxtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepackStringstxtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DumpImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepackImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents c1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents picTxtFlowey As System.Windows.Forms.PictureBox
    Friend WithEvents picTxtBox As System.Windows.Forms.PictureBox
    Friend WithEvents picTxtEnemy As System.Windows.Forms.PictureBox
    Friend WithEvents c2 As System.Windows.Forms.PictureBox
    Friend WithEvents c3 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ttipUntranslated As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ttipTranslated As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ttipTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBookmarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cf3 As System.Windows.Forms.PictureBox
    Friend WithEvents cf2 As System.Windows.Forms.PictureBox
    Friend WithEvents cf1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cbFonts As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
