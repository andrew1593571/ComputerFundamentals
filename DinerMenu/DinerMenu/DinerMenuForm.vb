Option Strict On
Option Explicit On

'Andrew Keller
'RCET2265
'Fall 2024
'Diner Menu Program
'https://github.com/andrew1593571/DinerMenu.git


Public Class DinerMenuForm
    Private Sub SoupButton_Click(sender As Object, e As EventArgs) Handles SoupButton.Click
        Dim soupTitle As String = "~ Soup of the Day ~" & vbNewLine
        Dim soupName As String = "Hacker's Delight" & vbNewLine
        Dim soupDescription As String
        soupDescription = "A taste of digital anarchy in every spoonful. Our soup is a playful subversion of traditional comfort food, with a dash of code-red madness thrown in for good measure. Served in a bowl that's equal parts high-tech and retro-futuristic, Hacker's Delight is the perfect dish for those who refuse to be silenced by the ordinary."

        'Set the DisplaySpecialLabel text to the title, name, and description of the dish
        DisplaySpecialLabel.Text = soupTitle & vbNewLine & soupName & vbNewLine & soupDescription
    End Sub

    Private Sub SaladButton_Click(sender As Object, e As EventArgs) Handles SaladButton.Click
        Dim saladTitle As String = "~ House Salad ~" & vbNewLine
        Dim saladName As String = "Digital Delirium" & vbNewLine
        Dim saladDescription As String
        saladDescription = "A salad of mixed greens, crispy fried bacon, diced chicken, and shredded mozzarella cheese, topped with a drizzle of digital tears, a special sauce made from the finest algorithmically-generated spices."

        'Set the DisplaySpecialLabel text to the title, name, and description of the dish
        DisplaySpecialLabel.Text = saladTitle & vbNewLine & saladName & vbNewLine & saladDescription
    End Sub

    Private Sub FishButton_Click(sender As Object, e As EventArgs) Handles FishButton.Click
        Dim fishTitle As String = "~ Daily Fish ~" & vbNewLine
        Dim fishName As String = "The Circuit Breaker" & vbNewLine
        Dim fishDescription As String
        fishDescription = " Crispy fried catfish that's been rebooted 17 times to achieve optimal crunchiness, served with a side of coleslaw that's been genetically engineered to have the perfect ratio of vinegar to sugar."

        'Set the DisplaySpecialLabel text to the title, name, and description of the dish
        DisplaySpecialLabel.Text = fishTitle & vbNewLine & fishName & vbNewLine & fishDescription
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
