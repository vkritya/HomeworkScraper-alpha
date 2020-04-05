Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Property Password As String
    Property Username As String

    Public Sub New(Title As String)
        InitializeComponent()
        Text = Title
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            MsgBox("�rd be a felhaszn�l�neved!")
        ElseIf PasswordTextBox.Text = "" Then
            MsgBox("�rd be a jelszavad!")
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
