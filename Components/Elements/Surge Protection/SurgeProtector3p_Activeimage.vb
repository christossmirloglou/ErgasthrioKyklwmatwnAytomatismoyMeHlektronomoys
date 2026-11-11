Public Class SurgeProtector3p_ActiveImage
    Inherits ActiveImage

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.SurgeProtector3_Off
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CSurgeProtector3_Off
        End Select
    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()



        Me.information = "Τριφασικό αντικεραυνικό Τ1/Τ2. Προστατεύει τό κύκλωμα από κρουστικές υπερτάσεις που οφείλονται σε πλήγματα κεραυνού."
        nameImage()
        'Me.Image = My.Resources.CircuitBreaker_3P
        addScrew(6, 4, 15, 15, "1", "L1 - Συνδέστε εδώ την φάση 1.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Άκρο NC (κανονικά κλειστό) της μεταγωγικής επαφής του αντικεραυνικού - Όσο το αντικεραυνικό λειτουργεί κανονικά αυτή η επαφή (11-12) θα είναι κλειστή.", wirecolors(5), 1.5, Me)
        addScrew(31, 4, 15, 15, "3", "L2 - Συνδέστε εδώ τη φάση 2.", wirecolors(1), 0.5, Me)
        addScrew(31, 102, 15, 15, "4", "Κοινό άκρο C (common) της μεταγωγικής επαφής(11-12-14 του αντικεραυνικού", wirecolors(0), 1.5, Me)
        addScrew(56, 4, 15, 15, "5", "L3 - Συνδέστε εδώ την φάση 3.", wirecolors(2), 0.5, Me)
        addScrew(56, 102, 15, 15, "6", "Άκρο NΟ (κανονικά ανοιχτό) της μεταγωγικής επαφής του αντικεραυνικού - Όσο το αντικεραυνικό λειτουργεί κανονικά αυτή η επαφή (11-14) θα είναι ανοιχτή.", wirecolors(5), 1.5, Me)
        addScrew(81, 4, 15, 15, "7", "Ν - Συνδέστε εδώ τον Ουδέτερο.", wirecolors(3), 0.5, Me)
        addScrew(81, 102, 15, 15, "8", "ΡΕ - Συνδέστε εδώ την Γείωση (ΡΕ).", wirecolors(4), 1.5, Me)
        Me.numberOfScrews = 7
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Ανενεργο - Κανονική λειτουργία του αλεξικέραυνου.")
        setHotKeyInformation(1, "Ενεργό - Ενεργοποίηση του αλεξικέραυνου μετά το κεραυνικό πλήγμα.")
        Me.state = GlobalInfo.state.anenergo

    End Sub



    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        If Me.state = GlobalInfo.state.anenergo Then

            screw(3).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(3).value)


        End If

        If Me.state = GlobalInfo.state.energo Then

            screw(5).combine_all_values(screw(3).value)
            screw(3).combine_all_values(screw(5).value)


        End If

    End Sub




    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "SURGE PROTECTOR 3 PHASE"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Αντικεραυνικό (τριφασικό)"
    End Function

    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.energo Then
            If SimulationSymbols Then Me.Image = My.Resources.CSurgeProtector3_On Else Me.Image = My.Resources.SurgeProtector3_On
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CSurgeProtector3_Off Else Me.Image = My.Resources.SurgeProtector3_Off

        End If
    End Sub



    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        Refresh_Image_Reference_For_Simulation()
    End Sub


    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    Public Overrides Sub keypressed(whatkey As Char)
        If whatkey = getHotKey(0) Then changestate(GlobalInfo.state.anenergo)
        If whatkey = getHotKey(1) Then changestate(GlobalInfo.state.energo)

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        If state = GlobalInfo.state.anenergo Then changestate(GlobalInfo.state.energo) Else changestate(GlobalInfo.state.anenergo)

    End Sub



    Public Overrides Sub EvaluateObject()

        '1. Βλέπω τι είναι συνδεδεμένο στις 3 φάσεις
        Dim ErrorFound As Boolean = False
        Dim ErrorText As String = ""



        If screw(0).value = 0 Then ErrorText = ErrorText + "Δεν έχετε συνδέσει την L1." + vbNewLine : ErrorFound = True
        If screw(2).value = 0 Then ErrorText = ErrorText + "Δεν έχετε συνδέσει την L2." + vbNewLine : ErrorFound = True
        If screw(4).value = 0 Then ErrorText = ErrorText + "Δεν έχετε συνδέσει την L3." + vbNewLine : ErrorFound = True
        If (screw(0).value Or screw(2).value Or screw(4).value) <> (V_L1 Or V_L2 Or V_L3) Then ErrorText = ErrorText + "Λάθος συνδεσμολογία Φάσεων. Συνδέστε Φάση 1 στο L1, Φάση 2 στο L2 και Φάση 3 στο L3." + vbNewLine : ErrorFound = True
        If screw(6).value = 0 Then ErrorText = ErrorText + "Δεν έχετε συνδέσει τον ουδέτερο." + vbNewLine : ErrorFound = True
        If (screw(6).value <> V_N) And (screw(6).value <> 0) Then ErrorText = ErrorText + "Λάθος συνδεσμολογία Ουδετέρου. Συνδέστε μόνο τον Ουδέτερο στο άκρο Ν." + vbNewLine : ErrorFound = True
        If screw(7).value = 0 Then ErrorText = ErrorText + "Δεν έχετε συνδέσει την γείωση." + vbNewLine : ErrorFound = True
        If (screw(7).value <> V_PE) And (screw(7).value <> 0) Then ErrorText = ErrorText + "Λάθος συνδεσμολογία Γείωσης. Συνδέστε μόνο την Γείωση στο άκρο ΡΕ." + vbNewLine : ErrorFound = True

        If ErrorFound Then
            Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "):" + vbNewLine + ErrorText + _
                "Το αντικεραυνικό δεν θα λειτουργήσει σωστά γιατί έχετε κάνει λάθος συνδεσμολογία. Παρόλα αυτά το κύκλωμα συνεχίζει να λειτουργεί κανονικά"
        End If


    End Sub
End Class
