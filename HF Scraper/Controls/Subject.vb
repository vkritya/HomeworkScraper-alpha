Public Class Subject
    Private myLesson As Lesson? = Nothing
    Private myMainForm As MainForm

    'For Blanks
    Public Sub New(mainForm As MainForm)
        myMainForm = mainForm
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
        setLabel(StartTimeLabel, myLesson.StartTime.ToString("hh:mm"))
        setLabel(EndTimeLabel, myLesson.EndTime.ToString("hh:mm"))
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
        If myLesson.HasValue AndAlso myLesson.Value.TeacherHomeworkID <> 0 Then
            myMainForm.OpenHomeworkDetails(Me, myLesson.Value.TeacherHomeworkID)
        Else
            myMainForm.BlankHomeworkDetails()
        End If
    End Sub

End Class
