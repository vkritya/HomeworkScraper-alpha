<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.myTabControl = New System.Windows.Forms.TabControl()
        Me.TimetableTabPage = New System.Windows.Forms.TabPage()
        Me.TimetableSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.WeekTimeSpanLabel = New System.Windows.Forms.Label()
        Me.DecrementWeekButton = New System.Windows.Forms.Button()
        Me.IncrementWeekButton = New System.Windows.Forms.Button()
        Me.MessagesTabPage = New System.Windows.Forms.TabPage()
        Me.MessagesSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.MessagesListView = New System.Windows.Forms.ListView()
        Me.NullColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FeladoColoumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FeladasDatumaColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HataridoColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HomeworkTabPage = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RequestTypeCheckBox = New System.Windows.Forms.CheckBox()
        Me.myToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SettingsButton = New System.Windows.Forms.ToolStripButton()
        Me.myToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.myStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ProgressToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mySchoolWeek = New HF_Scraper.SchoolWeek()
        Me.myHomeworkDetail = New HF_Scraper.HomeworkDetail()
        Me.MessagesTimeSpanPicker = New HF_Scraper.TimeSpanPicker()
        Me.HomeworkTimeSpanPicker = New HF_Scraper.TimeSpanPicker()
        Me.myTabControl.SuspendLayout()
        Me.TimetableTabPage.SuspendLayout()
        CType(Me.TimetableSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TimetableSplitContainer.Panel1.SuspendLayout()
        Me.TimetableSplitContainer.Panel2.SuspendLayout()
        Me.TimetableSplitContainer.SuspendLayout()
        Me.MessagesTabPage.SuspendLayout()
        CType(Me.MessagesSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MessagesSplitContainer.Panel1.SuspendLayout()
        Me.MessagesSplitContainer.Panel2.SuspendLayout()
        Me.MessagesSplitContainer.SuspendLayout()
        Me.HomeworkTabPage.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.myToolStrip.SuspendLayout()
        Me.myStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'myTabControl
        '
        Me.myTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myTabControl.Controls.Add(Me.TimetableTabPage)
        Me.myTabControl.Controls.Add(Me.MessagesTabPage)
        Me.myTabControl.Controls.Add(Me.HomeworkTabPage)
        Me.myTabControl.Location = New System.Drawing.Point(0, 28)
        Me.myTabControl.Name = "myTabControl"
        Me.myTabControl.Padding = New System.Drawing.Point(0, 0)
        Me.myTabControl.SelectedIndex = 0
        Me.myTabControl.Size = New System.Drawing.Size(1022, 512)
        Me.myTabControl.TabIndex = 0
        Me.myTabControl.TabStop = False
        '
        'TimetableTabPage
        '
        Me.TimetableTabPage.Controls.Add(Me.TimetableSplitContainer)
        Me.TimetableTabPage.Location = New System.Drawing.Point(4, 22)
        Me.TimetableTabPage.Name = "TimetableTabPage"
        Me.TimetableTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TimetableTabPage.Size = New System.Drawing.Size(1014, 486)
        Me.TimetableTabPage.TabIndex = 0
        Me.TimetableTabPage.Text = "Órarend"
        Me.TimetableTabPage.UseVisualStyleBackColor = True
        '
        'TimetableSplitContainer
        '
        Me.TimetableSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TimetableSplitContainer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TimetableSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.TimetableSplitContainer.Location = New System.Drawing.Point(6, 6)
        Me.TimetableSplitContainer.Name = "TimetableSplitContainer"
        '
        'TimetableSplitContainer.Panel1
        '
        Me.TimetableSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.TimetableSplitContainer.Panel1.BackgroundImage = Global.HF_Scraper.My.Resources.Resources.Loading
        Me.TimetableSplitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TimetableSplitContainer.Panel1.Controls.Add(Me.WeekTimeSpanLabel)
        Me.TimetableSplitContainer.Panel1.Controls.Add(Me.DecrementWeekButton)
        Me.TimetableSplitContainer.Panel1.Controls.Add(Me.IncrementWeekButton)
        Me.TimetableSplitContainer.Panel1.Controls.Add(Me.mySchoolWeek)
        Me.TimetableSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'TimetableSplitContainer.Panel2
        '
        Me.TimetableSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.TimetableSplitContainer.Panel2.Controls.Add(Me.myHomeworkDetail)
        Me.TimetableSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TimetableSplitContainer.Size = New System.Drawing.Size(1002, 474)
        Me.TimetableSplitContainer.SplitterDistance = 769
        Me.TimetableSplitContainer.SplitterWidth = 6
        Me.TimetableSplitContainer.TabIndex = 0
        Me.TimetableSplitContainer.TabStop = False
        '
        'WeekTimeSpanLabel
        '
        Me.WeekTimeSpanLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WeekTimeSpanLabel.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.WeekTimeSpanLabel.Location = New System.Drawing.Point(380, 4)
        Me.WeekTimeSpanLabel.Name = "WeekTimeSpanLabel"
        Me.WeekTimeSpanLabel.Size = New System.Drawing.Size(329, 19)
        Me.WeekTimeSpanLabel.TabIndex = 2
        Me.WeekTimeSpanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DecrementWeekButton
        '
        Me.DecrementWeekButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DecrementWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DecrementWeekButton.Image = Global.HF_Scraper.My.Resources.Resources.button_left_icon_x20
        Me.DecrementWeekButton.Location = New System.Drawing.Point(715, 0)
        Me.DecrementWeekButton.Name = "DecrementWeekButton"
        Me.DecrementWeekButton.Size = New System.Drawing.Size(27, 27)
        Me.DecrementWeekButton.TabIndex = 1
        Me.DecrementWeekButton.TabStop = False
        Me.DecrementWeekButton.UseVisualStyleBackColor = True
        '
        'IncrementWeekButton
        '
        Me.IncrementWeekButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncrementWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IncrementWeekButton.Image = Global.HF_Scraper.My.Resources.Resources.button_right_icon_x20
        Me.IncrementWeekButton.Location = New System.Drawing.Point(742, 0)
        Me.IncrementWeekButton.Name = "IncrementWeekButton"
        Me.IncrementWeekButton.Size = New System.Drawing.Size(27, 27)
        Me.IncrementWeekButton.TabIndex = 1
        Me.IncrementWeekButton.TabStop = False
        Me.IncrementWeekButton.UseVisualStyleBackColor = True
        '
        'MessagesTabPage
        '
        Me.MessagesTabPage.Controls.Add(Me.MessagesSplitContainer)
        Me.MessagesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MessagesTabPage.Name = "MessagesTabPage"
        Me.MessagesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MessagesTabPage.Size = New System.Drawing.Size(1014, 486)
        Me.MessagesTabPage.TabIndex = 1
        Me.MessagesTabPage.Text = "Üzenetek"
        Me.MessagesTabPage.UseVisualStyleBackColor = True
        '
        'MessagesSplitContainer
        '
        Me.MessagesSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MessagesSplitContainer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MessagesSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.MessagesSplitContainer.Location = New System.Drawing.Point(6, 6)
        Me.MessagesSplitContainer.Name = "MessagesSplitContainer"
        '
        'MessagesSplitContainer.Panel1
        '
        Me.MessagesSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.MessagesSplitContainer.Panel1.Controls.Add(Me.MessagesListView)
        Me.MessagesSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'MessagesSplitContainer.Panel2
        '
        Me.MessagesSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.MessagesSplitContainer.Panel2.Controls.Add(Me.MessagesTimeSpanPicker)
        Me.MessagesSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.MessagesSplitContainer.Size = New System.Drawing.Size(1004, 474)
        Me.MessagesSplitContainer.SplitterDistance = 662
        Me.MessagesSplitContainer.SplitterWidth = 6
        Me.MessagesSplitContainer.TabIndex = 2
        Me.MessagesSplitContainer.TabStop = False
        '
        'MessagesListView
        '
        Me.MessagesListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MessagesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NullColumnHeader, Me.FeladoColoumnHeader, Me.FeladasDatumaColumnHeader, Me.HataridoColumnHeader, Me.StatusColumnHeader})
        Me.MessagesListView.Location = New System.Drawing.Point(0, 0)
        Me.MessagesListView.Name = "MessagesListView"
        Me.MessagesListView.Size = New System.Drawing.Size(662, 474)
        Me.MessagesListView.TabIndex = 1
        Me.MessagesListView.UseCompatibleStateImageBehavior = False
        Me.MessagesListView.View = System.Windows.Forms.View.Details
        '
        'NullColumnHeader
        '
        Me.NullColumnHeader.DisplayIndex = 4
        Me.NullColumnHeader.Width = 0
        '
        'FeladoColoumnHeader
        '
        Me.FeladoColoumnHeader.DisplayIndex = 0
        Me.FeladoColoumnHeader.Text = "Feladó"
        Me.FeladoColoumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FeladoColoumnHeader.Width = 138
        '
        'FeladasDatumaColumnHeader
        '
        Me.FeladasDatumaColumnHeader.DisplayIndex = 1
        Me.FeladasDatumaColumnHeader.Text = "Feladás Dátuma"
        Me.FeladasDatumaColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FeladasDatumaColumnHeader.Width = 104
        '
        'HataridoColumnHeader
        '
        Me.HataridoColumnHeader.DisplayIndex = 2
        Me.HataridoColumnHeader.Text = "Határidő"
        Me.HataridoColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusColumnHeader
        '
        Me.StatusColumnHeader.DisplayIndex = 3
        Me.StatusColumnHeader.Text = "Státusz"
        Me.StatusColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusColumnHeader.Width = 57
        '
        'HomeworkTabPage
        '
        Me.HomeworkTabPage.Controls.Add(Me.SplitContainer1)
        Me.HomeworkTabPage.Location = New System.Drawing.Point(4, 22)
        Me.HomeworkTabPage.Name = "HomeworkTabPage"
        Me.HomeworkTabPage.Size = New System.Drawing.Size(1014, 486)
        Me.HomeworkTabPage.TabIndex = 2
        Me.HomeworkTabPage.Text = "Házi Feladatok"
        Me.HomeworkTabPage.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.RequestTypeCheckBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.HomeworkTimeSpanPicker)
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Size = New System.Drawing.Size(1004, 474)
        Me.SplitContainer1.SplitterDistance = 662
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 3
        Me.SplitContainer1.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(662, 474)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 4
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 0
        Me.ColumnHeader2.Text = "Feladó"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 138
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 1
        Me.ColumnHeader3.Text = "Feladás Dátuma"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 104
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 2
        Me.ColumnHeader4.Text = "Határidő"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 3
        Me.ColumnHeader5.Text = "Státusz"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 57
        '
        'RequestTypeCheckBox
        '
        Me.RequestTypeCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RequestTypeCheckBox.AutoSize = True
        Me.RequestTypeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RequestTypeCheckBox.Location = New System.Drawing.Point(160, 382)
        Me.RequestTypeCheckBox.Name = "RequestTypeCheckBox"
        Me.RequestTypeCheckBox.Size = New System.Drawing.Size(172, 17)
        Me.RequestTypeCheckBox.TabIndex = 7
        Me.RequestTypeCheckBox.TabStop = False
        Me.RequestTypeCheckBox.Text = "Beadási határidőre kérdezzen?"
        Me.RequestTypeCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.myToolTip.SetToolTip(Me.RequestTypeCheckBox, "Pipáld ki ha azt szeretnéd, hogy a beadási határidők essenek a megadott tartomány" &
        "ba!")
        Me.RequestTypeCheckBox.UseVisualStyleBackColor = True
        '
        'myToolStrip
        '
        Me.myToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.myToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsButton})
        Me.myToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.myToolStrip.Name = "myToolStrip"
        Me.myToolStrip.Size = New System.Drawing.Size(1022, 25)
        Me.myToolStrip.TabIndex = 1
        Me.myToolStrip.Text = "ToolStrip1"
        '
        'SettingsButton
        '
        Me.SettingsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SettingsButton.Image = Global.HF_Scraper.My.Resources.Resources.settings_icon_x32
        Me.SettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(23, 22)
        Me.SettingsButton.Text = "Beállítások"
        '
        'myStatusStrip
        '
        Me.myStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressToolStripStatusLabel})
        Me.myStatusStrip.Location = New System.Drawing.Point(0, 539)
        Me.myStatusStrip.Name = "myStatusStrip"
        Me.myStatusStrip.Size = New System.Drawing.Size(1022, 22)
        Me.myStatusStrip.TabIndex = 2
        Me.myStatusStrip.Text = "StatusStrip1"
        '
        'ProgressToolStripStatusLabel
        '
        Me.ProgressToolStripStatusLabel.Name = "ProgressToolStripStatusLabel"
        Me.ProgressToolStripStatusLabel.Size = New System.Drawing.Size(120, 17)
        Me.ProgressToolStripStatusLabel.Text = "ToolStripStatusLabel1"
        '
        'mySchoolWeek
        '
        Me.mySchoolWeek.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mySchoolWeek.AutoScroll = True
        Me.mySchoolWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.mySchoolWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mySchoolWeek.Location = New System.Drawing.Point(0, 26)
        Me.mySchoolWeek.Margin = New System.Windows.Forms.Padding(0)
        Me.mySchoolWeek.Name = "mySchoolWeek"
        Me.mySchoolWeek.Size = New System.Drawing.Size(769, 448)
        Me.mySchoolWeek.TabIndex = 0
        '
        'myHomeworkDetail
        '
        Me.myHomeworkDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myHomeworkDetail.Location = New System.Drawing.Point(0, 0)
        Me.myHomeworkDetail.Name = "myHomeworkDetail"
        Me.myHomeworkDetail.Size = New System.Drawing.Size(227, 474)
        Me.myHomeworkDetail.TabIndex = 5
        Me.myHomeworkDetail.TabStop = False
        '
        'MessagesTimeSpanPicker
        '
        Me.MessagesTimeSpanPicker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MessagesTimeSpanPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MessagesTimeSpanPicker.Location = New System.Drawing.Point(0, 401)
        Me.MessagesTimeSpanPicker.MinimumSize = New System.Drawing.Size(154, 73)
        Me.MessagesTimeSpanPicker.Name = "MessagesTimeSpanPicker"
        Me.MessagesTimeSpanPicker.Size = New System.Drawing.Size(336, 73)
        Me.MessagesTimeSpanPicker.TabIndex = 3
        '
        'HomeworkTimeSpanPicker
        '
        Me.HomeworkTimeSpanPicker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HomeworkTimeSpanPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.HomeworkTimeSpanPicker.Location = New System.Drawing.Point(0, 401)
        Me.HomeworkTimeSpanPicker.MinimumSize = New System.Drawing.Size(154, 73)
        Me.HomeworkTimeSpanPicker.Name = "HomeworkTimeSpanPicker"
        Me.HomeworkTimeSpanPicker.Size = New System.Drawing.Size(336, 73)
        Me.HomeworkTimeSpanPicker.TabIndex = 3
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1022, 561)
        Me.Controls.Add(Me.myStatusStrip)
        Me.Controls.Add(Me.myTabControl)
        Me.Controls.Add(Me.myToolStrip)
        Me.MinimumSize = New System.Drawing.Size(509, 600)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.myTabControl.ResumeLayout(False)
        Me.TimetableTabPage.ResumeLayout(False)
        Me.TimetableSplitContainer.Panel1.ResumeLayout(False)
        Me.TimetableSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.TimetableSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimetableSplitContainer.ResumeLayout(False)
        Me.MessagesTabPage.ResumeLayout(False)
        Me.MessagesSplitContainer.Panel1.ResumeLayout(False)
        Me.MessagesSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MessagesSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MessagesSplitContainer.ResumeLayout(False)
        Me.HomeworkTabPage.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.myToolStrip.ResumeLayout(False)
        Me.myToolStrip.PerformLayout()
        Me.myStatusStrip.ResumeLayout(False)
        Me.myStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents myTabControl As TabControl
    Friend WithEvents TimetableTabPage As TabPage
    Friend WithEvents MessagesTabPage As TabPage
    Friend WithEvents myToolStrip As ToolStrip
    Friend WithEvents SettingsButton As ToolStripButton
    Friend WithEvents MessagesListView As ListView
    Friend WithEvents NullColumnHeader As ColumnHeader
    Friend WithEvents FeladoColoumnHeader As ColumnHeader
    Friend WithEvents FeladasDatumaColumnHeader As ColumnHeader
    Friend WithEvents HataridoColumnHeader As ColumnHeader
    Friend WithEvents StatusColumnHeader As ColumnHeader
    Friend WithEvents TimetableSplitContainer As SplitContainer
    Friend WithEvents MessagesSplitContainer As SplitContainer
    Friend WithEvents MessagesTimeSpanPicker As TimeSpanPicker
    Friend WithEvents myHomeworkDetail As HomeworkDetail
    Friend WithEvents myToolTip As ToolTip
    Friend WithEvents myStatusStrip As StatusStrip
    Friend WithEvents HomeworkTabPage As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents HomeworkTimeSpanPicker As TimeSpanPicker
    Friend WithEvents RequestTypeCheckBox As CheckBox
    Friend WithEvents ProgressToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents mySchoolWeek As SchoolWeek
    Friend WithEvents WeekTimeSpanLabel As Label
    Friend WithEvents DecrementWeekButton As Button
    Friend WithEvents IncrementWeekButton As Button
End Class
