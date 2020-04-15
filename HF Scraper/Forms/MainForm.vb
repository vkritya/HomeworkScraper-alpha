Class MainForm
    'Because VS Designer is drunk
    Private Sub LoadDesignerFix() Handles MyBase.Load
        MessagesTimeSpanPicker.Size = New Size(336, 73)
        HomeworkTimeSpanPicker.Size = New Size(336, 73)
        RequestTypeCheckBox.Location = New Point(160, 382)
    End Sub

    Private Async Sub MainFormShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'eKreta
        Try
            Await eKreta.Initialize()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim suppressNonAwaitedCallWarning = setSchoolWeek(Now, myCancelTokenSource.Token) 'Workaround


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
        Try
            Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
            Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week
            WeekTimeSpanLabel.Text = weekStart.ToString(Common.Constant.FORMAT_YMD) & " - " & weekEnd.ToString(Common.Constant.FORMAT_YMD)
            Dim lessons = Await eKreta.getLessonRangeUpdate(weekStart, weekEnd)
            If Not cancelToken.IsCancellationRequested Then
                mySchoolWeek.setLessons(lessons)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
    Private Sub DrawMessageColumnHeaders(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles MessagesListView.DrawColumnHeader
        If e.ColumnIndex <> 0 Then
            Dim header As ColumnHeader = MessagesListView.Columns(e.ColumnIndex)
            Dim size As SizeF = e.Graphics.MeasureString(header.Text, e.Font)

            Dim x As Single = (e.Bounds.Width - size.Width) / 2.0F

            e.DrawBackground()
            Using brush As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(header.Text, e.Font, brush, e.Bounds.X + x, 5.0F, StringFormat.GenericDefault)
            End Using
        End If
    End Sub

    'GET Messenger, Facebook, e-mail, e-ügyintézés, Classroom
    Private Async Sub MessagesTimeSpanPickerClick(fromDate As Date, toDate As Date) Handles MessagesTimeSpanPicker.FetchButtonClicked
        MessagesListView.Items.Clear()
        MessagesTimeSpanPicker.Enabled = False
        Dim eKretaMessageTask = eKreta.getMessageRange(fromDate, toDate)




        Try
            'e-Kréta
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        MessagesTimeSpanPicker.Enabled = True
    End Sub
    Private Sub addMessage(myMessage As Common.Struct.Message)
        Dim item As New ListViewItem
        item.Group = MessagesListView.Groups(myMessage.Service)
        item.SubItems.Add(myMessage.Sender)
        item.SubItems.Add(myMessage.myDate.ToString(Common.Constant.FORMAT_YMD_HMS))
        item.SubItems.Add(Net.WebUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(myMessage.MessageText, "<.*?>", " ").Trim))
        item.Tag = myMessage

        MessagesListView.Items.Add(item)
    End Sub
    Private Function getMessage() As Common.Struct.Message
        If MessagesListView.SelectedItems.Count <> 0 Then
            Dim item = MessagesListView.SelectedItems.Item(0)
            Return item.Tag
        End If
        Return Nothing
    End Function
#End Region

