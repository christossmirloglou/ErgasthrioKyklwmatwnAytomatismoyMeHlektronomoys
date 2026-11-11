Public Class Switch5P_ActiveImage
    Inherits ActiveImage



    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Switch_5p
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CSwitch_5p_off
        End Select
    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        Me.information = "Τέτραπολικός διακόπτης"
        nameImage()
        Me.addScrew(6, 4, 15, 15, "1", "Αυτό είναι το άνω άκρο του πρώτου πόλου του διακόπτη.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Αυτό είναι το κάτω άκρο του πρώτου πόλου του διακόπτη", wirecolors(0), 1.5, Me)
        addScrew(31, 4, 15, 15, "3", "Αυτό είναι το άνω άκρο του δεύτερου πόλου του διακόπτη", wirecolors(1), 0.5, Me)
        addScrew(31, 102, 15, 15, "4", "Αυτό είναι το κάτω άκρο του δεύτερου πόλου του διακόπτη", wirecolors(1), 1.5, Me)
        addScrew(56, 4, 15, 15, "5", "Αυτό είναι το άνω άκρο του τρίτου πόλου του διακόπτη", wirecolors(2), 0.5, Me)
        addScrew(56, 102, 15, 15, "6", "Αυτό είναι το κάτω άκρο του τρίτου πόλου του διακόπτη.", wirecolors(2), 1.5, Me)
        addScrew(81, 4, 15, 15, "7", "Αυτό είναι το άνω άκρο του τέταρτου πόλου του διακόπτη", wirecolors(0), 0.5, Me)
        addScrew(81, 102, 15, 15, "8", "Αυτό είναι το κάτω άκρο του τέταρτου πόλου του διακόπτη.", wirecolors(0), 1.5, Me)
        addScrew(106, 4, 15, 15, "9", "Αυτό είναι το άνω άκρο του πέμπτου πόλου του διακόπτη", wirecolors(1), 0.5, Me)
        addScrew(106, 102, 15, 15, "10", "Αυτό είναι το κάτω άκρο του πέμπτου πόλου του διακόπτη.", wirecolors(1), 1.5, Me)
        Me.numberOfScrews = 9
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Άνοιγμα διακόπτη")
        setHotKeyInformation(1, "Κλείσιμο διακόπτη")
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
        Return "SWITCH 5P"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Διακόπτης πενταπολικός"
    End Function




    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.kleisto Then
            If SimulationSymbols Then Me.Image = My.Resources.CSwitch_5p Else Me.Image = My.Resources.Switch_5p
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CSwitch_5p_off Else Me.Image = My.Resources.Switch_5p_off

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

        If state = GlobalInfo.state.anoixto Then changestate(GlobalInfo.state.kleisto) Else changestate(GlobalInfo.state.anoixto)

    End Sub


End Class
