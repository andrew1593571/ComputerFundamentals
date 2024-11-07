Option Strict On
Option Explicit On
Imports System.Threading.Thread

'TODO
'[X] frame/play area setup - Build animation frame array, populate with graphic characters
'[X] basic animation
' - [X] enemy movement
' - [X] player movement
' - [X] enemy projectile
' - [X] player projectile
'[X] player controls
'[ ] collision detection
' - [ ] Player Collision
' - [X] Enemy Collision
'[X] score keeping
'[ ] lives tracking
'[ ] start screen
'[ ] end screen

Module GalacticIntruders

    Sub Main()
        Dim moveAliens As New System.Threading.Thread(AddressOf MoveEnemy)
        Dim moveBullets As New System.Threading.Thread(AddressOf MoveProjectiles)
        Dim refreshScreen As New System.Threading.Thread(AddressOf refreshDisplay)
        Dim player As New System.Threading.Thread(AddressOf PlayerControls)

        'Runs the storeHeight and StoreWidth functions at startup
        StoreHeight(Console.BufferHeight)
        StoreWidth(Console.BufferWidth)

        StoreFrame(CreateFrame())

        For i = 0 To 8
            Do 'loop until enemy added successfully
            Loop While AddEnemy()
        Next

        PlayerPosition()
        WriteFrame()


        Console.ReadLine()

        'starts the game
        moveAliens.Start()
        moveBullets.Start()
        refreshScreen.Start()
        player.Start()

        Do 'check every 50ms if the game is over yet
            Sleep(50)
        Loop Until gameOver()
        Console.WriteLine("GAME OVER!!!")

        Console.ReadLine()
    End Sub

    Sub PlayerControls()
        Do

            Select Case Console.ReadKey.Key
                Case ConsoleKey.LeftArrow
                    PlayerPosition(-1)
                Case ConsoleKey.RightArrow
                    PlayerPosition(1)
                Case ConsoleKey.Spacebar
                    PlayerFire()
            End Select
        Loop Until gameOver()
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
            _Height = newHeight - 2 'offset height to start at 0 and have space for header
        End If

        Return _Height
    End Function

    ''' <summary>
    ''' Stores the current life count as an integer. removeLife is an integer subracted directly from the current number of lives
    ''' If lives reaches 0, calls the GameOver function with the true flag. Default number of lives is 5
    ''' </summary>
    ''' <param name="removeLife"></param>
    ''' <returns></returns>
    Function Lives(Optional removeLife As Integer = 0) As Integer
        Static _lives As Integer = 5

        _lives -= removeLife
        If _lives = 0 Then
            gameOver(True)
        End If

        Return _lives
    End Function

    ''' <summary>
    ''' Stores the current score as as an integer. addScore is an integer added directly to the current score
    ''' </summary>
    ''' <param name="addScore"></param>
    ''' <returns></returns>
    Function Score(Optional addScore As Integer = 0) As Integer
        Static _score As Integer

        _score += addScore

        Return _score
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
        Dim padSize As Integer
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

        padSize = StoreWidth() - 7 - CStr(Score()).Length - 7 - CStr(Lives()).Length
        Console.Clear()
        Console.WriteLine($"Score: {CStr(Score())}".PadRight(padSize) & $"Lives: {CStr(Lives())}")
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

    Sub PlayerFire()
        Dim _frame(,) As String = StoreFrame()

        _frame(PlayerPosition() + 1, StoreHeight() - 3) = "|"
        StoreFrame(_frame)
    End Sub

    Sub MoveProjectiles()
        Dim _frame(,) As String

        Do
            'Enemy Projectile
            For i = StoreWidth() To 0 Step -1
                For j = StoreHeight() To 0 Step -1
                    _frame = StoreFrame()
                    If _frame(i, j) = "." Then
                        _frame(i, j) = " "
                        If j + 1 < StoreHeight() Then
                            Select Case _frame(i, j + 1)
                                Case "|"
                                    _frame(i, j + 1) = " "
                                Case " "
                                    _frame(i, j + 1) = "."
                            End Select

                        End If
                    End If
                    StoreFrame(_frame)
                Next
            Next

            'Player Projectile
            For i = 0 To StoreWidth()
                For j = 0 To StoreHeight()
                    _frame = StoreFrame()
                    If _frame(i, j) = "|" Then
                        _frame(i, j) = " "
                        If j - 1 > 0 Then
                            Select Case _frame(i, j - 1)
                                Case "."
                                    _frame(i, j - 1) = " "
                                Case " "
                                    _frame(i, j - 1) = "|"
                                Case Else
                                    Score(1)
                                    For k = -4 To 4
                                        For l = 0 To 3
                                            If i + k > 0 And i + k < StoreWidth() And j - l > 0 And j - l < StoreHeight() Then
                                                If _frame(i + k, j - l) <> " " Then
                                                    _frame(i + k, j - l) = " "
                                                End If
                                            End If
                                        Next

                                    Next

                            End Select

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


    Function PlayerPosition(Optional column As Integer = 0) As Integer
        Static _position As Integer = StoreWidth() \ 2
        Dim _frame(,) As String = StoreFrame()

        _frame(_position, StoreHeight() - 2) = " "
        _frame(_position + 1, StoreHeight() - 2) = " "
        _frame(_position + 2, StoreHeight() - 2) = " "
        _frame(_position + 3, StoreHeight() - 2) = " "
        _frame(_position, StoreHeight() - 1) = " "
        _frame(_position + 1, StoreHeight() - 1) = " "
        _frame(_position + 2, StoreHeight() - 1) = " "
        _frame(_position + 3, StoreHeight() - 1) = " "
        StoreFrame(_frame)

        _position = _position + column
        DrawPlayer(_position)

        Return _position
    End Function


    Sub DrawPlayer(position As Integer)
        Dim _frame(,) As String

        _frame = StoreFrame()
        For i = 0 To 1
            For j = 0 To 3
                _frame(position + j, StoreHeight() - 2 + i) = Player()(j, i)
            Next
        Next
        StoreFrame(_frame)
    End Sub

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

    Function Player() As String(,)
        Dim _player(3, 1) As String

        _player(0, 0) = " "
        _player(1, 0) = "/"
        _player(2, 0) = "\"
        _player(3, 0) = " "
        _player(0, 1) = "/"
        _player(1, 1) = "_"
        _player(2, 1) = "_"
        _player(3, 1) = "\"

        Return _player
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
