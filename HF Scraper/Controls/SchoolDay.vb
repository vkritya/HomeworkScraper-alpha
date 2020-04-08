Public Class SchoolDay

    Private myMainForm As MainForm

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(mainForm As MainForm, minTime As Date, maxTime As Date, myLessonArray() As Lesson)
        InitializeComponent()
        Me.myMainForm = mainForm
        Initialize(minTime, maxTime, myLessonArray)
    End Sub
    Public Sub Initialize(minTime As Date, maxTime As Date, myLessonArray() As Lesson)
        If myLessonArray.Length > 0 Then
            If (myLessonArray(0).StartTime - minTime).TotalMinutes > 0 Then
                addBlank((myLessonArray(0).StartTime.TimeOfDay - minTime.TimeOfDay).TotalMinutes)
            End If
            For i = 0 To myLessonArray.Length - 2
                addSubject(myLessonArray(i))
                addBlank((myLessonArray(i + 1).StartTime - myLessonArray(i).EndTime).TotalMinutes)
            Next
            addSubject(myLessonArray.Last)
            If (maxTime.TimeOfDay - myLessonArray.Last.EndTime.TimeOfDay).TotalMinutes > 0 Then
                addBlank((maxTime.TimeOfDay - myLessonArray.Last.EndTime.TimeOfDay).TotalMinutes)
            End If
        End If
    End Sub

    Private Sub addBlank(length As ULong)
        Dim mySubject As New Subject(myMainForm)
        Me.Controls.Add(mySubject)
        mySubject.setBlank(length)
    End Sub
    Private Sub addSubject(lesson As Lesson)
        Dim mySubject As New Subject(myMainForm, lesson)
        Me.Controls.Add(mySubject)
    End Sub

End Class
