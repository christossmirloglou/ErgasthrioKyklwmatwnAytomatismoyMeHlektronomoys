Public Class CircuitBreaker2P_ActiveImage
    Inherits ActiveImage

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.CircuitBreaker_2P
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CCircuitBreaker_2P_off
        End Select
    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()



        Me.information = "Διπολική αυτόματη ασφάλεια. Προστατεύει από υπεφόρτιση και βραχυκύκλωμα."
        nameImage()
        'Me.Image = My.Resources.CircuitBreaker_3P
        addScrew(6, 4, 15, 15, "1", "Αυτό είναι το άνω άκρο της πρώτης ασφάλειας.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Αυτό είναι το κάτω άκρο της πρώτης ασφάλειας.", wirecolors(0), 1.5, Me)
        addScrew(31, 4, 15, 15, "3", "Αυτό είναι το άνω άκρο της δεύτερης ασφάλειας.", wirecolors(1), 0.5, Me)
        addScrew(31, 102, 15, 15, "4", "Αυτό είναι το κάτω άκρο της δεύτερης ασφάλειας.", wirecolors(1), 1.5, Me)
        Me.numberOfScrews = 3
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Άνοιγμα της ασφάλειας")
        setHotKeyInformation(1, "Κλείσιμο της ασφάλειας")
        Me.state = GlobalInfo.state.kleisto

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

        If Me.state = GlobalInfo.state.kleisto Then
            For i = 0 To (numberOfScrews - 1) / 2
                screw(0 + i * 2).combine_all_values(screw(1 + i * 2).value)
                screw(1 + i * 2).combine_all_values(screw(0 + i * 2).value)
            Next i

        End If
    End Sub




    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "CIRCUIT BREAKER 2P"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Αυτόματη ασφάλεια διπολική"
    End Function

    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.kleisto Then
            If SimulationSymbols Then Me.Image = My.Resources.CCircuitBreaker_2P Else Me.Image = My.Resources.CircuitBreaker_2P
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CCircuitBreaker_2P_off Else Me.Image = My.Resources.CircuitBreaker_2P_off

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
        If whatkey = getHotKey(0) Then changestate(GlobalInfo.state.anoixto)
        If whatkey = getHotKey(1) Then changestate(GlobalInfo.state.kleisto)

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        If state = GlobalInfo.state.anoixto Then changestate(GlobalInfo.state.kleisto) Else changestate(GlobalInfo.state.anoixto)

    End Sub
End Class
