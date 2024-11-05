﻿Option Strict On
Option Explicit On
Imports System.Net.Mime
Imports System.Security.Cryptography.X509Certificates
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
        Dim moveAliens As New System.Threading.Thread(AddressOf MoveEnemy)
        Dim moveBullets As New System.Threading.Thread(AddressOf MoveProjectiles)
        Dim refreshScreen As New System.Threading.Thread(AddressOf refreshDisplay)

        Dim currentKey As ConsoleKey

        'Runs the storeHeight and StoreWidth functions at startup
        StoreHeight(Console.BufferHeight)
        StoreWidth(Console.BufferWidth)

        StoreFrame(CreateFrame())

        For i = 0 To 8
            Do 'loop until enemy added successfully
            Loop While AddEnemy()
        Next
        WriteFrame()

        Console.ReadLine()

        'starts the game
        moveAliens.Start()
        moveBullets.Start()
        refreshScreen.Start()

        Do 'check every 50ms if the game is over yet
            Sleep(50)
        Loop Until gameOver()
        Console.WriteLine("GAME OVER!!!")

        'If 
        'Console.WriteLine(ConsoleKey.UpArrow)

        'Do
        '    gameOver = MoveEnemy()
        '    WriteFrame()
        '    Sleep(1000)
        'Loop Until gameOver

        Console.ReadLine()
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
    ''' stores whether or not the game is over
    ''' </summary>
    ''' <param name="status"></param>
    ''' <returns></returns>
    Function gameOver(Optional status As Boolean = False) As Boolean
        Static _gameOver As Boolean

        If status Then
            _gameOver = True
        End If
        Return _gameOver
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
    ''' creates an array the size of the screen full of spaces
    ''' </summary>
    ''' <returns></returns>
    Function CreateFrame() As String(,)
        Dim _frame(StoreWidth(), StoreHeight()) As String

        For row = 0 To StoreHeight()
            For column = 0 To StoreWidth()
                _frame(column, row) = " "
            Next
        Next

        Return _frame
    End Function

    ''' <summary>
    ''' Refreshes the display every 1ms
    ''' </summary>
    Sub refreshDisplay()
        Do
            WriteFrame()
            Sleep(1)
        Loop Until gameOver()
    End Sub

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
                If _frame(_position + j, i) <> " " Then
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


    Sub MoveProjectiles()
        Dim _frame(,) As String

        Do
            For i = StoreWidth() To 0 Step -1
                For j = StoreHeight() To 0 Step -1
                    _frame = StoreFrame()
                    If _frame(i, j) = "." Then
                        _frame(i, j) = " "
                        If j + 1 < 30 Then
                            _frame(i, j + 1) = "."
                        End If
                    End If
                    StoreFrame(_frame)
                Next
            Next
            Sleep(300)
        Loop Until gameOver()

    End Sub

    ''' <summary>
    ''' Moves the enemy around on the screen
    ''' </summary>
    ''' <returns></returns>
    Sub MoveEnemy()
        Dim _frame(,) As String
        Dim count As Integer = 0
        Dim newColumn As Integer
        Dim newRow As Integer

        Do
            For i = StoreWidth() To 0 Step -1
                For j = StoreHeight() To 0 Step -1
                    _frame = StoreFrame()
                    If _frame(i, j) = "8" Then
                        count += 1
                        removeEnemy(i, j)
                        If GetRandomNumberInRange(10, 0) < 8 Then
                            Do
                                newColumn = GetRandomNumberInRange(-2, 2) + i
                                newRow = GetRandomNumberInRange(2, 1) + j - 1
                                If newColumn < 2 Then
                                    newColumn = 2
                                ElseIf newColumn > StoreWidth() - 5 Then
                                    newColumn = StoreWidth() - 5
                                End If
                                If newRow > StoreHeight() - 1 Then
                                    newRow = StoreHeight() - 1
                                    gameOver(True)
                                End If
                            Loop While DrawEnemy(False, newColumn, newRow)
                        Else
                            Do
                                newColumn = GetRandomNumberInRange(-2, 2) + i
                                newRow = GetRandomNumberInRange(2, 1) + j - 1
                                If newColumn < 2 Then
                                    newColumn = 2
                                ElseIf newColumn > StoreWidth() - 5 Then
                                    newColumn = StoreWidth() - 5
                                End If
                                If newRow > StoreHeight() - 1 Then
                                    newRow = StoreHeight() - 1
                                    gameOver(True)
                                End If
                            Loop While DrawEnemy(True, newColumn, newRow)
                        End If
                    End If
                    StoreFrame(_frame)
                Next
            Next

            Sleep(1000)
        Loop Until gameOver()

    End Sub

    Function DrawEnemy(firing As Boolean, column As Integer, row As Integer) As Boolean
        Dim _overlap As Boolean = False
        Dim _enemy(,) As String
        Dim _frame(,) As String
        Dim _startColumn As Integer = column - 2
        _frame = StoreFrame()

        If firing Then
            _enemy = EnemyFiring()
        Else
            _enemy = Enemy()
        End If

        For i = 0 To 1
            For j = 0 To 4
                If _frame(_startColumn + j, row + i) <> " " Then
                    _overlap = True
                End If
            Next
        Next
        If Not _overlap Then
            For i = 0 To 1
                For j = 0 To 4
                    _frame(_startColumn + j, row + i) = _enemy(j, i)
                Next
            Next
            If firing And row + 2 < StoreHeight() Then
                _frame(_startColumn + 2, row + 2) = "."
            End If
            StoreFrame(_frame)
        End If

        Return _overlap
    End Function

    ''' <summary>
    ''' Removes the enemy at the given point where the 8 is found
    ''' </summary>
    ''' <param name="column"></param>
    ''' <param name="row"></param>
    Sub removeEnemy(column As Integer, row As Integer)
        Dim _frame(,) As String = StoreFrame()
        _frame(column - 2, row) = " "
        _frame(column - 1, row) = " "
        _frame(column, row) = " "
        _frame(column + 1, row) = " "
        _frame(column + 2, row) = " "
        _frame(column - 1, row + 1) = " "
        _frame(column, row + 1) = " "
        _frame(column + 1, row + 1) = " "
        StoreFrame(_frame)
    End Sub

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
        _enemyFiring(2, 1) = "*"
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
