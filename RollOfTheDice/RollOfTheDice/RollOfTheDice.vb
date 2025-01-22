Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'https://github.com/andrew1593571/RollOfTheDice.git

Module RollOfTheDice

    Sub Main()
        Dim columnWidth As Integer = 6
        Dim diceRolls(10) As Integer 'stores the number of rolls for each number 2 through 12
        Dim column As String
        Dim row As String
        Dim title As String = "Roll of the Dice"

        'finds the pad width to fit center the title over the table
        Dim titlePad As Integer = (((columnWidth * 11) - title.Length) \ 2) + title.Length

        'roll the dice i times, increment the rolled value by 1
        For i = 0 To 1000
            diceRolls(GetRandomNumberInRange(10)) += 1
        Next

        'Add in the title row
        Console.WriteLine(title.PadLeft(titlePad))

        'Add in the column header row
        DrawLine(columnWidth * 11)
        row = ""
        For i = 0 To 10
            column = $"|  {CStr(i + 2)}".PadRight(columnWidth)
            row &= column
        Next
        Console.WriteLine(row & "|")

        'Add in the Add in the dice roll results
        DrawLine(columnWidth * 11)
        row = ""
        For i = 0 To 10
            column = $"| {CStr(diceRolls(i))}".PadRight(columnWidth)
            row &= column
        Next
        Console.WriteLine(row & "|")

        'Add in bottom line of table
        DrawLine(columnWidth * 11)


        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Draws a line of dashes
    ''' </summary>
    ''' <param name="width"></param>
    Sub DrawLine(width As Integer)
        Console.WriteLine(StrDup(width, "-"))
    End Sub

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

End Module
