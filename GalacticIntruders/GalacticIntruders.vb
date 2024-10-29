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
        StoreHeight(Console.BufferHeight)
        StoreWidth(Console.BufferWidth)

        Dim frame(StoreWidth, StoreHeight) As String

        frame(10, 10) = "|"

        StoreFrame(frame)
        WriteFrame()

        Console.Read()
    End Sub

    Function StoreWidth(Optional newWidth As Integer = 0) As Integer
        Static _width As Integer

        If newWidth <> 0 Then
            _width = newWidth - 1 'offset width to start at 0
        End If

        Return _width
    End Function

    Function StoreHeight(Optional newHeight As Integer = 0) As Integer
        Static _Height As Integer

        If newHeight <> 0 Then
            _Height = newHeight - 1 'offset height to start at 0
        End If

        Return _Height
    End Function

    ''' <summary>
    ''' Stores the current frame as a Function
    ''' </summary>
    ''' <param name="newFrame"></param>
    ''' <returns></returns>
    Function StoreFrame(Optional newFrame(,) As String = Nothing) As String(,)
        Static _Frame(StoreWidth(), StoreHeight()) As String

        If newFrame IsNot Nothing Then
            _Frame = newFrame
        End If

        Return _Frame
    End Function

    ''' <summary>
    ''' Writes the stored frame to the console
    ''' </summary>
    Sub WriteFrame()
        Dim _text As String = ""
        For i = 0 To StoreHeight()
            For j = 0 To StoreWidth()
                If StoreFrame()(j, i) = "" Then
                    _text = _text & " "
                Else
                    _text = _text & StoreFrame()(j, i)
                End If
            Next
            If i < StoreHeight() Then
                _text = _text & vbNewLine
            End If
        Next

        Console.Clear()
        Console.Write(_text)
    End Sub

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
