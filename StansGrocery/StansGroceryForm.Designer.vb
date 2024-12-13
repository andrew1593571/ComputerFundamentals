<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StansGroceryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SearchContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.SearchLabel = New System.Windows.Forms.Label()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.DisplayGroupBox = New System.Windows.Forms.GroupBox()
        Me.DisplayListBox = New System.Windows.Forms.ListBox()
        Me.DisplayLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStrip.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.SearchGroupBox.SuspendLayout()
        Me.DisplayGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchButton.ContextMenuStrip = Me.ContextMenuStrip
        Me.SearchButton.Location = New System.Drawing.Point(462, 19)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(97, 36)
        Me.SearchButton.TabIndex = 0
        Me.SearchButton.Text = "&Search"
        Me.ToolTip.SetToolTip(Me.SearchButton, "Search for Item")
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchContextMenuItem, Me.ExitContextMenuItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(110, 48)
        '
        'SearchContextMenuItem
        '
        Me.SearchContextMenuItem.Name = "SearchContextMenuItem"
        Me.SearchContextMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SearchContextMenuItem.Text = "Search"
        '
        'ExitContextMenuItem
        '
        Me.ExitContextMenuItem.Name = "ExitContextMenuItem"
        Me.ExitContextMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.ExitContextMenuItem.Text = "Exit"
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.ContextMenuStrip = Me.ContextMenuStrip
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileTopToolStripMenuItem, Me.HelpTopToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(589, 24)
        Me.TopMenuStrip.TabIndex = 1
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileTopToolStripMenuItem
        '
        Me.FileTopToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchTopToolStripMenuItem, Me.ExitTopToolStripMenuItem})
        Me.FileTopToolStripMenuItem.Name = "FileTopToolStripMenuItem"
        Me.FileTopToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileTopToolStripMenuItem.Text = "&File"
        '
        'SearchTopToolStripMenuItem
        '
        Me.SearchTopToolStripMenuItem.Name = "SearchTopToolStripMenuItem"
        Me.SearchTopToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SearchTopToolStripMenuItem.Text = "&Search"
        '
        'ExitTopToolStripMenuItem
        '
        Me.ExitTopToolStripMenuItem.Name = "ExitTopToolStripMenuItem"
        Me.ExitTopToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.ExitTopToolStripMenuItem.Text = "E&xit"
        '
        'HelpTopToolStripMenuItem
        '
        Me.HelpTopToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutTopToolStripMenuItem})
        Me.HelpTopToolStripMenuItem.Name = "HelpTopToolStripMenuItem"
        Me.HelpTopToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpTopToolStripMenuItem.Text = "&Help"
        '
        'AboutTopToolStripMenuItem
        '
        Me.AboutTopToolStripMenuItem.Name = "AboutTopToolStripMenuItem"
        Me.AboutTopToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutTopToolStripMenuItem.Text = "&About"
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchGroupBox.ContextMenuStrip = Me.ContextMenuStrip
        Me.SearchGroupBox.Controls.Add(Me.SearchTextBox)
        Me.SearchGroupBox.Controls.Add(Me.SearchLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Location = New System.Drawing.Point(12, 27)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(565, 64)
        Me.SearchGroupBox.TabIndex = 2
        Me.SearchGroupBox.TabStop = False
        '
        'SearchLabel
        '
        Me.SearchLabel.AutoSize = True
        Me.SearchLabel.Location = New System.Drawing.Point(6, 19)
        Me.SearchLabel.Name = "SearchLabel"
        Me.SearchLabel.Size = New System.Drawing.Size(87, 13)
        Me.SearchLabel.TabIndex = 3
        Me.SearchLabel.Text = "Search By Name"
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchTextBox.Location = New System.Drawing.Point(9, 35)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(447, 20)
        Me.SearchTextBox.TabIndex = 4
        '
        'DisplayGroupBox
        '
        Me.DisplayGroupBox.Controls.Add(Me.DisplayLabel)
        Me.DisplayGroupBox.Controls.Add(Me.DisplayListBox)
        Me.DisplayGroupBox.Location = New System.Drawing.Point(12, 97)
        Me.DisplayGroupBox.Name = "DisplayGroupBox"
        Me.DisplayGroupBox.Size = New System.Drawing.Size(251, 236)
        Me.DisplayGroupBox.TabIndex = 3
        Me.DisplayGroupBox.TabStop = False
        '
        'DisplayListBox
        '
        Me.DisplayListBox.FormattingEnabled = True
        Me.DisplayListBox.Location = New System.Drawing.Point(6, 58)
        Me.DisplayListBox.Name = "DisplayListBox"
        Me.DisplayListBox.Size = New System.Drawing.Size(239, 173)
        Me.DisplayListBox.TabIndex = 0
        '
        'DisplayLabel
        '
        Me.DisplayLabel.Location = New System.Drawing.Point(6, 16)
        Me.DisplayLabel.Name = "DisplayLabel"
        Me.DisplayLabel.Size = New System.Drawing.Size(239, 39)
        Me.DisplayLabel.TabIndex = 4
        Me.DisplayLabel.Text = "Display Label"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(269, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'StansGroceryForm
        '
        Me.AcceptButton = Me.SearchButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DisplayGroupBox)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "StansGroceryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stan's Grocery"
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.DisplayGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SearchButton As Button
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents SearchContextMenuItem As ToolStripMenuItem
    Friend WithEvents ExitContextMenuItem As ToolStripMenuItem
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents SearchLabel As Label
    Friend WithEvents DisplayGroupBox As GroupBox
    Friend WithEvents DisplayListBox As ListBox
    Friend WithEvents DisplayLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
