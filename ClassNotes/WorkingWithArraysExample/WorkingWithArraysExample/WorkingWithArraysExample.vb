Option Strict On
Option Explicit On
Option Compare Text

Module WorkingWithArraysExample

    Sub Main()
        Dim randomNumbers(10) As Integer
        Dim formatted As String
        Dim userInput As String


        Console.WriteLine()

        Do
            'TODO test randomness with array
            For i = 0 To 10000
                'Console.WriteLine(GetRandomNumberBetween(0, 10))

                randomNumbers(GetRandomNumberBetween(0, 10)) += 1
            Next

            'Console.Write(GetRandomNumberBetween(10, -10))

            Console.WriteLine(StrDup((11 * 7), "-"))

            For i = LBound(randomNumbers) To UBound(randomNumbers)
                formatted = CStr(randomNumbers(i)) & " |"
                formatted = formatted.PadLeft(7)
                Console.Write(formatted)
            Next

            'move to a new line and draw the bottom of the table
            Console.WriteLine()
            Console.WriteLine(StrDup((11 * 7), "-"))

            userInput = Console.ReadLine()
            Console.Clear()
        Loop Until userInput = "q"

    End Sub

    Sub SimpleArray()
        Dim names(5) As String

        names(0) = "Jimmy"
        names(3) = "Bob"

        'crashes the program
        'Console.WriteLine(names(6))

        For i = 0 To 10
            Console.WriteLine(names(i))
        Next

    End Sub

    Sub LessSimpleArrays()
        Dim names(5, 1) As String
        Dim numbers = New Integer(,) {{1, 2, 3}, {3, 4, 5}, {7, 8, 9}}
        Dim fruits = New String() {"apple", "banana", "grape"}

        names(0, 0) = "Jimmy"
        names(0, 1) = "Buffet"

        names(1, 0) = "Jane"
        names(1, 1) = "Dover"

        'For i = LBound(names) To UBound(names)
        '    Console.WriteLine($"The name is: {names(i, 0)} {names(i, 1)}")
        'Next

        'For Each name In names
        '    Console.WriteLine($"The name is: {name}")

        'Next

        For i = names.GetLowerBound(0) To names.GetUpperBound(0)
            Console.WriteLine($"The element ({i}, 0) has: {names(i, 0)} The element ({i}, 1) has: {names(i, 1)}")
        Next

    End Sub

    Function GetRandomNumberBetween(Optional max As Integer = 10, Optional min As Integer = 0) As Integer
        Dim value As Integer

        Randomize()

        'int returns only the integer portion f the number. throwing away the decimal portion.
        'Cint converts to integer. If we only convert the max and min numbers will only hit haft the frequency of the middle due to rounding
        'value = CInt(Int(Rnd() * (max + 1))) 'always starts at 0

        value = CInt(Int(Rnd() * ((max - min) + 1))) + min 'finds the difference between max and min, finds a random number in that range, adds min


        Return value
    End Function
End Module
