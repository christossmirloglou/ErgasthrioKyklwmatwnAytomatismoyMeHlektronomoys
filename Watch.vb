Public Class Watch


    Private Sub Watch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(PauseOnError, addNewLine(My.Resources.Watch_PauseOnError_Tooltip))
        ToolTip1.SetToolTip(PauseOnGroundingError, addNewLine(My.Resources.Watch_PauseOnGroundingError_Tooltip))
        ToolTip1.SetToolTip(showinfo, addNewLine(My.Resources.Watch_ShowUserNameInfo_Tooltip))
        ToolTip1.SetToolTip(showkeys, addNewLine(My.Resources.Watch_ShowKeys_tooltip))
        ToolTip1.SetToolTip(Show_Voltage, addNewLine(My.Resources.Watch_ShowVoltage_ToolTip))
        ToolTip1.SetToolTip(Keys, addNewLine(My.Resources.Watch_Katastash_Tooltip))
        ToolTip1.SetToolTip(Label3, addNewLine(My.Resources.Watch_Katastash_Tooltip))
        ToolTip1.SetToolTip(Label1, addNewLine(My.Resources.Watch_Info_ToolTip))
        ToolTip1.SetToolTip(information, addNewLine(My.Resources.Watch_Info_ToolTip))



    End Sub

    Private Sub LineShape1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Keys_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Keys.MouseDoubleClick
        Dim c() As Char
        c = Keys.Text.ToCharArray
        If c.Length > 16 Then
            If c(0) = " " Then Simulator.A_Key_Was_Pressed(c(15))
        End If

    End Sub


    Private Sub Watch_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Height > information.Location.Y + 52 Then
            information.Height = Me.Height - information.Location.Y - 50

        End If
    End Sub

    Private Sub PauseOnError_CheckedChanged(sender As Object, e As EventArgs) Handles PauseOnError.CheckedChanged
        Stop_Simulation_On_Error = PauseOnError.Checked
    End Sub

    Private Sub PauseOnGroundingError_CheckedChanged(sender As Object, e As EventArgs) Handles PauseOnGroundingError.CheckedChanged
        Stop_Simulation_On_Grounding_Error = PauseOnGroundingError.Checked
    End Sub

   
    Private Sub showinfo_CheckedChanged(sender As Object, e As EventArgs) Handles showinfo.CheckedChanged
        If Not Me.Visible Then Exit Sub
        show_info_during_simulation = showinfo.Checked
        If Not Simulator.is_Simulation_Running Then Simulator.draw_everything()
    End Sub

    Private Sub showkeys_CheckedChanged(sender As Object, e As EventArgs) Handles showkeys.CheckedChanged
        If Not Me.Visible Then Exit Sub
        show_keys_during_simulation = showkeys.Checked
        If Not Simulator.is_Simulation_Running Then Simulator.draw_everything()
    End Sub

    Private Sub Show_Voltage_CheckedChanged(sender As Object, e As EventArgs) Handles Show_Voltage.CheckedChanged
        If Not Me.Visible Then Exit Sub
        Show_Voltage_During_Simulation = Show_Voltage.Checked
        If Not Simulator.is_Simulation_Running Then Simulator.draw_everything()

    End Sub

    Private Sub Keys_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Keys.SelectedIndexChanged

    End Sub
End Class