Public Class NotaPedidoEN
    Private _codnot As Integer
    Public Property CodNot() As Integer
        Get
            Return _codnot
        End Get
        Set(ByVal value As Integer)
            _codnot = value
        End Set
    End Property

    Private _nronota As String
    Public Property NroNota() As String
        Get
            Return _nronota
        End Get
        Set(ByVal value As String)
            _nronota = value
        End Set
    End Property

    Private _codprov As Integer
    Public Property CodProv() As Integer
        Get
            Return _codprov
        End Get
        Set(ByVal value As Integer)
            _codprov = value
        End Set
    End Property


    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
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

    Private _detalle As List(Of DetalleEN)
    Public Property Detalle() As List(Of DetalleEN)
        Get
            Return _detalle
        End Get
        Set(ByVal value As List(Of DetalleEN))
            _detalle = value
        End Set
    End Property
End Class
