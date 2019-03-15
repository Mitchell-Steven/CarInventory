
Option Strict On

''' <summary>
''' Author Name:    Steven Mitchell
''' Project Name:   Car Inventory
''' Date:           March 15, 2019
''' Description     Application to keep a list of vehicles and information about them.
''' </summary>

Public Class frmCarInventory

    Private vehicleList As New SortedList                               'Collection of all the vehicleList in the list
    Private currentVehicleIdentificationNumber As String = String.Empty 'Current selected vehicle identification number
    Private editMode As Boolean = False

    ''' <summary>
    ''' btnEnter_Click - Will validate that the data entered into the controls is appropriate.
    '''                - Once the data is validated a vehicle object will be created using the  
    '''                - parameterized constructor. It will also insert the new vehicle object
    '''                - into the vehicleList collection. It will also check to see if the data in
    '''                - the controls has been selected from the listview by the user. In that case
    '''                - it will need to update the data in the specific vehicle object and the 
    '''                - listview as well.
    ''' </summary>
    ''' <param name="sender">Object</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim vehicle As Vehicle          'Declare a Vehicle class
        Dim vehicleItem As ListViewItem 'Declare a ListViewItem class

        'Validate the data in the form
        If IsValidInput() = True Then

            'Set the edit flag to true
            editMode = True

            lblResult.Text = "It worked!"

            'If the current vehicle identification number has a no value
            'Then this is not an existing item from the listview
            If currentVehicleIdentificationNumber.Trim.Length = 0 Then

                'Create a new vehicle object using the parameterized constructor
                vehicle = New Vehicle(cmbMake.Text, txtModel.Text, cmbYear.Text, txtPrice.Text, chkNew.Checked)

                'Add the vehicle to the vehicleList collection
                'Using the identification number as the key
                'Which will make the vehicle object easier to
                'Find in the vehicleList collection later
                vehicleList.Add(vehicle.IdentificationNumber.ToString(), vehicle)

            Else
                'If the current vehicle identification number has a value
                'Then the user has selected something from the list view
                'So the data in the vehicle object in the vehicleList collection
                'Must be updated

                'So get the vehicle from the vehicles collection
                'Using the selected key
                vehicle = CType(vehicleList.Item(currentVehicleIdentificationNumber), Vehicle)

                'Update the data in the specific object
                'From the controls
                vehicle.CarMake = cmbMake.Text
                vehicle.CarModel = txtModel.Text
                vehicle.CarYear = cmbYear.Text
                vehicle.CarPrice = txtPrice.Text
                vehicle.NewVehicleStatus = chkNew.Checked
            End If

            'Clear the items from the listview control
            lvwVehicles.Items.Clear()

            'Loop through the vehicleList collection
            'And populate the list view
            For Each vehicleEntry As DictionaryEntry In vehicleList

                'Instantiate a new ListViewItem
                vehicleItem = New ListViewItem()

                'Get the vehicle from the list
                vehicle = CType(vehicleEntry.Value, Vehicle)

                'Assign the values to the checked control
                'And the subitems
                vehicleItem.Checked = vehicle.NewVehicleStatus
                vehicleItem.SubItems.Add(vehicle.IdentificationNumber.ToString())
                vehicleItem.SubItems.Add(vehicle.CarMake)
                vehicleItem.SubItems.Add(vehicle.CarModel)
                vehicleItem.SubItems.Add(vehicle.CarYear)
                vehicleItem.SubItems.Add("$" + vehicle.CarPrice)

                'Add the new instantiated and populated ListViewItem
                'To the listview control
                lvwVehicles.Items.Add(vehicleItem)

            Next vehicleEntry

            'Alternate looping strategy
            'For index As Integer = 0 To vehicleList.Count - 1

            '    'Instantiate a new ListViewItem
            '    'vehicleItem = New ListViewItem()

            '    'Get the vehicle from the list
            '    'vehicle = CType(vehicleList(vehicleList.GetKey(index)), Vehicle)

            '    'Assign the values to the ckecked control
            '    'And the subitems
            '    vehicleItem.Checked = vehicle.NewVehicleStatus
            '    vehicleItem.SubItems.Add(vehicle.IdentificationNumber.ToString())
            '    vehicleItem.SubItems.Add(vehicle.CarMake)
            '    vehicleItem.SubItems.Add(vehicle.CarModel)
            '    vehicleItem.SubItems.Add(vehicle.CarYear)
            '    vehicleItem.SubItems.Add(vehicle.CarPrice)

            '    'Add the new instantiated and populated ListViewItem
            '    'To the listview control
            '    lvwCustomers.Items.Add(vehicleItem)

            'Next index

            'Clear the controls
            Reset()

            'Set the edit flag to false
            editMode = False

        End If

    End Sub

    ''' <summary>
    ''' Reset - set the controls back to their default state.
    ''' </summary>
    Private Sub Reset()


        txtModel.Text = String.Empty
        cmbYear.SelectedIndex = -1
        chkNew.Checked = False
        cmbMake.SelectedIndex = -1
        lblResult.Text = String.Empty
        txtPrice.Text = String.Empty

        currentVehicleIdentificationNumber = String.Empty

    End Sub

    ''' <summary>
    ''' IsValidInput - validates the data in each control to ensure that the user has entered appropriate values
    ''' </summary>
    ''' <returns>Boolean</returns>
    Private Function IsValidInput() As Boolean

        Dim returnValue As Boolean = True
        Dim outputMessage As String = String.Empty
        Dim parseResult As Double

        'Check if the make has been selected
        If cmbMake.SelectedIndex = -1 Then

            'If not set the error message
            outputMessage += "Please select the vehicle's make." & vbCrLf

            'And, set the return value to false
            returnValue = False

        End If

        'Check if the model has been entered
        If txtModel.Text.Trim.Length = 0 Then

            'If not set the error message
            outputMessage += "Please enter the vehicle's model." & vbCrLf

            'And, set the return value to false
            returnValue = False

        End If

        'Check if the year has been entered
        If cmbYear.Text.Trim.Length = 0 Then

            'If not set the error message
            outputMessage += "Please enter the vehicle's year." & vbCrLf

            'And, set the return value to false
            returnValue = False

        End If

        'Check if the price has been entered
        If txtPrice.Text.Trim.Length = 0 Then

            'If not set the error message
            outputMessage += "Please enter the vehicle's price." & vbCrLf

            'And, set the return value to false
            returnValue = False

        End If

        If (Not Double.TryParse(txtPrice.Text, parseResult)) Then

            'If not set the error message
            outputMessage += "Please ensure price is a number." & vbCrLf

            'And, set the return value to false
            returnValue = False

        Else
            parseResult = Math.Round(parseResult, 2)
            txtPrice.Text = CType(parseResult, String)

        End If

        'Check to see if any value
        'Did not validate
        If returnValue = False Then

            'Show the message(s) to the user
            lblResult.Text = "ERRORS" & vbCrLf & outputMessage

        End If

        'Return the boolean value
        'True if it passed validation
        'False if it did not pass validation
        Return returnValue

    End Function

    ''' <summary>
    ''' Event is declared as private because it is only accessible within the form
    ''' The code in the btnReset_Click EventHandler will clear the form and set
    ''' focus back to the input text box. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        'Call the reset sub routine
        Reset()

    End Sub
    ''' <summary>
    ''' Event is declared as private because it is only accessible within the form
    ''' The code in the btnExit_Click EventHandler will close the application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'This will close the form
        Me.Close()

    End Sub

    ''' <summary>
    ''' lvwCustomers_ItemCheck - used to prevent the user from checking the check box in the list view
    '''                        - if it is not in edit mode
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lvwCustomers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvwVehicles.ItemCheck

        'If it is not in edit mode
        If editMode = False Then

            'The new value to the current value
            'So it cannot be set in the listview by the user
            e.NewValue = e.CurrentValue

        End If

    End Sub

    ''' <summary>
    ''' lvwCustomers_SelectedIndexChanged - when the user selected a row in the list it will populate the fields for editing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lvwCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwVehicles.SelectedIndexChanged

        'Constant that represents the index of the subitem in the list that
        'Holds the vehicle identification number 
        Const identificationSubItemIndex As Integer = 1

        'Get the vehicle identification number 
        currentVehicleIdentificationNumber = lvwVehicles.Items(lvwVehicles.FocusedItem.Index).SubItems(identificationSubItemIndex).Text

        'Use the vehicle identification number to get the customer from the collection object
        Dim vehicle As Vehicle = CType(vehicleList.Item(currentVehicleIdentificationNumber), Vehicle)

        'Set the controls on the form
        txtModel.Text = vehicle.CarModel            'Get the model and set the text box
        cmbYear.Text = vehicle.CarYear              'Get the year and set the text box
        cmbMake.Text = vehicle.CarMake              'Get the make and set the combo box
        txtPrice.Text = vehicle.CarPrice            'Get the price and set the text box
        chkNew.Checked = vehicle.NewVehicleStatus   'Get the vehicle status and set the combo box

        lblResult.Text = vehicle.GetInformation()


    End Sub

    'Private Sub lvwCustomers_Click(sender As Object, e As EventArgs) Handles lvwCustomers.Click
    '    lbResult.Text = "aaa"
    'End Sub
End Class

