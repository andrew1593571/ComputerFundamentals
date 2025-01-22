Option Strict On
Option Explicit On

Module WorkingWithFilesExamples

    Sub Main()

        'OpenFile()
        'DotNetExample()
        'AppendFile()
        'ReadEntireFile()
        'GetUserData("C:\Users\andre\Git Repositories\ComputerFundamentals\WorkingWithFilesExample\WorkingWithFilesExample\userData.txt")
        GetUserData("..\..\userData.txt")

        Console.Read()
    End Sub

    Sub OpenFile()
        'opens file so we can write to it
        'will create the file if it does not exist
        'openmode.output will overwrite the existing file contents
        FileOpen(1, "testFile.txt", OpenMode.Output)

        Write(1, "Wake Up Neo...")
        Write(1, "Knock Knock")
        Write(1, "Follow the White Rabbit")

        FileClose(1)

    End Sub

    Sub AppendFile()
        'opens file so we can write to it
        'will create the file if it does not exist
        'openmode.append will not overwrite the existing file contents
        'will append to the existing content
        FileOpen(1, "testFile.txt", OpenMode.Append)

        WriteLine(1, "Wake Up Neo...")
        WriteLine(1, "Knock Knock")
        WriteLine(1, "Follow the White Rabbit")

        FileClose(1)

    End Sub

    Sub ReadFile()
        Dim currentRecord As String

        FileOpen(1, "testFile.txt", OpenMode.Input)

        For i = 1 To 5
            Input(1, currentRecord)
            Console.WriteLine(currentRecord)
        Next

        FileClose(1)
    End Sub

    Sub ReadEntireFile()
        Dim currentRecord As String = ""

        FileOpen(1, "testFile.txt", OpenMode.Input)

        Do Until EOF(1)
            Input(1, currentRecord)
            Console.WriteLine(currentRecord)
            Console.WriteLine($"After input: {Seek(1)}")
        Loop
    End Sub

    Sub GetUserData(fileName As String)
        Dim currentRecord As String
        Dim originalFile As Integer
        Dim newFile As Integer = FreeFile()
        Dim temp() As String

        FileOpen(newFile, "..\..\cleanFile.txt", OpenMode.Output)

        originalFile = FreeFile()

        Try
            FileOpen(originalFile, fileName, OpenMode.Input) '
            Do Until EOF(originalFile)
                'Input(originalFile, currentRecord)
                'If currentRecord <> "" Then
                '    WriteLine(newFile, currentRecord)
                'End If
                currentRecord = LineInput(originalFile)
                Console.WriteLine(currentRecord)

                temp = Split(currentRecord, """")
                temp = Split(temp(1), ",")
                temp(0) = Replace(temp(0), "$$", "")

                Write(newFile, temp(0))
                Write(newFile, temp(1))
                Write(newFile, temp(2))
                WriteLine(newFile, temp(3))

                Console.WriteLine(currentRecord)

            Loop
        Catch ex As Exception
            Console.WriteLine($"file not found: {fileName}")
        End Try
        FileClose(originalFile)
        FileClose(newFile)
    End Sub

    Sub DotNetExample()
        ' Open file for output.
        FileOpen(1, "TestFile.txt", OpenMode.Output)
        ' Print text to the file. The quotation marks will be in the display.
        Write(1, "This is a test.")
        ' Go to the next line.
        WriteLine(1)
        ' Skip a line.
        WriteLine(1)
        ' Print in two print zones. You will see commas and quotation marks
        ' in the output file.
        WriteLine(1, "Zone 1", SPC(10), "Zone 2")
        ' Build a longer string before calling WriteLine.
        WriteLine(1, "Hello" & "  " & "World")
        ' Include five leading spaces.
        WriteLine(1, SPC(5), "Leading spaces")
        ' Print a word starting at column 10.
        WriteLine(1, TAB(10), "Hello")

        ' Assign Boolean and Date values.
        Dim aBool As Boolean
        Dim aDate As DateTime
        aBool = False
        aDate = DateTime.Parse("February 12, 1969")

        ' Dates and Booleans are translated using locale settings of 
        ' your system.
        WriteLine(1, aBool & " is a Boolean value.")
        WriteLine(1, aDate & " is a date.")
        WriteLine(1, aBool)
        WriteLine(1, aDate)
        ' Close the file.
        FileClose(1)

        ' Contents of TestFile.txt
        '"This is a test.",
        '
        '"Zone 1",          "Zone 2"
        '"Hello  World"
        '     "Leading spaces"
        '         ,"Hello"
        '"False is a Boolean value."
        '"2/12/1969 is a date."
    End Sub

End Module
