Public Class frmLogin
    Dim oBll As New BLL

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lstRoluri As List(Of Utilizatori)
        lstRoluri = oBll.ListaRoluri()
        bsRoluri.DataSource = lstRoluri

    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If oBll.ExistaUserName(txtUtilizator.Text) And oBll.ExistaPassword(txtParola.Text) And cmbRoluri.SelectedValue = "Admin" Then
            PaginaPrincipala.Show()
            Me.Hide()
        ElseIf oBll.ExistaUserName(txtUtilizator.Text) And oBll.ExistaPassword(txtParola.Text) And cmbRoluri.SelectedValue = "ManagerGeneral" Then
            PaginaPrincipala.Show()
            frmGrafic.Show()
            frmIndicatori.Show()
            Me.Hide()
        ElseIf oBll.ExistaUserName(txtUtilizator.Text) And oBll.ExistaPassword(txtParola.Text) And cmbRoluri.SelectedValue = "ManagerAprovizionare" Then
            frmGenerareFacturiCumparare.Show()
            Me.Hide()
        ElseIf oBll.ExistaUserName(txtUtilizator.Text) And oBll.ExistaPassword(txtParola.Text) And cmbRoluri.SelectedValue = "ManagerVanzare" Then
            frmGenerareFacturiVanzare.Show()
            Me.Hide()

        Else
            MsgBox("Nume Utilizator sau Parola gresite", MsgBoxStyle.Information, "Error")

        End If


    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub


End Class