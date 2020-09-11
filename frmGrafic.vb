Imports SimulatorLicenta
Public Class frmGrafic
    Dim oBLL As New BLL

    Private Sub frmGrafic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SursaGraficFacurate As List(Of SPSursaGraficFacturate_Result)

        SursaGraficFacurate = oBLL.DateGraficFacturate()
        bsGraficFacturate.DataSource = SursaGraficFacurate

        Dim SursaGraficIesite As List(Of spSursaGraficIesite_Result)

        SursaGraficIesite = oBLL.DateGraficIesite()
        bsGraficIesite.DataSource = SursaGraficIesite

        Dim SursaGraficDiferente As List(Of SPSursaGraficDiferenta_Result)

        SursaGraficDiferente = oBLL.DateGraficDiferente()
        bsGraficDiferente.DataSource = SursaGraficDiferente

        Dim DatePentruGraficTotaluri As List(Of spTotaluri_Result)

        DatePentruGraficTotaluri = oBLL.DateGraficPie()
        bsGraficTotaluri.DataSource = DatePentruGraficTotaluri

    End Sub

    Private Sub btnIncarcaGrafic_Click(sender As Object, e As EventArgs) Handles btnIncarcaGrafic.Click
        Dim datafact As Date = dtpPrimaData.Value
        Dim datasfct As Date = dtpUltimaData.Value
        Dim SursaGraficFacurate2 As List(Of SPSursaGraficFacturateIntreDouaDate_Result)

        SursaGraficFacurate2 = oBLL.DateGraficFacturateIntreDouaDate(datafact, datasfct)
        bsGraficFacturate.DataSource = SursaGraficFacurate2

        Dim SursaGraficIesite2 As List(Of spSursaGraficIesiteIntreDouaDate_Result)

        SursaGraficIesite2 = oBLL.DateGraficIesiteIntreDouaDate(datafact, datasfct)
        bsGraficIesite.DataSource = SursaGraficIesite2

        Dim SursaGraficDiferente2 As List(Of SPSursaGraficDiferentaIntreDouaDate_Result)

        SursaGraficDiferente2 = oBLL.DateGraficDiferenteIntreDouaDate(datafact, datasfct)
        bsGraficDiferente.DataSource = SursaGraficDiferente2

        Dim DatePentruGraficTotaluri2 As List(Of spTotaluriIntreDouaDate_Result)

        DatePentruGraficTotaluri2 = oBLL.DateGraficPieIntreDouaDate(datafact, datasfct)
        bsGraficTotaluri.DataSource = DatePentruGraficTotaluri2

        GraficFacturate.DataBind()
        GraficIesite.DataBind()
        GraficDiferente.DataBind()
        GraficTotaluri.DataBind()

    End Sub


End Class