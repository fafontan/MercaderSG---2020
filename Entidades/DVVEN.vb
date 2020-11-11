
Public Class DVVEN

    Private _tabla As String
    Public Property Tabla() As String
        Get
            Return _tabla
        End Get
        Set(ByVal value As String)
            _tabla = value
        End Set
    End Property

    Private _coden As Integer
    Public Property CodEn() As Integer
        Get
            Return _coden
        End Get
        Set(ByVal value As Integer)
            _coden = value
        End Set
    End Property

    Private _columna As String
    Public Property Columna() As String
        Get
            Return _columna
        End Get
        Set(ByVal value As String)
            _columna = value
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

    Private _valordvhantiguo As Integer
    Public Property ValorDVHAntiguo() As Integer
        Get
            Return _valordvhantiguo
        End Get
        Set(ByVal value As Integer)
            _valordvhantiguo = value
        End Set
    End Property

    Private _tipoaccion As String
    Public Property TipoAccion() As String
        Get
            Return _tipoaccion
        End Get
        Set(ByVal value As String)
            _tipoaccion = value
        End Set
    End Property
End Class
