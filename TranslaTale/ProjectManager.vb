Imports System.IO
Imports System.Xml

Public Module ProjectManager

    Public CurrentProject As String

    Public Sub Write(ByVal filePath As String, ByVal name As String, ByVal cleanScriptPath As String,
                     ByVal translationPath As String, ByVal imagesPath As String, ByVal fontPath As String,
                     ByVal cleanGamePath As String, ByVal translatedGamePath As String)

        Dim writer As XmlTextWriter = New XmlTextWriter(filePath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument(True)
        writer.WriteStartElement("projectSettings")
        writer.WriteElementString("name", name)
        writer.WriteElementString("cleanScriptPath", cleanScriptPath)
        writer.WriteElementString("translationPath", translationPath)
        writer.WriteElementString("imagesPath", imagesPath)
        writer.WriteElementString("fontsPath", fontPath)
        writer.WriteElementString("cleanGamePath", cleanGamePath)
        writer.WriteElementString("translatedGamePath", translatedGamePath)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Public Function GetOutputDirectory() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("translatedGamePath")(0).InnerXml
    End Function

    Public Sub Read(ByRef name As String, ByRef cleanScriptPath As String, ByRef translationPath As String)

        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)

        name = doc.GetElementsByTagName("name")(0).InnerXml
        cleanScriptPath = doc.GetElementsByTagName("cleanScriptPath")(0).InnerXml
        translationPath = doc.GetElementsByTagName("translationPath")(0).InnerXml
    End Sub

    Public Sub Read(ByRef translationPath As String, ByRef imagesPath As String,
                    ByRef fontsPath As String, ByRef cleanGamePath As String, ByRef translatedGamePath As String)
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)

        translationPath = doc.GetElementsByTagName("translationPath")(0).InnerXml
        imagesPath = doc.GetElementsByTagName("imagesPath")(0).InnerXml
        fontsPath = doc.GetElementsByTagName("fontsPath")(0).InnerXml
        cleanGamePath = doc.GetElementsByTagName("cleanGamePath")(0).InnerXml
        translatedGamePath = doc.GetElementsByTagName("translatedGamePath")(0).InnerXml

    End Sub

    Public Sub Read(ByRef name As String, ByRef cleanScriptPath As String, ByRef translationPath As String,
                    ByRef imagesPath As String, ByRef fontsPath As String, ByRef cleanGamePath As String,
                    ByRef translatedGamePath As String)

        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)

        name = doc.GetElementsByTagName("name")(0).InnerXml
        cleanScriptPath = doc.GetElementsByTagName("cleanScriptPath")(0).InnerXml
        translationPath = doc.GetElementsByTagName("translationPath")(0).InnerXml
        imagesPath = doc.GetElementsByTagName("imagesPath")(0).InnerXml
        fontsPath = doc.GetElementsByTagName("fontsPath")(0).InnerXml
        cleanGamePath = doc.GetElementsByTagName("cleanGamePath")(0).InnerXml
        translatedGamePath = doc.GetElementsByTagName("translatedGamePath")(0).InnerXml
    End Sub
End Module
