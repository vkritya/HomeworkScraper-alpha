<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeworkIcon
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
        Me.IsFinished = New System.Windows.Forms.PictureBox()
        CType(Me.IsFinished, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsFinished
        '
        Me.IsFinished.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsFinished.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IsFinished.Image = Global.HF_Scraper.My.Resources.Resources.checkmark_icon_x20
        Me.IsFinished.Location = New System.Drawing.Point(10, 10)
        Me.IsFinished.Margin = New System.Windows.Forms.Padding(0)
        Me.IsFinished.Name = "IsFinished"
        Me.IsFinished.Size = New System.Drawing.Size(20, 20)
        Me.IsFinished.TabIndex = 0
        Me.IsFinished.TabStop = False
        Me.IsFinished.Visible = False
        '
        'HomeworkIcon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.HF_Scraper.My.Resources.Resources.house_icon_x32
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.IsFinished)
        Me.Name = "HomeworkIcon"
        Me.Size = New System.Drawing.Size(32, 32)
        CType(Me.IsFinished, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents IsFinished As PictureBox
End Class
