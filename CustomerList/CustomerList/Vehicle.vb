Option Strict On
Public Class Vehicle


    Private Shared vehicleCount As Integer                  'Static or shared private variable to hold the number of vehicles
    Private vehicleIdentificationNumber As Integer = 0      'Private variable to hold the vehicle's identification number
    Private vehicleMake As String = String.Empty            'Private variable to hold the vehicles's make
    Private vehicleModel As String = String.Empty           'Private variable to hold the vehicle's model
    Private vehicleYear As String = String.Empty            'Private variable to hold the vehicle's year
    Private vehiclePrice As String = String.Empty           'Private variable to hold the vehicle's price
    Private vehicleNewStatus As Boolean = False             'Private variable to hold the vehicle's status

    ''' <summary>
    ''' Constructor - Default - creates a new customer object
    ''' </summary>
    Public Sub New()

        vehicleCount += 1                           'Increment the shared/static variable counter by 1
        vehicleIdentificationNumber = vehicleCount  'Assign the vehicle's ID

    End Sub

    ''' <summary>
    ''' Constructor - Parameterized - creates a new vehicle object
    ''' </summary>
    ''' <param name="make"></param>
    ''' <param name="model"></param>
    ''' <param name="year"></param>
    ''' <param name="price"></param>
    ''' <param name="vehicleStatus"></param>
    Public Sub New(make As String, model As String, year As String, price As String, vehicleStatus As Boolean)

        'Call the other constructor 
        'To set the vehicle count and
        'To set the customer ID
        Me.New()

        vehicleMake = make                  'Set the vehicle make
        vehicleModel = model                'Set the vehicle model
        vehicleYear = year                  'Set the vehicle year
        vehiclePrice = price                'Set the vehicle price
        vehicleNewStatus = vehicleStatus    'Set the vehicle status

    End Sub


    ''' <summary>
    ''' Count ReadOnly Property - Gets the number of vehicles that have been instantiated/created
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property Count() As Integer
        Get
            Return vehicleCount
        End Get
    End Property

    ''' <summary>
    ''' IdentificationNumber ReadOnly Property - Gets a specific vehicle's identification number
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property IdentificationNumber() As Integer
        Get
            Return vehicleIdentificationNumber
        End Get
    End Property

    ''' <summary>
    ''' NewVehicleStatus Property - >Gets and Sets the new vehicle status of a vehicle
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property NewVehicleStatus() As Boolean
        Get
            Return vehicleNewStatus
        End Get
        Set(ByVal value As Boolean)
            vehicleNewStatus = value
        End Set
    End Property

    ''' <summary>
    ''' CarMake property - Gets and Sets the make of a vehicle
    ''' </summary>
    ''' <returns>String</returns>
    Public Property CarMake() As String
        Get
            Return vehicleMake
        End Get
        Set(ByVal value As String)
            vehicleMake = value
        End Set
    End Property

    ''' <summary>
    ''' CarModel property - Gets and Sets the model of a vehicle
    ''' </summary>
    ''' <returns>String</returns>
    Public Property CarModel() As String
        Get
            Return vehicleModel
        End Get
        Set(ByVal value As String)
            vehicleModel = value
        End Set
    End Property

    ''' <summary>
    ''' CarYear property - Gets and Sets the year of a vehicle
    ''' </summary>
    ''' <returns>String</returns>
    Public Property CarYear() As String
        Get
            Return vehicleYear
        End Get
        Set(ByVal value As String)
            vehicleYear = value
        End Set
    End Property

    ''' <summary>
    ''' CarPrice property - Gets and Sets the price of a vehicle
    ''' </summary>
    ''' <returns>String</returns>
    Public Property CarPrice() As String
        Get
            Return vehiclePrice
        End Get
        Set(ByVal value As String)
            vehiclePrice = value
        End Set
    End Property

    ''' <summary>
    ''' GetInformation is a function that returns vehicle information based on the private properties within the class scope
    ''' </summary>
    ''' <returns>String</returns>
    Public Function GetInformation() As String

        Return "This vehicle is a " & vehicleYear & " " & vehicleMake & ", " & vehicleModel & ".It costs $" & vehiclePrice & IIf(vehicleNewStatus = True, " and is new", " and is used").ToString()

    End Function


End Class
