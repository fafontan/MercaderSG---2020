
Public Class IdiomaEN
    Private _codidioma As Integer
    Public Property CodIdioma() As Integer
        Get
            Return _codidioma
        End Get
        Set(ByVal value As Integer)
            _codidioma = value
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
