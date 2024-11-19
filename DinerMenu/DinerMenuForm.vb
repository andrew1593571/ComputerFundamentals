Public Class DinerMenuForm
    Private Sub SoupButton_Click(sender As Object, e As EventArgs) Handles SoupButton.Click
        Dim title As String = "~ Soup of the Day ~" & vbNewLine
        Dim name As String = "Hacker's Delight" & vbNewLine
        Dim description As String
        description = "A savory blend of chicken, potatoes, and carrots seasoned with herbs and spices, all topped off with a rich cream sause. The perfect accompaniment to any digital conquest!"


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
End Class
