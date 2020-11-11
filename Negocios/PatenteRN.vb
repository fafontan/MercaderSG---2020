Imports Entidades
Imports Datos
Imports Excepciones
Imports Servicios

Public Class PatenteRN

    Public Shared Function CargarPatente() As List(Of PatenteEN)
        Dim ListaPatentes As New List(Of PatenteEN)
        ListaPatentes = PatenteAD.CargarPatente()
        Return ListaPatentes
    End Function


    Public Shared Function CargarPatente(ByVal Usuario As String) As List(Of PatenteEN)
        Dim CodUsu As Integer
        Dim ListaPatente As New List(Of PatenteEN)
        Dim ListaPatenteProcesada As New List(Of PatenteEN)

        If UsuarioAD.ValidarUsuario(Usuario) > 0 Then
            CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario)

            ListaPatente = PatenteAD.CargarPatente(CodUsu)

            For Each item As PatenteEN In ListaPatente
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = item.CodPat
                UnaPatente.Descripcion = item.Descripcion

                ListaPatenteProcesada.Add(UnaPatente)
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
        End If

        Return ListaPatenteProcesada
    End Function

    Public Shared Function ObtenerPatenteUsuario(ByVal CodUsu As Integer) As DataTable
        Return PatenteAD.ObtenerPatenteUsuario(CodUsu)
    End Function

    Public Shared Function CargarPatenteUsuario(Usuario As String) As List(Of PatenteEN)
        Dim CodUsu As Integer
        Dim ListaPatente As New List(Of PatenteEN)
        Dim ListaPatenteProcesada As New List(Of PatenteEN)

        If UsuarioAD.ValidarUsuario(Usuario) > 0 Then
            CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario)

            ListaPatente = PatenteAD.CargarPatenteUsuario(CodUsu)

            For Each item As PatenteEN In ListaPatente
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = item.CodPat
                UnaPatente.Descripcion = item.Descripcion

                ListaPatenteProcesada.Add(UnaPatente)
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
        End If

        Return ListaPatenteProcesada
    End Function

    Public Shared Function CargarPatentesFamilia(Fam As String) As List(Of PatenteEN)
        Dim CodFam As Integer
        Fam = Seguridad.Encriptar(Fam)
        Dim ListaPatente As New List(Of PatenteEN)
        Dim ListaPatenteProcesada As New List(Of PatenteEN)

        If FamiliaAD.ValidarFamilia(Fam) > 0 Then
            CodFam = FamiliaAD.ObtenerIDFamilia(Fam)

            ListaPatente = PatenteAD.CargarPatentesFamilia(CodFam)

            For Each item As PatenteEN In ListaPatente
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = item.CodPat
                UnaPatente.Descripcion = item.Descripcion

                ListaPatenteProcesada.Add(UnaPatente)
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaInexistente)
        End If

        Return ListaPatenteProcesada

    End Function

    Public Shared Function CargarNoPatentesFamilia(Fam As String) As List(Of PatenteEN)

        Dim CodFam As Integer
        Fam = Seguridad.Encriptar(Fam)
        Dim ListaPatente As New List(Of PatenteEN)
        Dim ListaPatenteProcesada As New List(Of PatenteEN)

        If FamiliaAD.ValidarFamilia(Fam) > 0 Then
            CodFam = FamiliaAD.ObtenerIDFamilia(Fam)

            ListaPatente = PatenteAD.CargarNoPatentesFamilia(CodFam)

            For Each item As PatenteEN In ListaPatente
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = item.CodPat
                UnaPatente.Descripcion = item.Descripcion

                ListaPatenteProcesada.Add(UnaPatente)
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.FamiliaInexistente)
        End If

        Return ListaPatenteProcesada

    End Function

    Public Shared Function CargarPatentesDenegadasUsuario(UsuEnc As String) As List(Of PatenteEN)
        Dim CodUsu As Integer
        Dim ListaPatente As New List(Of PatenteEN)
        Dim ListaPatenteProcesada As New List(Of PatenteEN)

        If UsuarioAD.ValidarUsuario(UsuEnc) > 0 Then
            CodUsu = UsuarioAD.ObtenerIDUsuario(UsuEnc)

            ListaPatente = PatenteAD.CargarPatenteDenegadasUsuario(CodUsu)

            For Each item As PatenteEN In ListaPatente
                Dim UnaPatente As New PatenteEN
                UnaPatente.CodPat = item.CodPat
                UnaPatente.Descripcion = item.Descripcion

                ListaPatenteProcesada.Add(UnaPatente)
            Next
        Else
            Throw New WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja)
        End If

        Return ListaPatenteProcesada
    End Function

    Public Shared Function ObtenerPatentesFamilia(CodFam As Integer) As Boolean
        Return PatenteAD.ObtenerPatentesFamilia(CodFam)
    End Function


End Class ' PatenteRN