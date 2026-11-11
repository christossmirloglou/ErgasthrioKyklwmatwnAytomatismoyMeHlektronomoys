Public Class LightSwitchComitater_Activeimage
    Inherits ActiveImage


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.COM00
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CCOM00
        End Select

    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()


        Me.information = "Διακόπτης φωτισμού κομιτατέρ (διπλός)"
        nameImage()

        addScrew(6, 4, 15, 15, "A", "Αυτή είναι η είσοδος του διακόπτη", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "1", "Αυτή είναι η πρώτη έξοδος", wirecolors(0), 1.5, Me)
        addScrew(31, 102, 15, 15, "2", "Αυτή είναι η δεύτερη έξοδος", wirecolors(0), 1.5, Me)


        Me.numberOfScrews = 2
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Πίεση πρώτου πλήκτρου")
        setHotKeyInformation(1, "Πίεση δεύτερου πλήκτρου")


        Me.state = GlobalInfo.state.c00


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
        Select Case Me.state
            Case GlobalInfo.state.c01
                screw(0).combine_all_values(screw(2).value)
                screw(2).combine_all_values(screw(0).value)
            Case GlobalInfo.state.c10
                screw(0).combine_all_values(screw(1).value)
                screw(1).combine_all_values(screw(0).value)
            Case GlobalInfo.state.c11
                screw(0).combine_all_values(screw(1).value)
                screw(1).combine_all_values(screw(0).value)

                screw(0).combine_all_values(screw(2).value)
                screw(2).combine_all_values(screw(0).value)


        End Select



    End Sub


    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************


    Public Overrides Function whatami() As String
        Return "DOUBLE LIGHT SWITCH"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Διακόπτης φωτισμού κομιτατέρ"
    End Function


    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()

        Select Case Me.state
            Case GlobalInfo.state.c00
                If SimulationSymbols Then Me.Image = My.Resources.CCOM00 Else Me.Image = My.Resources.COM00
            Case GlobalInfo.state.c01
                If SimulationSymbols Then Me.Image = My.Resources.CCOM01 Else Me.Image = My.Resources.COM01
            Case GlobalInfo.state.c10
                If SimulationSymbols Then Me.Image = My.Resources.CCOM10 Else Me.Image = My.Resources.COM10
            Case GlobalInfo.state.c11
                If SimulationSymbols Then Me.Image = My.Resources.CCOM11 Else Me.Image = My.Resources.COM11


        End Select



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
        If whatkey = getHotKey(0) Then 'αν πατηθεί το πρώτο πλήκτρο
            Select Case Me.state
                Case GlobalInfo.state.c00
                    changestate(GlobalInfo.state.c10)
                Case GlobalInfo.state.c01
                    changestate(GlobalInfo.state.c11)
                Case GlobalInfo.state.c10
                    changestate(GlobalInfo.state.c00)
                Case GlobalInfo.state.c11
                    changestate(GlobalInfo.state.c01)
            End Select

        End If

        If whatkey = getHotKey(1) Then 'αν πατηθεί το 2o πλήκτρο
            Select Case Me.state
                Case GlobalInfo.state.c00
                    changestate(GlobalInfo.state.c01)
                Case GlobalInfo.state.c01
                    changestate(GlobalInfo.state.c00)
                Case GlobalInfo.state.c10
                    changestate(GlobalInfo.state.c11)
                Case GlobalInfo.state.c11
                    changestate(GlobalInfo.state.c10)
            End Select

        End If


    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    'Εδώ μέσα θα καθορίζεται η συμπεριφορά του αντικειμένου όταν γίνεται κλικ επάνω του κατά την προσομοίωση
    Public Overrides Sub HasBeenClickedOnDuringSimulation()
        If soundon Then My.Computer.Audio.Play(My.Resources.LightSwitch_Sound, AudioPlayMode.Background)
        Select Case Me.state
            Case GlobalInfo.state.c00
                changestate(GlobalInfo.state.c01)
            Case GlobalInfo.state.c01
                changestate(GlobalInfo.state.c11)
            Case GlobalInfo.state.c11
                changestate(GlobalInfo.state.c10)
            Case GlobalInfo.state.c10
                changestate(GlobalInfo.state.c00)
        End Select

    End Sub
End Class
