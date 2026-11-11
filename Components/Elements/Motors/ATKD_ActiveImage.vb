Public Class ATKD_ActiveImage
    Inherits ActiveImage

    Public Overrides Sub initialization()


        Me.information = "Ασύγχρονος τριφασικός κινητήρας με συνδεσμολογία Τριγώνου."
        Me.Image = My.Resources.MotorD
        
        addScrew(31, 4, 15, 15, "U/U1", "Άνω άκρο του πρώτου τυλίγματος του ΑΤΚ (U1/U2)", wirecolors(0), 0.5, Me)
        addScrew(56, 4, 15, 15, "V/V1", "Άνω άκρο του δεύτερου τυλίγματος του ΑΤΚ (V1/V2)", wirecolors(1), 0.5, Me)
        addScrew(81, 4, 15, 15, "W/W1", "Άνω άκρο του τρίτου τυλίγματος του ΑΤΚ (W1/W2)", wirecolors(2), 0.5, Me)
        addScrew(106, 4, 15, 15, "PE", "Γείωση", wirecolors(4), 0.5, Me)
        Me.state = GlobalInfo.state.motor_not_powered
        Me.setMoveBounds()
        Me.numberOfScrews = 3

    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next


    End Sub
    Public Overrides Function whatami() As String
        Return "3PHASE MOTOR D"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Κινητήρας 3φ (Δ)"
    End Function

    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Select Case state
            Case GlobalInfo.state.motor_not_powered
                Me.Image = My.Resources.MotorD
            Case GlobalInfo.state.motor_right
                Me.Image = My.Resources.motorD_Working_Right
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_SOund, AudioPlayMode.Background)

            Case GlobalInfo.state.motor_left
                Me.Image = My.Resources.motorD_Working_Left
                If soundon Then My.Computer.Audio.Play(My.Resources.motor_working_SOund, AudioPlayMode.Background)




        End Select

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για σωστή κατανομή των φάσεων
    Public Function check_for_correct_phase_connection() As Boolean
        'Αν το άθροισμα των τιμών ισούται με τις τιμές των τριών φάσεων, τότε όλα είναι OK
        If (screw(0).value And V_PhasesNeutralMask) + (screw(1).value And V_PhasesNeutralMask) + (screw(2).value And V_PhasesNeutralMask) = V_L1 + V_L2 + V_L3 Then Return True
        Return False
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για λειτουργία του κινητήρα με δύο φάσεις μόνο
    Public Function check_for_connection_errors(ByRef returnstring As String) As Boolean
        Dim v As Long = (screw(0).value And V_LNMASK) Or (screw(1).value And V_LNMASK) Or (screw(2).value And V_LNMASK)
        returnstring = ""
        Con_Errors_Found = -1
        If ((screw(0).value) Or (screw(1).value) Or (screw(2).value)) And V_PE Then returnstring = "ΓΕΙΩΣΗ ΦΑΣΕΩΝ: Η γείωση συνδέεται μόνο στον ακροδέκτη ΡΕ και πουθενά αλλού." : Con_Errors_Found = 0
        Select Case v
            Case V_L1 + V_L2, V_L2 + V_L3, V_L3 + V_L1                      'Πρώτη περίπτωση μόνο δύο φάσεις
                returnstring = returnstring + " ΛΕΙΤΟΥΡΓΙΑ ΜΕ ΔΥΟ ΦΑΣΕΙΣ: Ο κινητήρας λειτουργεί με δυο από τις τρεις φάσεις. Ο κινητήρας δεν ξεκινά, αλλά, ο άξονας τρέμει. Αν το πρόβλημα εμφανιστεί ενώ ήδη λειτουργεί ο κινητήρας, τότε μπορεί να συνεχίσει να δουλεύει, αλλά, κινδυνέυει να κάψει τα τυλίγματα του. Σε αυτό το σημείο ενεργοποιείται το θερμικό. Αυτή είναι μια προβληματική κατάσταση που οδηγεί σε υψηλό θόρυβο, μείωση ισχύος, αύξηση θερμοκρασίας και πιθανή καταστροφή του κινητήρα."
                Con_Errors_Found = 1
                Return True
            Case V_L1 + V_N, V_L2 + V_N, V_L3 + V_N
                returnstring = returnstring + " ΛΕΙΤΟΥΡΓΙΑ ΜΕ ΜΙΑ ΦΑΣΗ ΚΑΙ ΟΥΔΕΤΕΡΟ: Θα πρέπει να χρησιμοποιήσετε μόνο τις 3 φάσεις για να τον συνδέσετε. Η χρήση του ουδετέρου μπορεί να οδηγήσει στην καταστροφή του."
                Con_Errors_Found = 2
                Return True

            Case V_L1 + V_L2 + V_N, V_L2 + V_L3 + V_N, V_L3 + V_L1 + V_N                      'Δεύτερη περίπτωση μόνο δύο φάσεις + Ουδέτερος
                returnstring = returnstring + " ΛΕΙΤΟΥΡΓΙΑ ΜΕ ΔΥΟ ΦΑΣΕΙΣ ΚΑΙ ΟΥΔΕΤΕΡΟ: Θα πρέπει να χρησιμοποιήσετε μόνο τις 3 φάσεις για να τον συνδέσετε. Η χρήση του ουδετέρου μπορεί να οδηγήσει στην καταστροφή του."
                Con_Errors_Found = 3
                Return True

            Case Else
                Return False
        End Select
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Έλεγχος για σωστή γείωση
    Public Function check_for_grounding_errors(ByRef returnstring As String) As Boolean
        Dim v = screw(3).value And V_PhasesNeutralMask
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


    '***************************************************************************************************************************************
    ' MotorSpin
    'Επιστρέφει True για αριστερόστροφη ή False για δεξιόστροφη φορά
    'ΠΡΕΠΕΙ ΝΑ ΕΧΟΥΝ ΓΙΝΕΙ ΟΛΟΙ ΟΙ ΕΛΕΓΧΟΙ ΠΡΩΤΑ
    '***************************************************************************************************************************************
    Function motorSpinLeft() As Boolean
        Dim tyligma1, tyligma2 As Long
        'Με τον παρακάτω τρόπο μετατρέπω τα δυαδικά δεδομενα σε αριθμόυς
        'L1 = 0
        'L2 = 1
        'L3 = 2
        tyligma1 = Long.Parse(Math.Log10(Long.Parse(screw(0).ScrewValueToBinary(4))))
        tyligma2 = Long.Parse(Math.Log10(Long.Parse(screw(1).ScrewValueToBinary(4))))

        'Αν το δεύτερο τύλιγμα έχει την επόμενη φάση, δηλαδή L1 -> L2  ή L2 -> L3 τότε έχουμε Ascending order
        'Επίσης Ascending order έχουμε με τους συνδυασμούς l3 - > l1
        'Αν το δεύτερο τύλιγμα έχει την προηγούμενη φάση, δηλαδή L2 -> L1  ή L3 -> L2 τότε έχουμε Descending order
        'Επίσης Descending order έχουμε με τους συνδυασμούς l1 -> l3

        If (tyligma1 = tyligma2 - 1) Or (tyligma1 = tyligma2 + 2) Then Return True Else Return False


    End Function



    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    Public Overrides Sub EvaluateObject()
        Dim report_grounding As String = ""
        Dim report_twophase As String = ""
        Dim bt As Boolean
        'Πρώτα θα δούμε αν έχει γίνει σωστή σύνδεση


        'Αν δεν παίρνει ρεύμα
        If (screw(0).value And V_PhasesNeutralMask) = 0 And (screw(1).value And V_PhasesNeutralMask) = 0 And (screw(2).value And V_PhasesNeutralMask) = 0 Then changestate(GlobalInfo.state.motor_not_powered) : Exit Sub
        bt = check_for_grounding_errors(report_grounding)
        Sim_Grounding_Error_Text = Sim_Grounding_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + report_grounding + vbNewLine

        'Πρώτα ελέγχω αν έχει γίνει σωστή σύνδεση των φάσεων
        Select Case check_for_correct_phase_connection()
            Case True
                'Αν όλα πάνε καλά τότε ορίζουμε τον τρόπο περιστροφής του κινητήρα.
                If motorSpinLeft() Then changestate(GlobalInfo.state.motor_left) Else changestate(GlobalInfo.state.motor_right)
            Case False
                bt = check_for_connection_errors(report_twophase)
                Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + report_twophase + vbNewLine

        End Select

        If ErrorSentFromElsewhere <> "" Then Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + ErrorSentFromElsewhere
        ErrorSentFromElsewhere = ""
    End Sub

    Public Overrides Sub Draw_Anything_Extra(WheretoDraw As Object, ratio As Single)
        Dim gr As Graphics = WheretoDraw.CreateGraphics
        Dim defaultPen As Pen = New Pen(Brushes.Red, 2)
        Dim offset As Integer = 0
        If Con_Errors_Found > -1 Then
            Dim pos1 = New Point((Me.Location.X + Me.Width / 2 - My.Resources.Fire.Width / 2) * ratio, (Me.Location.Y + Me.Height / 2 - My.Resources.Fire.Height) * ratio)
            gr.DrawImage(My.Resources.Fire, pos1.X, pos1.Y, My.Resources.Fire.Width * ratio, My.Resources.Fire.Height * ratio)
            Drop_Thermiko()
            Con_Errors_Found = -1
            If soundon Then My.Computer.Audio.Play(My.Resources.motor_error_sound, AudioPlayMode.Background)

        End If


    End Sub
   

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
