Imports System.Xml

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
End Module
