Public Class LightSwitchSingle_Activeimage
    Inherits ActiveImage


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.LightSwitchSingle_Off

            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CLightSwitchSingle_Off
        End Select
    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()


        Me.information = "Απλός διακόπτης φωτισμού"
        nameImage()

        addScrew(6, 4, 15, 15, "1", "Αυτό είναι το ένα άκρο του διακόπτη", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Αυτό είναι το άλλο άκρο του διακόπτη.", wirecolors(0), 1.5, Me)
        Me.numberOfScrews = 1
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Άνοιγμα διακόπτη")
        setHotKeyInformation(1, "Κλείσιμο διακόπτη")
        Me.state = GlobalInfo.state.anoixto


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

            screw(0).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(0).value)

        End If
    End Sub


    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************


    Public Overrides Function whatami() As String
        Return "LIGHT SWITCH 1P"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Απλός διακόπτης φωτισμού"
    End Function


    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.kleisto Then
            If SimulationSymbols Then Me.Image = My.Resources.CLightSwitchSingle_On Else Me.Image = My.Resources.LightSwitchSingle_On
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CLightSwitchSingle_Off Else Me.Image = My.Resources.LightSwitchSingle_Off

        End If
    End Sub


    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        If soundon Then My.Computer.Audio.Play(My.Resources.LightSwitch_Sound, AudioPlayMode.Background)
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
        If soundon Then My.Computer.Audio.Play(My.Resources.LightSwitch_Sound, AudioPlayMode.Background)
        If state = GlobalInfo.state.anoixto Then changestate(GlobalInfo.state.kleisto) Else changestate(GlobalInfo.state.anoixto)

    End Sub
End Class
