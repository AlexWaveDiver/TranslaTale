<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSearch
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbBase = New System.Windows.Forms.RadioButton()
        Me.rbTranslation = New System.Windows.Forms.RadioButton()
        Me.rbBoth = New System.Windows.Forms.RadioButton()
        Me.chkIgnoreCase = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstSearchResults = New System.Windows.Forms.ListView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cbIgnoreFormat = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(14, 32)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(434, 20)
        Me.txtSearch.TabIndex = 16
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(372, 76)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 17
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Search term:"
        '
        'rbBase
        '
        Me.rbBase.AutoSize = True
        Me.rbBase.Checked = True
        Me.rbBase.Location = New System.Drawing.Point(14, 59)
        Me.rbBase.Name = "rbBase"
        Me.rbBase.Size = New System.Drawing.Size(69, 17)
        Me.rbBase.TabIndex = 19
        Me.rbBase.TabStop = True
        Me.rbBase.Text = "&Base text"
        Me.rbBase.UseVisualStyleBackColor = True
        '
        'rdTranslation
        '
        Me.rbTranslation.AutoSize = True
        Me.rbTranslation.Location = New System.Drawing.Point(89, 58)
        Me.rbTranslation.Name = "rdTranslation"
        Me.rbTranslation.Size = New System.Drawing.Size(77, 17)
        Me.rbTranslation.TabIndex = 20
        Me.rbTranslation.Text = "&Translation"
        Me.rbTranslation.UseVisualStyleBackColor = True
        '
        'rdBoth
        '
        Me.rbBoth.AutoSize = True
        Me.rbBoth.Location = New System.Drawing.Point(172, 58)
        Me.rbBoth.Name = "rdBoth"
        Me.rbBoth.Size = New System.Drawing.Size(47, 17)
        Me.rbBoth.TabIndex = 21
        Me.rbBoth.Text = "B&oth"
        Me.rbBoth.UseVisualStyleBackColor = True
        '
        'chkIgnoreCase
        '
        Me.chkIgnoreCase.AutoSize = True
        Me.chkIgnoreCase.Location = New System.Drawing.Point(14, 85)
        Me.chkIgnoreCase.Name = "chkIgnoreCase"
        Me.chkIgnoreCase.Size = New System.Drawing.Size(94, 17)
        Me.chkIgnoreCase.TabIndex = 22
        Me.chkIgnoreCase.Text = "C&ase sensitive"
        Me.chkIgnoreCase.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstSearchResults)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 191)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search results"
        '
        'lstSearchResults
        '
        Me.lstSearchResults.Enabled = False
        Me.lstSearchResults.FullRowSelect = True
        Me.lstSearchResults.GridLines = True
        ListViewGroup1.Header = "ListViewGroup"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "ListViewGroup"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "ListViewGroup"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.lstSearchResults.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lstSearchResults.Location = New System.Drawing.Point(6, 19)
        Me.lstSearchResults.Name = "lstSearchResults"
        Me.lstSearchResults.Size = New System.Drawing.Size(422, 167)
        Me.lstSearchResults.TabIndex = 14
        Me.lstSearchResults.UseCompatibleStateImageBehavior = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(373, 314)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cbIgnoreFormat
        '
        Me.cbIgnoreFormat.AutoSize = True
        Me.cbIgnoreFormat.Location = New System.Drawing.Point(114, 85)
        Me.cbIgnoreFormat.Name = "cbIgnoreFormat"
        Me.cbIgnoreFormat.Size = New System.Drawing.Size(111, 17)
        Me.cbIgnoreFormat.TabIndex = 24
        Me.cbIgnoreFormat.Text = "&Ignore format tags"
        Me.cbIgnoreFormat.UseVisualStyleBackColor = True
        Me.cbIgnoreFormat.Visible = False
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 348)
        Me.Controls.Add(Me.cbIgnoreFormat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkIgnoreCase)
        Me.Controls.Add(Me.rbBoth)
        Me.Controls.Add(Me.rbTranslation)
        Me.Controls.Add(Me.rbBase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbBase As System.Windows.Forms.RadioButton
    Friend WithEvents rbTranslation As System.Windows.Forms.RadioButton
    Friend WithEvents rbBoth As System.Windows.Forms.RadioButton
    Friend WithEvents chkIgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstSearchResults As System.Windows.Forms.ListView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbIgnoreFormat As System.Windows.Forms.CheckBox
End Class
