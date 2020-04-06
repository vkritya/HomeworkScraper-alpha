﻿Public Class Subject
    Private myLesson As Lesson
    Private myMainForm As MainForm

    'For Blanks
    Public Sub New()
        InitializeComponent()
    End Sub

    'For Use
    Public Sub New(mainForm As MainForm, myLesson As Lesson)
        InitializeComponent()
        myMainForm = mainForm
        setLesson(myLesson)
    End Sub

    Public Sub setBlank(length As Integer)
        Me.BackColor = Parent.BackColor
        For Each control In Me.Controls
            TryCast(control, Control).Visible = False
        Next
        Me.MinimumSize = New Size(Me.MinimumSize.Width, 0)
        Me.Size = New Size(Me.Size.Width, length * 2)
    End Sub

    Public Sub setLesson(myLesson As Lesson)
        Me.myLesson = myLesson
        Me.Height = 2 * (myLesson.EndTime - myLesson.StartTime).TotalMinutes
        setLabel(SubjectNameLabel, myLesson.SubjectName)
        setLabel(TeacherLabel, myLesson.Teacher)
        setLabel(ClassRoomLabel, myLesson.ClassRoom)
        setLabel(StartTimeLabel, eKretaAA.Format.buildTime(myLesson.StartTime))
        setLabel(EndTimeLabel, eKretaAA.Format.buildTime(myLesson.EndTime))
        myHomeworkIcon.Visible = (myLesson.TeacherHomeworkID <> 0)
    End Sub

    Public Function getLesson() As Lesson
        Return myLesson
    End Function

    Private Sub setLabel(label As Label, text As String)
        label.Text = text
        myToolTip.SetToolTip(label, text)
    End Sub

    Private Sub ClickedHandler() Handles Me.Click, ClassRoomLabel.Click, EndTimeLabel.Click, myHomeworkIcon.Click, myHomeworkIcon.IsFinishedClicked, StartTimeLabel.Click, SubjectNameLabel.Click, TeacherLabel.Click
        If myLesson.TeacherHomeworkID <> 0 And myMainForm IsNot Nothing Then
            myMainForm.OpenHomeworkDetails(Me, myLesson.TeacherHomeworkID)
        End If
    End Sub

End Class
