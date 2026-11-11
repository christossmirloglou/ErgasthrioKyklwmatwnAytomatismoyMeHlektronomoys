Public Class SocketIND4p
    Inherits ActiveImage



    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        '  Select Case useStandardSymbolsDuringEdit
        '      Case False                              'Κανονική εικόνα
        '  Me.Image = My.Resources.Socket1ph1
        '      Case True                               'Εικόνα με σύμβολο
        '  Me.Image = My.Resources.CSocket1ph1
        ' End Select
        Me.Image = My.Resources.SocketIND4p1
    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()

        Me.information = "Τριφασική - Τετραπολική Βιομηχανική Πρίζα με φις"
        nameImage()
        Me.addScrew(6, 4, 15, 15, "1", "Εδώ συνδέστε την φάση L1 της παροχής.", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Εδώ συνδέστε την φάση L1 της συσκευής.", wirecolors(0), 1.5, Me)
        addScrew(31, 4, 15, 15, "3", "Εδώ συνδέστε την φάση L2 της παροχής.", wirecolors(1), 0.5, Me)
        addScrew(31, 102, 15, 15, "4", "Εδώ συνδέστε την φάση L2 της συσκευής.", wirecolors(1), 1.5, Me)
        addScrew(56, 4, 15, 15, "5", "Εδώ συνδέστε την φάση L3 της συσκευής.", wirecolors(2), 0.5, Me)
        addScrew(56, 102, 15, 15, "6", "Εδώ συνδέστε την φάση L3 της συσκευής.", wirecolors(2), 1.5, Me)
        addScrew(81, 4, 15, 15, "7", "Εδώ συνδέστε την γείωση της παροχής.", wirecolors(4), 0.5, Me)
        addScrew(81, 102, 15, 15, "8", "Εδώ συνδέστε την γείωση της συσκευής.", wirecolors(4), 1.5, Me)
        Me.numberOfScrews = 7
        Me.setMoveBounds()
        setHotkeyNumber(1)
        setHotKeyInformation(0, "Αποσύνδεση φις")
        setHotKeyInformation(1, "Σύνδεση φις")
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
            For i = 0 To 3
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
        Return "THREE PHASE INDUSTRIAL SOCKET 4 POLE"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Τριφασική τετραπολική βιομηχανική πρίζα"
    End Function




    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.kleisto Then
            Me.Image = My.Resources.SocketIND4p1
            '  If SimulationSymbols Then Me.Image = My.Resources.CSocket1ph1 Else Me.Image = My.Resources.Socket1ph1
        Else
            Me.Image = My.Resources.SocketIND4p0
            ' If SimulationSymbols Then Me.Image = My.Resources.CSocket1ph0 Else Me.Image = My.Resources.Socket1ph0

        End If
    End Sub

    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        If soundon Then My.Computer.Audio.Play(My.Resources.Socket_sound, AudioPlayMode.Background)
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
