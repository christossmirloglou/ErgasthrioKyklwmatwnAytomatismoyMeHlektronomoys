Public Class WaterTankSettings

    Private WhoCalledMe As ActiveImage

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles DiscardAndExit.Click
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
        ToolTip1.SetToolTip(Label1, addNewLine(My.Resources.WaterTank_FloatTop_tooltip))
        ToolTip1.SetToolTip(TopTerminalList, addNewLine(My.Resources.WaterTank_FloatTop_tooltip))
        ToolTip1.SetToolTip(ClearTopTerm, addNewLine(My.Resources.WaterTank_FloatTop_tooltip))

        ToolTip1.SetToolTip(Label2, addNewLine(My.Resources.WaterTank_FloatBot_tooltip))
        ToolTip1.SetToolTip(BottomTerminalList, addNewLine(My.Resources.WaterTank_FloatBot_tooltip))
        ToolTip1.SetToolTip(ClearBottomTerm, addNewLine(My.Resources.WaterTank_FloatBot_tooltip))

        ToolTip1.SetToolTip(Label3, addNewLine(My.Resources.WaterTank_Motor_Tooltip))
        ToolTip1.SetToolTip(MotorList, addNewLine(My.Resources.WaterTank_Motor_Tooltip))
        ToolTip1.SetToolTip(ClearMotor, addNewLine(My.Resources.WaterTank_Motor_Tooltip))


        ToolTip1.SetToolTip(SaveAndExit, addNewLine(My.Resources.WaterTank_SaveAndExit_ToolTip))
        ToolTip1.SetToolTip(DiscardAndExit, addNewLine(My.Resources.WaterTank_DiscardAndExit_Tooltip))
        ToolTip1.SetToolTip(Help, addNewLine(My.Resources.WaterTank_Help_ToolTip))
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ClearMotor.Click
        MotorList.SelectedIndex = -1
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        MsgBox(addNewLine(My.Resources.WaterTank_Help), vbOKOnly)

    End Sub
End Class
