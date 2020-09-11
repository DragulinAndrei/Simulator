Public Class frmRaportIesiri
    Private Sub frmRaportIesiri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AndreiDragulinDataSet1.Materiale_Iesite' table. You can move, or remove it, as needed.
        Materiale_IesiteTableAdapter.Fill(AndreiDragulinDataSet1.Materiale_Iesite)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class