Public Class Comune
    Public Shared Function GenerareNumereAleatoare(LimitaInferioara As Int64, LimitaSuperioara As Int64, NrValoriGenerate As Integer) As List(Of Int64)
        Dim colValori As New List(Of Int64)
        For i As Int64 = LimitaInferioara To LimitaSuperioara
            colValori.Add(i)
        Next
        Dim colAmestec As New List(Of Int64)
        colAmestec = colValori.OrderBy(Function(v) Guid.NewGuid()).ToList
        colAmestec = colAmestec.Take(NrValoriGenerate).ToList

        Return colAmestec
    End Function
    Public Shared Function GenerareSiruri(LungimeSir As String, NrSiruriGenerate As Integer) As List(Of String)
        Dim colStrRezultat As New List(Of String)
        For i As Integer = 1 To NrSiruriGenerate
            Dim str As String = GenerareStringAleator(LungimeSir)
            colStrRezultat.Add(str)
        Next
        Return colStrRezultat
    End Function
    Public Shared Function GenerareStringAleator(ByVal LungimeCod As Integer) As String
        Dim _CaracterePermise As String = "ABCDEFGHJKLMNOPQRSTUVWXYZ"
        Dim NrCaracterePermise As Integer = _CaracterePermise.Length
        Dim CaractereAmestecate(NrCaracterePermise - 1) As Char
        Dim _CaractereAmestecate = _CaracterePermise.ToCharArray.OrderBy(Function(t) Guid.NewGuid).ToArray
        Return Microsoft.VisualBasic.Strings.Left(New String(_CaractereAmestecate), LungimeCod)
    End Function

    Public Shared Function GenerareDate(DataInceput As Date, DataSfarsit As Date, NrDateGenerate As Integer) As List(Of Date)
        Dim colResult As New List(Of Date)
        Dim DiferentaZile As Integer = DateDiff(DateInterval.Day, DataInceput, DataSfarsit)
        Dim ColNrAleatoare As List(Of Int64) = GenerareNumereAleatoare(1, DiferentaZile, NrDateGenerate)
        For Each nr As Int64 In ColNrAleatoare
            Dim DataNoua As Date = DateAdd(DateInterval.Day, nr, DataInceput)
            colResult.Add(DataNoua.Date)
        Next
        Return colResult
    End Function

    Public Shared Function AmestecareColectie(colectie As List(Of Int64), NrElementeExtrase As Integer) As List(Of Int64)
        Dim colRezultat As New List(Of Int64)
        Dim colTemporar As New List(Of Int64)
        colTemporar = colectie.OrderBy(Function(s) Guid.NewGuid).ToList
        colRezultat = colTemporar.Take(NrElementeExtrase).ToList
        Return colRezultat
    End Function

    Public Shared Function AmestecareColectieSiruri(colectie As List(Of String), NrElementeExtrase As Integer) As List(Of String)
        Dim colRezultat As New List(Of String)
        Dim colTemporar As New List(Of String)
        colTemporar = colectie.OrderBy(Function(s) Guid.NewGuid).ToList
        colRezultat = colTemporar.Take(NrElementeExtrase).ToList
        Return colRezultat
    End Function

    Public Shared ReadOnly Property SirConectare() As String
        Get
            Return "Data Source=samsungcat\SqlExpress;Initial Catalog=Licenta;Integrated Security=True"
        End Get
    End Property

End Class
