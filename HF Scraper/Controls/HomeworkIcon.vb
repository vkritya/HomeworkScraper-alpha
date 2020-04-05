Public Class HomeworkIcon
    Public Sub setFinished(value As Boolean)
        Me.IsFinished.Visible = value
    End Sub
    Public Function getFinished() As Boolean
        Return Me.IsFinished.Visible
    End Function

    Public Event IsFinishedClicked()
    Private Sub passClick() Handles IsFinished.Click
        RaiseEvent IsFinishedClicked()
    End Sub
End Class
