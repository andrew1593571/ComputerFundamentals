Option Explicit On
Option Strict On
Imports System.Security.Cryptography



'Andrew Keller
'RCET2265
'Fall 2024
'Math Contest
'https://github.com/andrew1593571/MathContest.git

Public Class MathContestForm
    ''' <summary>
    ''' Checks to see if the student information entered is acceptable.
    ''' Name must not be blank
    ''' Age must be between 7 and 11
    ''' Grade must be between 1 and 4
    ''' </summary>
    Sub ValidStudent()
        Dim userMessage As String = ""
        Dim studentAge As Integer
        Dim studentGrade As Integer

        'will change to true for each check that passes
        Dim nameCheck As Boolean
        Dim ageCheck As Boolean
        Dim gradeCheck As Boolean

        'Check that the name is not blank
        If NameTextBox.Text = "" Then
            userMessage = "Please enter a student name." & vbNewLine
        Else
            nameCheck = True
        End If

        'Check that the age is not blank, then try to convert the age to an integer
        'also check that age is between 7 and 11
        If AgeTextBox.Text <> "" Then
            Try
                studentAge = CInt(AgeTextBox.Text)
                If studentAge >= 7 And studentAge <= 11 Then
                    ageCheck = True
                Else
                    userMessage &= "Age must be between 7 and 11." & vbNewLine
                End If
            Catch ex As Exception
                userMessage &= "Age is not a whole number." & vbNewLine
            End Try
        Else
            userMessage &= "Please enter a student age." & vbNewLine
        End If

        'Check that the grade is not blank, then try to convert the grade to an integer
        'also check that grade is between 1 and 4
        If GradeTextBox.Text <> "" Then
            Try
                studentGrade = CInt(GradeTextBox.Text)
                If studentGrade >= 1 And studentGrade <= 4 Then
                    gradeCheck = True
                Else
                    userMessage &= "Grade must be between 1 and 4." & vbNewLine
                End If
            Catch ex As Exception
                userMessage &= "Grade is not a whole number." & vbNewLine
            End Try
        Else
            userMessage &= "Please enter a student grade." & vbNewLine
        End If

        If nameCheck And ageCheck And gradeCheck Then
            'TODO enable the math problem groups
        Else
            MsgBox(userMessage)
            'Set the focus to the first check to not pass
            Select Case False
                Case nameCheck
                    NameTextBox.Focus()
                Case ageCheck
                    AgeTextBox.Focus()
                Case gradeCheck
                    GradeTextBox.Focus()
            End Select
        End If

    End Sub


    Private Sub InformationUpdated(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged, AgeTextBox.TextChanged, GradeTextBox.TextChanged
        InformationTimer.Stop()
        InformationTimer.Start()
    End Sub

    Private Sub InformationTimer_Tick(sender As Object, e As EventArgs) Handles InformationTimer.Tick
        InformationTimer.Stop()
        ValidStudent()
    End Sub
End Class
