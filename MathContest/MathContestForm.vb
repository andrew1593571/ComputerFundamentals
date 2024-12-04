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
    ''' Stores the total number of problems solved
    ''' </summary>
    ''' <param name="additional"></param>
    ''' <param name="clear"></param>
    ''' <returns></returns>
    Function ProblemsSolved(Optional additional As Integer = 0, Optional clear As Boolean = False) As Integer
        Static total As Integer

        If clear Then
            total = 0
        Else
            total += additional
        End If

        Return total
    End Function

    ''' <summary>
    ''' Stores the number of problems correctly answered
    ''' </summary>
    ''' <param name="additional"></param>
    ''' <param name="clear"></param>
    ''' <returns></returns>
    Function AnsweredCorrectly(Optional additional As Integer = 0, Optional clear As Boolean = False) As Integer
        Static totalCorrect As Integer

        If clear Then
            totalCorrect = 0
        Else
            totalCorrect += additional
        End If

        Return totalCorrect
    End Function

    ''' <summary>
    ''' Stores and returns the current math problem. Also generates new problems
    ''' </summary>
    ''' <param name="newProblem">When True,generates a new problem</param>
    ''' <returns></returns>
    Function CurrentProblem(Optional newProblem As Boolean = False) As Integer()
        Static _numberOne As Integer
        Static _numberTwo As Integer

        'Clear the current student answer and generate a new one
        If newProblem Then
            AnswerTextBox.Text = ""
            _numberOne = GetRandomNumberInRange(10 * CurrentStudentGrade(), 1)
            _numberTwo = GetRandomNumberInRange(10 * CurrentStudentGrade(), 1)
        End If

        Number1TextBox.Text = CStr(_numberOne)
        Number2TextBox.Text = CStr(_numberTwo)

        Return {_numberOne, _numberTwo}
    End Function

    ''' <summary>
    ''' Stores the Current Student age
    ''' </summary>
    ''' <param name="age"></param>
    ''' <returns></returns>
    Function CurrentStudentAge(Optional age As Integer = 0) As Integer
        Static _studentAge As Integer

        If age <> 0 Then
            _studentAge = age
        End If

        Return _studentAge
    End Function

    ''' <summary>
    ''' Stores the current student Grade
    ''' </summary>
    ''' <param name="grade"></param>
    ''' <returns></returns>
    Function CurrentStudentGrade(Optional grade As Integer = 0) As Integer
        Static _studentGrade As Integer

        If grade <> 0 Then
            _studentGrade = grade
        End If

        Return _studentGrade
    End Function

    ''' <summary>
    ''' Stores the current student name
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Function CurrentStudentName(Optional name As String = "") As String
        Static _studentName As String

        If name <> "" Then
            _studentName = name
        End If

        Return _studentName
    End Function

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
            CurrentStudentName(NameTextBox.Text)
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
                    CurrentStudentAge(studentAge)
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
                    CurrentStudentGrade(studentGrade)
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
            CurrentProblem(True)
        End If

    End Sub

    ''' <summary>
    ''' Returns a random number in the specified range
    ''' </summary>
    ''' <param name="Max"></param>
    ''' <param name="Min"></param>
    ''' <returns></returns>
    Function GetRandomNumberInRange(Max As Integer, Optional Min As Integer = 0) As Integer
        Dim randomNumber As Integer

        Randomize(DateTime.Now.Millisecond)
        randomNumber = CInt(Math.Floor((Rnd() * ((Max - Min) + 1)))) + Min

        Return randomNumber
    End Function


    '###___EVENT HANDLERS BELOW HERE___###
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

    ''' <summary>
    ''' When the submit button is clicked, determines if the student answered correctly, 
    ''' unlocks the summary button, locks the student information, generates new problem
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim correctAnswer As Integer
        Dim problem() As Integer = CurrentProblem()
        Dim studentAnswer As Integer

        'Determine the correct answer for the selected math type
        Select Case True
            Case AddRadioButton.Checked
                correctAnswer = problem(0) + problem(1)
            Case SubtractRadioButton.Checked
                correctAnswer = problem(0) - problem(1)
            Case MultiplyRadioButton.Checked
                correctAnswer = problem(0) * problem(1)
            Case DivideRadioButton.Checked
                correctAnswer = problem(0) \ problem(1)
        End Select

        'Convert the student answer to an integer from a string
        Try
            studentAnswer = CInt(AnswerTextBox.Text)
        Catch ex As Exception
            MsgBox("Student answer is not a whole number.")
            Exit Sub
        End Try

        'Check if the student answer is correct
        If studentAnswer = correctAnswer Then
            MsgBox("Congratulations! You answered correctly!")
            AnsweredCorrectly(1) 'add one to the total answered correctly
        Else
            MsgBox($"The correct answer was {CStr(correctAnswer)}.")
        End If

        ProblemsSolved(1) 'Add one to the total number of problems solved

        'enable the summary button once submit is clicked and lock the student information
        SummaryButton.Enabled = True
        NameTextBox.ReadOnly = True
        AgeTextBox.ReadOnly = True
        GradeTextBox.ReadOnly = True

        CurrentProblem(True) 'Generate new problem
    End Sub

    ''' <summary>
    ''' Presents a messagebox to the user with the number answered correct and total asked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        MsgBox($"{CurrentStudentName()} has answered {CStr(AnsweredCorrectly())} correctly out of a possible {CStr(ProblemsSolved())}.")
    End Sub
End Class
