﻿Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'https://github.com/andrew1593571/RollOfTheDiceListBox.git

Public Class RollOfTheDiceListBoxForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        Dim _columnWidth As Integer = 7
        Dim _diceRolls() As Integer = DiceRolls() 'stores the number of rolls for each number 2 through 12
        Dim _column As String
        Dim _row As String
        Dim _title As String = "Roll of the Dice"
        Dim _message As String = ""

        'finds the pad width to fit center the title over the table
        Dim titlePad As Integer = (((_columnWidth * 11) - _title.Length) \ 2) + _title.Length

        'roll the dice i times, increment the rolled value by 1
        For i = 0 To 1000
            _diceRolls(GetRandomNumberInRange(10)) += 1
        Next

        'Clear the ListBox
        ResultsListBox.Items.Clear()

        'Add in the title row
        ResultsListBox.Items.Add(_title.PadLeft(titlePad))

        'Add in the column header row
        ResultsListBox.Items.Add(DrawLine(_columnWidth * 11))
        _row = ""
        For i = 0 To 10
            _column = $"|  {CStr(i + 2)}".PadRight(_columnWidth)
            _row &= _column
        Next
        ResultsListBox.Items.Add(_row & "|")

        'Add in the Add in the dice roll results
        ResultsListBox.Items.Add(DrawLine(_columnWidth * 11))
        _row = ""
        For i = 0 To 10
            _column = $"| {CStr(_diceRolls(i))}".PadRight(_columnWidth)
            _row &= _column
        Next
        ResultsListBox.Items.Add(_row & "|")

        'Add in bottom line of table
        ResultsListBox.Items.Add(DrawLine(_columnWidth * 11))

        'Save the _diceRolls back to DiceRolls function
        DiceRolls(_diceRolls)
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'clears the listbox and reset dice roll to 0
        ResultsListBox.Items.Clear()
        DiceRolls(Nothing, True)
    End Sub


    '---Functions and Subs---

    ''' <summary>
    ''' Stores the current dice rolls and returns them
    ''' </summary>
    ''' <param name="newRolls"></param>
    ''' <param name="Clear"></param>
    ''' <returns></returns>
    Function DiceRolls(Optional newRolls As Integer() = Nothing, Optional Clear As Boolean = False) As Integer()
        Static _diceRolls(10) As Integer

        If newRolls IsNot Nothing Then
            _diceRolls = newRolls
        End If

        If Clear Then
            For i = 0 To 10
                _diceRolls(i) = 0
            Next
            ResultsListBox.Items.Clear()
        End If

        Return _diceRolls
    End Function

    ''' <summary>
    ''' Draws a line of dashes
    ''' </summary>
    ''' <param name="width"></param>
    Function DrawLine(width As Integer) As String
        Dim _line As String
        _line = StrDup(width, "-")
        Return _line
    End Function

    ''' <summary>
    ''' Returns a random number in the specified range
    ''' </summary>
    ''' <param name="Max"></param>
    ''' <param name="Min"></param>
    ''' <returns></returns>
    Function GetRandomNumberInRange(Max As Integer, Optional Min As Integer = 0) As Integer
        Dim randomNumber As Integer

        'Initialize randomize with the current time in milliseconds
        Randomize(DateTime.Now.Millisecond)

        randomNumber = CInt(Math.Floor((Rnd() * ((Max - Min) + 1)))) + Min

        Return randomNumber
    End Function


End Class
