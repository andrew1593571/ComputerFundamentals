Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'Accumulate Messages
'https://github.com/andrew1593571/AccumulateMessages.git

Imports System

Module MessageProgram
    Sub Main(args As String())
        'uncomment to test interactively
        'Test.Manual()
        Test.Auto()
    End Sub

    Function UserMessages(ByVal newMessage As String, ByVal clear As Boolean) As String
        Static Dim messages As String

        If clear Then
            messages = ""
        ElseIf newMessage = "" Then
            messages = messages
        ElseIf messages = "" Then
            messages = newMessage
        Else
            messages = messages & vbCrLf & newMessage
        End If

        Return messages
    End Function


End Module
