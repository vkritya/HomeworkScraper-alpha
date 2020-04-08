Public Class StudentHomeworkView
    Public Sub New(homework As StudentHomework, initialWidth As Integer)
        InitializeComponent()
        myWebBrowser.DocumentText = homework.FeladatSzovege
        NameLabel.Text = homework.TanuloNev
        TimeLabel.Text = homework.FeladasDatuma.ToString("yyyy\/MM\/dd - hh:mm:ss")

        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Me.Width = initialWidth
    End Sub

    Private loadComplete As Boolean = False
    Private Sub WebBrowserComplete() Handles myWebBrowser.DocumentCompleted
        loadComplete = True
        myWebBrowser.Height = myWebBrowser.Document.Body.ScrollRectangle.Height
        Me.Height = myWebBrowser.Height + 51
        TimeLabel.Location = New Point(TimeLabel.Location.X, myWebBrowser.Height + 27)
    End Sub

    Public Sub ResizeControl(width As Integer)
        Me.Width = width
        If loadComplete Then
            WebBrowserComplete()
        End If
    End Sub
End Class
