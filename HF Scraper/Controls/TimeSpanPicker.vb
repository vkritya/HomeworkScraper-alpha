﻿Imports System.Text.RegularExpressions
Public Class TimeSpanPicker

    Event FetchButtonClicked(fromDate As Date, toDate As Date) 'enabledServiceIDs As List(Of ULong)

    Dim myFromDate As Date = Nothing
    Dim myToDate As Date = Nothing

    Private Sub DateTextBoxTextChanged(sender As Object, e As EventArgs) Handles FromDateTextBox.TextChanged, ToDateTextBox.TextChanged
        Dim mySender As TextBox = sender
        Dim targetLabel As Label

        'Set up targets
        If mySender.Name = FromDateTextBox.Name Then
            myFromDate = Nothing
            targetLabel = FromDateLabel
        Else
            myToDate = Nothing
            targetLabel = ToDateLabel
        End If

        'Check for empty
        If mySender.Text = "" Then
            targetLabel.Text = ""
            Exit Sub
        End If

        'Match yyyy.MM.dd.   year e[2000;2999], month e[1;12], day e[1;31]
        Dim myMatch = Regex.Match(mySender.Text, GlobalConstants.REGEX_YMD_MATCHER)
        If Not myMatch.Success Then
            'Match mm.dd.   month e[1;12], day e[1;31]
            myMatch = Regex.Match(mySender.Text, GlobalConstants.REGEX_MD_MATCHER)
        End If

        If myMatch.Success Then
            'Set text to Dates
            If myMatch.Groups.Count = 4 Then
                targetLabel.Text = $"{myMatch.Groups(1)}/{myMatch.Groups(2)}/{myMatch.Groups(3)}"
            Else
                targetLabel.Text = $"{DateTime.Now.Year}/{myMatch.Groups(1)}/{myMatch.Groups(2)}"
            End If

            'Check if date is possible
            If IsDate(targetLabel.Text) Then
                Dim tempSplit = targetLabel.Text.Split("/")
                If mySender.Name = FromDateTextBox.Name Then
                    myFromDate = New Date(CInt(tempSplit(0)), CInt(tempSplit(1)), CInt(tempSplit(2)), 0, 0, 0, DateTimeKind.Local)
                Else
                    myToDate = New Date(CInt(tempSplit(0)), CInt(tempSplit(1)), CInt(tempSplit(2)), 0, 0, 0, DateTimeKind.Local)
                End If
            Else
                targetLabel.Text = "Hibás dátum"
            End If
        Else
            targetLabel.Text = "Hibás formátum"
        End If
    End Sub

    Private Sub DateTextBoxFocusGained(sender As Object, e As MouseEventArgs) Handles FromDateTextBox.Click, ToDateTextBox.Click
        Dim mySender As TextBox = sender
        mySender.SelectAll()
    End Sub

    Private Sub FetchButtonClick() Handles FetchButton.Click
        If myFromDate <> Nothing And myToDate <> Nothing Then
            RaiseEvent FetchButtonClicked(myFromDate, myToDate)
        ElseIf MessageBox.Show("Nem adtál meg egy dátumot (vagy hibásak), frissítse a program a jelenlegi hetet?", "Hibás vagy hiányzó dátumok", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            myFromDate = DateTime.Now.AddDays(-DateTime.Now.DayOfWeek + 1)
            FromDateTextBox.Text = $"{myFromDate.Year}/{myFromDate.Month}/{myFromDate.Day}"
            ToDateTextBox.Text = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}"
            RaiseEvent FetchButtonClicked(myFromDate, DateTime.Now)
        End If
    End Sub

    Private Sub ThisWeekButtonClick() Handles ThisWeekButton.Click
        myFromDate = DateTime.Now.AddDays(-DateTime.Now.DayOfWeek + 1)
        FromDateTextBox.Text = $"{myFromDate.Year}/{myFromDate.Month}/{myFromDate.Day}"
        ToDateTextBox.Text = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}"
    End Sub

    Private Sub TimeSpanPickerLoad() Handles MyBase.Load
        ToDateTextBox.Text = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}"
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        Dim myWidth = Math.Floor(Me.Size.Width / 2 - 8)
        Dim myPos = Me.Size.Width - myWidth - 7

        FromDateTextBox.Size = New Size(myWidth, FromDateTextBox.Size.Height)
        FromDateLabel.Size = New Size(myWidth, FromDateLabel.Size.Height)
        ThisWeekButton.Size = New Size(myWidth, ThisWeekButton.Size.Height)

        ToDateTextBox.Size = New Size(myWidth, ToDateTextBox.Size.Height)
        ToDateTextBox.Location = New Point(myPos, ToDateTextBox.Location.Y)
        ToDateLabel.Size = New Size(myWidth, ToDateLabel.Size.Height)
        ToDateLabel.Location = New Point(myPos, ToDateLabel.Location.Y)
        FetchButton.Size = New Size(myWidth, FetchButton.Size.Height)
        FetchButton.Location = New Point(myPos, FetchButton.Location.Y)
    End Sub

End Class
