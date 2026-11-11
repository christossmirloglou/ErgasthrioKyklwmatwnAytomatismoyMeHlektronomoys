Imports System.Deployment.Application
Public Class About

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim v As String
        If ApplicationDeployment.IsNetworkDeployed Then
            v = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Else
            v = Application.ProductVersion.ToString
        End If
        Information.Text = My.Resources.AboutText + vbNewLine + "Φάκελος εγκατάστασης: " & My.Application.Info.DirectoryPath & vbNewLine & "Έκδοση: " + v
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class