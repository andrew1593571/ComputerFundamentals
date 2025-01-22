Option Strict On
Option Explicit On

'Andrew Keller
'RCET2265
'Fall 2024
'Stans Grocery
'https://github.com/andrew1593571/StansGrocery.git


Public Class SplashScreenForm
    Private Sub SplashScreenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashTimer.Start()
    End Sub

    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs) Handles SplashTimer.Tick
        StansGroceryForm.Show()
        Me.Close()
    End Sub
End Class