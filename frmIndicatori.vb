Public Class frmIndicatori
    Dim oBll As New BLL
    Private Sub frmIndicatori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstTotaluri As List(Of spTotaluri_Result)
        lstTotaluri = oBll.DateGraficPie
        bsTarget.DataSource = lstTotaluri
    End Sub
    Private Sub btnIndicatori_Click(sender As Object, e As EventArgs) Handles btnIndicatori.Click
        Dim viteza As Decimal
        viteza = (cmbTotalIntrari.SelectedValue - cmbTotalIesiri.SelectedValue) / cmbTotalIesiri.SelectedValue
        txtViteza.Text = viteza

        Dim Durata As Decimal
        Durata = (cmbTotalIntrari.SelectedValue - cmbTotalIesiri.SelectedValue) / (cmbTotalIesiri.SelectedValue * 360)
        txtDurata.Text = Durata

        Dim TargetVz As Decimal
        TargetVz = (cmbTotalIesiri.SelectedValue / txtTargetVz.Text) * 100
        txtIndeplinitVz.Text = TargetVz

        Dim TargetAp As Decimal
        TargetAp = (cmbTotalIntrari.SelectedValue / txtTargetAp.Text) * 100
        txtIndeplinitAp.Text = TargetAp

    End Sub


End Class