Public Class Faros_Activeimage
    Inherits SimpleSinglePhaseComponentTemplate
    Dim numberofticks As Integer = 0


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Faros0

            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.cFaros0
        End Select

    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()
        Me.information = "Φάρος. Όταν τροφοδοτηθούν τα άκρα (1-2) του φάρου με τάση 230V τότε αυτός θα ξεκινήσει να φωτοβολεί."
        nameImage()
        addScrew(31, 4, 15, 15, "1", "Το ένα άκρο του φάρου. Αν τροφοδοτηθούν τα άκρα 1-2 με τάση 230V τότε ο φάρος θα ανάψει.", wirecolors(5), 0.5, Me)
        addScrew(31, 102, 15, 15, "2", "Το άλλο άκρο του φάρου. Αν τροφοδοτηθούν τα άκρα 1-2 με τάση 230V τότε ο φάρος θα ανάψει.", wirecolors(3), 1.5, Me)
        Me.numberOfScrews = 1
        Me.setMoveBounds()
        state = GlobalInfo.state.anenergo
        setHotkeyNumber(-1)
        numberofticks = 0
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

    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************
    Public Overrides Function whatami() As String
        Return "ALARM SIGNAL LIGHT"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Φάρος"
    End Function

    '______________________________________________________________________________________________________________________________
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.energo
                If SimulationSymbols Then
                    Me.Image = My.Resources.cFaros1
                Else
                    numberofticks = numberofticks + 1
                    If numberofticks > 1000 Then numberofticks = 0
                    If (numberofticks Mod 10) >= 5 Then Me.Image = My.Resources.Faros1b Else Me.Image = My.Resources.Faros1a
                End If

            Case Else
                If SimulationSymbols Then Me.Image = My.Resources.cFaros0 Else Me.Image = My.Resources.Faros0


        End Select

    End Sub



    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()

    End Sub








End Class

