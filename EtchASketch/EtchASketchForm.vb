Imports System.Linq.Expressions

'Andrew Keller
'RCET2265
'Fall 2024
'Etch-A-Sketch
'https://github.com/andrew1593571/EtchASketch.git

Public Class EtchASketchForm

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
    ''' Draw text at 50,50.
    ''' </summary>
    Sub DrawText()
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim brush As New SolidBrush(Color.Red)

        g.DrawString("Hello", Me.Font, brush, 50, 50)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Draws an image the full size of the DrawingPictureBox
    ''' </summary>
    ''' <param name="imagePath"></param>
    Sub DrawImage(imagePath As String)
        Dim bmp As Image = StoreBitmap()
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim image As Image = Image.FromFile(imagePath)

        Dim resized As New Bitmap(image, DrawingPictureBox.Width, DrawingPictureBox.Height)

        g.DrawImage(resized, 0, 0)

        StoreBitmap(bmp)
        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Stores the Pen color for all of the graphics tools
    ''' </summary>
    ''' <param name="newColor"></param>
    ''' <returns></returns>
    Function PenColor(Optional newColor As Color = Nothing) As Color
        Static _color As Color

        If newColor <> Nothing Then
            _color = newColor
        End If

        Return _color
    End Function

    ''' <summary>
    ''' Stores the pen size for all of the graphics tools.
    ''' </summary>
    ''' <param name="newSize"></param>
    ''' <returns></returns>
    Function PenSize(Optional newSize As Single = 0) As Single
        Static _size As Single

        If newSize <> 0 Then
            _size = newSize
        End If

        Return _size
    End Function

    ''' <summary>
    ''' Draws a straight line from the start x and y to the end x and y
    ''' </summary>
    ''' <param name="startX"></param>
    ''' <param name="startY"></param>
    ''' <param name="endX"></param>
    ''' <param name="endY"></param>
    Sub MouseDraw(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        Dim g As Graphics = Graphics.FromImage(StoreBitmap())
        Dim pen As New Pen(PenColor(), PenSize())

        g.DrawLine(pen, startX, startY, endX, endY)

        g.Dispose()
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' Draws scope divisions using the MouseDraw Sub
    ''' </summary>
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

    ''' <summary>
    ''' Draws a sine wave on the bitmap using the MouseDraw function
    ''' </summary>
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

    ''' <summary>
    ''' creates an empty bitmap with the correct size for the DrawingPictureBox
    ''' </summary>
    ''' <returns></returns>
    Function CreateBitmap() As Image
        Dim bmp As New Bitmap(DrawingPictureBox.Width, DrawingPictureBox.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.Clear(DrawingPictureBox.BackColor)

        g.Dispose()
        Return bmp
    End Function

    ''' <summary>
    ''' Stores the bitmap to be drawn on. If not provided with a new image, the bitmap will return the existing
    ''' </summary>
    ''' <param name="image"></param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' When the form is clicked, draws a line, rectangle, and circle on the picturebox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GraphicsExampleForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        DrawLine()
        DrawRectangle()
        DrawCircle()
        DrawText()
        DrawImage("C:\Users\andre\Downloads\scifi-4916165_1920.jpg")
    End Sub

    ''' <summary>
    ''' closes the form when the exit button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Calls the MouseDraw sub whenever the mouse moves and the left mouse button is held
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DrawingPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseDown, DrawingPictureBox.MouseMove
        Static oldX%, oldY%

        'Me.Text = $"({e.X.ToString},{e.Y.ToString}) Button: {e.Button.ToString} Color: {PenColor().Name}"

        If e.Button = MouseButtons.Left Then
            MouseDraw(oldX, oldY, e.X, e.Y)
        End If

        oldX = e.X
        oldY = e.Y

    End Sub

    ''' <summary>
    ''' Changes the pen color with a dialog
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        PenColor(ColorDialog.Color)
    End Sub

    ''' <summary>
    ''' Creates an empty bitmap and sets the pen to black when the form loads
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GraphicsExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        PenColor(Color.Black)
        StoreBitmap(CreateBitmap())
        DrawingPictureBox.Image = StoreBitmap()
    End Sub

    ''' <summary>
    ''' overwrites the existing bitmap with a blank bitmap
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DrawingPictureBox.Image = StoreBitmap(CreateBitmap())
    End Sub

    ''' <summary>
    ''' Sets the background color of the picturebox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        DrawingPictureBox.BackColor = ColorDialog.Color
    End Sub

    ''' <summary>
    ''' draws a oscilloscope view of a sine wave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WaveButton_Click(sender As Object, e As EventArgs) Handles WaveButton.Click
        DrawDivisions()
        DrawSinWave()
    End Sub

    ''' <summary>
    ''' opens and imports an image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenTopMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTopMenuItem.Click

        OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "image files (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif|All files (*.*)|*.*"

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            DrawImage(OpenFileDialog.FileName)
        End If

    End Sub

    ''' <summary>
    ''' prompts the user to save the current bitmap to file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveTopMenuItem_Click(sender As Object, e As EventArgs) Handles SaveTopMenuItem.Click

        SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        SaveFileDialog.FileName = $"Untitled-{DateTime.Today.Now.ToString("yyMMddhhmmss")}.bmp"

        'opens the SaveFileDialog
        SaveFileDialog.ShowDialog()

        StoreBitmap().Save(SaveFileDialog.FileName)

    End Sub

    ''' <summary>
    ''' Scales the current bitmap when the form size is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GraphicsExampleForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Visible Then

            Dim newbmp As New Bitmap(StoreBitmap(), DrawingPictureBox.Width, DrawingPictureBox.Height)

            DrawingPictureBox.Image = StoreBitmap(newbmp)

        End If
    End Sub

    ''' <summary>
    ''' sets the pen size whenever the trackbar is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PenSizeTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles PenSizeTrackBar.ValueChanged
        PenSize(PenSizeTrackBar.Value)
    End Sub
End Class
