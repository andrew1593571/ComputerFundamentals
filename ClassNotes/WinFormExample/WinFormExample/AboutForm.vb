Public Class AboutForm
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
        WinFormExampleForm.Show()
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class