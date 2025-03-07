﻿Option Strict On
Option Explicit On

Module DataTypeConversionExamples

    Sub Main()
        Dim userInput As String = ""
        Dim firstNumber As Integer = 0
        Dim secondNumber As Integer = 0

        'firstNumber = "f"  'Not possible, crashes program

        Console.WriteLine("enter a whole number")
        userInput = Console.ReadLine()

        Try
            firstNumber = CInt(userInput)

        Catch ex As Exception
            Console.WriteLine($"you entered {userInput}")
            Console.WriteLine($"{userInput} is not a whole number")
        End Try

        Console.WriteLine("enter a whole number")
        userInput = Console.ReadLine()

        Try
            secondNumber = CInt(userInput)

        Catch ex As Exception
            Console.WriteLine($"you entered {userInput}")
            Console.WriteLine($"{userInput} is not a whole number")
        End Try

        Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}")

        Console.ReadLine()


    End Sub

End Module
