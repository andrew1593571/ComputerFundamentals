Option Explicit On
Option Strict On
Option Compare Binary

'Andrew Keller
'RCET2265
'Fall 2024
'Car Rental
'https://github.com/andrew1593571/CarRental.git

Public Class RentalForm

    ''' <summary>
    ''' Stores the total miles driven by all customers
    ''' </summary>
    ''' <param name="additionalMiles"></param>
    ''' <returns></returns>
    Function TotalMiles(Optional additionalMiles As Double = 0) As Double
        Static _miles As Double

        _miles += additionalMiles

        Return _miles
    End Function

    ''' <summary>
    ''' Stores the total charges for all customers
    ''' </summary>
    ''' <param name="additionalCharge"></param>
    ''' <returns></returns>
    Function TotalCharges(Optional additionalCharge As Double = 0) As Double
        Static _charges As Double

        _charges += additionalCharge

        Return _charges
    End Function

    ''' <summary>
    ''' stores the number of total customers served.
    ''' </summary>
    ''' <param name="newCustomer"></param>
    ''' <returns></returns>
    Function TotalCustomers(Optional newCustomer As Boolean = False) As Integer
        Static _totalCustomers As Integer

        If newCustomer Then
            _totalCustomers += 1
        End If

        Return _totalCustomers
    End Function

    ''' <summary>
    ''' Stores the current difference in the odometer readings
    ''' </summary>
    ''' <param name="difference"></param>
    ''' <returns></returns>
    Function StoreOdometerDifference(Optional difference As Integer = 0) As Integer
        Static _odometerDifference As Integer

        If difference > 0 Then
            _odometerDifference = difference
        End If

        Return _odometerDifference
    End Function

    ''' <summary>
    ''' Stores the number of days as an integer
    ''' </summary>
    ''' <param name="days"></param>
    ''' <returns></returns>
    Function storeDays(Optional days As Integer = 0) As Integer
        Static _days As Integer

        If days > 0 Then
            _days = days
        End If

        Return _days
    End Function

    ''' <summary>
    ''' Returns true if the inputs are all valid
    ''' </summary>
    ''' <returns></returns>
    Function ValidInputs() As Boolean
        Dim valid As Boolean
        Dim focusSet As Boolean
        Dim userMessage As String = "" 'stores the error message
        Dim startOdometer As Integer
        Dim endOdometer As Integer
        Dim odometerError As Boolean
        Dim numberDays As Integer

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
                StoreOdometerDifference(endOdometer - startOdometer)

            Else
                userMessage &= "Ending odometer must greater than Beginning Odometer." & vbNewLine
                If Not focusSet Then
                    EndOdometerTextBox.Focus()
                    focusSet = True
                End If
            End If
        End If

        'Check that the days are a number and that the value is not 0
        Try
            numberDays = CInt(DaysTextBox.Text)
            If numberDays > 0 Then
                storeDays(numberDays)
            Else
                userMessage &= "Number of days must be greater than 0." & vbNewLine
            End If
        Catch ex As Exception
            userMessage &= "Number of days must be a whole number." & vbNewLine
            If Not focusSet Then
                DaysTextBox.Focus()
                focusSet = True
            End If
        End Try

        If Not focusSet Then
            valid = True
        Else
            MsgBox(userMessage)
        End If
        Return valid
    End Function

    ''' <summary>
    ''' calculates the current rental costs
    ''' </summary>
    Sub CalculateRental()
        Dim milesTraveled As Double
        Dim mileageCharge As Double
        Dim dayCharge As Double
        Dim totalCharge As Double
        Dim discount As Double

        Select Case True
            Case MilesradioButton.Checked
                milesTraveled = StoreOdometerDifference()
            Case KilometersradioButton.Checked
                milesTraveled = StoreOdometerDifference() * 0.62
        End Select
        TotalMilesTextBox.Text = CStr(milesTraveled) & " mi"

        TotalMiles(milesTraveled)

        Select Case milesTraveled
            Case <= 200
                mileageCharge = 0
            Case <= 500
                milesTraveled -= 200 'subtract out the previous 200 miles
                mileageCharge = milesTraveled * 0.12
            Case > 500
                milesTraveled -= 500 'subtract out the previous 500 miles
                mileageCharge = 300 * 0.12 'add in the charge for the 300 miles between 201 and 500
                mileageCharge += milesTraveled * 0.1
        End Select

        MileageChargeTextBox.Text = $"${CStr(mileageCharge)}"

        dayCharge = storeDays() * 15
        DayChargeTextBox.Text = $"${CStr(dayCharge)}"

        totalCharge = dayCharge + mileageCharge
        If AAAcheckbox.Checked Then 'if AAA member, apply 5% discount
            discount += totalCharge * 0.05
        End If
        If Seniorcheckbox.Checked Then 'if Senior Citizen, apply 3% discount
            discount += totalCharge * 0.03
        End If
        TotalDiscountTextBox.Text = $"${CStr(discount)}"

        totalCharge -= discount
        TotalChargeTextBox.Text = $"${CStr(totalCharge)}"

        TotalCharges(totalCharge)
    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click, CalculateToolStripMenuItem.Click
        If ValidInputs() Then
            CalculateRental()
            TotalCustomers(True)
        End If
    End Sub
End Class
