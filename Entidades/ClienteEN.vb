
Public Class ClienteEN
    Private _codcli As Integer
    Public Property CodCli() As Integer
        Get
            Return _codcli
        End Get
        Set(ByVal value As Integer)
            _codcli = value
        End Set
    End Property

    Private _codloc As Integer
    Public Property CodLoc() As Integer
        Get
            Return _codloc
        End Get
        Set(ByVal value As Integer)
            _codloc = value
        End Set
    End Property

    Private _cuit As String
    Public Property Cuit() As String
        Get
            Return _cuit
        End Get
        Set(ByVal value As String)
            _cuit = value
        End Set
    End Property

    Private _razonsocial As String
    Public Property RazonSocial() As String
        Get
            Return _razonsocial
        End Get
        Set(ByVal value As String)
            _razonsocial = value
        End Set
    End Property

    Private _calle As String
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property

    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property

    Private _piso As String
    Public Property Piso() As String
        Get
            Return _piso
        End Get
        Set(ByVal value As String)
            _piso = value
        End Set
    End Property

    Private _departamento As String
    Public Property Departamento() As String
        Get
            Return _departamento
        End Get
        Set(ByVal value As String)
            _departamento = value
        End Set
    End Property

    Private _activo As Boolean
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Private _dvh As Integer
    Public Property DVH() As Integer
        Get
            Return _dvh
        End Get
        Set(ByVal value As Integer)
            _dvh = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _localidad As String
    Public Property Localidad() As String
        Get
            Return _localidad
        End Get
        Set(ByVal value As String)
            _localidad = value
        End Set
    End Property

    Private _telefono As List(Of TelefonoEN)
    Public Property Telefono() As List(Of TelefonoEN)
        Get
            Return _telefono
        End Get
        Set(ByVal value As List(Of TelefonoEN))
            _telefono = value
        End Set
    End Property
End Class
