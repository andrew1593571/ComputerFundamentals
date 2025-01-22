Option Explicit On
Option Strict On
Option Compare Text 'makes string comparison not case sensitive

Module MethodCallExamples

    Sub Main()
        Dim firstNumber As Integer = 7 'Only accessible in the Main Subroutine
        Dim secondNumber As Integer = 5
        Console.WriteLine("Start of Main")

        'For i = 0 To 5
        '    ExampleSub()
        'Next

        'Console.WriteLine(firstNumber)
        'DoMath(3)
        'DoMath(firstNumber)
        'Console.WriteLine(firstNumber)

        'For i = 0 To 10
        '    Console.WriteLine(GetRandomNumber())
        'Next

        'Console.WriteLine(SumOf(3, 5))

        'Console.WriteLine(firstNumber)
        'Console.WriteLine(secondNumber)

        'PlayWithScope(firstNumber, secondNumber)

        'Console.WriteLine(firstNumber)
        'Console.WriteLine(secondNumber)

        'For i = 1 To 10
        '    RunningTotal(5)
        'Next

        ''get total no clear
        'Console.WriteLine(RunningTotal())

        ''clear
        'RunningTotal(, True)

        'For i = 1 To 10
        '    Console.WriteLine(RunningTotal(5))
        'Next

        ExponentSeries(5)

        ExponentSeries(8, 2)

        Console.WriteLine("End of Main")
        Console.ReadLine()
    End Sub



    ''' <summary>
    ''' Example of a simple Sub Routine
    ''' </summary>
    Sub ExampleSub()
        Console.WriteLine("Hello from the Sub")
    End Sub

    ''' <summary>
    ''' takes a value then adds 5 and prints the equation
    ''' </summary>
    ''' <param name="secondNumber"></param>
    Sub DoMath(secondNumber As Integer)
        Dim firstNumber As Integer = 5
        Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}")
    End Sub

    Function GetRandomNumber() As Integer
        Dim value As Integer = CInt(Int((6 * Rnd()) + 1))
        Return value
    End Function

    ''' <summary>
    ''' Calculates the sum of two whole numbers
    ''' </summary>
    ''' <param name="firstNumber"></param>
    ''' <param name="secondNumber"></param>
    ''' <returns>Integer</returns>
    Function SumOf(firstNumber As Integer, secondNumber As Integer) As Integer
        Dim result As Integer
        result = firstNumber + secondNumber
        Return result
    End Function

    Sub PlayWithScope(ByVal firstNumber As Integer, ByRef secondNumber As Integer) 'ByVal is the default
        Console.WriteLine("Start PlayWithScope Sub")
        firstNumber = 25
        secondNumber = 42
        Console.WriteLine("Start PlayWithScope Sub")
    End Sub

    ''' <summary>
    ''' If clear is true, returns 0. If clear is false, adds current number to total and returns total.
    ''' </summary>
    ''' <param name="currentNumber"></param>
    ''' <param name="clear"></param>
    ''' <returns></returns>
    Function RunningTotal(Optional currentNumber As Integer = 0, Optional clear As Boolean = False) As Integer
        Static total As Integer 'static keeps it from being disposed at end of function
        If clear Then
            total = 0
        Else
            total += currentNumber
        End If

        Return total
    End Function

    Sub ExponentSeries(iterations As Integer, Optional base As Integer = 10)

        For i = 0 To iterations
            Console.WriteLine(base ^ i)
        Next


    End Sub

End Module
