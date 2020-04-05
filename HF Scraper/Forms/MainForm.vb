Imports System.Text.RegularExpressions
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports HF_Scraper.eKreta

Public Class MainForm

    Public Sub OpenHomeworkDetails(subjectControl As Subject, homeworkID As ULong)
        MsgBox("Peniszman: " + subjectControl.getLesson().StartTime.ToString("ddd HH:mm"))
    End Sub

    Private Async Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Await Initialize(Me)

        'getInstituteList()

        Dim myInstitute = Await getInstituteFromID(771)

        'Dim token = eKreta.getAccessToken(myInstitute.Url, myInstitute.InstituteCode)
        'eKreta.getAccessToken("https://klik037632001.e-kreta.hu", "klik037632001", "YTk2NTcwYTgtMDE5Yy00NjBiLWIwMWUtODYwNWQ2YmQxODBmIyM3OThmYjliOS1kZTBmLTRiMTQtOTE4Yy0xNTQzMWIyNjQxOTM=")
        Dim asd = Await getLessonList(myInstitute.Url, "2020-03-30", "2020-04-03", getAccessToken(myInstitute.Url, myInstitute.InstituteID))
        'Dim asd = Await eKretaFunctions.getHomeworkList("https://klik037632001.e-kreta.hu", "2020-03-30", "2020-03-30", getAccessToken(myInstitute.Url, myInstitute.InstituteCode))
        'Dim asd = Await getMessages(getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'downloadFile(asd(2).Files(0), "C:\Users\kozosgep\Desktop\cuccer.docx", getAccessToken(myInstitute.Url, myInstitute.InstituteId))
        'SchoolDay1.Initialize(#2020/04/01 8:00#, #2020/04/01 13:25#, asd.ToArray)
        Dim myschoolweek As New SchoolWeek(Me, asd)
        Me.TimetableSplitContainer.Panel1.Controls.Add(myschoolweek)
        myschoolweek.Location = New Point(0, 0)
        myschoolweek.Size = Me.TimetableSplitContainer.Panel1.Size
        TimetableSplitContainer.SplitterDistance = myschoolweek.Width
    End Sub

    Private Sub SplitterMaxSize(sender As Object, e As SplitterEventArgs) Handles TimetableSplitContainer.SplitterMoved
        With TimetableSplitContainer
            If .SplitterDistance - .SplitterWidth / 2 > 769 Then
                .SplitterDistance = 769
            End If
        End With
    End Sub
End Class