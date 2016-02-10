Public Class frmSplash
    Private Sub tmrSplash_Tick(sender As Object, e As EventArgs) Handles tmrSplash.Tick
        tmrSplash.Stop()
        Me.Hide()
        frmMain.Show()
    End Sub
End Class