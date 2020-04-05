<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Subject
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SubjectNameLabel = New System.Windows.Forms.Label()
        Me.StartTimeLabel = New System.Windows.Forms.Label()
        Me.EndTimeLabel = New System.Windows.Forms.Label()
        Me.TeacherLabel = New System.Windows.Forms.Label()
        Me.myToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ClassRoomLabel = New System.Windows.Forms.Label()
        Me.myHomeworkIcon = New HF_Scraper.HomeworkIcon()
        Me.SuspendLayout()
        '
        'SubjectNameLabel
        '
        Me.SubjectNameLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubjectNameLabel.BackColor = System.Drawing.Color.Transparent
        Me.SubjectNameLabel.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.SubjectNameLabel.Location = New System.Drawing.Point(-1, -1)
        Me.SubjectNameLabel.Name = "SubjectNameLabel"
        Me.SubjectNameLabel.Size = New System.Drawing.Size(108, 36)
        Me.SubjectNameLabel.TabIndex = 1
        Me.SubjectNameLabel.Text = "<Hiba>"
        '
        'StartTimeLabel
        '
        Me.StartTimeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartTimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.StartTimeLabel.Location = New System.Drawing.Point(0, 72)
        Me.StartTimeLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.StartTimeLabel.Name = "StartTimeLabel"
        Me.StartTimeLabel.Size = New System.Drawing.Size(50, 13)
        Me.StartTimeLabel.TabIndex = 2
        Me.StartTimeLabel.Text = "<Hiba>"
        Me.StartTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'EndTimeLabel
        '
        Me.EndTimeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EndTimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.EndTimeLabel.Location = New System.Drawing.Point(98, 72)
        Me.EndTimeLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.EndTimeLabel.Name = "EndTimeLabel"
        Me.EndTimeLabel.Size = New System.Drawing.Size(50, 13)
        Me.EndTimeLabel.TabIndex = 2
        Me.EndTimeLabel.Text = "<Hiba>"
        Me.EndTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'TeacherLabel
        '
        Me.TeacherLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeacherLabel.BackColor = System.Drawing.Color.Transparent
        Me.TeacherLabel.Location = New System.Drawing.Point(0, 42)
        Me.TeacherLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TeacherLabel.Name = "TeacherLabel"
        Me.TeacherLabel.Size = New System.Drawing.Size(148, 13)
        Me.TeacherLabel.TabIndex = 2
        Me.TeacherLabel.Text = "<Hiba>"
        '
        'ClassRoomLabel
        '
        Me.ClassRoomLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClassRoomLabel.BackColor = System.Drawing.Color.Transparent
        Me.ClassRoomLabel.Location = New System.Drawing.Point(0, 57)
        Me.ClassRoomLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ClassRoomLabel.Name = "ClassRoomLabel"
        Me.ClassRoomLabel.Size = New System.Drawing.Size(148, 13)
        Me.ClassRoomLabel.TabIndex = 2
        Me.ClassRoomLabel.Text = "<Hiba>"
        '
        'myHomeworkIcon
        '
        Me.myHomeworkIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myHomeworkIcon.BackColor = System.Drawing.Color.Transparent
        Me.myHomeworkIcon.BackgroundImage = Global.HF_Scraper.My.Resources.Resources.house_icon_x32
        Me.myHomeworkIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.myHomeworkIcon.Location = New System.Drawing.Point(111, 3)
        Me.myHomeworkIcon.Name = "myHomeworkIcon"
        Me.myHomeworkIcon.Size = New System.Drawing.Size(32, 32)
        Me.myHomeworkIcon.TabIndex = 3
        '
        'Subject
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.myHomeworkIcon)
        Me.Controls.Add(Me.ClassRoomLabel)
        Me.Controls.Add(Me.TeacherLabel)
        Me.Controls.Add(Me.EndTimeLabel)
        Me.Controls.Add(Me.StartTimeLabel)
        Me.Controls.Add(Me.SubjectNameLabel)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(98, 90)
        Me.Name = "Subject"
        Me.Size = New System.Drawing.Size(148, 88)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents myHomeworkIcon As HomeworkIcon
    Friend WithEvents SubjectNameLabel As Label
    Friend WithEvents StartTimeLabel As Label
    Friend WithEvents EndTimeLabel As Label
    Friend WithEvents TeacherLabel As Label
    Friend WithEvents myToolTip As ToolTip
    Friend WithEvents ClassRoomLabel As Label
End Class
