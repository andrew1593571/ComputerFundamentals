Option Strict On
Option Explicit On
Option Compare Text
'Andrew Keller
'RCET2265
'Fall 2024
'Multiplication Table
'https://github.com/andrew1593571/MultiplicationTable.git

Module MultiplicationTable

    Sub Main()


        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Requests a number from the user. Returns an Integer
    ''' </summary>
    ''' <returns></returns>
    Function GetUserNumber() As Integer
        Dim userInput As String
        Dim number As Integer
        Dim exitLoop As Boolean

        Do
            Console.WriteLine("Please enter a number:")
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
