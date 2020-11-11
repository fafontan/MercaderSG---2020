Public Class Autenticar
    Private Shared Aut As Autenticar

    Sub New()

    End Sub

    Public Shared Function Instancia() As Autenticar
        If Aut Is Nothing Then
            Aut = New Autenticar
        End If

        Return Aut
    End Function

    Private _usuariologueado As String
    Public Property UsuarioLogueado() As String
        Get
            Return _usuariologueado
        End Get
        Set(ByVal value As String)
            _usuariologueado = value
        End Set
    End Property

    Private _codusulogueado As Integer
    Public Property CodUsuLogueado() As Integer
        Get
            Return _codusulogueado
        End Get
        Set(ByVal value As Integer)
            _codusulogueado = value
        End Set
    End Property

    Private _dtpatusu As DataTable
    Public Property dtPatUsu() As DataTable
        Get
            Return _dtpatusu
        End Get
        Set(ByVal value As DataTable)
            _dtpatusu = value
        End Set
    End Property

End Class
