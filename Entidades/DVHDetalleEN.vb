Public Class DVHDetalleEN
    Private _codprod As Integer
    Public Property CodProd() As Integer
        Get
            Return _codprod
        End Get
        Set(ByVal value As Integer)
            _codprod = value
        End Set
    End Property

    Private _valordvh As Integer
    Public Property ValorDVH() As Integer
        Get
            Return _valordvh
        End Get
        Set(ByVal value As Integer)
            _valordvh = value
        End Set
    End Property


End Class
