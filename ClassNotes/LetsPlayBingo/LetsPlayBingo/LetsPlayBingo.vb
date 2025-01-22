Option Strict On
Option Explicit On
Option Compare Text
Imports System.Data.SqlClient

Module LetsPlayBingo

    Sub Main()
        Dim ballCage(14, 4) As Boolean
        Dim done As Boolean
        Dim userInput As String
        Dim mostRecent As String
        Dim ballsDrawn As Integer = 0
        Dim userMessage As String

        Do
            Console.Clear()

            'If ballsDrawn is equal to or greater than 75, ask to start new game.
            'If ballsDrawn is less than 75, draw a ball and provide continue instructions.
            If ballsDrawn >= 75 Then
                userMessage = $"All balls have been drawn. Thanks for Playing Bingo!{vbNewLine}Enter ""N"" to start a new game. Enter ""Q"" to quit."
            Else
                userMessage = "Press enter to Draw a Ball. Enter ""Q"" to quit."
                mostRecent = DrawBall(ballCage)
                ballsDrawn += 1
            End If

            'Display the Drawn Balls
            Display(ballCage)
            Console.WriteLine($"The most recent ball was: {mostRecent}")

            'user prompt
            Console.WriteLine(userMessage)
            userInput = Console.ReadLine()

            Select Case userInput
                Case "Q"
                    done = True
                    Console.WriteLine("Have a nice Day! Press enter to close.")
                Case "N"
                    done = True
                Case Else
                    done = False

            End Select

        Loop Until done

        Console.ReadLine()
    End Sub


    ''' <summary>
    ''' Draws a ball from the cage. Returns the ball it drew
    ''' </summary>
    ''' <param name="ballCage"></param>
    ''' <returns></returns>
    Function DrawBall(ByRef ballCage(,) As Boolean) As String
        Dim _number As Integer
        Dim _letter As Integer

        Do
            _number = GetRandomNumberInRange(14, 0)
            _letter = GetRandomNumberInRange(4, 0)

        Loop While ballCage(_number, _letter)

        ballCage(_number, _letter) = True

        Return FormatBall(_letter, _number)
    End Function

    ''' <summary>
    ''' Displays the formatted game status on the console
    ''' </summary>
    ''' <param name="ballCage"></param>
    Sub Display(ByRef ballCage(,) As Boolean)

        Dim header() As String = {"B", "I", "N", "G", "O"}
        Dim prettyNumber As String = ""
        Dim pad As Integer = 4

        'Prints header to console
        Console.Write("|")
        For i = 0 To 4
            Console.Write(header(i).PadLeft(pad) & " |")
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(((pad + 2) * 5) + 1, "-"))

        'Prints numbers to console if they have been called
        For number = 0 To 14
            Console.Write("|")
            For letter = 0 To 4
                'Console.Write(ballCage(number, letter)) 'TODO write pretty number if drawn
                Select Case ballCage(number, letter)
                    Case True
                        prettyNumber = FormatBall(letter, number)
                    Case False
                        prettyNumber = ""
                End Select
                Console.Write(prettyNumber.PadLeft(pad) & " |")
            Next
            Console.WriteLine()
        Next

    End Sub

    ''' <summary>
    ''' Function to take a letter and number integer and convert to a formal print name.
    ''' </summary>
    ''' <param name="_letter"></param>
    ''' <param name="_number"></param>
    ''' <returns></returns>
    Function FormatBall(_letter As Integer, _number As Integer) As String
        Dim _prettyNumber As String = ""
        Dim _header() As String = {"B", "I", "N", "G", "O"}

        _prettyNumber = _header(_letter) & CStr((15 * _letter) + 1 + _number)

        Return _prettyNumber
    End Function

    Function 

    ''' <summary>
    ''' Get a random integer within the specified range. Inclusive
    ''' </summary>
    ''' <param name="Max"></param>
    ''' <param name="Min"></param>
    ''' <returns></returns>
    Function GetRandomNumberInRange(Max As Integer, Min As Integer) As Integer
        Dim randomNumber As Integer

        Randomize(DateTime.Now.Millisecond)
        randomNumber = CInt(Math.Floor((Rnd() * ((Max - Min) + 1)))) + Min

        Return randomNumber
    End Function

End Module
