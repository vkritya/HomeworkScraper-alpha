<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeworkDetail
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
        Me.ContentWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.SubjectLabel = New System.Windows.Forms.Label()
        Me.NoNameLabel1 = New System.Windows.Forms.Label()
        Me.SenderLabel = New System.Windows.Forms.Label()
        Me.NoNameLabel2 = New System.Windows.Forms.Label()
        Me.SentDateLabel = New System.Windows.Forms.Label()
        Me.DeadlineLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ContentWebBrowser
        '
        Me.ContentWebBrowser.AllowWebBrowserDrop = False
        Me.ContentWebBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentWebBrowser.IsWebBrowserContextMenuEnabled = False
        Me.ContentWebBrowser.Location = New System.Drawing.Point(3, 78)
        Me.ContentWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ContentWebBrowser.Name = "ContentWebBrowser"
        Me.ContentWebBrowser.Size = New System.Drawing.Size(344, 319)
        Me.ContentWebBrowser.TabIndex = 0
        Me.ContentWebBrowser.TabStop = False
        Me.ContentWebBrowser.WebBrowserShortcutsEnabled = False
        '
        'SubjectLabel
        '
        Me.SubjectLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubjectLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.SubjectLabel.ForeColor = System.Drawing.Color.Black
        Me.SubjectLabel.Location = New System.Drawing.Point(3, 3)
        Me.SubjectLabel.Name = "SubjectLabel"
        Me.SubjectLabel.Size = New System.Drawing.Size(344, 23)
        Me.SubjectLabel.TabIndex = 1
        Me.SubjectLabel.Text = "FIZIKA"
        Me.SubjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NoNameLabel1
        '
        Me.NoNameLabel1.AutoSize = True
        Me.NoNameLabel1.Location = New System.Drawing.Point(3, 46)
        Me.NoNameLabel1.Name = "NoNameLabel1"
        Me.NoNameLabel1.Size = New System.Drawing.Size(42, 13)
        Me.NoNameLabel1.TabIndex = 2
        Me.NoNameLabel1.Text = "Feladó:"
        '
        'SenderLabel
        '
        Me.SenderLabel.AutoSize = True
        Me.SenderLabel.Location = New System.Drawing.Point(94, 46)
        Me.SenderLabel.Name = "SenderLabel"
        Me.SenderLabel.Size = New System.Drawing.Size(39, 13)
        Me.SenderLabel.TabIndex = 2
        Me.SenderLabel.Text = "Label2"
        '
        'NoNameLabel2
        '
        Me.NoNameLabel2.AutoSize = True
        Me.NoNameLabel2.Location = New System.Drawing.Point(3, 62)
        Me.NoNameLabel2.Name = "NoNameLabel2"
        Me.NoNameLabel2.Size = New System.Drawing.Size(85, 13)
        Me.NoNameLabel2.TabIndex = 5
        Me.NoNameLabel2.Text = "Feladás dátuma:"
        '
        'SentDateLabel
        '
        Me.SentDateLabel.AutoSize = True
        Me.SentDateLabel.Location = New System.Drawing.Point(94, 62)
        Me.SentDateLabel.Name = "SentDateLabel"
        Me.SentDateLabel.Size = New System.Drawing.Size(39, 13)
        Me.SentDateLabel.TabIndex = 2
        Me.SentDateLabel.Text = "Label2"
        '
        'DeadlineLabel
        '
        Me.DeadlineLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeadlineLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DeadlineLabel.ForeColor = System.Drawing.Color.Black
        Me.DeadlineLabel.Location = New System.Drawing.Point(3, 23)
        Me.DeadlineLabel.Name = "DeadlineLabel"
        Me.DeadlineLabel.Size = New System.Drawing.Size(344, 20)
        Me.DeadlineLabel.TabIndex = 1
        Me.DeadlineLabel.Text = "HATÁRIDŐ: 2020/02/42"
        Me.DeadlineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'HomeworkDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NoNameLabel2)
        Me.Controls.Add(Me.SentDateLabel)
        Me.Controls.Add(Me.SenderLabel)
        Me.Controls.Add(Me.NoNameLabel1)
        Me.Controls.Add(Me.DeadlineLabel)
        Me.Controls.Add(Me.SubjectLabel)
        Me.Controls.Add(Me.ContentWebBrowser)
        Me.Name = "HomeworkDetail"
        Me.Size = New System.Drawing.Size(350, 400)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ContentWebBrowser As WebBrowser
    Friend WithEvents SubjectLabel As Label
    Friend WithEvents NoNameLabel1 As Label
    Friend WithEvents SenderLabel As Label
    Friend WithEvents NoNameLabel2 As Label
    Friend WithEvents SentDateLabel As Label
    Friend WithEvents DeadlineLabel As Label
End Class
