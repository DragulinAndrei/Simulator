Imports System.Data.SqlClient
Public Class frmGenerareFacturiVanzare
    Private oBll As New BLL

    Private Sub frmGenerareFacturiVanzare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstTotaluri As List(Of spTotaluri_Result)
        lstTotaluri = oBll.DateGraficPie
        bsTotalIesiri.DataSource = lstTotaluri

        Dim lstClienti As List(Of Client)
        lstClienti = oBll.ListaClienti()
        bsClienti.DataSource = lstClienti

        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim lstFacturiE As List(Of Facturi_Iesiri)
        lstFacturiE = oBll.ListaFacturiIesiri()
        bsFacturiVanzare.DataSource = lstFacturiE
        If lstFacturiE.Count = 0 Then Exit Sub
        Dim codFacturaE As Int64 = lstFacturiE(0).Cod_Factura_E
        Dim lstmaterialeIesite As List(Of Materiale_Iesite)
        lstmaterialeIesite = oBll.ListaMaterialeIesitebyCodFactura(codFacturaE)
        bsMaterialeIesite.DataSource = lstmaterialeIesite

        Dim lstTotaluri2 As List(Of spTotaluri_Result)
        lstTotaluri2 = oBll.DateGraficPie
        bsTotalIesiri.DataSource = lstTotaluri2
    End Sub

    Private Sub btnGenereazaE_Click(sender As Object, e As EventArgs) Handles btnGenereazaE.Click
        Dim ColNumere As List(Of Int64)
        ColNumere = Comune.GenerareNumereAleatoare(txtNrInceputE.Text, txtNrSfarsitE.Text, txtNrFacturiGenerateE.Text)
        Dim ColDate As List(Of Date)
        ColDate = Comune.GenerareDate(dtpDataInceputE.Value, dtpDataSfarsitE.Value, txtNrFacturiGenerateE.Text)
        Dim colSerii As List(Of String)
        colSerii = Comune.GenerareSiruri(txtNrCaractereSeriiFacturiE.Text, txtNrFacturiGenerateE.Text)

        Dim lstFacturiGenerateE As New List(Of Facturi_Iesiri)
        Dim cnn As New SqlConnection
        cnn.ConnectionString = Comune.SirConectare
        For i As Integer = 0 To txtNrFacturiGenerateE.Text - 1
            Dim Scadenta As Integer
            Dim rand As New Random
            Scadenta = rand.Next(7 - 1) + 1
            Dim DataScadenta = DateAdd(DateInterval.Day, Scadenta, ColDate(i))

            Dim facturaNouaE As New Facturi_Iesiri
            With facturaNouaE
                .NrFactura_E = ColNumere(i)
                .SerieFactura_E = colSerii(i)
                .DataFactura_E = ColDate(i)
                .DataScadenta_E = DataScadenta
                .Cod_Client = cmbClient.SelectedValue
            End With


            Dim colCantitate As List(Of Int64), colPret As List(Of Int64)
            colCantitate = Comune.GenerareNumereAleatoare(txtCantitateMinimaE.Text, txtCantitateMaximaE.Text, txtNrMarfuriVandute.Text)
            colPret = Comune.GenerareNumereAleatoare(txtPretMinimE.Text, txtPretMaximE.Text, txtNrMarfuriVandute.Text)
            Dim colIdMarfa As List(Of String)
            colIdMarfa = ExtrageIdMarfaAleator(txtNrMarfuriVandute.Text)

            Dim lstMaterialeIesite As New List(Of Materiale_Iesite)

            For j As Integer = 0 To txtNrMarfuriVandute.Text - 1

                Dim mi As New Materiale_Iesite With {
                    .Cod_Material = colIdMarfa(j),
                    .Cantitate_Iesita = colCantitate(j),
                    .Pret_Iesire = colPret(j)
                    }

                facturaNouaE.Materiale_Iesite.Add(mi)
            Next j

            lstFacturiGenerateE.Add(facturaNouaE)
        Next i
        oBll.AdaugaListaFacturiE(lstFacturiGenerateE)
        RefreshGrid()

        Try

        Catch ex As Exception
            MsgBox("Eroare:" & vbCrLf & ex.Message)

        End Try
    End Sub

    Private Function ExtrageIdMarfaAleator(NrInregistrari As Integer) As List(Of String)

        Dim colIdMarfa As New List(Of String)

        Dim colId As New List(Of String)


        colId = oBll.ListaMateriale.Select(Function(mi) mi.Cod_Material).ToList()
        colIdMarfa = Comune.AmestecareColectieSiruri(colId, NrInregistrari)
        Return colIdMarfa
    End Function

    Private Sub grdFacturiE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFacturiE.CellClick
        If e.RowIndex >= 0 Then
            Dim codFacturaESelectata As Int64
            codFacturaESelectata = grdFacturiE.Item(0, e.RowIndex).Value
            Dim lstmaterialeIesite As List(Of Materiale_Iesite)
            lstmaterialeIesite = oBll.ListaMaterialeIesitebyCodFactura(codFacturaESelectata)
            bsMaterialeIesite.DataSource = lstmaterialeIesite
        End If


    End Sub
End Class