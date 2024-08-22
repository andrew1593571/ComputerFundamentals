Option Explicit On
Option Strict On

Module SayMyName
    'Andrew Keller
    'RCET2265
    'Fall 2024
    'Say My Name
    'https://github.com/andrew1593571/SayMyName.git

    Sub Main()
        Dim name As String

        'sets the console background color to Blue
        Console.BackgroundColor() = ConsoleColor.DarkBlue
        Console.Clear()

        'Writes to console asking for user name
        Console.WriteLine("What is your name?")

        'Reads line from console
        name = Console.ReadLine()

        Console.WriteLine("Hello, " & name & "!")

        'Console.Beep() 
        'Console.Beep(200, 1000) 'beeps at 200Hz for 1000ms

        Console.ReadLine() 'keeps the console open until the user hits enter
    End Sub

End Module
