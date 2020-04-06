Public Class EKretaLoginForm

    Property Password As String
    Property Username As String

    Public Sub New(Title As String)
        InitializeComponent()
        Text = Title
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            MsgBox("Írd be a felhasználóneved!")
        ElseIf PasswordTextBox.Text = "" Then
            MsgBox("Írd be a jelszavad!")
        Else
            Password = PasswordTextBox.Text
            Username = UsernameTextBox.Text
            Me.DialogResult = DialogResult.OK
            Me.Hide()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub
End Class
