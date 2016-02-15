<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjOptions
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjOptions))
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpPaths = New System.Windows.Forms.GroupBox()
        Me.btnFolder3 = New System.Windows.Forms.Button()
        Me.btnFolder2 = New System.Windows.Forms.Button()
        Me.btnFolder1 = New System.Windows.Forms.Button()
        Me.btnFile2 = New System.Windows.Forms.Button()
        Me.btnFile1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolder3 = New System.Windows.Forms.TextBox()
        Me.txtFolder2 = New System.Windows.Forms.TextBox()
        Me.txtFolder1 = New System.Windows.Forms.TextBox()
        Me.txtFile2 = New System.Windows.Forms.TextBox()
        Me.txtFile1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtFile3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnFile3 = New System.Windows.Forms.Button()
        Me.grpPaths.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(42, 37)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(267, 20)
        Me.txtName.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(39, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Project name:"
        '
        'grpPaths
        '
        Me.grpPaths.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.grpPaths.Controls.Add(Me.btnFile3)
        Me.grpPaths.Controls.Add(Me.Label7)
        Me.grpPaths.Controls.Add(Me.txtFolder3)
        Me.grpPaths.Controls.Add(Me.btnFolder3)
        Me.grpPaths.Controls.Add(Me.btnFolder2)
        Me.grpPaths.Controls.Add(Me.btnFolder1)
        Me.grpPaths.Controls.Add(Me.btnFile2)
        Me.grpPaths.Controls.Add(Me.btnFile1)
        Me.grpPaths.Controls.Add(Me.Label6)
        Me.grpPaths.Controls.Add(Me.Label5)
        Me.grpPaths.Controls.Add(Me.Label4)
        Me.grpPaths.Controls.Add(Me.Label3)
        Me.grpPaths.Controls.Add(Me.Label2)
        Me.grpPaths.Controls.Add(Me.txtFolder2)
        Me.grpPaths.Controls.Add(Me.txtFolder1)
        Me.grpPaths.Controls.Add(Me.txtFile2)
        Me.grpPaths.Controls.Add(Me.txtFile1)
        Me.grpPaths.Controls.Add(Me.txtFile3)
        Me.grpPaths.Location = New System.Drawing.Point(13, 75)
        Me.grpPaths.Name = "grpPaths"
        Me.grpPaths.Size = New System.Drawing.Size(335, 181)
        Me.grpPaths.TabIndex = 8
        Me.grpPaths.TabStop = False
        Me.grpPaths.Text = "File Directories"
        '
        'btnFolder3
        '
        Me.btnFolder3.Location = New System.Drawing.Point(294, 149)
        Me.btnFolder3.Name = "btnFolder3"
        Me.btnFolder3.Size = New System.Drawing.Size(24, 20)
        Me.btnFolder3.TabIndex = 19
        Me.btnFolder3.Text = "..."
        Me.btnFolder3.UseVisualStyleBackColor = True
        '
        'btnFolder2
        '
        Me.btnFolder2.Location = New System.Drawing.Point(294, 123)
        Me.btnFolder2.Name = "btnFolder2"
        Me.btnFolder2.Size = New System.Drawing.Size(24, 20)
        Me.btnFolder2.TabIndex = 18
        Me.btnFolder2.Text = "..."
        Me.btnFolder2.UseVisualStyleBackColor = True
        '
        'btnFolder1
        '
        Me.btnFolder1.Location = New System.Drawing.Point(294, 97)
        Me.btnFolder1.Name = "btnFolder1"
        Me.btnFolder1.Size = New System.Drawing.Size(24, 20)
        Me.btnFolder1.TabIndex = 17
        Me.btnFolder1.Text = "..."
        Me.btnFolder1.UseVisualStyleBackColor = True
        '
        'btnFile2
        '
        Me.btnFile2.Location = New System.Drawing.Point(294, 45)
        Me.btnFile2.Name = "btnFile2"
        Me.btnFile2.Size = New System.Drawing.Size(24, 20)
        Me.btnFile2.TabIndex = 16
        Me.btnFile2.Text = "..."
        Me.btnFile2.UseVisualStyleBackColor = True
        '
        'btnFile1
        '
        Me.btnFile1.Location = New System.Drawing.Point(294, 19)
        Me.btnFile1.Name = "btnFile1"
        Me.btnFile1.Size = New System.Drawing.Size(24, 20)
        Me.btnFile1.TabIndex = 9
        Me.btnFile1.Text = "..."
        Me.btnFile1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Translated Game:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Original Game:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Image Files:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Translated Script:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Clean Script:"
        '
        'txtFolder3
        '
        Me.txtFolder3.Location = New System.Drawing.Point(104, 149)
        Me.txtFolder3.Name = "txtFolder3"
        Me.txtFolder3.Size = New System.Drawing.Size(184, 20)
        Me.txtFolder3.TabIndex = 11
        '
        'txtFolder2
        '
        Me.txtFolder2.Location = New System.Drawing.Point(104, 123)
        Me.txtFolder2.Name = "txtFolder2"
        Me.txtFolder2.Size = New System.Drawing.Size(184, 20)
        Me.txtFolder2.TabIndex = 10
        '
        'txtFolder1
        '
        Me.txtFolder1.Location = New System.Drawing.Point(104, 97)
        Me.txtFolder1.Name = "txtFolder1"
        Me.txtFolder1.Size = New System.Drawing.Size(184, 20)
        Me.txtFolder1.TabIndex = 9
        '
        'txtFile2
        '
        Me.txtFile2.Location = New System.Drawing.Point(104, 45)
        Me.txtFile2.Name = "txtFile2"
        Me.txtFile2.Size = New System.Drawing.Size(184, 20)
        Me.txtFile2.TabIndex = 8
        '
        'txtFile1
        '
        Me.txtFile1.Location = New System.Drawing.Point(104, 19)
        Me.txtFile1.Name = "txtFile1"
        Me.txtFile1.Size = New System.Drawing.Size(184, 20)
        Me.txtFile1.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 270)
        Me.Panel1.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(272, 276)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 276)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Exit"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtFile3
        '
        Me.txtFile3.Location = New System.Drawing.Point(104, 71)
        Me.txtFile3.Name = "txtFile3"
        Me.txtFile3.Size = New System.Drawing.Size(184, 20)
        Me.txtFile3.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "UTFonts File:"
        '
        'btnFile3
        '
        Me.btnFile3.Location = New System.Drawing.Point(294, 71)
        Me.btnFile3.Name = "btnFile3"
        Me.btnFile3.Size = New System.Drawing.Size(24, 20)
        Me.btnFile3.TabIndex = 22
        Me.btnFile3.Text = "..."
        Me.btnFile3.UseVisualStyleBackColor = True
        '
        'frmProjOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(359, 306)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.grpPaths)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjOptions"
        Me.Text = "frmProjOptions"
        Me.grpPaths.ResumeLayout(False)
        Me.grpPaths.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents grpPaths As GroupBox
    Friend WithEvents btnFolder3 As Button
    Friend WithEvents btnFolder2 As Button
    Friend WithEvents btnFolder1 As Button
    Friend WithEvents btnFile2 As Button
    Friend WithEvents btnFile1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFolder3 As TextBox
    Friend WithEvents txtFolder2 As TextBox
    Friend WithEvents txtFolder1 As TextBox
    Friend WithEvents txtFile2 As TextBox
    Friend WithEvents txtFile1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnFile3 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFile3 As TextBox
End Class
