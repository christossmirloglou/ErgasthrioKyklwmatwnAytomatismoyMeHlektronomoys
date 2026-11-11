Public Class Fan_ActiveImage
    Inherits SimpleSinglePhaseComponentWithGrounding
    Const ScrewHeight = 85


    Const MyTitle As String = "Ανεμιστήρας"
    Const WhatMI As String = "FAN"
    Const WhatMIGreek As String = MyTitle

    Dim AnenergoImage As Image = My.Resources.Fan0
    Dim CAnenergoImage As Image = My.Resources.CFan0

    Dim EnergoImage As Image = My.Resources.Fan1
    Dim CEnergoImage As Image = My.Resources.CFan1

    Dim Mysound As System.IO.Stream = My.Resources.Click_Sound
    Const PlaySound = False

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = AnenergoImage
            Case True                               'Εικόνα με σύμβολο
                Me.Image = CAnenergoImage
        End Select
    End Sub

    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()



        Me.information = MyTitle
        nameImage()


        addScrew(6, ScrewHeight, 15, 15, "L/N", "Συνδέστε εδώ φάση ή ουδέτερο για να λειτουργήσει η συσκευή.", wirecolors(0), 1.5, Me)
        addScrew(31, ScrewHeight, 15, 15, "L/N", "Συνδέστε εδώ φάση ή ουδέτερο για να λειτουργήσει η συσκευή.", wirecolors(3), 1.5, Me)
        addScrew(56, ScrewHeight, 15, 15, "PE", "Συνδέστε εδώ την γείωση.", wirecolors(4), 1.5, Me)
        Me.numberOfScrews = 2
        Me.setMoveBounds()
        state = GlobalInfo.state.anenergo


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
        Return WhatMI
    End Function
    Public Overrides Function whatamiGreek() As String
        Return WhatMIGreek
    End Function


    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.energo
                If SimulationSymbols Then Me.Image = CEnergoImage Else Me.Image = EnergoImage
            Case Else
                If SimulationSymbols Then Me.Image = CAnenergoImage Else Me.Image = AnenergoImage


        End Select
    End Sub




    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        If soundon And PlaySound Then My.Computer.Audio.Play(Mysound, AudioPlayMode.Background)
        Refresh_Image_Reference_For_Simulation()

    End Sub

End Class
