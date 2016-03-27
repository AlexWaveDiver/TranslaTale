<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileMerge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileMerge))
        Me.pnlDone = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlConflicts = New System.Windows.Forms.Panel()
        Me.rdbThird = New System.Windows.Forms.RadioButton()
        Me.rdbChoose = New System.Windows.Forms.RadioButton()
        Me.rdbTransl = New System.Windows.Forms.RadioButton()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlMerging = New System.Windows.Forms.Panel()
        Me.lblNoConflicts = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblConflicts = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblProcessed = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.pnlDone.SuspendLayout()
        Me.pnlConflicts.SuspendLayout()
        Me.pnlMerging.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDone
        '
        Me.pnlDone.BackColor = System.Drawing.Color.White
        Me.pnlDone.Controls.Add(Me.Label5)
        Me.pnlDone.Controls.Add(Me.Label6)
        Me.pnlDone.Controls.Add(Me.Label9)
        Me.pnlDone.Location = New System.Drawing.Point(122, 0)
        Me.pnlDone.Name = "pnlDone"
        Me.pnlDone.Size = New System.Drawing.Size(307, 249)
        Me.pnlDone.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(229, 65)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "All done!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can now save your file." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Make sure to close this form when you" &
    "'re done." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 20.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(15, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 33)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "File Merging"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 2
        '
        'pnlConflicts
        '
        Me.pnlConflicts.BackColor = System.Drawing.Color.White
        Me.pnlConflicts.Controls.Add(Me.rdbThird)
        Me.pnlConflicts.Controls.Add(Me.rdbChoose)
        Me.pnlConflicts.Controls.Add(Me.rdbTransl)
        Me.pnlConflicts.Controls.Add(Me.lblDesc)
        Me.pnlConflicts.Controls.Add(Me.Label8)
        Me.pnlConflicts.Controls.Add(Me.Label10)
        Me.pnlConflicts.Location = New System.Drawing.Point(122, 0)
        Me.pnlConflicts.Name = "pnlConflicts"
        Me.pnlConflicts.Size = New System.Drawing.Size(307, 249)
        Me.pnlConflicts.TabIndex = 19
        '
        'rdbThird
        '
        Me.rdbThird.AutoSize = True
        Me.rdbThird.Location = New System.Drawing.Point(31, 149)
        Me.rdbThird.Name = "rdbThird"
        Me.rdbThird.Size = New System.Drawing.Size(117, 17)
        Me.rdbThird.TabIndex = 12
        Me.rdbThird.TabStop = True
        Me.rdbThird.Text = "Prefer additional file"
        Me.rdbThird.UseVisualStyleBackColor = True
        '
        'rdbChoose
        '
        Me.rdbChoose.AutoSize = True
        Me.rdbChoose.Location = New System.Drawing.Point(31, 172)
        Me.rdbChoose.Name = "rdbChoose"
        Me.rdbChoose.Size = New System.Drawing.Size(105, 17)
        Me.rdbChoose.TabIndex = 11
        Me.rdbChoose.TabStop = True
        Me.rdbChoose.Text = "Choose manually"
        Me.rdbChoose.UseVisualStyleBackColor = True
        '
        'rdbTransl
        '
        Me.rdbTransl.AutoSize = True
        Me.rdbTransl.Location = New System.Drawing.Point(31, 126)
        Me.rdbTransl.Name = "rdbTransl"
        Me.rdbTransl.Size = New System.Drawing.Size(120, 17)
        Me.rdbTransl.TabIndex = 10
        Me.rdbTransl.TabStop = True
        Me.rdbTransl.Text = "Prefer translation file"
        Me.rdbTransl.UseVisualStyleBackColor = True
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(28, 76)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(169, 26)
        Me.lblDesc.TabIndex = 6
        Me.lblDesc.Text = "Some conflicts have been found." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please choose how to solve them:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 20.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(15, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 33)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "File Merging"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 2
        '
        'pnlMerging
        '
        Me.pnlMerging.BackColor = System.Drawing.Color.White
        Me.pnlMerging.Controls.Add(Me.lblNoConflicts)
        Me.pnlMerging.Controls.Add(Me.Label4)
        Me.pnlMerging.Controls.Add(Me.lblConflicts)
        Me.pnlMerging.Controls.Add(Me.lblTitle)
        Me.pnlMerging.Controls.Add(Me.lblProcessed)
        Me.pnlMerging.Controls.Add(Me.Label7)
        Me.pnlMerging.Location = New System.Drawing.Point(122, 0)
        Me.pnlMerging.Name = "pnlMerging"
        Me.pnlMerging.Size = New System.Drawing.Size(307, 249)
        Me.pnlMerging.TabIndex = 18
        '
        'lblNoConflicts
        '
        Me.lblNoConflicts.AutoSize = True
        Me.lblNoConflicts.Location = New System.Drawing.Point(82, 192)
        Me.lblNoConflicts.Name = "lblNoConflicts"
        Me.lblNoConflicts.Size = New System.Drawing.Size(136, 13)
        Me.lblNoConflicts.TabIndex = 7
        Me.lblNoConflicts.Text = "No conflicts found! Hooray!"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 26)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Comparing files and applying changes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This might take a while." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblConflicts
        '
        Me.lblConflicts.AutoSize = True
        Me.lblConflicts.Location = New System.Drawing.Point(18, 140)
        Me.lblConflicts.Name = "lblConflicts"
        Me.lblConflicts.Size = New System.Drawing.Size(59, 13)
        Me.lblConflicts.TabIndex = 5
        Me.lblConflicts.Text = "Conflicts: 0"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Calibri Light", 20.25!)
        Me.lblTitle.ForeColor = System.Drawing.Color.Silver
        Me.lblTitle.Location = New System.Drawing.Point(15, 19)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(149, 33)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "File Merging"
        '
        'lblProcessed
        '
        Me.lblProcessed.AutoSize = True
        Me.lblProcessed.Location = New System.Drawing.Point(18, 117)
        Me.lblProcessed.Name = "lblProcessed"
        Me.lblProcessed.Size = New System.Drawing.Size(114, 13)
        Me.lblProcessed.TabIndex = 3
        Me.lblProcessed.Text = "Lines Processed: 0 / 0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 2
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(342, 261)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 17
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 261)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 16
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.White
        Me.pnlInfo.Controls.Add(Me.Label3)
        Me.pnlInfo.Controls.Add(Me.Label2)
        Me.pnlInfo.Controls.Add(Me.lblInfo)
        Me.pnlInfo.Controls.Add(Me.Label1)
        Me.pnlInfo.Location = New System.Drawing.Point(122, 0)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(307, 249)
        Me.pnlInfo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 26)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Potential conflicts between translation lines" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will require to be solved by hand." &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 20.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(15, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 33)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "File Merging"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(18, 76)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(200, 26)
        Me.lblInfo.TabIndex = 3
        Me.lblInfo.Text = "This wizard will help you merge other files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to your translation file."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TranslaTale.My.Resources.Resources.about
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 249)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 295)
        Me.Controls.Add(Me.pnlDone)
        Me.Controls.Add(Me.pnlConflicts)
        Me.Controls.Add(Me.pnlMerging)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMerge"
        Me.Text = "File Merging"
        Me.pnlDone.ResumeLayout(False)
        Me.pnlDone.PerformLayout()
        Me.pnlConflicts.ResumeLayout(False)
        Me.pnlConflicts.PerformLayout()
        Me.pnlMerging.ResumeLayout(False)
        Me.pnlMerging.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDone As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlConflicts As Panel
    Friend WithEvents rdbThird As RadioButton
    Friend WithEvents rdbChoose As RadioButton
    Friend WithEvents rdbTransl As RadioButton
    Friend WithEvents lblDesc As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlMerging As Panel
    Friend WithEvents lblNoConflicts As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblConflicts As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblProcessed As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
