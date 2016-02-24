<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Undertale.exe", 0)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("data.win", 0)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Sprites", 0)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Original Strings.txt", 0)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Translated Srings.txt", 0)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.stringTextEditor = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SpriteFontBox1 = New UTSpriteFontBox.SpriteFontBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.newProjectToolStripBtn = New System.Windows.Forms.ToolStripButton()
        Me.openProjectBtn2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.LastestFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.projectManagerToolBtn = New System.Windows.Forms.ToolStripButton()
        Me.stringsEditorToolBtn = New System.Windows.Forms.ToolStripButton()
        Me.spritesEditorToolBtn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.searchToolStripBtn = New System.Windows.Forms.ToolStripButton()
        Me.goToLineToolStripBtn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.debugToolBtn = New System.Windows.Forms.ToolStripButton()
        Me.UDTPatchToolStripMenuItem = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DumpStringstxtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DumpOriginalImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.RepackGameASCIICharactersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepackGamecustomFontsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MigrationToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.UndertalePatchToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompareTranslationFilesToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.filtermenubtn = New System.Windows.Forms.ToolStripDropDownButton()
        Me.filterByGroupBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TranslatedStringsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UntranslatedStringsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ShowSymbolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.ttipMenu = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.ResetBtn = New System.Windows.Forms.PictureBox()
        Me.stringsPnl = New System.Windows.Forms.ListView()
        Me.MainViewPanel = New System.Windows.Forms.Panel()
        Me.spritesPnl = New System.Windows.Forms.Panel()
        Me.spritesListView = New System.Windows.Forms.ListView()
        Me.spriteContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.spritesImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ChooseSpritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromUndertaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.projectmanagerPnl = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.useDefaultStringsBtn = New System.Windows.Forms.LinkLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.useDefaultSpritesBtn = New System.Windows.Forms.LinkLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.welcomePnl = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.infoBtn = New System.Windows.Forms.LinkLabel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.migrationToolBtn = New System.Windows.Forms.LinkLabel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.compareMainBtn = New System.Windows.Forms.LinkLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.openProjectBtn = New System.Windows.Forms.LinkLabel()
        Me.newProjectBtn = New System.Windows.Forms.LinkLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.bottomPnl = New System.Windows.Forms.Panel()
        Me.cbFonts = New System.Windows.Forms.ComboBox()
        Me.rbFacebox = New System.Windows.Forms.RadioButton()
        Me.rbTextbox = New System.Windows.Forms.RadioButton()
        Me.splitRight = New System.Windows.Forms.SplitContainer()
        Me.pnlGroups = New System.Windows.Forms.Panel()
        Me.btnEditGroup = New System.Windows.Forms.Button()
        Me.btnDeleteGroup = New System.Windows.Forms.Button()
        Me.btnCreateGroup = New System.Windows.Forms.Button()
        Me.btnSetGroup = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.componentsList = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.topPnl = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialogMulti = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TranslationPercentageBox1 = New TranslaTale.TranslationPercentageBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SpriteFontBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tblEditor.SuspendLayout()
        CType(Me.ResetBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainViewPanel.SuspendLayout()
        Me.spritesPnl.SuspendLayout()
        Me.spriteContextMenuStrip.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.projectmanagerPnl.SuspendLayout()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.welcomePnl.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.bottomPnl.SuspendLayout()
        CType(Me.splitRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitRight.Panel1.SuspendLayout()
        Me.splitRight.Panel2.SuspendLayout()
        Me.splitRight.SuspendLayout()
        Me.pnlGroups.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.topPnl.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel9.SuspendLayout()
        Me.FlowLayoutPanel8.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stringTextEditor
        '
        Me.stringTextEditor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stringTextEditor.BackColor = System.Drawing.Color.Gainsboro
        Me.stringTextEditor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.stringTextEditor.Enabled = False
        Me.stringTextEditor.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stringTextEditor.ForeColor = System.Drawing.Color.Black
        Me.stringTextEditor.Location = New System.Drawing.Point(0, 41)
        Me.stringTextEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.stringTextEditor.Name = "stringTextEditor"
        Me.stringTextEditor.Size = New System.Drawing.Size(55, 26)
        Me.stringTextEditor.TabIndex = 10
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(666, 170)
        Me.TableLayoutPanel1.TabIndex = 54
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.SpriteFontBox1)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 164)
        Me.Panel1.TabIndex = 0
        '
        'SpriteFontBox1
        '
        Me.SpriteFontBox1.CurrentSpriteFont = UTSpriteFontBox.SpriteFontBox.SpriteFonts.BitOperator
        Me.SpriteFontBox1.ErrorImage = Nothing
        Me.SpriteFontBox1.FontPath = ""
        Me.SpriteFontBox1.Image = CType(resources.GetObject("SpriteFontBox1.Image"), System.Drawing.Image)
        Me.SpriteFontBox1.InitialImage = Nothing
        Me.SpriteFontBox1.Location = New System.Drawing.Point(41, 6)
        Me.SpriteFontBox1.MinimumSize = New System.Drawing.Size(578, 152)
        Me.SpriteFontBox1.Name = "SpriteFontBox1"
        Me.SpriteFontBox1.ShowCommands = False
        Me.SpriteFontBox1.ShowFaces = False
        Me.SpriteFontBox1.Size = New System.Drawing.Size(578, 152)
        Me.SpriteFontBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SpriteFontBox1.TabIndex = 60
        Me.SpriteFontBox1.Text = "SpriteFontBox1"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox4.BackgroundImage = Global.TranslaTale.My.Resources.Resources.tablebg
        Me.PictureBox4.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(652, 158)
        Me.PictureBox4.TabIndex = 5
        Me.PictureBox4.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowMerge = False
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newProjectToolStripBtn, Me.openProjectBtn2, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.projectManagerToolBtn, Me.stringsEditorToolBtn, Me.spritesEditorToolBtn, Me.ToolStripSeparator5, Me.searchToolStripBtn, Me.goToLineToolStripBtn, Me.ToolStripSeparator6, Me.debugToolBtn, Me.UDTPatchToolStripMenuItem, Me.CompareTranslationFilesToolStripMenuItem, Me.ToolStripSeparator2, Me.filtermenubtn, Me.ToolStripSeparator10, Me.OptionsToolStripMenuItem, Me.ToolStripSeparator12, Me.AboutToolStripMenuItem})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 17)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(854, 76)
        Me.ToolStrip1.TabIndex = 49
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'newProjectToolStripBtn
        '
        Me.newProjectToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.newProjectToolStripBtn.Image = Global.TranslaTale.My.Resources.Resources._new
        Me.newProjectToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newProjectToolStripBtn.Name = "newProjectToolStripBtn"
        Me.newProjectToolStripBtn.Size = New System.Drawing.Size(36, 36)
        Me.newProjectToolStripBtn.Text = "New Project"
        '
        'openProjectBtn2
        '
        Me.openProjectBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.openProjectBtn2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoryToolStripMenuItem, Me.ToolStripSeparator8, Me.LastestFileToolStripMenuItem})
        Me.openProjectBtn2.Image = Global.TranslaTale.My.Resources.Resources.folder_page_white1
        Me.openProjectBtn2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.openProjectBtn2.Name = "openProjectBtn2"
        Me.openProjectBtn2.Size = New System.Drawing.Size(48, 36)
        Me.openProjectBtn2.Text = "Open"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(126, 6)
        '
        'LastestFileToolStripMenuItem
        '
        Me.LastestFileToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.time
        Me.LastestFileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LastestFileToolStripMenuItem.Name = "LastestFileToolStripMenuItem"
        Me.LastestFileToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.LastestFileToolStripMenuItem.Text = "Lastest file"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.save_as1
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(36, 36)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'projectManagerToolBtn
        '
        Me.projectManagerToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.projectManagerToolBtn.Enabled = False
        Me.projectManagerToolBtn.Image = Global.TranslaTale.My.Resources.Resources.house
        Me.projectManagerToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.projectManagerToolBtn.Name = "projectManagerToolBtn"
        Me.projectManagerToolBtn.Size = New System.Drawing.Size(36, 36)
        Me.projectManagerToolBtn.Text = "Project manager"
        '
        'stringsEditorToolBtn
        '
        Me.stringsEditorToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stringsEditorToolBtn.Enabled = False
        Me.stringsEditorToolBtn.Image = Global.TranslaTale.My.Resources.Resources.edit_diff
        Me.stringsEditorToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stringsEditorToolBtn.Name = "stringsEditorToolBtn"
        Me.stringsEditorToolBtn.Size = New System.Drawing.Size(36, 36)
        Me.stringsEditorToolBtn.Text = "Strings editor"
        '
        'spritesEditorToolBtn
        '
        Me.spritesEditorToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.spritesEditorToolBtn.Enabled = False
        Me.spritesEditorToolBtn.Image = Global.TranslaTale.My.Resources.Resources.image_edit
        Me.spritesEditorToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.spritesEditorToolBtn.Name = "spritesEditorToolBtn"
        Me.spritesEditorToolBtn.Size = New System.Drawing.Size(36, 36)
        Me.spritesEditorToolBtn.Text = "Sprites editor"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'searchToolStripBtn
        '
        Me.searchToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.searchToolStripBtn.Enabled = False
        Me.searchToolStripBtn.Image = Global.TranslaTale.My.Resources.Resources.find2
        Me.searchToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.searchToolStripBtn.Name = "searchToolStripBtn"
        Me.searchToolStripBtn.Size = New System.Drawing.Size(36, 36)
        Me.searchToolStripBtn.Text = "Search"
        '
        'goToLineToolStripBtn
        '
        Me.goToLineToolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.goToLineToolStripBtn.Enabled = False
        Me.goToLineToolStripBtn.Image = Global.TranslaTale.My.Resources.Resources.table_select_row
        Me.goToLineToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.goToLineToolStripBtn.Name = "goToLineToolStripBtn"
        Me.goToLineToolStripBtn.Size = New System.Drawing.Size(36, 36)
        Me.goToLineToolStripBtn.Text = "Jump to line"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'debugToolBtn
        '
        Me.debugToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.debugToolBtn.Enabled = False
        Me.debugToolBtn.Image = Global.TranslaTale.My.Resources.Resources.resultset_next
        Me.debugToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.debugToolBtn.Name = "debugToolBtn"
        Me.debugToolBtn.Size = New System.Drawing.Size(36, 36)
        Me.debugToolBtn.Text = "Debug"
        '
        'UDTPatchToolStripMenuItem
        '
        Me.UDTPatchToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UDTPatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DumpStringstxtToolStripMenuItem, Me.DumpOriginalImagesToolStripMenuItem, Me.ToolStripSeparator11, Me.RepackGameASCIICharactersToolStripMenuItem, Me.RepackGamecustomFontsToolStripMenuItem, Me.ToolStripSeparator3, Me.MigrationToolToolStripMenuItem, Me.ToolStripSeparator7, Me.UndertalePatchToolToolStripMenuItem})
        Me.UDTPatchToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.compile
        Me.UDTPatchToolStripMenuItem.Name = "UDTPatchToolStripMenuItem"
        Me.UDTPatchToolStripMenuItem.Size = New System.Drawing.Size(45, 36)
        Me.UDTPatchToolStripMenuItem.Text = "Game related"
        '
        'DumpStringstxtToolStripMenuItem
        '
        Me.DumpStringstxtToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.box_open
        Me.DumpStringstxtToolStripMenuItem.Name = "DumpStringstxtToolStripMenuItem"
        Me.DumpStringstxtToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.DumpStringstxtToolStripMenuItem.Text = "Dump original strings.txt"
        '
        'DumpOriginalImagesToolStripMenuItem
        '
        Me.DumpOriginalImagesToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.box_open
        Me.DumpOriginalImagesToolStripMenuItem.Name = "DumpOriginalImagesToolStripMenuItem"
        Me.DumpOriginalImagesToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.DumpOriginalImagesToolStripMenuItem.Text = "Dump original images"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(302, 6)
        '
        'RepackGameASCIICharactersToolStripMenuItem
        '
        Me.RepackGameASCIICharactersToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.text_allcaps
        Me.RepackGameASCIICharactersToolStripMenuItem.Name = "RepackGameASCIICharactersToolStripMenuItem"
        Me.RepackGameASCIICharactersToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.RepackGameASCIICharactersToolStripMenuItem.Text = "Repack Game (ASCII characters)"
        '
        'RepackGamecustomFontsToolStripMenuItem
        '
        Me.RepackGamecustomFontsToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.text_language
        Me.RepackGamecustomFontsToolStripMenuItem.Name = "RepackGamecustomFontsToolStripMenuItem"
        Me.RepackGamecustomFontsToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.RepackGamecustomFontsToolStripMenuItem.Text = "Repack Game with a custom character table"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(302, 6)
        '
        'MigrationToolToolStripMenuItem
        '
        Me.MigrationToolToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.translation_tool_tip
        Me.MigrationToolToolStripMenuItem.Name = "MigrationToolToolStripMenuItem"
        Me.MigrationToolToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.MigrationToolToolStripMenuItem.Text = "Migration Tool (from v1.0 to v1.001)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(302, 6)
        '
        'UndertalePatchToolToolStripMenuItem
        '
        Me.UndertalePatchToolToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.compile
        Me.UndertalePatchToolToolStripMenuItem.Name = "UndertalePatchToolToolStripMenuItem"
        Me.UndertalePatchToolToolStripMenuItem.Size = New System.Drawing.Size(305, 22)
        Me.UndertalePatchToolToolStripMenuItem.Text = "Undertale Patcher Tool"
        '
        'CompareTranslationFilesToolStripMenuItem
        '
        Me.CompareTranslationFilesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CompareTranslationFilesToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.compare
        Me.CompareTranslationFilesToolStripMenuItem.Name = "CompareTranslationFilesToolStripMenuItem"
        Me.CompareTranslationFilesToolStripMenuItem.Size = New System.Drawing.Size(36, 36)
        Me.CompareTranslationFilesToolStripMenuItem.Text = "Compare and join two projects"
        Me.CompareTranslationFilesToolStripMenuItem.ToolTipText = "Compare two translation files"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'filtermenubtn
        '
        Me.filtermenubtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.filtermenubtn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.filterByGroupBtn, Me.ToolStripSeparator4, Me.TranslatedStringsToolStripMenuItem, Me.UntranslatedStringsToolStripMenuItem, Me.ToolStripSeparator9, Me.ClearFilterToolStripMenuItem})
        Me.filtermenubtn.Image = Global.TranslaTale.My.Resources.Resources.filter
        Me.filtermenubtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.filtermenubtn.Name = "filtermenubtn"
        Me.filtermenubtn.Size = New System.Drawing.Size(45, 36)
        Me.filtermenubtn.Text = "Filter"
        '
        'filterByGroupBtn
        '
        Me.filterByGroupBtn.Image = Global.TranslaTale.My.Resources.Resources.tag_orange
        Me.filterByGroupBtn.Name = "filterByGroupBtn"
        Me.filterByGroupBtn.Size = New System.Drawing.Size(236, 22)
        Me.filterByGroupBtn.Text = "Filter by group"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(233, 6)
        '
        'TranslatedStringsToolStripMenuItem
        '
        Me.TranslatedStringsToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.page_green1
        Me.TranslatedStringsToolStripMenuItem.Name = "TranslatedStringsToolStripMenuItem"
        Me.TranslatedStringsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.TranslatedStringsToolStripMenuItem.Text = "Show only translated strings"
        '
        'UntranslatedStringsToolStripMenuItem
        '
        Me.UntranslatedStringsToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.page_red1
        Me.UntranslatedStringsToolStripMenuItem.Name = "UntranslatedStringsToolStripMenuItem"
        Me.UntranslatedStringsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.UntranslatedStringsToolStripMenuItem.Text = "Show only untranslated strings"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(233, 6)
        '
        'ClearFilterToolStripMenuItem
        '
        Me.ClearFilterToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.filter_clear1
        Me.ClearFilterToolStripMenuItem.Name = "ClearFilterToolStripMenuItem"
        Me.ClearFilterToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ClearFilterToolStripMenuItem.Text = "Reset filter"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 39)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSymbolsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.layout_edit
        Me.OptionsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(45, 36)
        Me.OptionsToolStripMenuItem.Text = "View settings"
        '
        'ShowSymbolsToolStripMenuItem
        '
        Me.ShowSymbolsToolStripMenuItem.Name = "ShowSymbolsToolStripMenuItem"
        Me.ShowSymbolsToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ShowSymbolsToolStripMenuItem.Text = "&Show formatting symbols"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 39)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.information
        Me.AboutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(36, 36)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ttipMenu
        '
        Me.ttipMenu.AutoEllipsis = True
        Me.ttipMenu.AutoSize = True
        Me.ttipMenu.BackColor = System.Drawing.Color.Transparent
        Me.ttipMenu.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttipMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ttipMenu.Location = New System.Drawing.Point(0, 0)
        Me.ttipMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.ttipMenu.Name = "ttipMenu"
        Me.ttipMenu.Size = New System.Drawing.Size(25, 13)
        Me.ttipMenu.TabIndex = 61
        Me.ttipMenu.Text = "File"
        Me.ttipMenu.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ttipMenu, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(761, 16)
        Me.TableLayoutPanel2.TabIndex = 16
        '
        'tblEditor
        '
        Me.tblEditor.BackColor = System.Drawing.Color.Gainsboro
        Me.tblEditor.ColumnCount = 2
        Me.tblEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tblEditor.Controls.Add(Me.stringTextEditor, 0, 1)
        Me.tblEditor.Controls.Add(Me.ResetBtn, 1, 1)
        Me.tblEditor.Controls.Add(Me.stringsPnl, 0, 0)
        Me.tblEditor.Location = New System.Drawing.Point(630, 32)
        Me.tblEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.tblEditor.Name = "tblEditor"
        Me.tblEditor.RowCount = 2
        Me.tblEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tblEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblEditor.Size = New System.Drawing.Size(81, 67)
        Me.tblEditor.TabIndex = 60
        '
        'ResetBtn
        '
        Me.ResetBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResetBtn.BackColor = System.Drawing.Color.Gainsboro
        Me.ResetBtn.BackgroundImage = Global.TranslaTale.My.Resources.Resources.cross2
        Me.ResetBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ResetBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ResetBtn.Location = New System.Drawing.Point(55, 41)
        Me.ResetBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.ResetBtn.Name = "ResetBtn"
        Me.ResetBtn.Size = New System.Drawing.Size(26, 26)
        Me.ResetBtn.TabIndex = 55
        Me.ResetBtn.TabStop = False
        Me.ResetBtn.Visible = False
        '
        'stringsPnl
        '
        Me.stringsPnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.stringsPnl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tblEditor.SetColumnSpan(Me.stringsPnl, 2)
        Me.stringsPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.stringsPnl.Enabled = False
        Me.stringsPnl.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stringsPnl.ForeColor = System.Drawing.Color.Black
        Me.stringsPnl.FullRowSelect = True
        Me.stringsPnl.GridLines = True
        ListViewGroup1.Header = "ListViewGroup"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "ListViewGroup"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "ListViewGroup"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.stringsPnl.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.stringsPnl.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.stringsPnl.HideSelection = False
        Me.stringsPnl.Location = New System.Drawing.Point(0, 0)
        Me.stringsPnl.Margin = New System.Windows.Forms.Padding(0)
        Me.stringsPnl.Name = "stringsPnl"
        Me.stringsPnl.OwnerDraw = True
        Me.stringsPnl.Size = New System.Drawing.Size(81, 41)
        Me.stringsPnl.TabIndex = 11
        Me.stringsPnl.UseCompatibleStateImageBehavior = False
        Me.stringsPnl.View = System.Windows.Forms.View.Details
        '
        'MainViewPanel
        '
        Me.MainViewPanel.Controls.Add(Me.spritesPnl)
        Me.MainViewPanel.Controls.Add(Me.projectmanagerPnl)
        Me.MainViewPanel.Controls.Add(Me.tblEditor)
        Me.MainViewPanel.Controls.Add(Me.welcomePnl)
        Me.MainViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainViewPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainViewPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MainViewPanel.Name = "MainViewPanel"
        Me.MainViewPanel.Size = New System.Drawing.Size(666, 361)
        Me.MainViewPanel.TabIndex = 62
        '
        'spritesPnl
        '
        Me.spritesPnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spritesPnl.Controls.Add(Me.spritesListView)
        Me.spritesPnl.Controls.Add(Me.ToolStrip3)
        Me.spritesPnl.Location = New System.Drawing.Point(589, 261)
        Me.spritesPnl.Name = "spritesPnl"
        Me.spritesPnl.Size = New System.Drawing.Size(358, 222)
        Me.spritesPnl.TabIndex = 61
        '
        'spritesListView
        '
        Me.spritesListView.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spritesListView.ContextMenuStrip = Me.spriteContextMenuStrip
        Me.spritesListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spritesListView.LargeImageList = Me.spritesImageList
        Me.spritesListView.Location = New System.Drawing.Point(0, 25)
        Me.spritesListView.Name = "spritesListView"
        Me.spritesListView.Size = New System.Drawing.Size(358, 197)
        Me.spritesListView.TabIndex = 0
        Me.spritesListView.UseCompatibleStateImageBehavior = False
        '
        'spriteContextMenuStrip
        '
        Me.spriteContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeToolStripMenuItem, Me.ToolStripSeparator14, Me.ExportToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.spriteContextMenuStrip.Name = "spriteContextMenuStrip"
        Me.spriteContextMenuStrip.Size = New System.Drawing.Size(125, 76)
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.folder_image1
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ChangeToolStripMenuItem.Text = "Change..."
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(121, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.save_close
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.TranslaTale.My.Resources.Resources.bin
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'spritesImageList
        '
        Me.spritesImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.spritesImageList.ImageSize = New System.Drawing.Size(48, 48)
        Me.spritesImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AllowItemReorder = True
        Me.ToolStrip3.BackColor = System.Drawing.Color.White
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip3.Size = New System.Drawing.Size(358, 25)
        Me.ToolStrip3.TabIndex = 1
        Me.ToolStrip3.Text = "Edit"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChooseSpritesToolStripMenuItem, Me.FromFolderToolStripMenuItem, Me.FromUndertaleToolStripMenuItem})
        Me.ToolStripButton6.Image = Global.TranslaTale.My.Resources.Resources.plus
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripButton6.Text = "Add sprites..."
        '
        'ChooseSpritesToolStripMenuItem
        '
        Me.ChooseSpritesToolStripMenuItem.Name = "ChooseSpritesToolStripMenuItem"
        Me.ChooseSpritesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ChooseSpritesToolStripMenuItem.Text = "Choose sprites..."
        '
        'FromFolderToolStripMenuItem
        '
        Me.FromFolderToolStripMenuItem.Name = "FromFolderToolStripMenuItem"
        Me.FromFolderToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FromFolderToolStripMenuItem.Text = "From folder..."
        '
        'FromUndertaleToolStripMenuItem
        '
        Me.FromUndertaleToolStripMenuItem.Name = "FromUndertaleToolStripMenuItem"
        Me.FromUndertaleToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FromUndertaleToolStripMenuItem.Text = "From Undertale"
        '
        'projectmanagerPnl
        '
        Me.projectmanagerPnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox16)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel6)
        Me.projectmanagerPnl.Controls.Add(Me.TextBox2)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox15)
        Me.projectmanagerPnl.Controls.Add(Me.useDefaultStringsBtn)
        Me.projectmanagerPnl.Controls.Add(Me.Panel5)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox14)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel7)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox13)
        Me.projectmanagerPnl.Controls.Add(Me.useDefaultSpritesBtn)
        Me.projectmanagerPnl.Controls.Add(Me.Panel4)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox12)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel5)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox11)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel4)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox10)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel3)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox9)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel2)
        Me.projectmanagerPnl.Controls.Add(Me.PictureBox8)
        Me.projectmanagerPnl.Controls.Add(Me.LinkLabel1)
        Me.projectmanagerPnl.Controls.Add(Me.Label9)
        Me.projectmanagerPnl.Location = New System.Drawing.Point(62, 14)
        Me.projectmanagerPnl.Name = "projectmanagerPnl"
        Me.projectmanagerPnl.Size = New System.Drawing.Size(490, 298)
        Me.projectmanagerPnl.TabIndex = 12
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(193, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 25
        Me.TextBox2.Text = "Rename project"
        Me.TextBox2.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = Global.TranslaTale.My.Resources.Resources.file_extension_txt
        Me.PictureBox15.Location = New System.Drawing.Point(196, 35)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox15.TabIndex = 24
        Me.PictureBox15.TabStop = False
        '
        'useDefaultStringsBtn
        '
        Me.useDefaultStringsBtn.AutoSize = True
        Me.useDefaultStringsBtn.Enabled = False
        Me.useDefaultStringsBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.useDefaultStringsBtn.Location = New System.Drawing.Point(233, 46)
        Me.useDefaultStringsBtn.Name = "useDefaultStringsBtn"
        Me.useDefaultStringsBtn.Size = New System.Drawing.Size(146, 13)
        Me.useDefaultStringsBtn.TabIndex = 23
        Me.useDefaultStringsBtn.TabStop = True
        Me.useDefaultStringsBtn.Text = "Use default original Strings.txt"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Location = New System.Drawing.Point(3, 73)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(484, 1)
        Me.Panel5.TabIndex = 19
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = Global.TranslaTale.My.Resources.Resources.game_monitor
        Me.PictureBox14.Location = New System.Drawing.Point(9, 35)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox14.TabIndex = 22
        Me.PictureBox14.TabStop = False
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel7.Location = New System.Drawing.Point(46, 46)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(94, 13)
        Me.LinkLabel7.TabIndex = 21
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Import Undertale..."
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = Global.TranslaTale.My.Resources.Resources.file_extension_png
        Me.PictureBox13.Location = New System.Drawing.Point(385, 35)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox13.TabIndex = 20
        Me.PictureBox13.TabStop = False
        '
        'useDefaultSpritesBtn
        '
        Me.useDefaultSpritesBtn.AutoSize = True
        Me.useDefaultSpritesBtn.Enabled = False
        Me.useDefaultSpritesBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.useDefaultSpritesBtn.Location = New System.Drawing.Point(422, 46)
        Me.useDefaultSpritesBtn.Name = "useDefaultSpritesBtn"
        Me.useDefaultSpritesBtn.Size = New System.Drawing.Size(94, 13)
        Me.useDefaultSpritesBtn.TabIndex = 19
        Me.useDefaultSpritesBtn.TabStop = True
        Me.useDefaultSpritesBtn.Text = "Use default sprites"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Location = New System.Drawing.Point(3, 194)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(484, 1)
        Me.Panel4.TabIndex = 18
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = Global.TranslaTale.My.Resources.Resources.folder_image
        Me.PictureBox12.Location = New System.Drawing.Point(9, 239)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox12.TabIndex = 17
        Me.PictureBox12.TabStop = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel5.Location = New System.Drawing.Point(46, 250)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(130, 13)
        Me.LinkLabel5.TabIndex = 2
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Import sprites from folder..."
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = Global.TranslaTale.My.Resources.Resources.inbox_slide1
        Me.PictureBox11.Location = New System.Drawing.Point(9, 201)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox11.TabIndex = 17
        Me.PictureBox11.TabStop = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel4.Location = New System.Drawing.Point(46, 212)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(78, 13)
        Me.LinkLabel4.TabIndex = 2
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Import sprites..."
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = Global.TranslaTale.My.Resources.Resources.edit_diff
        Me.PictureBox10.Location = New System.Drawing.Point(9, 156)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox10.TabIndex = 17
        Me.PictureBox10.TabStop = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel3.Location = New System.Drawing.Point(46, 167)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(58, 13)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Edit strings"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.TranslaTale.My.Resources.Resources.inbox_document_text
        Me.PictureBox9.Location = New System.Drawing.Point(9, 118)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox9.TabIndex = 15
        Me.PictureBox9.TabStop = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel2.Location = New System.Drawing.Point(46, 129)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(159, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Import translated Strings.txt file..."
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.TranslaTale.My.Resources.Resources.inbox_document
        Me.PictureBox8.Location = New System.Drawing.Point(9, 80)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox8.TabIndex = 13
        Me.PictureBox8.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(46, 91)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(146, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Import original Strings.txt file..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(194, 32)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Unnamed project"
        '
        'welcomePnl
        '
        Me.welcomePnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.welcomePnl.Controls.Add(Me.Panel3)
        Me.welcomePnl.Controls.Add(Me.PictureBox3)
        Me.welcomePnl.Controls.Add(Me.Panel6)
        Me.welcomePnl.Controls.Add(Me.PictureBox7)
        Me.welcomePnl.Controls.Add(Me.infoBtn)
        Me.welcomePnl.Controls.Add(Me.PictureBox6)
        Me.welcomePnl.Controls.Add(Me.migrationToolBtn)
        Me.welcomePnl.Controls.Add(Me.PictureBox5)
        Me.welcomePnl.Controls.Add(Me.compareMainBtn)
        Me.welcomePnl.Controls.Add(Me.PictureBox2)
        Me.welcomePnl.Controls.Add(Me.PictureBox1)
        Me.welcomePnl.Controls.Add(Me.openProjectBtn)
        Me.welcomePnl.Controls.Add(Me.newProjectBtn)
        Me.welcomePnl.Controls.Add(Me.Label12)
        Me.welcomePnl.Location = New System.Drawing.Point(558, 138)
        Me.welcomePnl.Name = "welcomePnl"
        Me.welcomePnl.Size = New System.Drawing.Size(81, 101)
        Me.welcomePnl.TabIndex = 13
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.TranslaTale.My.Resources.Resources.information
        Me.PictureBox7.Location = New System.Drawing.Point(10, 187)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox7.TabIndex = 11
        Me.PictureBox7.TabStop = False
        '
        'infoBtn
        '
        Me.infoBtn.AutoSize = True
        Me.infoBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.infoBtn.Location = New System.Drawing.Point(47, 198)
        Me.infoBtn.Name = "infoBtn"
        Me.infoBtn.Size = New System.Drawing.Size(35, 13)
        Me.infoBtn.TabIndex = 4
        Me.infoBtn.TabStop = True
        Me.infoBtn.Text = "About"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.TranslaTale.My.Resources.Resources.translation_tool_tip
        Me.PictureBox6.Location = New System.Drawing.Point(10, 149)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox6.TabIndex = 9
        Me.PictureBox6.TabStop = False
        '
        'migrationToolBtn
        '
        Me.migrationToolBtn.AutoSize = True
        Me.migrationToolBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.migrationToolBtn.Location = New System.Drawing.Point(47, 160)
        Me.migrationToolBtn.Name = "migrationToolBtn"
        Me.migrationToolBtn.Size = New System.Drawing.Size(162, 13)
        Me.migrationToolBtn.TabIndex = 3
        Me.migrationToolBtn.TabStop = True
        Me.migrationToolBtn.Text = "Migration tool (from v1 to v1.001)"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.TranslaTale.My.Resources.Resources.compare1
        Me.PictureBox5.Location = New System.Drawing.Point(10, 111)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = False
        '
        'compareMainBtn
        '
        Me.compareMainBtn.AutoSize = True
        Me.compareMainBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.compareMainBtn.Location = New System.Drawing.Point(47, 122)
        Me.compareMainBtn.Name = "compareMainBtn"
        Me.compareMainBtn.Size = New System.Drawing.Size(118, 13)
        Me.compareMainBtn.TabIndex = 2
        Me.compareMainBtn.TabStop = True
        Me.compareMainBtn.Text = "Compare two projects..."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, -38)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(81, 26)
        Me.Panel3.TabIndex = 7
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox3.Image = Global.TranslaTale.My.Resources.Resources.icon_8SA_icon
        Me.PictureBox3.Location = New System.Drawing.Point(0, -12)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(81, 87)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TranslaTale.My.Resources.Resources.next_comment
        Me.PictureBox2.Location = New System.Drawing.Point(10, 73)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TranslaTale.My.Resources.Resources.new_comment
        Me.PictureBox1.Location = New System.Drawing.Point(8, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'openProjectBtn
        '
        Me.openProjectBtn.AutoSize = True
        Me.openProjectBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.openProjectBtn.Location = New System.Drawing.Point(47, 84)
        Me.openProjectBtn.Name = "openProjectBtn"
        Me.openProjectBtn.Size = New System.Drawing.Size(77, 13)
        Me.openProjectBtn.TabIndex = 1
        Me.openProjectBtn.TabStop = True
        Me.openProjectBtn.Text = "Open project..."
        '
        'newProjectBtn
        '
        Me.newProjectBtn.AutoSize = True
        Me.newProjectBtn.LinkColor = System.Drawing.Color.DodgerBlue
        Me.newProjectBtn.Location = New System.Drawing.Point(47, 46)
        Me.newProjectBtn.Name = "newProjectBtn"
        Me.newProjectBtn.Size = New System.Drawing.Size(73, 13)
        Me.newProjectBtn.TabIndex = 0
        Me.newProjectBtn.TabStop = True
        Me.newProjectBtn.Text = "New project..."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 32)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Welcome"
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitMain.Location = New System.Drawing.Point(0, 88)
        Me.splitMain.Margin = New System.Windows.Forms.Padding(0)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.MainViewPanel)
        Me.splitMain.Panel1.Controls.Add(Me.bottomPnl)
        Me.splitMain.Panel1MinSize = 573
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.splitRight)
        Me.splitMain.Panel2MinSize = 184
        Me.splitMain.Size = New System.Drawing.Size(854, 556)
        Me.splitMain.SplitterDistance = 666
        Me.splitMain.TabIndex = 61
        '
        'bottomPnl
        '
        Me.bottomPnl.Controls.Add(Me.cbFonts)
        Me.bottomPnl.Controls.Add(Me.rbFacebox)
        Me.bottomPnl.Controls.Add(Me.rbTextbox)
        Me.bottomPnl.Controls.Add(Me.TableLayoutPanel1)
        Me.bottomPnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomPnl.Location = New System.Drawing.Point(0, 361)
        Me.bottomPnl.Margin = New System.Windows.Forms.Padding(0)
        Me.bottomPnl.Name = "bottomPnl"
        Me.bottomPnl.Size = New System.Drawing.Size(666, 195)
        Me.bottomPnl.TabIndex = 62
        '
        'cbFonts
        '
        Me.cbFonts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFonts.FormattingEnabled = True
        Me.cbFonts.Items.AddRange(New Object() {"BitOperator", "ComicSans", "Papyrus"})
        Me.cbFonts.Location = New System.Drawing.Point(529, 2)
        Me.cbFonts.Name = "cbFonts"
        Me.cbFonts.Size = New System.Drawing.Size(121, 21)
        Me.cbFonts.TabIndex = 57
        '
        'rbFacebox
        '
        Me.rbFacebox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbFacebox.AutoSize = True
        Me.rbFacebox.ForeColor = System.Drawing.Color.Black
        Me.rbFacebox.Location = New System.Drawing.Point(84, 5)
        Me.rbFacebox.Name = "rbFacebox"
        Me.rbFacebox.Size = New System.Drawing.Size(112, 17)
        Me.rbFacebox.TabIndex = 56
        Me.rbFacebox.Text = "Text box with face"
        Me.rbFacebox.UseVisualStyleBackColor = True
        '
        'rbTextbox
        '
        Me.rbTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbTextbox.AutoSize = True
        Me.rbTextbox.Checked = True
        Me.rbTextbox.ForeColor = System.Drawing.Color.Black
        Me.rbTextbox.Location = New System.Drawing.Point(12, 5)
        Me.rbTextbox.Name = "rbTextbox"
        Me.rbTextbox.Size = New System.Drawing.Size(66, 17)
        Me.rbTextbox.TabIndex = 55
        Me.rbTextbox.TabStop = True
        Me.rbTextbox.Text = "Text box"
        Me.rbTextbox.UseVisualStyleBackColor = True
        '
        'splitRight
        '
        Me.splitRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitRight.Location = New System.Drawing.Point(0, 0)
        Me.splitRight.Margin = New System.Windows.Forms.Padding(0)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitRight.Panel1
        '
        Me.splitRight.Panel1.Controls.Add(Me.pnlGroups)
        Me.splitRight.Panel1MinSize = 228
        '
        'splitRight.Panel2
        '
        Me.splitRight.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.splitRight.Panel2.Controls.Add(Me.Panel2)
        Me.splitRight.Panel2MinSize = 226
        Me.splitRight.Size = New System.Drawing.Size(184, 556)
        Me.splitRight.SplitterDistance = 228
        Me.splitRight.TabIndex = 2
        '
        'pnlGroups
        '
        Me.pnlGroups.Controls.Add(Me.btnEditGroup)
        Me.pnlGroups.Controls.Add(Me.btnDeleteGroup)
        Me.pnlGroups.Controls.Add(Me.btnCreateGroup)
        Me.pnlGroups.Controls.Add(Me.btnSetGroup)
        Me.pnlGroups.Controls.Add(Me.Label10)
        Me.pnlGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGroups.Location = New System.Drawing.Point(0, 0)
        Me.pnlGroups.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlGroups.Name = "pnlGroups"
        Me.pnlGroups.Size = New System.Drawing.Size(184, 228)
        Me.pnlGroups.TabIndex = 1
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditGroup.Image = Global.TranslaTale.My.Resources.Resources.tag_blue_edit
        Me.btnEditGroup.Location = New System.Drawing.Point(9, 176)
        Me.btnEditGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Size = New System.Drawing.Size(163, 41)
        Me.btnEditGroup.TabIndex = 4
        Me.btnEditGroup.Text = "Edit group"
        Me.btnEditGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditGroup.UseVisualStyleBackColor = True
        '
        'btnDeleteGroup
        '
        Me.btnDeleteGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteGroup.Image = Global.TranslaTale.My.Resources.Resources.tag_blue_delete
        Me.btnDeleteGroup.Location = New System.Drawing.Point(9, 129)
        Me.btnDeleteGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDeleteGroup.Name = "btnDeleteGroup"
        Me.btnDeleteGroup.Size = New System.Drawing.Size(163, 41)
        Me.btnDeleteGroup.TabIndex = 3
        Me.btnDeleteGroup.Text = "Delete group"
        Me.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteGroup.UseVisualStyleBackColor = True
        '
        'btnCreateGroup
        '
        Me.btnCreateGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateGroup.Image = Global.TranslaTale.My.Resources.Resources.tag_blue_add
        Me.btnCreateGroup.Location = New System.Drawing.Point(9, 82)
        Me.btnCreateGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCreateGroup.Name = "btnCreateGroup"
        Me.btnCreateGroup.Size = New System.Drawing.Size(163, 41)
        Me.btnCreateGroup.TabIndex = 2
        Me.btnCreateGroup.Text = "Create group"
        Me.btnCreateGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCreateGroup.UseVisualStyleBackColor = True
        '
        'btnSetGroup
        '
        Me.btnSetGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetGroup.Image = Global.TranslaTale.My.Resources.Resources.tag_green
        Me.btnSetGroup.Location = New System.Drawing.Point(9, 35)
        Me.btnSetGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSetGroup.Name = "btnSetGroup"
        Me.btnSetGroup.Size = New System.Drawing.Size(163, 41)
        Me.btnSetGroup.TabIndex = 1
        Me.btnSetGroup.Text = "Set group"
        Me.btnSetGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetGroup.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 32)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Groups"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.componentsList)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.TranslationPercentageBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 324)
        Me.Panel2.TabIndex = 2
        '
        'componentsList
        '
        Me.componentsList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.componentsList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.componentsList.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.componentsList.Enabled = False
        Me.componentsList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        ListViewItem1.Tag = "Undertale"
        ListViewItem2.Tag = "data.win"
        ListViewItem3.Tag = "Sprites"
        ListViewItem4.Tag = "Original"
        ListViewItem5.Tag = "Translated"
        Me.componentsList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5})
        Me.componentsList.Location = New System.Drawing.Point(9, 201)
        Me.componentsList.Name = "componentsList"
        Me.componentsList.Scrollable = False
        Me.componentsList.Size = New System.Drawing.Size(166, 113)
        Me.componentsList.SmallImageList = Me.ImageList1
        Me.componentsList.TabIndex = 21
        Me.componentsList.UseCompatibleStateImageBehavior = False
        Me.componentsList.View = System.Windows.Forms.View.List
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "delete.png")
        Me.ImageList1.Images.SetKeyName(1, "accept_button.png")
        Me.ImageList1.Images.SetKeyName(2, "error.png")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 32)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Project info"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 32)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "File info"
        '
        'topPnl
        '
        Me.topPnl.BackColor = System.Drawing.Color.White
        Me.topPnl.Controls.Add(Me.TableLayoutPanel2)
        Me.topPnl.Controls.Add(Me.FlowLayoutPanel1)
        Me.topPnl.Controls.Add(Me.ToolStrip1)
        Me.topPnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.topPnl.Location = New System.Drawing.Point(0, 0)
        Me.topPnl.Margin = New System.Windows.Forms.Padding(0)
        Me.topPnl.Name = "topPnl"
        Me.topPnl.Size = New System.Drawing.Size(854, 88)
        Me.topPnl.TabIndex = 12
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel7)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel9)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel8)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 63)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(854, 25)
        Me.FlowLayoutPanel1.TabIndex = 57
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.MintCream
        Me.FlowLayoutPanel2.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(122, 25)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.BackColor = System.Drawing.Color.MistyRose
        Me.FlowLayoutPanel5.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel5.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(122, 0)
        Me.FlowLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(124, 25)
        Me.FlowLayoutPanel5.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "My project"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.LightCyan
        Me.FlowLayoutPanel3.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel3.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(246, 0)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(76, 25)
        Me.FlowLayoutPanel3.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Search"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.BackColor = System.Drawing.Color.Honeydew
        Me.FlowLayoutPanel4.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel4.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(322, 0)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(139, 25)
        Me.FlowLayoutPanel4.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tools"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.FlowLayoutPanel7.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel7.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(461, 0)
        Me.FlowLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(50, 25)
        Me.FlowLayoutPanel7.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 25)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sort"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.BackColor = System.Drawing.Color.PapayaWhip
        Me.FlowLayoutPanel9.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel9.Controls.Add(Me.Label13)
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(511, 0)
        Me.FlowLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(51, 25)
        Me.FlowLayoutPanel9.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 25)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "View"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.BackColor = System.Drawing.Color.Azure
        Me.FlowLayoutPanel8.BackgroundImage = Global.TranslaTale.My.Resources.Resources.ttxbgfooter
        Me.FlowLayoutPanel8.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(562, 0)
        Me.FlowLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(42, 25)
        Me.FlowLayoutPanel8.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "About"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialogMulti
        '
        Me.OpenFileDialogMulti.Multiselect = True
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = Global.TranslaTale.My.Resources.Resources.image_edit
        Me.PictureBox16.Location = New System.Drawing.Point(9, 277)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox16.TabIndex = 27
        Me.PictureBox16.TabStop = False
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel6.Location = New System.Drawing.Point(46, 288)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(58, 13)
        Me.LinkLabel6.TabIndex = 26
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Edit sprites"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 75)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(81, 26)
        Me.Panel6.TabIndex = 12
        '
        'TranslationPercentageBox1
        '
        Me.TranslationPercentageBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TranslationPercentageBox1.LeftValue = 0R
        Me.TranslationPercentageBox1.Location = New System.Drawing.Point(9, 36)
        Me.TranslationPercentageBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.TranslationPercentageBox1.MinimumSize = New System.Drawing.Size(150, 85)
        Me.TranslationPercentageBox1.Name = "TranslationPercentageBox1"
        Me.TranslationPercentageBox1.RightValue = 0R
        Me.TranslationPercentageBox1.SelectedPercentage = TranslaTale.TranslationPercentageBox.Percentage.All
        Me.TranslationPercentageBox1.Size = New System.Drawing.Size(166, 162)
        Me.TranslationPercentageBox1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(854, 644)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.topPnl)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(870, 585)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TranslaTale"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.SpriteFontBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.tblEditor.ResumeLayout(False)
        Me.tblEditor.PerformLayout()
        CType(Me.ResetBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainViewPanel.ResumeLayout(False)
        Me.spritesPnl.ResumeLayout(False)
        Me.spritesPnl.PerformLayout()
        Me.spriteContextMenuStrip.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.projectmanagerPnl.ResumeLayout(False)
        Me.projectmanagerPnl.PerformLayout()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.welcomePnl.ResumeLayout(False)
        Me.welcomePnl.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.bottomPnl.ResumeLayout(False)
        Me.bottomPnl.PerformLayout()
        Me.splitRight.Panel1.ResumeLayout(False)
        Me.splitRight.Panel2.ResumeLayout(False)
        CType(Me.splitRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitRight.ResumeLayout(False)
        Me.pnlGroups.ResumeLayout(False)
        Me.pnlGroups.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.topPnl.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel9.ResumeLayout(False)
        Me.FlowLayoutPanel8.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents stringTextEditor As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents searchToolStripBtn As System.Windows.Forms.ToolStripButton
    Friend WithEvents goToLineToolStripBtn As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ResetBtn As PictureBox
    Friend WithEvents OptionsToolStripMenuItem As ToolStripDropDownButton
    Friend WithEvents AboutToolStripMenuItem As ToolStripButton
    Friend WithEvents ShowSymbolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents CompareTranslationFilesToolStripMenuItem As ToolStripButton
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents filtermenubtn As ToolStripDropDownButton
    Friend WithEvents filterByGroupBtn As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TranslatedStringsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UntranslatedStringsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ClearFilterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel8 As FlowLayoutPanel
    Friend WithEvents SpriteFontBox1 As UTSpriteFontBox.SpriteFontBox
    Friend WithEvents UDTPatchToolStripMenuItem As ToolStripDropDownButton
    Friend WithEvents UndertalePatchToolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents DumpStringstxtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DumpOriginalImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents RepackGameASCIICharactersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepackGamecustomFontsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MigrationToolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ttipMenu As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents tblEditor As TableLayoutPanel
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents pnlGroups As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents splitRight As SplitContainer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents btnEditGroup As Button
    Friend WithEvents btnDeleteGroup As Button
    Friend WithEvents btnCreateGroup As Button
    Friend WithEvents btnSetGroup As Button
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TranslationPercentageBox1 As TranslationPercentageBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents MainViewPanel As Panel
    Public WithEvents stringsPnl As ListView
    Friend WithEvents topPnl As Panel
    Friend WithEvents bottomPnl As Panel
    Friend WithEvents cbFonts As ComboBox
    Friend WithEvents rbFacebox As RadioButton
    Friend WithEvents rbTextbox As RadioButton
    Friend WithEvents projectmanagerPnl As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents welcomePnl As Panel
    Friend WithEvents openProjectBtn As LinkLabel
    Friend WithEvents newProjectBtn As LinkLabel
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents projectManagerToolBtn As ToolStripButton
    Friend WithEvents stringsEditorToolBtn As ToolStripButton
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents compareMainBtn As LinkLabel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents migrationToolBtn As LinkLabel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents infoBtn As LinkLabel
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents newProjectToolStripBtn As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents FlowLayoutPanel9 As FlowLayoutPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents openProjectBtn2 As ToolStripSplitButton
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents LastestFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents useDefaultSpritesBtn As LinkLabel
    Friend WithEvents componentsList As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox14 As PictureBox
    Friend WithEvents LinkLabel7 As LinkLabel
    Friend WithEvents PictureBox15 As PictureBox
    Friend WithEvents useDefaultStringsBtn As LinkLabel
    Friend WithEvents OpenFileDialogMulti As OpenFileDialog
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents debugToolBtn As ToolStripButton
    Friend WithEvents spritesPnl As Panel
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents spritesEditorToolBtn As ToolStripButton
    Friend WithEvents spritesListView As ListView
    Friend WithEvents spritesImageList As ImageList
    Friend WithEvents spriteContextMenuStrip As ContextMenuStrip
    Friend WithEvents ChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton6 As ToolStripDropDownButton
    Friend WithEvents ChooseSpritesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromUndertaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox16 As PictureBox
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents Panel6 As Panel
End Class
