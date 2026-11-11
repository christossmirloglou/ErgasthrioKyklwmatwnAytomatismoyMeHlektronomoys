Public Class GarageDoor_ActiveImage
    Inherits ActiveImage
    'Settings 1 = ο ΑΑ του κινητήρα που θα κινήσει την γκαραζόπορτα
    'Settings 2 = φορά περιστροφής σύμφωνα με το (motorspin.left ή right)
    'Settings 3 = ο ΑΑ του άνω τερματικού διακόπτη
    'Settings 4 = ο ΑΑ του κάτω τερματικού διακόπτη
    'Settings 5 = χρόνος κλεισίματος σε sec
    Public Const maxClosingtime = 60
    Public Const minClosingtime = 10


    Private DoorTopLeft As Point = New Point(12, 47)
    Private doorBottomRight As Point = New Point(214, 236)

    Private DoorMotion As Integer = 0

    Private TimeStarted As DateTime = Nothing

    Private SettingsForm As GarageDoorSettingsForm
    Private DoorPosition As Integer = 0
    Private InitialDoorPosition As Integer = 0
    Private TopTerminalSwitchPosition As Integer = 5
    Private BottomTerminalSwitchPosition As Integer = doorBottomRight.Y - DoorTopLeft.Y - 5
    Private WasTheMotorRunningBefore As Integer = 0
    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο

        Me.Image = My.Resources.Gkaraz
    End Sub

    Public Overrides Sub initialization()

        Settings5 = minClosingtime
        Me.information = "Αυτή η εφαρμογή μπορεί να προσομοιώσει την λειτουργία μιας ηλεκτροκίνητης γκαραζόπορτας. Η λειτουργία της βασίζεται στην λειτουργία του κυκλώματος αυτοματισμού που έχετε υλοποιήσει. Ετοιμάστε πρώτα το κύκλωμα αυτοματισμού και στη συνέχεια κάντε δεξί κλικ και επιλέξτε το 'Τοποθέτηση και σύνδεση εξαρτημάτων στην γκαραζόπορτα' για να προχωρήσετε στις ρυθμίσεις της γκαραζόπορτας."
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
        Return "GARAGE DOOR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Γκαραζόπορτα"
    End Function
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Me.Image = My.Resources.Gkaraz


        'Έλεγχος για κίνηση γκαραζόπορτας
        If Settings1 > -1 And Settings1 < maxActiveObjects Then
            Select Case allActiveObjects(Settings1).state
                Case GlobalInfo.state.motor_right, GlobalInfo.state.motor_left
                    If TimeStarted = Nothing Then
                        TimeStarted = Now()
                        InitialDoorPosition = DoorPosition
                    End If
                Case GlobalInfo.state.motor_not_powered
                    TimeStarted = Nothing
                    InitialDoorPosition = DoorPosition
            End Select

        End If


    End Sub

    'Άνοιγμα του παραθύρου  ρυθμίσεων του στοιχείου
    Public Overrides Sub ShowSettings()
        Dim sarwsh As Integer
        Dim s As String
        If SettingsForm Is Nothing Then SettingsForm = New GarageDoorSettingsForm()

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

        Dim TotalHeightis As Integer = doorBottomRight.Y - DoorTopLeft.Y


        'Εδώ θα δούμε αν η κίνηση πρέπει να ανεβάζει ή να κατεβάζει την γκαραζόπορτα
        '        Debug.Print("S2 " + Settings2.ToString + " motorspin left=" + motorspin.left)
        If Settings1 > -1 And Settings1 < maxActiveObjects Then
            If allActiveObjects(Settings1).state = Settings2 Then pros = 1 Else pros = -1
        End If




        DoorPosition = InitialDoorPosition + pros * TotalHeightis * (Secs / Settings5)

        'Αν βρισκόμαστε στα άκρα
        If (DoorPosition >= TotalHeightis) Or (DoorPosition <= 0) Then
            'Και ο κινητήρας δουλεύει
            If Not (TimeStarted = Nothing) Then
                If WasTheMotorRunningBefore > 3 Then allActiveObjects(Settings1).ThrowConnectionError("Η γκαραζόπορτα έφτασε στο τέρμα και ο κινητήρας δεν σταματά - Υπερθέρμανση κινητήρα.")
                WasTheMotorRunningBefore = WasTheMotorRunningBefore + 1
            End If
        End If

        If DoorPosition > TotalHeightis Then DoorPosition = TotalHeightis
        If DoorPosition < 0 Then DoorPosition = 0


        'If Not (TimeStarted = Nothing) And (DoorPosition = 0 Or DoorPosition = TotalHeightis) Then ThrowConnectionError(5, "Υπερθέρμανση κινητήρα") : MsgBox("thrown")


        Dim presound As Boolean = soundon

        soundon = False

        'Ενεργοποίηση άνω τερματικού διακόπτη
        If Settings3 > 0 And Settings3 < numberOfActiveObjects Then
            If DoorPosition >= TopTerminalSwitchPosition Then allActiveObjects(Settings3).changestate(GlobalInfo.state.energo) Else allActiveObjects(Settings3).changestate(GlobalInfo.state.anenergo)
        End If

        'Ενεργοποίηση άνω τερματικού διακόπτη
        If Settings4 > 0 And Settings4 < numberOfActiveObjects Then
            If DoorPosition >= BottomTerminalSwitchPosition Then allActiveObjects(Settings4).changestate(GlobalInfo.state.energo) Else allActiveObjects(Settings4).changestate(GlobalInfo.state.anenergo)
        End If

        soundon = presound


        'If DoorPosition > TopTerminalSwitchPosition Then


        Dim pos2 = New Point(DoorTopLeft.X, DoorTopLeft.Y + DoorPosition)

        'Μεταφορά σε απόλυτες συντεταγμένες
        Dim p1 = New Point((DoorTopLeft.X + Me.Location.X) * ratio, (DoorTopLeft.Y + Me.Location.Y) * ratio)
        Dim p2 = New Point((doorBottomRight.X + Me.Location.X) * ratio, (pos2.Y + Me.Location.Y) * ratio)


        'Dim pos2 = New Point((Me.Location.X + 148 + offset) * ratio, (Me.Location.Y + 107) * ratio)


        gr.FillRectangle(mybrush, New Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y))

        'Edit.Text = "state =" + allActiveObjects(Settings1).state.ToString + " global left=" + GlobalInfo.state.motor_left.ToString  'InitialDoorPosition.ToString + " " + DoorPosition.ToString + " pros=" + pros.ToString + " state = " + allActiveObjects(Settings1).state.ToString + " Settings2=" + Settings2.ToString + "  Settings3=" + Settings3.ToString + " Settings4=" + Settings4.ToString
    End Sub


    'Θα χρησιμοποιηθεί από το PLC για να επαναφέρει (Reset) τις ρυθμίσεις των χρονικών και των απαριθμητών
    Public Overrides Sub reset_all_parameters()
        DoorPosition = 0
        TimeStarted = Nothing
    End Sub
End Class
