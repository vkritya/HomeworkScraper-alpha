Imports System.Text.RegularExpressions
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class MainForm

    Private Async Sub MainFormShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'eKreta
        Await eKreta.Initialize()
        setSchoolWeek(Now, myCancelTokenSource.Token)



        'getInstituteList()
        'Dim token = eKreta.getAccessToken(myInstitute.Url, myInstitute.InstituteCode)
        'eKreta.getAccessToken("https://klik037632001.e-kreta.hu", "klik037632001", "YTk2NTcwYTgtMDE5Yy00NjBiLWIwMWUtODYwNWQ2YmQxODBmIyM3OThmYjliOS1kZTBmLTRiMTQtOTE4Yy0xNTQzMWIyNjQxOTM=")
        'Dim asd = Await eKretaFunctions.getHomeworkList("https://klik037632001.e-kreta.hu", "2020-03-30", "2020-03-30", getAccessToken(myInstitute.Url, myInstitute.InstituteCode))
        'Dim asd = Await getMessages(getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'downloadFile(asd(2).Files(0), "C:\Users\kozosgep\Desktop\cuccer.docx", getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'SchoolDay1.Initialize(#2020/04/01 8:00#, #2020/04/01 13:25#, asd.ToArray)
        'MsgBox($"{Me.TimetableSplitContainer.Panel2.Size.Width}")
    End Sub

#Region "Timetable"
    Dim myWeek As Date = Now
    Dim myCancelTokenSource As New Threading.CancellationTokenSource

    Private Sub DecrementWeekButtonClick() Handles DecrementWeekButton.Click
        myWeek = myWeek.AddDays(-7)
        Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
        Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week
        WeekTimeSpanLabel.Text = weekStart.ToString(GlobalConstants.FORMAT_YMD) & " - " & weekEnd.ToString(GlobalConstants.FORMAT_YMD)

        myCancelTokenSource.Cancel()
        myCancelTokenSource = New Threading.CancellationTokenSource
#Disable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
        setSchoolWeek(myWeek, myCancelTokenSource.Token)
#Enable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
    End Sub
    Private Sub IncrementWeekButtonClick() Handles IncrementWeekButton.Click
        myWeek = myWeek.AddDays(7)
        Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
        Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week
        WeekTimeSpanLabel.Text = weekStart.ToString(GlobalConstants.FORMAT_YMD) & " - " & weekEnd.ToString(GlobalConstants.FORMAT_YMD)

        myCancelTokenSource.Cancel()
        myCancelTokenSource = New Threading.CancellationTokenSource
#Disable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
        setSchoolWeek(myWeek, myCancelTokenSource.Token)
#Enable Warning BC42358 ' Because this call is not awaited, execution of the current method continues before the call is completed
    End Sub
    Private Async Function setSchoolWeek(week As Date, cancelToken As Threading.CancellationToken) As Task
        Dim weekStart = myWeek.AddDays(-myWeek.DayOfWeek + 1) 'Set to monday of week
        Dim weekEnd = weekStart.AddDays(4) 'Set to friday of week
        WeekTimeSpanLabel.Text = weekStart.ToString(GlobalConstants.FORMAT_YMD) & " - " & weekEnd.ToString(GlobalConstants.FORMAT_YMD)
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

    Public Sub UpdateUI()

    End Sub
End Class