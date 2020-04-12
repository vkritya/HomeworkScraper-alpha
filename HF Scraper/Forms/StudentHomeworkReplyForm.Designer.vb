<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentHomeworkReplyForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentHomeworkReplyForm))
        Me.myWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.myToolStrip = New System.Windows.Forms.ToolStrip()
        Me.FontToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.FontSizeToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.FontSizeToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.ForeColorToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.BackColorToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.BoldToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ItalicToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UnderlineToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StrikethroughToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.LeftToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CenterToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RightToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.JustifyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UnorderedListToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OrderedListToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.IndentToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OutdentToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.myToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'myWebBrowser
        '
        Me.myWebBrowser.AllowWebBrowserDrop = False
        Me.myWebBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myWebBrowser.IsWebBrowserContextMenuEnabled = False
        Me.myWebBrowser.Location = New System.Drawing.Point(0, 25)
        Me.myWebBrowser.Margin = New System.Windows.Forms.Padding(0)
        Me.myWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.myWebBrowser.Name = "myWebBrowser"
        Me.myWebBrowser.ScriptErrorsSuppressed = True
        Me.myWebBrowser.Size = New System.Drawing.Size(800, 400)
        Me.myWebBrowser.TabIndex = 0
        Me.myWebBrowser.WebBrowserShortcutsEnabled = False
        '
        'myToolStrip
        '
        Me.myToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.myToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripComboBox, Me.FontSizeToolStripComboBox, Me.FontSizeToolStripLabel, Me.ForeColorToolStripSplitButton, Me.BackColorToolStripSplitButton, Me.ToolStripSeparator1, Me.BoldToolStripButton, Me.ItalicToolStripButton, Me.UnderlineToolStripButton, Me.StrikethroughToolStripButton, Me.ToolStripSeparator2, Me.LeftToolStripButton, Me.CenterToolStripButton, Me.RightToolStripButton, Me.JustifyToolStripButton, Me.ToolStripSeparator3, Me.UnorderedListToolStripButton, Me.OrderedListToolStripButton, Me.IndentToolStripButton, Me.OutdentToolStripButton})
        Me.myToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.myToolStrip.Name = "myToolStrip"
        Me.myToolStrip.ShowItemToolTips = False
        Me.myToolStrip.Size = New System.Drawing.Size(800, 25)
        Me.myToolStrip.TabIndex = 1
        Me.myToolStrip.Text = "ToolStrip1"
        '
        'FontToolStripComboBox
        '
        Me.FontToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FontToolStripComboBox.Items.AddRange(New Object() {"Arial", "Courier New", "Times New Roman", "Verdana"})
        Me.FontToolStripComboBox.Name = "FontToolStripComboBox"
        Me.FontToolStripComboBox.Size = New System.Drawing.Size(125, 25)
        '
        'FontSizeToolStripComboBox
        '
        Me.FontSizeToolStripComboBox.AutoSize = False
        Me.FontSizeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FontSizeToolStripComboBox.DropDownWidth = 20
        Me.FontSizeToolStripComboBox.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"})
        Me.FontSizeToolStripComboBox.Name = "FontSizeToolStripComboBox"
        Me.FontSizeToolStripComboBox.Size = New System.Drawing.Size(40, 23)
        '
        'FontSizeToolStripLabel
        '
        Me.FontSizeToolStripLabel.Name = "FontSizeToolStripLabel"
        Me.FontSizeToolStripLabel.Size = New System.Drawing.Size(18, 22)
        Me.FontSizeToolStripLabel.Text = "pt"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'SendButton
        '
        Me.SendButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SendButton.Location = New System.Drawing.Point(3, 428)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(794, 28)
        Me.SendButton.TabIndex = 2
        Me.SendButton.TabStop = False
        Me.SendButton.Text = "Küldés"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'ForeColorToolStripSplitButton
        '
        Me.ForeColorToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ForeColorToolStripSplitButton.Image = CType(resources.GetObject("ForeColorToolStripSplitButton.Image"), System.Drawing.Image)
        Me.ForeColorToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ForeColorToolStripSplitButton.Name = "ForeColorToolStripSplitButton"
        Me.ForeColorToolStripSplitButton.Size = New System.Drawing.Size(32, 22)
        Me.ForeColorToolStripSplitButton.Text = "ToolStripSplitButton1"
        '
        'BackColorToolStripSplitButton
        '
        Me.BackColorToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BackColorToolStripSplitButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_backcolor_icon_x16
        Me.BackColorToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BackColorToolStripSplitButton.Name = "BackColorToolStripSplitButton"
        Me.BackColorToolStripSplitButton.Size = New System.Drawing.Size(32, 22)
        Me.BackColorToolStripSplitButton.Text = "ToolStripSplitButton1"
        '
        'BoldToolStripButton
        '
        Me.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BoldToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_bold_icon_x16
        Me.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BoldToolStripButton.Name = "BoldToolStripButton"
        Me.BoldToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BoldToolStripButton.Text = "ToolStripButton1"
        '
        'ItalicToolStripButton
        '
        Me.ItalicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItalicToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_italic_icon_x16
        Me.ItalicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItalicToolStripButton.Name = "ItalicToolStripButton"
        Me.ItalicToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ItalicToolStripButton.Text = "ToolStripButton2"
        '
        'UnderlineToolStripButton
        '
        Me.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnderlineToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_underline_icon_x16
        Me.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnderlineToolStripButton.Name = "UnderlineToolStripButton"
        Me.UnderlineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnderlineToolStripButton.Text = "ToolStripButton3"
        '
        'StrikethroughToolStripButton
        '
        Me.StrikethroughToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StrikethroughToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_strikethrough_icon_x16
        Me.StrikethroughToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StrikethroughToolStripButton.Name = "StrikethroughToolStripButton"
        Me.StrikethroughToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.StrikethroughToolStripButton.Text = "ToolStripButton4"
        '
        'LeftToolStripButton
        '
        Me.LeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_align_left_icon_x16
        Me.LeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton.Name = "LeftToolStripButton"
        Me.LeftToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton.Text = "ToolStripButton1"
        '
        'CenterToolStripButton
        '
        Me.CenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CenterToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_align_center_icon_x16
        Me.CenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CenterToolStripButton.Name = "CenterToolStripButton"
        Me.CenterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CenterToolStripButton.Text = "ToolStripButton2"
        '
        'RightToolStripButton
        '
        Me.RightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RightToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_align_right_icon_x16
        Me.RightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RightToolStripButton.Name = "RightToolStripButton"
        Me.RightToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RightToolStripButton.Text = "ToolStripButton3"
        '
        'JustifyToolStripButton
        '
        Me.JustifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.JustifyToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_align_justify_icon_x16
        Me.JustifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.JustifyToolStripButton.Name = "JustifyToolStripButton"
        Me.JustifyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.JustifyToolStripButton.Text = "ToolStripButton4"
        '
        'UnorderedListToolStripButton
        '
        Me.UnorderedListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnorderedListToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_unorderedlist_icon_x16
        Me.UnorderedListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnorderedListToolStripButton.Name = "UnorderedListToolStripButton"
        Me.UnorderedListToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnorderedListToolStripButton.Text = "ToolStripButton1"
        '
        'OrderedListToolStripButton
        '
        Me.OrderedListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OrderedListToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_orderedlist_icon_x16
        Me.OrderedListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OrderedListToolStripButton.Name = "OrderedListToolStripButton"
        Me.OrderedListToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OrderedListToolStripButton.Text = "ToolStripButton2"
        '
        'IndentToolStripButton
        '
        Me.IndentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.IndentToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_indent_icon_x16
        Me.IndentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.IndentToolStripButton.Name = "IndentToolStripButton"
        Me.IndentToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.IndentToolStripButton.Text = "ToolStripButton1"
        '
        'OutdentToolStripButton
        '
        Me.OutdentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OutdentToolStripButton.Image = Global.HF_Scraper.My.Resources.Resources.editor_outdent_icon_x16
        Me.OutdentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OutdentToolStripButton.Name = "OutdentToolStripButton"
        Me.OutdentToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OutdentToolStripButton.Text = "ToolStripButton1"
        '
        'StudentHomeworkReplyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 459)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.myToolStrip)
        Me.Controls.Add(Me.myWebBrowser)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MinimumSize = New System.Drawing.Size(600, 200)
        Me.Name = "StudentHomeworkReplyForm"
        Me.Text = "Komment Szerkesztő"
        Me.myToolStrip.ResumeLayout(False)
        Me.myToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents myWebBrowser As WebBrowser
    Friend WithEvents myToolStrip As ToolStrip
    Friend WithEvents FontToolStripComboBox As ToolStripComboBox
    Friend WithEvents SendButton As Button
    Friend WithEvents FontSizeToolStripLabel As ToolStripLabel
    Friend WithEvents ForeColorToolStripSplitButton As ToolStripSplitButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BoldToolStripButton As ToolStripButton
    Friend WithEvents ItalicToolStripButton As ToolStripButton
    Friend WithEvents UnderlineToolStripButton As ToolStripButton
    Friend WithEvents StrikethroughToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents LeftToolStripButton As ToolStripButton
    Friend WithEvents CenterToolStripButton As ToolStripButton
    Friend WithEvents RightToolStripButton As ToolStripButton
    Friend WithEvents JustifyToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents UnorderedListToolStripButton As ToolStripButton
    Friend WithEvents OrderedListToolStripButton As ToolStripButton
    Friend WithEvents IndentToolStripButton As ToolStripButton
    Friend WithEvents FontSizeToolStripComboBox As ToolStripComboBox
    Friend WithEvents OutdentToolStripButton As ToolStripButton
    Friend WithEvents BackColorToolStripSplitButton As ToolStripSplitButton
End Class
