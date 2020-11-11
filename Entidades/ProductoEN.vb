
Public Class ProductoEN
    Private _codprod As Integer
    Public Property CodProd() As Integer
        Get
            Return _codprod
        End Get
        Set(ByVal value As Integer)
            _codprod = value
        End Set
    End Property

    Private _codhistorico As Integer
    Public Property CodHistorico() As Integer
        Get
            Return _codhistorico
        End Get
        Set(ByVal value As Integer)
            _codhistorico = value
        End Set
    End Property


    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _precio As String
    Public Property Precio() As String
        Get
            Return _precio
        End Get
        Set(ByVal value As String)
            _precio = value
        End Set
    End Property


    Private _sector As String
    Public Property Sector() As String
        Get
            Return _sector
        End Get
        Set(ByVal value As String)
            _sector = value
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
End Class
