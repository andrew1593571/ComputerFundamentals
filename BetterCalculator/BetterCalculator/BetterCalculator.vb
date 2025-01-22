Option Explicit On
Option Strict On
'Andrew Keller
'RCET2265
'Fall 2024
'Better Calculator
'https://github.com/andrew1593571/BetterCalculator.git

Imports System.Linq.Expressions

Module BetterCalculator

    Sub Main()
        Dim userInput As String = ""
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim validOption As Boolean
        Dim quitEntered As Boolean


        Do 'Loop until quit is selected

            firstNumber = GetUserNumber()
            secondNumber = GetUserNumber()

            Do 'Loop until valid option is selected
                Console.WriteLine($"Choose one of the following options:{vbNewLine}1. Add{vbNewLine}2. Subtract{vbNewLine}3. Multiply{vbNewLine}4. Divide{vbNewLine}5. Quit")
                userInput = Console.ReadLine()
                Console.WriteLine($"You entered ""{userInput}""")

                Select Case userInput
                    Case "1"
                        Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}")
                        validOption = True
                    Case "2"
                        Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}")
                        validOption = True
                    Case "3"
                        Console.WriteLine($"{firstNumber} x {secondNumber} = {firstNumber * secondNumber}")
                        validOption = True
                    Case "4"
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}")
                        validOption = True
                    Case "5"
                        Console.WriteLine($"Have a nice day!{vbNewLine}Press enter to close this window")
                        validOption = True
                        quitEntered = True
                    Case Else

                End Select

            Loop Until validOption

        Loop Until quitEntered


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
                Console.WriteLine($"You entered ""{userInput}""")
                exitLoop = True
            Catch ex As Exception
                Console.WriteLine($"You entered ""{userInput}"", please enter a whole number.")
            End Try
        Loop Until exitLoop

        Return number

    End Function

End Module

