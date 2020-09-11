Public Class frmRaportIntrari
    Private Sub frmRaportIntrari_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AndreiDragulinDataSet2.Materiale_Facturate' table. You can move, or remove it, as needed.
        Materiale_FacturateTableAdapter.Fill(AndreiDragulinDataSet2.Materiale_Facturate)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class