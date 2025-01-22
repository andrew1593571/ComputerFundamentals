Imports System.Linq.Expressions

Public Class GraphicsExampleForm

    ''' <summary>
    ''' Draw a line from (0,0) to (100,100)
    ''' </summary>
    Sub DrawLine()
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim pen As New Pen(Color.Blue, PenSize())

        g.DrawLine(pen, 0, 0, 100, 100)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Draw a rectangle from (100,100) to (300,300)
    ''' </summary>
    Sub DrawRectangle()
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim pen As New Pen(Color.Blue, PenSize())

        g.DrawRectangle(pen, 100, 100, 300, 300)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Draw an ellipse from (100,100) to (300,300)
    ''' </summary>
    Sub DrawCircle()
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim pen As New Pen(Color.Blue, PenSize())

        g.DrawEllipse(pen, 100, 100, 300, 300)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Draw text at 50,50
    ''' </summary>
    Sub DrawText()
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim brush As New SolidBrush(Color.Red)

        g.DrawString("Hello", Me.Font, brush, 50, 50)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    Sub DrawImage(imagePath As String)
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim image As Image = Image.FromFile(imagePath)

        Dim resized As New Bitmap(image, DrawingPictureBox.Width, DrawingPictureBox.Height)

        g.DrawImage(resized, 0, 0)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    Function PenColor(Optional newColor As Color = Nothing) As Color
        Static _color As Color

        If newColor <> Nothing Then
            _color = newColor
        End If

        Return _color
    End Function
    Function PenSize(Optional newSize As Single = 0) As Single
        Static _size As Single

        If newSize <> 0 Then
            _size = newSize
        End If

        Return _size
    End Function

    Sub MouseDraw(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim pen As New Pen(PenColor(), PenSize())

        g.DrawLine(pen, startX, startY, endX, endY)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    Sub DrawDivisions()
        Dim xSpace As Integer = DrawingPictureBox.Width \ 10
        Dim ySpace As Integer = DrawingPictureBox.Height \ 8
        Dim existingColor As Color = PenColor()

        PenColor(Color.LightGray)

        For i = 0 To xSpace * 10 Step xSpace
            MouseDraw(i, 0, i, ySpace * 8)
        Next

        For i = 0 To ySpace * 8 Step ySpace
            MouseDraw(0, i, xSpace * 10, i)
        Next

        PenColor(existingColor)

    End Sub

    Sub DrawSinWave()
        Dim degToRad As Double = Math.PI / 180
        Dim oneDegree As Double = DrawingPictureBox.Width / 360
        Dim peak As Integer = DrawingPictureBox.Height \ 2
        Dim currentY As Integer
        Dim nextX As Integer
        Dim lastY As Integer = peak
        Dim lastX As Integer

        For i = 0 To DrawingPictureBox.Width \ CInt(oneDegree)
            currentY = CInt(peak * Math.Sin(degToRad * i)) + peak
            nextX = lastX + CInt(oneDegree)
            MouseDraw(lastX, lastY, nextX, currentY)
            lastY = currentY
            lastX = nextX
        Next

    End Sub

    Function CreateBitmap() As Image
        Dim bmp As New Bitmap(DrawingPictureBox.Width, DrawingPictureBox.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.Clear(DrawingPictureBox.BackColor)

        g.Dispose()
        Return bmp
    End Function

    Function StoreBitmap(Optional image As Image = Nothing) As Image
        Static bmp As Bitmap

        If image Is Nothing Then
            Return bmp
        Else
            bmp = New Bitmap(image)
            Return bmp
        End If

    End Function

    '______Event Handlers Below Here______
    Private Sub GraphicsExampleForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        DrawLine()
        DrawRectangle()
        DrawCircle()
        DrawText()
        DrawImage("C:\Users\andre\Downloads\scifi-4916165_1920.jpg")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DrawingPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseDown, DrawingPictureBox.MouseMove
        Static oldX%, oldY%

        Me.Text = $"({e.X.ToString},{e.Y.ToString}) Button: {e.Button.ToString} Color: {PenColor().Name}"

        If e.Button = MouseButtons.Left Then
            MouseDraw(oldX, oldY, e.X, e.Y)
        End If

        oldX = e.X
        oldY = e.Y

    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        PenColor(ColorDialog.Color)
    End Sub

    Private Sub GraphicsExampleForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        PenColor(Color.Black)
        StoreBitmap(CreateBitmap())
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DrawingPictureBox.Image = StoreBitmap(CreateBitmap())
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        DrawingPictureBox.BackColor = ColorDialog.Color
    End Sub

    Private Sub WaveButton_Click(sender As Object, e As EventArgs) Handles WaveButton.Click
        DrawDivisions()
        DrawSinWave()
    End Sub

    Private Sub OpenTopMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTopMenuItem.Click

        OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "image files (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif|All files (*.*)|*.*"

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            DrawImage(OpenFileDialog.FileName)
        End If

    End Sub

    Private Sub SaveTopMenuItem_Click(sender As Object, e As EventArgs) Handles SaveTopMenuItem.Click

        SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        SaveFileDialog.FileName = $"Untitled-{DateTime.Today.Now.ToString("yyMMddhhmmss")}.bmp"

        SaveFileDialog.ShowDialog()

        StoreBitmap().Save(SaveFileDialog.FileName)

    End Sub

    Private Sub GraphicsExampleForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Visible Then

            Dim newbmp As New Bitmap(StoreBitmap(), DrawingPictureBox.Width, DrawingPictureBox.Height)

            DrawingPictureBox.Image = StoreBitmap(newbmp)

        End If
    End Sub

    Private Sub PenSizeTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles PenSizeTrackBar.ValueChanged
        PenSize(PenSizeTrackBar.Value)
    End Sub
End Class
