Public Class DelayOff_ActiveImage
    Inherits ActiveImage
    Dim StartedWorkingAt As Integer = 0
    Dim IS_powered As Boolean = False
    Dim Was_powered As Boolean = False

    '***************************************************************************************************************************************
    ' nameImage
    'Ορίζει την εικόνα που θα πρέπει να φαίνεται στο αντικείμενο
    '***************************************************************************************************************************************
    Public Overrides Sub nameImage()
        'Αν ζητηθεί η δημιουργία αντικειμένου κατά τη διάρκεια του Edit, τότε εδώ θα ορίσουμε αν θα έχει την κανονική του εικόνα ή την εικόνα με το σύμβολο
        Select Case useStandardSymbolsDuringEdit
            Case False                              'Κανονική εικόνα
                Me.Image = My.Resources.DelayOff
            Case True                               'Εικόνα με σύμβολο
                Me.Image = My.Resources.CDelayOff
        End Select
    End Sub
    '***************************************************************************************************************************************
    ' Initialization
    'Χρησιμοποιείται κατά την φάση της δημιουργίας του αντικειμένου για να δώσει ορίσει τα ξεχωριστά χαρακτηριστικά του
    '***************************************************************************************************************************************
    Public Overrides Sub initialization()



        Me.information = "Χρονικό Delay Off. Φέρει δύο σετ επαφών. Η επαφή 15-16 NO είναι κανονικά ανοιχτή με χρονική λειτουργία. Η επαφή 27-28 NC είναι κανονικά κλειστή με χρονική λειτουργία. Για να ενεργοποιηθεί το χρονικό απαιτείται να τροφοδοτηθεί με τάση στα άκρα Α1-Α2. Η ενεργοποίηση γίνεται άμεσα και οι επαφές αλλάζουν άμεσα κατάσταση. Στη συνέχεια, μόλις σταματήσουμε να τροφοδοτούμε το Α1-Α2 οι επαφές συνεχίζουν να είναι ενεργοποιημένες (δεν απενεργοποιούνται άμεσα). Θα αλλάξουν κατάσταση μόνο όταν περάσει ο καθορισμένος (από τον χειριστή) χρόνος. Μπορείτε να ορίσετε αυτόν τον χρόνο κάνοντας δεξί κλικ επάνω στο χρονικό και επιλέγοντας `Ρύθμιση χρονικής καθυστέρησης` από το αναδυόμενο μενού."
        nameImage()

        

        addScrew(6, 4, 15, 15, "17", "Άνω άκρο της βοηθητικής επαφής 17-18 NO. Αυτή η επαφή θα κλείσει όταν τροφοδοτηθεί το Α1-Α2. Θα συνεχίσει να είναι κλειστή για όσο χρόνο τροφοδοτούμε το A1-A2. Αφού πάψει η τροφοδοσία του A1-A2 θα συνεχίσει να είναι κλειστή για τον καθορισμένο (από τον χειριστή) χρόνο και μετά θα επανέλθει σε κατάσταση ηρεμίας.", wirecolors(5), 0.5, Me)
        addScrew(6, 102, 15, 15, "18", "Κάτω άκρο της βοηθητικής επαφής 17-18 NO. Αυτή η επαφή θα κλείσει όταν τροφοδοτηθεί το Α1-Α2. Θα συνεχίσει να είναι κλειστή για όσο χρόνο τροφοδοτούμε το A1-A2. Αφού πάψει η τροφοδοσία του A1-A2 θα συνεχίσει να είναι κλειστή για τον καθορισμένο (από τον χειριστή) χρόνο και μετά θα επανέλθει σε κατάσταση ηρεμίας.", wirecolors(5), 1.5, Me)
        addScrew(31, 4, 15, 15, "25", "Άνω άκρο της βοηθητικής επαφής 25-26 NC. Αυτή η επαφή θα ανοίξει όταν τροφοδοτηθεί το Α1-Α2. Θα συνεχίσει να είναι ανοιχτή για όσο χρόνο τροφοδοτούμε το A1-A2. Αφού πάψει η τροφοδοσία του A1-A2 θα συνεχίσει να είναι ανοιχτή για τον καθορισμένο (από τον χειριστή) χρόνο και μετά θα επανέλθει σε κατάσταση ηρεμίας.", wirecolors(5), 0.5, Me)
        addScrew(31, 102, 15, 15, "26", "Κάτω άκρο της βοηθητικής επαφής 25-26 NC. Αυτή η επαφή θα ανοίξει όταν τροφοδοτηθεί το Α1-Α2. Θα συνεχίσει να είναι ανοιχτή για όσο χρόνο τροφοδοτούμε το A1-A2. Αφού πάψει η τροφοδοσία του A1-A2 θα συνεχίσει να είναι ανοιχτή για τον καθορισμένο (από τον χειριστή) χρόνο και μετά θα επανέλθει σε κατάσταση ηρεμίας.", wirecolors(5), 1.5, Me)
        addScrew(56, 4, 15, 15, "A1", "Άνω άκρο της επαφής Α1-Α2 τροφοδοσίας του χρονικού.", wirecolors(0), 0.5, Me)
        addScrew(56, 102, 15, 15, "A2", "Κάτω άκρο της επαφής Α1-Α2 τροφοδοσίας του χρονικού.", wirecolors(3), 1.5, Me)
        HasTimeSettings = True
        Me.numberOfScrews = 5
        Me.setMoveBounds()
        state = GlobalInfo.state.xroniko_anenergo
        Dim StartedWorkingAt As Integer = 0
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
        Select Case state
            
            Case GlobalInfo.state.xroniko_counting, GlobalInfo.state.xroniko_powered
                screw(0).combine_all_values(screw(1).value)     'NO
                screw(1).combine_all_values(screw(0).value)     'NO
            Case Else
                ' GlobalInfo.state.xroniko_anenergo, και tripped
                screw(2).combine_all_values(screw(3).value)     'NC
                screw(3).combine_all_values(screw(2).value)     'NC

        End Select
    End Sub





    '***************************************************************************************************************************************
    ' What Am I
    'Επιστρέφει ένα String με τον τύπο του εξαρτήματος
    '***************************************************************************************************************************************

    Public Overrides Function whatami() As String
        Return "DELAY OFF TIMER"
    End Function

    Public Overrides Function whatamiGreek() As String
        Return "Χρονικό Delay Off"
    End Function

    'RefreshImageForSimulation
    'Βασικά επιλέγει την σωστή εικόνα που θα πρέπει να προβληθεί κατά την προσομοίωση ανάλογα με το αν έχουμε επιλέξει να γίνει προσομοίωση με μορφή προβολή συμβόλων ή εξαρτημάτων
    Public Overrides Sub Refresh_Image_Reference_For_Simulation()
        Select Case state
            Case GlobalInfo.state.xroniko_anenergo
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOff Else Me.Image = My.Resources.DelayOff
            Case GlobalInfo.state.xroniko_powered
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOff_Powered Else Me.Image = My.Resources.DelayOff_Powered
            Case GlobalInfo.state.xroniko_counting
                If SimulationSymbols Then Me.Image = My.Resources.CDelayOff_Powered_Counting Else Me.Image = My.Resources.DelayOff_Powered_Counting


        End Select
    End Sub
    '***************************************************************************************************************************************
    ' State Has Changed
    'Κανει τις απαραίτητες αλλαγές όταν αλλάζει η κατάσταση του αντικειμένου
    '***************************************************************************************************************************************
    Public Overrides Sub state_has_changed()
        Refresh_Image_Reference_For_Simulation()

    End Sub


    '***************************************************************************************************************************************
    'checkifDifferent
    'Έλεγχος αν δεν έχουμε την ίδια φάση συνδεδεμένη επάνω και κάτω
    '***************************************************************************************************************************************
    Function checkifDifferent(val1 As Integer, val2 As Integer) As Boolean
        If (val1 And 15) = (val2 And 15) Then Return False
        Return True
    End Function





    '***************************************************************************************************************************************
    'Εδώ θα ρυθμίζουμε την συμπεριφορά του χρονικού
    '***************************************************************************************************************************************
    Public Overrides Sub EvaluateObject()
        Dim st = GlobalInfo.state.anenergo
        'Αν η πάνω και κάτω βίδα φέρει L1, L2, L3 ή N
        Dim A1 As Long = screw(4).value And V_PhasesNeutralMask
        Dim A2 As Long = screw(5).value And V_PhasesNeutralMask

        Dim A3 As Long = screw(4).value
        Dim A4 As Long = screw(5).value




        'Αν έχετε συνδέσει μόνο μια φάση ή την ίδια φάση
        Dim a5 = screw(4).value Or screw(5).value
        If (a5 = V_L1) Or (a5 = V_L2) Or (a5 = V_L3) Or (a5 = V_N) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Λάθος συνδεσμολογία" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub


        'Αν έχει συνδεθεί η γείωση στους ακροδέκτες της συσκευής
        If (((A3 = V_L1) Or (A3 = V_L2) Or (A3 = V_L3) Or (A3 = V_N)) And (A2 = V_PE)) Or _
    (((A4 = V_L1) Or (A4 = V_L2) Or (A4 = V_L3) Or (A4 = V_N)) And (A1 = V_PE)) Or (a5 = V_PE) Then st = GlobalInfo.state.xroniko_anenergo : Sim_Error_Text = Sim_Error_Text + whatamiGreek() + "(" + This_Objects_Number.ToString + "): Συνδέσατε την γείωση στους ακροδέκτες τροφοδοσίας" + vbNewLine : StartedWorkingAt = -1 : changestate(st) : Exit Sub




        If (((A1 = V_L1) Or (A1 = V_L2) Or (A1 = V_L3)) And (A2 = V_N)) Or _
           (((A2 = V_L1) Or (A2 = V_L2) Or (A2 = V_L3)) And (A1 = V_N)) Then

            'ΕΦΟΣΟΝ ΤΟ ΧΡΟΝΙΚΟ ΤΡΟΦΟΔΟΤΕΙΤΑΙ
            st = GlobalInfo.state.xroniko_powered
            IS_powered = True
            Was_powered = True
            StartedWorkingAt = Simulation_runsteps

        Else
            'Αν τώρα δεν τροφοδοτείται

            'αλλα τροφοδοτούνταν πριν λίγο τότε 
            If Was_powered Then
                'Αν έχει περάσει αρκετός χρόνος
                If Simulation_runsteps >= (StartedWorkingAt + TripTicks) Then
                    'κλείσε
                    st = GlobalInfo.state.xroniko_anenergo
                    Was_powered = False

                Else    'αν δεν έχει περάσει αρκετός χρόνος
                    st = GlobalInfo.state.xroniko_counting
                    Was_powered = True
                End If

            End If



        End If
        changestate(st)




    End Sub

End Class
