Option Explicit On
Option Strict On
Option Compare Text

Module ConsoleExamples

    Sub Main()
        Dim userInput As String
        Dim validInput As Boolean = False
        Dim message As String

        Do
            'Console.Clear()
            Console.WriteLine("Please Select an Option:")
            Console.WriteLine("1. Option One" & vbNewLine &
                          "2. Option Two" & vbNewLine &
                          "3. Option Three" & vbNewLine)

            userInput = Console.ReadLine()

            Select Case userInput
                Case "1"
                    message = "you have chosen... poorly..."
                    validInput = True
                Case "2"
                    message = "you win!!!"
                    validInput = True
                Case "3"
                    message = "you lose!!!"
                    validInput = True
                Case "Q"
                    message = "you chose to quit"
                    validInput = True
                Case Else
                    message = "Try Again"
            End Select

            Console.Clear()
            Console.WriteLine($"You selected {userInput}!")
            Console.WriteLine(message)
            Console.WriteLine()

            'If userInput = "1" Then
            '    Console.WriteLine("you have chosen... poorly....")
            '    validInput = True
            'ElseIf userInput = "2" Then
            '    Console.WriteLine("you win!!!")
            '    validInput = True
            'ElseIf userInput = "3" Then
            '    Console.WriteLine("you lose!!!!!!!!!!!!!")
            '    validInput = True
            'ElseIf userInput = "q" Then
            '    validInput = True
            'Else
            '    Console.WriteLine("please read the options again...")
            'End If

        Loop Until validInput

        Console.WriteLine("Have a nice day!!")

        Console.ReadLine()
    End Sub

End Module
