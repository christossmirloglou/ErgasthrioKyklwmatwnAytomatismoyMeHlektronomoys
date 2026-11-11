Public Class TerminalSwitchTemplate
    Inherits ActiveImage



    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    '  Public Overrides Sub nameImage()
    ' 'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
    '     Select Case useStandardSymbolsDuringEdit
    '         Case False                              'Κανονική εικόνα
    '             Me.Image = My.Resources.Photo_Switch
    '         Case True                               'Εικόνα με σύμβολο
    '             Me.Image = My.Resources.CPhoto_Switch
    '     End Select
    ' End Sub


    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    ' Public Overrides Sub initialization()
    '     Me.information = "Φωτοκύτταρο. Φέρει μια επαφή (11-12) κανονικά κλειστή και μια (23-24) κανονικά ανοιχτή (Normally Open). Σε κατάσταση ηρεμίας η επαφή NO είναι ανοιχτή και η ΝC κλειστή. Όταν κάποιο αντικείμενο περάσει μπροστά από την φωτεινή δέσμη του φωτοκυττάρου τότε η επαφή NO κλείνει και η NC ανοίγει."
    '
    '        nameImage()
    '
    '
    '    Me.addScrew(81, 4, 15, 15, "11", "Αυτό είναι το ένα άκρο (έξοδος) της κανονικά κλειστής (Normally Closed) επαφής 11-12. Σε κατάσταση ηρεμίας η επαφή είναι κλειστή.", wirecolors(5), 0.5, Me)
    '     Me.addScrew(81, 102, 15, 15, "12", "Αυτό είναι το άλλο άκρο (έξοδος) της κανονικά κλειστής (Normally Closed) επαφής 11-12. Σε κατάσταση ηρεμίας η επαφή είναι κλειστή.", wirecolors(5), 1.5, Me)
    '     Me.addScrew(106, 4, 15, 15, "23", "Αυτό είναι το ένα άκρο (είσοδος) της κανονικά ανοιχτής (Normally Open) επαφής 23-24. Σε κατάσταση ηρεμίας η επαφή είναι ανοιχτή.", wirecolors(5), 0.5, Me)
    '     Me.addScrew(106, 102, 15, 15, "24", "Αυτό είναι το άλλο άκρο (έξοδος) της κανονικά ανοιχτής (Normally Open) επαφής 23-24. Σε κατάσταση ηρεμίας η επαφή είναι ανοιχτή.", wirecolors(5), 1.5, Me)



    '    Me.numberOfScrews = 3
    '    Me.setMoveBounds()
    '    setHotkeyNumber(1)
    '    Me.state = GlobalInfo.state.anenergo
    '     setHotKeyInformation(0, "Ενεργοποίηση του φωτοκυττάρου")
    '    setHotKeyInformation(1, "Απενεργοποίηση του φωτοκυττάρου")


    '    End Sub




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
            screw(0).combine_all_values(screw(1).value)
            screw(1).combine_all_values(screw(0).value)
        Else
            screw(2).combine_all_values(screw(3).value)
            screw(3).combine_all_values(screw(2).value)
        End If

    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    ' Public Overrides Function whatami() As String
    '     Return "PHOTOELECTRIC SENSOR"
    ' End Function

    '    Public Overrides Function whatamiGreek() As String
    '        Return "Φωτοκύτταρο"
    '    End Function

    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    'Public Overrides Sub Refresh_Image_Reference_For_Simulation()
    '
    '       If state = GlobalInfo.state.anenergo Then
    '           If SimulationSymbols Then Me.Image = My.Resources.CPhoto_Switch Else Me.Image = My.Resources.Photo_Switch
    '       Else
    '           If SimulationSymbols Then Me.Image = My.Resources.CPhoto_Switch_Active Else Me.Image = My.Resources.Photo_Switch_Active
    '
    '        End If
    '    End Sub

    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    'Public Overrides Sub state_has_changed()
    '    If soundon Then My.Computer.Audio.Play(My.Resources.Click_Sound, AudioPlayMode.Background)
    '    Refresh_Image_Reference_For_Simulation()

    '    End Sub





    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    Public Overrides Sub keypressed(whatkey As Char)
        If whatkey = getHotKey(0) Then changestate(GlobalInfo.state.energo)
        If whatkey = getHotKey(1) Then changestate(GlobalInfo.state.anenergo)

    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If state = GlobalInfo.state.energo Then changestate(GlobalInfo.state.anenergo) Else changestate(GlobalInfo.state.energo)

    End Sub
End Class
