Public Class Awning_ActiveImage
    Inherits ActiveImage
    'Settings 1 = ο ΑΑ του κινητήρα που θα κινήσει την γκαραζόπορτα
    'Settings 2 = φορά περιστροφής σύμφωνα με το (motorspin.left ή right)
    'Settings 3 = ο ΑΑ του άνω τερματικού διακόπτη
    'Settings 4 = ο ΑΑ του κάτω τερματικού διακόπτη
    'Settings 5 = χρόνος κλεισίματος σε sec
    Public Const maxClosingtime = 60
    Public Const minClosingtime = 10

    Private Const awningy1 As Integer = 134
    Private Const awningy2 As Integer = 174
    Private Const awningx1 As Integer = 111
    Private Const awningx2 As Integer = 191
    Private Const awningheight = awningy2 - awningy1
    Private Const awningwidth = awningx2 - awningx1

    Private AwningTopLeft As Point = New Point(awningx1, awningy1)
    Private AwningBottomRight As Point = New Point(awningx2, awningy2)

    Private DoorMotion As Integer = 0

    Private TimeStarted As DateTime = Nothing

    Private SettingsForm As AwningSettingsForm
    Private AwningPosition As Integer = 0
    Private InitialAwningPosition As Integer = 0
    Private TopTerminalSwitchPosition As Integer = 5
    Private BottomTerminalSwitchPosition As Integer = AwningBottomRight.Y - AwningTopLeft.Y - 5
    Private WasTheMotorRunningBefore As Integer = 0
    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο

        Me.Image = My.Resources.awning0
    End Sub

    Public Overrides Sub initialization()

        Settings5 = minClosingtime
        Me.information = "Αυτή η εφαρμογή μπορεί να προσομοιώσει την λειτουργία μιας ηλεκτροκίνητης τέντας. Η συμπεριφορά της βασίζεται στην λειτουργία του κυκλώματος αυτοματισμού που έχετε υλοποιήσει. Ετοιμάστε πρώτα το κύκλωμα αυτοματισμού και στη συνέχεια κάντε δεξί κλικ και επιλέξτε το 'Τοποθέτηση και σύνδεση εξαρτημάτων στην τέντα' για να προχωρήσετε στις ρυθμίσεις της τέντας."
        nameImage()
        Me.numberOfScrews = -1
        Me.setMoveBounds()
        state = GlobalInfo.state.leitoyrgei_kanonika


        'Να σβηστούν
        ' Settings5 = 20
        ' Settings1 = 12
        ' Settings2 = GlobalInfo.state.motor_left
        'Settings3 = 17
        'Settings4 = 16

    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
    End Sub
    Public Overrides Function whatami() As String
        Return "AWNING"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Τέντα"
    End Function
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Me.Image = My.Resources.awning0


        'Έλεγχος για κίνηση γκαραζόπορτας
        If Settings1 > -1 And Settings1 < maxActiveObjects Then
            Select Case allActiveObjects(Settings1).state
                Case GlobalInfo.state.motor_right, GlobalInfo.state.motor_left
                    If TimeStarted = Nothing Then
                        TimeStarted = Now()
                        InitialAwningPosition = AwningPosition
                    End If
                Case GlobalInfo.state.motor_not_powered
                    TimeStarted = Nothing
                    InitialAwningPosition = AwningPosition
            End Select

        End If


    End Sub

    'Άνοιγμα του παραθύρου  ρυθμίσεων του στοιχείου
    Public Overrides Sub ShowSettings()
        Dim sarwsh As Integer
        Dim s As String
        If SettingsForm Is Nothing Then SettingsForm = New AwningSettingsForm()

        'Καθαρισμός των λιστών
        SettingsForm.TopTerminalList.Items.Clear()
        SettingsForm.BottomTerminalList.Items.Clear()

        SettingsForm.MotorList.Items.Clear()

        'Συμπλήρωση των λιστών
        For sarwsh = 0 To numberOfActiveObjects - 1
            s = Trim(sarwsh.ToString()) + ") " + allActiveObjects(sarwsh).WhatAmIGreek
            Select Case allActiveObjects(sarwsh).WhatAmI
                Case "3PHASE MOTOR D", "3PHASE MOTOR Y", "3PHASE MOTOR", "1PHASE MOTOR"
                    SettingsForm.MotorList.Items.Add(s)
                Case "LIMIT SWITCH", "PHOTOELECTRIC SENSOR"
                    SettingsForm.TopTerminalList.Items.Add(s)
                    SettingsForm.BottomTerminalList.Items.Add(s)
                Case "LIGHT SENSOR"
                    SettingsForm.LightSensorList.Items.Add(s)
                Case "WIND SENSOR"
                    SettingsForm.WindSensorList.Items.Add(s)
                Case "RAIN SENSOR"
                    SettingsForm.RainSensorList.Items.Add(s)

            End Select
        Next

        'Βάζω τον κατάλληλο τίτλο στο πλήκτρο σχετικά με την φορά περιστροφής του κινητήρα σύμφωνα με το Settings 2
        If Settings2 = GlobalInfo.state.motor_left Then SettingsForm.MotorSpinDirection.Text = motorspintext(0) Else Settings2 = GlobalInfo.state.motor_right : SettingsForm.MotorSpinDirection.Text = motorspintext(1)

        'Τώρα υπογραμμίζω τις τρέχουσες επιλογές επάνω στα listbox
        For sarwsh = 0 To SettingsForm.MotorList.Items.Count - 1
            If Settings1 = Val(SettingsForm.MotorList.Items(sarwsh).ToString) Then SettingsForm.MotorList.SelectedIndex = sarwsh
        Next

        For sarwsh = 0 To SettingsForm.TopTerminalList.Items.Count - 1
            If Settings3 = Val(SettingsForm.TopTerminalList.Items(sarwsh).ToString) Then SettingsForm.TopTerminalList.SelectedIndex = sarwsh
        Next

        For sarwsh = 0 To SettingsForm.BottomTerminalList.Items.Count - 1
            If Settings4 = Val(SettingsForm.BottomTerminalList.Items(sarwsh).ToString) Then SettingsForm.BottomTerminalList.SelectedIndex = sarwsh
        Next

        For sarwsh = 0 To SettingsForm.LightSensorList.Items.Count - 1
            If Settings6 = Val(SettingsForm.LightSensorList.Items(sarwsh).ToString) Then SettingsForm.LightSensorList.SelectedIndex = sarwsh
        Next

        For sarwsh = 0 To SettingsForm.WindSensorList.Items.Count - 1
            If Settings7 = Val(SettingsForm.WindSensorList.Items(sarwsh).ToString) Then SettingsForm.WindSensorList.SelectedIndex = sarwsh
        Next

        For sarwsh = 0 To SettingsForm.RainSensorList.Items.Count - 1
            If Settings8 = Val(SettingsForm.RainSensorList.Items(sarwsh).ToString) Then SettingsForm.RainSensorList.SelectedIndex = sarwsh
        Next

        If Settings5 < minClosingtime Then Settings5 = minClosingtime
        If Settings5 > maxClosingtime Then Settings5 = maxClosingtime
        SettingsForm.Closingtime.Maximum = maxClosingtime
        SettingsForm.Closingtime.Minimum = minClosingtime
        SettingsForm.Closingtime.Value = Settings5


        SettingsForm.showMe(Me)


    End Sub


    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)

        Dim mybrush As New SolidBrush(Color.Gray)
        'Αν λειτουργεί ο κινητήρας θα πρέπει να υπολογίσω τον χρόνο που λειτουργεί
        Dim Span As TimeSpan = Now() - TimeStarted
        Dim pros As Integer = 1
        Dim Secs As Long

        'Επειδή δεν θέλω να τρέχουν τα παρακάτω στο Edit. Του λέω αν το Simulator δεν φαίνεται τότε -> έξοδος
        If Simulator.Visible = False Then Exit Sub

        If TimeStarted = Nothing Then Secs = 0 : WasTheMotorRunningBefore = 0 Else Secs = Span.TotalSeconds

        'Αν ο χρόνος που έχει περάσει είναι μεγαλύτερος του μέγιστου τότε απλά κάνω τον υπολογισμό με τον μέγιστο
        If Secs > Settings5 Then Secs = Settings5
        If Secs < 0 Then Secs = 0

        'If Secs < 0 Then Exit Sub


        'Οι συντεταγμένες εδώ είναι σε σχέση με την αρχή του αντικειμένου και όχι της φόρμας

        Dim TotalHeightis As Integer = AwningBottomRight.Y - AwningTopLeft.Y


        'Εδώ θα δούμε αν η κίνηση πρέπει να ανεβάζει ή να κατεβάζει την γκαραζόπορτα
        '        Debug.Print("S2 " + Settings2.ToString + " motorspin left=" + motorspin.left)
        If Settings1 > -1 And Settings1 < maxActiveObjects Then
            If allActiveObjects(Settings1).state = Settings2 Then pros = 1 Else pros = -1
        End If




        AwningPosition = InitialAwningPosition + pros * TotalHeightis * (Secs / Settings5)

        'Αν βρισκόμαστε στα άκρα
        If (AwningPosition >= TotalHeightis) Or (AwningPosition <= 0) Then
            'Και ο κινητήρας δουλεύει
            If Not (TimeStarted = Nothing) Then
                If WasTheMotorRunningBefore > 3 Then allActiveObjects(Settings1).ThrowConnectionError("Η γκαραζόπορτα έφτασε στο τέρμα και ο κινητήρας δεν σταματά - Υπερθέρμανση κινητήρα.")
                WasTheMotorRunningBefore = WasTheMotorRunningBefore + 1
            End If
        End If

        If AwningPosition > TotalHeightis Then AwningPosition = TotalHeightis
        If AwningPosition < 0 Then AwningPosition = 0


        'If Not (TimeStarted = Nothing) And (AwningPosition = 0 Or AwningPosition = TotalHeightis) Then ThrowConnectionError(5, "Υπερθέρμανση κινητήρα") : MsgBox("thrown")


        Dim presound As Boolean = soundon

        soundon = False

        'Ενεργοποίηση άνω τερματικού διακόπτη
        If Settings3 > 0 And Settings3 < numberOfActiveObjects Then
            If AwningPosition >= TopTerminalSwitchPosition Then allActiveObjects(Settings3).changestate(GlobalInfo.state.energo) Else allActiveObjects(Settings3).changestate(GlobalInfo.state.anenergo)
        End If

        'Ενεργοποίηση άνω τερματικού διακόπτη
        If Settings4 > 0 And Settings4 < numberOfActiveObjects Then
            If AwningPosition >= BottomTerminalSwitchPosition Then allActiveObjects(Settings4).changestate(GlobalInfo.state.energo) Else allActiveObjects(Settings4).changestate(GlobalInfo.state.anenergo)
        End If

        soundon = presound


        'If AwningPosition > TopTerminalSwitchPosition Then


        Dim pos2 = New Point(AwningTopLeft.X, AwningTopLeft.Y + AwningPosition)

        'Μεταφορά σε απόλυτες συντεταγμένες
        Dim p1 = New Point((AwningTopLeft.X + Me.Location.X) * ratio, (AwningTopLeft.Y + Me.Location.Y) * ratio)
        Dim p2 = New Point((AwningBottomRight.X + Me.Location.X) * ratio, (pos2.Y + Me.Location.Y) * ratio)


        'Dim pos2 = New Point((Me.Location.X + 148 + offset) * ratio, (Me.Location.Y + 107) * ratio)
        Dim rect As New Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y)
        gr.DrawImage(My.Resources.awningtop, rect)
        gr.DrawImage(My.Resources.awningbottom, p1.X, p2.Y, My.Resources.awningbottom.Width * ratio, My.Resources.awningbottom.Height * ratio)

        Dim topleftpoint As Point = New Point(Me.Location.X * ratio, Me.Location.Y * ratio)
        'Ζωγράφια ήλιου - αέρα - βροχής
        'Ήλιος - Σκοτάδι
        If Settings6 > 0 And Settings6 < numberOfActiveObjects Then
            'Ήλιος
            If allActiveObjects(Settings6).state = GlobalInfo.state.energo Then gr.DrawImage(My.Resources.Awning_sun, topleftpoint) Else gr.DrawImage(My.Resources.Awning_moon, topleftpoint)
        End If

        'Αέρας
        If Settings7 > 0 And Settings7 < numberOfActiveObjects Then
            If allActiveObjects(Settings7).state = GlobalInfo.state.energo Then gr.DrawImage(My.Resources.Awning_wind, topleftpoint)
        End If

        'βροχή
        If Settings8 > 0 And Settings8 < numberOfActiveObjects Then
            If allActiveObjects(Settings8).state = GlobalInfo.state.energo Then gr.DrawImage(My.Resources.Awning_rain, topleftpoint)
        End If



        'gr.FillRectangle(mybrush, New Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y))

        'Edit.Text = "state =" + allActiveObjects(Settings1).state.ToString + " global left=" + GlobalInfo.state.motor_left.ToString  'InitialAwningPosition.ToString + " " + AwningPosition.ToString + " pros=" + pros.ToString + " state = " + allActiveObjects(Settings1).state.ToString + " Settings2=" + Settings2.ToString + "  Settings3=" + Settings3.ToString + " Settings4=" + Settings4.ToString
    End Sub


    'Θα χρησιμοποιηθεί από το PLC για να επαναφέρει (Reset) τις ρυθμίσεις των χρονικών και των απαριθμητών
    Public Overrides Sub reset_all_parameters()
        AwningPosition = 0
        TimeStarted = Nothing
    End Sub

End Class
