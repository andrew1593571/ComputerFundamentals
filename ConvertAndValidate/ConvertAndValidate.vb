Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'ConvertAndValidate
'https://github.com/andrew1593571/ConvertAndValidate.git

Module ConvertAndValidate

    Sub Main()
        'for testing the function add this to your Sub Main()

        Dim aValidNumber As Integer
        Dim usernResponse As String

        Do

            Console.WriteLine($"Enter a number:")

            usernResponse = Console.ReadLine()

            If ConversionValid(usernResponse, aValidNumber) = True Then

                Console.WriteLine($"{usernResponse} converted successfully to {aValidNumber}!")

            Else

                Console.WriteLine($"Oops, {usernResponse} does not seem to be a number")

            End If

        Loop
    End Sub

    Function ConversionValid(ByVal convertThisString As String, ByRef toThisInteger As Integer) As Boolean
        Dim status As Boolean

        Try
            toThisInteger = CInt(convertThisString)
            status = True
        Catch ex As Exception
            status = False
        End Try

        Return status

    End Function

End Module
