Imports System.Xml

Public Class frmStartUp

    Dim projects As XmlNodeList = GetRecentProjects()

    Private Sub frmStartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If projects.Count > 0 Then
            For Each project As XmlElement In projects
                lstProjects.Items.Add(project.SelectSingleNode("Name").InnerText)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmNewProject.Show(Me)
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "TranslaTale Project files (*.ttp) |*.ttp"
        OpenFileDialog1.Title = "Open a Project file"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim doc As New XmlDocument()
            doc.Load(OpenFileDialog1.FileName)
            SaveRecentProject(doc.GetElementsByTagName("Name")(0).InnerXml, OpenFileDialog1.FileName)

            Me.Hide()
            frmMain.Show()
            frmMain.OpenFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub lstProjects_DoubleClick(sender As Object, e As EventArgs) Handles lstProjects.DoubleClick
        If lstProjects.SelectedItem IsNot vbNullString Then
            Me.Hide()
            frmMain.Show()
            frmMain.OpenFile(projects.Item(lstProjects.SelectedIndex).SelectSingleNode("Path").InnerText)
        End If

    End Sub
End Class