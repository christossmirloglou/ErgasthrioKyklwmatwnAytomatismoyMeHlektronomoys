Public Class SinglePhaseMotor_ActiveImage
    Inherits ActiveImage
    Public Overrides Sub initialization()


        Me.information = "Μονοφασικός κινητήρας Ε.Ρ."
        Me.Image = My.Resources.Motor1P
        addScrew(31, 4, 15, 15, "U1", "Άνω άκρο του κυρίου τυλίγματος (U1/U2)", wirecolors(0), 0.5, Me)
        addScrew(31, 102, 15, 15, "Z2", "Κάτω ακρο του βοηθητικού τυλίγματος (Z1/Z2)", wirecolors(0), 1.5, Me)
        addScrew(56, 4, 15, 15, "Z1", "Άνω άκρο του βοηθητικού τυλίγματος (Z1/Z2)", wirecolors(1), 0.5, Me)
        addScrew(56, 102, 15, 15, "U2", "Κάτω άκρο του κυρίου τυλίγματος (U1/U2)", wirecolors(1), 1.5, Me)
        addScrew(81, 4, 15, 15, "PE", "Γείωση", wirecolors(4), 0.5, Me)
        Me.setMoveBounds()
        Me.state = GlobalInfo.state.motor_not_powered
        Me.numberOfScrews = 4

    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

    End Sub
    Public Overrides Function whatami() As String
        Return "1PHASE MOTOR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Κινητήρας 1φ"
    End Function
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Select Case state
            Case GlobalInfo.state.motor_not_powered
                Me.Image = My.Resources.Motor1P
            Case GlobalInfo.state.motor_right
                Me.Image = My.Resources.Motor1PWorkingRight
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_sound, AudioPlayMode.Background)

            Case GlobalInfo.state.motor_left
                Me.Image = My.Resources.Motor1PWorkingLeft
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_sound, AudioPlayMode.Background)




        End Select
        If Con_Errors_Found > 0 Then If soundon Then My.Computer.Audio.Play(My.Resources.motor_error_sound, AudioPlayMode.Background)

    End Sub





    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για σωστή γείωση
    Public Function check_for_grounding_errors(ByRef returnstring As String) As Boolean
        Dim v = screw(4).value
        returnstring = ""
        Select Case v
            Case V_PE
                returnstring = returnstring + "Σώμα κινητήρα γειωμένο σωστά."
                Return False
            Case 0
                returnstring = returnstring + "Το σώμα του κινητήρα δεν έχει γειωθεί! Υπάρχει κίνδυνος ηλεκτροπληξίας για τους χειριστές!"
                Return True
            Case V_L1, V_L2, V_L3
                returnstring = returnstring + "Στον ακροδέκτη της γείωσης συνδέσατε φάση. ΑΜΕΣΟΣ ΚΙΝΔΥΝΟΣ ΗΛΕΚΤΡΟΠΛΗΞΙΑΣ ΚΑΙ ΘΑΝΑΤΟΥ ΓΙΑ ΤΟΥΣ ΧΕΙΡΙΣΤΕΣ!"
                Return True
            Case Else
                returnstring = returnstring + "Επικίνδυνη και λανθασμένη γείωση κινητήρα."
                Return True
        End Select

    End Function


    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    Public Overrides Sub EvaluateObject()
        Dim report_grounding As String = ""
        Dim groundingerror As Boolean
        Dim connectionerror As Boolean = False
        Dim report_connection_error As String = ""
        Dim sc0 As Long = screw(0).value And V_PhasesNeutralMask
        Dim sc1 As Long = screw(1).value And V_PhasesNeutralMask
        Dim sc2 As Long = screw(2).value And V_PhasesNeutralMask
        Dim sc3 As Long = screw(3).value And V_PhasesNeutralMask


        Dim i As Integer

        'Πρώτα απ' όλα ελέγχουμε αν υπάρχει βραχυκύκλωμα σε κάποια βίδα
        For i = 0 To 3
            If screw(0).isThereAShort Then changestate(GlobalInfo.state.motor_not_powered) : Exit Sub
        Next

        'Μετά έλεγχος για τη σωστή γείωση
        groundingerror = check_for_grounding_errors(report_grounding)
        Sim_Grounding_Error_Text = Sim_Grounding_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + report_grounding + vbNewLine


        'Αριστερόστροφη κίνηση
        If (sc0 = screw(1).value) And (sc2 = screw(3).value) And (sc0 <> sc2) Then
            If (((sc0 <= V_L3) And (sc0 > 0)) And (sc2 = V_N)) Or _
                (((sc2 <= V_L3) And (sc2 > 0)) And (sc0 = V_N)) Then
                changestate(GlobalInfo.state.motor_left)
                Exit Sub
            End If
        End If

        'Δεξιόστροφη κίνηση
        If (sc0 = sc2) And (sc1 = sc3) And (sc0 <> sc1) Then
            If (((sc0 <= V_L3) And (sc0 > 0)) And (sc1 = V_N)) Or _
                (((sc1 <= V_L3) And (sc1 > 0)) And (sc0 = V_N)) Then
                changestate(GlobalInfo.state.motor_right)
                Exit Sub
            End If
        End If

        connectionerror = check_for_connection_errors(report_connection_error)
        ErrorSentFromElsewhere = ""

        If Con_Errors_Found > -1 Then Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + report_connection_error + vbNewLine
        If ErrorSentFromElsewhere.Length > 1 Then Con_Errors_Found += 1
        Sim_Error_Text += ErrorSentFromElsewhere
        ErrorSentFromElsewhere = ""
        changestate(GlobalInfo.state.motor_not_powered)
    End Sub

    'Έλεγχος για την σωστη τροφοδοσία ενός τυλίγματος
    Public Function Check_Correct_Winding_Connection(WindingValue As Long) As Boolean
        If (WindingValue = (V_L1 + V_N)) Or (WindingValue = (V_L2 + V_N)) Or (WindingValue = (V_L3 + V_N)) Or (WindingValue = 0) Then Return True
        Return False
    End Function

    '------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για σφάλματα σύνδεσης
    '
    Public Function check_for_connection_errors(ByRef returnstring As String) As Boolean
        'Πρώτα έλεγχος για την ύπαρξη γείωσης στα άκρα τροφοδοσίας
        Dim v = screw(0).value Or screw(1).value Or screw(2).value Or screw(3).value
        Dim kyrio_tyligma As Long = (screw(0).value And V_PhasesNeutralMask) Or (screw(3).value And V_PhasesNeutralMask)
        Dim Bohuhtiko_tyligma As Long = (screw(1).value And V_PhasesNeutralMask) Or (screw(2).value And V_PhasesNeutralMask)
        Dim kyrioOK As Boolean = False
        Dim BohthitikoOK As Boolean = False
        Dim err_found_get_out As Boolean = False
        returnstring = ""
        Con_Errors_Found = -1
        If v And V_PE Then returnstring = "ΓΕΙΩΣΗ ΦΑΣΕΩΝ: Η γείωση συνδέεται μόνο στον ακροδέκτη ΡΕ και πουθενά αλλού." : Con_Errors_Found = 0

        'Αν η πρώτη βίδα του κυρίου τυλίγματος παίρνει φάση και η δεύτερη ουδέτερο ή αντίστροφα τότε το κύριο τύλιγμα είναι εντάξει
        If (((screw(0).value And V_PhaseMask) > 0) And ((screw(3).value And V_N) > 0)) Or (((screw(3).value And V_PhaseMask) > 0) And ((screw(0).value And V_N) > 0)) Then kyrioOK = True

        'Αν η πρώτη βίδα του βοηθητικού τυλίγματος παίρνει φάση και η δεύτερη ουδέτερο ή αντίστροφα τότε το βοηθητικό τύλιγμα είναι εντάξει
        If (((screw(1).value And V_PhaseMask) > 0) And ((screw(2).value And V_N) > 0)) Or (((screw(2).value And V_PhaseMask) > 0) And ((screw(0).value And V_N) > 0)) Then BohthitikoOK = True

        'Αν είναι όλα συνδεδεμένα κανονικά τότε δεν χρειάζεται περαιτέρω έλεγχος
        If kyrioOK And BohthitikoOK Then Return False

        'Αν στο κύριο τύλίγμα έχει συνδεθεί δύο φορές η ίδια φάση (ή ο ουδέτερος) και το ίδιο έχει γίνει στο βοηθητικό
        If (kyrio_tyligma = V_L1 Or _
            kyrio_tyligma = V_L2 Or _
            kyrio_tyligma = V_L3 Or _
            kyrio_tyligma = V_N Or
            kyrio_tyligma = 0) And
            (Bohuhtiko_tyligma = V_L1 Or _
            Bohuhtiko_tyligma = V_L2 Or _
            Bohuhtiko_tyligma = V_L3 Or _
            Bohuhtiko_tyligma = V_N Or
            Bohuhtiko_tyligma = 0) Then returnstring = "Προσέξτε την σύνδεση του κινητήρα. Τα τυλίγματα δεν τροφοδοτούνται σωστά." : Return False


        'Έλεγχος τυλιγμάτων για σωστή σύνδεση
        If Not Check_Correct_Winding_Connection(kyrio_tyligma) Then
            err_found_get_out = True
            returnstring = returnstring + "Το κύριο τύλιγμα δεν τροφοδοτείται σωστά. "
            Con_Errors_Found = 1
        End If


        If Not Check_Correct_Winding_Connection(Bohuhtiko_tyligma) Then
            err_found_get_out = True
            returnstring = returnstring + "Το βοηθητικό τύλιγμα δεν τροφοδοτείται σωστά. "
            Con_Errors_Found = 2
        End If

        'Αν δεν τροφοδοτείται το κύριο, ή έχει συνδεθεί μόνο ένα άκρο του
        If (((kyrio_tyligma = 0) Or (kyrio_tyligma = V_N) Or (kyrio_tyligma = V_L1) Or (kyrio_tyligma = V_L2) Or (kyrio_tyligma = V_L3)) And Bohuhtiko_tyligma > 0) Then
            err_found_get_out = True
            returnstring = returnstring + "Δεν τροφοδοτήσατε το κύριο τύλιγμα του κινητήρα. "
            Con_Errors_Found = 3

        End If

        'Αν δεν τροφοδοτείται το βοηθητικό, ή έχει συνδεθεί μόνο ένα άκρο του
        If (((kyrio_tyligma > 0)) And ((Bohuhtiko_tyligma = 0) Or (Bohuhtiko_tyligma = V_L1) Or (Bohuhtiko_tyligma = V_L2) Or (Bohuhtiko_tyligma = V_L3) Or (Bohuhtiko_tyligma = V_N))) Then
            err_found_get_out = True
            returnstring = returnstring + "Δεν τροφοδοτήσατε το βοηθητικό τύλιγμα του κινητήρα. "
            Con_Errors_Found = 4

        End If

        If (kyrio_tyligma And V_PE) Or (Bohuhtiko_tyligma And V_PE) Then
            err_found_get_out = True
            returnstring = returnstring + "Έχετε γειώσει τα τυλίγματα. "
            Con_Errors_Found = 5
        End If

        If err_found_get_out Then Return False
        Return True
    End Function

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Εδώ χρησιμοποίούμε αυτό το Sub για να σχεδιάσουμε την φωτιά επάνω στον κινητήρα

    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        Dim offset As Integer = 0
        If Con_Errors_Found > -1 Then
            Dim pos1 = New Point((Me.Location.X + Me.Width / 2 - My.Resources.new_file.Width / 2) * ratio, (Me.Location.Y + Me.Height / 2 - My.Resources.new_file.Height) * ratio)
            gr.DrawImage(My.Resources.Fire, pos1.X, pos1.Y, My.Resources.Fire.Width * ratio, My.Resources.Fire.Height * ratio)
            Drop_Thermiko()
            Con_Errors_Found = -1

        End If


    End Sub
End Class
