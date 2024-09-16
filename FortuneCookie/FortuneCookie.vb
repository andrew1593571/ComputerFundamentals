Module FortuneCookie

    Sub Main()

        Console.WriteLine("Here is your Fortune:")

        'Requests a random number between 1 and 9
        'Each case contains a different "Wisdom"
        'wisdoms were obtained from Copilot and are electronics themed.
        Select Case GetRandomNumberBetween(9, 1)
            Case 1
                Console.WriteLine("A transistor's true power lies in its ability to amplify not just signals, but possibilities.")
            Case 2
                Console.WriteLine("In the world of circuits, even the smallest component can make the biggest difference.")
            Case 3
                Console.WriteLine("Just like a capacitor stores energy for future use, always be prepared to harness your potential when the time is right.")
            Case 4
                Console.WriteLine("An Oscillator's rhythm is the heartbeat of innovation.")
            Case 5
                Console.WriteLine("In the realm of semiconductors, change is the only constant.")
            Case 6
                Console.WriteLine("A well-designed circuit is a symphony of precision and creativity")
            Case 7
                Console.WriteLine("Resistors teach us that sometimes, resistance is necessary to achieve balance.")
            Case 8
                Console.WriteLine("Diodes remind us that direction matters in the flow of life.")
            Case 9
                Console.WriteLine("Capacitors show that patience and storage can lead to powerful releases.")
        End Select

        Console.WriteLine("Hope you enjoyed your fortune!")
        Console.ReadLine()
    End Sub


    Function GetRandomNumberBetween(max As Integer, min As Integer) As Integer
        Dim value As Integer

        Randomize()

        value = CInt(Int(Rnd() * ((max - min) + 1))) + min 'finds the difference between max and min, finds a random number in that range, adds min

        Return value
    End Function
End Module
