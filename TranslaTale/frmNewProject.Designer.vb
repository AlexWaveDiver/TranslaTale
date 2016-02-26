<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewProject
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProject))
        Me.tabModeSelect = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFolder2 = New System.Windows.Forms.Button()
        Me.btnFolder1 = New System.Windows.Forms.Button()
        Me.lblFolder2 = New System.Windows.Forms.Label()
        Me.txtFolder2 = New System.Windows.Forms.TextBox()
        Me.lblFolder1 = New System.Windows.Forms.Label()
        Me.txtFolder1 = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grpFiles = New System.Windows.Forms.GroupBox()
        Me.btnFile4 = New System.Windows.Forms.Button()
        Me.lblFile4 = New System.Windows.Forms.Label()
        Me.txtFile4 = New System.Windows.Forms.TextBox()
        Me.btnFile3 = New System.Windows.Forms.Button()
        Me.lblFile3 = New System.Windows.Forms.Label()
        Me.txtFile3 = New System.Windows.Forms.TextBox()
        Me.btnFile2 = New System.Windows.Forms.Button()
        Me.btnFile1 = New System.Windows.Forms.Button()
        Me.lblFile2 = New System.Windows.Forms.Label()
        Me.txtFile2 = New System.Windows.Forms.TextBox()
        Me.lblFile1 = New System.Windows.Forms.Label()
        Me.txtFile1 = New System.Windows.Forms.TextBox()
        Me.lblName2 = New System.Windows.Forms.Label()
        Me.txtName2 = New System.Windows.Forms.TextBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.imgAbout = New System.Windows.Forms.PictureBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.tabModeSelect.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grpFiles.SuspendLayout()
        CType(Me.imgAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabModeSelect
        '
        Me.tabModeSelect.Controls.Add(Me.TabPage1)
        Me.tabModeSelect.Controls.Add(Me.TabPage2)
        Me.tabModeSelect.Location = New System.Drawing.Point(118, 12)
        Me.tabModeSelect.Name = "tabModeSelect"
        Me.tabModeSelect.SelectedIndex = 0
        Me.tabModeSelect.Size = New System.Drawing.Size(334, 237)
        Me.tabModeSelect.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.lblName)
        Me.TabPage1.Controls.Add(Me.txtName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(326, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decompile"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFolder2)
        Me.GroupBox1.Controls.Add(Me.btnFolder1)
        Me.GroupBox1.Controls.Add(Me.lblFolder2)
        Me.GroupBox1.Controls.Add(Me.txtFolder2)
        Me.GroupBox1.Controls.Add(Me.lblFolder1)
        Me.GroupBox1.Controls.Add(Me.txtFolder1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 95)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Directories"
        '
        'btnFolder2
        '
        Me.btnFolder2.Location = New System.Drawing.Point(255, 49)
        Me.btnFolder2.Name = "btnFolder2"
        Me.btnFolder2.Size = New System.Drawing.Size(24, 20)
        Me.btnFolder2.TabIndex = 9
        Me.btnFolder2.Text = "..."
        Me.btnFolder2.UseVisualStyleBackColor = True
        '
        'btnFolder1
        '
        Me.btnFolder1.Location = New System.Drawing.Point(255, 22)
        Me.btnFolder1.Name = "btnFolder1"
        Me.btnFolder1.Size = New System.Drawing.Size(24, 20)
        Me.btnFolder1.TabIndex = 8
        Me.btnFolder1.Text = "..."
        Me.btnFolder1.UseVisualStyleBackColor = True
        '
        'lblFolder2
        '
        Me.lblFolder2.AutoSize = True
        Me.lblFolder2.Location = New System.Drawing.Point(24, 52)
        Me.lblFolder2.Name = "lblFolder2"
        Me.lblFolder2.Size = New System.Drawing.Size(75, 13)
        Me.lblFolder2.TabIndex = 6
        Me.lblFolder2.Text = "Project Folder:"
        '
        'txtFolder2
        '
        Me.txtFolder2.Location = New System.Drawing.Point(105, 49)
        Me.txtFolder2.Name = "txtFolder2"
        Me.txtFolder2.Size = New System.Drawing.Size(144, 20)
        Me.txtFolder2.TabIndex = 5
        '
        'lblFolder1
        '
        Me.lblFolder1.AutoSize = True
        Me.lblFolder1.Location = New System.Drawing.Point(11, 26)
        Me.lblFolder1.Name = "lblFolder1"
        Me.lblFolder1.Size = New System.Drawing.Size(88, 13)
        Me.lblFolder1.TabIndex = 4
        Me.lblFolder1.Text = "Undertale Folder:"
        '
        'txtFolder1
        '
        Me.txtFolder1.Location = New System.Drawing.Point(105, 22)
        Me.txtFolder1.Name = "txtFolder1"
        Me.txtFolder1.Size = New System.Drawing.Size(144, 20)
        Me.txtFolder1.TabIndex = 3
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(14, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Project name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(17, 28)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(292, 20)
        Me.txtName.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpFiles)
        Me.TabPage2.Controls.Add(Me.lblName2)
        Me.TabPage2.Controls.Add(Me.txtName2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(326, 211)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Create from existing files"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grpFiles
        '
        Me.grpFiles.Controls.Add(Me.btnFile4)
        Me.grpFiles.Controls.Add(Me.lblFile4)
        Me.grpFiles.Controls.Add(Me.txtFile4)
        Me.grpFiles.Controls.Add(Me.btnFile3)
        Me.grpFiles.Controls.Add(Me.lblFile3)
        Me.grpFiles.Controls.Add(Me.txtFile3)
        Me.grpFiles.Controls.Add(Me.btnFile2)
        Me.grpFiles.Controls.Add(Me.btnFile1)
        Me.grpFiles.Controls.Add(Me.lblFile2)
        Me.grpFiles.Controls.Add(Me.txtFile2)
        Me.grpFiles.Controls.Add(Me.lblFile1)
        Me.grpFiles.Controls.Add(Me.txtFile1)
        Me.grpFiles.Location = New System.Drawing.Point(17, 61)
        Me.grpFiles.Name = "grpFiles"
        Me.grpFiles.Size = New System.Drawing.Size(293, 133)
        Me.grpFiles.TabIndex = 4
        Me.grpFiles.TabStop = False
        Me.grpFiles.Text = "Data files"
        '
        'btnFile4
        '
        Me.btnFile4.Location = New System.Drawing.Point(255, 101)
        Me.btnFile4.Name = "btnFile4"
        Me.btnFile4.Size = New System.Drawing.Size(24, 20)
        Me.btnFile4.TabIndex = 15
        Me.btnFile4.Text = "..."
        Me.btnFile4.UseVisualStyleBackColor = True
        '
        'lblFile4
        '
        Me.lblFile4.AutoSize = True
        Me.lblFile4.Location = New System.Drawing.Point(26, 104)
        Me.lblFile4.Name = "lblFile4"
        Me.lblFile4.Size = New System.Drawing.Size(73, 13)
        Me.lblFile4.TabIndex = 14
        Me.lblFile4.Text = "Images folder:"
        '
        'txtFile4
        '
        Me.txtFile4.Location = New System.Drawing.Point(105, 101)
        Me.txtFile4.Name = "txtFile4"
        Me.txtFile4.Size = New System.Drawing.Size(144, 20)
        Me.txtFile4.TabIndex = 13
        '
        'btnFile3
        '
        Me.btnFile3.Location = New System.Drawing.Point(255, 75)
        Me.btnFile3.Name = "btnFile3"
        Me.btnFile3.Size = New System.Drawing.Size(24, 20)
        Me.btnFile3.TabIndex = 12
        Me.btnFile3.Text = "..."
        Me.btnFile3.UseVisualStyleBackColor = True
        '
        'lblFile3
        '
        Me.lblFile3.AutoSize = True
        Me.lblFile3.Location = New System.Drawing.Point(11, 78)
        Me.lblFile3.Name = "lblFile3"
        Me.lblFile3.Size = New System.Drawing.Size(88, 13)
        Me.lblFile3.TabIndex = 11
        Me.lblFile3.Text = "Translated script:"
        '
        'txtFile3
        '
        Me.txtFile3.Location = New System.Drawing.Point(105, 75)
        Me.txtFile3.Name = "txtFile3"
        Me.txtFile3.Size = New System.Drawing.Size(144, 20)
        Me.txtFile3.TabIndex = 10
        '
        'btnFile2
        '
        Me.btnFile2.Location = New System.Drawing.Point(255, 49)
        Me.btnFile2.Name = "btnFile2"
        Me.btnFile2.Size = New System.Drawing.Size(24, 20)
        Me.btnFile2.TabIndex = 9
        Me.btnFile2.Text = "..."
        Me.btnFile2.UseVisualStyleBackColor = True
        '
        'btnFile1
        '
        Me.btnFile1.Location = New System.Drawing.Point(255, 22)
        Me.btnFile1.Name = "btnFile1"
        Me.btnFile1.Size = New System.Drawing.Size(24, 20)
        Me.btnFile1.TabIndex = 8
        Me.btnFile1.Text = "..."
        Me.btnFile1.UseVisualStyleBackColor = True
        '
        'lblFile2
        '
        Me.lblFile2.AutoSize = True
        Me.lblFile2.Location = New System.Drawing.Point(34, 52)
        Me.lblFile2.Name = "lblFile2"
        Me.lblFile2.Size = New System.Drawing.Size(65, 13)
        Me.lblFile2.TabIndex = 6
        Me.lblFile2.Text = "Clean script:"
        '
        'txtFile2
        '
        Me.txtFile2.Location = New System.Drawing.Point(105, 49)
        Me.txtFile2.Name = "txtFile2"
        Me.txtFile2.Size = New System.Drawing.Size(144, 20)
        Me.txtFile2.TabIndex = 5
        '
        'lblFile1
        '
        Me.lblFile1.AutoSize = True
        Me.lblFile1.Location = New System.Drawing.Point(11, 26)
        Me.lblFile1.Name = "lblFile1"
        Me.lblFile1.Size = New System.Drawing.Size(88, 13)
        Me.lblFile1.TabIndex = 4
        Me.lblFile1.Text = "Undertale Folder:"
        '
        'txtFile1
        '
        Me.txtFile1.Location = New System.Drawing.Point(105, 22)
        Me.txtFile1.Name = "txtFile1"
        Me.txtFile1.Size = New System.Drawing.Size(144, 20)
        Me.txtFile1.TabIndex = 3
        '
        'lblName2
        '
        Me.lblName2.AutoSize = True
        Me.lblName2.Location = New System.Drawing.Point(14, 12)
        Me.lblName2.Name = "lblName2"
        Me.lblName2.Size = New System.Drawing.Size(72, 13)
        Me.lblName2.TabIndex = 3
        Me.lblName2.Text = "Project name:"
        '
        'txtName2
        '
        Me.txtName2.Location = New System.Drawing.Point(17, 28)
        Me.txtName2.Name = "txtName2"
        Me.txtName2.Size = New System.Drawing.Size(292, 20)
        Me.txtName2.TabIndex = 2
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(356, 255)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(82, 23)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "Create Project"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 255)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'imgAbout
        '
        Me.imgAbout.Image = Global.TranslaTale.My.Resources.Resources.about2
        Me.imgAbout.Location = New System.Drawing.Point(-2, 0)
        Me.imgAbout.Name = "imgAbout"
        Me.imgAbout.Size = New System.Drawing.Size(123, 248)
        Me.imgAbout.TabIndex = 5
        Me.imgAbout.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.ClientSize = New System.Drawing.Size(450, 288)
        Me.Controls.Add(Me.imgAbout)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.tabModeSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Project"
        Me.tabModeSelect.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.grpFiles.ResumeLayout(False)
        Me.grpFiles.PerformLayout()
        CType(Me.imgAbout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabModeSelect As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblFolder1 As Label
    Friend WithEvents txtFolder1 As TextBox
    Friend WithEvents btnFolder2 As Button
    Friend WithEvents btnFolder1 As Button
    Friend WithEvents lblFolder2 As Label
    Friend WithEvents txtFolder2 As TextBox
    Friend WithEvents btnDone As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents imgAbout As PictureBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents grpFiles As GroupBox
    Friend WithEvents btnFile3 As Button
    Friend WithEvents lblFile3 As Label
    Friend WithEvents txtFile3 As TextBox
    Friend WithEvents btnFile2 As Button
    Friend WithEvents lblFile2 As Label
    Friend WithEvents txtFile2 As TextBox
    Friend WithEvents lblFile1 As Label
    Friend WithEvents txtFile1 As TextBox
    Friend WithEvents lblName2 As Label
    Friend WithEvents txtName2 As TextBox
    Friend WithEvents btnFile4 As Button
    Friend WithEvents txtFile4 As TextBox
    Friend WithEvents lblFile4 As Label
    Friend WithEvents btnFile1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
