Public Class InstitutePicker

    Property InstituteId
    Dim myInstitutes As New List(Of Institute)

    Async Sub InstitutePicker_Shown() Handles Me.Shown
        Me.Enabled = False
        myInstitutes = Await eKreta.getInstituteList()
        Dim SorterData As New SortedDictionary(Of String, List(Of Institute))
        For Each e In myInstitutes
            If Not SorterData.ContainsKey(e.City) Then
                SorterData.Add(e.City, New List(Of Institute))
            End If
            SorterData(e.City).Add(e)
        Next
        myInstitutes.Clear()
        For Each value In SorterData.Values
            myInstitutes.AddRange(value.OrderBy(Function(e) e.Name).ToList)
        Next
        For Each e In myInstitutes
            InstituteListBox.Items.Add(e.City + ", " + e.Name)
        Next
        InstituteListBox.SelectedIndex = 0
        Me.Enabled = True
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        InstituteId = myInstitutes.ElementAt(InstituteListBox.SelectedIndex).InstituteId
        DialogResult = DialogResult.OK
        Me.Hide()
    End Sub
End Class