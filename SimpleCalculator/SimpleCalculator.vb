'Andrew Keller
'RCET2265
'Fall 2024
'Simple Calculator
'https://github.com/andrew1593571/SimpleCalculator.git

Option Explicit On
Option Strict On

Module SimpleCalculator

    Sub Main()
        Dim userInput As String = ""
        Dim firstNumber As Integer
        Dim secondNumber As Integer

        Console.Write("Choose a Number: ")
        userInput = Console.ReadLine() 'Pulls the entered number from the console.
        firstNumber = CInt(userInput) 'converts to integer and saves

        Console.Write("Choose a Number: ")
        userInput = Console.ReadLine() 'pulls number from console
        secondNumber = CInt(userInput) 'converts to integer and saves

        Console.WriteLine("Select an Option:" & vbNewLine &
                          "1. Sum" & vbNewLine &
                          "2. Product" & vbNewLine &
                          "3. Quit")
        userInput = Console.ReadLine()

        Select Case userInput
            Case "1"
                Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}")
            Case "2"
                Console.WriteLine($"{firstNumber} x {secondNumber} = {firstNumber * secondNumber}")
            Case "3"
                Console.WriteLine("Have a Nice Day! Press enter to exit")
            Case Else
                Console.WriteLine($"You entered {userInput}. {userInput} is not a valid option.")
        End Select


        'Do


        'Loop Until userInput = "3"
        Console.ReadLine()
    End Sub

End Module
