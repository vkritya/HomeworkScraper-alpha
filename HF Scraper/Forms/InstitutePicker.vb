Public Class InstitutePicker

    Property myInstitute As Institute
    Dim myInstitutes As New List(Of Institute)

    Async Sub InstitutePicker_Shown() Handles Me.Shown
        InstituteListBox.Enabled = False
        OKButton.Enabled = False
        myInstitutes = Await eKreta.getInstitutes()
        Dim SortedData As New SortedDictionary(Of String, List(Of Institute))
        For Each e In myInstitutes
            If Not SortedData.ContainsKey(e.City) Then
                SortedData.Add(e.City, New List(Of Institute))
            End If
            SortedData(e.City).Add(e)
        Next
        myInstitutes.Clear()
        For Each value In SortedData.Values
            myInstitutes.AddRange(value.OrderBy(Function(e) e.Name).ToList)
        Next
        For Each e In myInstitutes
            InstituteListBox.Items.Add($"{e.City}, {e.Name}")
        Next
        InstituteListBox.SelectedIndex = 0
        InstituteListBox.Enabled = True
        OKButton.Enabled = True
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If InstituteListBox.SelectedIndex <> -1 Then
            myInstitute = myInstitutes.ElementAt(InstituteListBox.SelectedIndex)
            DialogResult = DialogResult.OK
            Me.Hide()
        End If
    End Sub
End Class