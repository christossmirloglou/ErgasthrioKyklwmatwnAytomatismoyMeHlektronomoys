Public Class RCBO1p_ActiveImage
    Inherits ActiveImage
    'Dim relay_timing() As Integer = {5, 10, 15, 20, 25, 30}
    Dim powered_timer, not_powered_timer As Long
    Dim first_run = True
    Dim PlaySoundOn As Boolean = True 'Χρησιμοποιείται για να μην ακούγεται πολλές φορές το κλικ κατά το άνοιγμα και κλείσιμο του ρελέ

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.RCBO1p_on

            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CRCBO1p_on

        End Select
    End Sub


    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        nameImage()


        Me.information = "Μονοφασικός μικροαυτόματος με Διακόπτης Διαρροής Έντασης (ΔΔΕ) (RCBO=Residual Current Breaker with Overcurrent) με 2 κύριες επαφές (L: 1-2, N: 3-4)."
        addScrew(6, 4, 15, 15, "L-1", "Αυτό είναι το ένα άκρο της πρώτης επαφής του RCBO. Σε αυτό το σημείο θα πρέπει να συνδέσετε την φάση L.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "T-2", "Αυτό είναι το άλλο άκρο της πρώτης επαφής του RCBO. Εδώ είναι η έξοδος της φάσης L.", wirecolors(0), 1.5, Me)
        addScrew(31, 4, 15, 15, "N-3", "Αυτό είναι το ένα άκρο της δεύτερης επαφής του RCBO. Σε αυτό το σημείο θα πρέπει να συνδέσετε τον ουδέτερο.", wirecolors(3), 0.5, Me)
        addScrew(31, 102, 15, 15, "N-4", "Αυτό είναι το άλλο άκρο της δεύτερης επαφής του RCBO. Εδώ είναι η έξοδος του ουδετέρου.", wirecolors(3), 1.5, Me)
        Me.numberOfScrews = 3
        'Ορισμός των ορίων που θα επιτρέπεται η μετακίνηση
        setHotkeyNumber(2)
        setHotKeyInformation(0, "Άνοιγμα RCBO")
        setHotKeyInformation(1, "Κλείσιμο RCBO")
        setHotKeyInformation(2, "Πίεση πλήκτρου δοκιμής RCBO")
        Me.setMoveBounds()
        state = GlobalInfo.state.kleisto

    End Sub



    '***************************************************************************************************************************************
    ' Inform Screws
    'Ενημερώνει τις αξίες των βιδών σύμφωνα με την τρέχουσα κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    'Βήματα λειτουργίας του ρελέ
    'rele_1_energo_phnio = 1                Στα 5ms ενεργοποιείται
    'rele_2_anoigei_nc = 2                  Στα 10ms
    'rele_3_kleinei_proorhs_ergasias = 3    Στα 15ms
    'rele_4_anoigei_kathysterimenhs_hremias = 4 Στα 20 ms
    'rele_5_kleinei_no = 5                      Στα 25 ms
    'rele_6_kleinoyn_kyries_epafes = 6          Στα 30 ms
    Public Overrides Sub inform_screws()

        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
            screw(i).InitializeAll()

        Next


        If Me.state = GlobalInfo.state.kleisto Then
            For i = 0 To 1
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
        Return "1 phase RCBO = Residual Current Breaker with Overcurrent (Single Phase)"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Μικροαυτόματος και Διακόπτης Διαρροής Έντασης (Μονοφασικός)"
    End Function


    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()

        If state = GlobalInfo.state.kleisto Then
            If SimulationSymbols Then Me.Image = My.Resources.CRCBO1p_on Else Me.Image = My.Resources.RCBO1p_on
        End If

        If state = GlobalInfo.state.anoixto Then
            If SimulationSymbols Then Me.Image = My.Resources.CRCBO1p_off Else Me.Image = My.Resources.RCBO1p_off

        End If

        If state = GlobalInfo.state.pathmeno Then
            If SimulationSymbols Then Me.Image = My.Resources.CRCBO1p_test Else Me.Image = My.Resources.RCBO1p_test
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
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του πηνίου του ρελέ.
    '***************************************************************************************************************************************

    ''Public Overrides Sub EvaluateObject()

    ''    End Sub


    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()

        If state = GlobalInfo.state.anoixto Then changestate(GlobalInfo.state.kleisto) Else changestate(GlobalInfo.state.anoixto)

    End Sub

    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    Public Overrides Sub keypressed(whatkey As Char)
        If whatkey = getHotKey(0) Then changestate(GlobalInfo.state.anoixto)
        If whatkey = getHotKey(1) Then changestate(GlobalInfo.state.kleisto)
        If whatkey = getHotKey(2) Then changestate(GlobalInfo.state.pathmeno)

    End Sub

End Class
