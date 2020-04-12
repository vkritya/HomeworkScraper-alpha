<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ColorDropDown
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
        Me.myColorEditorManager = New Cyotek.Windows.Forms.ColorEditorManager()
        Me.myHueSlider = New Cyotek.Windows.Forms.HueColorSlider()
        Me.mySaturationSlider = New Cyotek.Windows.Forms.SaturationColorSlider()
        Me.myValueSlider = New Cyotek.Windows.Forms.SaturationColorSlider()
        Me.myTextBox = New System.Windows.Forms.TextBox()
        Me.myColorIndicator = New System.Windows.Forms.PictureBox()
        CType(Me.myColorIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myHueSlider
        '
        Me.myHueSlider.Location = New System.Drawing.Point(6, 0)
        Me.myHueSlider.Name = "myHueSlider"
        Me.myHueSlider.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.myHueSlider.Size = New System.Drawing.Size(30, 120)
        Me.myHueSlider.TabIndex = 0
        Me.myHueSlider.TabStop = False
        '
        'mySaturationSlider
        '
        Me.mySaturationSlider.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mySaturationSlider.Location = New System.Drawing.Point(45, 0)
        Me.mySaturationSlider.Name = "mySaturationSlider"
        Me.mySaturationSlider.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.mySaturationSlider.Size = New System.Drawing.Size(30, 120)
        Me.mySaturationSlider.TabIndex = 0
        Me.mySaturationSlider.TabStop = False
        '
        'myValueSlider
        '
        Me.myValueSlider.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.myValueSlider.Location = New System.Drawing.Point(84, 0)
        Me.myValueSlider.Name = "myValueSlider"
        Me.myValueSlider.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.myValueSlider.Size = New System.Drawing.Size(30, 120)
        Me.myValueSlider.TabIndex = 0
        Me.myValueSlider.TabStop = False
        '
        'myTextBox
        '
        Me.myTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.myTextBox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.myTextBox.Location = New System.Drawing.Point(6, 124)
        Me.myTextBox.MaximumSize = New System.Drawing.Size(69, 20)
        Me.myTextBox.MaxLength = 7
        Me.myTextBox.Name = "myTextBox"
        Me.myTextBox.Size = New System.Drawing.Size(69, 22)
        Me.myTextBox.TabIndex = 1
        Me.myTextBox.Text = "#FFFFFF"
        Me.myTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.myTextBox.WordWrap = False
        '
        'myColorIndicator
        '
        Me.myColorIndicator.BackColor = System.Drawing.Color.Red
        Me.myColorIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.myColorIndicator.Location = New System.Drawing.Point(84, 124)
        Me.myColorIndicator.Name = "myColorIndicator"
        Me.myColorIndicator.Size = New System.Drawing.Size(21, 22)
        Me.myColorIndicator.TabIndex = 2
        Me.myColorIndicator.TabStop = False
        '
        'ColorDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.myColorIndicator)
        Me.Controls.Add(Me.myTextBox)
        Me.Controls.Add(Me.myValueSlider)
        Me.Controls.Add(Me.mySaturationSlider)
        Me.Controls.Add(Me.myHueSlider)
        Me.MinimumSize = New System.Drawing.Size(120, 150)
        Me.Name = "ColorDropDown"
        Me.Size = New System.Drawing.Size(120, 150)
        CType(Me.myColorIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents myColorEditorManager As Cyotek.Windows.Forms.ColorEditorManager
    Friend WithEvents myHueSlider As Cyotek.Windows.Forms.HueColorSlider
    Friend WithEvents mySaturationSlider As Cyotek.Windows.Forms.SaturationColorSlider
    Friend WithEvents myValueSlider As Cyotek.Windows.Forms.SaturationColorSlider
    Friend WithEvents myTextBox As TextBox
    Friend WithEvents myColorIndicator As PictureBox
End Class
