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


        Console.WriteLine(DealCard(dealtCards))

        Console.ReadLine()

    End Sub

    ''' <summary>
    ''' Draws a card from the deck and returns a string of what it is
    ''' </summary>
    ''' <param name="dealt"></param>
    ''' <returns></returns>
    Function DealCard(ByRef dealt(,) As Boolean) As String
        'set up arrays of proper names for cards
        Dim suitString() As String = {"Spades", "Clubs", "Hearts", "Diamonds"}
        Dim cardString() As String
        cardString = {"Ace", "Jack", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Queen", "King"}

        Static Dim count As Integer
        Dim drawnCard As String = ""
        Dim suit As Integer
        Dim card As Integer

        If count >= 52 Then 'if the whole deck has been drawn, do not deal a card
            drawnCard = "All Cards have been Dealt. Shuffle the Deck."
        Else
            Do 'keep getting a random number until the card has not been drawn previously
                suit = GetRandomNumberInRange(3, 0)
                card = GetRandomNumberInRange(12, 0)
            Loop While dealt(suit, card)

            dealt(suit, card) = True
            drawnCard = $"{cardString(card)} of {suitString(suit)}"
        End If


        Return drawnCard
    End Function

    ''' <summary>
    ''' Displays the dealt card to the console in readable format
    ''' </summary>
    ''' <param name="suit"></param>
    ''' <param name="card"></param>
    Sub DisplayCard(suit As Integer, card As Integer)
        'set up arrays of proper names for cards
        Dim suitString() As String = {"Spades", "Clubs", "Hearts", "Diamonds"}
        Dim cardString() As String
        cardString = {"Ace", "Jack", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Queen", "King"}

        Console.WriteLine($"You have been dealt the {cardString(card)} of {suitString(suit)}")

        Console.ReadLine()
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
