Option Strict On
Option Explicit On
Imports System.Net.Http
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Thread

'TODO
'[X] frame/play area setup - Build animation frame array, populate with graphic characters
'[X] basic animation
' - [X] enemy movement
' - [X] player movement
' - [X] enemy projectile
' - [X] player projectile
'[X] player controls
'[X] collision detection
' - [X] Player Collision
' - [X] Enemy Collision
'[X] Enemy Spawning/Difficulty
'[X] score keeping
'[X] lives tracking
'[X] Game Over Reason
'[X] start screen
'[X] end screen
'[ ] High Score
' - [ ] Save high score to file
' - [ ] Retrieve existing high score from file
'[X] Loop Main
'[X] Control Screen
'[ ] resize window or lock to original size

Module GalacticIntruders

    Sub Main()
        Dim startGame As Boolean = False
        Dim _quit As Boolean = False


        Do

            'These are in the loop so that it creates a new thread task for each round. Otherwise the game can only run once.
            Dim moveAliens As New System.Threading.Thread(AddressOf MoveEnemy)
            Dim moveBullets As New System.Threading.Thread(AddressOf MoveProjectiles)
            Dim refreshScreen As New System.Threading.Thread(AddressOf refreshDisplay)
            Dim player As New System.Threading.Thread(AddressOf PlayerControls)
            Dim spawn As New System.Threading.Thread(AddressOf SpawnEnemy)


            Do
                'Runs the storeHeight and StoreWidth functions while in the main menu
                StoreHeight(Console.WindowHeight)
                StoreWidth(Console.WindowWidth)
                StartScreen()

                Select Case Console.ReadKey.Key
                    Case ConsoleKey.Spacebar
                        startGame = True
                    Case ConsoleKey.Q
                        _quit = True
                        Exit Sub
                    Case ConsoleKey.C
                        ControlScreen()
                        StartScreen()
                End Select
            Loop Until startGame
            startGame = False

            StoreFrame(CreateFrame()) 'Stores an empty frame
            PlayerPosition() 'spawns the player in
            Lives(-20) 'sets the life count to 20
            Score(-Score()) 'sets the score back to 0
            GameOver(False, True) 'Sets the game over flag back to false
            WriteFrame()

            'starts the game
            spawn.Start()
            moveAliens.Start()
            moveBullets.Start()
            refreshScreen.Start()
            player.Start()

            Do 'check every 50ms if the game is over yet
                Sleep(50)
            Loop Until GameOver()

            EndScreen()
        Loop Until _quit


    End Sub

    ''' <summary>
    ''' watches for key presses and executes functions based on them
    ''' </summary>
    Sub PlayerControls()
        Dim shield As New System.Threading.Thread(AddressOf SpawnShield)

        Do

            Select Case Console.ReadKey.Key
                Case ConsoleKey.LeftArrow
                    PlayerPosition(-1)
                Case ConsoleKey.RightArrow
                    PlayerPosition(1)
                Case ConsoleKey.Spacebar
                    PlayerFire()
                Case ConsoleKey.S
                    If Not shield.IsAlive Then 'if there is not an existing shield, create one
                        shield = New System.Threading.Thread(AddressOf SpawnShield)
                        shield.Start()
                    End If
            End Select
        Loop Until GameOver()
    End Sub

    Sub GetHighScore()
        'open file and retrieve current high score
    End Sub

    ''' <summary>
    ''' Stores the width of the console window. Can be set using newWidth
    ''' </summary>
    ''' <param name="newWidth"></param>
    ''' <returns></returns>
    Function StoreWidth(Optional newWidth As Integer = 0) As Integer
        Static _width As Integer

        If newWidth <> 0 Then
            _width = newWidth - 1 'offset width to start at 0
        End If

        Return _width
    End Function

    ''' <summary>
    ''' Stores the height of the console window. Can be set using newHeight
    ''' </summary>
    ''' <param name="newHeight"></param>
    ''' <returns></returns>
    Function StoreHeight(Optional newHeight As Integer = 0) As Integer
        Static _Height As Integer

        If newHeight <> 0 Then
            _Height = newHeight - 2 'offset height to start at 0 and have space for header
        End If

        Return _Height
    End Function

    ''' <summary>
    ''' Stores the current life count as an integer. removeLife is an integer subracted directly from the current number of lives
    ''' If lives reaches 0, calls the GameOver function with the true flag. Default number of lives is 20
    ''' </summary>
    ''' <param name="removeLife"></param>
    ''' <returns></returns>
    Function Lives(Optional removeLife As Integer = 0) As Integer
        Static _lives As Integer = 0

        _lives -= removeLife
        If _lives = 0 Then
            GameOver(True, True)
            GameOverReason("Out of Lives!")
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
    ''' Stores a string with the reason for the game ending
    ''' </summary>
    ''' <param name="newReason"></param>
    ''' <returns></returns>
    Function GameOverReason(Optional newReason As String = Nothing) As String
        Static _reason As String = "Unknown Reason"

        If newReason IsNot Nothing Then
            _reason = newReason
        End If

        Return _reason
    End Function

    ''' <summary>
    ''' stores whether or not the game is over
    ''' </summary>
    ''' <param name="status"></param>
    ''' <returns></returns>
    Function GameOver(Optional status As Boolean = False, Optional setStatus As Boolean = False) As Boolean
        Static _gameOver As Boolean

        If setStatus Then
            _gameOver = status
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
            Sleep(2)
        Loop Until GameOver()
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
    ''' Displays a list of controls for the user
    ''' </summary>
    Sub ControlScreen()
        Dim _startLine As Integer = StoreHeight() \ 3
        Dim _message As String = "Controls:"
        Dim _fireInstruction As String = "Spacebar".PadLeft(12) & " - " & "Shoot Projectile".PadRight(18)
        Dim _moveLeft As String = "Left Arrow".PadLeft(12) & " - " & "Move Left".PadRight(18)
        Dim _moveRight As String = "Right Arrow".PadLeft(12) & " - " & "Move Right".PadRight(18)
        Dim _Shield As String = "S".PadLeft(12) & " - " & "Spawn Shield".PadRight(18)
        Dim _continueMessage As String = "Press Enter to Return to the Main Menu"

        Console.Clear()
        Console.SetCursorPosition(0, _startLine)
        Console.WriteLine(_message.PadLeft(((StoreWidth() - _message.Length) \ 2) + _message.Length))
        Console.WriteLine()
        Console.WriteLine(_fireInstruction.PadLeft(((StoreWidth() - _fireInstruction.Length) \ 2) + _fireInstruction.Length))
        Console.WriteLine(_moveLeft.PadLeft(((StoreWidth() - _moveLeft.Length) \ 2) + _moveLeft.Length))
        Console.WriteLine(_moveRight.PadLeft(((StoreWidth() - _moveRight.Length) \ 2) + _moveRight.Length))
        Console.WriteLine(_Shield.PadLeft(((StoreWidth() - _Shield.Length) \ 2) + _Shield.Length))
        Console.WriteLine()
        Console.WriteLine(_continueMessage.PadLeft(((StoreWidth() - _continueMessage.Length) \ 2) + _continueMessage.Length))

        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Displays the start screen for the game
    ''' </summary>
    Sub StartScreen()
        Dim _startLine As Integer = StoreHeight() \ 3
        Dim _message As String = "Galactic Intruders"
        Dim _byLine As String = "By: Andrew Keller"
        Dim _alienLineOne As String = "-/8\-  -/8\-"
        Dim _alienLineTwo As String = " o o    o o "
        Dim _highScoreMessage As String = $"High Score: {CStr(Score())}"
        Dim _startInstruction As String = "Press Space to Start"
        Dim _quitInstruction As String = "Press Q to Quit"
        Dim _controlInstruction As String = "Press C to View Controls"

        Console.Clear()
        Console.SetCursorPosition(0, _startLine)
        Console.WriteLine(_message.PadLeft(((StoreWidth() - _message.Length) \ 2) + _message.Length))
        Console.WriteLine(_byLine.PadLeft(((StoreWidth() - _byLine.Length) \ 2) + _byLine.Length))
        Console.WriteLine()
        Console.WriteLine(_alienLineOne.PadLeft(((StoreWidth() - _alienLineOne.Length) \ 2) + _alienLineOne.Length))
        Console.WriteLine(_alienLineTwo.PadLeft(((StoreWidth() - _alienLineTwo.Length) \ 2) + _alienLineTwo.Length))
        Console.WriteLine()
        Console.WriteLine(_highScoreMessage.PadLeft(((StoreWidth() - _highScoreMessage.Length) \ 2) + _highScoreMessage.Length))
        Console.WriteLine()
        Console.WriteLine(_startInstruction.PadLeft(((StoreWidth() - _startInstruction.Length) \ 2) + _startInstruction.Length))
        Console.WriteLine(_quitInstruction.PadLeft(((StoreWidth() - _quitInstruction.Length) \ 2) + _quitInstruction.Length))
        Console.WriteLine(_controlInstruction.PadLeft(((StoreWidth() - _controlInstruction.Length) \ 2) + _controlInstruction.Length))
    End Sub

    ''' <summary>
    ''' Writes the screen when game finishes
    ''' </summary>
    Sub EndScreen()
        Dim _centerline As Integer = StoreHeight() \ 2
        Dim _message As String = "Game Over!"
        Dim _scoreMessage As String = $"Score: {CStr(Score())}"
        Dim _highScoreMessage As String = $"High Score: {CStr(Score())}"
        Dim _continueMessage As String = "Press Enter to Return to the Main Menu"

        Console.Clear()
        Console.SetCursorPosition(0, _centerline - 1)
        Console.WriteLine(_message.PadLeft(((StoreWidth() - _message.Length) \ 2) + _message.Length))
        Console.WriteLine(GameOverReason().PadLeft(((StoreWidth() - GameOverReason().Length) \ 2) + GameOverReason().Length))
        Console.WriteLine()
        Console.WriteLine(_scoreMessage.PadLeft(((StoreWidth() - _scoreMessage.Length) \ 2) + _scoreMessage.Length))
        Console.WriteLine(_highScoreMessage.PadLeft(((StoreWidth() - _highScoreMessage.Length) \ 2) + _highScoreMessage.Length))
        Console.WriteLine()
        Console.WriteLine(_continueMessage.PadLeft(((StoreWidth() - _continueMessage.Length) \ 2) + _continueMessage.Length))

        Console.ReadLine()
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

    ''' <summary>
    ''' spawns a increasing number of enemies based on the score
    ''' </summary>
    Sub SpawnEnemy()
        Do
            Select Case Score()
                Case 0 To 4 'less than a score of 5, spawn 1
                    Do 'loop until enemy added successfully
                    Loop While AddEnemy()

                Case 5 To 10 'between 5 and 10, spawn 2
                    For i = 0 To 1
                        Do 'loop until enemy added successfully
                        Loop While AddEnemy()
                    Next

                Case 11 To 20 'between 11 and 20 spawn 3
                    For i = 0 To 2
                        Do 'loop until enemy added successfully
                        Loop While AddEnemy()
                    Next

                Case 21 To 30 'between 21 and 30 spawn 5
                    For i = 0 To 4
                        Do 'loop until enemy added successfully
                        Loop While AddEnemy()
                    Next

                Case 31 To 50 'between 31 and 50 spawn 7
                    For i = 0 To 6
                        Do 'loop until enemy added successfully
                        Loop While AddEnemy()
                    Next
                Case > 50 'greater than 50 spawn 9
                    For i = 0 To 8
                        Do 'loop until enemy added successfully
                        Loop While AddEnemy()
                    Next
            End Select

            Sleep(6000)
        Loop Until GameOver()
    End Sub

    ''' <summary>
    ''' spawns a player projectile above the player
    ''' </summary>
    Sub PlayerFire()
        Dim _frame(,) As String = StoreFrame()

        _frame(PlayerPosition() + 1, StoreHeight() - 3) = "|"
        StoreFrame(_frame)
    End Sub

    ''' <summary>
    ''' Moves the projectiles on the screen, detects collisions with enemies or player
    ''' </summary>
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
                                Case "-"
                                    'Do nothing if it is a shield
                                Case Else
                                    If j < StoreHeight() - 2 Then
                                        Lives(1)
                                    End If
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
                                Case "-" 'skip above the sheild
                                    _frame(i, j - 2) = "|"
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
        Loop Until GameOver()

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
                                    GameOver(True, True)
                                    GameOverReason("The Intruders Reached your Base!")
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
                                    GameOver(True, True)
                                    GameOverReason("The Intruders Reached your Base!")
                                End If
                            Loop While DrawEnemy(True, newColumn, newRow)
                        End If
                    End If
                    StoreFrame(_frame)
                Next
            Next

            Sleep(1000)
        Loop Until GameOver()

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
    ''' spawns a shield above the player area for 10 seconds. Cannot be used for another 10 seconds
    ''' </summary>
    Sub SpawnShield()
        Dim _Frame(,) As String = StoreFrame()

        For i = 0 To StoreWidth()
            _Frame(i, StoreHeight() - 4) = "-"
        Next

        Sleep(10000)

        For i = 0 To StoreWidth()
            _Frame(i, StoreHeight() - 4) = " "
        Next

        Sleep(10000)
    End Sub

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

        'keep the player within the drawable area
        If _position + column < 0 Then
            _position = 0
        ElseIf _position + column > StoreWidth() - 3 Then
            _position = StoreWidth() - 3
        Else
            _position = _position + column
        End If
        DrawPlayer(_position)

        Return _position
    End Function

    ''' <summary>
    ''' Draws the player on the screen
    ''' </summary>
    ''' <param name="position"></param>
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

    ''' <summary>
    ''' Returns a 2D array containing the characters for the player
    ''' </summary>
    ''' <returns></returns>
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
