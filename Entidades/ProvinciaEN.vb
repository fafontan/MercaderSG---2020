
Public Class ProvinciaEN
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

End Class
