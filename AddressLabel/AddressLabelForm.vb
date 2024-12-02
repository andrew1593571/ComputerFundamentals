Public Class AddressLabelForm

    ''' <summary>
    ''' Closes the form when the ExitButton is Pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Clears the Display Label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DisplayLabel.Text = ""
    End Sub

    ''' <summary>
    ''' Formats and displays the address label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        Dim labelText As String

        labelText = $"{FirstNameTextBox.Text} {LastNameTextBox.Text}"
        labelText &= vbNewLine & StreetAddressTextBox.Text
        labelText &= vbNewLine & $"{CityTextBox.Text}, {StateTextBox.Text} {ZipTextBox.Text}"

        DisplayLabel.Text = labelText
    End Sub
End Class
