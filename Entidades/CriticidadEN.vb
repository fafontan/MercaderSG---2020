Public Class CriticidadEN
    Private _codcriti As Integer
    Public Property CodCriti() As Integer
        Get
            Return _codcriti
        End Get
        Set(ByVal value As Integer)
            _codcriti = value
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
