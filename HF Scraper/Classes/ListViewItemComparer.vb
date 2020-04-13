Public Class ListViewItemComparer
    Implements IComparer

    Public myColumn As Integer
    Private myOrder As SortOrder

    Public Sub New()
        myColumn = 0
        myOrder = SortOrder.Ascending
    End Sub
    Public Sub New(column As Integer, order As SortOrder)
        myColumn = column
        myOrder = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim returnValue As Integer

        Dim xText As String = CType(x, ListViewItem).SubItems(myColumn).Text
        Dim yText As String = CType(y, ListViewItem).SubItems(myColumn).Text

        returnValue = String.Compare(xText, yText)

        If myOrder = SortOrder.Descending Then
            returnValue *= -1
        End If

        Return returnValue
    End Function
End Class
