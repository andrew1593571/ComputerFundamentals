Option Strict On
Option Explicit On
Imports System.Net.Mime
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
        'Runs the storeHeight and StoreWidth functions at startup
        StoreHeight(Console.BufferHeight)
        StoreWidth(Console.BufferWidth)

        Dim frame(StoreWidth, StoreHeight) As String

        frame(10, 10) = "|"

        StoreFrame(frame)

        For i = 0 To 15
            Do 'loop until enemy added successfully
            Loop While AddEnemy()
        Next

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

    ''' <summary>
    ''' returns a true if overlap was detected and placement has failed
    ''' </summary>
    ''' <returns></returns>
    Function AddEnemy() As Boolean
        Dim _overlap As Boolean = False

        Dim _position As Integer
        _position = GetRandomNumberInRange(StoreWidth() - 5)

        Dim _frame(,) As String
        _frame = StoreFrame()

        For i = 0 To 1
            For j = 0 To 4
                If _frame(_position + j, i) <> "" Then
                    _overlap = True
                End If
            Next
        Next
        If Not _overlap Then
            For i = 0 To 1
                For j = 0 To 4
                    _frame(_position + j, i) = Enemy()(j, i)
                Next
            Next
            StoreFrame(_frame)
        End If

        Return _overlap
    End Function



    ''' <summary>
    ''' Returns a 2D array containing the characters for the enemy firing
    ''' </summary>
    ''' <returns></returns>
    Function EnemyFiring() As String(,)
        Dim _enemyFiring(4, 1) As String

        _enemyFiring(0, 0) = "-"
        _enemyFiring(1, 0) = "\"
        _enemyFiring(2, 0) = "8"
        _enemyFiring(3, 0) = "/"
        _enemyFiring(4, 0) = "-"
        _enemyFiring(0, 1) = " "
        _enemyFiring(1, 1) = " "
        _enemyFiring(2, 1) = "˅"
        _enemyFiring(3, 1) = " "
        _enemyFiring(4, 1) = " "

        Return _enemyFiring
    End Function

    ''' <summary>
    ''' Returns a 2D array contaning the characters for the enemy
    ''' </summary>
    ''' <returns></returns>
    Function Enemy() As String(,)
        Dim _enemy(4, 1) As String

        _enemy(0, 0) = "-"
        _enemy(1, 0) = "/"
        _enemy(2, 0) = "8"
        _enemy(3, 0) = "\"
        _enemy(4, 0) = "-"
        _enemy(0, 1) = " "
        _enemy(1, 1) = "o"
        _enemy(2, 1) = " "
        _enemy(3, 1) = "o"
        _enemy(4, 1) = " "

        Return _enemy
    End Function

    ''' <summary>
    ''' Returns a random number in the specified range
    ''' </summary>
    ''' <param name="Max"></param>
    ''' <param name="Min"></param>
    ''' <returns></returns>
    Function GetRandomNumberInRange(Max As Integer, Optional Min As Integer = 0) As Integer
        Dim randomNumber As Integer

        Randomize(DateTime.Now.Millisecond)
        randomNumber = CInt(Math.Floor((Rnd() * ((Max - Min) + 1)))) + Min

        Return randomNumber
    End Function
End Module
