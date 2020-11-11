
Public Class BitacoraEN
    Private _codbit As Integer
    Public Property CodBit() As Integer
        Get
            Return _codbit
        End Get
        Set(ByVal value As Integer)
            _codbit = value
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

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _criticidad As String
    Public Property Criticidad() As String
        Get
            Return _criticidad
        End Get
        Set(ByVal value As String)
            _criticidad = value
        End Set
    End Property

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
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
