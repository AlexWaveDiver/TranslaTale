<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TTgroupControl
    Inherits System.Windows.Forms.UserControl

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblLabel
        '
        Me.lblLabel.Location = New System.Drawing.Point(117, 9)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(43, 13)
        Me.lblLabel.TabIndex = 0
        Me.lblLabel.Text = Me.Name
        Me.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabel.Visible = False
        '
        'TTgroupControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblLabel)
        Me.Name = "TTgroupControl"
        Me.Size = New System.Drawing.Size(289, 215)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLabel As System.Windows.Forms.Label
End Class
