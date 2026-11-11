Public Class SlidingDoorSettingsForm

    Private WhoCalledMe As ActiveImage

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub

    Public Sub showMe(WhoCalled As ActiveImage)
        WhoCalledMe = WhoCalled
        Me.Show()

    End Sub

    Private Function ReturnValue(Whichone As ListBox) As Integer
        'Αν δεν έχει επιλεγεί τίποτα
        If Whichone.Text = "" Then Return -1
        Return Val(Whichone.Text)

    End Function

    Private Sub SaveAndExit_Click(sender As Object, e As EventArgs) Handles SaveAndExit.Click

        WhoCalledMe.Settings1 = ReturnValue(MotorList)
        If MotorSpinDirection.Text = motorspintext(0) Then WhoCalledMe.Settings2 = GlobalInfo.state.motor_left Else WhoCalledMe.Settings2 = GlobalInfo.state.motor_left
        WhoCalledMe.Settings3 = ReturnValue(TopTerminalList)
        WhoCalledMe.Settings4 = ReturnValue(BottomTerminalList)
        WhoCalledMe.Settings5 = Closingtime.Value

        Me.Hide()
    End Sub

    Private Sub GarageSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MotorSpinDirection_Click(sender As Object, e As EventArgs) Handles MotorSpinDirection.Click
        Select Case MotorSpinDirection.Text
            Case motorspintext(0)
                MotorSpinDirection.Text = motorspintext(1)
            Case motorspintext(1)
                MotorSpinDirection.Text = motorspintext(0)

        End Select
    End Sub


    Private Sub ClearTopTerm_Click(sender As Object, e As EventArgs) Handles ClearTopTerm.Click
        TopTerminalList.SelectedIndex = -1

    End Sub

    Private Sub ClearBottomTerm_Click(sender As Object, e As EventArgs) Handles ClearBottomTerm.Click
        BottomTerminalList.SelectedIndex = -1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MotorList.SelectedIndex = -1
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class