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

        DisplayCard(2, 5)

    End Sub

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
End Module
