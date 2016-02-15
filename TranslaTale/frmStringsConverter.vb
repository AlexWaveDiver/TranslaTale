Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class frmStringsConverter
    Dim crossCompareDelegated As New ThreadStart(AddressOf crossCompare)
    Dim easterEggDelegated As New ThreadStart(AddressOf easterEgg)
    Dim easterEggRunning As Boolean = False
    Dim crossCompareCancelled As Boolean = False
    Dim crossCompareDone = False
    Dim freshv1txt As String()
    Dim freshv1001txt As String()
    Dim translatetxt As String()
    Dim freshv1Path As String = ""
    Dim freshv1001Path As String = ""
    Dim translationPath As String = ""
    Dim koLines As Integer = 0
    Dim easterEggTitle As String() = {"Sets of numbers...", "Lines of dialogue...", "I've seen them all."}

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        crossCompareCancelled = True
        closeForm()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Delegate Sub ListBoxInvoker(ByVal text As String, ByVal ListElement As ListBox)
    Private Delegate Sub elementTextInvoker(ByVal text As String, ByVal controlElement As Control)
    Private Delegate Sub elementVisibilityInvoker(ByVal visible As Boolean, ByVal buttonElement As Control)
    Private Delegate Sub elementEnableInvoker(ByVal enabled As Boolean, ByVal buttonElement As Control)

    Private Sub setListItem(ByVal text As String, ByVal ListElement As ListBox)
        If ListElement.InvokeRequired Then
            ListElement.Invoke(New ListBoxInvoker(AddressOf setListItem), text, ListElement)
        Else
            ListElement.Items.Add(text)
        End If
    End Sub

    Private Sub setElementText(ByVal text As String, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementTextInvoker(AddressOf setElementText), text, controlElement)
        Else
            controlElement.Text = text
        End If
    End Sub

    Private Sub setElementVisibility(ByVal visible As Boolean, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementVisibilityInvoker(AddressOf setElementVisibility), visible, controlElement)
        Else
            controlElement.Visible = visible
        End If
    End Sub

    Private Sub setElementEnabled(ByVal enabled As Boolean, ByVal controlElement As Control)
        If controlElement.InvokeRequired Then
            controlElement.Invoke(New elementEnableInvoker(AddressOf setElementEnabled), enabled, controlElement)
        Else
            controlElement.Enabled = enabled
        End If
    End Sub

    Public Sub easterEgg()
        If easterEggRunning = False Then
            easterEggRunning = True
            setElementText("", Me)
            For value As Integer = 0 To easterEggTitle(0).Length
                If value <= easterEggTitle(0).Length - 1 Then
                    setElementText(Me.Text & easterEggTitle(0)(value), Me)
                    Thread.Sleep(100)
                End If
            Next
            Thread.Sleep(1000)
            setElementText("", Me)
            For value As Integer = 0 To easterEggTitle(1).Length
                If value <= easterEggTitle(1).Length - 1 Then
                    setElementText(Me.Text & easterEggTitle(1)(value), Me)
                    Thread.Sleep(100)
                End If
            Next
            Thread.Sleep(2000)
            setElementText("", Me)
            For value As Integer = 0 To easterEggTitle(2).Length
                If value <= easterEggTitle(2).Length - 1 Then
                    setElementText(Me.Text & easterEggTitle(2)(value), Me)
                    Thread.Sleep(100)
                End If
            Next
            Thread.Sleep(10000)
            setElementText("Strings Migration Wizard", Me)
            easterEggRunning = False
        End If
    End Sub

    Public Sub crossCompare()
        setElementVisibility(False, Button1)
        setElementEnabled(True, btnCancel)

        Try
            freshv1txt = File.ReadAllLines(freshv1Path)
            freshv1001txt = File.ReadAllLines(freshv1001Path)
            translatetxt = File.ReadAllLines(translationPath)
            Dim totalLines As Integer = freshv1txt.Count
            Dim okLines As Integer = 0
            Dim lineIndex As Integer = 0
            For Each freshv1txtLine As String In freshv1txt
                If Me.crossCompareCancelled = True Then
                    Exit Sub
                End If

                ' gml_ mus_ spr_ obj_

                setElementText("Processed: " & lineIndex.ToString & "/" & totalLines.ToString, lblProcessed)
                Dim newLinePos As String = Array.FindIndex(freshv1001txt, Function(x) (x.StartsWith(freshv1txtLine)))
                If freshv1txt(lineIndex).StartsWith("gml_") Or freshv1txt(lineIndex).StartsWith("obj_") Or freshv1txt(lineIndex).StartsWith("mus_") Or freshv1txt(lineIndex).StartsWith("spr_") Then
                    okLines += 1
                    setElementText("Successfully: " & okLines.ToString, lblOK)
                Else
                    If newLinePos > -1 Then
                        If freshv1txt(lineIndex) = freshv1001txt(newLinePos) Then
                            okLines += 1
                            setElementText("Successfully: " & okLines.ToString, lblOK)
                            freshv1001txt(newLinePos) = translatetxt(lineIndex)
                        Else
                            koLines += 1
                            setElementText("Unsuccessfully: " & koLines.ToString, lblKO)
                            setListItem((lineIndex + 1).ToString & "|||" & freshv1txt(lineIndex), ListBox1)
                        End If
                    Else
                        koLines += 1
                        setElementText("Unsuccessfully: " & koLines.ToString, lblKO)
                        setListItem((lineIndex + 1).ToString & "|||" & freshv1txt(lineIndex), ListBox1)
                    End If
                End If
                lineIndex += 1
            Next
            setElementText("Processed: " & totalLines.ToString & "/" & totalLines.ToString, lblProcessed)
            crossCompareDone = True
            setElementVisibility(True, btnReport)
            setElementText("S&ave", btnNext)
            setElementVisibility(True, Button1)
            setElementEnabled(False, btnCancel)
            setElementEnabled(True, btnNext)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Function closeForm()
        Panel2.Visible = False
        btnNext.Text = "&Next >"
        btnCancel.Visible = True
        lblProcessed.Text = "Processed: 0 / 0"
        lblOK.Text = "Successfully: 0"
        lblKO.Text = "Unsuccessfully: 0"
        Button1.Visible = True
        btnCancel.Enabled = False
        btnNext.Enabled = True
        btnReport.Visible = False
    End Function

    Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If btnNext.Text = "S&ave" Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Title = "Save as..."
            saveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            saveFileDialog1.Filter = "TXT files (*.txt)|*.txt"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                System.IO.File.WriteAllLines(saveFileDialog1.FileName, freshv1001txt)
            End If
            Exit Sub
        End If

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Title = "Select your fresh v1.0 strings file"
        openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        openFileDialog1.Filter = "TXT files (*.txt)|*.txt"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            freshv1Path = openFileDialog1.FileName()
            openFileDialog1 = New OpenFileDialog()
            openFileDialog1.Title = "Select your fresh v1.001 strings file"
            openFileDialog1.InitialDirectory = freshv1Path
            openFileDialog1.Filter = "TXT files (*.txt)|*.txt"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                freshv1001Path = openFileDialog1.FileName()
                openFileDialog1 = New OpenFileDialog()
                openFileDialog1.Title = "Select your translation file"
                openFileDialog1.InitialDirectory = freshv1001Path
                openFileDialog1.Filter = "TXT files (*.txt)|*.txt"
                openFileDialog1.FilterIndex = 2
                openFileDialog1.RestoreDirectory = True
                If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    translationPath = openFileDialog1.FileName()
                    btnNext.Enabled = False
                    Panel2.Visible = True
                    ListBox1.Items.Clear()
                    crossCompareCancelled = False
                    Dim compareThread As New System.Threading.Thread(crossCompareDelegated)
                    compareThread.SetApartmentState(ApartmentState.STA)
                    compareThread.Start()
                End If
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim header As String = <![CDATA[
<html>
<head>
	<style>
		html, body{
			background-color:#000;
			font-family: arial, helvetica, sans-serif;
			margin:15px;
		}

		table { border-collapse: collapse; }
		table tr { line-height: 30px; }

		.content {
			border-radius: 5px;
			background-color: #f8f8f8;
			width:100%;
			padding:20px 10px;
			margin-bottom: 20px;
		}
	</style>
</head>
<body>
	<div class="content">
		<h1>TranslaTale - report</h1>
		<h3>Untranslated lines (]]>.ToString

        Dim header2 As String = <![CDATA[)</h3>
	</div>
	<div class="content">
		<table style="width:100%; text-align:left">
			<tr>
				<th style="width:200px; border-bottom: 1px solid #d7d7d7">Line number</th>
				<th style="border-bottom: 1px solid #d7d7d7">Text</th>
			</tr>]]>.ToString

        Dim footer As String = <![CDATA[		</table>
	</div>
</body>
</html>]]>.ToString

        Dim body As String = ""
        For Each failedLine As String In ListBox1.Items
            If ListBox1.Items.Count > 0 Then
                Dim failedLineInfo As String() = Split(failedLine, "|||")
                body += "<tr style=""margin-bottom:10px""><td>" & failedLineInfo(0) & "</td><td>" & failedLineInfo(1) & "</td></tr>"
            End If
        Next


        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Title = "Save report as..."
        saveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        saveFileDialog1.Filter = "HTML document (*.html)|*.html"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim output As String = (header & koLines & header2 & body & footer).Replace("<![CDATA[", String.Empty).Replace("]]>", String.Empty)
            System.IO.File.WriteAllText(saveFileDialog1.FileName, output)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim easterEggThread As New System.Threading.Thread(easterEggDelegated)
        easterEggThread.SetApartmentState(ApartmentState.STA)
        easterEggThread.Start()
    End Sub

    Private Sub frmStringsConverter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Panel2.Visible = True Or btnCancel.Text = "&Cancel" Or btnCancel.Text = "&Back" Then
            crossCompareCancelled = True
            btnCancel.Text = "&Exit"
            btnCancel.PerformClick()
            e.Cancel = True
        End If
        closeForm()
        e.Cancel = False
    End Sub
End Class