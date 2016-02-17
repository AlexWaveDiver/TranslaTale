Imports System.Xml
Imports System.IO

Module SettingsManager

    Function GetBookmarks()
        Dim xmlBookmarks As String = My.Settings.Bookmarks
        Dim xml As New XmlDocument()
        xml.LoadXml(xmlBookmarks)
        Dim nodelist As XmlNodeList = xml.SelectNodes("//Bookmarks/Bookmark")
        Return nodelist
    End Function

    Function GetRecentProjects()
        Dim xmlProjects As String = My.Settings.RecentProjects
        Dim xml As New XmlDocument()
        xml.LoadXml(xmlProjects)
        Dim nodelist As XmlNodeList = xml.SelectNodes("//RecentProjects/Project")
        Return nodelist
    End Function

    Function SaveBookmark(ByVal page As Integer, ByVal tag As String)
        Dim xmlBookmarks As String = My.Settings.Bookmarks
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(xmlBookmarks)

        With xml.SelectSingleNode("//Bookmarks").CreateNavigator().AppendChild()
            .WriteStartElement("Bookmark")
            .WriteElementString("page", page)
            .WriteElementString("tag", tag)
            .WriteEndElement()
            .Close()
        End With
        My.Settings.Bookmarks = xml.OuterXml
        My.Settings.Save()
        Return True
    End Function

    Function SaveRecentProject(ByVal name As String, ByVal path As String)
        Dim xmlProjects As String = My.Settings.RecentProjects
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(xmlProjects)

        With xml.SelectSingleNode("//RecentProjects").CreateNavigator().AppendChild()
            .WriteStartElement("Project")
            .WriteElementString("Name", name)
            .WriteElementString("Path", path)
            .WriteEndElement()
            .Close()
        End With
        My.Settings.RecentProjects = xml.OuterXml
        My.Settings.Save()
        Return True
    End Function

    Function GetSingleBookmark(ByVal index As String)
        Dim xmlBookmarks As String = My.Settings.Bookmarks
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(xmlBookmarks)

        Dim node As XmlNode = xml.SelectSingleNode("//Bookmarks/Bookmark[" + index + "]")

        If node IsNot Nothing Then
            Return False
        Else
            Return node
        End If
    End Function

    Function DeleteBookmark(ByVal index As String)
        Dim xmlBookmarks As String = My.Settings.Bookmarks
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(xmlBookmarks)

        Dim node As XmlNode = xml.SelectSingleNode("//Bookmarks/Bookmark[" + index + "]")

        If node IsNot Nothing Then
            node.ParentNode.RemoveChild(node)
            My.Settings.Bookmarks = xml.OuterXml
            My.Settings.Save()
        Else
            Dim lastNode As XmlNode = xml.SelectSingleNode("//Bookmarks/Bookmark")
            If lastNode IsNot Nothing Then
                lastNode.ParentNode.RemoveChild(lastNode)
                My.Settings.Bookmarks = xml.OuterXml
                My.Settings.Save()
            Else
                Return False
            End If
        End If
        Return True
    End Function

    Function GetTempFolder(Optional ByVal customFolder As Boolean = False, Optional ByVal subfolder As String = "") As String
        Dim folder As String = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
        Do While Directory.Exists(folder) Or File.Exists(folder)
            folder = Path.Combine(Path.GetTempPath, Path.GetRandomFileName)
        Loop

        System.IO.Directory.CreateDirectory(folder)
        If customFolder = True Then
            If Not subfolder = "" Then
                System.IO.Directory.CreateDirectory(folder & "\" & subfolder)
            End If
        Else
            System.IO.Directory.CreateDirectory(folder & "\UTFONTS")
            System.IO.Directory.CreateDirectory(folder & "\DATAWIN")
        End If
        Return folder
    End Function
End Module
