Public Class SchoolWeek

    Private myMainForm As MainForm
    'For Designer
    Public Sub New()
        InitializeComponent()
    End Sub
    'For Use
    Public Sub New(mainForm As MainForm, lessons As List(Of Lesson))
        InitializeComponent()
        Me.myMainForm = mainForm
        setLessons(lessons)
    End Sub

    Private SchoolDays(4) As SchoolDay

    Sub setLessons(lessons As List(Of Lesson))
        lessons = lessons.OrderBy(Function(e) e.StartTime).ToList
        Dim i As Integer

        Dim minTime As Date = Date.MaxValue
        Dim maxTime As Date = Date.MinValue
        For Each lesson In lessons
            If minTime.TimeOfDay > lesson.StartTime.TimeOfDay Then
                minTime = lesson.StartTime
            End If
            If maxTime.TimeOfDay < lesson.EndTime.TimeOfDay Then
                maxTime = lesson.EndTime
            End If
        Next
        Me.MaximumSize = New Size(769, (maxTime.TimeOfDay - minTime.TimeOfDay).TotalMinutes * 2 + 4)
        Do Until lessons.Count = 0
            If lessons.Count <= i + 1 OrElse lessons(i).StartTime.Day <> lessons(i + 1).StartTime.Day Then
                addSchoolDay(minTime, maxTime, lessons.GetRange(0, i + 1).ToArray)
                lessons.RemoveRange(0, i + 1)
                i = -1
            End If
            i += 1
        Loop
    End Sub
    Private Sub addSchoolDay(minTime As Date, maxTime As Date, lessons() As Lesson)
        Dim index = lessons(0).StartTime.DayOfWeek - 1

        SchoolDays(index) = New SchoolDay(myMainForm, minTime, maxTime, lessons)
        Me.Controls.Add(SchoolDays(index))
        SchoolDays(index).Location = New Point(index * 150, 0)
    End Sub

    Private Sub ScrollSmearFix() Handles Me.Scroll
        Me.Refresh()
    End Sub
End Class
