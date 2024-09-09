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
        Dim continueLoop As Boolean
        Dim userInput As String

        Console.Write("Please enter your name: ")
        userInput = Console.ReadLine()

        Select Case userInput
            Case "Emily"
                Console.WriteLine("Welcome, Emily!")
            Case "Joe"
                Console.WriteLine("Welome, Joe!")
            Case "Andrew"
                Console.WriteLine("Haven't you done enough here Andrew?")
            Case Else
                Console.WriteLine("Your name is not in the system. Go touch grass.")
        End Select
        'Do

        'Loop Until continueLoop

        Console.ReadLine()
    End Sub

End Module
