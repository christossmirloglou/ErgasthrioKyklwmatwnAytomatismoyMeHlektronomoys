Public Class MpoutonKoudouniou_ActiveImage
    Inherits LightSwitchSingle_Activeimage

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.MpoutonKoudouniou0

            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CMpoutonKoudouniou0
        End Select
    End Sub



    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()


        Me.information = "Πλήκτρο Κουδουνιου. Πρόκειται για ένα στιγμιαίο διακόπτη ο οποίος ενεργοποιείται μόνο την στιγμή που πιέζεται. Φέρει μια επαφή κανονικά άνοικτή (1-2) που κλείνει όταν πιεστεί το πλήκτρο."
        nameImage()

        addScrew(6, 4, 15, 15, "1", "Αυτό είναι το ένα άκρο του πλήκτρου", wirecolors(0), 0.5, Me)
        addScrew(6, 102, 15, 15, "2", "Αυτό είναι το άλλο άκρο του πλήκτρου", wirecolors(0), 1.5, Me)
        Me.numberOfScrews = 1
        Me.setMoveBounds()
        setHotkeyNumber(0)
        setHotKeyInformation(0, "Άνοιγμα/κλείσιμο διακόπτη")
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
        Return "DOORBELL BUTTON"
    End Function
    Public Overrides Function whatamiGreek() As String
        Return "Πλήκτρο (μπουτόν) κουδουνιού"
    End Function


    '*****************************************************************************************************************************************************************************
    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    '*****************************************************************************************************************************************************************************
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        If state = GlobalInfo.state.kleisto Then
            If SimulationSymbols Then Me.Image = My.Resources.CMpoutonKoudouniou1 Else Me.Image = My.Resources.MpoutonKoudouniou1
        Else
            If SimulationSymbols Then Me.Image = My.Resources.CMpoutonKoudouniou0 Else Me.Image = My.Resources.MpoutonKoudouniou0

        End If
    End Sub



    '***************************************************************************************************************************************
    ' Keypressed
    ' Ανάλογα με το πλήκτρο που του δίνουμε (που πιέζεται επάνω στην φόρμα Simulator) γίνονται οι απαραίτητες αλλαγές στο state
    '***************************************************************************************************************************************
    Public Overrides Sub keypressed(whatkey As Char)
        If whatkey = getHotKey(0) Then
            If Me.state = GlobalInfo.state.kleisto Then changestate(GlobalInfo.state.anoixto) Else changestate(GlobalInfo.state.kleisto)
        End If


    End Sub

End Class
