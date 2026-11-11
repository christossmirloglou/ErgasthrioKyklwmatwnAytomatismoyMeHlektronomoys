Public Class SimpleSinglePhaseComponentTemplate
    Inherits ActiveImage


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    'Public Overrides Sub nameImage()
    'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
    '        Select Case useStandardSymbolsDuringEdit
    '            Case False                              'Κανονική εικόνα
    '                Me.Image = My.Resources.siren
    '            Case True                               'Εικόνα με σύμβολο
    '                Me.Image = My.Resources.Csiren
    '        End Select
    'End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    'Public Overrides Sub initialization()
    '        Me.information = "Σειρήνα. Όταν τροφοδοτηθούν τα άκρα (1-2) της λυχνίας με τάση 230V τότε ενεργοποιείται να παράγει ήχο"

    '        nameImage()


    '        addScrew(6, 4, 15, 15, "1", "Το ένα άκρο (είσοδος) της σειρήνας. Αν τροφοδοτηθούν τα άκρα 1-2 με τάση 230V τότε θα ενεργοποιηθεί και θα αρχίσει να παράγει ήχο.", wirecolors(5), 0.5, Me)
    '        addScrew(6, 102, 15, 15, "2", "Το άλλο άκρο (έξοδος) της σειρήνας. Αν τροφοδοτηθούν τα άκρα 1-2 με τάση 230V τότε θα ενεργοποιηθεί και θα αρχίσει να παράγει ήχο.", wirecolors(3), 1.5, Me)
    '        Me.numberOfScrews = 1
    '        Me.setMoveBounds()
    '        state = GlobalInfo.state.anenergo
    '        setHotkeyNumber(-1)


    'End Sub

    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    'Public Overrides Sub keypressed(whatkey As Char)

    'End Sub

    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    'Public Overrides Function whatami() As String
    '    Return "SIREN"
    'End Function
    'Public Overrides Function whatamiGreek() As String
    '    Return "Σειρήνα"
    'End Function





    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    'Public Overrides Sub Refresh_Image_Reference_For_Simulation()
    '    Select Case state
    '        Case GlobalInfo.state.energo
    '            If SimulationSymbols Then Me.Image = My.Resources.Csiren_powered Else Me.Image = My.Resources.siren_powered
    '        Case Else
    '            If SimulationSymbols Then Me.Image = My.Resources.Csiren Else Me.Image = My.Resources.siren
    '    End Select
    'End Sub



    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    'Public Overrides Sub state_has_changed()
    '    If state = GlobalInfo.state.energo Then
    '        If soundon Then My.Computer.Audio.Play(My.Resources.siren_Sound, AudioPlayMode.Background)
    '    End If
    '    Refresh_Image_Reference_For_Simulation()
    'End Sub



    '***************************************************************************************************************************************
    'checkifDifferent
    'Έλεγχος αν δεν έχουμε την ίδια φάση συνδεδεμένη επάνω και κάτω
    '***************************************************************************************************************************************
    Function checkifDifferent(val1 As Integer, val2 As Integer) As Boolean
        If (val1 And 15) = (val2 And 15) Then Return False
        Return True
    End Function

    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    Public Overrides Sub EvaluateObject()
        Dim st = GlobalInfo.state.anenergo
        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
        Dim A1 As Long = screw(0).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(1).value And V_PhasesNeutralMask
        Dim A3 As Long = screw(0).value
        Dim A4 As Long = screw(1).value




        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(0).value Or screw(1).value
        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Or (a5 = V_N) Then st = GlobalInfo.state.anenergo : Sim_Error_Text = Sim_Error_Text + WhatAmIGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : changestate(st) : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
    (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then st = GlobalInfo.state.anenergo : Sim_Error_Text = Sim_Error_Text + WhatAmIGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : changestate(st) : Exit Sub



        'Αν έχει συνδεθεί σωστά
        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
    (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then st = GlobalInfo.state.energo

        ' A1 = screw(0).value
        ' A2 = screw(1).value





        changestate(st)

    End Sub
End Class
