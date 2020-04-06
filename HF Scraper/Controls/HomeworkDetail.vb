Public Class HomeworkDetail
    Dim myHomework As Homework

    Public Sub setHomework(homework As Homework?)
        If homework IsNot Nothing Then
            myHomework = homework.Value

            ContentWebBrowser.Visible = True
            NoNameLabel1.Visible = True
            NoNameLabel2.Visible = True

            SubjectLabel.Text = homework.Value.Tantargy.ToUpper
            DeadlineLabel.Text = $"HATÁRIDŐ: {homework.Value.Hatarido.Year}/{homework.Value.Hatarido.Month}/{homework.Value.Hatarido.Day}"
            SenderLabel.Text = homework.Value.Rogzito
            SentDateLabel.Text = $"{homework.Value.FeladasDatuma.Year}/{homework.Value.FeladasDatuma.Month}/{homework.Value.FeladasDatuma.Day}"
            ContentWebBrowser.DocumentText = homework.Value.Szoveg
            'TODO Add StudentHomeworks
        Else
            myHomework = New Homework
            SubjectLabel.Text = ""
            DeadlineLabel.Text = ""
            SenderLabel.Text = ""
            SentDateLabel.Text = ""
            ContentWebBrowser.Visible = False
            NoNameLabel1.Visible = False
            NoNameLabel2.Visible = False
        End If
    End Sub

End Class
