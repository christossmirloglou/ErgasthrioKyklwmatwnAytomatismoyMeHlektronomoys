Public Class Connector_ActiveImage
    Inherits ActiveImage


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.Connector
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CConnector
        End Select
    End Sub

    Public Overrides Sub initialization()


        Me.information = "Κλέμα Πίνακα"
        nameImage()
        addScrew(6, 4, 15, 15, "1", "Το ένα άκρο (είσοδος) της κλέμας", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Το άλλο άκρο (έξοδος) της κλέμας", wirecolors(0), 1.5, Me)






        Me.numberOfScrews = 1
        Me.setMoveBounds()
        state = GlobalInfo.state.leitoyrgei_kanonika

    End Sub
Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        screw(0).combine_all_values(screw(1).value)
        screw(1).combine_all_values(screw(0).value)
    End Sub
    Public Overrides Function whatami() As String
        Return "CONNECTOR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Κλέμα"
    End Function
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If SimulationSymbols Then Me.Image = My.Resources.CConnector Else Me.Image = My.Resources.Connector

    End Sub
End Class
