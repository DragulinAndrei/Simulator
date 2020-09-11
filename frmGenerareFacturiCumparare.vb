Imports System.Data.SqlClient
Public Class frmGenerareFacturiCumparare
    Private oBll As New BLL

    Private Sub frmGenerareFacturiCumparare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstTotaluri As List(Of spTotaluri_Result)
        lstTotaluri = oBll.DateGraficPie
        bsTotalIntrari.DataSource = lstTotaluri

        Dim lstFurnizori As List(Of Furnizor)
        lstFurnizori = oBll.ListaFurnizori()
        bsFurnizori.DataSource = lstFurnizori

        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Dim lstFacturi As List(Of Facturi_Intrari)
        lstFacturi = oBll.ListaFacturiIntrari()
        bsFacturiCumparare.DataSource = lstFacturi
        If lstFacturi.Count = 0 Then Exit Sub
        Dim codFactura As Int64 = lstFacturi(0).Cod_Factura_I 'citesc codul primei facturi din lista
        Dim lstmaterialeFacturate As List(Of Materiale_Facturate)
        lstmaterialeFacturate = oBll.ListaMaterialeFacturatebyCodFactura(codFactura)
        bsMaterialeFacturate.DataSource = lstmaterialeFacturate

        Dim lstTotaluri2 As List(Of spTotaluri_Result)
        lstTotaluri2 = oBll.DateGraficPie
        bsTotalIntrari.DataSource = lstTotaluri2
    End Sub
    Private Sub btnGenereaza_Click(sender As Object, e As EventArgs) Handles btnGenereaza.Click
        Dim ColNumere As List(Of Int64)
        ColNumere = Comune.GenerareNumereAleatoare(txtNrInceput.Text, txtNrSfarsit.Text, txtNrFacturiGenerate.Text)
        Dim ColDate As List(Of Date)
        ColDate = Comune.GenerareDate(dtpDataInceput.Value, dtpDataSfarsit.Value, txtNrFacturiGenerate.Text)
        Dim colSerii As List(Of String)
        colSerii = Comune.GenerareSiruri(txtNrCaractereSerie.Text, txtNrFacturiGenerate.Text)

        Dim lstFacturiGenerate As New List(Of Facturi_Intrari)
        Dim cnn As New SqlConnection 'o noua conexiune la baza de date sqlserver
        cnn.ConnectionString = Comune.SirConectare 'stabilesc sirul de conectare pentru baza de date
        For i As Integer = 0 To txtNrFacturiGenerate.Text - 1 'generez numarul de facturi specificat in formular
            Dim Scadenta As Integer
            Dim rand As New Random
            Scadenta = rand.Next(7 - 1) + 1 'aici generez un numar aleator de zile de scadenta (intre 1 si 7 zile)
            Dim DataScadenta = DateAdd(DateInterval.Day, Scadenta, ColDate(i))

            Dim facturaNoua As New Facturi_Intrari
            With facturaNoua
                .NrFactura = ColNumere(i)
                .SerieFactura = colSerii(i)
                .DataFactura = ColDate(i)
                .DataScadenta = DataScadenta
                .Cod_Furnizor = cmbFurnizor.SelectedValue
            End With

            'incarc date despre materialele facturate din aceasta factura
            '======================================================

            Dim colCantitate As List(Of Int64), colPret As List(Of Int64)
            colCantitate = Comune.GenerareNumereAleatoare(txtCantitateMinima.Text, txtCantitateMaxima.Text, txtNrMarfuriCumparate.Text)
            colPret = Comune.GenerareNumereAleatoare(txtPretMinim.Text, txtPretMaxim.Text, txtNrMarfuriCumparate.Text)
            Dim colIdMarfa As List(Of String)
            colIdMarfa = ExtrageIdMarfaAleator(txtNrMarfuriCumparate.Text)

            Dim lstMaterialeFacturate As New List(Of Materiale_Facturate)

            For j As Integer = 0 To txtNrMarfuriCumparate.Text - 1 'pentru fiecare factura se va genera numarul de marfuri cumparate specificat in formular
                'definesc un nou material facturat pe care il incarc cu date generate aleator si apoi il incarc in lista de materiale facturate
                Dim mf As New Materiale_Facturate With {
                    .Cod_Material = colIdMarfa(j),
                    .Cantitate_Facturata = colCantitate(j),
                    .Pret_Facturare = colPret(j)
                    }
                'adaug acest nou material generat in factura curenta
                facturaNoua.Materiale_Facturate.Add(mf)
            Next j
            'acum adaug factura cu toate produsele generate in cadrul ei in lista de facturi care urmeaza a se salva in baza de date
            lstFacturiGenerate.Add(facturaNoua)
        Next i
        oBll.AdaugaListaFacturi(lstFacturiGenerate)
        RefreshGrid()

        Try

        Catch ex As Exception
            MsgBox("Eroare:" & vbCrLf & ex.Message)

        End Try
    End Sub

    Private Function ExtrageIdMarfaAleator(NrInregistrari As Integer) As List(Of String)
        'functie care extrage un numar precizat de id-uri de marfa incarcate intr-o colectie de numere intregi folosita pentru generarea de inregistrari in tabela MarfuriCumparate (campul cheie externa IdMarfa)
        Dim colIdMarfa As New List(Of String)

        Dim colId As New List(Of String)
        'For Each r As Dataset1.MarfuriRow In dt.Rows
        '    'adaug la colectie id-ul marfii selectate
        '    colId.Add(r.IdMarfa)
        'Next
        colId = oBll.ListaMateriale.Select(Function(mf) mf.Cod_Material).ToList()
        colIdMarfa = Comune.AmestecareColectieSiruri(colId, NrInregistrari)
        Return colIdMarfa
    End Function

    Private Sub grdFacturi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFacturi.CellClick
        If e.RowIndex >= 0 Then
            Dim codFacturaSelectata As Int64
            codFacturaSelectata = grdFacturi.Item(0, e.RowIndex).Value
            Dim lstmaterialeFacturate As List(Of Materiale_Facturate)
            lstmaterialeFacturate = oBll.ListaMaterialeFacturatebyCodFactura(codFacturaSelectata)
            bsMaterialeFacturate.DataSource = lstmaterialeFacturate
        End If


    End Sub


End Class