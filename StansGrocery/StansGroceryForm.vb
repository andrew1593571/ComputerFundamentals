Public Class StansGroceryForm
    Private Sub AboutTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutTopToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub ExitTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitTopToolStripMenuItem.Click, ExitContextMenuItem.Click
        Me.Close()
    End Sub

End Class
