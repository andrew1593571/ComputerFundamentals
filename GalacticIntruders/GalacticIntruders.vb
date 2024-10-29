Option Strict On
Option Explicit On
Imports System.Threading.Thread

'TODO
'[ ] frame/play area setup - Build animation frame array, populate with graphic characters
'[ ] basic animation
' - [ ] enemy movement
' - [ ] player movement
' - [ ] projectile
'[ ] collision detection
'[ ] score keeping
'[ ] lives tracking
'[ ] start screen
'[ ] end screen

Module GalacticIntruders

    Sub Main()
        'Do
        '    Console.WriteLine(Console.WindowHeight)
        '    Console.WriteLine(Console.LargestWindowHeight)
        '    Console.ReadLine()
        'Loop

        Console.SetCursorPosition(15, 15)
        Console.WriteLine(Enemy(0))
        Console.SetCursorPosition(15, 16)
        Console.WriteLine(Enemy(1))

        'Console.MoveBufferArea(0, 0, 5, 2, 15, 15)

        Console.Read()

    End Sub

    ''' <summary>
    ''' Stores the current frame as a Function
    ''' </summary>
    ''' <param name="newFrame"></param>
    ''' <returns></returns>
    Function Frame(Optional newFrame(,) As String = Nothing) As String(,)
        Static _Frame(120, 30) As String

        If newFrame IsNot Nothing Then
            _Frame = newFrame
        End If

        Return _Frame
    End Function

    Function Enemy() As String()
        Dim _enemy(1) As String

        'basic pose 1
        _enemy(0) = "-/8\-"
        _enemy(1) = " o o "
        'basic pose 2
        _enemy(2) = "-\8/-"
        _enemy(1) = "  ˅  "

        Return _enemy
    End Function

End Module
