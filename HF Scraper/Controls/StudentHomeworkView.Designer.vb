<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentHomeworkView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.myWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'NameLabel
        '
        Me.NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(1, 1)
        Me.NameLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(352, 23)
        Me.NameLabel.TabIndex = 0
        Me.NameLabel.Text = "Label1"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeLabel
        '
        Me.TimeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TimeLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TimeLabel.Location = New System.Drawing.Point(188, 124)
        Me.TimeLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(169, 23)
        Me.TimeLabel.TabIndex = 0
        Me.TimeLabel.Text = "2020/04/10 - 20:00:00"
        Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'myWebBrowser
        '
        Me.myWebBrowser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myWebBrowser.Location = New System.Drawing.Point(4, 26)
        Me.myWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.myWebBrowser.Name = "myWebBrowser"
        Me.myWebBrowser.ScrollBarsEnabled = False
        Me.myWebBrowser.Size = New System.Drawing.Size(349, 96)
        Me.myWebBrowser.TabIndex = 1
        '
        'StudentHomeworkView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.myWebBrowser)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Name = "StudentHomeworkView"
        Me.Size = New System.Drawing.Size(358, 148)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NameLabel As Label
    Friend WithEvents TimeLabel As Label
    Friend WithEvents myWebBrowser As WebBrowser
End Class
