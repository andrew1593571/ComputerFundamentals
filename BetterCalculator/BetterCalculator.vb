'Andrew Keller
'RCET2265
'Fall 2024
'Better Calculator
'https://github.com/andrew1593571/BetterCalculator.git

Option Explicit On
Option Strict On

Module BetterCalculator

    Sub Main()
        Dim userInput As String = ""
        Dim firstNumber As Integer
        Dim secondNumber As Integer

        firstNumber = GetUserNumber()
        secondNumber = GetUserNumber()


        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Function to ask the user for a number and returns. Loops until valid entry is received.
    ''' </summary>
    ''' <returns></returns>
    Function GetUserNumber() As Integer
        Dim userInput As String
        Dim number As Integer
        Dim exitLoop As Boolean

        Do
            Console.WriteLine("Choose a Number:")
            userInput = Console.ReadLine()
            Try
                number = CInt(userInput)
                exitLoop = True
            Catch ex As Exception
                Console.WriteLine($"You entered ""{userInput}"", please enter a whole number.")
            End Try
        Loop Until exitLoop

        Return number

    End Function

End Module

