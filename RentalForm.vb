Option Explicit On
Option Strict On
Option Compare Binary

'Andrew Keller
'RCET2265
'Fall 2024
'Car Rental
'https://github.com/andrew1593571/CarRental.git

Public Class RentalForm

    Function ValidInputs() As Boolean
        Dim valid As Boolean
        Dim focusSet As Boolean
        Dim userMessage As String = "" 'stores the error message
        Dim startOdometer As Integer
        Dim endOdometer As Integer
        Dim odometerError As Boolean

        'Check the Name
        If NameTextBox.Text = "" Then
            userMessage &= "Customer Name is Blank." & vbNewLine
            If Not focusSet Then
                NameTextBox.Focus()
                focusSet = True
            End If
        End If

        'Check the Address
        If AddressTextBox.Text = "" Then
            userMessage &= "Address is Blank." & vbNewLine
            If Not focusSet Then
                AddressTextBox.Focus()
                focusSet = True
            End If
        End If

        'Check the City
        If CityTextBox.Text = "" Then
            userMessage &= "City is Blank." & vbNewLine
            If Not focusSet Then
                CityTextBox.Focus()
                focusSet = True
            End If
        End If

        'Check the State
        If StateTextBox.Text = "" Then
            userMessage &= "State is Blank." & vbNewLine
            If Not focusSet Then
                StateTextBox.Focus()
                focusSet = True
            End If
        End If

        'Check the Zip Code
        If ZipCodeTextBox.Text = "" Then
            userMessage &= "Zip Code is Blank." & vbNewLine
            If Not focusSet Then
                ZipCodeTextBox.Focus()
                focusSet = True
            End If
        End If

        'Check the Starting Odometer reading
        Try
            startOdometer = CInt(BeginOdometerTextBox.Text)
        Catch ex As Exception
            userMessage &= "Beginning odometer must be a whole number." & vbNewLine
            odometerError = True
            If Not focusSet Then
                BeginOdometerTextBox.Focus()
                focusSet = True
            End If
        End Try

        'Check that the ending odometer is a whole number
        Try
            endOdometer = CInt(EndOdometerTextBox.Text)
        Catch ex As Exception
            odometerError = True
            userMessage &= "Ending odometer must be a whole number." & vbNewLine
            If Not focusSet Then
                EndOdometerTextBox.Focus()
                focusSet = True
            End If
        End Try

        'Check that the ending odometer is greater than the starting odometer
        If Not odometerError Then
            If endOdometer > startOdometer Then
                'TODO store 

            Else
                userMessage &= "Ending odometer must greater than Beginning Odometer." & vbNewLine
                If Not focusSet Then
                    EndOdometerTextBox.Focus()
                    focusSet = True
                End If
            End If
        End If







        Return valid
    End Function


End Class
