Public Class StudentHomeworkView
    Public Sub New(homework As StudentHomework, initialWidth As Integer)
        InitializeComponent()
        myWebBrowser.DocumentText = Net.WebUtility.HtmlDecode(homework.FeladatSzovege)
        NameLabel.Text = homework.TanuloNev
        TimeLabel.Text = homework.FeladasDatuma.ToString(Common.Constant.FORMAT_YMD_HMS)

        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Me.Width = initialWidth
    End Sub

    Private loadComplete As Boolean = False
    Private Sub myWebBrowserNavigating(sender As WebBrowser, e As WebBrowserNavigatingEventArgs) Handles myWebBrowser.Navigating
        If loadComplete Then
            Process.Start(e.Url.ToString)
            e.Cancel = True
        End If
    End Sub
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