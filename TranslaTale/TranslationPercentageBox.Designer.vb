<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TranslationPercentageBox
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnResetFilter = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.percRightBtn = New System.Windows.Forms.Panel()
        Me.percLeft = New System.Windows.Forms.Panel()
        Me.percLeftBtn = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLeft = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.btnResetFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.percLeft.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnResetFilter
        '
        Me.btnResetFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetFilter.Image = Global.TranslaTale.My.Resources.Resources.cross1
        Me.btnResetFilter.Location = New System.Drawing.Point(135, 66)
        Me.btnResetFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.btnResetFilter.Name = "btnResetFilter"
        Me.btnResetFilter.Size = New System.Drawing.Size(16, 16)
        Me.btnResetFilter.TabIndex = 13
        Me.btnResetFilter.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnResetFilter, "Reset filter")
        Me.btnResetFilter.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(150, 85)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnResetFilter)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(150, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 86)
        Me.Panel1.TabIndex = 0
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotal.Location = New System.Drawing.Point(30, 66)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(13, 15)
        Me.txtTotal.TabIndex = 12
        Me.txtTotal.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(-1, 67)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Total:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.percRightBtn)
        Me.Panel2.Controls.Add(Me.percLeft)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 35)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 25)
        Me.Panel2.TabIndex = 9
        '
        'percRightBtn
        '
        Me.percRightBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.percRightBtn.BackColor = System.Drawing.Color.Silver
        Me.percRightBtn.Location = New System.Drawing.Point(85, 2)
        Me.percRightBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.percRightBtn.Name = "percRightBtn"
        Me.percRightBtn.Size = New System.Drawing.Size(62, 21)
        Me.percRightBtn.TabIndex = 1
        '
        'percLeft
        '
        Me.percLeft.BackColor = System.Drawing.Color.LightGreen
        Me.percLeft.Controls.Add(Me.percLeftBtn)
        Me.percLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.percLeft.Location = New System.Drawing.Point(0, 0)
        Me.percLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.percLeft.Name = "percLeft"
        Me.percLeft.Size = New System.Drawing.Size(83, 25)
        Me.percLeft.TabIndex = 0
        '
        'percLeftBtn
        '
        Me.percLeftBtn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.percLeftBtn.BackColor = System.Drawing.Color.LimeGreen
        Me.percLeftBtn.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.percLeftBtn.Location = New System.Drawing.Point(2, 2)
        Me.percLeftBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.percLeftBtn.Name = "percLeftBtn"
        Me.percLeftBtn.Size = New System.Drawing.Size(79, 21)
        Me.percLeftBtn.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtLeft, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRight, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.MinimumSize = New System.Drawing.Size(150, 35)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 35)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'txtLeft
        '
        Me.txtLeft.AutoSize = True
        Me.txtLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLeft.Location = New System.Drawing.Point(0, 15)
        Me.txtLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(75, 20)
        Me.txtLeft.TabIndex = 6
        Me.txtLeft.Text = "0"
        '
        'txtRight
        '
        Me.txtRight.AutoSize = True
        Me.txtRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRight.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRight.Location = New System.Drawing.Point(75, 15)
        Me.txtRight.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Size = New System.Drawing.Size(75, 20)
        Me.txtRight.TabIndex = 5
        Me.txtRight.Text = "0"
        Me.txtRight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(75, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Untranslated"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Translated"
        '
        'TranslationPercentageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(150, 85)
        Me.Name = "TranslationPercentageBox"
        Me.Size = New System.Drawing.Size(150, 85)
        CType(Me.btnResetFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.percLeft.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnResetFilter As PictureBox
    Friend WithEvents txtTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents percRightBtn As Panel
    Friend WithEvents percLeft As Panel
    Friend WithEvents percLeftBtn As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtLeft As Label
    Friend WithEvents txtRight As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
