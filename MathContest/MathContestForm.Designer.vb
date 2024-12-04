<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MathContestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StudentInformationGroupBox = New System.Windows.Forms.GroupBox()
        Me.GradeLabel = New System.Windows.Forms.Label()
        Me.AgeLabel = New System.Windows.Forms.Label()
        Me.GradeTextBox = New System.Windows.Forms.TextBox()
        Me.AgeTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.ProblemGroupBox = New System.Windows.Forms.GroupBox()
        Me.AnswerTextBox = New System.Windows.Forms.TextBox()
        Me.AnswerLabel = New System.Windows.Forms.Label()
        Me.Number2TextBox = New System.Windows.Forms.TextBox()
        Me.Number2Label = New System.Windows.Forms.Label()
        Me.Number1TextBox = New System.Windows.Forms.TextBox()
        Me.Number1Label = New System.Windows.Forms.Label()
        Me.ProblemTypeGroupBox = New System.Windows.Forms.GroupBox()
        Me.DivideRadioButton = New System.Windows.Forms.RadioButton()
        Me.MultiplyRadioButton = New System.Windows.Forms.RadioButton()
        Me.SubtractRadioButton = New System.Windows.Forms.RadioButton()
        Me.AddRadioButton = New System.Windows.Forms.RadioButton()
        Me.ButtonGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SummaryButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.SubmitButton = New System.Windows.Forms.Button()
        Me.NameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AgeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GradeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StudentInformationGroupBox.SuspendLayout()
        Me.ProblemGroupBox.SuspendLayout()
        Me.ProblemTypeGroupBox.SuspendLayout()
        Me.ButtonGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'StudentInformationGroupBox
        '
        Me.StudentInformationGroupBox.Controls.Add(Me.GradeLabel)
        Me.StudentInformationGroupBox.Controls.Add(Me.AgeLabel)
        Me.StudentInformationGroupBox.Controls.Add(Me.GradeTextBox)
        Me.StudentInformationGroupBox.Controls.Add(Me.AgeTextBox)
        Me.StudentInformationGroupBox.Controls.Add(Me.NameTextBox)
        Me.StudentInformationGroupBox.Controls.Add(Me.NameLabel)
        Me.StudentInformationGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.StudentInformationGroupBox.Name = "StudentInformationGroupBox"
        Me.StudentInformationGroupBox.Size = New System.Drawing.Size(295, 80)
        Me.StudentInformationGroupBox.TabIndex = 0
        Me.StudentInformationGroupBox.TabStop = False
        Me.StudentInformationGroupBox.Text = "Student Information"
        '
        'GradeLabel
        '
        Me.GradeLabel.AutoSize = True
        Me.GradeLabel.Location = New System.Drawing.Point(234, 21)
        Me.GradeLabel.Name = "GradeLabel"
        Me.GradeLabel.Size = New System.Drawing.Size(36, 13)
        Me.GradeLabel.TabIndex = 4
        Me.GradeLabel.Text = "Grade"
        '
        'AgeLabel
        '
        Me.AgeLabel.AutoSize = True
        Me.AgeLabel.Location = New System.Drawing.Point(177, 20)
        Me.AgeLabel.Name = "AgeLabel"
        Me.AgeLabel.Size = New System.Drawing.Size(26, 13)
        Me.AgeLabel.TabIndex = 1
        Me.AgeLabel.Text = "Age"
        '
        'GradeTextBox
        '
        Me.GradeTextBox.Location = New System.Drawing.Point(237, 37)
        Me.GradeTextBox.Name = "GradeTextBox"
        Me.GradeTextBox.Size = New System.Drawing.Size(41, 20)
        Me.GradeTextBox.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.GradeTextBox, "Student Grade Between 1 and 4")
        '
        'AgeTextBox
        '
        Me.AgeTextBox.Location = New System.Drawing.Point(180, 37)
        Me.AgeTextBox.Name = "AgeTextBox"
        Me.AgeTextBox.Size = New System.Drawing.Size(41, 20)
        Me.AgeTextBox.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.AgeTextBox, "Student Age Between 7 and 11")
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(10, 37)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(155, 20)
        Me.NameTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.NameTextBox, "Student Full Name")
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(7, 20)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(35, 13)
        Me.NameLabel.TabIndex = 0
        Me.NameLabel.Text = "Name"
        '
        'ProblemGroupBox
        '
        Me.ProblemGroupBox.Controls.Add(Me.AnswerTextBox)
        Me.ProblemGroupBox.Controls.Add(Me.AnswerLabel)
        Me.ProblemGroupBox.Controls.Add(Me.Number2TextBox)
        Me.ProblemGroupBox.Controls.Add(Me.Number2Label)
        Me.ProblemGroupBox.Controls.Add(Me.Number1TextBox)
        Me.ProblemGroupBox.Controls.Add(Me.Number1Label)
        Me.ProblemGroupBox.Enabled = False
        Me.ProblemGroupBox.Location = New System.Drawing.Point(12, 98)
        Me.ProblemGroupBox.Name = "ProblemGroupBox"
        Me.ProblemGroupBox.Size = New System.Drawing.Size(174, 166)
        Me.ProblemGroupBox.TabIndex = 1
        Me.ProblemGroupBox.TabStop = False
        Me.ProblemGroupBox.Text = "Current Math Problem"
        '
        'AnswerTextBox
        '
        Me.AnswerTextBox.Location = New System.Drawing.Point(10, 132)
        Me.AnswerTextBox.Name = "AnswerTextBox"
        Me.AnswerTextBox.Size = New System.Drawing.Size(155, 20)
        Me.AnswerTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.AnswerTextBox, "The Student's Answer")
        '
        'AnswerLabel
        '
        Me.AnswerLabel.AutoSize = True
        Me.AnswerLabel.Location = New System.Drawing.Point(7, 115)
        Me.AnswerLabel.Name = "AnswerLabel"
        Me.AnswerLabel.Size = New System.Drawing.Size(82, 13)
        Me.AnswerLabel.TabIndex = 6
        Me.AnswerLabel.Text = "Student Answer"
        '
        'Number2TextBox
        '
        Me.Number2TextBox.Location = New System.Drawing.Point(10, 82)
        Me.Number2TextBox.Name = "Number2TextBox"
        Me.Number2TextBox.ReadOnly = True
        Me.Number2TextBox.Size = New System.Drawing.Size(155, 20)
        Me.Number2TextBox.TabIndex = 5
        Me.Number2TextBox.TabStop = False
        Me.ToolTip.SetToolTip(Me.Number2TextBox, "The Second Number in the Equation.")
        '
        'Number2Label
        '
        Me.Number2Label.AutoSize = True
        Me.Number2Label.Location = New System.Drawing.Point(7, 65)
        Me.Number2Label.Name = "Number2Label"
        Me.Number2Label.Size = New System.Drawing.Size(65, 13)
        Me.Number2Label.TabIndex = 4
        Me.Number2Label.Text = "2nd Number"
        '
        'Number1TextBox
        '
        Me.Number1TextBox.Location = New System.Drawing.Point(10, 33)
        Me.Number1TextBox.Name = "Number1TextBox"
        Me.Number1TextBox.ReadOnly = True
        Me.Number1TextBox.Size = New System.Drawing.Size(155, 20)
        Me.Number1TextBox.TabIndex = 3
        Me.Number1TextBox.TabStop = False
        Me.ToolTip.SetToolTip(Me.Number1TextBox, "The first number in the equation")
        '
        'Number1Label
        '
        Me.Number1Label.AutoSize = True
        Me.Number1Label.Location = New System.Drawing.Point(7, 16)
        Me.Number1Label.Name = "Number1Label"
        Me.Number1Label.Size = New System.Drawing.Size(61, 13)
        Me.Number1Label.TabIndex = 2
        Me.Number1Label.Text = "1st Number"
        '
        'ProblemTypeGroupBox
        '
        Me.ProblemTypeGroupBox.Controls.Add(Me.DivideRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.MultiplyRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.SubtractRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.AddRadioButton)
        Me.ProblemTypeGroupBox.Enabled = False
        Me.ProblemTypeGroupBox.Location = New System.Drawing.Point(192, 98)
        Me.ProblemTypeGroupBox.Name = "ProblemTypeGroupBox"
        Me.ProblemTypeGroupBox.Size = New System.Drawing.Size(115, 166)
        Me.ProblemTypeGroupBox.TabIndex = 2
        Me.ProblemTypeGroupBox.TabStop = False
        Me.ProblemTypeGroupBox.Text = "Math Problem Type"
        Me.ToolTip.SetToolTip(Me.ProblemTypeGroupBox, "The Math Problem Type")
        '
        'DivideRadioButton
        '
        Me.DivideRadioButton.AutoSize = True
        Me.DivideRadioButton.Location = New System.Drawing.Point(6, 102)
        Me.DivideRadioButton.Name = "DivideRadioButton"
        Me.DivideRadioButton.Size = New System.Drawing.Size(55, 17)
        Me.DivideRadioButton.TabIndex = 3
        Me.DivideRadioButton.Text = "Divide"
        Me.DivideRadioButton.UseVisualStyleBackColor = True
        '
        'MultiplyRadioButton
        '
        Me.MultiplyRadioButton.AutoSize = True
        Me.MultiplyRadioButton.Location = New System.Drawing.Point(6, 79)
        Me.MultiplyRadioButton.Name = "MultiplyRadioButton"
        Me.MultiplyRadioButton.Size = New System.Drawing.Size(60, 17)
        Me.MultiplyRadioButton.TabIndex = 2
        Me.MultiplyRadioButton.Text = "Multiply"
        Me.MultiplyRadioButton.UseVisualStyleBackColor = True
        '
        'SubtractRadioButton
        '
        Me.SubtractRadioButton.AutoSize = True
        Me.SubtractRadioButton.Location = New System.Drawing.Point(6, 56)
        Me.SubtractRadioButton.Name = "SubtractRadioButton"
        Me.SubtractRadioButton.Size = New System.Drawing.Size(65, 17)
        Me.SubtractRadioButton.TabIndex = 1
        Me.SubtractRadioButton.TabStop = True
        Me.SubtractRadioButton.Text = "Subtract"
        Me.SubtractRadioButton.UseVisualStyleBackColor = True
        '
        'AddRadioButton
        '
        Me.AddRadioButton.AutoSize = True
        Me.AddRadioButton.Checked = True
        Me.AddRadioButton.Location = New System.Drawing.Point(6, 33)
        Me.AddRadioButton.Name = "AddRadioButton"
        Me.AddRadioButton.Size = New System.Drawing.Size(44, 17)
        Me.AddRadioButton.TabIndex = 0
        Me.AddRadioButton.TabStop = True
        Me.AddRadioButton.Text = "Add"
        Me.AddRadioButton.UseVisualStyleBackColor = True
        '
        'ButtonGroupBox
        '
        Me.ButtonGroupBox.Controls.Add(Me.ExitButton)
        Me.ButtonGroupBox.Controls.Add(Me.SummaryButton)
        Me.ButtonGroupBox.Controls.Add(Me.ClearButton)
        Me.ButtonGroupBox.Controls.Add(Me.SubmitButton)
        Me.ButtonGroupBox.Location = New System.Drawing.Point(313, 12)
        Me.ButtonGroupBox.Name = "ButtonGroupBox"
        Me.ButtonGroupBox.Size = New System.Drawing.Size(124, 252)
        Me.ButtonGroupBox.TabIndex = 3
        Me.ButtonGroupBox.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(6, 174)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(109, 45)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "Exit"
        Me.ToolTip.SetToolTip(Me.ExitButton, "Exits the program")
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SummaryButton
        '
        Me.SummaryButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SummaryButton.Enabled = False
        Me.SummaryButton.Location = New System.Drawing.Point(6, 123)
        Me.SummaryButton.Name = "SummaryButton"
        Me.SummaryButton.Size = New System.Drawing.Size(109, 45)
        Me.SummaryButton.TabIndex = 2
        Me.SummaryButton.Text = "Summary"
        Me.ToolTip.SetToolTip(Me.SummaryButton, "Presents a summary for the current student")
        Me.SummaryButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(6, 72)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(109, 45)
        Me.ClearButton.TabIndex = 1
        Me.ClearButton.Text = "Clear"
        Me.ToolTip.SetToolTip(Me.ClearButton, "Clears the current student and resets the interface")
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'SubmitButton
        '
        Me.SubmitButton.Enabled = False
        Me.SubmitButton.Location = New System.Drawing.Point(6, 21)
        Me.SubmitButton.Name = "SubmitButton"
        Me.SubmitButton.Size = New System.Drawing.Size(109, 45)
        Me.SubmitButton.TabIndex = 0
        Me.SubmitButton.Text = "Submit"
        Me.ToolTip.SetToolTip(Me.SubmitButton, "Submits the Student Answer")
        Me.SubmitButton.UseVisualStyleBackColor = True
        '
        'NameTimer
        '
        Me.NameTimer.Interval = 500
        '
        'AgeTimer
        '
        Me.AgeTimer.Interval = 500
        '
        'GradeTimer
        '
        Me.GradeTimer.Interval = 500
        '
        'MathContestForm
        '
        Me.AcceptButton = Me.SubmitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SummaryButton
        Me.ClientSize = New System.Drawing.Size(448, 271)
        Me.Controls.Add(Me.ButtonGroupBox)
        Me.Controls.Add(Me.ProblemTypeGroupBox)
        Me.Controls.Add(Me.ProblemGroupBox)
        Me.Controls.Add(Me.StudentInformationGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MathContestForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Math Contest"
        Me.StudentInformationGroupBox.ResumeLayout(False)
        Me.StudentInformationGroupBox.PerformLayout()
        Me.ProblemGroupBox.ResumeLayout(False)
        Me.ProblemGroupBox.PerformLayout()
        Me.ProblemTypeGroupBox.ResumeLayout(False)
        Me.ProblemTypeGroupBox.PerformLayout()
        Me.ButtonGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StudentInformationGroupBox As GroupBox
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents GradeLabel As Label
    Friend WithEvents AgeLabel As Label
    Friend WithEvents GradeTextBox As TextBox
    Friend WithEvents AgeTextBox As TextBox
    Friend WithEvents ProblemGroupBox As GroupBox
    Friend WithEvents Number1Label As Label
    Friend WithEvents AnswerTextBox As TextBox
    Friend WithEvents AnswerLabel As Label
    Friend WithEvents Number2TextBox As TextBox
    Friend WithEvents Number2Label As Label
    Friend WithEvents Number1TextBox As TextBox
    Friend WithEvents ProblemTypeGroupBox As GroupBox
    Friend WithEvents SubtractRadioButton As RadioButton
    Friend WithEvents AddRadioButton As RadioButton
    Friend WithEvents DivideRadioButton As RadioButton
    Friend WithEvents MultiplyRadioButton As RadioButton
    Friend WithEvents ButtonGroupBox As GroupBox
    Friend WithEvents ClearButton As Button
    Friend WithEvents SubmitButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents SummaryButton As Button
    Friend WithEvents NameTimer As Timer
    Friend WithEvents AgeTimer As Timer
    Friend WithEvents GradeTimer As Timer
    Friend WithEvents ToolTip As ToolTip
End Class
