Imports System.Windows.Forms

Public Class PaginaPrincipala



    Private Sub FileMenu_Click(sender As Object, e As EventArgs) Handles btnCumparare.Click
        Dim f As New frmGenerareFacturiCumparare
        f.ShowDialog()

    End Sub

    Private Sub EditMenu_Click(sender As Object, e As EventArgs) Handles btnVanzare.Click
        Dim f As New frmGenerareFacturiVanzare
        f.ShowDialog()

    End Sub

    Private Sub ViewMenu_Click(sender As Object, e As EventArgs) Handles btnGenerareGrafice.Click
        Dim f As New frmGrafic
        f.ShowDialog()

    End Sub

    Private Sub btnIesireFormular_Click(sender As Object, e As EventArgs) Handles btnIesireFormular.Click
        Me.Close()

    End Sub



    Private Sub RaportIntrariToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim f As New frmRaportIntrari
        f.ShowDialog()
    End Sub

    Private Sub RaportIesiriToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim f As New frmRaportIesiri
        f.ShowDialog()
    End Sub

    Private Sub IndicatoriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndicatoriToolStripMenuItem.Click
        Dim f As New frmIndicatori
        f.ShowDialog()
    End Sub
End Class
