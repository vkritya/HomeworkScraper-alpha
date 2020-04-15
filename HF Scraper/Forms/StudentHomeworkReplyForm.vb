Imports mshtml
Imports System.Text.RegularExpressions
Class StudentHomeworkReplyForm

    Private myParent As Object

    Public Sub New(parent As TimetableHomeworkDetail)
        myParent = parent
        InitializeComponent()
    End Sub

    Public Sub New(parent As HomeworkDetail)
        myParent = parent
        InitializeComponent()
    End Sub

    Private Sub myWebBrowserDocumentCompleted() Handles myWebBrowser.DocumentCompleted
        Dim axObj = myWebBrowser.ActiveXInstance
        Dim document As HTMLDocumentClass = axObj.document
        document.designMode = "On"

        myWebBrowser.Document.AttachEventHandler("onselectionchange", SelectionChange)
    End Sub

    Private Sub StudentHomeworkReplyFormLoad() Handles MyBase.Load
        myWebBrowser.DocumentText = "<head></head><body></body>"
    End Sub

    Dim doEvents As Boolean = True

    Private SelectionChange As EventHandler =
    Sub()
        Dim range = getRange()
        doEvents = False
        If range IsNot Nothing Then

            Dim parentElement As IHTMLElement = range.parentElement
            Do Until parentElement.tagName = "BODY" OrElse parentElement.tagName = "P" OrElse parentElement.tagName = "LI"
                parentElement = parentElement.parentElement
            Loop
            'Font Name and Size
            FontToolStripComboBox.SelectedItem = range.queryCommandValue("fontname")
            If parentElement.style.getAttribute("font-size") Is Nothing Then
                If parentElement.tagName = "BODY" Then
                    parentElement.style.setAttribute("font-size", "12pt")
                ElseIf parentElement.tagName = "P" Then
                    parentElement.style.setAttribute("font-size", parentElement.parentElement.style.getAttribute("font-size"))
                ElseIf parentElement.tagName = "LI" Then
                    parentElement.style.setAttribute("font-size", parentElement.parentElement.parentElement.style.getAttribute("font-size"))
                End If
            End If
            If parentElement.style.getAttribute("font-size") IsNot Nothing Then
                FontSizeToolStripComboBox.SelectedItem = parentElement.style.getAttribute("font-size").Replace("pt", "")
            End If
            'Font style (Bold, Italic...)
            BoldToolStripButton.Checked = range.queryCommandState("bold")
            ItalicToolStripButton.Checked = range.queryCommandState("italic")
            UnderlineToolStripButton.Checked = range.queryCommandState("underline")
            StrikethroughToolStripButton.Checked = range.queryCommandState("strikethrough")
            'Justification
            If parentElement.style.getAttribute("text-align") Is Nothing Then
                parentElement.style.setAttribute("text-align", "left")
            End If
            LeftToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "left"
            CenterToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "center"
            RightToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "right"
            JustifyToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "justify"
            'Lists
            UnorderedListToolStripButton.Checked = range.queryCommandState("InsertUnorderedList")
            OrderedListToolStripButton.Checked = range.queryCommandState("InsertOrderedList")
        End If
        doEvents = True
    End Sub

    Private Function getRange() As IHTMLTxtRange
        Try
            Dim document As IHTMLDocument2 = DirectCast(myWebBrowser.Document.DomDocument, IHTMLDocument2)
            Dim selection As IHTMLSelectionObject = DirectCast(document.selection, IHTMLSelectionObject)
            If document IsNot Nothing AndAlso (document.selection.type.ToString = "Text" OrElse document.selection.type.ToString = "None") Then
                Return DirectCast(document.selection.createRange(), IHTMLTxtRange)
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Sub FontChange() Handles FontToolStripComboBox.SelectedIndexChanged
        If doEvents Then
            Dim range = getRange()
            If range IsNot Nothing Then
                range = range.duplicate
                If range.text Is Nothing Then
                    Dim parentElement As IHTMLElement = range.parentElement()
                    Do Until parentElement.tagName = "BODY" OrElse parentElement.tagName = "P" OrElse parentElement.tagName = "LI"
                        parentElement = parentElement.parentElement
                    Loop
                    If parentElement.isTextEdit Then
                        range.moveToElementText(parentElement)
                    End If
                    range.execCommand("fontname", False, FontToolStripComboBox.SelectedItem)
                Else
                    range.execCommand("fontname", False, FontToolStripComboBox.SelectedItem)
                End If
            End If
        End If
    End Sub
    Private Sub FontSizeChange() Handles FontSizeToolStripComboBox.SelectedIndexChanged
        If doEvents Then
            Dim range = getRange()
            If range IsNot Nothing Then

                Dim parentElement As IHTMLElement = range.parentElement()
                Do Until parentElement.tagName = "BODY" OrElse parentElement.tagName = "P" OrElse parentElement.tagName = "LI"
                    parentElement = parentElement.parentElement
                Loop
                If parentElement.tagName = "BODY" Then
                    For Each element As IHTMLElement In parentElement.children
                        element.style.setAttribute("font-size", FontSizeToolStripComboBox.SelectedItem & "pt")
                    Next
                End If
                parentElement.style.setAttribute("font-size", FontSizeToolStripComboBox.SelectedItem & "pt")
            End If
        End If
    End Sub

    Private Sub StyleToolStripButtonClick(sender As ToolStripButton, e As EventArgs) Handles BoldToolStripButton.Click, ItalicToolStripButton.Click, UnderlineToolStripButton.Click, StrikethroughToolStripButton.Click
        Dim range = getRange()
        If range IsNot Nothing Then
            range = range.duplicate
            If range.text Is Nothing Then
                range.expand("word")
                If range.text IsNot Nothing AndAlso Char.IsWhiteSpace(range.text.Last) Then
                    range.moveEnd("character", -1)
                End If
            End If

            Dim command As String = ""
            If sender.Equals(BoldToolStripButton) Then
                command = "bold"
            ElseIf sender.Equals(ItalicToolStripButton) Then
                command = "italic"
            ElseIf sender.Equals(UnderlineToolStripButton) Then
                command = "underline"
            Else
                command = "strikethrough"
            End If

            range.execCommand(command)
            sender.Checked = range.queryCommandState(command)
        End If
    End Sub

    Private Sub JustificationToolStripButtonClick(sender As ToolStripButton, e As EventArgs) Handles LeftToolStripButton.Click, CenterToolStripButton.Click, RightToolStripButton.Click, JustifyToolStripButton.Click
        Dim range = getRange()
        If range IsNot Nothing Then
            range = range.duplicate
            If range.text Is Nothing Then
                range.expand("character")
            End If

            Dim attribute As String = ""
            If sender.Equals(LeftToolStripButton) Then
                attribute = "left"
            ElseIf sender.Equals(CenterToolStripButton) Then
                attribute = "center"
            ElseIf sender.Equals(RightToolStripButton) Then
                attribute = "right"
            Else
                attribute = "justify"
            End If
            Dim parentElement As IHTMLElement = range.parentElement

            Do Until parentElement.tagName = "BODY" OrElse parentElement.tagName = "P" OrElse parentElement.tagName = "LI"
                parentElement = parentElement.parentElement
            Loop
            If parentElement.tagName = "BODY" Then
                For Each element As HTMLParaElement In parentElement.children
                    element.style.setAttribute("text-align", attribute)
                Next
                parentElement.style.setAttribute("text-align", attribute)
            Else
                If range.parentElement.getAttribute("text-align").ToString = attribute Then
                    parentElement.style.setAttribute("text-align", "left")
                Else
                    parentElement.style.setAttribute("text-align", attribute)
                End If
            End If
            LeftToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "left"
            CenterToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "center"
            RightToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "right"
            JustifyToolStripButton.Checked = parentElement.style.getAttribute("text-align").ToString = "justify"
        End If
    End Sub

    Private Sub ListToolStripButtonClick(sender As ToolStripButton, e As EventArgs) Handles OrderedListToolStripButton.Click, UnorderedListToolStripButton.Click
        Dim range = getRange()
        If range IsNot Nothing Then
            Dim command As String = ""
            If sender.Equals(OrderedListToolStripButton) Then
                command = "InsertOrderedList"
            Else
                command = "InsertUnorderedList"
            End If
            range.execCommand(command)
            sender.Checked = range.queryCommandState(command)
        End If
    End Sub

    Private Sub IndentationToolStripButtonClick(sender As ToolStripButton, e As EventArgs) Handles IndentToolStripButton.Click, OutdentToolStripButton.Click
        If doEvents Then
            Dim range = getRange()
            If range IsNot Nothing Then
                range = range.duplicate
                If range.text Is Nothing Then
                    range.expand("character")
                End If

                Dim command As String = ""
                If sender.Equals(IndentToolStripButton) Then
                    command = "indent"
                Else
                    command = "outdent"
                End If
                range.execCommand(command)
            End If
        End If
    End Sub

    Private Sub SendButtonClick() Handles SendButton.Click
        If MessageBox.Show("Biztos el szeretnéd küldeni az üzenetet?", "Megerősítés szükséges", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If TypeOf myParent.getHomework Is eKretaHomework Then
                eKreta.sendStudentHomework(myParent.getHomework, convertToHTML5(myWebBrowser.Document.Body.InnerHtml))
            Else
                Select Case myParent.gethomework.service
                    Case Common.Struct.ServiceType.eKretaHomework
                        eKreta.sendStudentHomework(New eKretaHomework(myParent.getHomework), convertToHTML5(myWebBrowser.Document.Body.InnerHtml))
                End Select
            End If
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Function convertToHTML5(str As String)
        str = Regex.Replace(str, "<BLOCKQUOTE( style="".*?)"" dir=ltr>", "<div$1; margin-left: 30px"">")
        str = Regex.Replace(str, "<U>|<U .*?(?:style=""(.*?)"")?(.*?)>", "<span style=""$1;text-decoration: underline"" $2>")
        str = Regex.Replace(str, "<FONT(?: style=""([^""]*)"")?(?: color=(#[0-9a-f]{6}))?(?: face=""?([^"">]*)""?)?>", "<span style=""$1; color: $2; font-family: '$3'"">")
        str = Regex.Replace(str, "(<span style="".*?)(?:font-family: '')(?=.*?"">)", "$1")
        str = Regex.Replace(str, "(<span style="".*?)(?:color: (?!#))(?=.*?"">)", "$1")

        Return str.Replace("</U>", "</span>").Replace("</FONT>", "</span>").Replace("</BLOCKQUOTE>", "</div>")
    End Function

    Private Sub ColorToolStripSplitButtonClick(sender As Object, e As EventArgs) Handles ForeColorToolStripSplitButton.ButtonClick, BackColorToolStripSplitButton.ButtonClick
        Dim command As String = ""
        Dim color As String = ""
        If sender.Equals(ForeColorToolStripSplitButton) Then
            command = "foreColor"
            color = myForeColorPicker.myTextBox.Text
        Else
            command = "backColor"
            color = myBackColorPicker.myTextBox.Text
        End If
        If Regex.Match(color, Common.Constant.REGEX_HEX).Success Then
            Dim range = getRange()
            If range IsNot Nothing Then
                range = range.duplicate
                If range.text Is Nothing Then
                    range.expand("word")
                    If range.text IsNot Nothing AndAlso Char.IsWhiteSpace(range.text.Last) Then
                        range.moveEnd("character", -1)
                    End If
                End If

                range.execCommand(command, False, color)
            End If
        End If
    End Sub

    Private myForeColorPicker As New ColorDropDown()
    Private myBackColorPicker As New ColorDropDown()

    Private Sub ColorStripDropDownOpening(sender As ToolStripSplitButton, e As EventArgs) Handles ForeColorToolStripSplitButton.DropDownOpening, BackColorToolStripSplitButton.DropDownOpening
        Dim toolHost As ToolStripControlHost
        If sender.Equals(ForeColorToolStripSplitButton) Then
            toolHost = New ToolStripControlHost(myForeColorPicker)
        Else
            toolHost = New ToolStripControlHost(myBackColorPicker)
        End If
        toolHost.Size = myForeColorPicker.MinimumSize
        toolHost.Margin = New Padding(0)
        Dim toolDrop As ToolStripDropDown = New ToolStripDropDown
        toolDrop.Padding = New Padding(0)
        toolDrop.Items.Add(toolHost)
        toolDrop.Show(Me, New Point(sender.Bounds.Left, sender.Bounds.Bottom))
    End Sub

    Private Sub CloseOverride(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    Private Sub StudentHomeworkReplyFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ColorStripDropDownOpening(sender As Object, e As EventArgs) Handles ForeColorToolStripSplitButton.DropDownOpening, BackColorToolStripSplitButton.DropDownOpening

    End Sub

    Private Sub StyleToolStripButtonClick(sender As Object, e As EventArgs) Handles UnderlineToolStripButton.Click, StrikethroughToolStripButton.Click, ItalicToolStripButton.Click, BoldToolStripButton.Click

    End Sub

    Private Sub JustificationToolStripButtonClick(sender As Object, e As EventArgs) Handles RightToolStripButton.Click, LeftToolStripButton.Click, JustifyToolStripButton.Click, CenterToolStripButton.Click

    End Sub

    Private Sub ListToolStripButtonClick(sender As Object, e As EventArgs) Handles UnorderedListToolStripButton.Click, OrderedListToolStripButton.Click

    End Sub

    Private Sub IndentationToolStripButtonClick(sender As Object, e As EventArgs) Handles OutdentToolStripButton.Click, IndentToolStripButton.Click

    End Sub
End Class