Imports System.Xml
Imports System.IO

Module funcs
    Function getBookmarks()
        Dim xmlBookmarks As String = My.Settings.Bookmarks
        Dim xml As New XmlDocument()
        xml.LoadXml(xmlBookmarks)
        Dim nodelist As XmlNodeList = xml.SelectNodes("//Bookmarks/Bookmark")
        Return nodelist
    End Function

    Function saveBookmark(ByVal page As Integer, ByVal tag As String)
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

    Function getSingleBookmark(ByVal index As String)
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

    Function deleteBookmark(ByVal index As String)
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
