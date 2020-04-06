<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TimeSpanPicker
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
        Me.FromDateTextBox = New System.Windows.Forms.TextBox()
        Me.ToDateTextBox = New System.Windows.Forms.TextBox()
        Me.FetchButton = New System.Windows.Forms.Button()
        Me.FromDateLabel = New System.Windows.Forms.Label()
        Me.ToDateLabel = New System.Windows.Forms.Label()
        Me.ThisWeekButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FromDateTextBox
        '
        Me.FromDateTextBox.Location = New System.Drawing.Point(3, 3)
        Me.FromDateTextBox.Name = "FromDateTextBox"
        Me.FromDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FromDateTextBox.TabIndex = 0
        Me.FromDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToDateTextBox
        '
        Me.ToDateTextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToDateTextBox.Location = New System.Drawing.Point(109, 3)
        Me.ToDateTextBox.Name = "ToDateTextBox"
        Me.ToDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ToDateTextBox.TabIndex = 1
        Me.ToDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FetchButton
        '
        Me.FetchButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FetchButton.Location = New System.Drawing.Point(109, 43)
        Me.FetchButton.Name = "FetchButton"
        Me.FetchButton.Size = New System.Drawing.Size(100, 23)
        Me.FetchButton.TabIndex = 2
        Me.FetchButton.Text = "Frissítés"
        Me.FetchButton.UseVisualStyleBackColor = True
        '
        'FromDateLabel
        '
        Me.FromDateLabel.Location = New System.Drawing.Point(3, 26)
        Me.FromDateLabel.Name = "FromDateLabel"
        Me.FromDateLabel.Size = New System.Drawing.Size(100, 14)
        Me.FromDateLabel.TabIndex = 2
        Me.FromDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToDateLabel
        '
        Me.ToDateLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToDateLabel.Location = New System.Drawing.Point(109, 26)
        Me.ToDateLabel.Name = "ToDateLabel"
        Me.ToDateLabel.Size = New System.Drawing.Size(100, 14)
        Me.ToDateLabel.TabIndex = 2
        Me.ToDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ThisWeekButton
        '
        Me.ThisWeekButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ThisWeekButton.Location = New System.Drawing.Point(3, 43)
        Me.ThisWeekButton.Name = "ThisWeekButton"
        Me.ThisWeekButton.Size = New System.Drawing.Size(100, 23)
        Me.ThisWeekButton.TabIndex = 2
        Me.ThisWeekButton.Text = "Jelenlegi hét"
        Me.ThisWeekButton.UseVisualStyleBackColor = True
        '
        'TimeSpanPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.ToDateLabel)
        Me.Controls.Add(Me.FromDateLabel)
        Me.Controls.Add(Me.ThisWeekButton)
        Me.Controls.Add(Me.FetchButton)
        Me.Controls.Add(Me.ToDateTextBox)
        Me.Controls.Add(Me.FromDateTextBox)
        Me.MinimumSize = New System.Drawing.Size(154, 73)
        Me.Name = "TimeSpanPicker"
        Me.Size = New System.Drawing.Size(216, 73)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FromDateTextBox As TextBox
    Friend WithEvents ToDateTextBox As TextBox
    Friend WithEvents FetchButton As Button
    Friend WithEvents FromDateLabel As Label
    Friend WithEvents ToDateLabel As Label
    Friend WithEvents ThisWeekButton As Button
End Class
