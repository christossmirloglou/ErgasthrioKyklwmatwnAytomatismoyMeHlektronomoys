Public Class AwningSettingsForm


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
        WhoCalledMe.Settings6 = ReturnValue(LightSensorList)
        WhoCalledMe.Settings7 = ReturnValue(WindSensorList)
        WhoCalledMe.Settings8 = ReturnValue(RainSensorList)


        Me.Hide()
    End Sub

    Private Sub AwningSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(Label1, addNewLine(My.Resources.Awning_TermTop_Tooltip))
        ToolTip1.SetToolTip(TopTerminalList, addNewLine(My.Resources.Awning_TermTop_Tooltip))
        ToolTip1.SetToolTip(ClearTopTerm, addNewLine(My.Resources.Awning_TermTop_Tooltip))

        ToolTip1.SetToolTip(Label10, addNewLine(My.Resources.Awning_LightSensorList_Tooltip))
        ToolTip1.SetToolTip(LightSensorList, addNewLine(My.Resources.Awning_LightSensorList_Tooltip))
        ToolTip1.SetToolTip(ClearLightSensor, addNewLine(My.Resources.Awning_LightSensorList_Tooltip))

        ToolTip1.SetToolTip(Label11, addNewLine(My.Resources.Awning_WindSensorList_Tooltip))
        ToolTip1.SetToolTip(WindSensorList, addNewLine(My.Resources.Awning_WindSensorList_Tooltip))
        ToolTip1.SetToolTip(ClearWindSensor, addNewLine(My.Resources.Awning_WindSensorList_Tooltip))

        ToolTip1.SetToolTip(Label12, addNewLine(My.Resources.Awning_RainSensorList_Tooltip))
        ToolTip1.SetToolTip(RainSensorList, addNewLine(My.Resources.Awning_RainSensorList_Tooltip))
        ToolTip1.SetToolTip(ClearRainSensor, addNewLine(My.Resources.Awning_RainSensorList_Tooltip))


        ToolTip1.SetToolTip(Label2, addNewLine(My.Resources.Awning_TermBot_Tooltip))
        ToolTip1.SetToolTip(BottomTerminalList, addNewLine(My.Resources.Awning_TermBot_Tooltip))
        ToolTip1.SetToolTip(ClearBottomTerm, addNewLine(My.Resources.Awning_TermBot_Tooltip))

        ToolTip1.SetToolTip(Label3, addNewLine(My.Resources.Awning_Motor_Tooltip))
        ToolTip1.SetToolTip(MotorList, addNewLine(My.Resources.Awning_Motor_Tooltip))
        ToolTip1.SetToolTip(ClearMotor, addNewLine(My.Resources.Awning_Motor_Tooltip))

        ToolTip1.SetToolTip(GroupBox1, addNewLine(My.Resources.Awning_MotorSpin_Tooltip))
        ToolTip1.SetToolTip(MotorSpinDirection, addNewLine(My.Resources.Awning_MotorSpin_Tooltip))

        ToolTip1.SetToolTip(GroupBox2, addNewLine(My.Resources.Awning_Time_Tooltip))
        ToolTip1.SetToolTip(Closingtime, addNewLine(My.Resources.Awning_Time_Tooltip))

        ToolTip1.SetToolTip(SaveAndExit, addNewLine(My.Resources.awning_SaveAndExit_Tooltip))
        ToolTip1.SetToolTip(DiscardAndExit, addNewLine(My.Resources.Awning_DiscardChangesAndExit_tooltip))
        ToolTip1.SetToolTip(help, addNewLine(My.Resources.Awning_Help_Tooltip))
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

    Private Sub help_Click(sender As Object, e As EventArgs) Handles help.Click
        MsgBox(addNewLine(My.Resources.Awning_Help), vbOKOnly)
    End Sub

    Private Sub ClearLightSensor_Click(sender As Object, e As EventArgs) Handles ClearLightSensor.Click
        LightSensorList.SelectedIndex = -1
    End Sub

    Private Sub WindSensorList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WindSensorList.SelectedIndexChanged

    End Sub

    Private Sub ClearWindSensor_Click(sender As Object, e As EventArgs) Handles ClearWindSensor.Click
        WindSensorList.SelectedIndex = -1
    End Sub

    Private Sub ClearRainSensor_Click(sender As Object, e As EventArgs) Handles ClearRainSensor.Click
        RainSensorList.SelectedIndex = -1
    End Sub
End Class