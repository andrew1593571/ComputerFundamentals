Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'https://github.com/andrew1593571/RollOfTheDice.git

Module RollOfTheDice

    Sub Main()

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
