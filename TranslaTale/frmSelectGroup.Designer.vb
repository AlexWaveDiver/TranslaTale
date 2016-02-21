<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectGroup))
        Me.gruppiBox = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.noGroups = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'gruppiBox
        '
        Me.gruppiBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.gruppiBox.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gruppiBox.FormattingEnabled = True
        Me.gruppiBox.Location = New System.Drawing.Point(12, 12)
        Me.gruppiBox.Name = "gruppiBox"
        Me.gruppiBox.Size = New System.Drawing.Size(260, 21)
        Me.gruppiBox.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Button1.Location = New System.Drawing.Point(197, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Button2.Location = New System.Drawing.Point(116, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'noGroups
        '
        Me.noGroups.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noGroups.ForeColor = System.Drawing.Color.Red
        Me.noGroups.Location = New System.Drawing.Point(12, 39)
        Me.noGroups.Name = "noGroups"
        Me.noGroups.Size = New System.Drawing.Size(98, 23)
        Me.noGroups.TabIndex = 3
        Me.noGroups.Text = "No groups!"
        Me.noGroups.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.noGroups.Visible = False
        '
        'frmSelectGroup
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(284, 71)
        Me.Controls.Add(Me.noGroups)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gruppiBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select group"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gruppiBox As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents noGroups As Label
End Class
