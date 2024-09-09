'Andrew Keller
'RCET2265
'Fall 2024
'Say My Name Again
'https://github.com/andrew1593571/SayMyNameAgain.git

Option Explicit On
Option Compare Text
Option Strict On

Module SayMyNameAgain

    Sub Main()
        Dim continueLoop As Boolean = False
        Dim userInput As String

        Do
            Console.WriteLine("Please enter your name. Enter Q to quit.")
            userInput = Console.ReadLine()

            Select Case userInput
                Case "Emily"
                    Console.WriteLine("Welcome, Emily!")
                Case "Joe"
                    Console.WriteLine("Welome, Joe!")
                Case "Andrew"
                    Console.WriteLine("Haven't you done enough here Andrew?")
                Case "Q"
                    Console.WriteLine("Have a nice day!")
                    continueLoop = True
                Case Else
                    Console.WriteLine("Your name is not in the system. Go touch grass.")
            End Select
        Loop Until continueLoop

        Console.ReadLine()
    End Sub

End Module
