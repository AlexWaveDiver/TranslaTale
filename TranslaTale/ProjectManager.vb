Imports System.IO
Imports System.Xml

Public Module ProjectManager

    Public CurrentProject As String

    Public Sub Write(ByVal filePath As String, ByVal name As String, ByVal cleanScriptPath As String,
                     ByVal translationPath As String, ByVal imagesPath As String,
                     ByVal cleanGamePath As String, ByVal translatedGamePath As String)

        Dim writer As XmlTextWriter = New XmlTextWriter(filePath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument(True)
        writer.WriteStartElement("Settings")
        writer.WriteElementString("Name", name)
        writer.WriteElementString("CleanScriptPath", cleanScriptPath)
        writer.WriteElementString("TranslationPath", translationPath)
        writer.WriteElementString("ImagesPath", imagesPath)
        writer.WriteElementString("CleanGamePath", cleanGamePath)
        writer.WriteElementString("TranslatedGamePath", translatedGamePath)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Public Function GetName() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("Name")(0).InnerXml
    End Function

    Public Function GetCleanScript() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("CleanScriptPath")(0).InnerXml
    End Function

    Public Function GetTranslatedScript() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("TranslationPath")(0).InnerXml
    End Function

    Public Function GetImagesDirectory() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("ImagesPath")(0).InnerXml
    End Function

    Public Function GetInputDirectory() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("CleanGamePath")(0).InnerXml
    End Function

    Public Function GetOutputDirectory() As String
        Dim doc As New XmlDocument()
        doc.Load(CurrentProject)
        Return doc.GetElementsByTagName("TranslatedGamePath")(0).InnerXml
    End Function
End Module
