﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RollOfTheDiceListBoxForm
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
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.RollButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.ResultsListBox = New System.Windows.Forms.ListBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.Location = New System.Drawing.Point(712, 389)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(100, 60)
        Me.ExitButton.TabIndex = 3
        Me.ExitButton.Text = "E&xit"
        Me.ToolTip.SetToolTip(Me.ExitButton, "Exit the Program")
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'RollButton
        '
        Me.RollButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RollButton.Location = New System.Drawing.Point(12, 389)
        Me.RollButton.Name = "RollButton"
        Me.RollButton.Size = New System.Drawing.Size(100, 60)
        Me.RollButton.TabIndex = 1
        Me.RollButton.Text = "&Roll"
        Me.ToolTip.SetToolTip(Me.RollButton, "Rolls the dice an additional 1000 Times")
        Me.RollButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ClearButton.Location = New System.Drawing.Point(118, 389)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(100, 60)
        Me.ClearButton.TabIndex = 2
        Me.ClearButton.Text = "&Clear"
        Me.ToolTip.SetToolTip(Me.ClearButton, "Clear the Results")
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'ResultsListBox
        '
        Me.ResultsListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultsListBox.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultsListBox.FormattingEnabled = True
        Me.ResultsListBox.ItemHeight = 22
        Me.ResultsListBox.Location = New System.Drawing.Point(12, 12)
        Me.ResultsListBox.Name = "ResultsListBox"
        Me.ResultsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ResultsListBox.Size = New System.Drawing.Size(800, 356)
        Me.ResultsListBox.TabIndex = 3
        Me.ResultsListBox.TabStop = False
        '
        'RollOfTheDiceListBoxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 461)
        Me.Controls.Add(Me.ResultsListBox)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.RollButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Name = "RollOfTheDiceListBoxForm"
        Me.Text = "Roll of the Dice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ExitButton As Button
    Friend WithEvents RollButton As Button
    Friend WithEvents ClearButton As Button
    Friend WithEvents ResultsListBox As ListBox
    Friend WithEvents ToolTip As ToolTip
End Class