#Region "Homeworks"
    Private Sub DrawHomeworkColumnHeaders(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles HomeworksListView.DrawColumnHeader
        If e.ColumnIndex <> 0 Then
            Dim header As ColumnHeader = HomeworksListView.Columns(e.ColumnIndex)
            Dim size As SizeF = e.Graphics.MeasureString(header.Text, e.Font)

            Dim x As Single = (e.Bounds.Width - size.Width) / 2.0F

            e.DrawBackground()
            Using brush As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(header.Text, e.Font, brush, e.Bounds.X + x, 5.0F, StringFormat.GenericDefault)
            End Using
        End If
    End Sub

    'Load that stuff fam
    Private Async Sub HomeworkTimeSpanPickerClick(fromDate As Date, toDate As Date) Handles HomeworkTimeSpanPicker.FetchButtonClicked
        HomeworksListView.Items.Clear()
        HomeworkTimeSpanPicker.Enabled = False
        RequestTypeCheckBox.Enabled = False
        'eKreta
        Dim eKretaHomeworkTask As Task(Of List(Of eKretaHomework))
        If RequestTypeCheckBox.Checked Then
            eKretaHomeworkTask = eKreta.getHomeworksByDeadline(fromDate, toDate)
        Else
            eKretaHomeworkTask = eKreta.getHomeworkRangeUpdate(fromDate, toDate)
        End If
        'TODO többi beolvasás/lekérés


        Try
            For Each eKretaHomework In Await eKretaHomeworkTask
                Dim myHomework As Common.Struct.Homework
                myHomework.Service = Common.Struct.ServiceType.eKretaHomework
                myHomework.HomeworkID = eKretaHomework.ID
                myHomework.myDate = eKretaHomework.FeladasDatuma
                myHomework.myDeadlineDate = eKretaHomework.Hatarido
                myHomework.Subject = eKretaHomework.Tantargy
                myHomework.Sender = eKretaHomework.Rogzito
                myHomework.HomeworkText = eKretaHomework.Szoveg
                myHomework.Attachment = Nothing

                If eKretaHomework.IsTanuloHaziFeladatEnabled Then
                    myHomework.Comments = New List(Of Common.Struct.Comment)
                    For Each comment In eKretaHomework.StudentHomeworks
                        Dim myComment As Common.Struct.Comment
                        myComment.CommentID = comment.Id
                        myComment.CommentText = comment.FeladatSzovege
                        myComment.myDate = comment.FeladasDatuma
                        myComment.Sender = comment.TanuloNev
                        myComment.Attachment = Nothing
                        myHomework.Comments.Add(myComment)
                    Next
                Else
                    myHomework.Comments = Nothing
                End If
                'Add to ListView
                addHomework(myHomework)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        HomeworkTimeSpanPicker.Enabled = True
        RequestTypeCheckBox.Enabled = True
    End Sub
    Private Sub addHomework(myHomework As Common.Struct.Homework)
        Dim item As New ListViewItem
        item.Group = HomeworksListView.Groups(myHomework.Service)
        item.SubItems.Add(myHomework.Sender)
        item.SubItems.Add(myHomework.myDate.ToString(Common.Constant.FORMAT_YMD))
        item.SubItems.Add(myHomework.myDeadlineDate.ToString(Common.Constant.FORMAT_YMD))
        item.SubItems.Add(Net.WebUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(myHomework.HomeworkText, "<.*?>", " ").Trim))
        item.Tag = myHomework

        HomeworksListView.Items.Add(item)
    End Sub
    Private Function getHomework() As Common.Struct.Homework
        If HomeworksListView.SelectedItems.Count <> 0 Then
            Dim item = HomeworksListView.SelectedItems.Item(0)
            Return item.Tag
        End If
        Return Nothing
    End Function

    Private Sub HomeworksListViewItemChanged(sender As ListView, e As EventArgs) Handles HomeworksListView.SelectedIndexChanged
        If sender.SelectedItems.Count <> 0 Then
            HomeworksHomeworkDetail.setHomework(sender.SelectedItems(0).Tag)
        End If
    End Sub
#End Region

#Region "ListView Common"
    Private Sub DrawItems(sender As Object, e As DrawListViewItemEventArgs) Handles HomeworksListView.DrawItem, MessagesListView.DrawItem
        e.DrawDefault = True
    End Sub
    Private Sub DrawSubItems(sender As Object, e As DrawListViewSubItemEventArgs) Handles HomeworksListView.DrawSubItem, MessagesListView.DrawSubItem
        e.DrawDefault = True
    End Sub
    Private Sub ListViewColumnClick(sender As ListView, e As ColumnClickEventArgs) Handles HomeworksListView.ColumnClick, MessagesListView.ColumnClick
        If e.Column <> sender.Tag Then
            sender.Tag = e.Column
            sender.Sorting = SortOrder.Ascending
        Else
            If sender.Sorting = SortOrder.Ascending Then
                sender.Sorting = SortOrder.Descending
            Else
                sender.Sorting = SortOrder.Ascending
            End If
        End If

        sender.ListViewItemSorter = New ListViewItemComparer(e.Column, sender.Sorting)
        sender.Sort()
    End Sub
#End Region
End Class