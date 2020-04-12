Public Class SchoolWeek

    Private myMainForm As MainForm
    'For Designer
    Public Sub New()
        InitializeComponent()
    End Sub
    'For Use
    Public Sub New(mainForm As Form)
        InitializeComponent()
        myMainForm = TryCast(mainForm, MainForm)
    End Sub

    Private SchoolDays(4) As SchoolDay

    Sub setLessons(lessons As List(Of eKretaLesson))
        Me.AutoScroll = False
        Me.VerticalScroll.Enabled = False
        Me.HorizontalScroll.Enabled = False
        Me.Controls.Clear()

        Me.myMainForm = MainForm
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
        Me.MaximumSize = New Size(769, Math.Max((maxTime.TimeOfDay - minTime.TimeOfDay).TotalMinutes * 2 + 4, Me.Height))
        Do Until lessons.Count = 0
            Application.DoEvents()
            If lessons.Count <= i + 1 OrElse lessons(i).StartTime.Day <> lessons(i + 1).StartTime.Day Then
                addSchoolDay(minTime, maxTime, lessons.GetRange(0, i + 1).ToArray)
                lessons.RemoveRange(0, i + 1)
                i = -1
            End If
            i += 1
        Loop
        Me.VerticalScroll.Enabled = True
        Me.HorizontalScroll.Enabled = True
        Me.AutoScroll = True
    End Sub
    Private Sub addSchoolDay(minTime As Date, maxTime As Date, lessons() As eKretaLesson)
        Dim index = lessons(0).StartTime.DayOfWeek - 1

        SchoolDays(index) = (New SchoolDay(myMainForm, minTime, maxTime, lessons))
        Me.Controls.Add(SchoolDays(index))
        SchoolDays(index).Location = New Point(index * 150, 0)

    End Sub

    Private Sub ScrollSmearFix() Handles Me.Scroll
        Me.Refresh()
    End Sub
End Class
