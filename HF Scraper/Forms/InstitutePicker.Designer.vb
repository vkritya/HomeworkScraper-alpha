<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstitutePicker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.InstituteListBox = New System.Windows.Forms.ComboBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'InstituteListBox
        '
        Me.InstituteListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstituteListBox.FormattingEnabled = True
        Me.InstituteListBox.Location = New System.Drawing.Point(12, 12)
        Me.InstituteListBox.Name = "InstituteListBox"
        Me.InstituteListBox.Size = New System.Drawing.Size(370, 21)
        Me.InstituteListBox.TabIndex = 1
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(12, 39)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(370, 23)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'InstitutePicker
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 74)
        Me.ControlBox = False
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.InstituteListBox)
        Me.MaximumSize = New System.Drawing.Size(10000, 113)
        Me.MinimumSize = New System.Drawing.Size(410, 113)
        Me.Name = "InstitutePicker"
        Me.ShowInTaskbar = False
        Me.Text = "Iskola Választó"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents InstituteListBox As ComboBox
    Friend WithEvents OKButton As Button
End Class
