Option Strict On
Option Compare Text
Option Explicit On

'Andrew Keller
'RCET2265
'Fall 2024
'Shuffle the Deck
'https://github.com/andrew1593571/ShuffleTheDeck.git

Module ShuffleTheDeck

    Sub Main()
        Dim dealtCards(3, 12) As Boolean 'array to keep track of dealt cards
        'Spades = 0, Clubs = 1, Hearts = 2, Diamonds = 3
        '0 = Ace, 1 = Jack, 2-10 = 2-10, 11 = Queen, 12 = King

        Dim userInput As String
        Dim quit As Boolean = False
        Dim count As Integer = 0
        Dim message As String = ""

        Do
            Console.Clear()
            Console.Write(message)

            DisplayResults(DealCard(dealtCards, count))
            Console.WriteLine($"There are {CStr(52 - count)} cards remaining in the deck.")
            Console.WriteLine("Enter Q to Quit. Enter S to Shuffle. Press Enter to Draw another Card.")

            userInput = Console.ReadLine()
            Select Case userInput
                Case "Q"
                    Console.WriteLine("Have a nice day. Press Enter to quit.")
                    quit = True
                Case "S"
                    message = $"Deck has been Shuffled!{vbNewLine}"
                    ShuffleDeck(dealtCards)
                    count = 0
                Case Else
                    quit = False
                    message = ""
            End Select

        Loop Until quit



        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' puts all cards back in the deck. Sets all values in array to false.
    ''' </summary>
    ''' <param name="_dealt"></param>
    Sub ShuffleDeck(ByRef _dealt(,) As Boolean)
        For i = 0 To 3
            For j = 0 To 12
                _dealt(i, j) = False
            Next
        Next
    End Sub

    ''' <summary>
    ''' Draws a card from the deck and returns a string of what it is
    ''' </summary>
    ''' <param name="dealt"></param>
    ''' <returns></returns>
    Function DealCard(ByRef dealt(,) As Boolean, ByRef _count As Integer) As String
        'set up arrays of proper names for cards
        Dim suitString() As String = {"Spades", "Clubs", "Hearts", "Diamonds"}
        Dim cardString() As String
        cardString = {"Ace", "Jack", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Queen", "King"}

        Dim drawnCard As String = ""
        Dim suit As Integer
        Dim card As Integer

        If _count >= 52 Then 'if the whole deck has been drawn, do not deal a card
            drawnCard = ""
        Else
            Do 'keep getting a random number until the card has not been drawn previously
                suit = GetRandomNumberInRange(3, 0)
                card = GetRandomNumberInRange(12, 0)
            Loop While dealt(suit, card)

            dealt(suit, card) = True
            drawnCard = $"{cardString(card)} of {suitString(suit)}"
            _count += 1
        End If


        Return drawnCard
    End Function

    ''' <summary>
    ''' Displays the card results
    ''' </summary>
    ''' <param name="drawnCard"></param>
    Sub DisplayResults(drawnCard As String)
        If drawnCard = "" Then
            Console.WriteLine("No cards remaining in the deck. Please Shuffle the Deck.")
        Else
            Console.WriteLine($"You have been dealt the {drawnCard}")
        End If
    End Sub

    ''' <summary>
    ''' Returns a random number between max and min
    ''' </summary>
    ''' <param name="Max"></param>
    ''' <param name="Min"></param>
    ''' <returns></returns>
    Function GetRandomNumberInRange(Max As Integer, Min As Integer) As Integer
        Dim randomNumber As Integer

        Randomize(DateTime.Now.Millisecond) 'initializes the random generator
        randomNumber = CInt(Math.Floor((Rnd() * ((Max - Min) + 1)))) + Min

        Return randomNumber
    End Function
End Module
