
Public Class NVRemitoEN
    Private _codremito As Integer
    Public Property CodRemito() As Integer
        Get
            Return _codremito
        End Get
        Set(ByVal value As Integer)
            _codremito = value
        End Set
    End Property

    Private _codnot As Integer
    Public Property CodNot() As Integer
        Get
            Return _codnot
        End Get
        Set(ByVal value As Integer)
            _codnot = value
        End Set
    End Property

    Private _nroremito As Integer
    Public Property NroRemito() As Integer
        Get
            Return _nroremito
        End Get
        Set(ByVal value As Integer)
            _nroremito = value
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
