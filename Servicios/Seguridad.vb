Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports Excepciones
Public Class Seguridad

    Public Shared Function Encriptar(ByVal Dato As String) As String
        Dim TextoEncriptado As Byte()
        Dim DatoEntrada As Byte() = Encoding.UTF8.GetBytes(Dato)
        Using AlgAes As New RijndaelManaged
            AlgAes.Key = Encoding.ASCII.GetBytes("{M[3]}{R(C)}{4(D)}{3[R]}{50(63)}")
            AlgAes.IV = Encoding.ASCII.GetBytes("{.[N](3){T}[VS]}")

            Using MS As New MemoryStream(DatoEntrada.Length)
                Using CS As New CryptoStream(MS, AlgAes.CreateEncryptor(AlgAes.Key, AlgAes.IV), CryptoStreamMode.Write)
                    CS.Write(DatoEntrada, 0, DatoEntrada.Length)
                End Using

                TextoEncriptado = MS.ToArray()
            End Using
        End Using
        Return Convert.ToBase64String(TextoEncriptado)
    End Function


    Public Shared Function Desencriptar(ByVal Dato As String) As String
        Dim TextoDesencriptado As String = String.Empty
            Dim DatoEntrada As Byte() = Convert.FromBase64String(Dato)
            Using AlgAes As New RijndaelManaged
                AlgAes.Key = Encoding.ASCII.GetBytes("{M[3]}{R(C)}{4(D)}{3[R]}{50(63)}")
                AlgAes.IV = Encoding.ASCII.GetBytes("{.[N](3){T}[VS]}")

                Dim MS As New MemoryStream(DatoEntrada)
                Dim CS As New CryptoStream(MS, AlgAes.CreateDecryptor(AlgAes.Key, AlgAes.IV), CryptoStreamMode.Read)
                Dim SR As New StreamReader(CS)

                TextoDesencriptado = SR.ReadToEnd()
            End Using
            Return TextoDesencriptado
    End Function


    Public Shared Function EncriptarMD5(ByVal Dato As String) As String
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim resultado As Byte()
        resultado = md5.ComputeHash(Encoding.ASCII.GetBytes(Dato))

        Dim Cadena As New StringBuilder()
        For i As Integer = 0 To resultado.Length - 1
            Cadena.Append(resultado(i).ToString("x2"))
        Next
        Return Cadena.ToString()

    End Function


End Class