Public Class MainForm

    Private Async Sub MainFormShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'eKreta
        Await eKreta.Initialize()
        setSchoolWeek(Now, myCancelTokenSource.Token)

        Dim asd = Await eKreta.getMessages()

        'Dim studentHomeworkReply As New StudentHomeworkReplyForm(myHomeworkDetail)
        'studentHomeworkReply.Show()

        'getInstituteList()
        'Dim token = eKreta.getAccessToken(myInstitute.Url, myInstitute.InstituteCode)
        'eKreta.getAccessToken("https://klik037632001.e-kreta.hu", "klik037632001", "YTk2NTcwYTgtMDE5Yy00NjBiLWIwMWUtODYwNWQ2YmQxODBmIyM3OThmYjliOS1kZTBmLTRiMTQtOTE4Yy0xNTQzMWIyNjQxOTM=")
        'Dim asd = Await eKretaFunctions.getHomeworkList("https://klik037632001.e-kreta.hu", "2020-03-30", "2020-03-30", getAccessToken(myInstitute.Url, myInstitute.InstituteCode))
        'Dim asd = Await getMessages(getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'downloadFile(asd(2).Files(0), "C:\Users\kozosgep\Desktop\cuccer.docx", getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'SchoolDay1.Initialize(#2020/04/01 8:00#, #2020/04/01 13:25#, asd.ToArray)
        'MsgBox($"{Me.TimetableSplitContainer.Panel2.Size.Width}")
    End Sub

    Private Sub SettingsButtonClick() Handles SettingsButton.Click

    End Sub

#Region "Timetable"
    Dim myWeek As Date = Now
    Dim myCancelTokenSource As New Threading.CancellationTokenSource

    Private Sub ChangeWeekButtonClick(sender As Button, e As EventArgs) Handles DecrementWeekButton.Click, IncrementWeekButton.Click
        If sender.Equals(DecrementWeekButton) Then
            myWeek = myWeek.AddDays(-7)
        Else
            myWeek = myWeek.AddDays(7)
        End If
        Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
        Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week

        WeekTimeSpanLabel.Text = weekStart.ToString(Common.Constant.FORMAT_YMD) & " - " & weekEnd.ToString(Common.Constant.FORMAT_YMD)

        myCancelTokenSource.Cancel()
        myCancelTokenSource = New Threading.CancellationTokenSource
#Disable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
        setSchoolWeek(myWeek, myCancelTokenSource.Token)
#Enable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
    End Sub
    Private Async Function setSchoolWeek(week As Date, cancelToken As Threading.CancellationToken) As Task
        Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
        Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week
        WeekTimeSpanLabel.Text = weekStart.ToString(Common.Constant.FORMAT_YMD) & " - " & weekEnd.ToString(Common.Constant.FORMAT_YMD)
        Dim lessons = Await eKreta.getLessonRangeUpdate(weekStart, weekEnd)
        If Not cancelToken.IsCancellationRequested Then
            mySchoolWeek.setLessons(lessons)
        End If
    End Function

    Public Async Sub OpenHomeworkDetails(subjectControl As Subject, homeworkID As ULong)
        myHomeworkDetail.setHomework(Nothing)
        myHomeworkDetail.setHomework(Await eKreta.getHomeworkByIDUpdate(homeworkID))
    End Sub
    Public Sub BlankHomeworkDetails()
        myHomeworkDetail.setHomework(Nothing)
    End Sub

    Private Sub TimetableSplitterMaxSize(sender As Object, e As SplitterEventArgs) Handles TimetableSplitContainer.SplitterMoved
        With TimetableSplitContainer
            If .SplitterDistance > 769 Then
                .SplitterDistance = 769
            End If
        End With
    End Sub
#End Region

#Region "Messages"
    'GET Messenger, Facebook, e-mail, e-ügyintézés, classroom
    Private Async Sub MessagesTimeSpanPickerClick(fromDate As Date, toDate As Date) Handles MessagesTimeSpanPicker.FetchButtonClicked
        MessagesTimeSpanPicker.Enabled = False
        Dim eKretaMessageTask = eKreta.getMessageRange(fromDate, toDate)


        'e-Kreta
        For Each eKretaMessage In Await eKretaMessageTask
            Dim myMessage As Common.Struct.Message
            myMessage.Service = Common.Struct.ServiceType.eKretaMessage
            myMessage.MessageID = eKretaMessage.ID
            myMessage.MessageText = eKretaMessage.MessageBody
            myMessage.Sender = eKretaMessage.SenderName
            myMessage.myDate = eKretaMessage.myDate
            myMessage.Attachment = eKretaMessage.Files

            myMessage.Comments = Nothing
            addMessage(myMessage)
        Next

        MessagesTimeSpanPicker.Enabled = True
    End Sub
    Private Sub addMessage(myMessage As Common.Struct.Message)

    End Sub
#End Region

#Region "Homeworks"
    Private Async Sub HomeworkTimeSpanPickerClick() Handles HomeworkTimeSpanPicker.FetchButtonClicked
        Message
    End Sub


#End Region


End Class