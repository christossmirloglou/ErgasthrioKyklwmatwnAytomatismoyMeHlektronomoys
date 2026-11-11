Public Class Start_ActiveImage
    Inherits ActiveImage

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Start
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CStart
        End Select

    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()
        Me.information = "Πλήκτρο (Μπουτόν) ΣΤΑΡΤ (Start). Πρόκειται για πλήκτρο που φέρει μια επαφή (13-14) κανονικά ανοιχτή (Normally Open). Σε κατάσταση ηρεμίας η επαφή είναι ανοιχτή. Όταν πιεστεί το πλήκτρο τότε η επαφή κλείνει και επιτρέπει την ροή του ηλεκτρικού ρεύματος για όση ώρα είναι πιεσμένο το πλήκτρο. Δεν θα πρέπει να χρησιμοποιηθεί ως διακόπτης ισχύος. Επιτρέπεται η χρήση του μόνο στο κύκλωμα αυτοματισμού, για χαμηλές τιμές ρεύματος."
        nameImage()

        addScrew(6, 4, 15, 15, "13", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) επαφής 13-14. Σε κατάσταση ηρεμίας η επαφή είναι ανοιχτή. Όταν πιεστεί το πλήκτρο τότε η επαφή κλείνει και επιτρέπει την ροή του ηλεκτρικού ρεύματος.", wirecolors(5), 0.5, Me)
        addScrew(6, 102, 15, 15, "14", "Αυτό είναι το άλλο άκρο (έξοδος) της κανονικά ανοιχτής (Normally Open) επαφής 13-14. Σε κατάσταση ηρεμίας η επαφή είναι ανοιχτή. Όταν πιεστεί το πλήκτρο τότε η επαφή κλείνει και επιτρέπει την ροή του ηλεκτρικού ρεύματος.", wirecolors(5), 1.5, Me)
        Me.numberOfScrews = 1
        Me.setMoveBounds()
        setHotkeyNumber(1)
        Me.state = GlobalInfo.state.anenergo
        setHotKeyInformation(0, "Πίεση του Start - Κλείσιμο επαφών")
        setHotKeyInformation(1, "Ανενεργό Start - Ανοιχτές επαφές")


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

        If Me.state = GlobalInfo.state.pathmeno Then
            screw(0).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(0).value)
        Else
        End If

    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "START"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Πλήκτρο Σταρτ"
    End Function



    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.pathmeno Then
            If SimulationSymbols Then Image = My.Resources.CStart_Pressed Else Image = My.Resources.Start_Pressed
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CStart Else Me.Image = My.Resources.Start

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
        If whatkey = getHotKey(0) Then changestate(GlobalInfo.state.pathmeno)
        If whatkey = getHotKey(1) Then changestate(GlobalInfo.state.anenergo)

    End Sub


    'Αυτό το sub υπάρχει για να προστεθεί κώδικας από τα αντικείμενα που θα δημιουργηθούν με βάση το ActiveImage
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
        If state = GlobalInfo.state.pathmeno Then changestate(GlobalInfo.state.anenergo) Else changestate(GlobalInfo.state.pathmeno)

    End Sub
End Class
