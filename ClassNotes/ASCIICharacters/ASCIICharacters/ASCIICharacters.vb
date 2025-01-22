Module ASCIICharacters

    Sub Main()
        Console.OutputEncoding = System.Text.UnicodeEncoding.Unicode
        For i = 0 To 255
            Console.WriteLine($"{i}: {Chr(i)}")
        Next

        Console.WriteLine(ChrW(&H2660)) '&H in front of any unicode character will tell it to use it in Hex
        Console.WriteLine(ChrW(&H2663))
        Console.ReadLine()
    End Sub

End Module
