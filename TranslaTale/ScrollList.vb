Public Class ScrollList
    Inherits ListBox

    Public Event Scroll(ByVal sender As Object)
    Public Const WM_HSCROLL As Integer = &H114
    Public Const WM_VSCROLL As Integer = &H115

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HSCROLL Then
            RaiseEvent Scroll(Me)
        ElseIf m.Msg = WM_VSCROLL Then
            RaiseEvent Scroll(Me)
        End If

        MyBase.WndProc(m)
    End Sub
End Class