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
    ''' Stores the current information check status of the student information
    ''' </summary>
    ''' <param name="newStatus"></param>
    ''' <returns></returns>
    Function CheckStatus(Optional newStatus As Boolean() = Nothing) As Boolean()
        Static status() As Boolean = {False, False, False}

        If newStatus IsNot Nothing Then
            status = newStatus
        End If

        Return status
    End Function

    Sub ValidateName()
        Dim infoState() As Boolean = CheckStatus()
        'Check that the name is not blank
        If NameTextBox.Text = "" Then
            infoState(0) = False
            MsgBox("Please enter a student name.")
        Else
            'set infoState to True
            infoState(0) = True
        End If
        CheckStatus(infoState)
    End Sub

    Sub ValidateAge()
        Dim infoState() As Boolean = CheckStatus()
        Dim studentAge As Integer

        infoState(1) = False

        'Check that the age is not blank, then try to convert the age to an integer
        'also check that age is between 7 and 11
        If AgeTextBox.Text <> "" Then
            Try
                studentAge = CInt(AgeTextBox.Text)
                If studentAge >= 7 And studentAge <= 11 Then
                    infoState(1) = True
                Else
                    MsgBox("Age must be between 7 and 11.")
                End If
            Catch ex As Exception
                MsgBox("Age is not a whole number.")
            End Try
        Else
            MsgBox("Please enter a student age.")
        End If
        CheckStatus(infoState)
    End Sub

    Sub ValidateGrade()
        Dim infoState() As Boolean = CheckStatus()
        Dim studentGrade As Integer

        infoState(2) = False

        'Check that the grade is not blank, then try to convert the grade to an integer
        'also check that grade is between 1 and 4
        If GradeTextBox.Text <> "" Then
            Try
                studentGrade = CInt(GradeTextBox.Text)
                If studentGrade >= 1 And studentGrade <= 4 Then
                    infoState(2) = True
                Else
                    MsgBox("Grade must be between 1 and 4.")
                End If
            Catch ex As Exception
                MsgBox("Grade is not a whole number.")
            End Try
        Else
            MsgBox("Please enter a student grade.")
        End If
        CheckStatus(infoState)
    End Sub

    ''' <summary>
    ''' Checks to see if the student information entered is acceptable.
    ''' Name must not be blank
    ''' Age must be between 7 and 11
    ''' Grade must be between 1 and 4
    ''' </summary>
    Sub ValidStudent()
        Dim infoState() As Boolean = CheckStatus()

        If infoState(0) And infoState(1) And infoState(2) Then
            ProblemGroupBox.Enabled = True
            ProblemTypeGroupBox.Enabled = True
            SubmitButton.Enabled = True
        End If

    End Sub

    Private Sub NameTimer_Tick(sender As Object, e As EventArgs) Handles NameTimer.Tick
        'Stops the timer, then validates the student name
        NameTimer.Stop()
        ValidateName()
        ValidStudent()
    End Sub

    Private Sub AgeTimer_Tick(sender As Object, e As EventArgs) Handles AgeTimer.Tick
        'Stops the timer, then validates the student age
        AgeTimer.Stop()
        ValidateAge()
        ValidStudent()
    End Sub

    Private Sub GradeTimer_Tick(sender As Object, e As EventArgs) Handles GradeTimer.Tick
        'Stops the timer, then validates the student grade
        GradeTimer.Stop()
        ValidateGrade()
        ValidStudent()
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        'Stops then starts the NameTimer to prevent triggering checks while the user is typing
        NameTimer.Stop()
        NameTimer.Start()
    End Sub

    Private Sub AgeTextBox_TextChanged(sender As Object, e As EventArgs) Handles AgeTextBox.TextChanged
        'Stops then starts the AgeTimer to prevent triggering checks while the user is typing
        AgeTimer.Stop()
        AgeTimer.Start()
    End Sub

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GradeTextBox.TextChanged
        'Stops then starts the GradeTimer to prevent triggering checks while the user is typing
        GradeTimer.Stop()
        GradeTimer.Start()
    End Sub
End Class
