Public Class EKretaLoginForm

    Property Password As String
    Property Username As String
    Property myClosed As Boolean = False

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

    Private Sub SaveLoginCheckBoxCheckedChanged() Handles SaveLoginCheckBox.CheckedChanged
        If SaveLoginCheckBox.Checked Then
            If MessageBox.Show("Ha elmented a bejelentkez�si adataidat, m�s is kiolvashatja �ket a g�pb�l (ha van hozz�f�r�se a felhaszn�l�dhoz). Biztosan el szeretn�d menteni a bejelentkez�si adataidat?", "Figyelmeztet�s", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                SaveLoginCheckBox.Checked = False
            End If
        End If
    End Sub

    Private Sub EKretaLoginFormClosed(sender As Object, e As EventArgs) Handles MyBase.Closing
        myClosed = True
    End Sub
End Class
