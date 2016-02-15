Public Class frmProjOptions
    Private Sub frmProjOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProjectManager.Read(txtName.Text, txtFile1.Text, txtFile2.Text, txtFolder1.Text, txtFile3.Text, txtFolder2.Text, txtFolder3.Text)
    End Sub

    Private Sub btnFile1_Click(sender As Object, e As EventArgs) Handles btnFile1.Click
        OpenFileDialog1.Title = "Select your clean script file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFile1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFile2_Click(sender As Object, e As EventArgs) Handles btnFile2.Click
        OpenFileDialog1.Title = "Select your clean script file"
        OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFile2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnFile3_Click(sender As Object, e As EventArgs) Handles btnFile3.Click
        OpenFileDialog1.Title = "Select your UTFonts.win file"
        OpenFileDialog1.Filter = ".WIN files (*.win)|*.win"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFile3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnFolder1_Click(sender As Object, e As EventArgs) Handles btnFolder1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder2_Click(sender As Object, e As EventArgs) Handles btnFolder2.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnFolder3_Click(sender As Object, e As EventArgs) Handles btnFolder3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFolder3.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ProjectManager.Write(ProjectManager.CurrentProject, txtName.Text, txtFile1.Text, txtFile2.Text, txtFolder1.Text, txtFile3.Text, txtFolder2.Text, txtFolder3.Text)
        Me.Close()
    End Sub
End Class