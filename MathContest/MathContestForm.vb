Option Explicit On
Option Strict On

'Andrew Keller
'RCET2265
'Fall 2024
'Math Contest
'https://github.com/andrew1593571/MathContest.git

Public Class MathContestForm
    ''' <summary>
    ''' Checks to see if the student information entered is acceptable.
    ''' Age must be between 7 and 11
    ''' Grade must be between 1 and 4
    ''' </summary>
    Sub ValidStudent()
        If NameTextBox.Text <> "" And AgeTextBox.Text <> "" And GradeTextBox.Text <> "" Then
            MsgBox("Values are Not Empty")


        End If
    End Sub


    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        ValidStudent()
    End Sub
End Class
