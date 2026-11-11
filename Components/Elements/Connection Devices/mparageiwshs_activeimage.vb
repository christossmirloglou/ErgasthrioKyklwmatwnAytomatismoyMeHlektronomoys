Public Class MparaGeiwshs_activeimage
    Inherits ActiveImage


    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.mpara_geiwshs
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.Cmpara_geiwshs
        End Select
    End Sub






    Public Overrides Sub initialization()


        Me.information = "Μπάρα γείωσης"
        nameImage()
        addScrew(6, 15, 15, 15, "1", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)
        addScrew(31, 15, 15, 15, "2", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)
        addScrew(56, 15, 15, 15, "3", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)
        addScrew(81, 15, 15, 15, "4", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)
        addScrew(106, 15, 15, 15, "5", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)
        addScrew(131, 15, 15, 15, "6", "Μπάρα γείωσης.", wirecolors(4), 1.5, Me)

        Me.numberOfScrews = 5
        Me.setMoveBounds()
        state = GlobalInfo.state.leitoyrgei_kanonika

    End Sub
    Public Overrides Sub inform_screws()
        'Ενημέρωση όλων των σετ των βιδών που έχει το αντικείμενο
        For i = 0 To numberOfScrews
            screw(i).InitializeAll()
        Next

        For i = 0 To numberOfScrews
            For j = 0 To numberOfScrews
                screw(i).combine_all_values(screw(j).value)
                screw(j).combine_all_values(screw(i).value)
            Next j
        Next i
    End Sub
    Public Overrides Function whatami() As String
        Return "GROUND BAR"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Μπάρα γείωσης"
    End Function
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Me.Image = My.Resources.mpara_geiwshs

    End Sub

End Class
