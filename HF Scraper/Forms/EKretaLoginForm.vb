Public Class EKretaLoginForm

    Property Password As String
    Property Username As String
    Property myClosed As Boolean = False

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

    Private Sub SaveLoginCheckBoxCheckedChanged() Handles SaveLoginCheckBox.CheckedChanged
        If SaveLoginCheckBox.Checked Then
            If MessageBox.Show("Ha elmented a bejelentkezési adataidat, más is kiolvashatja õket a gépbõl (ha van hozzáférése a felhasználódhoz). Biztosan el szeretnéd menteni a bejelentkezési adataidat?", "Figyelmeztetés", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                SaveLoginCheckBox.Checked = False
            End If
        End If
    End Sub

    Private Sub EKretaLoginFormClosed(sender As Object, e As EventArgs) Handles MyBase.Closing
        myClosed = True
    End Sub
End Class
