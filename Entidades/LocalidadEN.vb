Public Class LocalidadEN
    Private _codloc As Integer
    Public Property CodLoc() As Integer
        Get
            Return _codloc
        End Get
        Set(ByVal value As Integer)
            _codloc = value
        End Set
    End Property

    Private _codprovincia As Integer
    Public Property CodProvincia() As Integer
        Get
            Return _codprovincia
        End Get
        Set(ByVal value As Integer)
            _codprovincia = value
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

    Private _codigopostal As String
    Public Property CodigoPostal() As String
        Get
            Return _codigopostal
        End Get
        Set(ByVal value As String)
            _codigopostal = value
        End Set
    End Property
End Class
