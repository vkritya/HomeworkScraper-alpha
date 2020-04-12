Public Class HomeworkDetail
    Dim myHomework As eKretaHomework
    Private LOCKED As Boolean = False
    Private WithEvents myStudentHomeworkReplyForm As StudentHomeworkReplyForm

    Public Function getHomework() As eKretaHomework
        Return myHomework
    End Function

    Public Sub setHomework(homework As eKretaHomework?)
        If Not LOCKED Then
            If myStudentHomeworkReplyForm IsNot Nothing Then
                myStudentHomeworkReplyForm = Nothing
            End If

            If homework IsNot Nothing Then
                myHomework = homework.Value

                NoNameLabel1.Visible = True
                NoNameLabel2.Visible = True
                SplitContainer1.Visible = True
                SendButton.Visible = True
                'Clear StudentHomeworks
                StudentHomeworkFlowLayoutPanel.Controls.Clear()
                'Set Data
                SubjectLabel.Text = homework.Value.Tantargy.ToUpper
                DeadlineLabel.Text = "HATÁRIDŐ: " & homework.Value.Hatarido.ToString(Common.Constant.FORMAT_YMD)
                SenderLabel.Text = homework.Value.Rogzito
                SentDateLabel.Text = homework.Value.FeladasDatuma.ToString(Common.Constant.FORMAT_YMD)
                SendButton.Enabled = homework.Value.IsTanuloHaziFeladatEnabled
                triggerNavigate = False
                ContentWebBrowser.DocumentText = homework.Value.Szoveg.Replace("target=""_blank""", "target=""_self""")
                'Add StudentHomeworks
                If homework.Value.IsTanuloHaziFeladatEnabled Then
                    setStudentHomeworks(homework.Value.StudentHomeworks)
                End If
            Else
                myHomework = New eKretaHomework
                'Hide everything
                SubjectLabel.Text = ""
                DeadlineLabel.Text = ""
                SenderLabel.Text = ""
                SentDateLabel.Text = ""
                NoNameLabel1.Visible = False
                NoNameLabel2.Visible = False
                SplitContainer1.Visible = False
                SendButton.Visible = False
            End If
        End If
    End Sub

    Private Sub setStudentHomeworks(homeworks As List(Of StudentHomework))
        StudentHomeworkFlowLayoutPanel.AutoScroll = False
        For Each homework In homeworks
            Dim myStudentHomeworkView = New StudentHomeworkView(homework, StudentHomeworkFlowLayoutPanel.Width - 6)
            StudentHomeworkFlowLayoutPanel.Controls.Add(myStudentHomeworkView)
        Next
        StudentHomeworkFlowLayoutPanel.AutoScroll = True
    End Sub
    Private Sub passResize() Handles StudentHomeworkFlowLayoutPanel.Resize
        If StudentHomeworkFlowLayoutPanel.VerticalScroll.Visible Then
            For Each control As StudentHomeworkView In StudentHomeworkFlowLayoutPanel.Controls
                control.ResizeControl(StudentHomeworkFlowLayoutPanel.Width - 6 - 17)
            Next
        Else
            For Each control As StudentHomeworkView In StudentHomeworkFlowLayoutPanel.Controls
                control.ResizeControl(StudentHomeworkFlowLayoutPanel.Width - 6)
            Next
        End If
    End Sub

    Private triggerNavigate = False
    Private Sub ContentWebBrowserDocumentComplete() Handles ContentWebBrowser.DocumentCompleted
        triggerNavigate = True
    End Sub
    Private Sub ContentWebBrowserNavigating(sender As WebBrowser, e As WebBrowserNavigatingEventArgs) Handles ContentWebBrowser.Navigating
        If triggerNavigate Then
            Process.Start(e.Url.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Async Sub SendButtonClick() Handles SendButton.Click
        If myStudentHomeworkReplyForm Is Nothing Then
            myStudentHomeworkReplyForm = New StudentHomeworkReplyForm(Me)
        End If
        LOCKED = True
        SendButton.Enabled = False
        'Block
        If myStudentHomeworkReplyForm.ShowDialog() = DialogResult.OK Then
        End If
        'Workaround
        If myStudentHomeworkReplyForm.DialogResult = DialogResult.OK Then
            myStudentHomeworkReplyForm = New StudentHomeworkReplyForm(Me)
            LOCKED = False
            setHomework(Await eKreta.getHomeworkByIDUpdate(myHomework.ID))
        End If
        SendButton.Enabled = True
        LOCKED = False
    End Sub
End Class