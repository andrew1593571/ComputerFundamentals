'Andrew Keller
'RCET2265
'Fall 2024
'Etch-A-Sketch
'https://github.com/andrew1593571/EtchASketch.git

Public Class AboutForm
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
        EtchASketchForm.Show()
    End Sub

    Private Sub InformationLabel_Click(sender As Object, e As EventArgs) Handles InformationLabel.Click

    End Sub
End Class