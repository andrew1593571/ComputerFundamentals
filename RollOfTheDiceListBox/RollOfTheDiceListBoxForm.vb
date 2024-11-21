Option Explicit On
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

    End Sub

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
