Public Class DinerMenuForm
    Private Sub SoupButton_Click(sender As Object, e As EventArgs) Handles SoupButton.Click
        Dim title As String = "~ Soup of the Day ~" & vbNewLine
        Dim name As String = "Hacker's Delight" & vbNewLine
        Dim description As String
        description = "A taste of digital anarchy in every spoonful. Our soup is a playful subversion of traditional comfort food, with a dash of code-red madness thrown in for good measure. Served in a bowl that's equal parts high-tech and retro-futuristic, Hacker's Delight is the perfect dish for those who refuse to be silenced by the ordinary."

        DisplaySpecialLabel.Text = title & vbNewLine & name & vbNewLine & description
    End Sub

    Private Sub SaladButton_Click(sender As Object, e As EventArgs) Handles SaladButton.Click
        Dim title As String = "~ House Salad ~" & vbNewLine
        Dim name As String = "Digital Delirium" & vbNewLine
        Dim description As String
        description = "A salad of mixed greens, crispy fried bacon, diced chicken, and shredded mozzarella cheese, topped with a drizzle of digital tears, a special sauce made from the finest algorithmically-generated spices."

        DisplaySpecialLabel.Text = title & vbNewLine & name & vbNewLine & description
    End Sub

    Private Sub FishButton_Click(sender As Object, e As EventArgs) Handles FishButton.Click
        Dim title As String = "~ Daily Fish ~" & vbNewLine
        Dim name As String = "The Circuit Breaker" & vbNewLine
        Dim description As String
        description = " Crispy fried catfish that's been rebooted 17 times to achieve optimal crunchiness, served with a side of coleslaw that's been genetically engineered to have the perfect ratio of vinegar to sugar."


        DisplaySpecialLabel.Text = title & vbNewLine & name & vbNewLine & description
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
