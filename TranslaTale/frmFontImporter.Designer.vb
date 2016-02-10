<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFontImporter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFontImporter))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCheck = New System.Windows.Forms.Label()
        Me.lstFontsNotFound = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblRebootTT = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblImages = New System.Windows.Forms.Label()
        Me.btnImages = New System.Windows.Forms.Button()
        Me.lblStrings = New System.Windows.Forms.Label()
        Me.btnStrings = New System.Windows.Forms.Button()
        Me.lblDataWin = New System.Windows.Forms.Label()
        Me.btnOpenDataWin = New System.Windows.Forms.Button()
        Me.btnOpenUTFonts = New System.Windows.Forms.Button()
        Me.lblUTFonts = New System.Windows.Forms.Label()
        Me.ofdPaths = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.fldPaths = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(118, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 314)
        Me.Panel1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(232, 26)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "When you're finished installing GM:S (or if you" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "have installed it already), clic" & _
    "k Next to continue."
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(76, 171)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 38)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "&Download GameMaker: Studio"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(255, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "In order to continue, you'll need GameMaker: Studio." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Don't worry, it's free!"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(277, 60)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "This wizard will help you importing custom fontsheets from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a GameMaker Studio pr" & _
    "oject into Undertale, as well as packaging your strings and graphics assets into" & _
    " a .WIN file."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(335, 327)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "&Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 327)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(254, 327)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "< &Back"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(14, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(269, 33)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Checking installed fonts"
        '
        'lblCheck
        '
        Me.lblCheck.AutoSize = True
        Me.lblCheck.Location = New System.Drawing.Point(18, 57)
        Me.lblCheck.Name = "lblCheck"
        Me.lblCheck.Size = New System.Drawing.Size(128, 13)
        Me.lblCheck.TabIndex = 1
        Me.lblCheck.Text = "Checking installed fonts..."
        '
        'lstFontsNotFound
        '
        Me.lstFontsNotFound.FormattingEnabled = True
        Me.lstFontsNotFound.Location = New System.Drawing.Point(21, 110)
        Me.lstFontsNotFound.Name = "lstFontsNotFound"
        Me.lstFontsNotFound.Size = New System.Drawing.Size(246, 82)
        Me.lstFontsNotFound.TabIndex = 4
        Me.lstFontsNotFound.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblRebootTT)
        Me.Panel2.Controls.Add(Me.lstFontsNotFound)
        Me.Panel2.Controls.Add(Me.lblCheck)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(118, -3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(307, 314)
        Me.Panel2.TabIndex = 5
        Me.Panel2.Visible = False
        '
        'lblRebootTT
        '
        Me.lblRebootTT.AutoSize = True
        Me.lblRebootTT.Location = New System.Drawing.Point(20, 203)
        Me.lblRebootTT.Name = "lblRebootTT"
        Me.lblRebootTT.Size = New System.Drawing.Size(209, 26)
        Me.lblRebootTT.TabIndex = 5
        Me.lblRebootTT.Text = "Once you've installed all the required fonts," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "close and open TranslaTale Again."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.LinkLabel1)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.LinkLabel3)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(118, -3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(311, 315)
        Me.Panel3.TabIndex = 7
        Me.Panel3.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Click Next to continue."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(20, 95)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(30, 13)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Here"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 26)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "         is a video-tutorial about how to prepare your " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "project resources for im" & _
    "porting."
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel3.Location = New System.Drawing.Point(20, 57)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(55, 13)
        Me.LinkLabel3.TabIndex = 10
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Download"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 26)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "                  and open the UTFonts project for" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GameMaker "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(14, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(191, 33)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Preparing assets"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Silver
        Me.Label13.Location = New System.Drawing.Point(14, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 33)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Path config"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.lblImages)
        Me.Panel4.Controls.Add(Me.btnImages)
        Me.Panel4.Controls.Add(Me.lblStrings)
        Me.Panel4.Controls.Add(Me.btnStrings)
        Me.Panel4.Controls.Add(Me.lblDataWin)
        Me.Panel4.Controls.Add(Me.btnOpenDataWin)
        Me.Panel4.Controls.Add(Me.btnOpenUTFonts)
        Me.Panel4.Controls.Add(Me.lblUTFonts)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Location = New System.Drawing.Point(118, -3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(312, 315)
        Me.Panel4.TabIndex = 14
        Me.Panel4.Visible = False
        '
        'lblImages
        '
        Me.lblImages.AutoEllipsis = True
        Me.lblImages.Location = New System.Drawing.Point(19, 281)
        Me.lblImages.Name = "lblImages"
        Me.lblImages.Size = New System.Drawing.Size(274, 24)
        Me.lblImages.TabIndex = 9
        Me.lblImages.Text = "Images: None selected"
        '
        'btnImages
        '
        Me.btnImages.Location = New System.Drawing.Point(20, 251)
        Me.btnImages.Name = "btnImages"
        Me.btnImages.Size = New System.Drawing.Size(142, 23)
        Me.btnImages.TabIndex = 8
        Me.btnImages.Text = "Selec&t Images path"
        Me.btnImages.UseVisualStyleBackColor = True
        '
        'lblStrings
        '
        Me.lblStrings.AutoEllipsis = True
        Me.lblStrings.Location = New System.Drawing.Point(19, 217)
        Me.lblStrings.Name = "lblStrings"
        Me.lblStrings.Size = New System.Drawing.Size(274, 24)
        Me.lblStrings.TabIndex = 7
        Me.lblStrings.Text = "Strings.txt: None selected"
        '
        'btnStrings
        '
        Me.btnStrings.Location = New System.Drawing.Point(20, 173)
        Me.btnStrings.Name = "btnStrings"
        Me.btnStrings.Size = New System.Drawing.Size(142, 38)
        Me.btnStrings.TabIndex = 6
        Me.btnStrings.Text = "Se&lect Strings.txt (translation)"
        Me.btnStrings.UseVisualStyleBackColor = True
        '
        'lblDataWin
        '
        Me.lblDataWin.AutoEllipsis = True
        Me.lblDataWin.Location = New System.Drawing.Point(19, 145)
        Me.lblDataWin.Name = "lblDataWin"
        Me.lblDataWin.Size = New System.Drawing.Size(274, 23)
        Me.lblDataWin.TabIndex = 5
        Me.lblDataWin.Text = "UT Data.win: None selected"
        '
        'btnOpenDataWin
        '
        Me.btnOpenDataWin.Location = New System.Drawing.Point(20, 114)
        Me.btnOpenDataWin.Name = "btnOpenDataWin"
        Me.btnOpenDataWin.Size = New System.Drawing.Size(142, 23)
        Me.btnOpenDataWin.TabIndex = 4
        Me.btnOpenDataWin.Text = "S&elect Undertale data.win"
        Me.btnOpenDataWin.UseVisualStyleBackColor = True
        '
        'btnOpenUTFonts
        '
        Me.btnOpenUTFonts.Location = New System.Drawing.Point(20, 55)
        Me.btnOpenUTFonts.Name = "btnOpenUTFonts"
        Me.btnOpenUTFonts.Size = New System.Drawing.Size(142, 23)
        Me.btnOpenUTFonts.TabIndex = 2
        Me.btnOpenUTFonts.Text = "&Select UTFonts"
        Me.btnOpenUTFonts.UseVisualStyleBackColor = True
        '
        'lblUTFonts
        '
        Me.lblUTFonts.AutoEllipsis = True
        Me.lblUTFonts.Location = New System.Drawing.Point(19, 85)
        Me.lblUTFonts.Name = "lblUTFonts"
        Me.lblUTFonts.Size = New System.Drawing.Size(272, 23)
        Me.lblUTFonts.TabIndex = 1
        Me.lblUTFonts.Text = "UTFonts: None selected"
        '
        'ofdPaths
        '
        Me.ofdPaths.Filter = ".WIN file | *.win"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Image = Global.TranslaTale.My.Resources.Resources.about
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 314)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmFontImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 362)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFontImporter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Repackaging Wizard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCheck As System.Windows.Forms.Label
    Friend WithEvents lstFontsNotFound As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblRebootTT As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnOpenDataWin As System.Windows.Forms.Button
    Friend WithEvents btnOpenUTFonts As System.Windows.Forms.Button
    Friend WithEvents lblUTFonts As System.Windows.Forms.Label
    Friend WithEvents lblDataWin As System.Windows.Forms.Label
    Friend WithEvents ofdPaths As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStrings As System.Windows.Forms.Label
    Friend WithEvents btnStrings As System.Windows.Forms.Button
    Friend WithEvents lblImages As System.Windows.Forms.Label
    Friend WithEvents btnImages As System.Windows.Forms.Button
    Friend WithEvents fldPaths As System.Windows.Forms.FolderBrowserDialog
End Class
