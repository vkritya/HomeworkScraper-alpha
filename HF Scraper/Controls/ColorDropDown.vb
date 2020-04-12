Imports Cyotek.Windows.Forms
Imports System.Text.RegularExpressions
Public Class ColorDropDown

    'Public Event colorSelected(color As Color)

    Private myColorCollection As ColorCollection
    Private textBoxEvent As Boolean = False
    Private sliderEvent As Boolean = False

    Private Sub myLoad() Handles MyBase.Load
        myColorCollection = myHueSlider.CustomColors
        myValueSlider.Color2 = Color.Black
        UpdateUI(Me)
        textBoxEvent = True
        sliderEvent = True
    End Sub

    Private Sub myColorSliderValueChanged(sender As Object, e As EventArgs) Handles myHueSlider.ValueChanged, myValueSlider.ValueChanged, mySaturationSlider.ValueChanged
        If sliderEvent Then
            textBoxEvent = False
            UpdateUI(sender)
            'RaiseEvent colorSelected(HEXToRGB(myTextBox.Text))
            textBoxEvent = True
        End If
    End Sub

    Private Sub TextBoxTextChanged(sender As Object, e As EventArgs) Handles myTextBox.TextChanged
        Dim caretpos As Integer = myTextBox.SelectionStart
        If textBoxEvent Then
            textBoxEvent = False
            If Regex.Match(myTextBox.Text, Common.Constant.REGEX_HEX).Success Then

                If myTextBox.Text.Length = 6 Then
                    myTextBox.Text = "#" & myTextBox.Text
                    myTextBox.SelectionStart = caretpos + 1
                End If

                Dim color As Color = HEXToRGB(myTextBox.Text)
                sliderEvent = False
                Dim hue As Integer = color.GetHue
                If hue = 360 Then
                    hue = 0
                End If
                myHueSlider.Value = hue
                mySaturationSlider.Value = 100 - color.GetSaturation * 100
                myValueSlider.Value = 100 - Math.Max(Math.Max(color.R, color.G), color.B) / 255 * 100
                UpdateUI(sender)
                sliderEvent = True
                'RaiseEvent colorSelected(color)
            Else
                If myTextBox.Text.Contains("#") Then
                    myTextBox.Text = myTextBox.Text.Replace("#", "")
                    caretpos -= 1
                End If

                Dim delta = myTextBox.Text.Length
                myTextBox.Text = clearInvalidChars(myTextBox.Text, "#0123456789ABCDEF")
                delta = delta - myTextBox.Text.Length
                myTextBox.SelectionStart = caretpos - delta
            End If
            textBoxEvent = True
        End If
    End Sub

    Private Function clearInvalidChars(str As String, acceptChars As String) As String
        Dim count As Integer = 0
        For i = 0 To str.Length - 1
            If Not acceptChars.Contains(str(i - count)) Then
                str = str.Remove(i - count, 1)
                count += 1
            End If
        Next
        Return str
    End Function

    Private Sub TextBoxKeyDown(sender As Object, e As KeyEventArgs) Handles myTextBox.KeyDown, myTextBox.KeyUp
        If Not (e.Modifiers = Keys.Control Or e.Modifiers = Keys.Shift) Then
            If myTextBox.Text.Length > 0 AndAlso myTextBox.Text.First = "#" AndAlso myTextBox.SelectionStart = 0 Then
                myTextBox.SelectionStart = 1
            End If
        End If
    End Sub
    Private Sub TextBoxSelectionChanged() Handles myTextBox.Click, myTextBox.GotFocus
        If myTextBox.Text.First = "#" AndAlso myTextBox.SelectionStart = 0 Then
            myTextBox.SelectionStart = 1
        End If
    End Sub

    Private Sub UpdateUI(sender As Object)
        Dim hue As UInteger = myHueSlider.Value
        If hue = 359 Then
            hue = 0
        End If

        'Hue
        If Not sender.Equals(myHueSlider) Then
            myHueSlider.CustomColors = applyValue(applySaturation(myColorCollection, 1 - mySaturationSlider.Value / 100), 1 - myValueSlider.Value / 100)
        Else
            myHueSlider.NubColor = myColorCollection(hue)
        End If
        'Saturation
        If Not sender.Equals(mySaturationSlider) Then
            mySaturationSlider.Color1 = applyValue(myColorCollection(hue), 1 - myValueSlider.Value / 100)
            mySaturationSlider.Color2 = applyValue(Color.White, 1 - myValueSlider.Value / 100)
        End If
        'Value
        If Not sender.Equals(myValueSlider) Then
            myValueSlider.Color1 = applySaturation(myColorCollection(hue), 1 - mySaturationSlider.Value / 100)
        End If
        'Hex
        If Not sender.Equals(myTextBox) Then
            myTextBox.Text = RGBToHEX(applyValue(applySaturation(myColorCollection(hue), 1 - mySaturationSlider.Value / 100), 1 - myValueSlider.Value / 100))
        End If
        'ColorIndicator
        myColorIndicator.BackColor = applyValue(applySaturation(myColorCollection(hue), 1 - mySaturationSlider.Value / 100), 1 - myValueSlider.Value / 100)
    End Sub

    Private Function RGBToHEX(inputColor As Color) As String
        Return "#" & Hex(inputColor.R).PadLeft(2, "0") & Hex(inputColor.G).PadLeft(2, "0") & Hex(inputColor.B).PadLeft(2, "0")
    End Function
    Private Function HEXToRGB(str As String) As Color
        str = str.Replace("#", "")
        Dim R = Convert.ToByte(str.Substring(0, 2), 16)
        Dim G = Convert.ToByte(str.Substring(2, 2), 16)
        Dim B = Convert.ToByte(str.Substring(4, 2), 16)
        Return Color.FromArgb(R, G, B)
    End Function

    Private Function applySaturation(inputColor As Color, factor As Single) As Color
        Dim R As Byte = inputColor.R
        Dim G As Byte = inputColor.G
        Dim B As Byte = inputColor.B

        Select Case Math.Floor(inputColor.GetHue / 60)
            Case 0, 6
                G = G + (255 - G) * (1 - factor)
                B = 255 * (1 - factor)
            Case 1
                R = R + (255 - R) * (1 - factor)
                B = 255 * (1 - factor)
            Case 2
                B = B + (255 - B) * (1 - factor)
                R = 255 * (1 - factor)
            Case 3
                G = G + (255 - G) * (1 - factor)
                R = 255 * (1 - factor)
            Case 4
                R = R + (255 - R) * (1 - factor)
                G = 255 * (1 - factor)
            Case 5
                B = B + (255 - B) * (1 - factor)
                G = 255 * (1 - factor)
        End Select
        Return Color.FromArgb(R, G, B)
    End Function
    Private Function applySaturation(inputColors As ColorCollection, factor As Single) As ColorCollection
        Dim colors As New ColorCollection
        colors.AddRange(inputColors)
        For i = 0 To colors.Count - 1
            colors(i) = applySaturation(colors(i), factor)
        Next
        Return colors
    End Function

    Private Function applyValue(inputColor As Color, factor As Single) As Color
        Return Color.FromArgb(inputColor.R * factor, inputColor.G * factor, inputColor.B * factor)
    End Function
    Private Function applyValue(inputColors As ColorCollection, factor As Single) As ColorCollection
        Dim colors As New ColorCollection
        colors.AddRange(inputColors)
        For i = 0 To colors.Count - 1
            colors(i) = applyValue(colors(i), factor)
        Next
        Return colors
    End Function

End Class
