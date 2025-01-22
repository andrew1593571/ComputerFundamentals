Option Strict On
Option Explicit On

Module ForLoopExamples

    Sub Main()

        'x = 5

        'for i = 10 to -10 step -1
        '    console.writeline(i)
        'next
        For row = 0 To 9
            For column = 0 To 9
                Console.Write(row & column & " ")
            Next
            Console.WriteLine()
        Next

        Console.ReadLine()
    End Sub

End Module
