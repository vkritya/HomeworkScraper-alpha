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
        Me.myTabControl = New System.Windows.Forms.TabControl()
        Me.TimetableTabPage = New System.Windows.Forms.TabPage()
        Me.TimetableSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MessagesListView = New System.Windows.Forms.ListView()
        Me.NullColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FeladoColoumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FeladasDatumaColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HataridoColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TopToolStrip = New System.Windows.Forms.ToolStrip()
        Me.BottomToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ProgressLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SettingsButton = New System.Windows.Forms.ToolStripButton()
        Me.myTabControl.SuspendLayout()
        Me.TimetableTabPage.SuspendLayout()
        CType(Me.TimetableSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TimetableSplitContainer.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TopToolStrip.SuspendLayout()
        Me.BottomToolStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'myTabControl
        '
        Me.myTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myTabControl.Controls.Add(Me.TimetableTabPage)
        Me.myTabControl.Controls.Add(Me.TabPage2)
        Me.myTabControl.Location = New System.Drawing.Point(0, 28)
        Me.myTabControl.Name = "myTabControl"
        Me.myTabControl.Padding = New System.Drawing.Point(0, 0)
        Me.myTabControl.SelectedIndex = 0
        Me.myTabControl.Size = New System.Drawing.Size(1022, 509)
        Me.myTabControl.TabIndex = 0
        Me.myTabControl.TabStop = False
        '
        'TimetableTabPage
        '
        Me.TimetableTabPage.Controls.Add(Me.TimetableSplitContainer)
        Me.TimetableTabPage.Location = New System.Drawing.Point(4, 22)
        Me.TimetableTabPage.Name = "TimetableTabPage"
        Me.TimetableTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TimetableTabPage.Size = New System.Drawing.Size(1014, 483)
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
        Me.TimetableSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'TimetableSplitContainer.Panel2
        '
        Me.TimetableSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.TimetableSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TimetableSplitContainer.Size = New System.Drawing.Size(1002, 471)
        Me.TimetableSplitContainer.SplitterDistance = 350
        Me.TimetableSplitContainer.SplitterWidth = 6
        Me.TimetableSplitContainer.TabIndex = 0
        Me.TimetableSplitContainer.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1014, 483)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Üzenetek"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MessagesListView
        '
        Me.MessagesListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MessagesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NullColumnHeader, Me.FeladoColoumnHeader, Me.FeladasDatumaColumnHeader, Me.HataridoColumnHeader, Me.StatusColumnHeader})
        Me.MessagesListView.Location = New System.Drawing.Point(0, 0)
        Me.MessagesListView.Name = "MessagesListView"
        Me.MessagesListView.Size = New System.Drawing.Size(350, 471)
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
        'TopToolStrip
        '
        Me.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TopToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsButton})
        Me.TopToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStrip.Name = "TopToolStrip"
        Me.TopToolStrip.Size = New System.Drawing.Size(1022, 25)
        Me.TopToolStrip.TabIndex = 1
        Me.TopToolStrip.Text = "ToolStrip1"
        '
        'BottomToolStrip
        '
        Me.BottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BottomToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressLabel})
        Me.BottomToolStrip.Location = New System.Drawing.Point(0, 536)
        Me.BottomToolStrip.Name = "BottomToolStrip"
        Me.BottomToolStrip.Size = New System.Drawing.Size(1022, 25)
        Me.BottomToolStrip.TabIndex = 2
        Me.BottomToolStrip.Text = "ToolStrip2"
        '
        'ProgressLabel
        '
        Me.ProgressLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(96, 22)
        Me.ProgressLabel.Text = "<progressLabel>"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.MessagesListView)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Size = New System.Drawing.Size(1004, 471)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 2
        Me.SplitContainer1.TabStop = False
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
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1022, 561)
        Me.Controls.Add(Me.myTabControl)
        Me.Controls.Add(Me.BottomToolStrip)
        Me.Controls.Add(Me.TopToolStrip)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.myTabControl.ResumeLayout(False)
        Me.TimetableTabPage.ResumeLayout(False)
        CType(Me.TimetableSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TimetableSplitContainer.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TopToolStrip.ResumeLayout(False)
        Me.TopToolStrip.PerformLayout()
        Me.BottomToolStrip.ResumeLayout(False)
        Me.BottomToolStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents myTabControl As TabControl
    Friend WithEvents TimetableTabPage As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TopToolStrip As ToolStrip
    Friend WithEvents BottomToolStrip As ToolStrip
    Friend WithEvents ProgressLabel As ToolStripLabel
    Friend WithEvents SettingsButton As ToolStripButton
    Friend WithEvents MessagesListView As ListView
    Friend WithEvents NullColumnHeader As ColumnHeader
    Friend WithEvents FeladoColoumnHeader As ColumnHeader
    Friend WithEvents FeladasDatumaColumnHeader As ColumnHeader
    Friend WithEvents HataridoColumnHeader As ColumnHeader
    Friend WithEvents StatusColumnHeader As ColumnHeader
    Friend WithEvents TimetableSplitContainer As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
