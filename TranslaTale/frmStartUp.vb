Imports System
Imports System.IO
Imports System.Xml
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmStartUp

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmNewProject.Show(Me)
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "TranslaTale Project files (*.ttp) |*.ttp"
        OpenFileDialog1.Title = "Open a Project file"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Me.Hide()
            frmMain.Show()
            frmMain.OpenFile(OpenFileDialog1.FileName)
        End If
    End Sub
End Class