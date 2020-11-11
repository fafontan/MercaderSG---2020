Public Class DetalleEN
    Private _codnot As Integer
    Public Property CodNot() As Integer
        Get
            Return _codnot
        End Get
        Set(ByVal value As Integer)
            _codnot = value
        End Set
    End Property

    Private _codprod As Integer
    Public Property CodProd() As Integer
        Get
            Return _codprod
        End Get
        Set(ByVal value As Integer)
            _codprod = value
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


    Private _nombreproducto As String
    Public Property NombreProducto() As String
        Get
            Return _nombreproducto
        End Get
        Set(ByVal value As String)
            _nombreproducto = value
        End Set
    End Property


End Class
