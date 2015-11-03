<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbIgnore = New System.Windows.Forms.CheckBox()
        Me.cbCS = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.rbbase = New System.Windows.Forms.RadioButton()
        Me.rbtranslation = New System.Windows.Forms.RadioButton()
        Me.rbboth = New System.Windows.Forms.RadioButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search:"
        '
        'cbIgnore
        '
        Me.cbIgnore.AutoSize = True
        Me.cbIgnore.Location = New System.Drawing.Point(13, 57)
        Me.cbIgnore.Name = "cbIgnore"
        Me.cbIgnore.Size = New System.Drawing.Size(111, 17)
        Me.cbIgnore.TabIndex = 1
        Me.cbIgnore.Text = "Ignore format tags"
        Me.cbIgnore.UseVisualStyleBackColor = True
        '
        'cbCS
        '
        Me.cbCS.AutoSize = True
        Me.cbCS.Location = New System.Drawing.Point(13, 80)
        Me.cbCS.Name = "cbCS"
        Me.cbCS.Size = New System.Drawing.Size(94, 17)
        Me.cbCS.TabIndex = 2
        Me.cbCS.Text = "Case sensitive"
        Me.cbCS.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(403, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(403, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "&Seach"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'rbbase
        '
        Me.rbbase.AutoSize = True
        Me.rbbase.Location = New System.Drawing.Point(211, 58)
        Me.rbbase.Name = "rbbase"
        Me.rbbase.Size = New System.Drawing.Size(69, 17)
        Me.rbbase.TabIndex = 5
        Me.rbbase.Text = "Base text"
        Me.rbbase.UseVisualStyleBackColor = True
        '
        'rbtranslation
        '
        Me.rbtranslation.AutoSize = True
        Me.rbtranslation.Checked = True
        Me.rbtranslation.Location = New System.Drawing.Point(286, 58)
        Me.rbtranslation.Name = "rbtranslation"
        Me.rbtranslation.Size = New System.Drawing.Size(77, 17)
        Me.rbtranslation.TabIndex = 6
        Me.rbtranslation.TabStop = True
        Me.rbtranslation.Text = "Translation"
        Me.rbtranslation.UseVisualStyleBackColor = True
        '
        'rbboth
        '
        Me.rbboth.AutoSize = True
        Me.rbboth.Location = New System.Drawing.Point(211, 81)
        Me.rbboth.Name = "rbboth"
        Me.rbboth.Size = New System.Drawing.Size(47, 17)
        Me.rbboth.TabIndex = 7
        Me.rbboth.Text = "Both"
        Me.rbboth.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(58, 17)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(419, 20)
        Me.txtSearch.TabIndex = 8
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 119)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.rbboth)
        Me.Controls.Add(Me.rbtranslation)
        Me.Controls.Add(Me.rbbase)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbCS)
        Me.Controls.Add(Me.cbIgnore)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.Text = "Search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbIgnore As System.Windows.Forms.CheckBox
    Friend WithEvents cbCS As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rbbase As System.Windows.Forms.RadioButton
    Friend WithEvents rbtranslation As System.Windows.Forms.RadioButton
    Friend WithEvents rbboth As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
End Class
