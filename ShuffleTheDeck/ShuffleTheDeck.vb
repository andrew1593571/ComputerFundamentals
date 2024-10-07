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

        DisplayCard(0, 0)

    End Sub


    Sub DisplayCard(suit As Integer, number As Integer)
        Dim suitString() As String = {"Spades", "Clubs", "Hearts", "Diamonds"}

        Console.ReadLine()
    End Sub
End Module
