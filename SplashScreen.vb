Public Class SplashScreen
    Private Sub getout()
        Edit.Enabled = True
        Me.Hide()
        Edit.BringToFront()
        'Edit.TopMost = True
        wires.drawAllWires()
    End Sub
    Private Sub SplashScreen_Click(sender As Object, e As EventArgs) Handles Me.Click
        getout()
    End Sub

    Private Sub SplashScreen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        getout()

    End Sub

 
    Public Sub onView()
        'My.Settings.DoNotShowSplashScreen=false:my.settings.save()
        If My.Settings.DoNotShowSplashScreen Then getout() : Exit Sub
        Me.DoNotShow.Checked = My.Settings.DoNotShowSplashScreen
        Width = Me.BackgroundImage.Width
        Height = BackgroundImage.Height
        Me.Show()
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = True

    End Sub

    Private Sub SplashScreen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        getout()

    End Sub
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        onView()
    End Sub



    Private Sub DoNotShow_CheckedChanged(sender As Object, e As EventArgs) Handles DoNotShow.CheckedChanged
        My.Settings.DoNotShowSplashScreen = DoNotShow.Checked
        My.Settings.Save()
        'Ενημέρωση της επιλογής του Edit form
        Edit.ShowSplashScreenMenu.Checked = Not My.Settings.DoNotShowSplashScreen
    End Sub
End Class