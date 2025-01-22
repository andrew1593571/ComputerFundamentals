Option Strict On
Option Explicit On
Option Compare Text
Imports System.CodeDom.Compiler
Imports System.IO



'Andrew Keller
'RCET2265
'Fall 2024
'Stans Grocery
'https://github.com/andrew1593571/StansGrocery.git

Public Class StansGroceryForm
    ''' <summary>
    ''' Stores the store inventory as a readily availble array where:
    ''' _inventory(0,n) is the item name
    ''' _inventory(1,n) is the aisle
    ''' _inventory(2,n) is the category
    ''' </summary>
    ''' <param name="newInventory"></param>
    ''' <param name="food"></param>
    ''' <returns></returns>
    Function Inventory(Optional newInventory As Boolean = False, Optional food As String(,) = Nothing) As String(,)
        Static _inventory As String(,)

        If newInventory Then
            _inventory = food
        End If

        Return _inventory
    End Function

    ''' <summary>
    ''' Imports the store inventory from file. Stores as an array where: 
    ''' food(0,n) is the item name
    ''' food(1,n) is the aisle
    ''' food(2,n) is the category
    ''' </summary>
    Sub ImportData()
        Dim filepath As String = "../../Grocery.txt"
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String
        Dim temp() As String
        Dim _food(,) As String
        Dim itemNumber As Integer

        Try
            FileOpen(fileNumber, filepath, OpenMode.Input)

            Do Until EOF(fileNumber)
                ReDim Preserve _food(2, itemNumber)
                currentRecord = LineInput(fileNumber)
                currentRecord = currentRecord.Replace("""", "")
                temp = Split(currentRecord, ",")

                For i = 0 To temp.Length - 1
                    Select Case True
                        Case temp(i).Contains("$$ITM")
                            _food(0, itemNumber) = temp(i).Replace("$$ITM", "")
                        Case temp(i).Contains("##LOC")
                            _food(1, itemNumber) = temp(i).Replace("##LOC", "")
                        Case temp(i).Contains("%%CAT")
                            _food(2, itemNumber) = temp(i).Replace("%%CAT", "")
                    End Select
                Next

                itemNumber += 1
            Loop

            FileClose(fileNumber)
            Inventory(True, _food)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    ''' <summary>
    ''' Adds the correct items to the DisplayListBox. 
    ''' If Show All is in the filterComboBox, does it match the search requirements.
    ''' If the filterByAisle if on, compare the aisle to the selected aisle
    ''' If the filterByCategory is on, compare the category to the selected category
    ''' </summary>
    Sub ListItems()
        Dim numberOfItems As Integer
        numberOfItems = Inventory.Length \ 3

        DisplayListBox.Items.Clear() 'clear the list box before adding new items

        If FilterComboBox.Text = "Show All" Then
            For i = 0 To numberOfItems - 1
                If Inventory()(0, i).Contains(SearchTextBox.Text) Then
                    DisplayListBox.Items.Add(Inventory()(0, i))
                End If
            Next
        Else
            Select Case True
                Case FilterByAisleRadioButton.Checked
                    For i = 0 To numberOfItems - 1
                        If Inventory()(1, i) = FilterComboBox.Text Then
                            DisplayListBox.Items.Add(Inventory()(0, i))
                        End If
                    Next
                Case FilterByCategoryRadioButton.Checked
                    For i = 0 To numberOfItems - 1
                        If Inventory()(2, i) = FilterComboBox.Text Then
                            DisplayListBox.Items.Add(Inventory()(0, i))
                        End If
                    Next
            End Select

        End If

    End Sub

    ''' <summary>
    ''' Updates the FilterComboBox Items with the selected filter type
    ''' </summary>
    Sub UpdateFilterList()
        Dim numberOfItems As Integer
        Dim usedOptions As String = "" 'stores all of the already used options to prevent reuse
        numberOfItems = Inventory().Length \ 3

        FilterComboBox.Items.Clear() 'clears the filterComboBox items

        Select Case True
            Case FilterByAisleRadioButton.Checked
                For i = 0 To numberOfItems - 1
                    If usedOptions.IndexOf(Inventory()(1, i)) < 0 Then 'checks if the option has already been used
                        FilterComboBox.Items.Add(Inventory()(1, i))
                        usedOptions &= $"{Inventory()(1, i)}," 'adds option to the list if it has been used
                    End If
                Next
            Case FilterByCategoryRadioButton.Checked
                For i = 0 To numberOfItems - 1
                    If usedOptions.IndexOf(Inventory()(2, i)) < 0 Then
                        FilterComboBox.Items.Add(Inventory()(2, i))
                        usedOptions &= $"{Inventory()(2, i)}," 'adds option to the list if it has been used
                    End If
                Next
        End Select
    End Sub


    '###___EVENT HANDLERS BELOW HERE___###

    Private Sub AboutTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutTopToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub ExitTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitTopToolStripMenuItem.Click, ExitContextMenuItem.Click
        Me.Close()
    End Sub

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ImportData()
        ListItems()
        UpdateFilterList()
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        Dim numberOfItems As Integer
        numberOfItems = Inventory.Length \ 3
        For i = 0 To numberOfItems - 1
            If DisplayListBox.SelectedItem.ToString = Inventory()(0, i) Then
                DisplayLabel.Text = $"{DisplayListBox.SelectedItem.ToString} is found on aisle {Inventory()(1, i)} with the {Inventory()(2, i)}"
                Exit For
            End If
        Next
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click, SearchContextMenuItem.Click, SearchTopToolStripMenuItem.Click
        If SearchTextBox.Text = "zzz" Then 'If zzz was entered, close the form. Otherwise search for items.
            Me.Close()

        Else
            FilterByAisleRadioButton.Checked = True
            FilterComboBox.Text = "Show All"
            DisplayLabel.Text = "Please Select an Item"


            ListItems()

            If DisplayListBox.Items.Count = 0 Then
                DisplayLabel.Text = $"Sorry, no matches for {SearchTextBox.Text}"
            End If

        End If
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComboBox.SelectedIndexChanged
        ListItems()
    End Sub

    Private Sub FilterRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FilterByAisleRadioButton.CheckedChanged, FilterByCategoryRadioButton.CheckedChanged
        If Me.Visible Then 'stops the event from calling the Update function during form load.
            UpdateFilterList()
        End If
    End Sub
End Class
