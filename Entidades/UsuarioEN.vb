
Public Class UsuarioEN
    Private _codusu As Integer
    Public Property CodUsu() As Integer
        Get
            Return _codusu
        End Get
        Set(ByVal value As Integer)
            _codusu = value
        End Set
    End Property

    Private _codidioma As Integer
    Public Property CodIdioma() As Integer
        Get
            Return _codidioma
        End Get
        Set(ByVal value As Integer)
            _codidioma = value
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

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _correo As String
    Public Property Correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property


    Private _correoelectronico As String
    Public Property CorreoElectronico() As String
        Get
            Return _correoelectronico
        End Get
        Set(ByVal value As String)
            _correoelectronico = value
        End Set
    End Property


    Private _fechanacimiento As Date
    Public Property FechaNacimiento() As Date
        Get
            Return _fechanacimiento
        End Get
        Set(ByVal value As Date)
            _fechanacimiento = value
        End Set
    End Property

    Private _edad As Integer
    Public Property Edad() As Integer
        Get
            Return _edad
        End Get
        Set(ByVal value As Integer)
            _edad = value
        End Set
    End Property


    Private _cii As Integer
    Public Property CII() As Integer
        Get
            Return _cii
        End Get
        Set(ByVal value As Integer)
            _cii = value
        End Set
    End Property

    Private _activo As Boolean
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Private _bloqueado As Boolean
    Public Property Bloqueado() As Boolean
        Get
            Return _bloqueado
        End Get
        Set(ByVal value As Boolean)
            _bloqueado = value
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

    Private _telefono As List(Of TelefonoEN)
    Public Property Telefono() As List(Of TelefonoEN)
        Get
            Return _telefono
        End Get
        Set(ByVal value As List(Of TelefonoEN))
            _telefono = value
        End Set
    End Property

    Private _usufamL As List(Of UsuFamEN)
    Public Property UsuFamL() As List(Of UsuFamEN)
        Get
            Return _usufamL
        End Get
        Set(ByVal value As List(Of UsuFamEN))
            _usufamL = value
        End Set
    End Property

    Private _usupatL As List(Of PatUsuEN)
    Public Property UsuPatL() As List(Of PatUsuEN)
        Get
            Return _usupatL
        End Get
        Set(ByVal value As List(Of PatUsuEN))
            _usupatL = value
        End Set
    End Property

    Private _tipoaccion As Boolean
    Public Property TipoAccion() As Boolean
        Get
            Return _tipoaccion
        End Get
        Set(ByVal value As Boolean)
            _tipoaccion = value
        End Set
    End Property

End Class
