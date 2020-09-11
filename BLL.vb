Public Class BLL
    Private bd As SimulatorEntities1

    Public Sub New()
        bd = New SimulatorEntities1

    End Sub

#Region "Intrari"
    Public Function ListaFacturiIntrari() As List(Of Facturi_Intrari)
        Dim rezultat As List(Of Facturi_Intrari)

        rezultat = bd.Facturi_Intrari.ToList()
        Return rezultat
    End Function

    Public Function ListaMaterialeFacturatebyCodFactura(codFactura As Int64) As List(Of Materiale_Facturate)
        Return bd.Materiale_Facturate.Where(Function(mf) mf.Cod_Factura_I = codFactura).ToList()
    End Function
    Public Function ListaMateriale() As List(Of Materiale)
        Return bd.Materiale.ToList()
    End Function

    Public Function ListaFurnizori() As List(Of Furnizor)
        Return bd.Furnizor.ToList()
    End Function

    Public Sub AdaugaFacturaIntegral(factura As Facturi_Intrari)
        bd.Facturi_Intrari.Add(factura)
        bd.SaveChanges()
    End Sub

    Public Sub AdaugaListaFacturi(lstFacturi As List(Of Facturi_Intrari))
        bd.Facturi_Intrari.AddRange(lstFacturi)
        bd.SaveChanges()
    End Sub

#End Region

#Region "Iesiri"
    Public Function ListaFacturiIesiri() As List(Of Facturi_Iesiri)
        Dim rezultat As List(Of Facturi_Iesiri)
        rezultat = bd.Facturi_Iesiri.ToList()
        Return rezultat
    End Function

    Public Function ListaMaterialeIesitebyCodFactura(codFacturaE As Int64) As List(Of Materiale_Iesite)
        Return bd.Materiale_Iesite.Where(Function(mi) mi.Cod_Factura_E = codFacturaE).ToList()
    End Function

    Public Function ListaMaterialeE() As List(Of Materiale)
        Return bd.Materiale.ToList()
    End Function

    Public Function ListaClienti() As List(Of Client)
        Return bd.Client.ToList()
    End Function

    Public Sub AdaugaFacturaIntegralE(facturaE As Facturi_Iesiri)
        bd.Facturi_Iesiri.Add(facturaE)
        bd.SaveChanges()
    End Sub

    Public Sub AdaugaListaFacturiE(lstFacturiE As List(Of Facturi_Iesiri))
        bd.Facturi_Iesiri.AddRange(lstFacturiE)
        bd.SaveChanges()
    End Sub


#End Region

    Public Function DateGraficFacturate() As List(Of SPSursaGraficFacturate_Result)
        Return bd.SPSursaGraficFacturate().ToList()
    End Function

    Public Function DateGraficDiferente() As List(Of SPSursaGraficDiferenta_Result)
        Return bd.SPSursaGraficDiferenta().ToList()
    End Function

    Public Function DateGraficIesite() As List(Of spSursaGraficIesite_Result)
        Return bd.spSursaGraficIesite().ToList()
    End Function

    Public Function DateGraficPie() As List(Of spTotaluri_Result)
        Return bd.spTotaluri().ToList()

    End Function


    Public Function VerificareAutentificare(username As String, password As String) As Boolean
        Dim rezultat As Boolean
        rezultat = bd.Utilizatori.Any(Function(u) u.UserName = username And u.Password = password)
        Return rezultat

    End Function

    Public Function ExistaUserName(username As String) As Boolean
        Return bd.Utilizatori.Any(Function(u) u.UserName = username)
    End Function

    Public Function ExistaPassword(password As String) As Boolean
        Return bd.Utilizatori.Any(Function(u) u.Password = password)
    End Function

    Public Function ListaRoluri() As List(Of Utilizatori)
        Dim rezultat As List(Of Utilizatori)
        rezultat = bd.Utilizatori().ToList()
        Return rezultat
    End Function

    Public Function DateGraficFacturateIntreDouaDate(DIfact As DateTime, DSfact As DateTime) As List(Of SPSursaGraficFacturateIntreDouaDate_Result)

        Return bd.SPSursaGraficFacturateIntreDouaDate(DIfact, DSfact).ToList()
    End Function

    Public Function DateGraficDiferenteIntreDouaDate(DIdif As DateTime, DSdif As DateTime) As List(Of SPSursaGraficDiferentaIntreDouaDate_Result)

        Return bd.SPSursaGraficDiferentaIntreDouaDate(DIdif, DSdif).ToList()
    End Function

    Public Function DateGraficIesiteIntreDouaDate(DIIes As DateTime, DSIes As DateTime) As List(Of spSursaGraficIesiteIntreDouaDate_Result)

        Return bd.spSursaGraficIesiteIntreDouaDate(DIIes, DSIes).ToList()
    End Function

    Public Function DateGraficPieIntreDouaDate(DIPie As DateTime, DSPie As DateTime) As List(Of spTotaluriIntreDouaDate_Result)

        Return bd.spTotaluriIntreDouaDate(DIPie, DSPie).ToList()

    End Function

End Class
